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
            base.m_caption = "放大到图层";
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
