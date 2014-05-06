using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAMSModule;

namespace TEAMSModule
{
    public partial class SplashPage : Form
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The user clicks "Start".
        /// The form closes and the CopyrightPage form is loaded.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Copyright c = new Copyright();
            this.Close();
            c.Show();
        }
    }
}
