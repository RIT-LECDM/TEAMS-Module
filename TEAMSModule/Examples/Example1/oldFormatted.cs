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

                label30.Text = (te.CD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // VOC
                label31.Text = (te.CD_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO
                label32.Text = (te.CD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // NOx
                label33.Text = (te.CD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM10
                label34.Text = (te.CD_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM2.5
                label35.Text = (te.CD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // SOx
                label36.Text = (te.CD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CH4
                label37.Text = (te.CD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2
                label38.Text = (te.CD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // N2O
                label41.Text = (te.CD_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2Biogenic

                /*
* Column 2 -- Vessel Operation
*/

                label42.Text = (te.MMBTUinperTrip * te.CD_VO_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy
/***************
* EMISSIONS
***************/

                label48.Text = (te.CD_VOC_EF *te.MMBTUinperTrip).ToString(); // VOC
                label49.Text = (te.CD_CO_EF * te.MMBTUinperTrip).ToString(); // CO
                label50.Text = (te.CD_NOx_EF * te.MMBTUinperTrip).ToString(); // NOx
                label51.Text = (te.CD_PM10_EF * te.MMBTUinperTrip).ToString(); // PM10
                label52.Text = "PM2.5"; // PM2.5
                label53.Text = (te.CD_SOx_EF * te.MMBTUinperTrip).ToString(); // SOx
                label54.Text = (te.CD_CH4_EF * te.MMBTUinperTrip).ToString(); // CH4
                label55.Text = (te.CD_CO2_EF * te.MMBTUinperTrip).ToString(); // CO2
                label56.Text = (te.CD_N2O_EF * te.MMBTUinperTrip).ToString(); // N2O
                label59.Text = "CO2 Biogenic"; // CO2Biogenic

                /*
* Column 3 -- Total
*/

                label60.Text = (te.MMBTUinperTrip * te.CD_Total_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.CD_Total_FF).ToString("#.##") + " mmbtu/trip"; // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.CD_Total_CF).ToString("#.##") + " mmbtu/trip"; // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.CD_Total_NG).ToString("#.##") + " mmbtu/trip"; // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.CD_Total_PF).ToString("#.##") + " mmbtu/trip"; // Petroleum Fuel

                /***************
* EMISSIONS
***************/

                label66.Text = ((te.CD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip) + (te.CD_VOC_EF * te.MMBTUinperTrip)).ToString(); // VOC
                label67.Text = ((te.CD_WTP_CO * 1000000000000 * te.MMBTUinperTrip) + (te.CD_CO_EF * te.MMBTUinperTrip)).ToString(); // CO
                label68.Text = ((te.CD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip) + (te.CD_NOx_EF * te.MMBTUinperTrip)).ToString(); // NOx
                label69.Text = ((te.CD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip) + (te.CD_PM10_EF * te.MMBTUinperTrip)).ToString(); // PM10
                label70.Text = "PM2.5"; // PM2.5
                label71.Text = ((te.CD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip) + (te.CD_SOx_EF * te.MMBTUinperTrip)).ToString(); // SOx
                label72.Text = ((te.CD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip) + (te.CD_CH4_EF * te.MMBTUinperTrip)).ToString(); // CH4
                label73.Text = ((te.CD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip) + (te.CD_CO2_EF * te.MMBTUinperTrip)).ToString(); // CO2
                label74.Text = ((te.CD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip) + (te.CD_N2O_EF * te.MMBTUinperTrip)).ToString(); // N2O
                label77.Text = "CO2 biogenic"; // CO2Biogenic

                //Title
                label1.Text = "Conventional Diesel";

                //Setting the stacked bar chart information
                fuelUsed = "Conventional Diesel";
                double[] total_energy = { (te.MMBTUinperTrip * te.CD_WTP_TE), (te.MMBTUinperTrip * te.CD_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 }; //Resource 2
                double[] co2 = { (te.CD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip), (te.CD_CO2_EF * te.MMBTUinperTrip)}; //Resource 3
                double[] ch4 = { (te.CD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip), (te.CD_CH4_EF * te.MMBTUinperTrip)}; //Resource 4
                double[] n2o = { (te.CD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip), (te.CD_N2O_EF * te.MMBTUinperTrip)}; //Resource 5
                double[] ghgs = { 90, 4.5 }; //Resource 6
                double[] voc = { (te.CD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip), (te.CD_VOC_EF *te.MMBTUinperTrip)}; //Resource 7
                double[] co = { (te.CD_WTP_CO * 1000000000000 * te.MMBTUinperTrip), (te.CD_CO_EF * te.MMBTUinperTrip) }; //Resource 8
                double[] nox = { (te.CD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip), (te.CD_NOx_EF * te.MMBTUinperTrip) }; //Resource 9
                double[] pm10 = { (te.CD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip), (te.CD_PM10_EF * te.MMBTUinperTrip) }; //Resource 10
                double[] sox = { (te.CD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip), (te.CD_SOx_EF * te.MMBTUinperTrip) }; //Resource 11
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

                label30.Text = (te.RO_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // VOC
                label31.Text = (te.RO_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO
                label32.Text = (te.RO_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // NOx
                label33.Text = (te.RO_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM10
                label34.Text = (te.RO_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM2.5
                label35.Text = (te.RO_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // SOx
                label36.Text = (te.RO_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CH4
                label37.Text = (te.RO_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2
                label38.Text = (te.RO_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // N2O
                label41.Text = (te.RO_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2Biogenic

                /*
* Column 2 -- Vessel Operation
*/

                label42.Text = (te.MMBTUinperTrip * te.RO_VO_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
* EMISSIONS
***************/

                label48.Text = (te.RO_VOC_EF * te.MMBTUinperTrip).ToString(); // VOC
                label49.Text = (te.RO_CO_EF * te.MMBTUinperTrip).ToString(); // CO
                label50.Text = (te.RO_NOx_EF * te.MMBTUinperTrip).ToString(); // NOx
                label51.Text = (te.RO_PM10_EF * te.MMBTUinperTrip).ToString(); // PM10
                label52.Text = "PM2.5"; // PM2.5
                label53.Text = (te.RO_SOx_EF * te.MMBTUinperTrip).ToString(); // SOx
                label54.Text = (te.RO_CH4_EF * te.MMBTUinperTrip).ToString(); // CH4
                label55.Text = (te.RO_CO2_EF * te.MMBTUinperTrip).ToString(); // CO2
                label56.Text = (te.RO_N2O_EF * te.MMBTUinperTrip).ToString(); // N2O
                label59.Text = "CO2 Biogenic"; // CO2Biogenic

                /*
* Column 3 -- Total
*/

                label60.Text = (te.MMBTUinperTrip * te.RO_Total_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.RO_Total_FF).ToString("#.##") + " mmbtu/trip"; // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.RO_Total_CF).ToString("#.##") + " mmbtu/trip"; // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.RO_Total_NG).ToString("#.##") + " mmbtu/trip"; // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.RO_Total_PF).ToString("#.##") + " mmbtu/trip"; // Petroleum Fuel

                /***************
* EMISSIONS
***************/

                label66.Text = ((te.RO_WTP_VOC * 1000000000000 * te.MMBTUinperTrip) + (te.RO_VOC_EF * te.MMBTUinperTrip)).ToString(); // VOC
                label67.Text = ((te.RO_WTP_CO * 1000000000000 * te.MMBTUinperTrip) + (te.RO_CO_EF * te.MMBTUinperTrip)).ToString(); // CO
                label68.Text = ((te.RO_WTP_NOX * 1000000000000 * te.MMBTUinperTrip) + (te.RO_NOx_EF * te.MMBTUinperTrip)).ToString(); // NOx
                label69.Text = ((te.RO_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip) + (te.RO_PM10_EF * te.MMBTUinperTrip)).ToString(); // PM10
                label70.Text = "PM2.5"; // PM2.5
                label71.Text = ((te.RO_WTP_SOX * 1000000000000 * te.MMBTUinperTrip) + (te.RO_SOx_EF * te.MMBTUinperTrip)).ToString(); // SOx
                label72.Text = ((te.RO_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip) + (te.RO_CH4_EF * te.MMBTUinperTrip)).ToString(); // CH4
                label73.Text = ((te.RO_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip) + (te.RO_CO2_EF * te.MMBTUinperTrip)).ToString(); // CO2
                label74.Text = ((te.RO_WTP_N2O * 1000000000000 * te.MMBTUinperTrip) + (te.RO_N2O_EF * te.MMBTUinperTrip)).ToString(); // N2O
                label77.Text = "CO2 biogenic"; // CO2Biogenic

                //Title
                label1.Text = "Residual Oil";

                //Setting the stacked bar chart information
                fuelUsed = "Residual Oil";
                double[] total_energy = { (te.MMBTUinperTrip * te.RO_WTP_TE), (te.MMBTUinperTrip * te.RO_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 }; //Resource 2
                double[] co2 = { (te.RO_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip), (te.RO_CO2_EF * te.MMBTUinperTrip) }; //Resource 3
                double[] ch4 = { (te.RO_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip), (te.RO_CH4_EF * te.MMBTUinperTrip) }; //Resource 4
                double[] n2o = { (te.RO_WTP_N2O * 1000000000000 * te.MMBTUinperTrip), (te.RO_N2O_EF * te.MMBTUinperTrip) }; //Resource 5
                double[] ghgs = { 90, 4.5 }; //Resource 6
                double[] voc = { (te.RO_WTP_VOC * 1000000000000 * te.MMBTUinperTrip), (te.RO_VOC_EF * te.MMBTUinperTrip) }; //Resource 7
                double[] co = { (te.RO_WTP_CO * 1000000000000 * te.MMBTUinperTrip), (te.RO_CO_EF * te.MMBTUinperTrip) }; //Resource 8
                double[] nox = { (te.RO_WTP_NOX * 1000000000000 * te.MMBTUinperTrip), (te.RO_NOx_EF * te.MMBTUinperTrip) }; //Resource 9
                double[] pm10 = { (te.RO_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip), (te.RO_PM10_EF * te.MMBTUinperTrip) }; //Resource 10
                double[] sox = { (te.RO_WTP_SOX * 1000000000000 * te.MMBTUinperTrip), (te.RO_SOx_EF * te.MMBTUinperTrip) }; //Resource 11
                double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };
                //Generate the graph using the resources set and seriesArray.
                Generate_Graph(resources, stacked_graph);
            }
            else if (e.Node.Text == "Low Sulfur Diesel")
            {
                /*
* Column 1 -- Well to Pump
*/

                label24.Text = (te.MMBTUinperTrip * te.LSD_WTP_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
* EMISSIONS
***************/

                label30.Text = (te.LSD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // VOC
                label31.Text = (te.LSD_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO
                label32.Text = (te.LSD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // NOx
                label33.Text = (te.LSD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM10
                label34.Text = (te.LSD_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM2.5
                label35.Text = (te.LSD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // SOx
                label36.Text = (te.LSD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CH4
                label37.Text = (te.LSD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2
                label38.Text = (te.LSD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // N2O
                label41.Text = (te.LSD_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2Biogenic

                /*
* Column 2 -- Vessel Operation
*/

                label42.Text = (te.MMBTUinperTrip * te.LSD_VO_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
* EMISSIONS
***************/

                label48.Text = (te.LSD_VOC_EF * te.MMBTUinperTrip).ToString(); // VOC
                label49.Text = (te.LSD_CO_EF * te.MMBTUinperTrip).ToString(); // CO
                label50.Text = (te.LSD_NOx_EF * te.MMBTUinperTrip).ToString(); // NOx
                label51.Text = (te.LSD_PM10_EF * te.MMBTUinperTrip).ToString(); // PM10
                label52.Text = "PM2.5"; // PM2.5
                label53.Text = (te.LSD_SOx_EF * te.MMBTUinperTrip).ToString(); // SOx
                label54.Text = (te.LSD_CH4_EF * te.MMBTUinperTrip).ToString(); // CH4
                label55.Text = (te.LSD_CO2_EF * te.MMBTUinperTrip).ToString(); // CO2
                label56.Text = (te.LSD_N2O_EF * te.MMBTUinperTrip).ToString(); // N2O
                label59.Text = "CO2 Biogenic"; // CO2Biogenic

                /*
* Column 3 -- Total
*/

                label60.Text = (te.MMBTUinperTrip * te.LSD_Total_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.LSD_Total_FF).ToString("#.##") + " mmbtu/trip"; // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.LSD_Total_CF).ToString("#.##") + " mmbtu/trip"; // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.LSD_Total_NG).ToString("#.##") + " mmbtu/trip"; // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.LSD_Total_PF).ToString("#.##") + " mmbtu/trip"; // Petroleum Fuel

                /***************
* EMISSIONS
***************/

                label66.Text = ((te.LSD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip) + (te.LSD_VOC_EF * te.MMBTUinperTrip)).ToString(); // VOC
                label67.Text = ((te.LSD_WTP_CO * 1000000000000 * te.MMBTUinperTrip) + (te.LSD_CO_EF * te.MMBTUinperTrip)).ToString(); // CO
                label68.Text = ((te.LSD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip) + (te.LSD_NOx_EF * te.MMBTUinperTrip)).ToString(); // NOx
                label69.Text = ((te.LSD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip) + (te.LSD_PM10_EF * te.MMBTUinperTrip)).ToString(); // PM10
                label70.Text = "PM2.5"; // PM2.5
                label71.Text = ((te.LSD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip) + (te.LSD_SOx_EF * te.MMBTUinperTrip)).ToString(); // SOx
                label72.Text = ((te.LSD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip) + (te.LSD_CH4_EF * te.MMBTUinperTrip)).ToString(); // CH4
                label73.Text = ((te.LSD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip) + (te.LSD_CO2_EF * te.MMBTUinperTrip)).ToString(); // CO2
                label74.Text = ((te.LSD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip) + (te.LSD_N2O_EF * te.MMBTUinperTrip)).ToString(); // N2O
                label77.Text = "CO2 biogenic"; // CO2Biogenic

                //Title
                label1.Text = "Low Sulfur Diesel";

                //Setting the stacked bar chart information
                fuelUsed = "Low Sulfur Diesel";
                double[] total_energy = { (te.MMBTUinperTrip * te.LSD_WTP_TE), (te.MMBTUinperTrip * te.LSD_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 }; //Resource 2
                double[] co2 = { (te.LSD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip), (te.LSD_CO2_EF * te.MMBTUinperTrip) }; //Resource 3
                double[] ch4 = { (te.LSD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip), (te.LSD_CH4_EF * te.MMBTUinperTrip) }; //Resource 4
                double[] n2o = { (te.LSD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip), (te.LSD_N2O_EF * te.MMBTUinperTrip) }; //Resource 5
                double[] ghgs = { 90, 4.5 }; //Resource 6
                double[] voc = { (te.LSD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip), (te.LSD_VOC_EF * te.MMBTUinperTrip) }; //Resource 7
                double[] co = { (te.LSD_WTP_CO * 1000000000000 * te.MMBTUinperTrip), (te.LSD_CO_EF * te.MMBTUinperTrip) }; //Resource 8
                double[] nox = { (te.LSD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip), (te.LSD_NOx_EF * te.MMBTUinperTrip) }; //Resource 9
                double[] pm10 = { (te.LSD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip), (te.LSD_PM10_EF * te.MMBTUinperTrip) }; //Resource 10
                double[] sox = { (te.LSD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip), (te.LSD_SOx_EF * te.MMBTUinperTrip) }; //Resource 11
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

                label30.Text = (te.NG_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // VOC
                label31.Text = (te.NG_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO
                label32.Text = (te.NG_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // NOx
                label33.Text = (te.NG_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM10
                label34.Text = (te.NG_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM2.5
                label35.Text = (te.NG_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // SOx
                label36.Text = (te.NG_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CH4
                label37.Text = (te.NG_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2
                label38.Text = (te.NG_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // N2O
                label41.Text = (te.NG_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2Biogenic

                /*
* Column 2 -- Vessel Operation
*/

                label42.Text = (te.MMBTUinperTrip * te.NG_VO_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
* EMISSIONS
***************/

                label48.Text = (te.NG_VOC_EF * te.MMBTUinperTrip).ToString(); // VOC
                label49.Text = (te.NG_CO_EF * te.MMBTUinperTrip).ToString(); // CO
                label50.Text = (te.NG_NOx_EF * te.MMBTUinperTrip).ToString(); // NOx
                label51.Text = (te.NG_PM10_EF * te.MMBTUinperTrip).ToString(); // PM10
                label52.Text = "PM2.5"; // PM2.5
                label53.Text = (te.NG_SOx_EF * te.MMBTUinperTrip).ToString(); // SOx
                label54.Text = (te.NG_CH4_EF * te.MMBTUinperTrip).ToString(); // CH4
                label55.Text = (te.NG_CO2_EF * te.MMBTUinperTrip).ToString(); // CO2
                label56.Text = (te.NG_N2O_EF * te.MMBTUinperTrip).ToString(); // N2O
                label59.Text = "CO2 Biogenic"; // CO2Biogenic

                /*
* Column 3 -- Total
*/

                label60.Text = (te.MMBTUinperTrip * te.NG_Total_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.NG_Total_FF).ToString("#.##") + " mmbtu/trip"; // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.NG_Total_CF).ToString("#.##") + " mmbtu/trip"; // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.NG_Total_NG).ToString("#.##") + " mmbtu/trip"; // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.NG_Total_PF).ToString("#.##") + " mmbtu/trip"; // Petroleum Fuel

                /***************
* EMISSIONS
***************/

                label66.Text = ((te.NG_WTP_VOC * 1000000000000 * te.MMBTUinperTrip) + (te.NG_VOC_EF * te.MMBTUinperTrip)).ToString(); // VOC
                label67.Text = ((te.NG_WTP_CO * 1000000000000 * te.MMBTUinperTrip) + (te.NG_CO_EF * te.MMBTUinperTrip)).ToString(); // CO
                label68.Text = ((te.NG_WTP_NOX * 1000000000000 * te.MMBTUinperTrip) + (te.NG_NOx_EF * te.MMBTUinperTrip)).ToString(); // NOx
                label69.Text = ((te.NG_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip) + (te.NG_PM10_EF * te.MMBTUinperTrip)).ToString(); // PM10
                label70.Text = "PM2.5"; // PM2.5
                label71.Text = ((te.NG_WTP_SOX * 1000000000000 * te.MMBTUinperTrip) + (te.NG_SOx_EF * te.MMBTUinperTrip)).ToString(); // SOx
                label72.Text = ((te.NG_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip) + (te.NG_CH4_EF * te.MMBTUinperTrip)).ToString(); // CH4
                label73.Text = ((te.NG_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip) + (te.NG_CO2_EF * te.MMBTUinperTrip)).ToString(); // CO2
                label74.Text = ((te.NG_WTP_N2O * 1000000000000 * te.MMBTUinperTrip) + (te.NG_N2O_EF * te.MMBTUinperTrip)).ToString(); // N2O
                label77.Text = "CO2 biogenic"; // CO2Biogenic

                //Title
                label1.Text = "Natural Gas";

                //Setting the stacked bar chart information
                fuelUsed = "Natural Gas";
                double[] total_energy = { (te.MMBTUinperTrip * te.NG_WTP_TE), (te.MMBTUinperTrip * te.NG_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 }; //Resource 2
                double[] co2 = { (te.NG_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip), (te.NG_CO2_EF * te.MMBTUinperTrip) }; //Resource 3
                double[] ch4 = { (te.NG_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip), (te.NG_CH4_EF * te.MMBTUinperTrip) }; //Resource 4
                double[] n2o = { (te.NG_WTP_N2O * 1000000000000 * te.MMBTUinperTrip), (te.NG_N2O_EF * te.MMBTUinperTrip) }; //Resource 5
                double[] ghgs = { 90, 4.5 }; //Resource 6
                double[] voc = { (te.NG_WTP_VOC * 1000000000000 * te.MMBTUinperTrip), (te.NG_VOC_EF * te.MMBTUinperTrip) }; //Resource 7
                double[] co = { (te.NG_WTP_CO * 1000000000000 * te.MMBTUinperTrip), (te.NG_CO_EF * te.MMBTUinperTrip) }; //Resource 8
                double[] nox = { (te.NG_WTP_NOX * 1000000000000 * te.MMBTUinperTrip), (te.NG_NOx_EF * te.MMBTUinperTrip) }; //Resource 9
                double[] pm10 = { (te.NG_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip), (te.NG_PM10_EF * te.MMBTUinperTrip) }; //Resource 10
                double[] sox = { (te.NG_WTP_SOX * 1000000000000 * te.MMBTUinperTrip), (te.NG_SOx_EF * te.MMBTUinperTrip) }; //Resource 11
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

                label30.Text = (te.BD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // VOC
                label31.Text = (te.BD_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO
                label32.Text = (te.BD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // NOx
                label33.Text = (te.BD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM10
                label34.Text = (te.BD_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM2.5
                label35.Text = (te.BD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // SOx
                label36.Text = (te.BD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CH4
                label37.Text = (te.BD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2
                label38.Text = (te.BD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // N2O
                label41.Text = (te.BD_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2Biogenic

                /*
* Column 2 -- Vessel Operation
*/

                label42.Text = (te.MMBTUinperTrip * te.BD_VO_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
* EMISSIONS
***************/

                label48.Text = (te.BD_VOC_EF * te.MMBTUinperTrip).ToString(); // VOC
                label49.Text = (te.BD_CO_EF * te.MMBTUinperTrip).ToString(); // CO
                label50.Text = (te.BD_NOx_EF * te.MMBTUinperTrip).ToString(); // NOx
                label51.Text = (te.BD_PM10_EF * te.MMBTUinperTrip).ToString(); // PM10
                label52.Text = "PM2.5"; // PM2.5
                label53.Text = (te.BD_SOx_EF * te.MMBTUinperTrip).ToString(); // SOx
                label54.Text = (te.BD_CH4_EF * te.MMBTUinperTrip).ToString(); // CH4
                label55.Text = (te.BD_CO2_EF * te.MMBTUinperTrip).ToString(); // CO2
                label56.Text = (te.BD_N2O_EF * te.MMBTUinperTrip).ToString(); // N2O
                label59.Text = "CO2 Biogenic"; // CO2Biogenic

                /*
* Column 3 -- Total
*/

                label60.Text = ((te.MMBTUinperTrip * te.BD_Total_TE) + (-2 * ((te.MMBTUinperTrip * te.BD_WTP_TE) - (te.MMBTUinperTrip * te.BD_VO_TE)))).ToString("#.##") + " mmbtu/trip"; // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.BD_Total_FF).ToString("#.##") + " mmbtu/trip"; // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.BD_Total_CF).ToString("#.##") + " mmbtu/trip"; // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.BD_Total_NG).ToString("#.##") + " mmbtu/trip"; // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.BD_Total_PF).ToString("#.##") + " mmbtu/trip"; // Petroleum Fuel

                /***************
* EMISSIONS
***************/
                label66.Text = ((te.BD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip) + (te.BD_VOC_EF * te.MMBTUinperTrip)).ToString(); // VOC
                label67.Text = ((te.BD_WTP_CO * 1000000000000 * te.MMBTUinperTrip) + (te.BD_CO_EF * te.MMBTUinperTrip)).ToString(); // CO
                label68.Text = ((te.BD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip) + (te.BD_NOx_EF * te.MMBTUinperTrip)).ToString(); // NOx
                label69.Text = ((te.BD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip) + (te.BD_PM10_EF * te.MMBTUinperTrip)).ToString(); // PM10
                label70.Text = "PM2.5"; // PM2.5
                label71.Text = ((te.BD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip) + (te.BD_SOx_EF * te.MMBTUinperTrip)).ToString(); // SOx
                label72.Text = ((te.BD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip) + (te.BD_CH4_EF * te.MMBTUinperTrip)).ToString(); // CH4
                label73.Text = ((te.BD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip) + (te.BD_CO2_EF * te.MMBTUinperTrip)).ToString(); // CO2
                label74.Text = ((te.BD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip) + (te.BD_N2O_EF * te.MMBTUinperTrip)).ToString(); // N2O
                label77.Text = "CO2 biogenic"; // CO2Biogenic

                //Title
                label1.Text = "Biodiesel";

                //Setting the stacked bar chart information
                fuelUsed = "Biodiesel";
                double[] total_energy = { (te.MMBTUinperTrip * te.BD_WTP_TE), (te.MMBTUinperTrip * te.BD_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 }; //Resource 2
                double[] co2 = { (te.BD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip), (te.BD_CO2_EF * te.MMBTUinperTrip) }; //Resource 3
                double[] ch4 = { (te.BD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip), (te.BD_CH4_EF * te.MMBTUinperTrip) }; //Resource 4
                double[] n2o = { (te.BD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip), (te.BD_N2O_EF * te.MMBTUinperTrip) }; //Resource 5
                double[] ghgs = { 90, 4.5 }; //Resource 6
                double[] voc = { (te.BD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip), (te.BD_VOC_EF * te.MMBTUinperTrip) }; //Resource 7
                double[] co = { (te.BD_WTP_CO * 1000000000000 * te.MMBTUinperTrip), (te.BD_CO_EF * te.MMBTUinperTrip) }; //Resource 8
                double[] nox = { (te.BD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip), (te.BD_NOx_EF * te.MMBTUinperTrip) }; //Resource 9
                double[] pm10 = { (te.BD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip), (te.BD_PM10_EF * te.MMBTUinperTrip) }; //Resource 10
                double[] sox = { (te.BD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip), (te.BD_SOx_EF * te.MMBTUinperTrip) }; //Resource 11
                double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };
                //Generate the graph using the resources set and seriesArray.
                Generate_Graph(resources, stacked_graph);
            }
            else if (e.Node.Text == "Fischer Tropsch Diesel")
            {
                /*
* Column 1 -- Well to Pump
*/

                label24.Text = (te.MMBTUinperTrip * te.FTD_WTP_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
* EMISSIONS
***************/

                label30.Text = (te.FTD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // VOC
                label31.Text = (te.FTD_WTP_CO * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO
                label32.Text = (te.FTD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // NOx
                label33.Text = (te.FTD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM10
                label34.Text = (te.FTD_WTP_PM25 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // PM2.5
                label35.Text = (te.FTD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // SOx
                label36.Text = (te.FTD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CH4
                label37.Text = (te.FTD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2
                label38.Text = (te.FTD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // N2O
                label41.Text = (te.FTD_WTP_PM25_CO2Biogenic * 1000000000000 * te.MMBTUinperTrip).ToString("#.##") + " g/trip"; // CO2Biogenic

                /*
* Column 2 -- Vessel Operation
*/

                label42.Text = (te.MMBTUinperTrip * te.FTD_VO_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy

                /***************
* EMISSIONS
***************/

                label48.Text = (te.FTD_VOC_EF * te.MMBTUinperTrip).ToString(); // VOC
                label49.Text = (te.FTD_CO_EF * te.MMBTUinperTrip).ToString(); // CO
                label50.Text = (te.FTD_NOx_EF * te.MMBTUinperTrip).ToString(); // NOx
                label51.Text = (te.FTD_PM10_EF * te.MMBTUinperTrip).ToString(); // PM10
                label52.Text = "PM2.5"; // PM2.5
                label53.Text = (te.FTD_SOx_EF * te.MMBTUinperTrip).ToString(); // SOx
                label54.Text = (te.FTD_CH4_EF * te.MMBTUinperTrip).ToString(); // CH4
                label55.Text = (te.FTD_CO2_EF * te.MMBTUinperTrip).ToString(); // CO2
                label56.Text = (te.FTD_N2O_EF * te.MMBTUinperTrip).ToString(); // N2O
                label59.Text = "CO2 Biogenic"; // CO2Biogenic

                /*
* Column 3 -- Total
*/

                label60.Text = (te.MMBTUinperTrip * te.FTD_Total_TE).ToString("#.##") + " mmbtu/trip"; // Total Energy
                label61.Text = (te.MMBTUinperTrip * te.FTD_Total_FF).ToString("#.##") + " mmbtu/trip"; // Fossil Fuel
                label62.Text = (te.MMBTUinperTrip * te.FTD_Total_CF).ToString("#.##") + " mmbtu/trip"; // Coal Fuel
                label63.Text = (te.MMBTUinperTrip * te.FTD_Total_NG).ToString("#.##") + " mmbtu/trip"; // Natural Gas Fuel
                label64.Text = (te.MMBTUinperTrip * te.FTD_Total_PF).ToString("#.##") + " mmbtu/trip"; // Petroleum Fuel

                /***************
* EMISSIONS
***************/

                label66.Text = ((te.FTD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip) + (te.FTD_VOC_EF * te.MMBTUinperTrip)).ToString(); // VOC
                label67.Text = ((te.FTD_WTP_CO * 1000000000000 * te.MMBTUinperTrip) + (te.FTD_CO_EF * te.MMBTUinperTrip)).ToString(); // CO
                label68.Text = ((te.FTD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip) + (te.FTD_NOx_EF * te.MMBTUinperTrip)).ToString(); // NOx
                label69.Text = ((te.FTD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip) + (te.FTD_PM10_EF * te.MMBTUinperTrip)).ToString(); // PM10
                label70.Text = "PM2.5"; // PM2.5
                label71.Text = ((te.FTD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip) + (te.FTD_SOx_EF * te.MMBTUinperTrip)).ToString(); // SOx
                label72.Text = ((te.FTD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip) + (te.FTD_CH4_EF * te.MMBTUinperTrip)).ToString(); // CH4
                label73.Text = ((te.FTD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip) + (te.FTD_CO2_EF * te.MMBTUinperTrip)).ToString(); // CO2
                label74.Text = ((te.FTD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip) + (te.FTD_N2O_EF * te.MMBTUinperTrip)).ToString(); // N2O
                label77.Text = "CO2 biogenic"; // CO2Biogenic

                //Title
                label1.Text = "Fischer Tropsch Diesel";

                //Setting the stacked bar chart information
                fuelUsed = "Fischer Tropsch Diesel";
                double[] total_energy = { (te.MMBTUinperTrip * te.FTD_WTP_TE), (te.MMBTUinperTrip * te.FTD_VO_TE) }; //Resource 0
                double[] fossil_fuels = { 10, 20 }; //Resource 1
                double[] petroleum = { 15, 25 }; //Resource 2
                double[] co2 = { (te.FTD_WTP_CO2 * 1000000000000 * te.MMBTUinperTrip), (te.FTD_CO2_EF * te.MMBTUinperTrip) }; //Resource 3
                double[] ch4 = { (te.FTD_WTP_CH4 * 1000000000000 * te.MMBTUinperTrip), (te.FTD_CH4_EF * te.MMBTUinperTrip) }; //Resource 4
                double[] n2o = { (te.FTD_WTP_N2O * 1000000000000 * te.MMBTUinperTrip), (te.FTD_N2O_EF * te.MMBTUinperTrip) }; //Resource 5
                double[] ghgs = { 90, 4.5 }; //Resource 6
                double[] voc = { (te.FTD_WTP_VOC * 1000000000000 * te.MMBTUinperTrip), (te.FTD_VOC_EF * te.MMBTUinperTrip) }; //Resource 7
                double[] co = { (te.FTD_WTP_CO * 1000000000000 * te.MMBTUinperTrip), (te.FTD_CO_EF * te.MMBTUinperTrip) }; //Resource 8
                double[] nox = { (te.FTD_WTP_NOX * 1000000000000 * te.MMBTUinperTrip), (te.FTD_NOx_EF * te.MMBTUinperTrip) }; //Resource 9
                double[] pm10 = { (te.FTD_WTP_PM10 * 1000000000000 * te.MMBTUinperTrip), (te.FTD_PM10_EF * te.MMBTUinperTrip) }; //Resource 10
                double[] sox = { (te.FTD_WTP_SOX * 1000000000000 * te.MMBTUinperTrip), (te.FTD_SOx_EF * te.MMBTUinperTrip) }; //Resource 11
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