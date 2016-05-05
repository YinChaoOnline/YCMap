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
    public partial class FormCreateBookmark : Form
    {
        private FormMain m_main = null;

        public FormCreateBookmark(FormMain main)
        {
            m_main = main;

            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_main.CreateBookmark(textBoxBookmarkName.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
