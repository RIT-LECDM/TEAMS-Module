using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlugInsInterfaces.PluginTypes;
using PlugInsInterfaces;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using TEAMSModule;

namespace WindowsApplication1
{
    /// <summary>
    /// This plugin example shows a very simple way to grab results from the GREET calculated pathways
    /// </summary>
    public class ResultsAccess : APlugin
    {
        /// <summary>
        /// Controller that allows access to the data and functions
        /// </summary>
        public static IGREETController controler;

        /// <summary>
        /// A array of the menu items for this plugin
        /// </summary>
        //This can add as many menu items as we want
        ToolStripMenuItem[] items = new ToolStripMenuItem[2];

        #region APlugin
        /// <summary>
        /// Initialize the plugin, called once after the DLL is loaded into GREET
        /// </summary>
        /// <param name="controler"></param>
        /// <returns></returns>
        //This is where the plugin actually gets called into GREET, so you make things that you can call here and they will show up
        public override bool InitializePlugin(IGREETController controler)
        {
            //init the controller that is used to send action and data requests to GREET
            ResultsAccess.controler = controler;

            //init menu items collection for this example (The text here is what will come up in the GREET model itself)
            ToolStripMenuItem read = new ToolStripMenuItem("TEAMS");
            
            read.Click += (s, e) =>
            {
                //generates and displays the splashpage form when the plugin is opened.
                SplashPage te = new SplashPage();
                te.Show();
            };
            this.items[0] = read;

            return true;
        }

        public override string GetPluginName
        {
            get { return "TEAMS"; }
        }
        public override string GetPluginDescription
        {
            get { return "Allows the user to perform a lifecycle analysis of maritime freight transportation"; }
        }
        public override string GetPluginVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }
        public override System.Drawing.Image GetPluginIcon
        {
            get { return null; }
        }
        #endregion

        #region menu items

        /// <summary>
        /// Called when the GREET main form is initializing, returns the menu items for this plugin
        /// </summary>
        /// <returns></returns>
        public override System.Windows.Forms.ToolStripMenuItem[] GetMainMenuItems()
        {
            return this.items;
        }

        #endregion
    }
}
