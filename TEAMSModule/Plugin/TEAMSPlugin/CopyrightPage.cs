using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAMSModule;
using TEAMS_Plugin;
namespace TEAMSModule
{
    public partial class Copyright : Form
    {
        public Copyright()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The user selects "I Understand" to the copyright notice.
        /// CopyrightForm closes and the main TEAM Module Input form is loaded.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            TEAMS t = new TEAMS();
            t.Show();
            this.Close();
        }
    }
}
