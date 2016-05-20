using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YCMap.Utils;

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

                //创建矩形元素
                IFillShapeElement fillShapeElement = ElementsHelper.GetRectangleElement(m_mapControl.Extent);
                UpdateMapControlGraphics(fillShapeElement as IElement);
            }
        }

        public Boolean UpdateMapControlGraphics(IElement element)
        {
            try
            {
                IGraphicsContainer graphicsContainer = axMapControl1.Map as IGraphicsContainer;
                // 在绘制前，清除 axMapControl2 中的任何图形元素
                graphicsContainer.DeleteAllElements();
                graphicsContainer.AddElement(element, 0);

                // 刷新
                IActiveView activeView = graphicsContainer as IActiveView;
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void FormOverview_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            IEnvelope envelope = null;
            if (axMapControl1.Map.LayerCount != 0 && m_mapControl != null)
            {
                // 按下鼠标左键移动矩形框
                if (e.button == 1)
                {
                    IPoint pPoint = new PointClass();
                    pPoint.PutCoords(e.mapX, e.mapY);
                    envelope = m_mapControl.Extent;
                    envelope.CenterAt(pPoint);
                }
                // 按下鼠标右键绘制矩形框
                else if (e.button == 2)
                {
                    envelope = this.axMapControl1.TrackRectangle();
                }
                m_mapControl.Extent = envelope;
                m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
        }

        //按下鼠标左键的时候移动矩形框，同时也改变主的图控件的显示范围
        private void axMapControl2_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            // 如果不是左键按下就直接返回
            if (e.button != 1) return;
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(e.mapX, e.mapY);
            this.m_mapControl.CenterAt(pPoint);
            this.m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }
    }
}

