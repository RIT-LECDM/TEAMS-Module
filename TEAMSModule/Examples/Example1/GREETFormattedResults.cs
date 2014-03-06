using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TEAMSModule
{
    public partial class GREETFormattedResults : Form
    {
        public GREETFormattedResults()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show("Thing");
        }

    }
}
