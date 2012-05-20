using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CsharpBits
{
    public partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        private void DebugWindow_Load(object sender, EventArgs e)
        {

        }
        delegate void AddErrorHelper(string err);
        public void AddError(string err)
        {
            if (txtOut.InvokeRequired)
                txtOut.Invoke(new AddErrorHelper(AddError), new object[] { err });
            else
                txtOut.Text += err + Environment.NewLine;
        }
    }
}
