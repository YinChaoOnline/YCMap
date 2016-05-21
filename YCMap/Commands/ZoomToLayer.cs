using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YCMap.Commands
{
    public sealed class ZoomToLayer : BaseCommand
    {
        private IMapControlDefault m_mapControl;
        public ZoomToLayer()
        {
            base.m_caption = "缩放至图层";
            base.m_toolTip = "缩放至图层";
            base.m_message = "缩放至图层";
            try
            {
                base.m_bitmap = YCMap.Properties.Resources.ZoomToLayer;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        public override void OnCreate(object hook)
        {
            m_mapControl = hook as IMapControlDefault;
        }

        public override void OnClick()
        {
            ILayer layer = m_mapControl.CustomProperty as ILayer;
            m_mapControl.Extent = layer.AreaOfInterest;
        }
    }
}
