namespace YCMap
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewMapDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenMapDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemAddData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBookmarks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCreateBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemManageBookmarks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlLayerAndProperty = new System.Windows.Forms.TabControl();
            this.tabPageLayers = new System.Windows.Forms.TabPage();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabControlMapAndPageLayout = new System.Windows.Forms.TabControl();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.tabPagePagelayout = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusBlank = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlLayerAndProperty.SuspendLayout();
            this.tabPageLayers.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            this.tabControlMapAndPageLayout.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.tabPagePagelayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuBookmarks,
            this.menuWindow});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(886, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewMapDocument,
            this.menuItemOpenMapDocument,
            this.toolStripSeparator1,
            this.menuItemSave,
            this.menuItemSaveAs,
            this.toolStripSeparator2,
            this.menuItemAddData,
            this.toolStripMenuItem2,
            this.menuItemExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(58, 21);
            this.menuFile.Text = "文件(&F)";
            // 
            // menuItemNewMapDocument
            // 
            this.menuItemNewMapDocument.Image = global::YCMap.Properties.Resources.DocumentNew32;
            this.menuItemNewMapDocument.Name = "menuItemNewMapDocument";
            this.menuItemNewMapDocument.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuItemNewMapDocument.Size = new System.Drawing.Size(174, 22);
            this.menuItemNewMapDocument.Text = "新建(&N)...";
            this.menuItemNewMapDocument.Click += new System.EventHandler(this.menuItemNewMapDocument_Click);
            // 
            // menuItemOpenMapDocument
            // 
            this.menuItemOpenMapDocument.Image = global::YCMap.Properties.Resources.GenericOpen32;
            this.menuItemOpenMapDocument.Name = "menuItemOpenMapDocument";
            this.menuItemOpenMapDocument.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuItemOpenMapDocument.Size = new System.Drawing.Size(174, 22);
            this.menuItemOpenMapDocument.Text = "打开(&O)...";
            this.menuItemOpenMapDocument.Click += new System.EventHandler(this.menuItemOpenMapDocument_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Image = global::YCMap.Properties.Resources.GenericSave32;
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemSave.Size = new System.Drawing.Size(174, 22);
            this.menuItemSave.Text = "保存(&S)";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Name = "menuItemSaveAs";
            this.menuItemSaveAs.Size = new System.Drawing.Size(174, 22);
            this.menuItemSaveAs.Text = "另存为(&A)...";
            this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // menuItemAddData
            // 
            this.menuItemAddData.Image = global::YCMap.Properties.Resources.DataAdd32;
            this.menuItemAddData.Name = "menuItemAddData";
            this.menuItemAddData.Size = new System.Drawing.Size(174, 22);
            this.menuItemAddData.Text = "添加数据(&T)...";
            this.menuItemAddData.Click += new System.EventHandler(this.menuItemAddData_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(171, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuItemExit.Size = new System.Drawing.Size(174, 22);
            this.menuItemExit.Text = "退出(&X)";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuBookmarks
            // 
            this.menuBookmarks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCreateBookmark,
            this.menuItemManageBookmarks});
            this.menuBookmarks.Name = "menuBookmarks";
            this.menuBookmarks.Size = new System.Drawing.Size(60, 21);
            this.menuBookmarks.Text = "书签(&B)";
            // 
            // menuItemCreateBookmark
            // 
            this.menuItemCreateBookmark.Image = global::YCMap.Properties.Resources.BookmarkCreate32;
            this.menuItemCreateBookmark.Name = "menuItemCreateBookmark";
            this.menuItemCreateBookmark.Size = new System.Drawing.Size(153, 22);
            this.menuItemCreateBookmark.Text = "创建书签(&C)...";
            this.menuItemCreateBookmark.Click += new System.EventHandler(this.menuItemCreateBookmark_Click);
            // 
            // menuItemManageBookmarks
            // 
            this.menuItemManageBookmarks.Image = global::YCMap.Properties.Resources.BookmarksManage32;
            this.menuItemManageBookmarks.Name = "menuItemManageBookmarks";
            this.menuItemManageBookmarks.Size = new System.Drawing.Size(153, 22);
            this.menuItemManageBookmarks.Text = "管理书签(&M)...";
            this.menuItemManageBookmarks.Click += new System.EventHandler(this.menuItemManageBookmarks_Click);
            // 
            // menuWindow
            // 
            this.menuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOverview});
            this.menuWindow.Name = "menuWindow";
            this.menuWindow.Size = new System.Drawing.Size(64, 21);
            this.menuWindow.Text = "窗口(&W)";
            // 
            // menuItemOverview
            // 
            this.menuItemOverview.Name = "menuItemOverview";
            this.menuItemOverview.Size = new System.Drawing.Size(152, 22);
            this.menuItemOverview.Text = "总览(&O)";
            this.menuItemOverview.Click += new System.EventHandler(this.menuItemOverview_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(886, 28);
            this.axToolbarControl1.TabIndex = 1;
            this.axToolbarControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnMouseMoveEventHandler(this.axToolbarControl1_OnMouseMove);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(276, 223);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 4;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(3, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(574, 327);
            this.axMapControl1.TabIndex = 5;
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(3, 3);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(280, 327);
            this.axTOCControl1.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControlLayerAndProperty);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlMapAndPageLayout);
            this.splitContainer1.Size = new System.Drawing.Size(886, 359);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 7;
            // 
            // tabControlLayerAndProperty
            // 
            this.tabControlLayerAndProperty.Controls.Add(this.tabPageLayers);
            this.tabControlLayerAndProperty.Controls.Add(this.tabPageProperties);
            this.tabControlLayerAndProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLayerAndProperty.Location = new System.Drawing.Point(0, 0);
            this.tabControlLayerAndProperty.Name = "tabControlLayerAndProperty";
            this.tabControlLayerAndProperty.SelectedIndex = 0;
            this.tabControlLayerAndProperty.Size = new System.Drawing.Size(294, 359);
            this.tabControlLayerAndProperty.TabIndex = 0;
            // 
            // tabPageLayers
            // 
            this.tabPageLayers.Controls.Add(this.axTOCControl1);
            this.tabPageLayers.Location = new System.Drawing.Point(4, 22);
            this.tabPageLayers.Name = "tabPageLayers";
            this.tabPageLayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLayers.Size = new System.Drawing.Size(286, 333);
            this.tabPageLayers.TabIndex = 0;
            this.tabPageLayers.Text = "图层";
            this.tabPageLayers.ToolTipText = "图层";
            this.tabPageLayers.UseVisualStyleBackColor = true;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.propertyGrid1);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(286, 333);
            this.tabPageProperties.TabIndex = 1;
            this.tabPageProperties.Text = "属性";
            this.tabPageProperties.ToolTipText = "属性";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(280, 327);
            this.propertyGrid1.TabIndex = 0;
            // 
            // tabControlMapAndPageLayout
            // 
            this.tabControlMapAndPageLayout.Controls.Add(this.tabPageMap);
            this.tabControlMapAndPageLayout.Controls.Add(this.tabPagePagelayout);
            this.tabControlMapAndPageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMapAndPageLayout.Location = new System.Drawing.Point(0, 0);
            this.tabControlMapAndPageLayout.Name = "tabControlMapAndPageLayout";
            this.tabControlMapAndPageLayout.SelectedIndex = 0;
            this.tabControlMapAndPageLayout.Size = new System.Drawing.Size(588, 359);
            this.tabControlMapAndPageLayout.TabIndex = 0;
            this.tabControlMapAndPageLayout.SelectedIndexChanged += new System.EventHandler(this.tabControlMapAndPageLayout_SelectedIndexChanged);
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.axMapControl1);
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMap.Size = new System.Drawing.Size(580, 333);
            this.tabPageMap.TabIndex = 0;
            this.tabPageMap.Text = "地图";
            this.tabPageMap.ToolTipText = "地图";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // tabPagePagelayout
            // 
            this.tabPagePagelayout.Controls.Add(this.axPageLayoutControl1);
            this.tabPagePagelayout.Location = new System.Drawing.Point(4, 22);
            this.tabPagePagelayout.Name = "tabPagePagelayout";
            this.tabPagePagelayout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePagelayout.Size = new System.Drawing.Size(580, 333);
            this.tabPagePagelayout.TabIndex = 1;
            this.tabPagePagelayout.Text = "布局";
            this.tabPagePagelayout.ToolTipText = "布局";
            this.tabPagePagelayout.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(574, 327);
            this.axPageLayoutControl1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusMessage,
            this.toolStripStatusBlank,
            this.toolStripStatusScale,
            this.toolStripStatusCoordinates});
            this.statusStrip1.Location = new System.Drawing.Point(0, 412);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(886, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusMessage
            // 
            this.toolStripStatusMessage.Name = "toolStripStatusMessage";
            this.toolStripStatusMessage.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusMessage.Text = "就绪";
            // 
            // toolStripStatusBlank
            // 
            this.toolStripStatusBlank.Name = "toolStripStatusBlank";
            this.toolStripStatusBlank.Size = new System.Drawing.Size(715, 17);
            this.toolStripStatusBlank.Spring = true;
            // 
            // toolStripStatusScale
            // 
            this.toolStripStatusScale.Name = "toolStripStatusScale";
            this.toolStripStatusScale.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusScale.Text = "当前坐标";
            // 
            // toolStripStatusCoordinates
            // 
            this.toolStripStatusCoordinates.Name = "toolStripStatusCoordinates";
            this.toolStripStatusCoordinates.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusCoordinates.Text = "当前比例尺";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 434);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "YCMap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControlLayerAndProperty.ResumeLayout(false);
            this.tabPageLayers.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.tabControlMapAndPageLayout.ResumeLayout(false);
            this.tabPageMap.ResumeLayout(false);
            this.tabPagePagelayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenMapDocument;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripMenuItem menuBookmarks;
        private System.Windows.Forms.ToolStripMenuItem menuItemCreateBookmark;
        private System.Windows.Forms.ToolStripMenuItem menuItemManageBookmarks;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlLayerAndProperty;
        private System.Windows.Forms.TabPage tabPageLayers;
        private System.Windows.Forms.TabPage tabPageProperties;
        private System.Windows.Forms.TabControl tabControlMapAndPageLayout;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.TabPage tabPagePagelayout;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewMapDocument;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddData;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusMessage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusBlank;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCoordinates;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusScale;
        private System.Windows.Forms.ToolStripMenuItem menuWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemOverview;
    }
}

