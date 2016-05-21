using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace YCMap.Commands
{
    /// <summary>
    /// Summary description for OpenNewMapDocument.
    /// </summary>
    public sealed class OpenNewMapDocument : BaseCommand
    {
        private IHookHelper m_hookHelper;
        private ControlsSynchronizer m_controlsSynchronizer = null;
        private string m_sDocumentPath = string.Empty;

        public OpenNewMapDocument(ControlsSynchronizer controlsSynchronizer)
        {
            base.m_category = "MapDocument";
            base.m_caption = "打开地图文档";
            base.m_message = "打开地图文档";
            base.m_toolTip = "打开地图文档";
            base.m_name = "OpenNewMapDocument";

            m_controlsSynchronizer = controlsSynchronizer;

            try
            {
                base.m_bitmap = YCMap.Properties.Resources.GenericOpen32;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;

        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            //launch a new OpenFile dialog
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Map Documents (*.mxd)|*.mxd";
            dlg.Multiselect = false;
            dlg.Title = "Open Map Document";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string docName = dlg.FileName;

                IMapDocument mapDoc = new MapDocumentClass();
                if (mapDoc.get_IsPresent(docName) && !mapDoc.get_IsPasswordProtected(docName))
                {
                    mapDoc.Open(docName, string.Empty);

                    // set the first map as the active view
                    IMap map = mapDoc.get_Map(0);
                    mapDoc.SetActiveView((IActiveView)map);

                    m_controlsSynchronizer.PageLayoutControl.PageLayout = mapDoc.PageLayout;

                    m_controlsSynchronizer.ReplaceMap(map);

                    mapDoc.Close();

                    m_sDocumentPath = docName;
                }
            }
        }

        #endregion

        public string DocumentFileName
        {
            get { return m_sDocumentPath; }
        }
    }
}
