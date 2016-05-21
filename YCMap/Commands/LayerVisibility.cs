using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace YCMap.Commands
{
    class LayerVisibility : BaseCommand, ICommandSubType
    {
        private IHookHelper m_hookHelper = new HookHelperClass();
        private Int32 m_subType;

        public LayerVisibility()
        {

        }

        public override void OnCreate(object hook)
        {
            m_hookHelper.Hook = hook;
        }

        public override void OnClick()
        {
            for (int i = 0; i <= m_hookHelper.FocusMap.LayerCount - 1; i++)
            {
                if (m_subType == 1) m_hookHelper.FocusMap.get_Layer(i).Visible = true;
                if (m_subType == 2) m_hookHelper.FocusMap.get_Layer(i).Visible = false;
            }
            m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        public override string Caption
        {
            get
            {
                if (m_subType == 1) return "打开所有图层";
                else return "关闭所有图层";
            }
        }
        public override bool Enabled
        {
            get
            {
                bool enabled = false;
                int i;
                if (m_subType == 1)
                {
                    for (i = 0; i <= m_hookHelper.FocusMap.LayerCount - 1; i++)
                    {
                        if (m_hookHelper.ActiveView.FocusMap.get_Layer(i).Visible == false)
                        {
                            enabled = true;
                            break;
                        }
                    }
                }
                else
                {
                    for (i = 0; i <= m_hookHelper.FocusMap.LayerCount - 1; i++)
                    {
                        if (m_hookHelper.ActiveView.FocusMap.get_Layer(i).Visible == true)
                        {
                            enabled = true;
                            break;
                        }
                    }
                }
                return enabled;
            }
        }


        public int GetCount()
        {
            return 2;
        }

        public void SetSubType(int SubType)
        {
            m_subType = SubType;
        }

    }
}
