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
    public partial class FormOverview : Form
    {
        private AxMapControl m_mapControl = null;

        public FormOverview(AxMapControl mapControl)
        {
            InitializeComponent();

            //定制mapcontrol，禁止键盘和鼠标对地图操作等
            axMapControl1.AutoKeyboardScrolling = false;
            axMapControl1.AutoMouseWheel = false;
            axMapControl1.ShowScrollbars = false;
            axMapControl1.BorderStyle = esriControlsBorderStyle.esriNoBorder;

            if (mapControl != null)
            {
                //初始化m_mapControl
                m_mapControl = mapControl;
            }
        }

        private void FormOverview_Load(object sender, EventArgs e)
        {
            if (m_mapControl != null && m_mapControl.LayerCount > 0)
            {
                // 当主地图显示控件的地图更换时，鹰眼中的地图也跟随更换
                axMapControl1.Map = new MapClass();

                //assign the spatial reference
                axMapControl1.SpatialReference = m_mapControl.SpatialReference;
                // 添加主地图控件中的所有图层到鹰眼控件中
                for (int i = m_mapControl.LayerCount - 1; i >= 0; i--)
                {
                    axMapControl1.AddLayer(m_mapControl.get_Layer(i));
                }
                // 设置 MapControl 显示范围至数据的全局范围
                axMapControl1.Extent = m_mapControl.ActiveView.FullExtent;
                // 刷新鹰眼控件地图
                axMapControl1.Refresh();
            }
        }
    }
}
