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
using System.Windows.Forms.DataVisualization.Charting;
namespace TEAMSModule
{
    public partial class GREETFormattedResults : Form
    {
        string fuelUsed;
        public TEAMS te;
        //Actual resource arrays/sets will be filled using calculations from GREET

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
                /* 
                 * Column 1 -- Well to Pump
                 */
                // Total Energy
                label24.Text = (te.MMBTUinperTrip * te.CD_WTP_TE).ToString("#.##") + " mmbtu/trip";

                /***************
                 * EMISSIONS
                 ***************/

                label30.Text = (te.CD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // VOC
                label31.Text = (te.CD_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO
                label32.Text = (te.CD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // NOx
                label33.Text = (te.CD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM10
                label34.Text = (te.CD_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM2.5
                label35.Text = (te.CD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // SOx
                label36.Text = (te.CD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CH4
                label37.Text = (te.CD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2
                label38.Text = (te.CD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // N2O
                label41.Text = (te.CD_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2Biogenic

                /*
                 * Column 2 -- Vessel Operation
                 */

                label42.Text = (te.MMBTUinperTrip * te.CD_VO_TE).ToString("#.##") + " mmbtu/trip";  // Total Energy

                /***************
                 * EMISSIONS
                 ***************/

                label48.Text = "Conventional Diesel";   // VOC
                label49.Text = "Conventional Diesel";   // CO
                label50.Text = "Conventional Diesel";   // NOx
                label51.Text = "Conventional Diesel";   // PM10
                label52.Text = "Conventional Diesel";   // PM2.5
                label53.Text = "Conventional Diesel";   // SOx
                label54.Text = "Conventional Diesel";   // CH4
                label55.Text = "Conventional Diesel";   // CO2
                label56.Text = "Conventional Diesel";   // N2O
                label59.Text = "Conventional Diesel";   // CO2Biogenic

                /*
                 * Column 3 -- Total
                 */

                label60.Text = (te.MMBTUinperTrip * te.CD_Total_TE).ToString("#.##") + " mmbtu/trip";   // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.CD_Total_FF).ToString("#.##") + " mmbtu/trip";   // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.CD_Total_CF).ToString("#.##") + " mmbtu/trip";   // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.CD_Total_NG).ToString("#.##") + " mmbtu/trip";   // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.CD_Total_PF).ToString("#.##") + " mmbtu/trip";   // Petroleum Fuel

                /***************
                 * EMISSIONS
                 ***************/

                label66.Text = "Conventional Diesel";   // VOC
                label67.Text = "Conventional Diesel";   // CO
                label68.Text = "Conventional Diesel";   // NOx
                label69.Text = "Conventional Diesel";   // PM10
                label70.Text = "Conventional Diesel";   // PM2.5
                label71.Text = "Conventional Diesel";   // SOx
                label72.Text = "Conventional Diesel";   // CH4
                label73.Text = "Conventional Diesel";   // CO2
                label74.Text = "Conventional Diesel";   // N2O
                label77.Text = "Conventional Diesel";   // CO2Biogenic

                //Title
                label1.Text = "Conventional Diesel";

                //Setting the stacked bar chart information
                fuelUsed = "Conventional Diesel";
                double[] total_energy = { (te.MMBTUinperTrip * te.CD_WTP_TE), (te.MMBTUinperTrip * te.CD_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 };    //Resource 2
                double[] co2 = { 12, 53 };          //Resource 3
                double[] ch4 = { 44, 22 };          //Resource 4
                double[] n2o = { 40, 20 };          //Resource 5
                double[] ghgs = { 90, 4.5 };        //Resource 6
                double[] voc = { 20, 55 };          //Resource 7
                double[] co = { 60, 10 };           //Resource 8
                double[] nox = { 14, 21 };          //Resource 9
                double[] pm10 = { 50, 25 };         //Resource 10
                double[] sox = { 22, 33 };          //Resource 11
                double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };
                //Generate the graph using the resources set and seriesArray.
                Generate_Graph(resources, stacked_graph);
            }
            else if (e.Node.Text == "Residual Oil")
            {
                /*
                 * Column 1 -- Well to Pump
                 */

                label24.Text = (te.MMBTUinperTrip * te.RO_WTP_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
                 * EMISSIONS
                 ***************/

                label30.Text = (te.RO_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // VOC
                label31.Text = (te.RO_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO
                label32.Text = (te.RO_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // NOx
                label33.Text = (te.RO_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM10
                label34.Text = (te.RO_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM2.5
                label35.Text = (te.RO_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // SOx
                label36.Text = (te.RO_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CH4
                label37.Text = (te.RO_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2
                label38.Text = (te.RO_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // N2O
                label41.Text = (te.RO_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2Biogenic

                /*
                 * Column 2 -- Vessel Operation
                 */

                label42.Text = (te.MMBTUinperTrip * te.RO_VO_TE).ToString("#.##") + " mmbtu/trip";  // Total Energy

                /***************
                 * EMISSIONS
                 ***************/

                label48.Text = "Residual Oil";  // VOC
                label49.Text = "Residual Oil";  // CO
                label50.Text = "Residual Oil";  // NOx
                label51.Text = "Residual Oil";  // PM10
                label52.Text = "Residual Oil";  // PM2.5
                label53.Text = "Residual Oil";  // SOx
                label54.Text = "Residual Oil";  // CH4
                label55.Text = "Residual Oil";  // CO2
                label56.Text = "Residual Oil";  // N20
                label59.Text = "Residual Oil";  // CO2Biogenic

                /*
                 * Column 3 -- Total
                 */

                label60.Text = (te.MMBTUinperTrip * te.RO_Total_TE).ToString("#.##") + " mmbtu/trip";  // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.RO_Total_FF).ToString("#.##") + " mmbtu/trip";  // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.RO_Total_CF).ToString("#.##") + " mmbtu/trip";  // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.RO_Total_NG).ToString("#.##") + " mmbtu/trip";  // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.RO_Total_PF).ToString("#.##") + " mmbtu/trip";  // Petroleum Fuel

                /***************
                 * EMISSIONS
                 ***************/

                label66.Text = "Residual Oil";  // VOC
                label67.Text = "Residual Oil";  // CO
                label68.Text = "Residual Oil";  // NOx
                label69.Text = "Residual Oil";  // PM10
                label70.Text = "Residual Oil";  // PM2.5
                label71.Text = "Residual Oil";  // SOx
                label72.Text = "Residual Oil";  // CH4
                label73.Text = "Residual Oil";  // CO2
                label74.Text = "Residual Oil";  // N2O
                label77.Text = "Residual Oil";  // CO2Biogenic

                //Title
                label1.Text = "Residual Oil";

                //Setting the stacked bar chart information
                fuelUsed = "Residual Oil";
                double[] total_energy = { (te.MMBTUinperTrip * te.RO_WTP_TE), (te.MMBTUinperTrip * te.RO_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 };    //Resource 2
                double[] co2 = { 12, 53 };          //Resource 3
                double[] ch4 = { 44, 22 };          //Resource 4
                double[] n2o = { 40, 20 };          //Resource 5
                double[] ghgs = { 90, 4.5 };        //Resource 6
                double[] voc = { 20, 55 };          //Resource 7
                double[] co = { 60, 10 };           //Resource 8
                double[] nox = { 14, 21 };          //Resource 9
                double[] pm10 = { 50, 25 };         //Resource 10
                double[] sox = { 22, 33 };          //Resource 11
                double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };
                //Generate the graph using the resources set and seriesArray.
                Generate_Graph(resources, stacked_graph);
            }
            else if (e.Node.Text == "Low Sulfur Diesel")
            {
                /*
                 * Column 1 -- Well to Pump
                 */

                label24.Text = (te.MMBTUinperTrip * te.LSD_WTP_TE).ToString("#.##") + " mmbtu/trip";    // Total Energy

                /***************
                 * EMISSIONS
                 ***************/

                label30.Text = (te.LSD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // VOC
                label31.Text = (te.LSD_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO
                label32.Text = (te.LSD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // NOx
                label33.Text = (te.LSD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM10
                label34.Text = (te.LSD_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM2.5
                label35.Text = (te.LSD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // SOx
                label36.Text = (te.LSD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CH4
                label37.Text = (te.LSD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2
                label38.Text = (te.LSD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // N2O
                label41.Text = (te.LSD_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2Biogenic

                /*
                 * Column 2 -- Vessel Operation
                 */

                label42.Text = (te.MMBTUinperTrip * te.LSD_VO_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
                 * EMISSIONS
                 ***************/

                label48.Text = "Low Sulfur Diesel"; // VOC
                label49.Text = "Low Sulfur Diesel"; // CO
                label50.Text = "Low Sulfur Diesel"; // NOx
                label51.Text = "Low Sulfur Diesel"; // PM10
                label52.Text = "Low Sulfur Diesel"; // PM2.5
                label53.Text = "Low Sulfur Diesel"; // SOx
                label54.Text = "Low Sulfur Diesel"; // CH4
                label55.Text = "Low Sulfur Diesel"; // CO2
                label56.Text = "Low Sulfur Diesel"; // N2O
                label59.Text = "Low Sulfur Diesel"; // CO2Biogenic

                /*
                 * Column 3 -- Total
                 */

                label60.Text = (te.MMBTUinperTrip * te.LSD_Total_TE).ToString("#.##") + " mmbtu/trip";  // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.LSD_Total_FF).ToString("#.##") + " mmbtu/trip";  // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.LSD_Total_CF).ToString("#.##") + " mmbtu/trip";  // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.LSD_Total_NG).ToString("#.##") + " mmbtu/trip";  // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.LSD_Total_PF).ToString("#.##") + " mmbtu/trip";  // Petroleum Fuel

                /***************
                 * EMISSIONS
                 ***************/

                label66.Text = "Low Sulfur Diesel";  // VOC
                label67.Text = "Low Sulfur Diesel";  // CO
                label68.Text = "Low Sulfur Diesel";  // NOx
                label69.Text = "Low Sulfur Diesel";  // PM10
                label70.Text = "Low Sulfur Diesel";  // PM2.5
                label71.Text = "Low Sulfur Diesel";  // SOx
                label72.Text = "Low Sulfur Diesel";  // CH4
                label73.Text = "Low Sulfur Diesel";  // CO2
                label74.Text = "Low Sulfur Diesel";  // N2O
                label77.Text = "Low Sulfur Diesel";  // CO2Biogene

                //Title
                label1.Text = "Low Sulfur Diesel";

                //Setting the stacked bar chart information
                fuelUsed = "Low Sulfur Diesel";
                double[] total_energy = { (te.MMBTUinperTrip * te.LSD_WTP_TE), (te.MMBTUinperTrip * te.LSD_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 };    //Resource 2
                double[] co2 = { 12, 53 };          //Resource 3
                double[] ch4 = { 44, 22 };          //Resource 4
                double[] n2o = { 40, 20 };          //Resource 5
                double[] ghgs = { 90, 4.5 };        //Resource 6
                double[] voc = { 20, 55 };          //Resource 7
                double[] co = { 60, 10 };           //Resource 8
                double[] nox = { 14, 21 };          //Resource 9
                double[] pm10 = { 50, 25 };         //Resource 10
                double[] sox = { 22, 33 };          //Resource 11
                double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };
                //Generate the graph using the resources set and seriesArray.
                Generate_Graph(resources, stacked_graph);
            }
            else if (e.Node.Text == "Natural Gas")
            {
                /*
                 * Column 1 -- Well to Pump
                 */

                label24.Text = (te.MMBTUinperTrip * te.NG_WTP_TE).ToString("#.##") + " mmbtu/trip"; // Total energy

                /***************
                 * EMISSIONS
                 ***************/

                label30.Text = (te.NG_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // VOC
                label31.Text = (te.NG_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO
                label32.Text = (te.NG_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // NOx
                label33.Text = (te.NG_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM10
                label34.Text = (te.NG_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM2.5
                label35.Text = (te.NG_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // SOx
                label36.Text = (te.NG_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CH4
                label37.Text = (te.NG_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2
                label38.Text = (te.NG_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // N2O
                label41.Text = (te.NG_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2Biogenic

                /*
                 * Column 2 -- Vessel Operation
                 */

                label42.Text = (te.MMBTUinperTrip * te.NG_VO_TE).ToString("#.##") + " mmbtu/trip";  // Total Energy

                /***************
                 * EMISSIONS
                 ***************/

                label48.Text = "Natural Gas";   // VOc
                label49.Text = "Natural Gas";   // CO
                label50.Text = "Natural Gas";   // NOx
                label51.Text = "Natural Gas";   // PM10
                label52.Text = "Natural Gas";   // PM2.5
                label53.Text = "Natural Gas";   // SOx
                label54.Text = "Natural Gas";   // CH4
                label55.Text = "Natural Gas";   // CO2
                label56.Text = "Natural Gas";   // N2O
                label59.Text = "Natural Gas";   // CO2Biogenic

                /*
                 * Column 3 -- Total
                 */

                label60.Text = (te.MMBTUinperTrip * te.NG_Total_TE).ToString("#.##") + " mmbtu/trip";   // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.NG_Total_FF).ToString("#.##") + " mmbtu/trip";   // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.NG_Total_CF).ToString("#.##") + " mmbtu/trip";   // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.NG_Total_NG).ToString("#.##") + " mmbtu/trip";   // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.NG_Total_PF).ToString("#.##") + " mmbtu/trip";   // Petroleum Fuel

                /***************
                 * EMISSIONS
                 ***************/

                label66.Text = "Natural Gas";   // VOC
                label67.Text = "Natural Gas";   // CO
                label68.Text = "Natural Gas";   // NOx
                label69.Text = "Natural Gas";   // PM10
                label70.Text = "Natural Gas";   // PM2.5
                label71.Text = "Natural Gas";   // SOx
                label72.Text = "Natural Gas";   // CH4
                label73.Text = "Natural Gas";   // CO2
                label74.Text = "Natural Gas";   // N2O
                label77.Text = "Natural Gas";   // CO2Biogenic

                //Title
                label1.Text = "Natural Gas";

                //Setting the stacked bar chart information
                fuelUsed = "Natural Gas";
                double[] total_energy = { (te.MMBTUinperTrip * te.NG_WTP_TE), (te.MMBTUinperTrip * te.NG_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 };    //Resource 2
                double[] co2 = { 12, 53 };          //Resource 3
                double[] ch4 = { 44, 22 };          //Resource 4
                double[] n2o = { 40, 20 };          //Resource 5
                double[] ghgs = { 90, 4.5 };        //Resource 6
                double[] voc = { 20, 55 };          //Resource 7
                double[] co = { 60, 10 };           //Resource 8
                double[] nox = { 14, 21 };          //Resource 9
                double[] pm10 = { 50, 25 };         //Resource 10
                double[] sox = { 22, 33 };          //Resource 11
                double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };
                //Generate the graph using the resources set and seriesArray.
                Generate_Graph(resources, stacked_graph);
            }
            else if (e.Node.Text == "Biodiesel")
            {
                /*
                 * Column 1 -- Well to Pump
                 */

                label24.Text = (-1 * ((te.MMBTUinperTrip * te.BD_WTP_TE) - (te.MMBTUinperTrip * te.BD_VO_TE))).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
                 * EMISSIONS
                 ***************/

                label30.Text = (te.BD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // VOC
                label31.Text = (te.BD_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO
                label32.Text = (te.BD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // NOx
                label33.Text = (te.BD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM10
                label34.Text = (te.BD_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM2.5
                label35.Text = (te.BD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // SOx
                label36.Text = (te.BD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CH4
                label37.Text = (te.BD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2
                label38.Text = (te.BD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // N2O
                label41.Text = (te.BD_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2Biogenic

                /*
                 * Column 2 -- Vessel Operation
                 */

                label42.Text = (te.MMBTUinperTrip * te.BD_VO_TE).ToString("#.##") + " mmbtu/trip";  // Total Energy

                /***************
                 * EMISSIONS
                 ***************/

                label48.Text = "Biodiesel"; // VOC
                label49.Text = "Biodiesel"; // CO
                label50.Text = "Biodiesel"; // NOx
                label51.Text = "Biodiesel"; // PM10
                label52.Text = "Biodiesel"; // PM2.5
                label53.Text = "Biodiesel"; // SOx
                label54.Text = "Biodiesel"; // CH4
                label55.Text = "Biodiesel"; // CO2
                label56.Text = "Biodiesel"; // N2O
                label59.Text = "Biodiesel"; // CO2Biogenic

                /*
                 * Column 3 -- Total
                 */

                label60.Text = ((te.MMBTUinperTrip * te.BD_Total_TE) + (-2 * ((te.MMBTUinperTrip * te.BD_WTP_TE) - (te.MMBTUinperTrip * te.BD_VO_TE)))).ToString("#.##") + " mmbtu/trip";   // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.BD_Total_FF).ToString("#.##") + " mmbtu/trip";   // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.BD_Total_CF).ToString("#.##") + " mmbtu/trip";   // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.BD_Total_NG).ToString("#.##") + " mmbtu/trip"; // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.BD_Total_PF).ToString("#.##") + " mmbtu/trip"; // Petroleum Fuel

                /***************
                 * EMISSIONS
                 ***************/

                label66.Text = "Biodiesel"; // VOC
                label67.Text = "Biodiesel"; // CO
                label68.Text = "Biodiesel"; // NOx
                label69.Text = "Biodiesel"; // PM10
                label70.Text = "Biodiesel"; // PM2.5
                label71.Text = "Biodiesel"; // SOx
                label72.Text = "Biodiesel"; // CH4
                label73.Text = "Biodiesel"; // CO2
                label74.Text = "Biodiesel"; // N2O
                label77.Text = "Biodiesel"; // CO2Biogenic

                //Title
                label1.Text = "Biodiesel";

                //Setting the stacked bar chart information
                fuelUsed = "Biodiesel";
                double[] total_energy = { (te.MMBTUinperTrip * te.BD_WTP_TE), (te.MMBTUinperTrip * te.BD_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 };    //Resource 2
                double[] co2 = { 12, 53 };          //Resource 3
                double[] ch4 = { 44, 22 };          //Resource 4
                double[] n2o = { 40, 20 };          //Resource 5
                double[] ghgs = { 90, 4.5 };        //Resource 6
                double[] voc = { 20, 55 };          //Resource 7
                double[] co = { 60, 10 };           //Resource 8
                double[] nox = { 14, 21 };          //Resource 9
                double[] pm10 = { 50, 25 };         //Resource 10
                double[] sox = { 22, 33 };          //Resource 11
                double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };
                //Generate the graph using the resources set and seriesArray.
                Generate_Graph(resources, stacked_graph);
            }
            else if (e.Node.Text == "Fischer Tropsch Diesel")
            {
                /*
                 * Column 1 -- Well to Pump
                 */

                label24.Text = (te.MMBTUinperTrip * te.FTD_WTP_TE).ToString("#.##") + " mmbtu/trip";    // Total Energy

                /***************
                 * EMISSIONS
                 ***************/

                label30.Text = (te.FTD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // VOC
                label31.Text = (te.FTD_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO
                label32.Text = (te.FTD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // NOx
                label33.Text = (te.FTD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM10
                label34.Text = (te.FTD_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";   // PM2.5
                label35.Text = (te.FTD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // SOx
                label36.Text = (te.FTD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CH4
                label37.Text = (te.FTD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2
                label38.Text = (te.FTD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // N2O
                label41.Text = (te.FTD_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip";  // CO2Biogenic

                /*
                 * Column 2 -- Vessel Operation
                 */

                label42.Text = (te.MMBTUinperTrip * te.FTD_VO_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
                 * EMISSIONS
                 ***************/

                label48.Text = "Fischer Tropsch Diesel";    // VOC
                label49.Text = "Fischer Tropsch Diesel";    // CO
                label50.Text = "Fischer Tropsch Diesel";    // NOx
                label51.Text = "Fischer Tropsch Diesel";    // PM10
                label52.Text = "Fischer Tropsch Diesel";    // PM2.5
                label53.Text = "Fischer Tropsch Diesel";    // SOx
                label54.Text = "Fischer Tropsch Diesel";    // CH4
                label55.Text = "Fischer Tropsch Diesel";    // CO2
                label56.Text = "Fischer Tropsch Diesel";    // N2O
                label59.Text = "Fischer Tropsch Diesel";    // CO2Biogenic

                /*
                 * Column 3 -- Total
                 */

                label60.Text = (te.MMBTUinperTrip * te.FTD_Total_TE).ToString("#.##") + " mmbtu/trip";  // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.FTD_Total_FF).ToString("#.##") + " mmbtu/trip";  // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.FTD_Total_CF).ToString("#.##") + " mmbtu/trip";  // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.FTD_Total_NG).ToString("#.##") + " mmbtu/trip";    // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.FTD_Total_PF).ToString("#.##") + " mmbtu/trip";    // Petroleum Fuel

                /***************
                 * EMISSIONS
                 ***************/

                label66.Text = "Fischer Tropsch Diesel";    // VOC
                label67.Text = "Fischer Tropsch Diesel";    // CO
                label68.Text = "Fischer Tropsch Diesel";    // NOx
                label69.Text = "Fischer Tropsch Diesel";    // PM10
                label70.Text = "Fischer Tropsch Diesel";    // PM2.5
                label71.Text = "Fischer Tropsch Diesel";    // SOx
                label72.Text = "Fischer Tropsch Diesel";    // CH4
                label73.Text = "Fischer Tropsch Diesel";    // CO2
                label74.Text = "Fischer Tropsch Diesel";    // N2O
                label77.Text = "Fischer Tropsch Diesel";    // CO2Biogenic

                //Title
                label1.Text = "Fischer Tropsch Diesel";

                //Setting the stacked bar chart information
                fuelUsed = "Fischer Tropsch Diesel";
                double[] total_energy = { (te.MMBTUinperTrip * te.FTD_WTP_TE), (te.MMBTUinperTrip * te.FTD_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 };    //Resource 2
                double[] co2 = { 12, 53 };          //Resource 3
                double[] ch4 = { 44, 22 };          //Resource 4
                double[] n2o = { 40, 20 };          //Resource 5
                double[] ghgs = { 90, 4.5 };        //Resource 6
                double[] voc = { 20, 55 };          //Resource 7
                double[] co = { 60, 10 };           //Resource 8
                double[] nox = { 14, 21 };          //Resource 9
                double[] pm10 = { 50, 25 };         //Resource 10
                double[] sox = { 22, 33 };          //Resource 11
                double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };
                //Generate the graph using the resources set and seriesArray.
                Generate_Graph(resources, stacked_graph);
            }
        }
        /// <summary>
        /// Generates the specified graph for display to the user.
        /// </summary>
        /// <param name="resources">A collection of the 12 resources to be modeled by the graph with values: { %upstream%, %vesseloperation% }</param>
        /// <param name="graph">The graph to be generated. Note that this should always be the graph from the designer, 'stacked_graph'.
        /// If you wish to generate another graph, you will need to do more than pass the graph in as a parameter.</param>
        /// <param name="title">The title of the graph to be displayed. These are taken from and match the titles from the graphs in the original TEAMS spreadsheet ~v1.4</param>
        private void Generate_Graph(double[][] resources, Chart graph)
        {
            //Matches the series collection already outlined in the designer.
            string[] seriesArray = { "Upstream", "VesselOperation" };
            //Set the title of the graph to the passed in string title.
            graph.Titles[0].Text = "Your Vessel using " + fuelUsed + " \nContribution of Each Stage";
            //Iterate through each of the three series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Clears points to ensure working with a new graph.
                graph.Series[i].Points.Clear();

                //Add each resource value to the respective series from the parent loop.
                for (int r = 0; r < resources.Length; r++)
                {
                    graph.Series[seriesArray[i]].Points.AddY(resources[r][i]);
                }
            }
        }

    }
}
