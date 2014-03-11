using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAMSModule;
using WindowsApplication1;

namespace TEAMSModule
{
    public partial class GREETFormattedResults : Form
    {
        public TEAMS te;
        public GREETFormattedResults(TEAMS t)
        {
            //We will use this teams object to pull the GREET values into the TEAMS class, and then reference them here so they can be displayed
            te = t;
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Conventional Diesel")
            {
                //Row 1
                label24.Text = (te.MMBTUinperTrip * te.CD_WTP_TE).ToString("#.##") + " mmbtu/trip";
                label30.Text = "Conventional Diesel";
                label31.Text = "Conventional Diesel";
                label32.Text = "Conventional Diesel";
                label33.Text = "Conventional Diesel";
                label34.Text = "Conventional Diesel";
                label35.Text = "Conventional Diesel";
                label36.Text = "Conventional Diesel";
                label37.Text = "Conventional Diesel";
                label38.Text = "Conventional Diesel";
                label39.Text = "Conventional Diesel";
                label40.Text = "Conventional Diesel";
                label41.Text = "Conventional Diesel";
                //Row 2
                label42.Text = (te.MMBTUinperTrip * te.CD_VO_TE).ToString("#.##") + " mmbtu/trip";
                label48.Text = "Conventional Diesel";
                label49.Text = "Conventional Diesel";
                label50.Text = "Conventional Diesel";
                label51.Text = "Conventional Diesel";
                label52.Text = "Conventional Diesel";
                label53.Text = "Conventional Diesel";
                label54.Text = "Conventional Diesel";
                label55.Text = "Conventional Diesel";
                label56.Text = "Conventional Diesel";
                label57.Text = "Conventional Diesel";
                label58.Text = "Conventional Diesel";
                label59.Text = "Conventional Diesel";
                //Row 3
                label60.Text = (te.MMBTUinperTrip * te.CD_Total_TE).ToString("#.##") + " mmbtu/trip";
                label61.Text = (te.MMBTUinperTrip * te.CD_Total_FF).ToString("#.##") + " mmbtu/trip";
                label62.Text = (te.MMBTUinperTrip * te.CD_Total_CF).ToString("#.##") + " mmbtu/trip";
                label63.Text = "Conventional Diesel";
                label64.Text = "Conventional Diesel";
                label66.Text = "Conventional Diesel";
                label67.Text = "Conventional Diesel";
                label68.Text = "Conventional Diesel";
                label69.Text = "Conventional Diesel";
                label70.Text = "Conventional Diesel";
                label71.Text = "Conventional Diesel";
                label72.Text = "Conventional Diesel";
                label73.Text = "Conventional Diesel";
                label74.Text = "Conventional Diesel";
                label75.Text = "Conventional Diesel";
                label76.Text = "Conventional Diesel";
                label77.Text = "Conventional Diesel";

                //Title
                label1.Text = "Conventional Diesel";
            }
            else if (e.Node.Text == "Residual Oil")
            {
                //Row 1
                label24.Text = (te.MMBTUinperTrip * te.RO_WTP_TE).ToString("#.##") + " mmbtu/trip";
                label30.Text = "Residual OIl";
                label31.Text = "Residual OIl";
                label32.Text = "Residual OIl";
                label33.Text = "Residual OIl";
                label34.Text = "Residual OIl";
                label35.Text = "Residual OIl";
                label36.Text = "Residual OIl";
                label37.Text = "Residual OIl";
                label38.Text = "Residual OIl";
                label39.Text = "Residual OIl";
                label40.Text = "Residual OIl";
                label41.Text = "Residual OIl";
                //Row 2
                label42.Text = (te.MMBTUinperTrip * te.RO_VO_TE).ToString("#.##") + " mmbtu/trip";
                label48.Text = "Residual OIl";
                label49.Text = "Residual OIl";
                label50.Text = "Residual OIl";
                label51.Text = "Residual OIl";
                label52.Text = "Residual OIl";
                label53.Text = "Residual OIl";
                label54.Text = "Residual OIl";
                label55.Text = "Residual OIl";
                label56.Text = "Residual OIl";
                label57.Text = "Residual OIl";
                label58.Text = "Residual OIl";
                label59.Text = "Residual OIl";
                //Row 3
                label60.Text = (te.MMBTUinperTrip * te.RO_Total_TE).ToString("#.##") + " mmbtu/trip";
                label61.Text = (te.MMBTUinperTrip * te.RO_Total_FF).ToString("#.##") + " mmbtu/trip";
                label62.Text = (te.MMBTUinperTrip * te.RO_Total_CF).ToString("#.##") + " mmbtu/trip";
                label63.Text = "Residual OIl";
                label64.Text = "Residual OIl";
                label66.Text = "Residual OIl";
                label67.Text = "Residual OIl";
                label68.Text = "Residual OIl";
                label69.Text = "Residual OIl";
                label70.Text = "Residual OIl";
                label71.Text = "Residual OIl";
                label72.Text = "Residual OIl";
                label73.Text = "Residual OIl";
                label74.Text = "Residual OIl";
                label75.Text = "Residual OIl";
                label76.Text = "Residual OIl";
                label77.Text = "Residual OIl";

                //Title
                label1.Text = "Residual OIl";
            }
            else if (e.Node.Text == "Low Sulfur Diesel")
            {
                //Row 1
                label24.Text = (te.MMBTUinperTrip * te.LSD_WTP_TE).ToString("#.##") + " mmbtu/trip";
                label30.Text = "Low Sulfur Diesel";
                label31.Text = "Low Sulfur Diesel";
                label32.Text = "Low Sulfur Diesel";
                label33.Text = "Low Sulfur Diesel";
                label34.Text = "Low Sulfur Diesel";
                label35.Text = "Low Sulfur Diesel";
                label36.Text = "Low Sulfur Diesel";
                label37.Text = "Low Sulfur Diesel";
                label38.Text = "Low Sulfur Diesel";
                label39.Text = "Low Sulfur Diesel";
                label40.Text = "Low Sulfur Diesel";
                label41.Text = "Low Sulfur Diesel";
                //Row 2
                label42.Text = (te.MMBTUinperTrip * te.LSD_VO_TE).ToString("#.##") + " mmbtu/trip";
                label48.Text = "Low Sulfur Diesel";
                label49.Text = "Low Sulfur Diesel";
                label50.Text = "Low Sulfur Diesel";
                label51.Text = "Low Sulfur Diesel";
                label52.Text = "Low Sulfur Diesel";
                label53.Text = "Low Sulfur Diesel";
                label54.Text = "Low Sulfur Diesel";
                label55.Text = "Low Sulfur Diesel";
                label56.Text = "Low Sulfur Diesel";
                label57.Text = "Low Sulfur Diesel";
                label58.Text = "Low Sulfur Diesel";
                label59.Text = "Low Sulfur Diesel";
                //Row 3
                label60.Text = (te.MMBTUinperTrip * te.LSD_Total_TE).ToString("#.##") + " mmbtu/trip";
                label61.Text = (te.MMBTUinperTrip * te.LSD_Total_FF).ToString("#.##") + " mmbtu/trip";
                label62.Text = (te.MMBTUinperTrip * te.LSD_Total_CF).ToString("#.##") + " mmbtu/trip";
                label63.Text = "Low Sulfur Diesel";
                label64.Text = "Low Sulfur Diesel";
                label66.Text = "Low Sulfur Diesel";
                label67.Text = "Low Sulfur Diesel";
                label68.Text = "Low Sulfur Diesel";
                label69.Text = "Low Sulfur Diesel";
                label70.Text = "Low Sulfur Diesel";
                label71.Text = "Low Sulfur Diesel";
                label72.Text = "Low Sulfur Diesel";
                label73.Text = "Low Sulfur Diesel";
                label74.Text = "Low Sulfur Diesel";
                label75.Text = "Low Sulfur Diesel";
                label76.Text = "Low Sulfur Diesel";
                label77.Text = "Low Sulfur Diesel";

                //Title
                label1.Text = "Low Sulfur Diesel";
            }
            else if (e.Node.Text == "Natural Gas")
            {
                //Row 1
                label24.Text = (te.MMBTUinperTrip * te.NG_WTP_TE).ToString("#.##") + " mmbtu/trip";
                label30.Text = "Natural Gas";
                label31.Text = "Natural Gas";
                label32.Text = "Natural Gas";
                label33.Text = "Natural Gas";
                label34.Text = "Natural Gas";
                label35.Text = "Natural Gas";
                label36.Text = "Natural Gas";
                label37.Text = "Natural Gas";
                label38.Text = "Natural Gas";
                label39.Text = "Natural Gas";
                label40.Text = "Natural Gas";
                label41.Text = "Natural Gas";
                //Row 2
                label42.Text = (te.MMBTUinperTrip * te.NG_VO_TE).ToString("#.##") + " mmbtu/trip";
                label48.Text = "Natural Gas";
                label49.Text = "Natural Gas";
                label50.Text = "Natural Gas";
                label51.Text = "Natural Gas";
                label52.Text = "Natural Gas";
                label53.Text = "Natural Gas";
                label54.Text = "Natural Gas";
                label55.Text = "Natural Gas";
                label56.Text = "Natural Gas";
                label57.Text = "Natural Gas";
                label58.Text = "Natural Gas";
                label59.Text = "Natural Gas";
                //Row 3
                label60.Text = (te.MMBTUinperTrip * te.NG_Total_TE).ToString("#.##") + " mmbtu/trip";
                label61.Text = (te.MMBTUinperTrip * te.NG_Total_FF).ToString("#.##") + " mmbtu/trip";
                label62.Text = (te.MMBTUinperTrip * te.NG_Total_CF).ToString("#.##") + " mmbtu/trip";
                label63.Text = "Natural Gas";
                label64.Text = "Natural Gas";
                label66.Text = "Natural Gas";
                label67.Text = "Natural Gas";
                label68.Text = "Natural Gas";
                label69.Text = "Natural Gas";
                label70.Text = "Natural Gas";
                label71.Text = "Natural Gas";
                label72.Text = "Natural Gas";
                label73.Text = "Natural Gas";
                label74.Text = "Natural Gas";
                label75.Text = "Natural Gas";
                label76.Text = "Natural Gas";
                label77.Text = "Natural Gas";

                //Title
                label1.Text = "Natural Gas";
            }
            else if (e.Node.Text == "Biodiesel")
            {
                //Row 1
                label24.Text = (-1 *((te.MMBTUinperTrip * te.BD_WTP_TE) - (te.MMBTUinperTrip * te.BD_VO_TE))).ToString("#.##") + " mmbtu/trip";
                label30.Text = "Biodiesel";
                label31.Text = "Biodiesel";
                label32.Text = "Biodiesel";
                label33.Text = "Biodiesel";
                label34.Text = "Biodiesel";
                label35.Text = "Biodiesel";
                label36.Text = "Biodiesel";
                label37.Text = "Biodiesel";
                label38.Text = "Biodiesel";
                label39.Text = "Biodiesel";
                label40.Text = "Biodiesel";
                label41.Text = "Biodiesel";
                //Row 2
                label42.Text = (te.MMBTUinperTrip * te.BD_VO_TE).ToString("#.##") + " mmbtu/trip";
                label48.Text = "Biodiesel";
                label49.Text = "Biodiesel";
                label50.Text = "Biodiesel";
                label51.Text = "Biodiesel";
                label52.Text = "Biodiesel";
                label53.Text = "Biodiesel";
                label54.Text = "Biodiesel";
                label55.Text = "Biodiesel";
                label56.Text = "Biodiesel";
                label57.Text = "Biodiesel";
                label58.Text = "Biodiesel";
                label59.Text = "Biodiesel";
                //Row 3
                label60.Text = ((te.MMBTUinperTrip * te.BD_Total_TE) + (-2 * ((te.MMBTUinperTrip * te.BD_WTP_TE) - (te.MMBTUinperTrip * te.BD_VO_TE)))).ToString("#.##") + " mmbtu/trip";
                label61.Text = (te.MMBTUinperTrip * te.BD_Total_FF).ToString("#.##") + " mmbtu/trip";
                label62.Text = (te.MMBTUinperTrip * te.BD_Total_CF).ToString("#.##") + " mmbtu/trip";
                label63.Text = "Biodiesel";
                label64.Text = "Biodiesel";
                label66.Text = "Biodiesel";
                label67.Text = "Biodiesel";
                label68.Text = "Biodiesel";
                label69.Text = "Biodiesel";
                label70.Text = "Biodiesel";
                label71.Text = "Biodiesel";
                label72.Text = "Biodiesel";
                label73.Text = "Biodiesel";
                label74.Text = "Biodiesel";
                label75.Text = "Biodiesel";
                label76.Text = "Biodiesel";
                label77.Text = "Biodiesel";

                //Title
                label1.Text = "Biodiesel";
            }
            else if (e.Node.Text == "Fischer Tropsch Diesel")
            {
                //Row 1
                label24.Text = (te.MMBTUinperTrip * te.FTD_WTP_TE).ToString("#.##") + " mmbtu/trip";
                label30.Text = "Fischer Tropsch Diesel";
                label31.Text = "Fischer Tropsch Diesel";
                label32.Text = "Fischer Tropsch Diesel";
                label33.Text = "Fischer Tropsch Diesel";
                label34.Text = "Fischer Tropsch Diesel";
                label35.Text = "Fischer Tropsch Diesel";
                label36.Text = "Fischer Tropsch Diesel";
                label37.Text = "Fischer Tropsch Diesel";
                label38.Text = "Fischer Tropsch Diesel";
                label39.Text = "Fischer Tropsch Diesel";
                label40.Text = "Fischer Tropsch Diesel";
                label41.Text = "Fischer Tropsch Diesel";
                //Row 2
                label42.Text = (te.MMBTUinperTrip * te.FTD_VO_TE).ToString("#.##") + " mmbtu/trip";
                label48.Text = "Fischer Tropsch Diesel";
                label49.Text = "Fischer Tropsch Diesel";
                label50.Text = "Fischer Tropsch Diesel";
                label51.Text = "Fischer Tropsch Diesel";
                label52.Text = "Fischer Tropsch Diesel";
                label53.Text = "Fischer Tropsch Diesel";
                label54.Text = "Fischer Tropsch Diesel";
                label55.Text = "Fischer Tropsch Diesel";
                label56.Text = "Fischer Tropsch Diesel";
                label57.Text = "Fischer Tropsch Diesel";
                label58.Text = "Fischer Tropsch Diesel";
                label59.Text = "Fischer Tropsch Diesel";
                //Row 3
                label60.Text = (te.MMBTUinperTrip * te.FTD_Total_TE).ToString("#.##") + " mmbtu/trip";
                label61.Text = (te.MMBTUinperTrip * te.FTD_Total_FF).ToString("#.##") + " mmbtu/trip";
                label62.Text = (te.MMBTUinperTrip * te.FTD_Total_CF).ToString("#.##") + " mmbtu/trip";
                label63.Text = "Fischer Tropsch Diesel";
                label64.Text = "Fischer Tropsch Diesel";
                label66.Text = "Fischer Tropsch Diesel";
                label67.Text = "Fischer Tropsch Diesel";
                label68.Text = "Fischer Tropsch Diesel";
                label69.Text = "Fischer Tropsch Diesel";
                label70.Text = "Fischer Tropsch Diesel";
                label71.Text = "Fischer Tropsch Diesel";
                label72.Text = "Fischer Tropsch Diesel";
                label73.Text = "Fischer Tropsch Diesel";
                label74.Text = "Fischer Tropsch Diesel";
                label75.Text = "Fischer Tropsch Diesel";
                label76.Text = "Fischer Tropsch Diesel";
                label77.Text = "Fischer Tropsch Diesel";

                //Title
                label1.Text = "Fischer Tropsch Diesel";
            }
        }

    }
}
