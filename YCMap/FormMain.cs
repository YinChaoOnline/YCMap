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

namespace YCMap
{
    public partial class FormMain : Form
    {
        private IMapControlDefault m_mapControl = null;
        private IPageLayoutControlDefault m_pageLayoutControl = null;
        private ControlsSynchronizer m_controlsSynchronizer = null;

        public FormMain()
        {
            InitializeComponent();

            try
            {
                //初始化IMapControlDefault与IPageLayoutControlDefault接口变量
                m_mapControl = axMapControl1.Object as IMapControlDefault;
                m_pageLayoutControl = axPageLayoutControl1.Object as IPageLayoutControlDefault;
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

    }
}