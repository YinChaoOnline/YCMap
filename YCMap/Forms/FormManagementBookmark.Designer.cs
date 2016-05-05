namespace YCMap.Forms
{
    partial class FormManagementBookmark
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnZoomTo = new System.Windows.Forms.Button();
            this.btnPanTo = new System.Windows.Forms.Button();
            this.btnCreateBookmarks = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(243, 257);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 117;
            // 
            // btnZoomTo
            // 
            this.btnZoomTo.Location = new System.Drawing.Point(277, 12);
            this.btnZoomTo.Name = "btnZoomTo";
            this.btnZoomTo.Size = new System.Drawing.Size(75, 23);
            this.btnZoomTo.TabIndex = 1;
            this.btnZoomTo.Text = "缩放至(&Z)";
            this.btnZoomTo.UseVisualStyleBackColor = true;
            this.btnZoomTo.Click += new System.EventHandler(this.btnZoomTo_Click);
            // 
            // btnPanTo
            // 
            this.btnPanTo.Location = new System.Drawing.Point(277, 58);
            this.btnPanTo.Name = "btnPanTo";
            this.btnPanTo.Size = new System.Drawing.Size(75, 23);
            this.btnPanTo.TabIndex = 2;
            this.btnPanTo.Text = "平移至(&P)";
            this.btnPanTo.UseVisualStyleBackColor = true;
            // 
            // btnCreateBookmarks
            // 
            this.btnCreateBookmarks.Location = new System.Drawing.Point(277, 103);
            this.btnCreateBookmarks.Name = "btnCreateBookmarks";
            this.btnCreateBookmarks.Size = new System.Drawing.Size(75, 23);
            this.btnCreateBookmarks.TabIndex = 3;
            this.btnCreateBookmarks.Text = "创建(&E)";
            this.btnCreateBookmarks.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(277, 147);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "移除(&R)";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(277, 199);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 5;
            this.btnRemoveAll.Text = "移除所有";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(277, 246);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FormManagementBookmark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 285);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCreateBookmarks);
            this.Controls.Add(this.btnPanTo);
            this.Controls.Add(this.btnZoomTo);
            this.Controls.Add(this.listView1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormManagementBookmark";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "书签管理器";
            this.Load += new System.EventHandler(this.FormManagementBookmark_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnZoomTo;
        private System.Windows.Forms.Button btnPanTo;
        private System.Windows.Forms.Button btnCreateBookmarks;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnClose;
    }
}