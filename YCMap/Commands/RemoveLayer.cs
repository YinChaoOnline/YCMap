using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YCMap.Commands
{
    public sealed class RemoveLayer : BaseCommand
    {
        private IMapControlDefault m_mapControl;
        public RemoveLayer()
        {
            base.m_caption = "移除";
            base.m_toolTip = "移除当前图层";
            base.m_message = "移除当前图层";
            try
            {
                base.m_bitmap = YCMap.Properties.Resources.RemoveLayer;
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
            m_mapControl.Map.DeleteLayer(layer);
        }
    }
}
