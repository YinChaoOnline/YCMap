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

namespace YCMap
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void menuItemOpenMapDocument_Click(object sender, EventArgs e)
        {
            ICommand openDocument = new ControlsOpenDocCommandClass();
            openDocument.OnCreate(axMapControl1.Object);
            openDocument.OnClick();
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            ICommand saveAsDocCommand
                = new ControlsSaveAsDocCommand();
            saveAsDocCommand.OnCreate(axMapControl1.Object);
            saveAsDocCommand.OnClick();
        }

        //地图文档保存
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            try
            {
                IMapDocument mapDocument = new MapDocumentClass();
                mapDocument.Open((axMapControl1.Object as IMapControlDefault).DocumentFilename);
                mapDocument.ReplaceContents(axMapControl1.Object as IMxdContents);

                IObjectCopy objCopy = new ObjectCopyClass(); //使用Copy，避免共享引用  
                axMapControl1.Map = (IMap)objCopy.Copy(mapDocument.get_Map(0));
                objCopy = null;

                mapDocument.Save(mapDocument.UsesRelativePaths, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("请联系管理员，错误原因是："+ex.Message);
            }
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

        private void menuItemNewMapDocument_Click(object sender, EventArgs e)
        {

        }

        private void menuItemAddData_Click(object sender, EventArgs e)
        {
            ICommand cmd =new ControlsAddDataCommandClass();
            cmd.OnCreate(axMapControl1.Object);
            cmd.OnClick();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            //TODO:check whether to save documents

            this.Close();
            Application.Exit();
        }
    }
}