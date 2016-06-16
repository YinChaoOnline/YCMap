using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using YCMap.Forms;
using YCMap.Commands;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using YCMap.Utils;
using YCMap.Tools;

namespace YCMap
{
    public partial class FormMain : Form
    {
        private IMapControlDefault m_mapControl = null;
        private IPageLayoutControlDefault m_pageLayoutControl = null;
        private ControlsSynchronizer m_controlsSynchronizer = null;
        private ITOCControlDefault m_tocControl = null;
        //TOCControl 中 Map 菜单
        private IToolbarMenu m_menuMap = new ToolbarMenuClass();
        //TOCControl 中图层菜单
        private IToolbarMenu m_menuLayer = new ToolbarMenuClass();
        private FormOverview m_FormOverview = null;

        public FormMain()
        {
            InitializeComponent();

            try
            {
                //初始化IMapControlDefault与IPageLayoutControlDefault接口变量
                m_mapControl = axMapControl1.Object as IMapControlDefault;
                m_pageLayoutControl = axPageLayoutControl1.Object as IPageLayoutControlDefault;
                m_tocControl = axTOCControl1.Object as ITOCControlDefault;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            m_controlsSynchronizer = new ControlsSynchronizer(m_mapControl, m_pageLayoutControl);
            //把 MapControl 和 PageLayoutControl 绑定起来(两个都指向同一个 Map),然后设置 MapControl 为活动的 Control
            m_controlsSynchronizer.BindControls(true);
            //为了在切换 MapControl 和 PageLayoutControl 视图同步，要添加 Framework Control
            m_controlsSynchronizer.AddFrameworkControl(axToolbarControl1.Object);
            m_controlsSynchronizer.AddFrameworkControl(axTOCControl1.Object);

            // 添加打开命令按钮到工具条
            //OpenNewMapDocument openMapDoc = new OpenNewMapDocument(m_controlsSynchronizer);
            //axToolbarControl1.AddItem(openMapDoc, -1, 0, false, -1, esriCommandStyles.esriCommandStyleIconOnly);
            //添加自定义菜单项到 TOCCOntrol 的 Map 菜单中

            m_menuMap.AddItem(new OpenNewMapDocument(m_controlsSynchronizer), -1,0, false, esriCommandStyles.esriCommandStyleIconAndText);
            //打开全部图层菜单
            m_menuMap.AddItem(new LayerVisibility(), 1,-1, true, esriCommandStyles.esriCommandStyleTextOnly);
            //关闭全部图层菜单
            m_menuMap.AddItem(new LayerVisibility(), 2, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuMap.SetHook(m_mapControl);

            //添加“移除图层”菜单项
            m_menuLayer.AddItem(new RemoveLayer(), -1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            //添加“放大到整个图层”菜单项
            m_menuLayer.AddItem(new ZoomToLayer(), -1, 1, true, esriCommandStyles.esriCommandStyleTextOnly);
            //设置菜单的 Hook
            m_menuLayer.SetHook(m_mapControl);

            try
            {
                axToolbarControl1.AddItem(new PanTool());
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #region 文件菜单

        //FIXME:open a map doc,click new map doc,will inject the bug
        private void menuItemNewMapDocument_Click(object sender, EventArgs e)
        {
            //非空白文档询问是否保存地图
            if (!String.IsNullOrEmpty(m_mapControl.DocumentFilename))
            {
                //询问是否保存当前地图
                DialogResult result = MessageBox.Show("是否保存当前地图?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //保存地图
                    menuItemSave_Click(null, null);
                }
            }
            // switch to map view
            tabControlMapAndPageLayout.SelectedTab = (TabPage)tabControlMapAndPageLayout.Controls[0];

            //创建新的地图实例
            IMap map = new MapClass();
            map.Name = "Map";
            m_controlsSynchronizer.MapControl.DocumentFilename = string.Empty;
            //更新新建地图实例的共享地图文档
            m_controlsSynchronizer.ReplaceMap(map);
        }

        private void menuItemOpenMapDocument_Click(object sender, EventArgs e)
        {
            // switch to map view
            tabControlMapAndPageLayout.SelectedTab = (TabPage)tabControlMapAndPageLayout.Controls[0];

            //launch the OpenMapDoc command
            OpenNewMapDocument openMapDoc = new OpenNewMapDocument(m_controlsSynchronizer);
            openMapDoc.OnCreate(m_controlsSynchronizer.MapControl.Object);
            openMapDoc.OnClick();

            m_controlsSynchronizer.MapControl.DocumentFilename = openMapDoc.DocumentFileName;
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            try
            {
                //空白文档不保存
                if (String.IsNullOrEmpty(m_mapControl.DocumentFilename)) return;

                //创建地图文档，调用open方法，调用ReplaceContents方法
                IMapDocument mapDocument = new MapDocumentClass();
                mapDocument.Open(m_mapControl.DocumentFilename);
                mapDocument.ReplaceContents(m_mapControl as IMxdContents);

                IObjectCopy objCopy = new ObjectCopyClass(); //使用Copy，避免共享引用  
                m_mapControl.Map = (IMap)objCopy.Copy(mapDocument.get_Map(0));
                objCopy = null;

                mapDocument.Save(mapDocument.UsesRelativePaths, false);
                mapDocument.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请联系管理员，错误原因是：" + ex.Message);
            }
        }


        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            ICommand saveAsDocCommand = new ControlsSaveAsDocCommandClass();
            saveAsDocCommand.OnCreate(m_controlsSynchronizer.ActiveControl);
            saveAsDocCommand.OnClick();
        }

        private void menuItemAddData_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsAddDataCommandClass();
            cmd.OnCreate(axMapControl1.Object);
            cmd.OnClick();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            //空白文档不保存
            if (String.IsNullOrEmpty(m_mapControl.DocumentFilename)) return;

            //询问是否保存当前地图
            DialogResult result = MessageBox.Show("是否保存当前地图?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //保存地图
                menuItemSave_Click(null, null);
            }
            Application.Exit();
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //用户关闭窗体，触发退出菜单click事件
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //空白文档不保存
                if (String.IsNullOrEmpty(m_mapControl.DocumentFilename)) return;
                menuItemExit_Click(null, null);
            }
        }

        private void menuItemOverview_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_FormOverview == null || m_FormOverview.IsDisposed)
                {
                    m_FormOverview = new FormOverview(axMapControl1);
                }
                m_FormOverview.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Bookmarks

        private void menuItemCreateBookmark_Click(object sender, EventArgs e)
        {
            FormCreateBookmark frm = new FormCreateBookmark(this);
            frm.ShowDialog();
        }

        private void menuItemManageBookmarks_Click(object sender, EventArgs e)
        {
            FormManagementBookmark frm = new FormManagementBookmark(axMapControl1);
            frm.Show();
        }

        //地图被替换时，加载地图文档的书签集合
        //释放总览窗体，并关闭
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            /*
             * 获取地图，然后，获取书签集合
             * 如果地图有书签，遍历书签，每个书签创建一个菜单
             * 如果没书签，直接return；
             */

            //获取书签集合
            IMapBookmarks mapBookmarks =
                axMapControl1.Map as IMapBookmarks;
            IEnumSpatialBookmark bookmarks
                = mapBookmarks.Bookmarks;

            //获取当前书签
            ISpatialBookmark currentBookmark
                = bookmarks.Next();

            //如果没书签直接退出函数，有，则删除原地图文档的书签菜单，并添加一个分割条
            if (currentBookmark == null)
            {
                return;
            }
            else
            {
                Int32 bookmarksStartMenuCount = menuBookmarks.DropDownItems.Count;
                if (bookmarksStartMenuCount > 2)//有其他地图书签时
                {
                    for (int i = 2; i < bookmarksStartMenuCount; i++)
                    {
                        menuBookmarks.DropDownItems.RemoveAt(2);
                    }
                }
                //添加一个分割条
                menuBookmarks.DropDownItems.Add(new ToolStripSeparator());
            }

            //遍历书签菜单，添加菜单
            ToolStripMenuItem tempMenu = null;
            while (currentBookmark != null)
            {
                tempMenu = new ToolStripMenuItem(currentBookmark.Name);
                tempMenu.Click += new EventHandler(tempMenu_Click);
                //存储书签
                tempMenu.Tag = currentBookmark;
                menuBookmarks.DropDownItems.Add(tempMenu);

                currentBookmark = bookmarks.Next();
            }

            //释放总览窗体并关闭
            CloseOverviewForm();
        }

        private void CloseOverviewForm()
        {
            if (m_FormOverview != null)
            {
                m_FormOverview.DialogResult = DialogResult.OK;
                m_FormOverview.Close();
            }
        }

        void tempMenu_Click(object sender, EventArgs e)
        {
            ISpatialBookmark bookmark
                = (sender as ToolStripMenuItem).Tag as ISpatialBookmark;
            if (bookmark != null)
            {
                bookmark.ZoomTo(axMapControl1.Map);
                //刷新地图
                //axMapControl1.ActiveView.Refresh();
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, null, axMapControl1.ActiveView.Extent);
            }
        }

        public void CreateBookmark(String bookmarkName)
        {
            //创建菜单项，其text为用户输入的文本框，但它被点击时，
            //地图就会zoom到某个位置
            IAOIBookmark mapBookmark = new AOIBookmarkClass();
            mapBookmark.Name = bookmarkName;
            mapBookmark.Location = axMapControl1.ActiveView.Extent;

            IMapBookmarks boomarks = axMapControl1.Map as IMapBookmarks;
            boomarks.AddBookmark(mapBookmark);

            ToolStripMenuItem menuItem = new ToolStripMenuItem(bookmarkName);
            menuItem.Click += new EventHandler(menuItem_Click);
            menuItem.Tag = mapBookmark;

            //被添加到书签菜单里面
            menuBookmarks.DropDownItems.Add(menuItem);
        }

        void menuItem_Click(object sender, EventArgs e)
        {
            IAOIBookmark bookmark = (sender as ToolStripMenuItem).Tag
                as IAOIBookmark;
            bookmark.ZoomTo(axMapControl1.Map);
            axMapControl1.ActiveView.Refresh();
        }

        #endregion

        #region MyRegion

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            //如果不是右键按下直接返回
            if (e.button != 2) return;

            esriTOCControlItem itemType = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap basicMap = null;
            ILayer layer = null;
            object other = null;
            object data = null;

            //判断所选菜单的类型
            m_tocControl.HitTest(e.x, e.y, ref itemType, ref basicMap, ref layer, ref other, ref data);

            //确定选定的菜单类型， Map 或是图层菜单
            if (itemType == esriTOCControlItem.esriTOCControlItemMap)
                m_tocControl.SelectItem(basicMap, null);
            else
                m_tocControl.SelectItem(layer, null);
            //设置 CustomProperty 为 layer ( 用于自定义的 Layer 命令)
            m_mapControl.CustomProperty = layer;
            //弹出右键菜单
            if (itemType == esriTOCControlItem.esriTOCControlItemMap)
                m_menuMap.PopupMenu(e.x, e.y, m_tocControl.hWnd);
            if (itemType == esriTOCControlItem.esriTOCControlItemLayer)
                m_menuLayer.PopupMenu(e.x, e.y, m_tocControl.hWnd);
        }

        private void axToolbarControl1_OnMouseMove(object sender, IToolbarControlEvents_OnMouseMoveEvent e)
        {
            // 取得鼠标所在工具的索引号
            int index = axToolbarControl1.HitTest(e.x, e.y, false);
            if (index != -1)
            {
                // 取得鼠标所在工具的 ToolbarItem
                IToolbarItem toolbarItem = axToolbarControl1.GetItem(index);
                // 设置状态栏信息
                toolStripStatusMessage.Text = toolbarItem.Command.Message;
            }
            else
            {
                toolStripStatusMessage.Text = " 就绪 ";
            }
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                //弹出右键菜单
                m_menuMap.PopupMenu(e.x, e.y, m_mapControl.hWnd);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            // 显示当前比例尺,整数
            toolStripStatusScale.Text = " 比例尺 1:" + axMapControl1.MapScale.ToString("f0");

            // 显示当前坐标，保留小数点后四位
            toolStripStatusCoordinates.Text = String.Format(" 当前坐标 X = {0}, Y={1} {2}",
                                                                                                e.mapX.ToString("f4"),
                                                                                                e.mapY.ToString("f4"),
                                                                                                YCMap.Utils.SystemHelper.ConvertEsriUnit(axMapControl1.MapUnits));
        }

        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            //创建矩形元素
            IFillShapeElement fillShapeElement = ElementsHelper.GetRectangleElement(e.newEnvelope as IGeometry);

            //刷新总览窗体的mapcontrol
            if (m_FormOverview != null && !m_FormOverview.IsDisposed)
            {
                m_FormOverview.UpdateMapControlGraphics(fillShapeElement as IElement);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //隐藏总览窗体
                if (m_FormOverview != null && !m_FormOverview.IsDisposed)
                {
                    m_FormOverview.Hide();
                }
            }
            else
            {
                m_FormOverview.Show();
            }
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {

        }

        private void FormMain_Activated(object sender, EventArgs e)
        {

        }
        private void FormMain_Leave(object sender, EventArgs e)
        {

        }

        private void tabControlMapAndPageLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMapAndPageLayout.SelectedIndex == 0) //map view
            {
                //activate the MapControl and deactivate the PageLayoutControl
                m_controlsSynchronizer.ActivateMap();
            }
            else //layout view
            {
                //activate the PageLayoutControl and deactivate the MapControl
                m_controlsSynchronizer.ActivatePageLayout();
            }
        }

        #endregion


    }
}