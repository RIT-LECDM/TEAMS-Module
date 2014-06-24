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
        #region Constants

        // Joules per 1 MMBTU
        private const double JOULES_PER_MMBTU           =   1055870000.0;
        // Grams per 1 Kilogram
        private const double GRAMS_PER_KILOGRAM         =   1000.0;
        // Kilowatt-hours per 1 Horsepower-hour
        private const double KWHRS_PER_HPHR             =   0.745699871;
        // Gallons per 1 cubic meter
        private const double GALLONS_PER_CUBIC_METER    =   264.172;
        // Grams Sulfur Oxide to Grams Sulfur Ratio
        private const double GRAMS_SOX_PER_GRAMS_S      =   64 / 32;

        #endregion

        // These are values for the string of text showing what fuel is used
        public string fuelUsed       =   "None Selected";
        public string auxFuelUsed    =   "None Selected";

        // The input sheet we are pulling from
        public TEAMS te;

        /// <summary>
        /// These are all of the variables for values on the results sheet itself, they are being set to a default of 0
        /// </summary>
        #region All Needed Results Variables

        // Main Engine Variables
        public double TE_WTP     =   0;
        public double TE_VO      =   0;
        public double TE_Total   =   0;
        public double FF_WTP     =   0;
        public double FF_VO      =   0;
        public double FF_Total   =   0;
        public double PF_WTP     =   0;
        public double PF_VO      =   0; 
        public double PF_Total   =   0;
        public double VOC_WTP    =   0;
        public double VOC_VO     =   0;
        public double VOC_Total  =   0;
        public double CO_WTP     =   0;
        public double CO_VO      =   0;
        public double CO_Total   =   0;
        public double NOx_WTP    =   0;
        public double NOx_VO     =   0;
        public double NOx_Total  =   0;
        public double PM10_WTP   =   0;
        public double PM10_VO    =   0;
        public double PM10_Total =   0;
        public double PM25_WTP   =   0;
        public double PM25_VO    =   0;
        public double PM25_Total =   0;
        public double SOx_WTP    =   0;
        public double SOx_VO     =   0;
        public double SOx_Total  =   0;
        public double CH4_WTP    =   0;
        public double CH4_VO     =   0;
        public double CH4_Total  =   0;
        public double CO2_WTP    =   0;
        public double CO2_VO     =   0;
        public double CO2_Total  =   0;
        public double N2O_WTP    =   0;
        public double N2O_VO     =   0;
        public double N2O_Total  =   0;

        // Auxillary Engine Variables
        public double AUX_TE_WTP     =   0;
        public double AUX_TE_VO      =   0;
        public double AUX_FF_WTP     =   0;
        public double AUX_FF_VO      =   0;
        public double AUX_PF_WTP     =   0;
        public double AUX_PF_VO      =   0;
        public double AUX_VOC_WTP    =   0;
        public double AUX_VOC_VO     =   0;
        public double AUX_CO_WTP     =   0;
        public double AUX_CO_VO      =   0;
        public double AUX_NOx_WTP    =   0;
        public double AUX_NOx_VO     =   0;
        public double AUX_PM10_WTP   =   0;
        public double AUX_PM10_VO    =   0;
        public double AUX_PM25_WTP   =   0;
        public double AUX_PM25_VO    =   0;
        public double AUX_SOx_WTP    =   0;
        public double AUX_SOx_VO     =   0;
        public double AUX_CH4_WTP    =   0;
        public double AUX_CH4_VO     =   0;
        public double AUX_CO2_WTP    =   0;
        public double AUX_CO2_VO     =   0;
        public double AUX_N2O_WTP    =   0;
        public double AUX_N2O_VO     =   0;

        public double Total_GHG_WTP  =   0;
        public double Total_GHG_VO   =   0;

        #endregion

        // Constructor for this form
        public GREETFormattedResults(TEAMS t)
        {
            // We will use this teams object to pull the GREET values into the TEAMS class, and then reference them here so they can be displayed
            te = t;
            InitializeComponent();
            setValues();
        }

        // Function that sets everything up at the beginning so that the values are a pleasent default to work on
        public void setValues()
        {
            tree_Main_Fuel_Pathways.Select();
            tree_Aux_Fuel_Pathways.Select();
            BuildingMainFuelPathways();
            BuildingAuxFuelPathways();
        }
        /// <summary>
        /// Pulls the needed GREET data, and makes final results calculations
        /// </summary>
        #region Final results calculation
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Object tag = this.tree_Main_Fuel_Pathways.SelectedNode.Tag;
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
                    te.GALLONperTrip = (1 / resourceUsed.LowerHeatingValue.GreetValue) * GALLONS_PER_CUBIC_METER * JOULES_PER_MMBTU * te.MMBTUinperTrip;
                }
                else
                {
                    te.GALLONperTrip = (1 / resourceUsed.LowerHeatingValue.UserValue) * GALLONS_PER_CUBIC_METER * JOULES_PER_MMBTU * te.MMBTUinperTrip;
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


                double[] main_fuel_type = new double[7];

                if (fuelUsed.Equals("Conventional Diesel"))
                {
                    Array.Copy(te.Diesel, main_fuel_type, te.Diesel.Length);
                }
                else if (fuelUsed.Equals("Residual Oil"))
                {
                    Array.Copy(te.Residual_Oil, main_fuel_type, te.Residual_Oil.Length);
                }
                else if (fuelUsed.Equals("Low-Sulfur Diesel"))
                {
                    Array.Copy(te.Ult_Low_Sulf, main_fuel_type, te.Ult_Low_Sulf.Length);
                }
                else if (fuelUsed.Equals("Liquefied Natural Gas"))
                {
                    Array.Copy(te.Natural_Gas, main_fuel_type, te.Natural_Gas.Length);
                }
                else if (fuelUsed.Equals("Biodiesel"))
                {
                    Array.Copy(te.Biodiesel, main_fuel_type, te.Biodiesel.Length);
                }
                else
                {
                    Array.Copy(te.Fischer, main_fuel_type, te.Fischer.Length);
                }

                //These should be relatively accurate no matter what, since it's a total energy and not the different engines
                //Total Energy Well To Pump = mmbtu of fuel put into the engine * all sections of energy for what it took to create 1 mmbtu of fuel - the 1 mmbtu of fuel

                TE_WTP = te.MMBTUinperTrip * ((
                    // Nuclear Energy
                    pathwayResults.LifeCycleResources().ElementAt(13).Value.Value +
                    // Renewable (Solar, Hydro, Wind, Geothermal
                    pathwayResults.LifeCycleResources().ElementAt(11).Value.Value +
                    // Wind Power
                    pathwayResults.LifeCycleResources().ElementAt(10).Value.Value +
                    // Geothermal
                    pathwayResults.LifeCycleResources().ElementAt(9).Value.Value +
                    // Hydroelectric
                    pathwayResults.LifeCycleResources().ElementAt(8).Value.Value +
                    // Solar
                    pathwayResults.LifeCycleResources().ElementAt(7).Value.Value +
                    // Forest Residue
                    pathwayResults.LifeCycleResources().ElementAt(6).Value.Value +
                    // Farmed Trees or Switchgrass -- unconfirmed which is which
                    pathwayResults.LifeCycleResources().ElementAt(5).Value.Value +
                    // Farmed Trees or Switchgrass -- unconfirmed which is which
                    pathwayResults.LifeCycleResources().ElementAt(4).Value.Value +
                    // Coal Average
                    pathwayResults.LifeCycleResources().ElementAt(3).Value.Value +
                    // Bituminous Oil
                    pathwayResults.LifeCycleResources().ElementAt(2).Value.Value +
                    // Crude Oil
                    pathwayResults.LifeCycleResources().ElementAt(1).Value.Value +
                    // Natural Gas
                    pathwayResults.LifeCycleResources().ElementAt(0).Value.Value)) -
                    1 - te.MMBTUinperTrip;

                //Total Energy Vessel Operation = mmbtu needed to put into the ship
                TE_VO = te.MMBTUinperTrip;
                //Total Energy = Vessel Operation + Well to pump + aux vessel operation + aux well to pump
                TE_Total = TE_WTP + TE_VO + AUX_TE_WTP + AUX_TE_VO;

                // TODO: Implement Fossil Fuels and Petroleum Fuels
                // Fossil Fuels in WTP =  mmbtuin * a greet energy WTP value
                //FF_WTP = te.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                //FF_Total = FF_WTP + FF_VO + AUX_FF_WTP + AUX_FF_VO;
                FF_WTP = 0;
                FF_Total = 0;

                // Petroleum Fuel in WTP =  mmbtuin * a greet energy WTP value
                //PF_WTP = te.MMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;
                //PF_Total = PF_WTP + PF_VO + AUX_PF_WTP + AUX_PF_VO;
                PF_WTP = 0;
                PF_Total = 0;

                // Volatile Organic Compounds
                // Well To Pump Emissions
                VOC_WTP     =   pathwayResults.LifeCycleEmissions().ElementAt(0).Value.Value * JOULES_PER_MMBTU * te.MMBTUinperTrip * GRAMS_PER_KILOGRAM;
                // Vessel Operation Emissions
                VOC_VO      =   main_fuel_type[0] * (1 / KWHRS_PER_HPHR) * te.KWHOutperTrip;
                // Total Emissions
                VOC_Total   =   VOC_WTP + VOC_VO + AUX_VOC_WTP + AUX_VOC_VO;

                // Carbon Monoxide
                CO_WTP      =   pathwayResults.LifeCycleEmissions().ElementAt(1).Value.Value * JOULES_PER_MMBTU * te.MMBTUinperTrip * GRAMS_PER_KILOGRAM;
                CO_VO       =   (main_fuel_type[1] * (1 / KWHRS_PER_HPHR) * te.KWHOutperTrip);
                CO_Total    =   CO_WTP + CO_VO + AUX_CO_WTP + AUX_CO_VO;

                // Nitrogen Dioxide
                NOx_WTP     =   pathwayResults.LifeCycleEmissions().ElementAt(2).Value.Value * JOULES_PER_MMBTU * te.MMBTUinperTrip * GRAMS_PER_KILOGRAM;
                NOx_VO      =   main_fuel_type[2] * (1 / KWHRS_PER_HPHR) * te.KWHOutperTrip;
                NOx_Total   =   NOx_WTP + NOx_VO + AUX_NOx_WTP + AUX_NOx_VO;

                // Particulate Matter 10
                PM10_WTP    =   pathwayResults.LifeCycleEmissions().ElementAt(3).Value.Value * JOULES_PER_MMBTU * te.MMBTUinperTrip * GRAMS_PER_KILOGRAM;
                PM10_VO     =   main_fuel_type[3] * (1 / KWHRS_PER_HPHR) * te.KWHOutperTrip;
                PM10_Total  =   PM10_WTP + PM10_VO + AUX_PM10_WTP + AUX_PM10_VO;

                // Particulate Matter 25
                PM25_WTP    =   pathwayResults.LifeCycleEmissions().ElementAt(4).Value.Value * JOULES_PER_MMBTU * te.MMBTUinperTrip * GRAMS_PER_KILOGRAM;
                PM25_VO     =   main_fuel_type[4] * (1 / KWHRS_PER_HPHR) * te.KWHOutperTrip;
                PM25_Total  =   PM25_WTP + PM25_VO + AUX_PM25_WTP + AUX_PM25_VO;

                // Sulfur Oxides
                SOx_WTP     =   pathwayResults.LifeCycleEmissions().ElementAt(5).Value.Value * JOULES_PER_MMBTU * te.MMBTUinperTrip * GRAMS_PER_KILOGRAM;
                SOx_VO      =   resourceDensity * resourceSulfurRatio * GRAMS_PER_KILOGRAM * (1 / GALLONS_PER_CUBIC_METER) * GRAMS_SOX_PER_GRAMS_S * te.GALLONperTrip;
                SOx_Total   =   SOx_WTP + SOx_VO + AUX_SOx_WTP + AUX_SOx_VO;

                // Methane
                CH4_WTP     =   pathwayResults.LifeCycleEmissions().ElementAt(6).Value.Value * JOULES_PER_MMBTU * te.MMBTUinperTrip * GRAMS_PER_KILOGRAM;
                CH4_VO      =   main_fuel_type[5] * (1 / KWHRS_PER_HPHR) * te.KWHOutperTrip;
                CH4_Total   =   CH4_WTP + CH4_VO + AUX_CH4_WTP + AUX_CH4_VO;

                // Carbon Dioxide
                double gramsOfFuel  =   (1 / resourceLowerHeatingValue) * resourceDensity * JOULES_PER_MMBTU * GRAMS_PER_KILOGRAM * te.MMBTUinperTrip;
                CO2_WTP     =   pathwayResults.LifeCycleEmissions().ElementAt(8).Value.Value * JOULES_PER_MMBTU * te.MMBTUinperTrip * GRAMS_PER_KILOGRAM;
                CO2_VO      =   gramsOfFuel * resourceCarbonRatio * (44 / 12);
                CO2_Total   =   CO2_WTP + CO2_VO + AUX_CO2_WTP + AUX_CO2_VO;

                //Nitrous Oxide
                N2O_WTP     =   pathwayResults.LifeCycleEmissions().ElementAt(7).Value.Value * JOULES_PER_MMBTU * te.MMBTUinperTrip * GRAMS_PER_KILOGRAM;
                N2O_VO      =   main_fuel_type[6] * (1 / KWHRS_PER_HPHR) * te.KWHOutperTrip;
                N2O_Total   =   N2O_WTP + N2O_VO + AUX_N2O_WTP + AUX_N2O_VO;
            }
            setLabels();
        }
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Object tag = this.tree_Aux_Fuel_Pathways.SelectedNode.Tag;
            if (tag is IPathway)
            {
                IGDataDictionary<int, IResource> resources   =   ResultsAccess.controler.CurrentProject.Data.Resources;
                IGDataDictionary<int, IPathway> pathways     =   ResultsAccess.controler.CurrentProject.Data.Pathways;

                IData data               =   ResultsAccess.controler.CurrentProject.Data;
                IPathway path            =   tag as IPathway;
                IResource resourceUsed   =   ResultsAccess.controler.CurrentProject.Data.Resources.ValueForKey(path.MainOutputResourceID);

                foreach (IResource resource in resources.AllValues.Where(item => item.Id == path.MainOutputResourceID))
                {
                    auxFuelUsed  =   resource.Name;
                }
                IResults pathwayResults  =   path.GetUpstreamResults(data).ElementAt(0).Value;

                // These numbers will be used in calculations below, and are based on whether or not the user has tried to edit GREET resource variables
                double resourceDensity;
                if (resourceUsed.Density.UserValue == 0)
                {
                    resourceDensity  =   resourceUsed.Density.GreetValue;
                }
                else
                {
                    resourceDensity  =   resourceUsed.Density.UserValue;
                }
                double resourceSulfurRatio;
                if (resourceUsed.SulfurRatio.UserValue == 0)
                {
                    resourceSulfurRatio  =   resourceUsed.SulfurRatio.GreetValue;
                }
                else
                {
                    resourceSulfurRatio  =   resourceUsed.SulfurRatio.UserValue;
                }
                double resourceLowerHeatingValue;
                if (resourceUsed.LowerHeatingValue.UserValue == 0)
                {
                    resourceLowerHeatingValue    =   resourceUsed.LowerHeatingValue.GreetValue;
                }
                else
                {
                    resourceLowerHeatingValue    =   resourceUsed.LowerHeatingValue.UserValue;
                }
                double resourceCarbonRatio;
                if (resourceUsed.CarbonRatio.UserValue == 0)
                {
                    resourceCarbonRatio  =   resourceUsed.CarbonRatio.GreetValue;
                }
                else
                {
                    resourceCarbonRatio  =   resourceUsed.CarbonRatio.UserValue;
                }

                double[] aux_fuel_type   =   new double[7];

                if (auxFuelUsed.Equals("Conventional Diesel"))
                {
                    Array.Copy(te.Aux_Diesel, aux_fuel_type, te.Aux_Diesel.Length);
                }
                else if (auxFuelUsed.Equals("Residual Oil"))
                {
                    Array.Copy(te.Aux_Residual_Oil, aux_fuel_type, te.Aux_Residual_Oil.Length);
                }
                else if (auxFuelUsed.Equals("Low-Sulfur Diesel"))
                {
                    Array.Copy(te.Aux_Ult_Low_Sulf, aux_fuel_type, te.Aux_Ult_Low_Sulf.Length);
                }
                else if (auxFuelUsed.Equals("Liquefied Natural Gas"))
                {
                    Array.Copy(te.Aux_Natural_Gas, aux_fuel_type, te.Aux_Natural_Gas.Length);
                }
                else if (auxFuelUsed.Equals("Biodiesel"))
                {
                    Array.Copy(te.Aux_Biodiesel, aux_fuel_type, te.Aux_Biodiesel.Length);
                }
                else
                {
                    Array.Copy(te.Aux_Fischer, aux_fuel_type, te.Aux_Fischer.Length);
                }

                te.AuxEngineGALLONperTrip = (1 / resourceLowerHeatingValue) * GALLONS_PER_CUBIC_METER * JOULES_PER_MMBTU * te.AuxEngineMMBTUinperTrip;
                AUX_TE_WTP = te.AuxEngineMMBTUinperTrip * 
                    // Nuclear Energy
                    ((pathwayResults.LifeCycleResources().ElementAt(13).Value.Value  + 
                    // Renewable (Solar, Hydro, Wind, GeoThermal)
                    pathwayResults.LifeCycleResources().ElementAt(11).Value.Value    + 
                    // Wind Power
                    pathwayResults.LifeCycleResources().ElementAt(10).Value.Value    + 
                    // Geothermal
                    pathwayResults.LifeCycleResources().ElementAt(9).Value.Value     + 
                    // Hydroelectric
                    pathwayResults.LifeCycleResources().ElementAt(8).Value.Value     + 
                    // Solar
                    pathwayResults.LifeCycleResources().ElementAt(7).Value.Value     + 
                    // Forest Residue
                    pathwayResults.LifeCycleResources().ElementAt(6).Value.Value     + 
                    // Farmed Trees OR Switchgrass -- unconfirmed which is which
                    pathwayResults.LifeCycleResources().ElementAt(5).Value.Value     + 
                    // Farmed Trees OR Switchgrass -- unconfirmed which is which
                    pathwayResults.LifeCycleResources().ElementAt(4).Value.Value     + 
                    // Coal Average
                    pathwayResults.LifeCycleResources().ElementAt(3).Value.Value     + 
                    // Bituminous Oil
                    pathwayResults.LifeCycleResources().ElementAt(2).Value.Value     + 
                    // Crude Oil
                    pathwayResults.LifeCycleResources().ElementAt(1).Value.Value     + 
                    // Natural Gas
                    pathwayResults.LifeCycleResources().ElementAt(0).Value.Value))   -
                    1 - te.AuxEngineMMBTUinperTrip;

                AUX_TE_VO    =   te.AuxEngineMMBTUinperTrip;
                TE_Total     =   TE_WTP + TE_VO + AUX_TE_WTP + AUX_TE_VO;
                
                // TODO: Implement Fossil Fuels and Petroleum Fuels
                // Fossil Fuels in WTP =  mmbtuin * a greet energy WTP value
                //AUX_FF_WTP = te.AuxEngineMMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                //FF_Total = FF_WTP + FF_VO + AUX_FF_WTP + AUX_FF_VO;
                AUX_FF_WTP = 0;
                FF_Total = 0;

                // Petroleum Fuel in WTP =  mmbtuin * a greet energy WTP value
                //AUX_PF_WTP = te.AuxEngineMMBTUinperTrip * pathwayResults.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;
                //PF_Total = PF_WTP + PF_VO + AUX_PF_WTP + AUX_PF_VO;              
                AUX_PF_WTP = 0;
                PF_Total = 0;

                AUX_VOC_WTP  =   pathwayResults.LifeCycleEmissions().ElementAt(0).Value.Value * JOULES_PER_MMBTU * te.AuxEngineMMBTUinperTrip * GRAMS_PER_KILOGRAM;
                AUX_VOC_VO   =   aux_fuel_type[0] * ( 1 / KWHRS_PER_HPHR ) * te.AuxEngineKWHoutperTrip;
                VOC_Total    =   VOC_WTP + VOC_VO + AUX_VOC_WTP + AUX_VOC_VO;

                AUX_CO_WTP   =   pathwayResults.LifeCycleEmissions().ElementAt(1).Value.Value * JOULES_PER_MMBTU * te.AuxEngineMMBTUinperTrip * GRAMS_PER_KILOGRAM;
                AUX_CO_VO    =   aux_fuel_type[1] * ( 1 / KWHRS_PER_HPHR ) * te.AuxEngineKWHoutperTrip;
                CO_Total     =   CO_WTP + CO_VO + AUX_CO_WTP + AUX_CO_VO;

                AUX_NOx_WTP  =   pathwayResults.LifeCycleEmissions().ElementAt(2).Value.Value * JOULES_PER_MMBTU * te.AuxEngineMMBTUinperTrip * GRAMS_PER_KILOGRAM;
                AUX_NOx_VO   =   aux_fuel_type[2] * ( 1 / KWHRS_PER_HPHR ) * te.AuxEngineKWHoutperTrip;
                NOx_Total    =   NOx_WTP + NOx_VO + AUX_NOx_WTP + AUX_NOx_VO;

                AUX_PM10_WTP =   pathwayResults.LifeCycleEmissions().ElementAt(3).Value.Value * JOULES_PER_MMBTU * te.AuxEngineMMBTUinperTrip * GRAMS_PER_KILOGRAM;
                AUX_PM10_VO  =   aux_fuel_type[3] * ( 1 / KWHRS_PER_HPHR ) * te.AuxEngineKWHoutperTrip;
                PM10_Total   =   PM10_WTP + PM10_VO + AUX_PM10_WTP + AUX_PM10_VO;

                AUX_PM25_WTP =   pathwayResults.LifeCycleEmissions().ElementAt(4).Value.Value * JOULES_PER_MMBTU * te.AuxEngineMMBTUinperTrip * GRAMS_PER_KILOGRAM;
                AUX_PM25_VO  =   aux_fuel_type[4] * ( 1 / KWHRS_PER_HPHR ) * te.AuxEngineKWHoutperTrip;
                PM25_Total   =   PM25_WTP + PM25_VO + AUX_PM25_WTP + AUX_PM25_VO;

                AUX_SOx_WTP  =   pathwayResults.LifeCycleEmissions().ElementAt(5).Value.Value * JOULES_PER_MMBTU * te.AuxEngineMMBTUinperTrip * GRAMS_PER_KILOGRAM;
                AUX_SOx_VO   =   resourceDensity * resourceSulfurRatio * GRAMS_PER_KILOGRAM * ( 1 / GALLONS_PER_CUBIC_METER ) * GRAMS_SOX_PER_GRAMS_S * te.AuxEngineGALLONperTrip;
                SOx_Total    =   SOx_WTP + SOx_VO + AUX_SOx_WTP + AUX_SOx_VO;

                AUX_CH4_WTP  =   pathwayResults.LifeCycleEmissions().ElementAt(6).Value.Value * JOULES_PER_MMBTU * te.AuxEngineMMBTUinperTrip * GRAMS_PER_KILOGRAM;
                AUX_CH4_VO   =   aux_fuel_type[5] * ( 1 / KWHRS_PER_HPHR ) * te.AuxEngineKWHoutperTrip;
                CH4_Total    =   CH4_WTP + CH4_VO + AUX_CH4_WTP + AUX_CH4_VO;

                double gramsOfFuel   =   (1 / resourceLowerHeatingValue) * resourceDensity * JOULES_PER_MMBTU * GRAMS_PER_KILOGRAM * te.AuxEngineMMBTUinperTrip;
                AUX_CO2_WTP  =   pathwayResults.LifeCycleEmissions().ElementAt(8).Value.Value * JOULES_PER_MMBTU * te.AuxEngineMMBTUinperTrip * GRAMS_PER_KILOGRAM;
                AUX_CO2_VO   =   gramsOfFuel * resourceCarbonRatio * (44 / 12);
                CO2_Total    =   CO2_WTP + CO2_VO + AUX_CO2_WTP + AUX_CO2_VO;

                AUX_N2O_WTP  =   pathwayResults.LifeCycleEmissions().ElementAt(7).Value.Value * JOULES_PER_MMBTU * te.AuxEngineMMBTUinperTrip * GRAMS_PER_KILOGRAM;
                AUX_N2O_VO   =   aux_fuel_type[6] * ( 1 / KWHRS_PER_HPHR ) * te.AuxEngineKWHoutperTrip;
                N2O_Total    =   N2O_WTP + N2O_VO + AUX_N2O_WTP + AUX_N2O_VO;
            }
            setLabels();
        }


        private String parseResourceToString(double resource)
        {
            if (resource != 0) { return (resource).ToString("#.##"); }
            else { return "0.00"; }
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
            label_Main_TE_WTP.Text = parseResourceToString(TE_WTP) + " mmbtu/trip";

            /***********************************************************
             * TODO: Re-implement Fossil Fuel and Petroleum Fuel Results
             ***********************************************************/

            // Fossil Fuel
            //label_Main_FF_WTP.Text = parseResourceToString(FF_WTP) + " mmbtu/trip";
            label_Fossil_Fuels.Text = "";
            label_Main_FF_WTP.Text = "";

            // Petroleum Fuel
            //label_Main_PF_WTP.Text = parseResourceToString(PF_WTP) + " mmbtu/trip";
            label_Petroleum_Fuel.Text = "";
            label_Main_PF_WTP.Text = "";


            /***************
             * EMISSIONS
             ***************/

            label_Main_VOC_WTP.Text    =   parseResourceToString(VOC_WTP) + " g/trip";   // VOC
            label_Main_CO_WTP.Text     =   parseResourceToString(CO_WTP) + " g/trip";     // CO
            label_Main_NOx_WTP.Text    =   parseResourceToString(NOx_WTP) + " g/trip";   // NOx
            label_Main_PM10_WTP.Text   =   parseResourceToString(PM10_WTP) + " g/trip"; // PM10
            label_Main_PM25_WTP.Text   =   parseResourceToString(PM25_WTP) + " g/trip"; // PM2.5
            label_Main_SOx_WTP.Text    =   parseResourceToString(SOx_WTP) + " g/trip";   // SOx
            label_Main_CH4_WTP.Text    =   parseResourceToString(CH4_WTP) + " g/trip";   // CH4
            label_Main_CO2_WTP.Text    =   parseResourceToString(CO2_WTP) + " g/trip";   // CO2
            label_Main_N2O_WTP.Text    =   parseResourceToString(N2O_WTP) + " g/trip";   // N2O

            /*
             * Column 2 -- Vessel Operation
             */

            label_Main_TE_VO.Text      =   parseResourceToString(TE_VO) + " mmbtu/trip";  // Total Energy

            /***************
             * EMISSIONS
             ***************/

            label_Main_VOC_VO.Text    =   parseResourceToString(VOC_VO) + " g/trip";     // VOC
            label_Main_CO_VO.Text     =   parseResourceToString(CO_VO) + " g/trip";      // CO
            label_Main_NOx_VO.Text    =   parseResourceToString(NOx_VO) + " g/trip";     // NOx
            label_Main_PM10_VO.Text   =   parseResourceToString(PM10_VO) + " g/trip";    // PM10
            label_Main_PM25_VO.Text   =   parseResourceToString(PM25_VO) + " g/trip";    // PM2.5
            label_Main_SOx_VO.Text    =   parseResourceToString(SOx_VO) + " g/trip";     // SOx
            label_Main_CH4_VO.Text    =   parseResourceToString(CH4_VO) + " g/trip";     // CH4
            label_Main_CO2_VO.Text    =   parseResourceToString(CO2_VO) + " g/trip";     // CO2
            label_Main_N2O_VO.Text    =   parseResourceToString(N2O_VO) + " g/trip";     // N2O


            // Column 3 -- Aux Engine WTP
            label_Aux_TE_WTP.Text     =   parseResourceToString(AUX_TE_WTP) + " mmbtu/trip";
            label_Aux_VOC_WTP.Text    =   parseResourceToString(AUX_VOC_WTP) + " g/trip";
            label_Aux_CO_WTP.Text     =   parseResourceToString(AUX_CO_WTP) + " g/trip";
            label_Aux_NOx_WTP.Text    =   parseResourceToString(AUX_NOx_WTP) + " g/trip";
            label_Aux_PM10_WTP.Text   =   parseResourceToString(AUX_PM10_WTP) + " g/trip";
            label_Aux_PM25_WTP.Text   =   parseResourceToString(AUX_PM25_WTP) + " g/trip";
            label_Aux_SOx_WTP.Text    =   parseResourceToString(AUX_SOx_WTP) + " g/trip";
            label_Aux_CH4_WTP.Text    =   parseResourceToString(AUX_CH4_WTP) + " g/trip";
            label_Aux_CO2_WTP.Text    =   parseResourceToString(AUX_CO2_WTP) + " g/trip";
            label_Aux_N2O_WTP.Text    =   parseResourceToString(AUX_N2O_WTP) + " g/trip";

            /***********************************************************
             * TODO: Re-implement Fossil Fuel and Petroleum Fuel Results
             ***********************************************************/

            // Fossil Fuel Aux WTP
            //label_Aux_FF_WTP.Text     =   parseResourceToString(AUX_FF_WTP) + " mmbtu/trip";
            label_Aux_FF_WTP.Text = "";

            // Petroleum Fuel Total
            //label_Aux_PF_WTP.Text     =   parseResourceToString(AUX_PF_WTP) + " mmbtu/trip";
            label_Aux_PF_WTP.Text = "";

            // Column 4 -- Aux Engine Vessel Operations
            label_Aux_TE_VO.Text      =   parseResourceToString(AUX_TE_VO) + " mmbtu/trip";
            label_Aux_VOC_VO.Text     =   parseResourceToString(AUX_VOC_VO) + " g/trip";
            label_Aux_CO_VO.Text      =   parseResourceToString(AUX_CO_VO) + " g/trip";
            label_Aux_NOx_VO.Text     =   parseResourceToString(AUX_NOx_VO) + " g/trip";
            label_Aux_PM10_VO.Text    =   parseResourceToString(AUX_PM10_VO) + " g/trip";
            label_Aux_PM25_VO.Text    =   parseResourceToString(AUX_PM25_VO) + " g/trip";
            label_Aux_SOx_VO.Text     =   parseResourceToString(AUX_SOx_VO) + " g/trip";
            label_Aux_CH4_VO.Text     =   parseResourceToString(AUX_CH4_VO) + " g/trip";
            label_Aux_CO2_VO.Text     =   parseResourceToString(AUX_CO2_VO) + " g/trip";
            label_Aux_N2O_VO.Text     =   parseResourceToString(AUX_N2O_VO) + " g/trip";
            /*
             * Column 5 -- Total
             */

            // Total Energy
            label_TE_Total.Text     =   parseResourceToString(TE_Total) + " mmbtu/trip";


            /***********************************************************
             * TODO: Re-implement Fossil Fuel and Petroleum Fuel Results
             ***********************************************************/
            // Fossil Fuel Total
            //label_FF_Total.Text     =   parseResourceToString(FF_Total) + " mmbtu/trip";
            label_FF_Total.Text = "";

            // Petroleum Fuel Total
            //label_PF_Total.Text     =   parseResourceToString(PF_Total) + " mmbtu/trip";
            label_PF_Total.Text = "";

            /***************
             * EMISSIONS
             ***************/

            label_VOC_Total.Text     =   parseResourceToString(VOC_Total) + " g/trip";
            label_CO_Total.Text      =   parseResourceToString(CO_Total) + " g/trip";
            label_NOx_Total.Text     =   parseResourceToString(NOx_Total) + " g/trip";
            label_PM10_Total.Text    =   parseResourceToString(PM10_Total) + " g/trip";
            label_PM25_Total.Text    =   parseResourceToString(PM25_Total) + " g/trip";
            label_SOx_Total.Text     =   parseResourceToString(SOx_Total) + " g/trip";
            label_CH4_Total.Text     =   parseResourceToString(CH4_Total) + " g/trip";
            label_CO2_Total.Text     =   parseResourceToString(CO2_Total) + " g/trip";
            label_N2O_Total.Text     =   parseResourceToString(N2O_Total) + " g/trip";

            // Title
            label_Main_Fuel_Type.Text   =   fuelUsed;
            label_Aux_Fuel_Type.Text    =   auxFuelUsed;

            // Calculating greenhouse gas using Global Warming Potential
            Total_GHG_WTP    =   (CO2_WTP * te.CO2_GWP) + (CH4_WTP * te.CH4_GWP) + (N2O_WTP * te.N2O_GWP) + (VOC_WTP * te.VOC_GWP) + (CO_WTP * te.CO_GWP) + (NOx_WTP * te.NO2_GWP);
            Total_GHG_VO     =   (CO2_VO * te.CO2_GWP) + (CH4_VO * te.CH4_GWP) + (N2O_VO * te.N2O_GWP) + (VOC_VO * te.VOC_GWP) + (CO_VO * te.CO_GWP) + (NOx_VO * te.NO2_GWP);

            // Preparing the stacked bar chart information
            double[] total_energy    =   { (TE_WTP + AUX_TE_WTP), (TE_VO + AUX_TE_VO) };     // Resource 0
            /* TODO: Re-implement fossil_fuels and petroleum calculations
             * double[] fossil_fuels = { 10, 20 };             // Resource xx
             * double[] petroleum = { 15, 25 };                // Resource xx
             * */
            double[] co2     =   { (CO2_WTP + AUX_CO2_WTP), (CO2_VO + AUX_CO2_VO) };         // Resource 1
            double[] ch4     =   { (CH4_WTP + AUX_CH4_WTP), (CH4_VO + AUX_CH4_VO) };         // Resource 2
            double[] n2o     =   { (N2O_WTP + AUX_N2O_WTP), (N2O_VO + AUX_N2O_VO) };         // Resource 3
            double[] ghgs    =   { Total_GHG_WTP, Total_GHG_VO };                            // Resource 4
            double[] voc     =   { (VOC_WTP + AUX_VOC_WTP), (VOC_VO + AUX_VOC_VO) };         // Resource 5
            double[] co      =   { (CO_WTP + AUX_CO_WTP), (CO_VO + AUX_CO_VO) };             // Resource 6
            double[] nox     =   { (NOx_WTP + AUX_NOx_WTP), (NOx_VO + AUX_NOx_VO) };         // Resource 7
            double[] pm10    =   { (PM10_WTP + AUX_PM10_WTP), (PM10_VO + AUX_PM10_VO) };     // Resource 8
            double[] sox     =   { (SOx_WTP + AUX_SOx_WTP), (SOx_VO + AUX_SOx_VO) };         // Resource 9

            double[][] resources     =   { total_energy, co2, ch4, n2o, ghgs, voc, co, nox, pm10, sox };

            // Generate the graph using the resources set and seriesArray.
            Generate_Graph(resources, graph_VO_vs_WTP);
        }
        #endregion

        /// <summary>
        /// Setup for the main engine fuel selector
        /// </summary>
        #region Main Fuel Pathways Setup
        public void BuildingMainFuelPathways()
        {
            tree_Main_Fuel_Pathways.Nodes.Clear();
            IGDataDictionary<int, IResource> resources   =   ResultsAccess.controler.CurrentProject.Data.Resources;
            IGDataDictionary<int, IPathway> pathways     =   ResultsAccess.controler.CurrentProject.Data.Pathways;
            IGDataDictionary<int, IMix> mixes            =   ResultsAccess.controler.CurrentProject.Data.Mixes;

            // Adds pathways and mixes to the list so the user can select one
            // Conventional Diesel Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 27))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode     =   new TreeNode(pathway.Name);
                    pathwayNode.Tag          =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Main_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }

            // Residual Oil pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 33))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Main_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }
            // Low Sulfur Diesel pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 30))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Main_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }
            // Liquid Natural Gas Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 41))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Main_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }
            // Biodiesel pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 44))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }

                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Main_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }
            // Fischer Tropsch Diesel Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 45))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }

                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Main_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }
        }
        #endregion

        /// <summary>
        /// Setup for the auxiliary engine fuel selector
        /// </summary>
        #region Auxiliary Fuel Pathways Setup
        public void BuildingAuxFuelPathways()
        {
            tree_Aux_Fuel_Pathways.Nodes.Clear();
            IGDataDictionary<int, IResource> resources   =   ResultsAccess.controler.CurrentProject.Data.Resources;
            IGDataDictionary<int, IPathway> pathways     =   ResultsAccess.controler.CurrentProject.Data.Pathways;
            IGDataDictionary<int, IMix> mixes            =   ResultsAccess.controler.CurrentProject.Data.Mixes;

            // Adds pathways and mixes to the list so the user can select one
            // Conventional Diesel Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 27))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Aux_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }

            // Residual Oil pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 33))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Aux_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }
            // Low Sulfur Diesel pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 30))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Aux_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }
            // Liquid Natural Gas Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 41))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }
                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Aux_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }
            // Biodiesel pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 44))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }

                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Aux_Fuel_Pathways.Nodes.Add(resourceTreeNode);
            }
            // Fischer Tropsch Diesel Pathways
            foreach (IResource resource in resources.AllValues.Where(item => item.Id == 45))
            {
                TreeNode resourceTreeNode    =   new TreeNode(resource.Name);
                resourceTreeNode.Tag         =   resource;

                foreach (IPathway pathway in pathways.AllValues.Where(item => item.MainOutputResourceID == resource.Id))
                {
                    TreeNode pathwayNode =   new TreeNode(pathway.Name);
                    pathwayNode.Tag      =   pathway;
                    resourceTreeNode.Nodes.Add(pathwayNode);
                }

                if (resourceTreeNode.Nodes.Count > 0)
                    this.tree_Aux_Fuel_Pathways.Nodes.Add(resourceTreeNode);
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
        /// <param name="resources">A collection of the resources to be modeled by the graph with values: { %upstream%, %vesseloperation% }</param>
        /// <param name="graph">The graph to be generated. Note that this should always be the graph from the designer, 'stacked_graph'.
        ///                     If you wish to generate another graph, you will need to do more than pass the graph in as a parameter.</param>
        /// <param name="title">The title of the graph to be displayed.</param>
        private void Generate_Graph(double[][] resources, Chart graph)
        {
            // Matches the series collection already outlined in the designer.
            string[] seriesArray     =   { "WellToPump", "VesselOperation" };

            // Set the title of the graph to the passed in string title.
            graph.Titles[0].Text     =   te.VesselTypeID + "\nMain Engine: " + fuelUsed + "\nAuxiliary Engine: " + auxFuelUsed;

            // Iterate through both of the series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Clears points to ensure working with a new graph.
                graph.Series[i].Points.Clear();

                // Add each resource value to the respective series from the parent loop.
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

        private void ExportButton_Click(object sender, EventArgs e)
        {
            // Create the new file to be saved, use Save Dialog Box.
            SaveFile.Filter   =   "Excel File|.xlsx";
            SaveFile.Title    =   "Save TEAMS Results to an Excel File";
            DialogResult save_result =   SaveFile.ShowDialog();

            string filePath  =   SaveFile.FileName;

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
            FileInfo newFile     =   null;
            try
            {
                newFile  =   new FileInfo(filePath);
            }
            catch (Exception exception)
            {
                exception_Handling(exception);
                return;
            }

            // If the file could not be created or accessed, return the user to the save menu.
            if (newFile == null) { ExportButton_Click(sender, e); }

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // Add a new Worksheet to the empty workbook
                ExcelWorksheet worksheet     =   package.Workbook.Worksheets.Add("TEAMS Results");
                
                // Add the headers
                worksheet.Cells[1, 1].Value              =   "Vessel name";
                worksheet.Cells[1, 1].Style.Font.Bold    =   true;
                worksheet.Cells[1, 2].Value              =   te.VesselTypeID;

                worksheet.Cells[2, 2].Value                      =   "Main Engine";
                worksheet.Cells[2, 2].Style.Font.Bold            =   true;
                worksheet.Cells[2, 2].Style.HorizontalAlignment  =   ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 2, 2, 3].Merge                =   true;

                worksheet.Cells[2, 4].Value                      =   "Auxiliary Engine";
                worksheet.Cells[2, 4].Style.Font.Bold            =   true;
                worksheet.Cells[2, 4].Style.HorizontalAlignment  =   ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 4, 2, 5].Merge                =   true;

                worksheet.Cells[3, 1].Value  =   "Results Shown Per Trip";
                worksheet.Cells[3, 2].Value  =   "Well To Pump";
                worksheet.Cells[3, 3].Value  =   "Vessel Operation";
                worksheet.Cells[3, 4].Value  =   "Well To Pump";
                worksheet.Cells[3, 5].Value  =   "Vessel Operation";
                worksheet.Cells[3, 6].Value  =   "Total";

                worksheet.Cells["A3:F3"].Style.HorizontalAlignment   =   ExcelHorizontalAlignment.Center;
                worksheet.Cells["A3:F3"].Style.Border.Bottom.Style   =   ExcelBorderStyle.Thin;

                // Add the data

                worksheet.Cells[4, 1].Value  =   "Total Energy";
                worksheet.Cells[4, 2].Value  =   TE_WTP;
                worksheet.Cells[4, 3].Value  =   TE_VO;
                worksheet.Cells[4, 4].Value  =   AUX_TE_WTP;
                worksheet.Cells[4, 5].Value  =   AUX_TE_VO;
                worksheet.Cells[4, 6].Value  =   TE_Total;

                // TODO: Implement Fossil Fuel
                // worksheet.Cells[5, 1].Value = "Fossil Fuel";
                worksheet.Cells[5, 2].Value  =   FF_WTP;
                worksheet.Cells[5, 4].Value  =   AUX_FF_WTP;
                worksheet.Cells[5, 6].Value  =   FF_Total;
                
                // TODO: Implement Petroleum Fuel
                // worksheet.Cells[6, 1].Value = "Petroleum Fuel";
                worksheet.Cells[6, 2].Value  =   PF_WTP;
                worksheet.Cells[6, 4].Value  =   AUX_PF_WTP;
                worksheet.Cells[6, 6].Value  =   PF_Total;

                worksheet.Cells[9, 1].Value  =   "Emissions";

                worksheet.Cells[10, 1].Value     =   "VOC";
                worksheet.Cells[10, 2].Value     =   VOC_WTP;
                worksheet.Cells[10, 3].Value     =   VOC_VO;
                worksheet.Cells[10, 4].Value     =   AUX_VOC_WTP;
                worksheet.Cells[10, 5].Value     =   AUX_VOC_VO;
                worksheet.Cells[10, 6].Value     =   VOC_Total;

                worksheet.Cells[11, 1].Value     =   "CO";
                worksheet.Cells[11, 2].Value     =   CO_WTP;
                worksheet.Cells[11, 3].Value     =   CO_VO;
                worksheet.Cells[11, 4].Value     =   AUX_CO_WTP;
                worksheet.Cells[11, 5].Value     =   AUX_CO_VO;
                worksheet.Cells[11, 6].Value     =   CO_Total;

                worksheet.Cells[12, 1].Value     =   "NOx";
                worksheet.Cells[12, 2].Value     =   NOx_WTP;
                worksheet.Cells[12, 3].Value     =   NOx_VO;
                worksheet.Cells[12, 4].Value     =   AUX_NOx_WTP;
                worksheet.Cells[12, 5].Value     =   AUX_NOx_VO;
                worksheet.Cells[12, 6].Value     =   NOx_Total;

                worksheet.Cells[13, 1].Value     =   "PM10";
                worksheet.Cells[13, 2].Value     =   PM10_WTP;
                worksheet.Cells[13, 3].Value     =   PM10_VO;
                worksheet.Cells[13, 4].Value     =   AUX_PM10_WTP;
                worksheet.Cells[13, 5].Value     =   AUX_PM10_VO;
                worksheet.Cells[13, 6].Value     =   PM10_Total;

                worksheet.Cells[14, 1].Value     =   "PM 2.5";
                worksheet.Cells[14, 2].Value     =   PM25_WTP;
                worksheet.Cells[14, 3].Value     =   PM25_VO;
                worksheet.Cells[14, 4].Value     =   AUX_PM25_WTP;
                worksheet.Cells[14, 5].Value     =   AUX_PM25_VO;
                worksheet.Cells[14, 6].Value     =   PM25_Total;

                worksheet.Cells[15, 1].Value     =   "SOx";
                worksheet.Cells[15, 2].Value     =   SOx_WTP;
                worksheet.Cells[15, 3].Value     =   SOx_VO;
                worksheet.Cells[15, 4].Value     =   AUX_SOx_WTP;
                worksheet.Cells[15, 5].Value     =   AUX_SOx_VO;
                worksheet.Cells[15, 6].Value     =   SOx_Total;

                worksheet.Cells[16, 1].Value     =   "CH4";
                worksheet.Cells[16, 2].Value     =   CH4_WTP;
                worksheet.Cells[16, 3].Value     =   CH4_VO;
                worksheet.Cells[16, 4].Value     =   AUX_CH4_WTP;
                worksheet.Cells[16, 5].Value     =   AUX_CH4_VO;
                worksheet.Cells[16, 6].Value     =   CH4_Total;

                worksheet.Cells[17, 1].Value     =   "CO2";
                worksheet.Cells[17, 2].Value     =   CO2_WTP;
                worksheet.Cells[17, 3].Value     =   CO2_VO;
                worksheet.Cells[17, 4].Value     =   AUX_CO2_WTP;
                worksheet.Cells[17, 5].Value     =   AUX_CO2_VO;
                worksheet.Cells[17, 6].Value     =   CO2_Total;

                worksheet.Cells[18, 1].Value     =   "N2O";
                worksheet.Cells[18, 2].Value     =   N2O_WTP;
                worksheet.Cells[18, 3].Value     =   N2O_VO;
                worksheet.Cells[18, 4].Value     =   AUX_N2O_WTP;
                worksheet.Cells[18, 5].Value     =   AUX_N2O_VO;
                worksheet.Cells[18, 6].Value     =   N2O_Total;

                worksheet.Cells[20, 1].Value             =   "Main Engine Fuel Type:";
                worksheet.Cells[20, 1].Style.Font.Bold   =   true;
                worksheet.Cells[20, 2].Value             =   fuelUsed;

                worksheet.Cells[21, 1].Value             =   "Auxiliary Engine Fuel Type:";
                worksheet.Cells[21, 1].Style.Font.Bold   =   true;
                worksheet.Cells[21, 2].Value             =   auxFuelUsed;

                // Resize the columns to fit the values
                worksheet.Cells["A1:F22"].AutoFitColumns();

                // Save the file
                package.Save();

                MessageBox.Show("Excel spreadsheet saved successfully.", "File Saved");
            }

            
        }
        #endregion

        // Reset button puts everything back to the original default
        private void ResetButton_Click(object sender, EventArgs e)
        {
            DialogResult result     =   MessageBox.Show("Are you sure you wish to reset the form?", "Reset Results", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                GREETFormattedResults newWindow     =   new GREETFormattedResults(te);
                newWindow.Show();
            }

        }

    }
}