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
using PlugInsInterfaces.DataTypes.Resource;
using PlugInsInterfaces.DataTypes;
using PlugInsInterfaces.DataTypes.Pathway;
using PlugInsInterfaces.DataTypes.Mix;
using PlugInsInterfaces.ResultTypes;
using PlugInsInterfaces.DataTypes.Technology;
using System.Windows.Forms.DataVisualization.Charting;
//using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.IO;
namespace TEAMSModule
{
    public partial class GREETFormattedResults : Form
    {
        public string fuelUsed = "Conventional Diesel";
        public string auxFuelUsed = "Conventional Diesel";

        public TEAMS te;

        #region All Needed Results Variables
        //Main ENgine Variables
        public double TE_WTP = 0;
        public double TE_VO = 0;
        public double TE_Total = 0;
        public double FF_Total = 0;
        public double CF_Total = 0;
        public double NGF_Total = 0;
        public double PF_Total = 0;
        public double VOC_WTP = 0;
        public double VOC_VO = 0;
        public double VOC_Total = 0;
        public double CO_WTP = 0;
        public double CO_VO = 0;
        public double CO_Total = 0;
        public double NOx_WTP = 0;
        public double NOx_VO = 0;
        public double NOx_Total = 0;
        public double PM10_WTP = 0;
        public double PM10_VO = 0;
        public double PM10_Total = 0;
        public double PM25_WTP = 0;
        public double PM25_VO = 0;
        public double PM25_Total = 0;
        public double SOx_WTP = 0;
        public double SOx_VO = 0;
        public double SOx_Total = 0;
        public double CH4_WTP = 0;
        public double CH4_VO = 0;
        public double CH4_Total = 0;
        public double CO2_WTP = 0;
        public double CO2_VO = 0;
        public double CO2_Total = 0;
        public double N2O_WTP = 0;
        public double N2O_VO = 0;
        public double N2O_Total = 0;
        public double GHG_WTP = 0;
        public double GHG_VO = 0;

        //Auxillary Engine Variables
        public double AUX_TE_WTP = 0;
        public double AUX_TE_VO = 0;
        public double AUX_VOC_WTP = 0;
        public double AUX_VOC_VO = 0;
        public double AUX_CO_WTP = 0;
        public double AUX_CO_VO = 0;
        public double AUX_NOx_WTP = 0;
        public double AUX_NOx_VO = 0;
        public double AUX_PM10_WTP = 0;
        public double AUX_PM10_VO = 0;
        public double AUX_PM25_WTP = 0;
        public double AUX_PM25_VO = 0;
        public double AUX_SOx_WTP = 0;
        public double AUX_SOx_VO = 0;
        public double AUX_CH4_WTP = 0;
        public double AUX_CH4_VO = 0;
        public double AUX_CO2_WTP = 0;
        public double AUX_CO2_VO = 0;
        public double AUX_N2O_WTP = 0;
        public double AUX_N2O_VO = 0;
        public double AUX_GHG_WTP = 0;
        public double AUX_GHG_VO = 0;
        #endregion
        public GREETFormattedResults(TEAMS t)
        {
            //We will use this teams object to pull the GREET values into the TEAMS class, and then reference them here so they can be displayed
            te = t;
            InitializeComponent();
            setValues();
        }
        public void setValues()
        {
            treeView1.Select();
            treeView2.Select();
            BuildingTreeView1();
            BuildingTreeView2();
        }

        #region This is where all final results calculations and value pulls are taking place
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Object tag = this.treeView1.SelectedNode.Tag;
            if (tag is IPathway)
            {
                IGDataDictionary<int, IResource> resources = ResultsAccess.controler.CurrentProject.Data.Resources;
                IGDataDictionary<int, IPathway> pathways = ResultsAccess.controler.CurrentProject.Data.Pathways;
                IData data = ResultsAccess.controler.CurrentProject.Data;
                IPathway path = tag as IPathway;
                IResource resourceUsed = ResultsAccess.controler.CurrentProject.Data.Resources.ValueForKey(path.MainOutputResourceID);
                foreach (IResource resource in resources.AllValues.Where(item => item.Id == path.MainOutputResourceID))
                {
                    fuelUsed = resource.Name;
                }
                IResults pathwayResults = path.GetUpstreamResults(data).ElementAt(0).Value;
                //These should be relatively accurate no matter what, since it's a total energy and not the different engines
                TE_WTP = te.MMBTUinperTrip * ((pathwayResults.LifeCycleResources().ElementAt(13).Value.Value + pathwayResults.LifeCycleResources().ElementAt(12).Value.Value + pathwayResults.LifeCycleResources().ElementAt(11).Value.Value + pathwayResults.LifeCycleResources().ElementAt(10).Value.Value + pathwayResults.LifeCycleResources().ElementAt(9).Value.Value + pathwayResults.LifeCycleResources().ElementAt(8).Value.Value + pathwayResults.LifeCycleResources().ElementAt(7).Value.Value + pathwayResults.LifeCycleResources().ElementAt(6).Value.Value + pathwayResults.LifeCycleResources().ElementAt(5).Value.Value + pathwayResults.LifeCycleResources().ElementAt(4).Value.Value + pathwayResults.LifeCycleResources().ElementAt(3).Value.Value + pathwayResults.LifeCycleResources().ElementAt(2).Value.Value + pathwayResults.LifeCycleResources().ElementAt(1).Value.Value + pathwayResults.LifeCycleResources().ElementAt(0).Value.Value)) - 1;
                TE_VO = te.MMBTUinperTrip;
                TE_Total = te.MMBTUinperTrip * ((pathwayResults.LifeCycleResources().ElementAt(13).Value.Value + pathwayResults.LifeCycleResources().ElementAt(12).Value.Value + pathwayResults.LifeCycleResources().ElementAt(11).Value.Value + pathwayResults.LifeCycleResources().ElementAt(10).Value.Value + pathwayResults.LifeCycleResources().ElementAt(9).Value.Value + pathwayResults.LifeCycleResources().ElementAt(8).Value.Value + pathwayResults.LifeCycleResources().ElementAt(7).Value.Value + pathwayResults.LifeCycleResources().ElementAt(6).Value.Value + pathwayResults.LifeCycleResources().ElementAt(5).Value.Value + pathwayResults.LifeCycleResources().ElementAt(4).Value.Value + pathwayResults.LifeCycleResources().ElementAt(3).Value.Value + pathwayResults.LifeCycleResources().ElementAt(2).Value.Value + pathwayResults.LifeCycleResources().ElementAt(1).Value.Value + pathwayResults.LifeCycleResources().ElementAt(0).Value.Value)) - 1 + te.MMBTUinperTrip + AUX_TE_WTP + AUX_TE_VO;

                FF_Total = te.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                CF_Total = te.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(3).Value.Value;
                NGF_Total = te.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(1).Value.Value;
                PF_Total = te.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;

                //Requires an input on the input sheet
                VOC_WTP = pathwayResults.LifeCycleEmissions().ElementAt(0).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                VOC_VO = ((te.VOC_gphphr_out * (1/0.745699871)) * te.KWHOutperTrip);
                VOC_Total = VOC_WTP + VOC_VO + AUX_VOC_WTP + AUX_VOC_VO;

                CO_WTP = pathwayResults.LifeCycleEmissions().ElementAt(1).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                CO_VO = ((te.CO_gphphr_out * (1 / 0.745699871)) * te.KWHOutperTrip);
                CO_Total = CO_WTP + CO_VO + AUX_CO_WTP + AUX_CO_VO;

                NOx_WTP = pathwayResults.LifeCycleEmissions().ElementAt(2).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                NOx_VO = ((te.NOX_gphphr_out * (1 / 0.745699871)) * te.KWHOutperTrip);
                NOx_Total = NOx_WTP + NOx_VO + AUX_NOx_WTP + AUX_NOx_VO;

                //Requires an input on the input sheet
                PM10_WTP = pathwayResults.LifeCycleEmissions().ElementAt(3).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                PM10_VO = ((te.PM10_gphphr_out * (1 / 0.745699871)) * te.KWHOutperTrip);
                PM10_Total = PM10_WTP + PM10_VO + AUX_PM10_WTP + AUX_PM10_VO;

                //Requires an input on the input sheet
                PM25_WTP = pathwayResults.LifeCycleEmissions().ElementAt(4).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                PM25_VO = ((te.PM25_gphphr_out * (1 / 0.745699871)) * te.KWHOutperTrip);
                PM25_Total = PM25_WTP + PM25_VO + AUX_PM25_WTP + AUX_PM25_VO;

                //Requires an input on the input sheet
                SOx_WTP = pathwayResults.LifeCycleEmissions().ElementAt(5).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                SOx_VO = resourceUsed.Density.GreetValue * (1000 / 7.48052) * te.GALLONperTrip * resourceUsed.SulfurRatio.GreetValue;
                SOx_Total = SOx_WTP + SOx_VO + AUX_SOx_WTP + AUX_SOx_VO;

                CH4_WTP = pathwayResults.LifeCycleEmissions().ElementAt(6).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                CH4_VO = 101;
                CH4_Total = CH4_WTP + CH4_VO + AUX_CH4_WTP + AUX_CH4_VO;

                CO2_WTP = pathwayResults.LifeCycleEmissions().ElementAt(8).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                double gramsOfFuel = ((1 / (resourceUsed.LowerHeatingValue.GreetValue * (3.5878781 / 1000000))) * 1000000 * te.MMBTUinperTrip) * ((resourceUsed.Density.GreetValue * 3.78541178) / 1000);
                double carbonPercentage = resourceUsed.CarbonRatio.GreetValue;
                CO2_VO = ((carbonPercentage * (gramsOfFuel / te.MMBTUinperTrip)) * te.MMBTUinperTrip) * (44 / 12);
                CO2_Total = CO2_WTP + CO2_VO + AUX_CO2_WTP + AUX_CO2_VO;

                N2O_WTP = pathwayResults.LifeCycleEmissions().ElementAt(7).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                N2O_VO = 101;
                N2O_Total = N2O_WTP + N2O_VO + AUX_N2O_WTP + AUX_N2O_VO;

                GHG_WTP = pathwayResults.LifeCycleEmissionsGroups(data).ElementAt(0).Value.Value * 1000000000000 * te.MMBTUinperTrip;
            }
            setLabels();
        }
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Object tag = this.treeView2.SelectedNode.Tag;
            if (tag is IPathway)
            {
                IGDataDictionary<int, IResource> resources = ResultsAccess.controler.CurrentProject.Data.Resources;
                IGDataDictionary<int, IPathway> pathways = ResultsAccess.controler.CurrentProject.Data.Pathways;
                IData data = ResultsAccess.controler.CurrentProject.Data;
                IPathway path = tag as IPathway;
                IResource resourceUsed = ResultsAccess.controler.CurrentProject.Data.Resources.ValueForKey(path.MainOutputResourceID);
                foreach (IResource resource in resources.AllValues.Where(item => item.Id == path.MainOutputResourceID))
                {
                    auxFuelUsed = resource.Name;
                }
                IResults pathwayResults = path.GetUpstreamResults(data).ElementAt(0).Value;
                //These should be relatively accurate no matter what, since it's a total energy and not the different engines
                AUX_TE_WTP = te.AuxEngineMMBTUinperTrip * ((pathwayResults.LifeCycleResources().ElementAt(13).Value.Value + pathwayResults.LifeCycleResources().ElementAt(12).Value.Value + pathwayResults.LifeCycleResources().ElementAt(11).Value.Value + pathwayResults.LifeCycleResources().ElementAt(10).Value.Value + pathwayResults.LifeCycleResources().ElementAt(9).Value.Value + pathwayResults.LifeCycleResources().ElementAt(8).Value.Value + pathwayResults.LifeCycleResources().ElementAt(7).Value.Value + pathwayResults.LifeCycleResources().ElementAt(6).Value.Value + pathwayResults.LifeCycleResources().ElementAt(5).Value.Value + pathwayResults.LifeCycleResources().ElementAt(4).Value.Value + pathwayResults.LifeCycleResources().ElementAt(3).Value.Value + pathwayResults.LifeCycleResources().ElementAt(2).Value.Value + pathwayResults.LifeCycleResources().ElementAt(1).Value.Value + pathwayResults.LifeCycleResources().ElementAt(0).Value.Value)) - 1;
                AUX_TE_VO = te.AuxEngineMMBTUinperTrip;
                TE_Total = te.MMBTUinperTrip * ((pathwayResults.LifeCycleResources().ElementAt(13).Value.Value + pathwayResults.LifeCycleResources().ElementAt(12).Value.Value + pathwayResults.LifeCycleResources().ElementAt(11).Value.Value + pathwayResults.LifeCycleResources().ElementAt(10).Value.Value + pathwayResults.LifeCycleResources().ElementAt(9).Value.Value + pathwayResults.LifeCycleResources().ElementAt(8).Value.Value + pathwayResults.LifeCycleResources().ElementAt(7).Value.Value + pathwayResults.LifeCycleResources().ElementAt(6).Value.Value + pathwayResults.LifeCycleResources().ElementAt(5).Value.Value + pathwayResults.LifeCycleResources().ElementAt(4).Value.Value + pathwayResults.LifeCycleResources().ElementAt(3).Value.Value + pathwayResults.LifeCycleResources().ElementAt(2).Value.Value + pathwayResults.LifeCycleResources().ElementAt(1).Value.Value + pathwayResults.LifeCycleResources().ElementAt(0).Value.Value)) - 1 + te.MMBTUinperTrip + AUX_TE_WTP + AUX_TE_VO;

                //Requires an input on the input sheet
                AUX_VOC_WTP = pathwayResults.LifeCycleEmissions().ElementAt(0).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_VOC_VO = ((te.VOC_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                VOC_Total = VOC_WTP + VOC_VO + AUX_VOC_WTP + AUX_VOC_VO;

                AUX_CO_WTP = pathwayResults.LifeCycleEmissions().ElementAt(1).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_CO_VO = ((te.CO_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                CO_Total = CO_WTP + CO_VO + AUX_CO_WTP + AUX_CO_VO;

                AUX_NOx_WTP = pathwayResults.LifeCycleEmissions().ElementAt(2).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_NOx_VO = ((te.NOX_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                NOx_Total = NOx_WTP + NOx_VO + AUX_NOx_WTP + AUX_NOx_VO;

                //Requires an input on the input sheet
                AUX_PM10_WTP = pathwayResults.LifeCycleEmissions().ElementAt(3).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_PM10_VO = ((te.PM10_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                PM10_Total = PM10_WTP + PM10_VO + AUX_PM10_WTP + AUX_PM10_VO;

                //Requires an input on the input sheet
                AUX_PM25_WTP = pathwayResults.LifeCycleEmissions().ElementAt(4).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_PM25_VO = ((te.PM25_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                PM25_Total = PM25_WTP + PM25_VO + AUX_PM25_WTP + AUX_PM25_VO;

                //Requires an input on the input sheet
                AUX_SOx_WTP = pathwayResults.LifeCycleEmissions().ElementAt(5).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_SOx_VO = resourceUsed.Density.GreetValue * (1000 / 7.48052) * te.AuxEngineGALLONperTrip * resourceUsed.SulfurRatio.GreetValue;
                SOx_Total = SOx_WTP + SOx_VO + AUX_SOx_WTP + AUX_SOx_VO;

                AUX_CH4_WTP = pathwayResults.LifeCycleEmissions().ElementAt(6).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_CH4_VO = 101;
                CH4_Total = CH4_WTP + CH4_VO + AUX_CH4_WTP + AUX_CH4_VO;

                double gramsOfFuel = ((1 / (resourceUsed.LowerHeatingValue.GreetValue * (3.5878781 / 1000000))) * 1000000 * te.MMBTUinperTrip) * ((resourceUsed.Density.GreetValue * 3.78541178) / 1000);
                double carbonPercentage = resourceUsed.CarbonRatio.GreetValue;
                AUX_CO2_WTP = pathwayResults.LifeCycleEmissions().ElementAt(8).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_CO2_VO = ((carbonPercentage * (gramsOfFuel / te.AuxEngineMMBTUinperTrip)) * te.AuxEngineMMBTUinperTrip) * (44 / 12);
                CO2_Total = CO2_WTP + CO2_VO + AUX_CO2_WTP + AUX_CO2_VO;

                AUX_N2O_WTP = pathwayResults.LifeCycleEmissions().ElementAt(7).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_N2O_VO = 101;
                N2O_Total = N2O_WTP + N2O_VO + AUX_N2O_WTP + AUX_N2O_VO;

                GHG_WTP = pathwayResults.LifeCycleEmissionsGroups(data).ElementAt(0).Value.Value * 1000000000000 * te.MMBTUinperTrip;
            }
            setLabels();
        }
        #endregion

        #region Setting Labels, and Generating new Graph
        public void setLabels()
        {
            /* 
            * Column 1 -- Well to Pump
            */
            // Total Energy
            label24.Text = (TE_WTP).ToString("#.##") + " mmbtu/trip";

            /***************
             * EMISSIONS
             ***************/

            label30.Text = (VOC_WTP).ToString("#.##") + " g/trip";  // VOC
            label31.Text = (CO_WTP).ToString("#.##") + " g/trip";   // CO
            label32.Text = (NOx_WTP).ToString("#.##") + " g/trip";  // NOx
            label33.Text = (PM10_WTP).ToString("#.##") + " g/trip"; // PM10
            label34.Text = (PM25_WTP).ToString("#.##") + " g/trip"; // PM2.5
            label35.Text = (SOx_WTP).ToString("#.##") + " g/trip";  // SOx
            label36.Text = (CH4_WTP).ToString("#.##") + " g/trip";  // CH4
            label37.Text = (CO2_WTP).ToString("#.##") + " g/trip";  // CO2
            label38.Text = (N2O_WTP).ToString("#.##") + " g/trip";  // N2O

            /*
             * Column 2 -- Vessel Operation
             */

            label42.Text = (TE_VO).ToString("#.##") + " mmbtu/trip";  // Total Energy

            /***************
             * EMISSIONS
             ***************/

            label48.Text = (VOC_VO).ToString("#.##") + " g/trip";     // VOC
            label49.Text = (CO_VO).ToString("#.##") + " g/trip";      // CO
            label50.Text = (NOx_VO).ToString("#.##") + " g/trip";     // NOx
            label51.Text = (PM10_VO).ToString("#.##") + " g/trip";    // PM10
            label52.Text = (PM25_VO).ToString("#.##") + " g/trip";    // PM2.5
            label53.Text = (SOx_VO).ToString("#.##") + " g/trip";     // SOx
            label54.Text = (CH4_VO).ToString("#.##") + " g/trip";     // CH4
            label55.Text = (CO2_VO).ToString("#.##") + " g/trip";     // CO2
            label56.Text = (N2O_VO).ToString("#.##") + " g/trip";     // N2O


            //Column 3 -- Aux Engine WTP
            label176.Text = AUX_TE_WTP.ToString("#.##") + " mmbtu/trip";
            label192.Text = AUX_VOC_WTP.ToString("#.##") + " g/trip";
            label193.Text = AUX_CO_WTP.ToString("#.##") + " g/trip";
            label194.Text = AUX_NOx_WTP.ToString("#.##") + " g/trip";
            label195.Text = AUX_PM10_WTP.ToString("#.##") + " g/trip";
            label196.Text = AUX_PM25_WTP.ToString("#.##") + " g/trip";
            label197.Text = AUX_SOx_WTP.ToString("#.##") + " g/trip";
            label198.Text = AUX_CH4_WTP.ToString("#.##") + " g/trip";
            label199.Text = AUX_CO2_WTP.ToString("#.##") + " g/trip";
            label200.Text = AUX_N2O_WTP.ToString("#.##") + " g/trip";

            //Collumn 4 -- Aux Engine Vessel Operations
            label19.Text = AUX_TE_VO.ToString("#.##") + " mmbtu/trip";
            label40.Text = AUX_VOC_VO.ToString("#.##") + " g/trip";
            label41.Text = AUX_CO_VO.ToString("#.##") + " g/trip";
            label43.Text = AUX_NOx_VO.ToString("#.##") + " g/trip";
            label44.Text = AUX_PM10_VO.ToString("#.##") + " g/trip";
            label45.Text = AUX_PM25_VO.ToString("#.##") + " g/trip";
            label46.Text = AUX_SOx_VO.ToString("#.##") + " g/trip";
            label47.Text = AUX_CH4_VO.ToString("#.##") + " g/trip";
            label57.Text = AUX_CO2_VO.ToString("#.##") + " g/trip";
            label58.Text = AUX_N2O_VO.ToString("#.##") + " g/trip";
            /*
             * Column 5 -- Total
             */

            label60.Text = (TE_Total).ToString("#.##") + " mmbtu/trip";   // Total Energy
            label61.Text = (FF_Total).ToString("#.##") + " mmbtu/trip";   // Fossil Fuel
            label62.Text = (CF_Total).ToString("#.##") + " mmbtu/trip";   // Coal Fuel
            label63.Text = (NGF_Total).ToString("#.##") + " mmbtu/trip";  // Natural Gas Fuel
            label64.Text = (PF_Total).ToString("#.##") + " mmbtu/trip";   // Petroleum Fuel

            /***************
             * EMISSIONS
             ***************/

            label66.Text = (VOC_Total).ToString("#.##") + " g/trip";      // VOC
            label67.Text = (CO_Total).ToString("#.##") + " g/trip";       // CO
            label68.Text = (NOx_Total).ToString("#.##") + " g/trip";      // NOx
            label69.Text = (PM10_Total).ToString("#.##") + " g/trip";     // PM10
            label70.Text = (PM25_Total).ToString("#.##") + " g/trip";     // PM2.5
            label71.Text = (SOx_Total).ToString("#.##") + " g/trip";      // SOx
            label72.Text = (CH4_Total).ToString("#.##") + " g/trip";      // CH4
            label73.Text = (CO2_Total).ToString("#.##") + " g/trip";      // CO2
            label74.Text = (N2O_Total).ToString("#.##") + " g/trip";      // N2O

            //Title
            label1.Text = fuelUsed;
            label27.Text = auxFuelUsed;
            //Setting the stacked bar chart information
            double[] total_energy = { (TE_WTP), (TE_VO) };  //Resource 0
            double[] fossil_fuels = { 10, 20 };             //Resource 1
            double[] petroleum = { 15, 25 };                //Resource 2
            double[] co2 = { (CO2_WTP), (CO2_VO) };         //Resource 3
            double[] ch4 = { (CH4_WTP), (CH4_VO) };         //Resource 4
            double[] n2o = { (N2O_WTP), (N2O_VO) };         //Resource 5
            double[] ghgs = { 90, 4.5 };                    //Resource 6
            double[] voc = { (VOC_WTP), (VOC_VO) };         //Resource 7
            double[] co = { (CO_WTP), (CO_VO) };            //Resource 8
            double[] nox = { (NOx_WTP), (NOx_VO) };         //Resource 9
            double[] pm10 = { (PM10_WTP), (PM10_VO) };      //Resource 10
            double[] sox = { (SOx_WTP), (SOx_VO) };         //Resource 11
            double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };

            //Generate the graph using the resources set and seriesArray.
            Generate_Graph(resources, stacked_graph);
        }
        #endregion
        #region TreeView 1 Setup
        public void BuildingTreeView1()
        {
            treeView1.Nodes.Clear();
            IGDataDictionary<int, IResource> resources = ResultsAccess.controler.CurrentProject.Data.Resources;
            IGDataDictionary<int, IPathway> pathways = ResultsAccess.controler.CurrentProject.Data.Pathways;
            IGDataDictionary<int, IMix> mixes = ResultsAccess.controler.CurrentProject.Data.Mixes;

            //Adds pathways and mixes to the list so the user can select one
            //Conventional Diesel Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 27))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }

            //Residual Oil pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 33))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }
            //Low Sulfur Diesel pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 30))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }
            //Liquid Natural Gas Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 41))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }
            //Biodiesel pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 44))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }

                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }
            //Fischer Tropsch Diesel Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 45))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }

                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView1.Nodes.Add(resourceTreeNode);
            }
        }
        #endregion
        #region TreeView 2 Setup
        public void BuildingTreeView2()
        {
            treeView2.Nodes.Clear();
            IGDataDictionary<int, IResource> resources = ResultsAccess.controler.CurrentProject.Data.Resources;
            IGDataDictionary<int, IPathway> pathways = ResultsAccess.controler.CurrentProject.Data.Pathways;
            IGDataDictionary<int, IMix> mixes = ResultsAccess.controler.CurrentProject.Data.Mixes;

            //Adds pathways and mixes to the list so the user can select one
            //Conventional Diesel Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 27))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView2.Nodes.Add(resourceTreeNode);
            }

            //Residual Oil pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 33))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView2.Nodes.Add(resourceTreeNode);
            }
            //Low Sulfur Diesel pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 30))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView2.Nodes.Add(resourceTreeNode);
            }
            //Liquid Natural Gas Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 41))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView2.Nodes.Add(resourceTreeNode);
            }
            //Biodiesel pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 44))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }

                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView2.Nodes.Add(resourceTreeNode);
            }
            //Fischer Tropsch Diesel Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 45))
            {
                TreeNode resourceTreeNode = new TreeNode(resource.Name);
                resourceTreeNode.Tag = resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode = new TreeNode(pathway.Name);
                    pathwayNode.Tag = pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }

                if (resourceTreeNode.Nodes.Count > 0)
                    this.treeView2.Nodes.Add(resourceTreeNode);
            }
        }
        #endregion
        #region Generating Bar Chart
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
            //Iterate through both of the series.
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
        #endregion

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        #region Saving for the excel sheet
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Create the new file to be saved, use Save Dialog Box.
            saveFileDialog1.Filter = "Excel File|.xlsx";
            saveFileDialog1.Title = "Save TEAMS Results to an Excel File";
            saveFileDialog1.ShowDialog();
            // TODO: IMPLEMENT ERROR CHECKING AND HANDLING
            string filePath = saveFileDialog1.FileName;

            if (filePath == "")
            {
                MessageBox.Show("Error: You must give the file a name!");
                button1_Click_1(sender, e);
            }
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            FileInfo newFile = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // Add a new Worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("TEAMS Results");
                
                // Add the headers
                worksheet.Cells[1, 1].Value = fuelUsed;

                worksheet.Cells[2, 1].Value = "Results Shown Per Trip";
                worksheet.Cells[2, 2].Value = "Well To Pump";
                worksheet.Cells[2, 3].Value = "Vessel Operation";
                worksheet.Cells[2, 4].Value = "Total";

                // Add the data

                worksheet.Cells[3, 1].Value = "Total Energy";
                worksheet.Cells[3, 2].Value = TE_WTP;
                worksheet.Cells[3, 3].Value = TE_VO;
                worksheet.Cells[3, 4].Value = TE_Total;

                worksheet.Cells[4, 1].Value = "Fossil Fuel";
                worksheet.Cells[4, 4].Value = FF_Total;

                worksheet.Cells[5, 1].Value = "Coal Fuel";
                worksheet.Cells[5, 4].Value = CF_Total;

                worksheet.Cells[6, 1].Value = "Natural Gas Fuel";
                worksheet.Cells[6, 4].Value = NGF_Total;

                worksheet.Cells[7, 1].Value = "Petroleum Fuel";
                worksheet.Cells[7, 4].Value = PF_Total;

                worksheet.Cells[8, 1].Value = "Emissions";

                worksheet.Cells[9, 1].Value = "VOC";
                worksheet.Cells[9, 2].Value = VOC_WTP;
                worksheet.Cells[9, 3].Value = VOC_VO;
                worksheet.Cells[9, 4].Value = VOC_Total;

                worksheet.Cells[10, 1].Value = "CO";
                worksheet.Cells[10, 2].Value = CO_WTP;
                worksheet.Cells[10, 3].Value = CO_VO;
                worksheet.Cells[10, 4].Value = CO_Total;

                worksheet.Cells[11, 1].Value = "NOx";
                worksheet.Cells[11, 2].Value = NOx_WTP;
                worksheet.Cells[11, 3].Value = NOx_VO;
                worksheet.Cells[11, 4].Value = NOx_Total;

                worksheet.Cells[12, 1].Value = "PM10";
                worksheet.Cells[12, 2].Value = PM10_WTP;
                worksheet.Cells[12, 3].Value = PM10_VO;
                worksheet.Cells[12, 4].Value = PM10_Total;

                worksheet.Cells[13, 1].Value = "PM 2.5";
                worksheet.Cells[13, 2].Value = PM25_WTP;
                worksheet.Cells[13, 3].Value = PM25_VO;
                worksheet.Cells[13, 4].Value = PM25_Total;

                worksheet.Cells[14, 1].Value = "SOx";
                worksheet.Cells[14, 2].Value = SOx_WTP;
                worksheet.Cells[14, 3].Value = SOx_VO;
                worksheet.Cells[14, 4].Value = SOx_Total;

                worksheet.Cells[15, 1].Value = "CH4";
                worksheet.Cells[15, 2].Value = CH4_WTP;
                worksheet.Cells[15, 3].Value = CH4_VO;
                worksheet.Cells[15, 4].Value = CH4_Total;

                worksheet.Cells[16, 1].Value = "CO2";
                worksheet.Cells[16, 2].Value = CO2_WTP;
                worksheet.Cells[16, 3].Value = CO2_VO;
                worksheet.Cells[16, 4].Value = CO2_Total;

                worksheet.Cells[17, 1].Value = "N2O";
                worksheet.Cells[17, 2].Value = N2O_WTP;
                worksheet.Cells[17, 3].Value = N2O_VO;
                worksheet.Cells[17, 4].Value = N2O_Total;

                // Resize the columns to fit the values
                worksheet.Cells["A1:D17"].AutoFitColumns();

                // Save the file
                package.Save();

                MessageBox.Show("Excel spreadsheet saved successfully.");
            }

            
        }
        #endregion
    }
}
