using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YCMap.Forms
{
    public partial class FormManagementBookmark : Form
    {
        private AxMapControl m_AxMapControl = null;
        private IEnumSpatialBookmark m_BookMarks = null;//地图书签集合

        public FormManagementBookmark(AxMapControl axMapControl)
        {
            InitializeComponent();

            m_AxMapControl = axMapControl;

            //获取地图书签集合
            if (m_AxMapControl!=null)
            {
                IMapBookmarks mapBookmarksWrapper = m_AxMapControl.Map as IMapBookmarks;
                m_BookMarks = mapBookmarksWrapper.Bookmarks;
            }
        }

        private void FormManagementBookmark_Load(object sender, EventArgs e)
        {
            ISpatialBookmark currentBookmark = m_BookMarks.Next();

            while (currentBookmark!=null)
            {
                //生成一个listviewitem,并且添加到listview1
                ListViewItem lvi = new ListViewItem();
                lvi.Text = currentBookmark.Name;
                listView1.Items.Add(lvi);

                currentBookmark = m_BookMarks.Next();
            }
        }

        private void btnZoomTo_Click(object sender, EventArgs e)
        {
            //找到用户选中的 ISpatialBookmark
            m_BookMarks.Reset();//书签指针归零
            ISpatialBookmark theBookmark = m_BookMarks.Next();
            while (theBookmark!=null)
            {
                if (theBookmark.Name==listView1.SelectedItems[0].Text)
                {
                     //调用zoomto
                    theBookmark.ZoomTo(m_AxMapControl.Map);
                    m_AxMapControl.ActiveView.Refresh();
                }
                theBookmark = m_BookMarks.Next();
            }
        }
    }
}
