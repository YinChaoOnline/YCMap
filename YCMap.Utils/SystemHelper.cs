using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YCMap.Utils
{
   public class SystemHelper
    {
        public static String ConvertEsriUnit(esriUnits units)
        {
            String zhUnits = "unknown";
            if (units.ToString().Contains("esri"))
            {
                zhUnits = units.ToString().Substring(4);
            }
            return zhUnits;
        }
    }
}
