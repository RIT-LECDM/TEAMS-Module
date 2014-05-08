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
using PlugInsInterfaces.DataTypes.Resource;
using PlugInsInterfaces.DataTypes;
using PlugInsInterfaces.DataTypes.Pathway;
using PlugInsInterfaces.DataTypes.Mix;
using PlugInsInterfaces.ResultTypes;
using PlugInsInterfaces.DataTypes.Technology;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

namespace TEAMSModule
{
    public partial class GREETFormattedResults : Form
    {
        //These are values for the string of text showing what fuel is used
        public string fuelUsed = "Conventional Diesel";
        public string auxFuelUsed = "Conventional Diesel";

        //The input sheet we are pulling from
        public TEAMS te;

        /// <summary>
        /// These are all of the variables for values on the results sheet itself, they are being set to a default of 0
        /// </summary>
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

        //Constructor for this form
        public GREETFormattedResults(TEAMS t)
        {
            //We will use this teams object to pull the GREET values into the TEAMS class, and then reference them here so they can be displayed
            te = t;
            InitializeComponent();
            setValues();
        }

        //Function that sets everything up at the beginning so that the values are a pleasent default to work on
        public void setValues()
        {
            treeView1.Select();
            treeView2.Select();
            BuildingTreeView1();
            BuildingTreeView2();
        }
        /// <summary>
        /// Pulls the needed GREET data, and makes final results calculations
        /// </summary>
        #region Final results calculation
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
                if (resourceUsed.LowerHeatingValue.UserValue == 0)
                {
                    te.GALLONperTrip = resourceUsed.LowerHeatingValue.GreetValue * (3.5878781 / 100000);
                }
                else
                {
                    te.GALLONperTrip = resourceUsed.LowerHeatingValue.UserValue * (3.5878781 / 100000);
                }

                //These numbers will be used in calculations below, and are based on whether or not the user has tried to edit GREET resource variables
                double resourceDensity;
                if (resourceUsed.Density.UserValue == 0)
                {
                    resourceDensity = resourceUsed.Density.GreetValue;
                }
                else
                {
                    resourceDensity = resourceUsed.Density.UserValue;
                }
                double resourceSulfurRatio;
                if (resourceUsed.SulfurRatio.UserValue == 0)
                {
                    resourceSulfurRatio = resourceUsed.SulfurRatio.GreetValue;
                }
                else
                {
                    resourceSulfurRatio = resourceUsed.SulfurRatio.UserValue;
                }
                double resourceLowerHeatingValue;
                if (resourceUsed.LowerHeatingValue.UserValue == 0)
                {
                    resourceLowerHeatingValue = resourceUsed.LowerHeatingValue.GreetValue;
                }
                else
                {
                    resourceLowerHeatingValue = resourceUsed.LowerHeatingValue.UserValue;
                }
                double resourceCarbonRatio;
                if (resourceUsed.CarbonRatio.UserValue == 0)
                {
                    resourceCarbonRatio = resourceUsed.CarbonRatio.GreetValue;
                }
                else
                {
                    resourceCarbonRatio = resourceUsed.CarbonRatio.UserValue;
                }


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
                SOx_VO = resourceDensity * (1000 / 7.48052) * te.GALLONperTrip * resourceSulfurRatio;
                SOx_Total = SOx_WTP + SOx_VO + AUX_SOx_WTP + AUX_SOx_VO;

                CH4_WTP = pathwayResults.LifeCycleEmissions().ElementAt(6).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                CH4_VO = ((te.CH4_gphphr_out * (1 / 0.745699871)) * te.KWHOutperTrip);
                CH4_Total = CH4_WTP + CH4_VO + AUX_CH4_WTP + AUX_CH4_VO;

                CO2_WTP = pathwayResults.LifeCycleEmissions().ElementAt(8).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                double gramsOfFuel = ((1 / (resourceLowerHeatingValue * (3.5878781 / 1000000))) * 1000000 * te.MMBTUinperTrip) * ((resourceDensity * 3.78541178) / 1000);
                CO2_VO = ((resourceCarbonRatio * (gramsOfFuel / te.MMBTUinperTrip)) * te.MMBTUinperTrip) * (44 / 12);
                CO2_Total = CO2_WTP + CO2_VO + AUX_CO2_WTP + AUX_CO2_VO;

                N2O_WTP = pathwayResults.LifeCycleEmissions().ElementAt(7).Value.Value * 1000000000000 * te.MMBTUinperTrip;
                N2O_VO = ((te.N2O_gphphr_out * (1 / 0.745699871)) * te.KWHOutperTrip);
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

                                //These numbers will be used in calculations below, and are based on whether or not the user has tried to edit GREET resource variables
                double resourceDensity;
                if (resourceUsed.Density.UserValue == 0)
                {
                    resourceDensity = resourceUsed.Density.GreetValue;
                }
                else
                {
                    resourceDensity = resourceUsed.Density.UserValue;
                }
                double resourceSulfurRatio;
                if (resourceUsed.SulfurRatio.UserValue == 0)
                {
                    resourceSulfurRatio = resourceUsed.SulfurRatio.GreetValue;
                }
                else
                {
                    resourceSulfurRatio = resourceUsed.SulfurRatio.UserValue;
                }
                double resourceLowerHeatingValue;
                if (resourceUsed.LowerHeatingValue.UserValue == 0)
                {
                    resourceLowerHeatingValue = resourceUsed.LowerHeatingValue.GreetValue;
                }
                else
                {
                    resourceLowerHeatingValue = resourceUsed.LowerHeatingValue.UserValue;
                }
                double resourceCarbonRatio;
                if (resourceUsed.CarbonRatio.UserValue == 0)
                {
                    resourceCarbonRatio = resourceUsed.CarbonRatio.GreetValue;
                }
                else
                {
                    resourceCarbonRatio = resourceUsed.CarbonRatio.UserValue;
                }
                //These should be relatively accurate no matter what, since it's a total energy and not the different engines
                te.AuxEngineGALLONperTrip = resourceLowerHeatingValue * (3.5878781 / 100000);
                AUX_TE_WTP = te.AuxEngineMMBTUinperTrip * ((pathwayResults.LifeCycleResources().ElementAt(13).Value.Value + pathwayResults.LifeCycleResources().ElementAt(12).Value.Value + pathwayResults.LifeCycleResources().ElementAt(11).Value.Value + pathwayResults.LifeCycleResources().ElementAt(10).Value.Value + pathwayResults.LifeCycleResources().ElementAt(9).Value.Value + pathwayResults.LifeCycleResources().ElementAt(8).Value.Value + pathwayResults.LifeCycleResources().ElementAt(7).Value.Value + pathwayResults.LifeCycleResources().ElementAt(6).Value.Value + pathwayResults.LifeCycleResources().ElementAt(5).Value.Value + pathwayResults.LifeCycleResources().ElementAt(4).Value.Value + pathwayResults.LifeCycleResources().ElementAt(3).Value.Value + pathwayResults.LifeCycleResources().ElementAt(2).Value.Value + pathwayResults.LifeCycleResources().ElementAt(1).Value.Value + pathwayResults.LifeCycleResources().ElementAt(0).Value.Value)) - 1;
                AUX_TE_VO = te.AuxEngineMMBTUinperTrip;
                TE_Total = te.MMBTUinperTrip * ((pathwayResults.LifeCycleResources().ElementAt(13).Value.Value + pathwayResults.LifeCycleResources().ElementAt(12).Value.Value + pathwayResults.LifeCycleResources().ElementAt(11).Value.Value + pathwayResults.LifeCycleResources().ElementAt(10).Value.Value + pathwayResults.LifeCycleResources().ElementAt(9).Value.Value + pathwayResults.LifeCycleResources().ElementAt(8).Value.Value + pathwayResults.LifeCycleResources().ElementAt(7).Value.Value + pathwayResults.LifeCycleResources().ElementAt(6).Value.Value + pathwayResults.LifeCycleResources().ElementAt(5).Value.Value + pathwayResults.LifeCycleResources().ElementAt(4).Value.Value + pathwayResults.LifeCycleResources().ElementAt(3).Value.Value + pathwayResults.LifeCycleResources().ElementAt(2).Value.Value + pathwayResults.LifeCycleResources().ElementAt(1).Value.Value + pathwayResults.LifeCycleResources().ElementAt(0).Value.Value)) - 1 + te.MMBTUinperTrip + AUX_TE_WTP + AUX_TE_VO;

                //Requires an input on the input sheet
                AUX_VOC_WTP = pathwayResults.LifeCycleEmissions().ElementAt(0).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_VOC_VO = ((te.AUX_VOC_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                VOC_Total = VOC_WTP + VOC_VO + AUX_VOC_WTP + AUX_VOC_VO;

                AUX_CO_WTP = pathwayResults.LifeCycleEmissions().ElementAt(1).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_CO_VO = ((te.AUX_CO_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                CO_Total = CO_WTP + CO_VO + AUX_CO_WTP + AUX_CO_VO;

                AUX_NOx_WTP = pathwayResults.LifeCycleEmissions().ElementAt(2).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_NOx_VO = ((te.AUX_NOX_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                NOx_Total = NOx_WTP + NOx_VO + AUX_NOx_WTP + AUX_NOx_VO;

                //Requires an input on the input sheet
                AUX_PM10_WTP = pathwayResults.LifeCycleEmissions().ElementAt(3).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_PM10_VO = ((te.AUX_PM10_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                PM10_Total = PM10_WTP + PM10_VO + AUX_PM10_WTP + AUX_PM10_VO;

                //Requires an input on the input sheet
                AUX_PM25_WTP = pathwayResults.LifeCycleEmissions().ElementAt(4).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_PM25_VO = ((te.AUX_PM25_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                PM25_Total = PM25_WTP + PM25_VO + AUX_PM25_WTP + AUX_PM25_VO;

                //Requires an input on the input sheet
                AUX_SOx_WTP = pathwayResults.LifeCycleEmissions().ElementAt(5).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_SOx_VO = resourceDensity * (1000 / 7.48052) * te.AuxEngineGALLONperTrip * resourceSulfurRatio;
                SOx_Total = SOx_WTP + SOx_VO + AUX_SOx_WTP + AUX_SOx_VO;

                AUX_CH4_WTP = pathwayResults.LifeCycleEmissions().ElementAt(6).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_CH4_VO = ((te.AUX_CH4_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                CH4_Total = CH4_WTP + CH4_VO + AUX_CH4_WTP + AUX_CH4_VO;

                double gramsOfFuel = ((1 / (resourceLowerHeatingValue * (3.5878781 / 1000000))) * 1000000 * te.MMBTUinperTrip) * ((resourceDensity * 3.78541178) / 1000);
                AUX_CO2_WTP = pathwayResults.LifeCycleEmissions().ElementAt(8).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_CO2_VO = ((resourceCarbonRatio * (gramsOfFuel / te.AuxEngineMMBTUinperTrip)) * te.AuxEngineMMBTUinperTrip) * (44 / 12);
                CO2_Total = CO2_WTP + CO2_VO + AUX_CO2_WTP + AUX_CO2_VO;

                AUX_N2O_WTP = pathwayResults.LifeCycleEmissions().ElementAt(7).Value.Value * 1000000000000 * te.AuxEngineMMBTUinperTrip;
                AUX_N2O_VO = ((te.AUX_N2O_gphphr_out * (1 / 0.745699871)) * te.AuxEngineKWHoutperTrip);
                N2O_Total = N2O_WTP + N2O_VO + AUX_N2O_WTP + AUX_N2O_VO;

                GHG_WTP = pathwayResults.LifeCycleEmissionsGroups(data).ElementAt(0).Value.Value * 1000000000000 * te.MMBTUinperTrip;
            }
            setLabels();
        }


        private String parseResourceToString(double resource)
        {
            if (resource != 0)
            {
                return (resource).ToString("#.##");
            }
            return "0.00";
        }

        #endregion

        /// <summary>
        /// Sets the labels and makes a new graph
        /// </summary>
        #region Set Labels, Make new Graph
        public void setLabels()
        {
            /* 
            * Column 1 -- Well to Pump
            */
            // Total Energy
            label24.Text = parseResourceToString(TE_WTP) + " mmbtu/trip";

            /***************
             * EMISSIONS
             ***************/

            label30.Text = parseResourceToString(VOC_WTP) + " g/trip";  // VOC
            label31.Text = parseResourceToString(CO_WTP) + " g/trip";   // CO
            label32.Text = parseResourceToString(NOx_WTP) + " g/trip";  // NOx
            label33.Text = parseResourceToString(PM10_WTP) + " g/trip"; // PM10
            label34.Text = parseResourceToString(PM25_WTP) + " g/trip"; // PM2.5
            label35.Text = parseResourceToString(SOx_WTP) + " g/trip";  // SOx
            label36.Text = parseResourceToString(CH4_WTP) + " g/trip";  // CH4
            label37.Text = parseResourceToString(CO2_WTP) + " g/trip";  // CO2
            label38.Text = parseResourceToString(N2O_WTP) + " g/trip";  // N2O

            /*
             * Column 2 -- Vessel Operation
             */

            label42.Text = parseResourceToString(TE_VO) + " mmbtu/trip";  // Total Energy

            /***************
             * EMISSIONS
             ***************/

            label48.Text = parseResourceToString(VOC_VO) + " g/trip";     // VOC
            label49.Text = parseResourceToString(CO_VO) + " g/trip";      // CO
            label50.Text = parseResourceToString(NOx_VO) + " g/trip";     // NOx
            label51.Text = parseResourceToString(PM10_VO) + " g/trip";    // PM10
            label52.Text = parseResourceToString(PM25_VO) + " g/trip";    // PM2.5
            label53.Text = parseResourceToString(SOx_VO) + " g/trip";     // SOx
            label54.Text = parseResourceToString(CH4_VO) + " g/trip";     // CH4
            label55.Text = parseResourceToString(CO2_VO) + " g/trip";     // CO2
            label56.Text = parseResourceToString(N2O_VO) + " g/trip";     // N2O


            //Column 3 -- Aux Engine WTP
            label176.Text = parseResourceToString(AUX_TE_WTP) + " mmbtu/trip";
            label192.Text = parseResourceToString(AUX_VOC_WTP) + " g/trip";
            label193.Text = parseResourceToString(AUX_CO_WTP) + " g/trip";
            label194.Text = parseResourceToString(AUX_NOx_WTP) + " g/trip";
            label195.Text = parseResourceToString(AUX_PM10_WTP) + " g/trip";
            label196.Text = parseResourceToString(AUX_PM25_WTP) + " g/trip";
            label197.Text = parseResourceToString(AUX_SOx_WTP) + " g/trip";
            label198.Text = parseResourceToString(AUX_CH4_WTP) + " g/trip";
            label199.Text = parseResourceToString(AUX_CO2_WTP) + " g/trip";
            label200.Text = parseResourceToString(AUX_N2O_WTP) + " g/trip";

            //Column 4 -- Aux Engine Vessel Operations
            label19.Text = parseResourceToString(AUX_TE_VO) + " mmbtu/trip";
            label40.Text = parseResourceToString(AUX_VOC_VO) + " g/trip";
            label41.Text = parseResourceToString(AUX_CO_VO) + " g/trip";
            label43.Text = parseResourceToString(AUX_NOx_VO) + " g/trip";
            label44.Text = parseResourceToString(AUX_PM10_VO) + " g/trip";
            label45.Text = parseResourceToString(AUX_PM25_VO) + " g/trip";
            label46.Text = parseResourceToString(AUX_SOx_VO) + " g/trip";
            label47.Text = parseResourceToString(AUX_CH4_VO) + " g/trip";
            label57.Text = parseResourceToString(AUX_CO2_VO) + " g/trip";
            label58.Text = parseResourceToString(AUX_N2O_VO) + " g/trip";
            /*
             * Column 5 -- Total
             */

            label60.Text = parseResourceToString(TE_Total) + " mmbtu/trip";   // Total Energy
            label61.Text = parseResourceToString(FF_Total) + " mmbtu/trip";   // Fossil Fuel
            label62.Text = parseResourceToString(CF_Total) + " mmbtu/trip";   // Coal Fuel
            label63.Text = parseResourceToString(NGF_Total) + " mmbtu/trip";  // Natural Gas Fuel
            label64.Text = parseResourceToString(PF_Total) + " mmbtu/trip";   // Petroleum Fuel

            /***************
             * EMISSIONS
             ***************/

            label66.Text = parseResourceToString(VOC_Total) + " g/trip";      // VOC
            label67.Text = parseResourceToString(CO_Total) + " g/trip";       // CO
            label68.Text = parseResourceToString(NOx_Total) + " g/trip";      // NOx
            label69.Text = parseResourceToString(PM10_Total) + " g/trip";     // PM10
            label70.Text = parseResourceToString(PM25_Total) + " g/trip";     // PM2.5
            label71.Text = parseResourceToString(SOx_Total) + " g/trip";      // SOx
            label72.Text = parseResourceToString(CH4_Total) + " g/trip";      // CH4
            label73.Text = parseResourceToString(CO2_Total) + " g/trip";      // CO2
            label74.Text = parseResourceToString(N2O_Total) + " g/trip";      // N2O

            //Title
            label1.Text = fuelUsed;
            label27.Text = auxFuelUsed;
            //Setting the stacked bar chart information
            double[] total_energy = { (TE_WTP + AUX_TE_WTP), (TE_VO + AUX_TE_VO) };  //Resource 0
            double[] fossil_fuels = { 10, 20 };             //Resource 1
            double[] petroleum = { 15, 25 };                //Resource 2
            double[] co2 = { (CO2_WTP + AUX_CO2_WTP), (CO2_VO + AUX_CO2_VO) };         //Resource 3
            double[] ch4 = { (CH4_WTP + AUX_CH4_WTP), (CH4_VO + AUX_CH4_VO) };         //Resource 4
            double[] n2o = { (N2O_WTP + AUX_N2O_WTP), (N2O_VO + AUX_N2O_VO) };         //Resource 5
            double[] ghgs = { 90, 4.5 };                    //Resource 6
            double[] voc = { (VOC_WTP + AUX_VOC_WTP), (VOC_VO + AUX_VOC_VO) };         //Resource 7
            double[] co = { (CO_WTP + AUX_CO_WTP), (CO_VO + AUX_CO_VO) };            //Resource 8
            double[] nox = { (NOx_WTP + AUX_NOx_WTP), (NOx_VO + AUX_NOx_VO) };         //Resource 9
            double[] pm10 = { (PM10_WTP + AUX_PM10_WTP), (PM10_VO + AUX_PM10_VO) };      //Resource 10
            double[] sox = { (SOx_WTP + AUX_SOx_WTP), (SOx_VO + AUX_SOx_VO) };         //Resource 11
            double[][] resources = { total_energy, fossil_fuels, petroleum, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };

            //Generate the graph using the resources set and seriesArray.
            Generate_Graph(resources, stacked_graph);
        }
        #endregion

        /// <summary>
        /// Setup for the main engine fuel selector
        /// </summary>
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

        /// <summary>
        /// Setup for the auxiliary engine fuel selector
        /// </summary>
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

        /// <summary>
        /// Generates the bar chart at the bottom of the form
        /// </summary>
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

        /// <summary>
        /// Saves values to an excel sheet, and lets the user pick the file path and name
        /// </summary>
        #region Saving for the excel sheet

        // For use during export to excel sheet. Prevents system crashing and gives error source to user.
        private void exception_Handling(Exception exception)
        {
            MessageBox.Show("An error occurred while trying to save the file. Ensure it is not being used by another program and try again.\n" +
                            "Exception message: " + exception.Message);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Create the new file to be saved, use Save Dialog Box.
            saveFileDialog1.Filter = "Excel File|.xlsx";
            saveFileDialog1.Title = "Save TEAMS Results to an Excel File";
            DialogResult save_result = saveFileDialog1.ShowDialog();
            // TODO: IMPLEMENT ERROR CHECKING AND HANDLING
            string filePath = saveFileDialog1.FileName;

            // If user cancels the save, do nothing
            if (save_result == DialogResult.Cancel)
            {
                return;
            }

            // Error proofing
            if (filePath == "")
            {
                MessageBox.Show("File name cannot be blank.");
                return;
            }

            // Handling for when the file exists and is being used by another program.
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch ( Exception exception)
                {
                    exception_Handling(exception);
                    return;
                }

                File.Delete(filePath);
                
            }

            // If the file does not previously exist, but for whatever reason cannot be created,
            // handle the exception and cancel the export.
            FileInfo newFile = null;
            try
            {
                newFile = new FileInfo(filePath);
            }
            catch (Exception exception)
            {
                exception_Handling(exception);
                return;
            }

            // If the file could not be created or accessed, return the user to the save menu.
            if (newFile == null) { button1_Click_1(sender, e); }

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // Add a new Worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("TEAMS Results");
                
                // Add the headers
                worksheet.Cells[1, 1].Value = "Vessel name";
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Value = te.VesselTypeID;

                worksheet.Cells[2, 2].Value = "Main Engine";
                worksheet.Cells[2, 2].Style.Font.Bold = true;
                worksheet.Cells[2, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 2, 2, 3].Merge = true;

                worksheet.Cells[2, 4].Value = "Auxiliary Engine";
                worksheet.Cells[2, 4].Style.Font.Bold = true;
                worksheet.Cells[2, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 4, 2, 5].Merge = true;

                worksheet.Cells[3, 1].Value = "Results Shown Per Trip";
                worksheet.Cells[3, 2].Value = "Well To Pump";
                worksheet.Cells[3, 3].Value = "Vessel Operation";
                worksheet.Cells[3, 4].Value = "Well To Pump";
                worksheet.Cells[3, 5].Value = "Vessel Operation";
                worksheet.Cells[3, 6].Value = "Total";

                worksheet.Cells["A3:F3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A3:F3"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                // Add the data

                worksheet.Cells[4, 1].Value = "Total Energy";
                worksheet.Cells[4, 2].Value = TE_WTP;
                worksheet.Cells[4, 3].Value = TE_VO;
                worksheet.Cells[4, 4].Value = AUX_TE_WTP;
                worksheet.Cells[4, 5].Value = AUX_TE_VO;
                worksheet.Cells[4, 6].Value = TE_Total;

                worksheet.Cells[5, 1].Value = "Fossil Fuel";
                worksheet.Cells[5, 6].Value = FF_Total;

                worksheet.Cells[6, 1].Value = "Coal Fuel";
                worksheet.Cells[6, 6].Value = CF_Total;

                worksheet.Cells[7, 1].Value = "Natural Gas Fuel";
                worksheet.Cells[7, 6].Value = NGF_Total;

                worksheet.Cells[8, 1].Value = "Petroleum Fuel";
                worksheet.Cells[8, 6].Value = PF_Total;

                worksheet.Cells[9, 1].Value = "Emissions";

                worksheet.Cells[10, 1].Value = "VOC";
                worksheet.Cells[10, 2].Value = VOC_WTP;
                worksheet.Cells[10, 3].Value = VOC_VO;
                worksheet.Cells[10, 4].Value = AUX_VOC_WTP;
                worksheet.Cells[10, 5].Value = AUX_VOC_VO;
                worksheet.Cells[10, 6].Value = VOC_Total;

                worksheet.Cells[11, 1].Value = "CO";
                worksheet.Cells[11, 2].Value = CO_WTP;
                worksheet.Cells[11, 3].Value = CO_VO;
                worksheet.Cells[11, 4].Value = AUX_CO_WTP;
                worksheet.Cells[11, 5].Value = AUX_CO_VO;
                worksheet.Cells[11, 6].Value = CO_Total;

                worksheet.Cells[12, 1].Value = "NOx";
                worksheet.Cells[12, 2].Value = NOx_WTP;
                worksheet.Cells[12, 3].Value = NOx_VO;
                worksheet.Cells[12, 4].Value = AUX_NOx_WTP;
                worksheet.Cells[12, 5].Value = AUX_NOx_VO;
                worksheet.Cells[12, 6].Value = NOx_Total;

                worksheet.Cells[13, 1].Value = "PM10";
                worksheet.Cells[13, 2].Value = PM10_WTP;
                worksheet.Cells[13, 3].Value = PM10_VO;
                worksheet.Cells[13, 4].Value = AUX_PM10_WTP;
                worksheet.Cells[13, 5].Value = AUX_PM10_VO;
                worksheet.Cells[13, 6].Value = PM10_Total;

                worksheet.Cells[14, 1].Value = "PM 2.5";
                worksheet.Cells[14, 2].Value = PM25_WTP;
                worksheet.Cells[14, 3].Value = PM25_VO;
                worksheet.Cells[14, 4].Value = AUX_PM25_WTP;
                worksheet.Cells[14, 5].Value = AUX_PM25_VO;
                worksheet.Cells[14, 6].Value = PM25_Total;

                worksheet.Cells[15, 1].Value = "SOx";
                worksheet.Cells[15, 2].Value = SOx_WTP;
                worksheet.Cells[15, 3].Value = SOx_VO;
                worksheet.Cells[15, 4].Value = AUX_SOx_WTP;
                worksheet.Cells[15, 5].Value = AUX_SOx_VO;
                worksheet.Cells[15, 6].Value = SOx_Total;

                worksheet.Cells[16, 1].Value = "CH4";
                worksheet.Cells[16, 2].Value = CH4_WTP;
                worksheet.Cells[16, 3].Value = CH4_VO;
                worksheet.Cells[16, 4].Value = AUX_CH4_WTP;
                worksheet.Cells[16, 5].Value = AUX_CH4_VO;
                worksheet.Cells[16, 6].Value = CH4_Total;

                worksheet.Cells[17, 1].Value = "CO2";
                worksheet.Cells[17, 2].Value = CO2_WTP;
                worksheet.Cells[17, 3].Value = CO2_VO;
                worksheet.Cells[17, 4].Value = AUX_CO2_WTP;
                worksheet.Cells[17, 5].Value = AUX_CO2_VO;
                worksheet.Cells[17, 6].Value = CO2_Total;

                worksheet.Cells[18, 1].Value = "N2O";
                worksheet.Cells[18, 2].Value = N2O_WTP;
                worksheet.Cells[18, 3].Value = N2O_VO;
                worksheet.Cells[18, 4].Value = AUX_N2O_WTP;
                worksheet.Cells[18, 5].Value = AUX_N2O_VO;
                worksheet.Cells[18, 6].Value = N2O_Total;

                // Resize the columns to fit the values
                worksheet.Cells["A1:F18"].AutoFitColumns();

                // Save the file
                package.Save();

                MessageBox.Show("Excel spreadsheet saved successfully.", "File Saved");
            }

            
        }
        #endregion

        //Reset button puts everything back to the original default
        private void ResetButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to reset the form?", "Reset Results", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                GREETFormattedResults newWindow = new GREETFormattedResults(te);
                newWindow.Show();
            }

        }
    }
}
