using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PlugInsInterfaces.DataTypes.Resource;
using PlugInsInterfaces.DataTypes;
using PlugInsInterfaces.DataTypes.Pathway;
using PlugInsInterfaces.DataTypes.Mix;
using PlugInsInterfaces.ResultTypes;
using TEAMSModule;

namespace WindowsApplication1
{
    public partial class TEAMS : Form
    {
        //Input Variables
        #region Teams 1.1 - 1.2
        //1.1
        public double EfficiencyForPetroleumRecovery;

        //1.2 (SL = Sulfur Level, RE = Refining Efficiency in %)
        public int ConventionalDieselSL;
        public double ConventionalDieselRE;
        public int LowSulfurDiesellSL;
        public double LowSulfurDieselRE;
        public int CrudeOilSL;
        public int ResidualOilSL;
        public double ResidualOilRE;
        #endregion
        #region Teams 2.1 - 2.5
        //2.1 (FS = Feedstock Source PDNG = Plant Design When Natural Gas is Feedstock PDFG = Plant Design When Flared Gas is Feedstock)
        //Feedstocks 1 = North American Natural Gas 2 = Non North American Natural Gas
        //Plant Designs 0 = No Co-Products 1 = Steam Co-Products 2 = Electricity Co-Products
        public int CompressedNaturalGasFS = 1;
        public int LiquifiedNaturalGasFS = 1;
        public int FistcherTropschDieselFS = 1;
        public int FischerTropschDieselPDNG;
        public int FischerTopschDieselPDFG;
        public int NANGSteamProductionCredit;
        public int NNANGSteamProductionCredit;
        public int NNAFGSteamProductionCredit;

        //2.2 (NG = Natural Gas FG = Flared Gas, values are being given as percent shares of energy feedstock EFP = Energy Feedstock Percentage)
        public double LiquifiedNaturalGasNGEFP;
        public double LiquifiedNaturalGasFGEFP;
        public double FischerTropschDieselNGEFP;
        public double FischerTropschDieselFGEFP;

        //2.3 Boiling ff Effects PP = Storage At Production Plant TPB = Transportation From Plant To Bulk Terminal BS = Bulk Terminal Storage DBR = Distribution From Bulk Terminal to Refueling Station RSCP = Refueling Station Storage for Central Plant
        //BoilingOffRatePerDay is a percentage, as is RateOfBoilingGasRecovered
        public double BoilingOffRatePerDayPP;
        public double BoilingOffRatePerDayTPB;
        public double BoilingOffRatePerDayBS;
        public double BoilingOffRatePerDayDBR;
        public double BoilingOffRatePerDayRSCP;
        public double DurationOfStageDaysPP;
        public double DurationOfStageDaysTPB;
        public double DurationOfStageDaysBS;
        public double DurationOfStageDaysDBR;
        public double DurationOfStageDaysRSCP;
        public double RateOfBoilingGasRecoveredPP;
        public double RateOfBoilingGasRecoveredTPB;
        public double RateOfBoilingGasRecoveredBS;
        public double RateOfBoilingGasRecoveredDBR;
        public double RateOfBoilingGasRecoveredRSCP;

        //2.4 Transportation Distances of Moving Feedstock or Fuel: In Miles(One Way Distance)
        //Petroleum based
        //CO = Crude Oil RO = Residual Oil USD = US Diesel USLSD = US Low Sulfur Diesel
        public int OceanTankerCO;
        public int OceanTankerRO;
        public int OceanTankerUSD;
        public int OceanTankerUSLSD;
        public int BargeCO;
        public int BargeRO;
        public int BargeUSD;
        public int BargeUSLSD;
        public int PipelineCO;
        public int PipelineRO;
        public int PipelineUSD;
        public int PipelineUSLSD;
        public int RailCO;
        public int RailRO;
        public int RailUSD;
        public int RailUSLSD;
        public int TruckCO;
        public int TruckRO;
        public int TruckUSD;
        public int TruckUSLSD;
        //Natural Gas Based
        //NA = North American Natural Gas //NNA = Non North American Natural Gas
        public int OceanTankerNA;
        public int OceanTankerNNA;
        public int BargeNA;
        public int BargeNNA;
        public int PipelineNA;
        public int PipelineNNA;
        public int RailNA;
        public int RailNNA;
        public int TruckNA;
        public int TruckNNA;
        //Fischer Tropsch Diesel Based
        //NAFTD = North American Natural Gas for Fischer Tropsch Diesel NNAFTD = Non North American Natural Gas for Fischer Tropsch Diesel NNAFGFTD = Non North American Flared Gas for Fischer Tropsch Diesel
        public int OceanTankerNAFTD;
        public int OceanTankerNNAFTD;
        public int OceanTankerNNAFGFTD;
        public int BargeNAFTD;
        public int BargeNNAFTD;
        public int BargeNNAFGFTD;
        public int PipelineNAFTD;
        public int PipelineNNAFTD;
        public int PipelineNNAFGFTD;
        public int RailNAFTD;
        public int RailNNAFTD;
        public int RailNNAFGFTD;
        public int TruckNAFTD;
        public int TruckNNAFTD;
        public int TruckNNAFGFTD;
        //BioDiesel based
        //AGC = Ag Chemicals SB = Soybeans BD = Biodiesel
        public int BargeAGC;
        public int BargeSB;
        public int BargeBD;
        public int PipelineAGC;
        public int PipelineSB;
        public int PipelineBD;
        public int RailAGC;
        public int RailSB;
        public int RailBD;
        public int TruckTransitAGC;
        public int TruckTransitSB;
        public int TruckTransitBD;
        public int TruckDistributionAGC;
        public int TruckDistributionSB;
        public int TruckDistributionBD;
        //Electricity Based
        //UO = Uranium Ore EU = Enriched Uranium
        public int OceanTankerCoal;
        public int OceanTankerUO;
        public int OceanTankerEU;
        public int BargeCoal;
        public int BargeUO;
        public int BargeEU;
        public int PipelineCoal;
        public int PipelineUO;
        public int PipelineEU;
        public int RailCoal;
        public int RailUO;
        public int RailEU;
        public int TruckCoal;
        public int TruckUO;
        public int TruckEU;

        //2.5 Distance From Gas Fields to Production plants: Miles
        //These are in miles, and describe what the useage of NG or the production of Transportation Fuels is
        public int NGStationaryCombustion;
        public int LiquifiedNaturalGasPlant;
        public int FTDieselPlant;
        public int NGElectricPowerPlant;
        public int RefuelingStationUseofNorthAmericanNaturalGasForCNG;
        public int RefuelingStationUseOfNonNorthAmericanNaturalGasForCNG;

        #endregion
        #region Teams 3
        //3 Simulation of Biodiesel: Allocation of Upstream Energy Use and Emissions Between Biodiesel and Co-Products
        //SD = Soydiesel CP = Co-Products
        public double SoybeanFarmingSD;
        public double SoybeanFarmingCP;
        public double SoyoilExtractionSD;
        public double SoyoilExtractionCP;
        public double SoyoilTransestrificationSD;
        public double SoyoilTransestrificationCP;
        #endregion
        #region Teams 4.1 - 4.2
        //4.1 Selection of Model Calculated or user-Input Emission Factors for Power Plants
        //1 = Model Calculated Emissions Factors 2 = user Input Emissions Factors
        public int SelectionOfModelCalculatedOrUserInput = 1;

        //4.2 Electricity Generation Mix
        //USAM = US Average Mis in percent
        public double ResidualOilUSAM;
        public double NaturalGasUSAM;
        public double CoalUSAM;
        public double NuclearPowerUSAM;
        public double BiomassAndOtherUSAM;
        #endregion
        #region Teams 5.1 - 5.4d
        //5.1 Main Engine Variables
        public string VesselTypeID;
        public int NumberOfEngines;
        public int SingleEngineHP;
        public int TotalOnboardHP;
        //Constants (These are units of measurement)
        public double KWperHP;
        public double GALperBBL;
        public double BBLperTONNE;
        public double BTUperKWH;

        //5.2 Trip Distance and Time
        public double TotalTripDistanceInMiles;
        public double TripTimeHours;
        public double TripTimeMinutes;
        public double TotalTripTimeHours;

        //5.3 Engine Charicterization Per Mode
        //POT - Percent Of Trip, Time in mode is measured in hours HPLF - Horse Power Load Factor (Single engine). HPPE = Horse Power Per Engine EP = Energy Production in KWH for all engines
        public double POTIdle;
        public double POTManeuvering;
        public double POTPrecautionary;
        public double POTSlowCruise;
        public double POTFullCruise;
        public double TimeInIdle;
        public double TimeInManeuvering;
        public double TimeInPrecautionary;
        public double TimeInSlowCruise;
        public double TimeInFullCruise;
        public double HPLFIdle;
        public double HPLFManeuvering;
        public double HPLFPrecautionary;
        public double HPLFSlowCruise;
        public double HPLFFullCruise;
        public double HPPEIdle;
        public double HPPEManeuvering;
        public double HPPEPrecautionary;
        public double HPPESlowCruise;
        public double HPPEFullCruise;
        public double EPIdle;
        public double EPManeuvering;
        public double EPPrecautionary;
        public double EPSlowCruise;
        public double EPFullCruise;
        public double EPTotal;

        //5.4a Selection of Model Calculated or User Input Fuel Consumption Values (Conventional Diesel as Baseline Fuel)
        //1 = Simulate using GPH derived from user-entered engine specifications 2 = Simulate using User - Entered GPH
        public int SelectionOfModelCalculatedOrUserInputFuelConsumptionValues;

        //5.4b Calculation of Fuel Use Using Conventional Diesel as Baseline Fuel
        public double EngineEfficiency;
        public double KWHOutperTrip;
        public double MMBTUoutperTrip;
        public double MMBTUinperTrip;
        public double GALLONperTrip;

        //5.4c Calculation of Fuel Use Using Alternative Fuels (Conventional Diesel as Baseline Fuel)
        //EE = Engine Efficiency in percent MMBTU = million BTUs in per trip AFC = alternative Fuel Consumption in Gallons per trip
        public double ResidualOilEE;
        public double ResidualOilMMBTU;
        public double ResidualOilAFC;
        public double LowSulfurDieselEE;
        public double LowSulfurDieselMMBTU;
        public double LowSulfurDieselAFC;
        public double NaturalGasEE;
        public double NaturalGasMMBTU;
        public double NaturalGasAFC;
        public double BiodieselEE;
        public double BiodieselMMBTU;
        public double BiodieselAFC;
        public double FischerTropschEE;
        public double FischerTropschMMBTU;
        public double FischerTropschAFC;

        //5.4d Fuel Consumption (Only needed if you are simulating using user - entered GPH) Total is in Gallons/Trip
        public int ConventionalDieselIdle;
        public int ConventionalDieselManeuvering;
        public int ConventionalDieselPrecautionary;
        public int ConventionalDieselSlowCruise;
        public int ConventionalDieselFullCruise;
        public int ConventionalDieselTotal;
        public int ResidualOilIdle;
        public int ResidualOilManeuvering;
        public int ResidualOilPrecautionary;
        public int ResidualOilSlowCruise;
        public int ResidualOilFullCruise;
        public int ResidualOilTotal;
        public int LowSulfurDieselIdle;
        public int LowSulfurDieselManeuvering;
        public int LowSulfurDieselPrecautionary;
        public int LowSulfurDieselSlowCruise;
        public int LowSulfurDieselFullCruise;
        public int LowSulfurDieselTotal;
        public int NaturalGasIdle;
        public int NaturalGasManeuvering;
        public int NaturalGasPrecautionary;
        public int NaturalGasSlowCruise;
        public int NaturalGasFullCruise;
        public int NaturalGasTotal;
        public int BioDieselIdle;
        public int BioDieselManeuvering;
        public int BioDieselPrecautionary;
        public int BioDieselSlowCruise;
        public int BioDieselFullCruise;
        public int BioDieselTotal;
        public int FischerTropschIdle;
        public int FischerTropschManeuvering;
        public int FischerTropschPrecautionary;
        public int FischerTropschSlowCruise;
        public int FischerTropschFullCruise;
        public int FischerTropschTotal;

        #endregion
        #region Teams 6.1 - 6.4d
        //6.1 Auxillary Engine Fuel Type to Present On Results Sheet;
        //1 = Conventional Diesel 2 = Residual Oil 3 = Low Sulfur Diesel 4 = Natural gas 5 = Biodiesel 6 = Fischer Tropsch Diesel
        public int AuxillaryEngineFuelType = 1;

        //6.2 Auxillary Engine Variables
        public int NumberOfOnBoarAuxillaryEngines;
        public int NumberOfAuxillaryEnginesInUse;
        public int AuxillaryEnginesRatedHPperEngine;
        public int TotalOnboardAUxHP;

        //6.3 Auxillary Engine Characterization (Conventional Diesel as Baseline Fuel)
        public double PercentOfTripAuxillaryIsActive;
        public double TimeAuxActiveHours;
        public double HPLoadFactorSingleEngine;
        public double ActiveHPPerAuxEngine;
        public double TotalAuxEnergyProduction;

        //6.4a Selection of Medel Calculated or User Input Fuel Consumption Values Conventional Diesel as Baseline Fuel
        //1 = Simlate using GPH derived from User-Entered Auxillary engine specifications 2 = Simlate using user entered GPH
        public int SelectionOfModelCalculatedOrUserInputFuelConsumptionValues6 = 1;

        //6.4b Calculation of Auxillary Engine Fuel use Using Conventional Diesel as Baseline Fuel
        public double AuxillaryEngineEfficiency;
        public double AuxEngineKWHoutperTrip;
        public double AuxEngineMMBTUoutperTrip;
        public double AuxEngineMMBTUinperTrip;
        public double AuxEngineGALLONperTrip;

        //6.4c Calculation of Auxillary Engine Fuel Use Using Alternative Fuels
        //EE = Engine Efficiency AuxMMBTU = Auxillary MMTBUin/Trip EAFC = Auxillary Engine Alternativee Fuel Consumption
        public double AuxResidualOilEE;
        public double AuxResidualOilMMBTU;
        public double AuxResidualOilEAFC;
        public double AuxLowSulfurDieselEE;
        public double AuxLowSulfurDieselMMBTU;
        public double AuxLowSulfurDieselEAFC;
        public double AuxNaturalGasEE;
        public double AuxNaturalGasMMBTU;
        public double AuxNaturalGasEAFC;
        public double AuxBiodieselEE;
        public double AuxBiodieselMMBTU;
        public double AuxBiodieselEAFC;
        public double AuxFischerTropschEE;
        public double AuxFischerTropschMMBTU;
        public double AuxFischerTropschEAFC;

        //6.4d  Auxillary Engine Fuel Consumption (Only if you're using user entered GPH for your simulation
        //FC = Fuel Consumption 
        public int AuxConventionalDieselFC;
        public double AuxConventionalDieselTotal;
        public int AuxResidualOilFC;
        public double AuxResidualOilTotal;
        public int AuxLowSulfurDieselFC;
        public double AuxLowSulfurDieselTotal;
        public int AuxNaturalGasFC;
        public double AuxNaturalGasTotal;
        public int AuxBiodieselFC;
        public double AuxBioDieselTotal;
        public int AuxFischerTropschFC;
        public double AuxFischerTropschTotal;
        #endregion
        #region Teams 7.2 - 7.2
        //7.1 Share of an Alternative Fuel in an Alternative Fuel Bleng Volumetric Percentage
        public double VolumetricPercentageOfFTDieselinFTDBlend;
        public double VolumetricPercentageOfBiodieselInBiodieselBlend;

        //7.2 Type of Diesel for Alternative Fuel Blends
        //1 = Conventional Diesel 2 = Low Sulfur Diesel
        public int DieselForFischerTropschBlend = 1;
        public int DieselForBiodieselBlend = 1;
        #endregion

        //Program Variables
        public bool one_complete;
        public bool two_complete;
        public bool three_complete;
        public bool four_complete;
        public bool five_complete;
        public bool six_complete;
        public bool seven_complete;
        public bool runSimActive;
        #region Greet Variables
        //GREET Variables
        //btu/Gal
        public double crudeOilBTUperGal;
        public double conventionalDieselBTUperGal;
        public double lowSulfurDieselBTUperGal;
        public double liquifiedPetroleumGasBTUperGal;
        public double residualOilBTUperGal;
        public double liquifiedNaturalGasBTUperGal;
        public double bioDieselBTUperGal;
        public double fischerTropschBTUperGal;

        public double natGasBTUperSCF;

        public double coalBTuperTON;
        //Grams/Gal
        public double crudeOilDensity;
        public double conventionalDieselDensity;
        public double lowSulfurDieselDensity;
        public double liquifiedPetroleumGasDensity;
        public double residualOilDensity;
        public double liquifiedNaturalGasDensity;
        public double bioDieselDensity;
        public double fischerTropschDensity;

        public double natGasGramsperSCF;

        //Carbon % by wt
        public double crudeOilCarbonRatio;
        public double conventionalDieselCarbonRatio;
        public double lowSulfurDieselCarbonRatio;
        public double liquifiedPetroleumGasCarbonRatio;
        public double residualOilCarbonRatio;
        public double liquifiedNaturalGasCarbonRatio;
        public double bioDieselCarbonRatio;
        public double fischerTropschCarbonRatio;
        public double natGasCarbonRatio;
        public double coalCarbonRatio;

        //These are ratios that are ppm by wt
        public double crudeOilSulfurRatio;
        public double conventionalDieselSulfurRatio;
        public double lowSulfurDieselSulfurRatio;
        public double liquifiedPetroleumGasSulfurRatio;
        public double residualOilSulfurRatio;
        public double liquifiedNaturalGasSulfurRatio;
        public double bioDieselSulfurRatio;
        public double fischerTropschSulfurRatio;
        public double natGasSulfurRatio;
        public double coalSulfurRatio;

        //These are ratios that are actual ration by wt
        public double crudeOilSulfurRatioActual;
        public double conventionalDieselSulfurRatioActual;
        public double lowSulfurDieselSulfurRatioActual;
        public double liquifiedPetroleumGasSulfurRatioActual;
        public double residualOilSulfurRatioActual;
        public double liquifiedNaturalGasSulfurRatioActual;
        public double bioDieselSulfurRatioActual;
        public double fischerTropschSulfurRatioActual;
        public double natGasSulfurRatioActual;
        public double coalSulfurRatioActual;

        public int GHPCO2 = 1;
        public int GHPCH4 = 23;
        public int GHPN2O = 296;
        public int GHPVOC = 0;
        public int GHPCO = 0;
        public int GHPNO2 = 0;

        public double CarbonRatioVOC = 85.0;
        public double CarbonRatioCO = 43.0;
        public double CarbonRatioCH4 = 75.0;
        public double CarbonRatioCO2 = 27.0;
        public double CarbonRatioSO2 = 50.0;
	


        #endregion

        public string openedFile;

        public bool advanced;

        public const int CRUDE_PATH_ID = 34;
        public const int CD_PATH_ID = 40;
        public const int LSD_PATH_ID = 61;
        public const int LIQ_PETROL_PATH_ID = 20;
        public const int RO_PATH_ID = 60;
        public const int LIQ_NATGAS_PATH_ID = 150000;
        public const int BIODIESEL_PATH_ID = 2020;
        public const int FTD_PATH_ID = 75;
        public const int NATGAS_PATH_ID = 1;
        public const int COAL_PATH_ID = 17;

        public Update u;
        public Fuel_Specs GVE;
        public ResultsSheet rs;
        public TEAMS()
        {
            InitializeComponent();
            pullFromGREET();
            useDefaults();
            changeResults();
            GVE = new Fuel_Specs(this);
            u = new Update(this);
        }
        public void pullFromGREET()
        {
            IGDataDictionary<int, IResource> resources = ResultsAccess.controler.CurrentProject.Data.Resources;
            IGDataDictionary<int, IPathway> pathways = ResultsAccess.controler.CurrentProject.Data.Pathways;
            IGDataDictionary<int, IMix> mixes = ResultsAccess.controler.CurrentProject.Data.Mixes;
            //These are the Fuel_Specs information being replicated as needed
            if (advanced == false)
            {
                #region Liquid Fuels
                // Grab the pathway from greet for the resource you are looking for.
                //IPathway myPathway = pathways.ValueForKey((int)numericUpDown264.Value);
                IPathway myPathway = pathways.ValueForKey(CRUDE_PATH_ID);
                // Grab the int id for the resource (the water)
                int productID = myPathway.MainOutputResourceID;
                IResource CrudeOil = resources.ValueForKey(productID);

                //This converts it to the preferred units, which in this case is grams/gal
                crudeOilDensity = (CrudeOil.Density.GreetValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                crudeOilBTUperGal = CrudeOil.LowerHeatingValue.GreetValue * (3.5878781 / 1000000);
                crudeOilCarbonRatio = CrudeOil.CarbonRatio.GreetValue;
                crudeOilSulfurRatio = CrudeOil.SulfurRatio.GreetValue * 1000000;
                crudeOilSulfurRatioActual = CrudeOil.SulfurRatio.GreetValue;
                //this.label251.Text = CrudeOil.Name + " Sulfur Ratio " + crudeOilSulfurRatio;

                //This is where you do the above process, but for conventional diesel
                myPathway = pathways.ValueForKey(CD_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource ConvDiesel = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                conventionalDieselDensity = (ConvDiesel.Density.GreetValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                conventionalDieselBTUperGal = ConvDiesel.LowerHeatingValue.GreetValue * (3.5878781 / 1000000);
                conventionalDieselCarbonRatio = ConvDiesel.CarbonRatio.GreetValue;
                conventionalDieselSulfurRatio = ConvDiesel.SulfurRatio.GreetValue * 1000000;
                conventionalDieselSulfurRatioActual = ConvDiesel.SulfurRatio.GreetValue;
                // this.label258.Text = ConvDiesel.Name + " Energy Value " + conventionalDieselBTUperGal + " Btu/Gal " + " Density: " + conventionalDieselDensity + " grams/gallon CR " + ConvDiesel.CarbonRatio.GreetValue;

                //This is where you do the above process, but for low sulfur diesel
                myPathway = pathways.ValueForKey(LSD_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource LSDiesel = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                lowSulfurDieselDensity = (LSDiesel.Density.GreetValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                lowSulfurDieselBTUperGal = LSDiesel.LowerHeatingValue.GreetValue * (3.5878781 / 1000000);
                lowSulfurDieselCarbonRatio = LSDiesel.CarbonRatio.GreetValue;
                lowSulfurDieselSulfurRatio = LSDiesel.SulfurRatio.GreetValue * 1000000;
                lowSulfurDieselSulfurRatioActual = LSDiesel.SulfurRatio.GreetValue;

                //This is where you do the above process, but for liquified petroleum gas
                myPathway = pathways.ValueForKey(LIQ_PETROL_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource LPG = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                liquifiedPetroleumGasDensity = (LPG.Density.GreetValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                liquifiedPetroleumGasBTUperGal = LPG.LowerHeatingValue.GreetValue * (3.5878781 / 1000000);
                liquifiedPetroleumGasCarbonRatio = LPG.CarbonRatio.GreetValue;
                liquifiedPetroleumGasSulfurRatio = LPG.SulfurRatio.GreetValue * 1000000;
                liquifiedPetroleumGasSulfurRatioActual = LPG.SulfurRatio.GreetValue;

                //This is where you do the above process, but for residual oil
                myPathway = pathways.ValueForKey(RO_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource RO = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                residualOilDensity = (RO.Density.GreetValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                residualOilBTUperGal = RO.LowerHeatingValue.GreetValue * (3.5878781 / 1000000);
                residualOilCarbonRatio = RO.CarbonRatio.GreetValue;
                residualOilSulfurRatio = RO.SulfurRatio.GreetValue * 1000000;
                residualOilSulfurRatioActual = RO.SulfurRatio.GreetValue;

                //This is where you do the above process, but for liquified natural gas
                myPathway = pathways.ValueForKey(LIQ_NATGAS_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource LNG = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                liquifiedNaturalGasDensity = (LNG.Density.GreetValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                liquifiedNaturalGasBTUperGal = LNG.LowerHeatingValue.GreetValue * (3.5878781 / 1000000);
                liquifiedNaturalGasCarbonRatio = LNG.CarbonRatio.GreetValue;
                liquifiedNaturalGasSulfurRatio = LNG.SulfurRatio.GreetValue * 1000000;
                liquifiedNaturalGasSulfurRatioActual = LNG.SulfurRatio.GreetValue;

                //This is where you do the above process, but for biodiesel
                myPathway = pathways.ValueForKey(BIODIESEL_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource BD = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                bioDieselDensity = (BD.Density.GreetValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                bioDieselBTUperGal = BD.LowerHeatingValue.GreetValue * (3.5878781 / 1000000);
                bioDieselCarbonRatio = BD.CarbonRatio.GreetValue;
                bioDieselSulfurRatio = BD.SulfurRatio.GreetValue * 1000000;
                bioDieselSulfurRatioActual = BD.SulfurRatio.GreetValue;

                //This is where you do the above process, but for fischer tropsch diesel
                myPathway = pathways.ValueForKey(FTD_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource FTD = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                fischerTropschDensity = (FTD.Density.GreetValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                fischerTropschBTUperGal = FTD.LowerHeatingValue.GreetValue * (3.5878781 / 1000000);
                fischerTropschCarbonRatio = FTD.CarbonRatio.GreetValue;
                fischerTropschSulfurRatio = FTD.SulfurRatio.GreetValue * 1000000;
                fischerTropschSulfurRatioActual = FTD.SulfurRatio.GreetValue;
                #endregion
                #region Solid and Gaseous Fuels
                //This is where you do the above process, but for Gaseous Natural Gas
                myPathway = pathways.ValueForKey(NATGAS_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource NG = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/Standard cubic foot
                natGasGramsperSCF = NG.Density.GreetValue / 0.0353146667;
                //This converts it to the preferred units, which in this case is btu/SCF (Standard cubic feet)
                natGasBTUperSCF = NG.LowerHeatingValue.GreetValue / 37258.7438641;
                natGasCarbonRatio = NG.CarbonRatio.GreetValue;
                natGasSulfurRatio = NG.SulfurRatio.GreetValue * 1000000;
                natGasSulfurRatioActual = NG.SulfurRatio.GreetValue;

                //This is where you do the above process, but for Gaseous Natural Gas
                myPathway = pathways.ValueForKey(COAL_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource Coal = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is btu/SCF (Standard cubic feet)
                coalBTuperTON = Coal.LowerHeatingValue.GreetValue / 1.15870823646;
                coalCarbonRatio = Coal.CarbonRatio.GreetValue;
                coalSulfurRatio = Coal.SulfurRatio.GreetValue * 1000000;
                coalSulfurRatioActual = Coal.SulfurRatio.GreetValue;
                //label251.Text = coalBTuperTON.ToString();
                #endregion
            }
            else if (advanced == true)
            {
                //This is the same as above, but it only pulls the user values, and not the GREET ones
                #region Liquid Fuels
                // Grab the pathway from greet for the resource you are looking for.
                //IPathway myPathway = pathways.ValueForKey((int)numericUpDown264.Value);
                IPathway myPathway = pathways.ValueForKey(CRUDE_PATH_ID);
                // Grab the int id for the resource (the water)
                int productID = myPathway.MainOutputResourceID;
                IResource CrudeOil = resources.ValueForKey(productID);

                //This converts it to the preferred units, which in this case is grams/gal
                crudeOilDensity = (CrudeOil.Density.UserValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                crudeOilBTUperGal = CrudeOil.LowerHeatingValue.UserValue * (3.5878781 / 1000000);
                crudeOilCarbonRatio = CrudeOil.CarbonRatio.UserValue;
                crudeOilSulfurRatio = CrudeOil.SulfurRatio.UserValue * 1000000;
                crudeOilSulfurRatioActual = CrudeOil.SulfurRatio.UserValue;
                //this.label251.Text = CrudeOil.Name + " Sulfur Ratio " + crudeOilSulfurRatio;

                //This is where you do the above process, but for conventional diesel
                myPathway = pathways.ValueForKey(CD_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource ConvDiesel = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                conventionalDieselDensity = (ConvDiesel.Density.UserValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                conventionalDieselBTUperGal = ConvDiesel.LowerHeatingValue.UserValue * (3.5878781 / 1000000);
                conventionalDieselCarbonRatio = ConvDiesel.CarbonRatio.UserValue;
                conventionalDieselSulfurRatio = ConvDiesel.SulfurRatio.UserValue * 1000000;
                conventionalDieselSulfurRatioActual = ConvDiesel.SulfurRatio.UserValue;
                // this.label258.Text = ConvDiesel.Name + " Energy Value " + conventionalDieselBTUperGal + " Btu/Gal " + " Density: " + conventionalDieselDensity + " grams/gallon CR " + ConvDiesel.CarbonRatio.UserValue;

                //This is where you do the above process, but for low sulfur diesel
                myPathway = pathways.ValueForKey(LSD_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource LSDiesel = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                lowSulfurDieselDensity = (LSDiesel.Density.UserValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                lowSulfurDieselBTUperGal = LSDiesel.LowerHeatingValue.UserValue * (3.5878781 / 1000000);
                lowSulfurDieselCarbonRatio = LSDiesel.CarbonRatio.UserValue;
                lowSulfurDieselSulfurRatio = LSDiesel.SulfurRatio.UserValue * 1000000;
                lowSulfurDieselSulfurRatioActual = LSDiesel.SulfurRatio.UserValue;

                //This is where you do the above process, but for liquified petroleum gas
                myPathway = pathways.ValueForKey(LIQ_PETROL_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource LPG = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                liquifiedPetroleumGasDensity = (LPG.Density.UserValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                liquifiedPetroleumGasBTUperGal = LPG.LowerHeatingValue.UserValue * (3.5878781 / 1000000);
                liquifiedPetroleumGasCarbonRatio = LPG.CarbonRatio.UserValue;
                liquifiedPetroleumGasSulfurRatio = LPG.SulfurRatio.UserValue * 1000000;
                liquifiedPetroleumGasSulfurRatioActual = LPG.SulfurRatio.UserValue;

                //This is where you do the above process, but for residual oil
                myPathway = pathways.ValueForKey(RO_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource RO = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                residualOilDensity = (RO.Density.UserValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                residualOilBTUperGal = RO.LowerHeatingValue.UserValue * (3.5878781 / 1000000);
                residualOilCarbonRatio = RO.CarbonRatio.UserValue;
                residualOilSulfurRatio = RO.SulfurRatio.UserValue * 1000000;
                residualOilSulfurRatioActual = RO.SulfurRatio.UserValue;

                //This is where you do the above process, but for liquified natural gas
                myPathway = pathways.ValueForKey(LIQ_NATGAS_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource LNG = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                liquifiedNaturalGasDensity = (LNG.Density.UserValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                liquifiedNaturalGasBTUperGal = LNG.LowerHeatingValue.UserValue * (3.5878781 / 1000000);
                liquifiedNaturalGasCarbonRatio = LNG.CarbonRatio.UserValue;
                liquifiedNaturalGasSulfurRatio = LNG.SulfurRatio.UserValue * 1000000;
                liquifiedNaturalGasSulfurRatioActual = LNG.SulfurRatio.UserValue;

                //This is where you do the above process, but for biodiesel
                myPathway = pathways.ValueForKey(BIODIESEL_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource BD = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                bioDieselDensity = (BD.Density.UserValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                bioDieselBTUperGal = BD.LowerHeatingValue.UserValue * (3.5878781 / 1000000);
                bioDieselCarbonRatio = BD.CarbonRatio.UserValue;
                bioDieselSulfurRatio = BD.SulfurRatio.UserValue * 1000000;
                bioDieselSulfurRatioActual = BD.SulfurRatio.UserValue;

                //This is where you do the above process, but for fischer tropsch diesel
                myPathway = pathways.ValueForKey(FTD_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource FTD = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/gal
                fischerTropschDensity = (FTD.Density.UserValue * 3.78541178) / 1000;
                //This converts it to the preferred units, which in this case is btu/gal
                fischerTropschBTUperGal = FTD.LowerHeatingValue.UserValue * (3.5878781 / 1000000);
                fischerTropschCarbonRatio = FTD.CarbonRatio.UserValue;
                fischerTropschSulfurRatio = FTD.SulfurRatio.UserValue * 1000000;
                fischerTropschSulfurRatioActual = FTD.SulfurRatio.UserValue;
                #endregion
                #region Solid and Gaseous Fuels
                //This is where you do the above process, but for Gaseous Natural Gas
                myPathway = pathways.ValueForKey(NATGAS_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource NG = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is grams/Standard cubic foot
                natGasGramsperSCF = NG.Density.UserValue / 0.0353146667;
                //This converts it to the preferred units, which in this case is btu/SCF (Standard cubic feet)
                natGasBTUperSCF = NG.LowerHeatingValue.UserValue / 37258.7438641;
                natGasCarbonRatio = NG.CarbonRatio.UserValue;
                natGasSulfurRatio = NG.SulfurRatio.UserValue * 1000000;
                natGasSulfurRatioActual = NG.SulfurRatio.UserValue;

                //This is where you do the above process, but for Gaseous Natural Gas
                myPathway = pathways.ValueForKey(COAL_PATH_ID);
                // Grab the int id for the resource (the water)
                productID = myPathway.MainOutputResourceID;
                IResource Coal = resources.ValueForKey(productID);
                //This converts it to the preferred units, which in this case is btu/SCF (Standard cubic feet)
                coalBTuperTON = Coal.LowerHeatingValue.UserValue / 1.15870823646;
                coalCarbonRatio = Coal.CarbonRatio.UserValue;
                coalSulfurRatio = Coal.SulfurRatio.UserValue * 1000000;
                coalSulfurRatioActual = Coal.SulfurRatio.UserValue;
                //label251.Text = coalBTuperTON.ToString();
                #endregion
            }

        }
        public void submitAll()
        {
            object sender = new object();
            EventArgs e = new EventArgs();
            button1_Click_1(sender,e);
            button2_Click(sender, e);
            button3_Click(sender, e);
            button4_Click(sender, e);
            button5_Click(sender, e);
            button6_Click(sender, e);
            button7_Click(sender, e);
            changeResults();
        }

        #region This will recalculate every value that is determined by taking in other values and applying calculation
        public void doCalculations()
        {
            FischerTropschDieselFGEFP = 100.00 - FischerTropschDieselNGEFP;
            LiquifiedNaturalGasFGEFP = 100.00 - LiquifiedNaturalGasNGEFP;
            SoybeanFarmingCP = 100.00 - SoybeanFarmingSD;
            SoyoilExtractionCP = 100.00 - SoybeanFarmingSD;
            SoyoilTransestrificationCP = 100.00 - SoyoilTransestrificationSD;
            TotalOnboardHP = SingleEngineHP * NumberOfEngines;
            TotalTripTimeHours = TripTimeHours + (TripTimeMinutes / 60);
            TimeInIdle = (POTIdle / 100) * TotalTripTimeHours;
            TimeInManeuvering = (POTManeuvering / 100) * TotalTripTimeHours;
            TimeInPrecautionary = (POTPrecautionary / 100) * TotalTripTimeHours;
            TimeInSlowCruise = (POTSlowCruise / 100) * TotalTripTimeHours;
            TimeInFullCruise = (POTFullCruise / 100) * TotalTripTimeHours;
            HPPEIdle = (HPLFIdle / 100) * SingleEngineHP;
            HPPEManeuvering = (HPLFManeuvering / 100) * SingleEngineHP;
            HPPEPrecautionary = (HPLFPrecautionary / 100) * SingleEngineHP;
            HPPESlowCruise = (HPLFSlowCruise / 100) * SingleEngineHP;
            HPPEFullCruise = (HPLFFullCruise / 100) * SingleEngineHP;
            EPIdle = NumberOfEngines * HPPEIdle * TimeInIdle * KWperHP;
            EPManeuvering = NumberOfEngines * HPPEManeuvering * TimeInManeuvering * KWperHP;
            EPPrecautionary = NumberOfEngines * HPPEPrecautionary * TimeInPrecautionary * KWperHP;
            EPSlowCruise = NumberOfEngines * HPPESlowCruise * TimeInSlowCruise * KWperHP;
            EPFullCruise = NumberOfEngines * HPPEFullCruise * TimeInFullCruise * KWperHP;
            EPTotal = EPIdle + EPManeuvering + EPPrecautionary + EPSlowCruise + EPFullCruise;
            KWHOutperTrip = EPTotal;
            MMBTUoutperTrip = (KWHOutperTrip * BTUperKWH) / 1000000;
            MMBTUinperTrip = MMBTUoutperTrip * (100 / EngineEfficiency);
            GALLONperTrip = (1 / conventionalDieselBTUperGal) * 1000000 * MMBTUinperTrip;
            ResidualOilMMBTU = MMBTUoutperTrip * (100 / ResidualOilEE);
            LowSulfurDieselMMBTU = MMBTUoutperTrip * (100 / LowSulfurDieselEE);
            NaturalGasMMBTU = MMBTUoutperTrip * (100 / NaturalGasEE);
            BiodieselMMBTU = MMBTUoutperTrip * (100 / BiodieselEE);
            FischerTropschMMBTU = MMBTUoutperTrip * (100 / FischerTropschEE);
            ResidualOilAFC = GALLONperTrip = (1 / residualOilBTUperGal) * 1000000 * ResidualOilMMBTU;
            LowSulfurDieselAFC = (1 / lowSulfurDieselBTUperGal) * 1000000 * LowSulfurDieselMMBTU;
            NaturalGasAFC = (1 / natGasBTUperSCF) * 1000000 * NaturalGasMMBTU;
            BiodieselAFC = (1 / bioDieselBTUperGal) * 1000000 * BiodieselMMBTU;
            FischerTropschAFC = (1 / fischerTropschBTUperGal) * 1000000 * FischerTropschMMBTU;
            ConventionalDieselTotal = (int)((ConventionalDieselIdle * TimeInIdle * NumberOfEngines) + (ConventionalDieselManeuvering * TimeInManeuvering * NumberOfEngines) + (ConventionalDieselPrecautionary * TimeInPrecautionary * NumberOfEngines) + (ConventionalDieselSlowCruise * TimeInSlowCruise * NumberOfEngines) + (ConventionalDieselFullCruise * TimeInFullCruise * NumberOfEngines));
            ResidualOilTotal = (int)((ResidualOilIdle * TimeInIdle * NumberOfEngines) + (ResidualOilManeuvering * TimeInManeuvering * NumberOfEngines) + (ResidualOilPrecautionary * TimeInPrecautionary * NumberOfEngines) + (ResidualOilSlowCruise * TimeInSlowCruise * NumberOfEngines) + (ResidualOilFullCruise * TimeInFullCruise * NumberOfEngines));
            LowSulfurDieselTotal = (int)((LowSulfurDieselIdle * TimeInIdle * NumberOfEngines) + (LowSulfurDieselManeuvering * TimeInManeuvering * NumberOfEngines) + (LowSulfurDieselPrecautionary * TimeInPrecautionary * NumberOfEngines) + (LowSulfurDieselSlowCruise * TimeInSlowCruise * NumberOfEngines) + (LowSulfurDieselFullCruise * TimeInFullCruise * NumberOfEngines));
            NaturalGasTotal = (int)((NaturalGasIdle * TimeInIdle * NumberOfEngines) + (NaturalGasManeuvering * TimeInManeuvering * NumberOfEngines) + (NaturalGasPrecautionary * TimeInPrecautionary * NumberOfEngines) + (NaturalGasSlowCruise * TimeInSlowCruise * NumberOfEngines) + (NaturalGasFullCruise * TimeInFullCruise * NumberOfEngines));
            BioDieselTotal = (int)((BioDieselIdle * TimeInIdle * NumberOfEngines) + (BioDieselManeuvering * TimeInManeuvering * NumberOfEngines) + (BioDieselPrecautionary * TimeInPrecautionary * NumberOfEngines) + (BioDieselSlowCruise * TimeInSlowCruise * NumberOfEngines) + (BioDieselFullCruise * TimeInFullCruise * NumberOfEngines));
            FischerTropschTotal = (int)(( FischerTropschIdle * TimeInIdle * NumberOfEngines) + ( FischerTropschManeuvering * TimeInManeuvering * NumberOfEngines) + ( FischerTropschPrecautionary * TimeInPrecautionary * NumberOfEngines) + ( FischerTropschSlowCruise * TimeInSlowCruise * NumberOfEngines) + (FischerTropschFullCruise * TimeInFullCruise * NumberOfEngines));
            TotalOnboardAUxHP = NumberOfAuxillaryEnginesInUse * AuxillaryEnginesRatedHPperEngine;
            TimeAuxActiveHours = (PercentOfTripAuxillaryIsActive / 100) * TotalTripTimeHours;
            ActiveHPPerAuxEngine = (HPLoadFactorSingleEngine / 100) * AuxillaryEnginesRatedHPperEngine;
            TotalAuxEnergyProduction = NumberOfAuxillaryEnginesInUse * ActiveHPPerAuxEngine * TimeAuxActiveHours * KWperHP;
            AuxEngineKWHoutperTrip = TotalAuxEnergyProduction;
            AuxEngineMMBTUoutperTrip = (AuxEngineKWHoutperTrip * BTUperKWH) / 1000000;
            AuxEngineMMBTUinperTrip = AuxEngineMMBTUoutperTrip * (100 / AuxillaryEngineEfficiency);
            AuxEngineGALLONperTrip = (1 / conventionalDieselBTUperGal) * 1000000 * AuxEngineMMBTUinperTrip;
            AuxResidualOilEE = ResidualOilEE;
            AuxResidualOilMMBTU = AuxEngineMMBTUoutperTrip * (100 / AuxResidualOilEE);
            AuxLowSulfurDieselEE = LowSulfurDieselEE;
            AuxLowSulfurDieselMMBTU = AuxEngineMMBTUoutperTrip * (100 / AuxLowSulfurDieselEE);
            AuxNaturalGasEE = NaturalGasEE;
            AuxNaturalGasMMBTU = AuxEngineMMBTUoutperTrip * (100 / AuxNaturalGasEE);
            AuxBiodieselEE = BiodieselEE;
            AuxBiodieselMMBTU = AuxEngineMMBTUoutperTrip * (100 / AuxBiodieselEE);
            AuxFischerTropschEE = FischerTropschEE;
            AuxFischerTropschMMBTU = AuxEngineMMBTUoutperTrip * (100 / AuxFischerTropschEE);
            AuxResidualOilEAFC = (1 / residualOilBTUperGal) * 1000000 * AuxResidualOilMMBTU;
            AuxLowSulfurDieselEAFC = (1 / lowSulfurDieselBTUperGal) * 1000000 * AuxLowSulfurDieselMMBTU;
            AuxNaturalGasEAFC = (1 / natGasBTUperSCF) * 1000000 * AuxNaturalGasMMBTU;
            AuxBiodieselEAFC = (1 / bioDieselBTUperGal) * 1000000 * AuxBiodieselMMBTU;
            AuxFischerTropschEAFC = (1 / fischerTropschBTUperGal) * 1000000 * AuxFischerTropschMMBTU;
            AuxConventionalDieselTotal = AuxConventionalDieselFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
            AuxResidualOilTotal = AuxResidualOilFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
            AuxLowSulfurDieselTotal = AuxLowSulfurDieselFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
            AuxNaturalGasTotal = AuxNaturalGasFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
            AuxBioDieselTotal = AuxBiodieselFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
            AuxFischerTropschTotal = AuxFischerTropschFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
        }
        #endregion
        #region This will make it so that all the values shown are consistent with the code values of the variables
        public void changeResults()
        {
            //1
            numericUpDown1.Value = (decimal)EfficiencyForPetroleumRecovery;
            numericUpDown2.Value = (decimal)ConventionalDieselSL;
            numericUpDown3.Value = (decimal)ConventionalDieselRE;
            numericUpDown5.Value = (decimal)LowSulfurDiesellSL;
            numericUpDown4.Value = (decimal)LowSulfurDieselRE;
            numericUpDown7.Value = (decimal)CrudeOilSL;
            numericUpDown9.Value = (decimal)ResidualOilSL;
            numericUpDown8.Value = (decimal)ResidualOilRE;

            //2
            numericUpDown15.Value = (decimal)CompressedNaturalGasFS;
            numericUpDown6.Value = (decimal)LiquifiedNaturalGasFS;
            numericUpDown10.Value = (decimal)FistcherTropschDieselFS;
            numericUpDown11.Value = (decimal)FischerTropschDieselPDNG;
            numericUpDown12.Value = (decimal)FischerTopschDieselPDFG;
            numericUpDown13.Value = (decimal)NANGSteamProductionCredit;
            numericUpDown14.Value = (decimal)NNANGSteamProductionCredit;
            numericUpDown16.Value = (decimal)NNAFGSteamProductionCredit;
            numericUpDown17.Value = (decimal)LiquifiedNaturalGasNGEFP;
            numericUpDown18.Value = (decimal)FischerTropschDieselNGEFP;
            numericUpDown24.Value = (decimal)BoilingOffRatePerDayPP;
            numericUpDown22.Value = (decimal)BoilingOffRatePerDayTPB;
            numericUpDown26.Value = (decimal)BoilingOffRatePerDayBS;
            numericUpDown28.Value = (decimal)BoilingOffRatePerDayDBR;
            numericUpDown30.Value = (decimal)BoilingOffRatePerDayRSCP;
            numericUpDown23.Value = (decimal)DurationOfStageDaysPP;
            numericUpDown21.Value = (decimal)DurationOfStageDaysTPB;
            numericUpDown25.Value = (decimal)DurationOfStageDaysBS;
            numericUpDown27.Value = (decimal)DurationOfStageDaysDBR;
            numericUpDown29.Value = (decimal)DurationOfStageDaysRSCP;
            numericUpDown35.Value = (decimal)RateOfBoilingGasRecoveredPP;
            numericUpDown34.Value = (decimal)RateOfBoilingGasRecoveredTPB;
            numericUpDown33.Value = (decimal)RateOfBoilingGasRecoveredBS;
            numericUpDown32.Value = (decimal)RateOfBoilingGasRecoveredDBR;
            numericUpDown31.Value = (decimal)RateOfBoilingGasRecoveredRSCP;
            numericUpDown47.Value = (decimal)OceanTankerCO;
            numericUpDown45.Value = (decimal)OceanTankerRO;
            numericUpDown44.Value = (decimal)OceanTankerUSD;
            numericUpDown43.Value = (decimal)OceanTankerUSLSD;
            numericUpDown39.Value = (decimal)BargeCO;
            numericUpDown38.Value = (decimal)BargeRO;
            numericUpDown37.Value = (decimal)BargeUSD;
            numericUpDown36.Value = (decimal)BargeUSLSD;
            numericUpDown46.Value = (decimal)PipelineCO;
            numericUpDown42.Value = (decimal)PipelineRO;
            numericUpDown41.Value = (decimal)PipelineUSD;
            numericUpDown40.Value = (decimal)PipelineUSLSD;
            numericUpDown51.Value = (decimal)RailCO;
            numericUpDown50.Value = (decimal)RailRO;
            numericUpDown49.Value = (decimal)RailUSD;
            numericUpDown48.Value = (decimal)RailUSLSD;
            numericUpDown55.Value = (decimal)TruckCO;
            numericUpDown54.Value = (decimal)TruckRO;
            numericUpDown53.Value = (decimal)TruckUSD;
            numericUpDown52.Value = (decimal)TruckUSLSD;
            numericUpDown75.Value = (decimal)OceanTankerNA;
            numericUpDown74.Value = (decimal)OceanTankerNNA;
            numericUpDown71.Value = (decimal)BargeNA;
            numericUpDown70.Value = (decimal)BargeNNA;
            numericUpDown67.Value = (decimal)PipelineNA;
            numericUpDown66.Value = (decimal)PipelineNNA;
            numericUpDown63.Value = (decimal)RailNA;
            numericUpDown62.Value = (decimal)RailNNA;
            numericUpDown59.Value = (decimal)TruckNA;
            numericUpDown58.Value = (decimal)TruckNNA;
            numericUpDown95.Value = (decimal)OceanTankerNAFTD;
            numericUpDown94.Value = (decimal)OceanTankerNNAFTD;
            numericUpDown93.Value = (decimal)OceanTankerNNAFGFTD;
            numericUpDown91.Value = (decimal)BargeNAFTD;
            numericUpDown90.Value = (decimal)BargeNNAFTD;
            numericUpDown89.Value = (decimal)BargeNNAFGFTD;
            numericUpDown87.Value = (decimal)PipelineNAFTD;
            numericUpDown86.Value = (decimal)PipelineNNAFTD;
            numericUpDown85.Value = (decimal)PipelineNNAFGFTD;
            numericUpDown83.Value = (decimal)RailNAFTD;
            numericUpDown82.Value = (decimal)RailNNAFTD;
            numericUpDown81.Value = (decimal)RailNNAFGFTD;
            numericUpDown79.Value = (decimal)TruckNAFTD;
            numericUpDown78.Value = (decimal)TruckNNAFTD;
            numericUpDown77.Value = (decimal)TruckNNAFGFTD;
            numericUpDown111.Value = (decimal)BargeAGC;
            numericUpDown110.Value = (decimal)BargeSB;
            numericUpDown109.Value = (decimal)BargeBD;
            numericUpDown107.Value = (decimal)PipelineAGC;
            numericUpDown106.Value = (decimal)PipelineSB;
            numericUpDown105.Value = (decimal)PipelineBD;
            numericUpDown103.Value = (decimal)RailAGC;
            numericUpDown102.Value = (decimal)RailSB;
            numericUpDown101.Value = (decimal)RailBD;
            numericUpDown99.Value = (decimal)TruckTransitAGC;
            numericUpDown98.Value = (decimal)TruckTransitSB;
            numericUpDown97.Value = (decimal)TruckTransitBD;
            numericUpDown61.Value = (decimal)TruckDistributionAGC;
            numericUpDown60.Value = (decimal)TruckDistributionSB;
            numericUpDown57.Value = (decimal)TruckDistributionBD;

            numericUpDown135.Value = (decimal)OceanTankerCoal;
            numericUpDown134.Value = (decimal)OceanTankerUO;
            numericUpDown133.Value = (decimal)OceanTankerEU;
            numericUpDown131.Value = (decimal)BargeCoal;
            numericUpDown130.Value = (decimal)BargeUO;
            numericUpDown129.Value = (decimal)BargeEU;
            numericUpDown127.Value = (decimal)PipelineCoal;
            numericUpDown126.Value = (decimal)PipelineUO;
            numericUpDown125.Value = (decimal)PipelineEU;
            numericUpDown123.Value = (decimal)RailCoal;
            numericUpDown122.Value = (decimal)RailUO;
            numericUpDown121.Value = (decimal)RailEU;
            numericUpDown119.Value = (decimal)TruckCoal;
            numericUpDown118.Value = (decimal)TruckUO;
            numericUpDown117.Value = (decimal)TruckEU;
            numericUpDown56.Value = (decimal)NGStationaryCombustion;
            numericUpDown64.Value = (decimal)LiquifiedNaturalGasPlant;
            numericUpDown65.Value = (decimal)FTDieselPlant;
            numericUpDown68.Value = (decimal)NGElectricPowerPlant;
            numericUpDown69.Value = (decimal)RefuelingStationUseofNorthAmericanNaturalGasForCNG;
            numericUpDown72.Value = (decimal)RefuelingStationUseOfNonNorthAmericanNaturalGasForCNG;

            //3
            numericUpDown76.Value = (decimal)SoybeanFarmingSD;
            numericUpDown84.Value = (decimal)SoyoilExtractionSD;
            numericUpDown92.Value = (decimal)SoyoilTransestrificationSD;

            //4
            numericUpDown96.Value = (decimal)SelectionOfModelCalculatedOrUserInput;
            numericUpDown108.Value = (decimal)ResidualOilUSAM;
            numericUpDown104.Value = (decimal)NaturalGasUSAM;
            numericUpDown100.Value = (decimal)CoalUSAM;
            numericUpDown112.Value = (decimal)NuclearPowerUSAM;
            numericUpDown113.Value = (decimal)BiomassAndOtherUSAM;

            //5 
            textBox1.Text = (string)VesselTypeID;
            numericUpDown132.Value = (decimal)NumberOfEngines;
            numericUpDown124.Value = (decimal)SingleEngineHP;
            numericUpDown138.Value = (decimal)KWperHP;
            numericUpDown137.Value = (decimal)GALperBBL;
            numericUpDown136.Value = (decimal)BBLperTONNE;
            numericUpDown141.Value = (decimal)BTUperKWH;
            numericUpDown143.Value = (decimal)TotalTripDistanceInMiles;
            numericUpDown142.Value = (decimal)TripTimeHours;
            numericUpDown140.Value = (decimal)TripTimeMinutes;
            numericUpDown147.Value = (decimal)POTIdle;
            numericUpDown153.Value = (decimal)POTManeuvering;
            numericUpDown158.Value = (decimal)POTPrecautionary;
            numericUpDown163.Value = (decimal)POTSlowCruise;
            numericUpDown168.Value = (decimal)POTFullCruise;
            numericUpDown145.Value = (decimal)HPLFIdle;
            numericUpDown151.Value = (decimal)HPLFManeuvering;
            numericUpDown156.Value = (decimal)HPLFPrecautionary;
            numericUpDown161.Value = (decimal)HPLFSlowCruise;
            numericUpDown166.Value = (decimal)HPLFFullCruise;
            numericUpDown170.Value = (decimal)SelectionOfModelCalculatedOrUserInputFuelConsumptionValues;
            numericUpDown175.Value = (decimal)EngineEfficiency;
            numericUpDown180.Value = (decimal)ResidualOilEE;
            numericUpDown179.Value = (decimal)LowSulfurDieselEE;
            numericUpDown178.Value = (decimal)NaturalGasEE;
            numericUpDown177.Value = (decimal)BiodieselEE;
            numericUpDown176.Value = (decimal)FischerTropschEE;
            numericUpDown215.Value = (decimal)ConventionalDieselIdle;
            numericUpDown210.Value = (decimal)ConventionalDieselManeuvering;
            numericUpDown205.Value = (decimal)ConventionalDieselPrecautionary;
            numericUpDown200.Value = (decimal)ConventionalDieselSlowCruise;
            numericUpDown195.Value = (decimal)ConventionalDieselFullCruise;
            numericUpDown214.Value = (decimal)ResidualOilIdle;
            numericUpDown209.Value = (decimal)ResidualOilManeuvering;
            numericUpDown204.Value = (decimal)ResidualOilPrecautionary;
            numericUpDown199.Value = (decimal)ResidualOilSlowCruise;
            numericUpDown194.Value = (decimal)ResidualOilFullCruise;
            numericUpDown213.Value = (decimal)LowSulfurDieselIdle;
            numericUpDown208.Value = (decimal)LowSulfurDieselManeuvering;
            numericUpDown203.Value = (decimal)LowSulfurDieselPrecautionary;
            numericUpDown198.Value = (decimal)LowSulfurDieselSlowCruise;
            numericUpDown193.Value = (decimal)LowSulfurDieselFullCruise;
            numericUpDown212.Value = (decimal)NaturalGasIdle;
            numericUpDown207.Value = (decimal)NaturalGasManeuvering;
            numericUpDown202.Value = (decimal)NaturalGasPrecautionary;
            numericUpDown197.Value = (decimal)NaturalGasSlowCruise;
            numericUpDown192.Value = (decimal)NaturalGasFullCruise;
            numericUpDown211.Value = (decimal)BioDieselIdle;
            numericUpDown206.Value = (decimal)BioDieselManeuvering;
            numericUpDown201.Value = (decimal)BioDieselPrecautionary;
            numericUpDown196.Value = (decimal)BioDieselSlowCruise;
            numericUpDown191.Value = (decimal)BioDieselFullCruise;
            numericUpDown220.Value = (decimal)FischerTropschIdle;
            numericUpDown219.Value = (decimal)FischerTropschManeuvering;
            numericUpDown218.Value = (decimal)FischerTropschPrecautionary;
            numericUpDown217.Value = (decimal)FischerTropschSlowCruise;
            numericUpDown216.Value = (decimal)FischerTropschFullCruise;

            //6
            numericUpDown227.Value = (decimal)AuxillaryEngineFuelType;
            numericUpDown228.Value = (decimal)NumberOfOnBoarAuxillaryEngines;
            numericUpDown229.Value = (decimal)NumberOfAuxillaryEnginesInUse;
            numericUpDown230.Value = (decimal)AuxillaryEnginesRatedHPperEngine;
            numericUpDown232.Value = (decimal)PercentOfTripAuxillaryIsActive;
            numericUpDown234.Value = (decimal)HPLoadFactorSingleEngine;
            numericUpDown237.Value = (decimal)SelectionOfModelCalculatedOrUserInputFuelConsumptionValues6;
            numericUpDown242.Value = (decimal)AuxillaryEngineEfficiency;
            numericUpDown293.Value = (decimal)AuxConventionalDieselFC;
            numericUpDown292.Value = (decimal)AuxResidualOilFC;
            numericUpDown291.Value = (decimal)AuxLowSulfurDieselFC;
            numericUpDown290.Value = (decimal)AuxNaturalGasFC;
            numericUpDown289.Value = (decimal)AuxBiodieselFC;
            numericUpDown268.Value = (decimal)AuxFischerTropschFC;

            //7
            numericUpDown114.Value = (decimal)VolumetricPercentageOfFTDieselinFTDBlend;
            numericUpDown115.Value = (decimal)VolumetricPercentageOfBiodieselInBiodieselBlend;
            numericUpDown120.Value = (decimal)DieselForFischerTropschBlend;
            numericUpDown116.Value = (decimal)DieselForBiodieselBlend;

            doCalculations();
            //All Results That Needed Calculation
            numericUpDown20.Value = (decimal)LiquifiedNaturalGasFGEFP;
            numericUpDown19.Value = (decimal)FischerTropschDieselFGEFP;
            numericUpDown73.Value = (decimal)SoybeanFarmingCP;
            numericUpDown80.Value = (decimal)SoyoilExtractionCP;
            numericUpDown88.Value = (decimal)SoyoilTransestrificationCP;
            numericUpDown128.Value = (decimal)TotalOnboardHP;
            numericUpDown139.Value = (decimal)TotalTripTimeHours;
            numericUpDown146.Value = (decimal)TimeInIdle;
            numericUpDown152.Value = (decimal)TimeInManeuvering;
            numericUpDown157.Value = (decimal)TimeInPrecautionary;
            numericUpDown162.Value = (decimal)TimeInSlowCruise;
            numericUpDown167.Value = (decimal)TimeInFullCruise;
            numericUpDown144.Value = (decimal)HPPEIdle;
            numericUpDown150.Value = (decimal)HPPEManeuvering;
            numericUpDown155.Value = (decimal)HPPEPrecautionary;
            numericUpDown160.Value = (decimal)HPPESlowCruise;
            numericUpDown165.Value = (decimal)HPPEFullCruise;
            numericUpDown148.Value = (decimal)EPIdle;
            numericUpDown149.Value = (decimal)EPManeuvering;
            numericUpDown154.Value = (decimal)EPPrecautionary;
            numericUpDown159.Value = (decimal)EPSlowCruise;
            numericUpDown164.Value = (decimal)EPFullCruise;
            numericUpDown169.Value = (decimal)EPTotal;
            numericUpDown174.Value = (decimal)KWHOutperTrip;
            numericUpDown173.Value = (decimal)MMBTUoutperTrip;
            numericUpDown172.Value = (decimal)MMBTUinperTrip;
            numericUpDown171.Value = (decimal)GALLONperTrip;
            numericUpDown185.Value = (decimal)ResidualOilMMBTU;
            numericUpDown184.Value = (decimal)LowSulfurDieselMMBTU;
            numericUpDown183.Value = (decimal)NaturalGasMMBTU;
            numericUpDown182.Value = (decimal)BiodieselMMBTU;
            numericUpDown181.Value = (decimal)FischerTropschMMBTU;
            numericUpDown190.Value = (decimal)ResidualOilAFC;
            numericUpDown189.Value = (decimal)LowSulfurDieselAFC;
            numericUpDown188.Value = (decimal)NaturalGasAFC;
            numericUpDown187.Value = (decimal)BiodieselAFC;
            numericUpDown186.Value = (decimal)FischerTropschAFC;
            numericUpDown226.Value = (decimal)ConventionalDieselTotal;
            numericUpDown225.Value = (decimal)ResidualOilTotal;
            numericUpDown224.Value = (decimal)LowSulfurDieselTotal;
            numericUpDown223.Value = (decimal)NaturalGasTotal;
            numericUpDown222.Value = (decimal)BioDieselTotal;
            numericUpDown221.Value = (decimal)FischerTropschTotal;
            numericUpDown231.Value = (decimal)TotalOnboardAUxHP;
            numericUpDown233.Value = (decimal)TimeAuxActiveHours;
            numericUpDown235.Value = (decimal)ActiveHPPerAuxEngine;
            numericUpDown236.Value = (decimal)TotalAuxEnergyProduction;
            numericUpDown241.Value = (decimal)AuxEngineKWHoutperTrip;
            numericUpDown240.Value = (decimal)AuxEngineMMBTUoutperTrip;
            numericUpDown239.Value = (decimal)AuxEngineMMBTUinperTrip;
            numericUpDown238.Value = (decimal)AuxEngineGALLONperTrip;
            numericUpDown257.Value = (decimal)AuxResidualOilEE;
            numericUpDown252.Value = (decimal)AuxResidualOilMMBTU;
            numericUpDown247.Value = (decimal)AuxResidualOilEAFC;
            numericUpDown256.Value = (decimal)AuxLowSulfurDieselEE;
            numericUpDown251.Value = (decimal)AuxLowSulfurDieselMMBTU;
            numericUpDown246.Value = (decimal)AuxLowSulfurDieselEAFC;
            numericUpDown255.Value = (decimal)AuxNaturalGasEE;
            numericUpDown250.Value = (decimal)AuxNaturalGasMMBTU;
            numericUpDown245.Value = (decimal)AuxNaturalGasEAFC;
            numericUpDown254.Value = (decimal)AuxBiodieselEE;
            numericUpDown249.Value = (decimal)AuxBiodieselMMBTU;
            numericUpDown244.Value = (decimal)AuxBiodieselEAFC;
            numericUpDown253.Value = (decimal)AuxFischerTropschEE;
            numericUpDown248.Value = (decimal)AuxFischerTropschMMBTU;
            numericUpDown243.Value = (decimal)AuxFischerTropschEAFC;
            numericUpDown263.Value = (decimal)AuxConventionalDieselTotal;
            numericUpDown262.Value = (decimal)AuxResidualOilTotal;
            numericUpDown261.Value = (decimal)AuxLowSulfurDieselTotal;
            numericUpDown260.Value = (decimal)AuxNaturalGasTotal;
            numericUpDown259.Value = (decimal)AuxBioDieselTotal;
            numericUpDown258.Value = (decimal)AuxFischerTropschTotal;
        }
        #endregion
        public void useDefaults()
        {
            #region Teams 1.1 - 1.2
            //1.1
            EfficiencyForPetroleumRecovery = 98.00;

            //1.2 (SL = Sulfur Level, RE = Refining Efficiency in %)
            ConventionalDieselSL = 200;
            ConventionalDieselRE = 89.0;
            LowSulfurDiesellSL = 11;
            LowSulfurDieselRE = 87.0;
            CrudeOilSL = 16000;
            ResidualOilSL = 28000;
            ResidualOilRE = 95.5;
            #endregion
            #region Teams 2.1 - 2.5
            //2.1 (FS = Feedstock Source PDNG = Plant Design When Natural Gas is Feedstock PDFG = Plant Design When Flared Gas is Feedstock)
            //Feedstocks 1 = North American Natural Gas 2 = Non North American Natural Gas
            //Plant Designs 0 = No Co-Products 1 = Steam Co-Products 2 = Electricity Co-Products
            CompressedNaturalGasFS = 1;
            LiquifiedNaturalGasFS = 1;
            FistcherTropschDieselFS = 1;
            FischerTropschDieselPDNG = 0;
            FischerTopschDieselPDFG = 0;
            NANGSteamProductionCredit = 202000;
            NNANGSteamProductionCredit = 202000;
            NNAFGSteamProductionCredit = 202000;

            //2.2 (NG = Natural Gas FG = Flared Gas, values are being given as percent shares of energy feedstock EFP = Energy Feedstock Percentage)
            LiquifiedNaturalGasNGEFP = 100.00;
            FischerTropschDieselNGEFP = 100.00;

            //2.3 Boiling ff Effects PP = Storage At Production Plant TPB = Transportation From Plant To Bulk Terminal BS = Bulk Terminal Storage DBR = Distribution From Bulk Terminal to Refueling Station RSCP = Refueling Station Storage for Central Plant
            //BoilingOffRatePerDay is a percentage, as is RateOfBoilingGasRecovered
            BoilingOffRatePerDayPP = .1;
            BoilingOffRatePerDayTPB = .1;
            BoilingOffRatePerDayBS = .1;
            BoilingOffRatePerDayDBR = .1;
            BoilingOffRatePerDayRSCP = .10;
            DurationOfStageDaysPP = 5;
            DurationOfStageDaysTPB = 1;
            DurationOfStageDaysBS = 5;
            DurationOfStageDaysDBR = .1;
            DurationOfStageDaysRSCP = 3;
            RateOfBoilingGasRecoveredPP = 80.0;
            RateOfBoilingGasRecoveredTPB = 80.0;
            RateOfBoilingGasRecoveredBS = 80.0;
            RateOfBoilingGasRecoveredDBR = 80.0;
            RateOfBoilingGasRecoveredRSCP = 80.0;

            //2.4 Transportation Distances of Moving Feedstock or Fuel: In Miles(One Way Distance)
            //Petroleum based
            //CO = Crude Oil RO = Residual Oil USD = US Diesel USLSD = US Low Sulfur Diesel
            OceanTankerCO = 5080;
            OceanTankerRO = 3000;
            OceanTankerUSD = 1450;
            OceanTankerUSLSD = 1450;
            BargeCO = 500;
            BargeRO = 340;
            BargeUSD = 520;
            BargeUSLSD = 520;
            PipelineCO = 750;
            PipelineRO = 400;
            PipelineUSD = 400;
            PipelineUSLSD = 400;
            RailCO = 800;
            RailRO = 800;
            RailUSD = 800;
            RailUSLSD = 800;
            TruckCO = 0;
            TruckRO = 30;
            TruckUSD = 30;
            TruckUSLSD = 30;
            //Natural Gas Based
            //NA = North American Natural Gas //NNA = Non North American Natural Gas
            OceanTankerNA = 0;
            OceanTankerNNA = 5000;
            BargeNA = 520;
            BargeNNA = 520;
            PipelineNA = 0;
            PipelineNNA = 0;
            RailNA = 800;
            RailNNA = 800;
            TruckNA = 30;
            TruckNNA = 30;
            //Fischer Tropsch Diesel Based
            //NAFTD = North American Natural Gas for Fischer Tropsch Diesel NNAFTD = Non North American Natural Gas for Fischer Tropsch Diesel NNAFGFTD = Non North American Flared Gas for Fischer Tropsch Diesel
            OceanTankerNAFTD = 0;
            OceanTankerNNAFTD = 5000;
            OceanTankerNNAFGFTD = 5900;
            BargeNAFTD = 520;
            BargeNNAFTD = 520;
            BargeNNAFGFTD = 520;
            PipelineNAFTD = 400;
            PipelineNNAFTD = 400;
            PipelineNNAFGFTD = 400;
            RailNAFTD = 800;
            RailNNAFTD = 800;
            RailNNAFGFTD = 800;
            TruckNAFTD = 30;
            TruckNNAFTD = 30;
            TruckNNAFGFTD = 30;
            //BioDiesel based
            //AGC = Ag Chemicals SB = Soybeans BD = Biodiesel
            BargeAGC = 400;
            BargeSB = 350;
            BargeBD = 520;
            PipelineAGC = 0;
            PipelineSB = 0;
            PipelineBD = 400;
            RailAGC = 750;
            RailSB = 400;
            RailBD = 800;
            TruckTransitAGC = 50;
            TruckTransitSB = 10;
            TruckTransitBD = 0;
            TruckDistributionAGC = 30;
            TruckDistributionSB = 40;
            TruckDistributionBD = 30;
            //Electricity Based
            //UO = Uranium Ore EU = Enriched Uranium
            OceanTankerCoal = 0;
            OceanTankerUO = 0;
            OceanTankerEU = 0;
            BargeCoal = 330;
            BargeUO = 0;
            BargeEU = 0;
            PipelineCoal = 0;
            PipelineUO = 0;
            PipelineEU = 0;
            RailCoal = 440;
            RailUO = 100;
            RailEU = 100;
            TruckCoal = 50;
            TruckUO = 1360;
            TruckEU = 920;

            //2.5 Distance From Gas Fields to Production plants: Miles
            //These are in miles, and describe what the useage of NG or the production of Transportation Fuels is
            NGStationaryCombustion = 500;
            LiquifiedNaturalGasPlant = 50;
            FTDieselPlant = 50;
            NGElectricPowerPlant = 375;
            RefuelingStationUseofNorthAmericanNaturalGasForCNG = 750;
            RefuelingStationUseOfNonNorthAmericanNaturalGasForCNG = 500;

            #endregion
            #region Teams 3
            //3 Simulation of Biodiesel: Allocation of Upstream Energy Use and Emissions Between Biodiesel and Co-Products
            //SD = Soydiesel CP = Co-Products
            SoybeanFarmingSD = 62.1;
            SoyoilExtractionSD = 62.1;
            SoyoilTransestrificationSD = 79.6;
            #endregion
            #region Teams 4.1 - 4.2
            //4.1 Selection of Model Calculated or user-Input Emission Factors for Power Plants
            //1 = Model Calculated Emissions Factors 2 = user Input Emissions Factors
            SelectionOfModelCalculatedOrUserInput = 1;

            //4.2 Electricity Generation Mix
            //USAM = US Average Mis in percent
            ResidualOilUSAM = 2.7;
            NaturalGasUSAM = 18.9;
            CoalUSAM = 50.7;
            NuclearPowerUSAM = 18.7;
            BiomassAndOtherUSAM = 9.0;
            #endregion
            #region Teams 5.1 - 5.4d
            //5.1 Main Engine Variables
            VesselTypeID = "Cont. Ship 6000";
            NumberOfEngines = 1;
            SingleEngineHP = 75097;
            //Constants (These are units of measurement)
            KWperHP = .7457;
            GALperBBL = 42;
            BBLperTONNE = 7.45;
            BTUperKWH = 3412;

            //5.2 Trip Distance and Time
            TotalTripDistanceInMiles = 10600.00;
            TripTimeHours = 480.00;
            TripTimeMinutes = 0.00;

            //5.3 Engine Charicterization Per Mode
            //POT - Percent Of Trip, Time in mode is measured in hours HPLF - Horse Power Load Factor (Single engine). HPPE = Horse Power Per Engine EP = Energy Production in KWH for all engines
            POTIdle = 1.25;
            POTManeuvering = 1.75;
            POTPrecautionary = 5.00;
            POTSlowCruise = 7.00;
            POTFullCruise = 85.00;
            HPLFIdle = 2.00;
            HPLFManeuvering = 8.00;
            HPLFPrecautionary = 12.00;
            HPLFSlowCruise = 50.00;
            HPLFFullCruise = 95.00;

            //5.4a Selection of Model Calculated or User Input Fuel Consumption Values (Conventional Diesel as Baseline Fuel)
            //1 = Simulate using GPH derived from user-entered engine specifications 2 = Simulate using User - Entered GPH
            SelectionOfModelCalculatedOrUserInputFuelConsumptionValues = 1;

            //5.4b Calculation of Fuel Use Using Conventional Diesel as Baseline Fuel
            EngineEfficiency = 45.00;

            //5.4c Calculation of Fuel Use Using Alternative Fuels (Conventional Diesel as Baseline Fuel)
            //EE = Engine Efficiency in percent MMBTU = million BTUs in per trip AFC = alternative Fuel Consumption in Gallons per trip
            ResidualOilEE = 45.0;
            LowSulfurDieselEE = 40.0;
            NaturalGasEE = 35.0;
            BiodieselEE = 40.0;
            FischerTropschEE = 40.0;

            //5.4d Fuel Consumption (Only needed if you are simulating using user - entered GPH) Total is in Gallons/Trip
            ConventionalDieselIdle = 30;
            ConventionalDieselManeuvering = 40;
            ConventionalDieselPrecautionary = 60;
            ConventionalDieselSlowCruise = 90;
            ConventionalDieselFullCruise = 100;
            ResidualOilIdle = 21;
            ResidualOilManeuvering = 31;
            ResidualOilPrecautionary = 52;
            ResidualOilSlowCruise = 75;
            ResidualOilFullCruise = 92;
            LowSulfurDieselIdle = 31;
            LowSulfurDieselManeuvering = 41;
            LowSulfurDieselPrecautionary = 61;
            LowSulfurDieselSlowCruise = 91;
            LowSulfurDieselFullCruise = 101;
            NaturalGasIdle = 3200;
            NaturalGasManeuvering = 4100;
            NaturalGasPrecautionary = 7800;
            NaturalGasSlowCruise = 10000;
            NaturalGasFullCruise = 11000;
            BioDieselIdle = 35;
            BioDieselManeuvering = 45;
            BioDieselPrecautionary = 65;
            BioDieselSlowCruise = 95;
            BioDieselFullCruise = 120;
            FischerTropschIdle = 34;
            FischerTropschManeuvering = 44;
            FischerTropschPrecautionary = 63;
            FischerTropschSlowCruise = 92;
            FischerTropschFullCruise = 111;

            #endregion
            #region Teams 6.1 - 6.4d
            //6.1 Auxillary Engine Fuel Type to Present On Results Sheet;
            //1 = Conventional Diesel 2 = Residual Oil 3 = Low Sulfur Diesel 4 = Natural gas 5 = Biodiesel 6 = Fischer Tropsch Diesel
            AuxillaryEngineFuelType = 1;

            //6.2 Auxillary Engine Variables
            NumberOfOnBoarAuxillaryEngines = 4;
            NumberOfAuxillaryEnginesInUse = 2;
            AuxillaryEnginesRatedHPperEngine = 1400;

            //6.3 Auxillary Engine Characterization (Conventional Diesel as Baseline Fuel)
            PercentOfTripAuxillaryIsActive = 50.00;
            HPLoadFactorSingleEngine = 80.00;

            //6.4a Selection of Medel Calculated or User Input Fuel Consumption Values Conventional Diesel as Baseline Fuel
            //1 = Simlate using GPH derived from User-Entered Auxillary engine specifications 2 = Simlate using user entered GPH
            SelectionOfModelCalculatedOrUserInputFuelConsumptionValues6 = 1;

            //6.4b Calculation of Auxillary Engine Fuel use Using Conventional Diesel as Baseline Fuel
            AuxillaryEngineEfficiency = 40.00;

            //6.4c Calculation of Auxillary Engine Fuel Use Using Alternative Fuels
            //EE = Engine Efficiency AuxMMBTU = Auxillary MMTBUin/Trip EAFC = Auxillary Engine Alternativee Fuel Consumption

            //6.4d  Auxillary Engine Fuel Consumption (Only if you're using user entered GPH for your simulation
            //FC = Fuel Consumption 
            AuxConventionalDieselFC = 9;
            AuxResidualOilFC = 10;
            AuxLowSulfurDieselFC = 11;
            AuxNaturalGasFC = 800;
            AuxBiodieselFC = 9;
            AuxFischerTropschFC = 10;
            #endregion
            #region Teams 7.2 - 7.2
            //7.1 Share of an Alternative Fuel in an Alternative Fuel Bleng Volumetric Percentage
            VolumetricPercentageOfFTDieselinFTDBlend = 100.00;
            VolumetricPercentageOfBiodieselInBiodieselBlend = 20.00;

            //7.2 Type of Diesel for Alternative Fuel Blends
            //1 = Conventional Diesel 2 = Low Sulfur Diesel
            DieselForFischerTropschBlend = 1;
            DieselForBiodieselBlend = 1;
            #endregion
        }
        //This is what happens when the TEAMS form loads
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Shows Copyright Screen
        private void button1_Click(object sender, EventArgs e)
        {
            Copyright c = new Copyright();
            this.Hide();
            c.Show();
        }
        //Timer constantly checking for needs to update
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (one_complete == true && two_complete == true && three_complete == true && four_complete == true && five_complete == true && six_complete == true && seven_complete == true)
            {
                runSimActive = true;
                runSimulationToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);
                //Timer stops running after the simulation is ready to run
                timer1.Stop();
            }
        }
        //Runs the simulation, and opens up the new results windows
        private void runSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (runSimActive == true)
            {
                runSimulationToolStripMenuItem.BackColor = Color.Green;
                ResultsSheet rs = new ResultsSheet(this);
                rs.Show();
            }
        }
        //This will set all variables to their default value, as is present in the TEAMS spreadsheet model
        private void useDefaultDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            submitAll();
        }
        #region This is what sends the data from the first set of inputs (Simulating Petroleum)

        private void button1_Click_1(object sender, EventArgs e)
        {
            EfficiencyForPetroleumRecovery = (double)numericUpDown1.Value;
            ConventionalDieselSL = (int)numericUpDown2.Value;
            ConventionalDieselRE = (double)numericUpDown3.Value;
            LowSulfurDiesellSL = (int)numericUpDown5.Value;
            LowSulfurDieselRE = (double)numericUpDown4.Value;
            CrudeOilSL = (int)numericUpDown7.Value;
            ResidualOilSL = (int)numericUpDown9.Value;
            ResidualOilRE = (double)numericUpDown8.Value;
            one_complete = true;
            button1.BackColor = Color.Green;
        }
        #endregion
        #region Sends Data from second set of inputs (Simulating Natural Gas)

        private void button2_Click(object sender, EventArgs e)
        {
            if (one_complete == true)
            {
                two_complete = true;
                button2.BackColor = Color.Green;
                //2.1
                CompressedNaturalGasFS = (int)numericUpDown15.Value;
                LiquifiedNaturalGasFS = (int)numericUpDown6.Value;
                FistcherTropschDieselFS = (int)numericUpDown10.Value;
                FischerTropschDieselPDNG = (int)numericUpDown11.Value;
                FischerTopschDieselPDFG = (int)numericUpDown12.Value;
                NANGSteamProductionCredit = (int)numericUpDown13.Value;
                NNANGSteamProductionCredit = (int)numericUpDown14.Value;
                NNAFGSteamProductionCredit = (int)numericUpDown16.Value;
                //2.2
                LiquifiedNaturalGasNGEFP = (double)numericUpDown17.Value;
                LiquifiedNaturalGasFGEFP = (double)numericUpDown20.Value;
                FischerTropschDieselFGEFP = 100.00 - FischerTropschDieselNGEFP;
                LiquifiedNaturalGasFGEFP = 100.00 - LiquifiedNaturalGasNGEFP;
                numericUpDown20.Value = (decimal)LiquifiedNaturalGasFGEFP;
                numericUpDown19.Value = (decimal)FischerTropschDieselFGEFP;
                //2.3
                BoilingOffRatePerDayPP = (double)numericUpDown24.Value;
                BoilingOffRatePerDayTPB = (double)numericUpDown22.Value;
                BoilingOffRatePerDayBS = (double)numericUpDown26.Value;
                BoilingOffRatePerDayDBR = (double)numericUpDown28.Value;
                BoilingOffRatePerDayRSCP = (double)numericUpDown30.Value;
                DurationOfStageDaysPP = (double)numericUpDown23.Value;
                DurationOfStageDaysTPB = (double)numericUpDown21.Value;
                DurationOfStageDaysBS = (double)numericUpDown25.Value;
                DurationOfStageDaysDBR = (double)numericUpDown27.Value;
                DurationOfStageDaysRSCP = (double)numericUpDown29.Value;
                RateOfBoilingGasRecoveredPP = (double)numericUpDown35.Value;
                RateOfBoilingGasRecoveredTPB = (double)numericUpDown34.Value;
                RateOfBoilingGasRecoveredBS = (double)numericUpDown33.Value;
                RateOfBoilingGasRecoveredDBR = (double)numericUpDown32.Value;
                RateOfBoilingGasRecoveredRSCP = (double)numericUpDown31.Value;
                //2.4
                OceanTankerCO = (int)numericUpDown47.Value;
                OceanTankerRO = (int)numericUpDown45.Value;
                OceanTankerUSD = (int)numericUpDown44.Value;
                OceanTankerUSLSD = (int)numericUpDown43.Value;
                BargeCO = (int)numericUpDown39.Value;
                BargeRO = (int)numericUpDown38.Value;
                BargeUSD = (int)numericUpDown37.Value;
                BargeUSLSD = (int)numericUpDown36.Value;
                PipelineCO = (int)numericUpDown46.Value;
                PipelineRO = (int)numericUpDown42.Value;
                PipelineUSD = (int)numericUpDown41.Value;
                PipelineUSLSD = (int)numericUpDown40.Value;
                RailCO = (int)numericUpDown51.Value;
                RailRO = (int)numericUpDown50.Value;
                RailUSD = (int)numericUpDown49.Value;
                RailUSLSD = (int)numericUpDown48.Value;
                TruckCO = (int)numericUpDown55.Value;
                TruckRO = (int)numericUpDown54.Value;
                TruckUSD = (int)numericUpDown53.Value;
                TruckUSLSD = (int)numericUpDown52.Value;
                //Natural Gas Based
                //NA = North American Natural Gas //NNA = Non North American Natural Gas
                OceanTankerNA = (int)numericUpDown75.Value;
                OceanTankerNNA = (int)numericUpDown74.Value;
                BargeNA = (int)numericUpDown71.Value;
                BargeNNA = (int)numericUpDown70.Value;
                PipelineNA = (int)numericUpDown67.Value;
                PipelineNNA = (int)numericUpDown66.Value;
                RailNA = (int)numericUpDown63.Value;
                RailNNA = (int)numericUpDown62.Value;
                TruckNA = (int)numericUpDown59.Value;
                TruckNNA = (int)numericUpDown58.Value;
                //Fischer Tropsch Diesel Based
                //NAFTD = North American Natural Gas for Fischer Tropsch Diesel NNAFTD = Non North American Natural Gas for Fischer Tropsch Diesel NNAFGFTD = Non North American Flared Gas for Fischer Tropsch Diesel
                OceanTankerNAFTD = (int)numericUpDown95.Value;
                OceanTankerNNAFTD = (int)numericUpDown94.Value;
                OceanTankerNNAFGFTD = (int)numericUpDown93.Value;
                BargeNAFTD = (int)numericUpDown91.Value;
                BargeNNAFTD = (int)numericUpDown90.Value;
                BargeNNAFGFTD = (int)numericUpDown89.Value;
                PipelineNAFTD = (int)numericUpDown87.Value;
                PipelineNNAFTD = (int)numericUpDown86.Value;
                PipelineNNAFGFTD = (int)numericUpDown85.Value;
                RailNAFTD = (int)numericUpDown83.Value;
                RailNNAFTD = (int)numericUpDown82.Value;
                RailNNAFGFTD = (int)numericUpDown81.Value;
                TruckNAFTD = (int)numericUpDown79.Value;
                TruckNNAFTD = (int)numericUpDown78.Value;
                TruckNNAFGFTD = (int)numericUpDown77.Value;
                //BioDiesel based
                //AGC = Ag Chemicals SB = Soybeans BD = Biodiesel
                BargeAGC = (int)numericUpDown111.Value;
                BargeSB = (int)numericUpDown110.Value;
                BargeBD = (int)numericUpDown109.Value;
                PipelineAGC = (int)numericUpDown107.Value;
                PipelineSB = (int)numericUpDown106.Value;
                PipelineBD = (int)numericUpDown105.Value;
                RailAGC = (int)numericUpDown103.Value;
                RailSB = (int)numericUpDown102.Value;
                RailBD = (int)numericUpDown101.Value;
                TruckTransitAGC = (int)numericUpDown99.Value;
                TruckTransitSB = (int)numericUpDown98.Value;
                TruckTransitBD = (int)numericUpDown97.Value;
                TruckDistributionAGC = (int)numericUpDown61.Value;
                TruckDistributionSB = (int)numericUpDown60.Value;
                TruckDistributionBD = (int)numericUpDown57.Value;
                //Electricity Based
                //UO = Uranium Ore EU = Enriched Uranium
                OceanTankerCoal = (int)numericUpDown135.Value;
                OceanTankerUO = (int)numericUpDown134.Value;
                OceanTankerEU = (int)numericUpDown133.Value;
                BargeCoal = (int)numericUpDown131.Value;
                BargeUO = (int)numericUpDown130.Value;
                BargeEU = (int)numericUpDown129.Value;
                PipelineCoal = (int)numericUpDown127.Value;
                PipelineUO = (int)numericUpDown126.Value;
                PipelineEU = (int)numericUpDown125.Value;
                RailCoal = (int)numericUpDown123.Value;
                RailUO = (int)numericUpDown122.Value;
                RailEU = (int)numericUpDown121.Value;
                TruckCoal = (int)numericUpDown119.Value;
                TruckUO = (int)numericUpDown118.Value;
                TruckEU = (int)numericUpDown117.Value;

                //2.5
                NGStationaryCombustion = (int)numericUpDown56.Value;
                LiquifiedNaturalGasPlant = (int)numericUpDown64.Value;
                FTDieselPlant = (int)numericUpDown65.Value;
                NGElectricPowerPlant = (int)numericUpDown68.Value;
                RefuelingStationUseofNorthAmericanNaturalGasForCNG = (int)numericUpDown69.Value;
                RefuelingStationUseOfNonNorthAmericanNaturalGasForCNG = (int)numericUpDown72.Value;
            }
            else
            {
                MessageBox.Show("Go Back And Complete Previous Tabs Before Submitting");
            }

        }
        #endregion
        #region Sends Data from third set of inputs (Simulating biodiesel)
        private void button3_Click(object sender, EventArgs e)
        {
            if (one_complete == true && two_complete == true)
            {
                three_complete = true;
                button3.BackColor = Color.Green;
                double SoybeanFarmingSD = (double)numericUpDown76.Value;
                double SoyoilExtractionSD = (double)numericUpDown84.Value;
                double SoyoilTransestrificationSD = (double)numericUpDown92.Value;
                SoybeanFarmingCP = 100.00 - SoybeanFarmingSD;
                SoyoilExtractionCP = 100.00 - SoybeanFarmingSD;
                SoyoilTransestrificationCP = 100.00 - SoyoilTransestrificationSD;
                numericUpDown73.Value = (decimal)SoybeanFarmingCP;
                numericUpDown80.Value = (decimal)SoyoilExtractionCP;
                numericUpDown88.Value = (decimal)SoyoilTransestrificationCP;
            }
            else
            {
                MessageBox.Show("Go Back And Complete Previous Tabs Before Submitting");
            }

        }
        #endregion
        #region Sends Data from fourth set of inputs (Simulating Electricity)
        private void button4_Click(object sender, EventArgs e)
        {
            if (one_complete == true && two_complete == true && three_complete == true)
            {
                four_complete = true;
                button4.BackColor = Color.Green;

                //4.1
                SelectionOfModelCalculatedOrUserInput = (int)numericUpDown96.Value;

                //4.2
                ResidualOilUSAM = (double)numericUpDown108.Value;
                NaturalGasUSAM = (double)numericUpDown104.Value;
                CoalUSAM = (double)numericUpDown100.Value;
                NuclearPowerUSAM = (double)numericUpDown112.Value;
                BiomassAndOtherUSAM = (double)numericUpDown113.Value;
            }
            else
            {
                MessageBox.Show("Go Back And Complete Previous Tabs Before Submitting");
            }

        }
        #endregion
        #region Sends data from fifth set of inputs (Main Engine)
        private void button5_Click(object sender, EventArgs e)
        {
            if (one_complete == true && two_complete == true && three_complete == true && four_complete == true)
            {
                five_complete = true;
                button5.BackColor = Color.Green;
                //5.1
                VesselTypeID = textBox1.Text;
                NumberOfEngines = (int)numericUpDown132.Value;
                SingleEngineHP = (int)numericUpDown124.Value;
                TotalOnboardHP = SingleEngineHP * NumberOfEngines;
                numericUpDown128.Value = (decimal)TotalOnboardHP;
                //Constants (These are units of measurement)
                KWperHP = (double)numericUpDown138.Value;
                GALperBBL = (double)numericUpDown137.Value;
                BBLperTONNE = (double)numericUpDown136.Value;
                BTUperKWH = (double)numericUpDown141.Value;

                //5.2
                TotalTripDistanceInMiles = (double)numericUpDown143.Value;
                TripTimeHours = (double)numericUpDown142.Value;
                TripTimeMinutes = (double)numericUpDown140.Value;
                TotalTripTimeHours = TripTimeHours + (TripTimeMinutes / 60);
                numericUpDown139.Value = (decimal)TotalTripTimeHours;
                //5.3
                POTIdle = (double)numericUpDown147.Value;
                POTManeuvering = (double)numericUpDown153.Value;
                POTPrecautionary = (double)numericUpDown158.Value;
                POTSlowCruise = (double)numericUpDown163.Value;
                POTFullCruise = (double)numericUpDown168.Value;
                TimeInIdle = (POTIdle / 100) * TotalTripTimeHours;
                numericUpDown146.Value = (decimal)TimeInIdle;
                TimeInManeuvering = (POTManeuvering / 100) * TotalTripTimeHours;
                numericUpDown152.Value = (decimal)TimeInManeuvering;
                TimeInPrecautionary = (POTPrecautionary / 100) * TotalTripTimeHours;
                numericUpDown157.Value = (decimal)TimeInPrecautionary;
                TimeInSlowCruise = (POTSlowCruise / 100) * TotalTripTimeHours;
                numericUpDown162.Value = (decimal)TimeInSlowCruise;
                TimeInFullCruise = (POTFullCruise / 100) * TotalTripTimeHours;
                numericUpDown167.Value = (decimal)TimeInFullCruise;
                HPLFIdle = (double)numericUpDown145.Value;
                HPLFManeuvering = (double)numericUpDown151.Value;
                HPLFPrecautionary = (double)numericUpDown156.Value;
                HPLFSlowCruise = (double)numericUpDown161.Value;
                HPLFFullCruise = (double)numericUpDown166.Value;

                HPPEIdle = (HPLFIdle / 100) * SingleEngineHP;
                numericUpDown144.Value = (decimal)HPPEIdle;
                HPPEManeuvering = (HPLFManeuvering / 100) * SingleEngineHP;
                numericUpDown150.Value = (decimal)HPPEManeuvering;
                HPPEPrecautionary = (HPLFPrecautionary / 100) * SingleEngineHP;
                numericUpDown155.Value = (decimal)HPPEPrecautionary;
                HPPESlowCruise = (HPLFSlowCruise / 100) * SingleEngineHP;
                numericUpDown160.Value = (decimal)HPPESlowCruise;
                HPPEFullCruise = (HPLFFullCruise / 100) * SingleEngineHP;
                numericUpDown165.Value = (decimal)HPPEFullCruise;
                EPIdle = NumberOfEngines * HPPEIdle * TimeInIdle * KWperHP;
                numericUpDown148.Value = (decimal)EPIdle;
                EPManeuvering = NumberOfEngines * HPPEManeuvering * TimeInManeuvering * KWperHP;
                numericUpDown149.Value = (decimal)EPManeuvering;
                EPPrecautionary = NumberOfEngines * HPPEPrecautionary * TimeInPrecautionary * KWperHP;
                numericUpDown154.Value = (decimal)EPPrecautionary;
                EPSlowCruise = NumberOfEngines * HPPESlowCruise * TimeInSlowCruise * KWperHP;
                numericUpDown159.Value = (decimal)EPSlowCruise;
                EPFullCruise = NumberOfEngines * HPPEFullCruise * TimeInFullCruise * KWperHP;
                numericUpDown164.Value = (decimal)EPFullCruise;
                EPTotal = EPIdle + EPManeuvering + EPPrecautionary + EPSlowCruise + EPFullCruise;
                numericUpDown169.Value = (decimal)EPTotal;

                //5.4a
                SelectionOfModelCalculatedOrUserInputFuelConsumptionValues = (int)numericUpDown170.Value;

                //5.4b
                EngineEfficiency = (double)numericUpDown175.Value;
                KWHOutperTrip = EPTotal;
                numericUpDown174.Value = (decimal)KWHOutperTrip;
                MMBTUoutperTrip = (KWHOutperTrip * BTUperKWH) / 1000000;
                numericUpDown173.Value = (decimal)MMBTUoutperTrip;
                MMBTUinperTrip = MMBTUoutperTrip * (100 / EngineEfficiency);
                numericUpDown172.Value = (decimal)MMBTUinperTrip;
                //Needs to pull from the Fuel Specs page in GREET
                GALLONperTrip = (1 / conventionalDieselBTUperGal) * 1000000 * MMBTUinperTrip;
                numericUpDown171.Value = (decimal)GALLONperTrip;

                //5.4c
                ResidualOilEE = (double)numericUpDown180.Value;
                ResidualOilMMBTU = MMBTUoutperTrip * (100 / ResidualOilEE);
                numericUpDown185.Value = (decimal)ResidualOilMMBTU;
                ResidualOilAFC = GALLONperTrip = (1 / residualOilBTUperGal) * 1000000 * ResidualOilMMBTU;
                numericUpDown190.Value = (decimal)ResidualOilAFC;

                LowSulfurDieselEE = (double)numericUpDown179.Value;
                LowSulfurDieselMMBTU = MMBTUoutperTrip * (100 / LowSulfurDieselEE);
                numericUpDown184.Value = (decimal)LowSulfurDieselMMBTU;
                LowSulfurDieselAFC = (1 / lowSulfurDieselBTUperGal) * 1000000 * LowSulfurDieselMMBTU;
                numericUpDown189.Value = (decimal)LowSulfurDieselAFC;

                NaturalGasEE = (double)numericUpDown178.Value;
                NaturalGasMMBTU = MMBTUoutperTrip * (100 / NaturalGasEE);
                numericUpDown183.Value = (decimal)NaturalGasMMBTU;
                NaturalGasAFC = (1 / natGasBTUperSCF) * 1000000 * NaturalGasMMBTU;
                numericUpDown188.Value = (decimal)NaturalGasAFC;

                BiodieselEE = (double)numericUpDown177.Value;
                BiodieselMMBTU = MMBTUoutperTrip * (100 / BiodieselEE);
                numericUpDown182.Value = (decimal)BiodieselMMBTU;
                BiodieselAFC = (1 / bioDieselBTUperGal) * 1000000 * BiodieselMMBTU;
                numericUpDown187.Value = (decimal)BiodieselAFC;

                FischerTropschEE = (double)numericUpDown176.Value;
                FischerTropschMMBTU = MMBTUoutperTrip * (100 / FischerTropschEE);
                numericUpDown181.Value = (decimal)FischerTropschMMBTU;
                FischerTropschAFC = (1 / fischerTropschBTUperGal) * 1000000 * FischerTropschMMBTU;
                numericUpDown186.Value = (decimal)FischerTropschAFC;

                //5.4d
                ConventionalDieselIdle = (int)numericUpDown215.Value;
                ConventionalDieselManeuvering = (int)numericUpDown210.Value;
                ConventionalDieselPrecautionary = (int)numericUpDown205.Value;
                ConventionalDieselSlowCruise = (int)numericUpDown200.Value;
                ConventionalDieselFullCruise = (int)numericUpDown195.Value;
                ConventionalDieselTotal = (int)((ConventionalDieselIdle * TimeInIdle * NumberOfEngines)+(ConventionalDieselManeuvering * TimeInManeuvering * NumberOfEngines)+(ConventionalDieselPrecautionary * TimeInPrecautionary * NumberOfEngines)+(ConventionalDieselSlowCruise * TimeInSlowCruise * NumberOfEngines)+(ConventionalDieselFullCruise * TimeInFullCruise * NumberOfEngines));
                numericUpDown226.Value = (decimal)ConventionalDieselTotal;
                ResidualOilIdle = (int)numericUpDown214.Value;
                ResidualOilManeuvering = (int)numericUpDown209.Value;
                ResidualOilPrecautionary = (int)numericUpDown204.Value;
                ResidualOilSlowCruise = (int)numericUpDown199.Value;
                ResidualOilFullCruise = (int)numericUpDown194.Value;
                ResidualOilTotal = (int)((ResidualOilIdle * TimeInIdle * NumberOfEngines) + (ResidualOilManeuvering * TimeInManeuvering * NumberOfEngines) + (ResidualOilPrecautionary * TimeInPrecautionary * NumberOfEngines) + (ResidualOilSlowCruise * TimeInSlowCruise * NumberOfEngines) + (ResidualOilFullCruise * TimeInFullCruise * NumberOfEngines));
                numericUpDown225.Value = (decimal)ResidualOilTotal;
                LowSulfurDieselIdle = (int)numericUpDown213.Value;
                LowSulfurDieselManeuvering = (int)numericUpDown208.Value;
                LowSulfurDieselPrecautionary = (int)numericUpDown203.Value;
                LowSulfurDieselSlowCruise = (int)numericUpDown198.Value;
                LowSulfurDieselFullCruise = (int)numericUpDown193.Value;
                LowSulfurDieselTotal = (int)((LowSulfurDieselIdle * TimeInIdle * NumberOfEngines) + (LowSulfurDieselManeuvering * TimeInManeuvering * NumberOfEngines) + (LowSulfurDieselPrecautionary * TimeInPrecautionary * NumberOfEngines) + (LowSulfurDieselSlowCruise * TimeInSlowCruise * NumberOfEngines) + (LowSulfurDieselFullCruise * TimeInFullCruise * NumberOfEngines));
                numericUpDown224.Value = (decimal)LowSulfurDieselTotal;
                NaturalGasIdle = (int)numericUpDown212.Value;
                NaturalGasManeuvering = (int)numericUpDown207.Value;
                NaturalGasPrecautionary = (int)numericUpDown202.Value;
                NaturalGasSlowCruise = (int)numericUpDown197.Value;
                NaturalGasFullCruise = (int)numericUpDown192.Value;
                NaturalGasTotal = (int)((NaturalGasIdle * TimeInIdle * NumberOfEngines) + (NaturalGasManeuvering * TimeInManeuvering * NumberOfEngines) + (NaturalGasPrecautionary * TimeInPrecautionary * NumberOfEngines) + (NaturalGasSlowCruise * TimeInSlowCruise * NumberOfEngines) + (NaturalGasFullCruise * TimeInFullCruise * NumberOfEngines));
                numericUpDown223.Value = (decimal)NaturalGasTotal;
                BioDieselIdle = (int)numericUpDown211.Value;
                BioDieselManeuvering = (int)numericUpDown206.Value;
                BioDieselPrecautionary = (int)numericUpDown201.Value;
                BioDieselSlowCruise = (int)numericUpDown196.Value;
                BioDieselFullCruise = (int)numericUpDown191.Value;
                BioDieselTotal = (int)((BioDieselIdle * TimeInIdle * NumberOfEngines) + (BioDieselManeuvering * TimeInManeuvering * NumberOfEngines) + (BioDieselPrecautionary * TimeInPrecautionary * NumberOfEngines) + (BioDieselSlowCruise * TimeInSlowCruise * NumberOfEngines) + (BioDieselFullCruise * TimeInFullCruise * NumberOfEngines));
                numericUpDown222.Value = (decimal)BioDieselTotal;
                FischerTropschIdle = (int)numericUpDown220.Value;
                FischerTropschManeuvering = (int)numericUpDown219.Value;
                FischerTropschPrecautionary = (int)numericUpDown218.Value;
                FischerTropschSlowCruise = (int)numericUpDown217.Value;
                FischerTropschFullCruise = (int)numericUpDown216.Value;
                FischerTropschTotal = (int)((FischerTropschIdle * TimeInIdle * NumberOfEngines) + (FischerTropschManeuvering * TimeInManeuvering * NumberOfEngines) + (FischerTropschPrecautionary * TimeInPrecautionary * NumberOfEngines) + (FischerTropschSlowCruise * TimeInSlowCruise * NumberOfEngines) + (FischerTropschFullCruise * TimeInFullCruise * NumberOfEngines));
                numericUpDown221.Value = (decimal)FischerTropschTotal;
            }
            else
            {
                MessageBox.Show("Go Back And Complete Previous Tabs Before Submitting");
            }
        }
        #endregion
        #region Sends data from sixth set of inputs (Aux Engine)
        private void button6_Click(object sender, EventArgs e)
        {
            if (one_complete == true && two_complete == true && three_complete == true && four_complete == true && five_complete == true)
            {
                six_complete = true;
                button6.BackColor = Color.Green;
                //6.1
                AuxillaryEngineFuelType = (int)numericUpDown227.Value;

                //6.2
                NumberOfOnBoarAuxillaryEngines = (int)numericUpDown228.Value;
                NumberOfAuxillaryEnginesInUse = (int)numericUpDown229.Value;
                AuxillaryEnginesRatedHPperEngine = (int)numericUpDown230.Value;
                TotalOnboardAUxHP = NumberOfAuxillaryEnginesInUse * AuxillaryEnginesRatedHPperEngine;
                numericUpDown231.Value = (decimal)TotalOnboardAUxHP;

                //6.3
                PercentOfTripAuxillaryIsActive = (double)numericUpDown232.Value;
                TimeAuxActiveHours = (PercentOfTripAuxillaryIsActive / 100) * TotalTripTimeHours;
                numericUpDown233.Value = (decimal)TimeAuxActiveHours;
                HPLoadFactorSingleEngine = (double)numericUpDown234.Value;
                ActiveHPPerAuxEngine = (HPLoadFactorSingleEngine / 100) * AuxillaryEnginesRatedHPperEngine;
                numericUpDown235.Value = (decimal)ActiveHPPerAuxEngine;
                TotalAuxEnergyProduction = NumberOfAuxillaryEnginesInUse * ActiveHPPerAuxEngine * TimeAuxActiveHours * KWperHP;
                numericUpDown236.Value = (decimal)TotalAuxEnergyProduction;

                //6.4a 
                SelectionOfModelCalculatedOrUserInputFuelConsumptionValues6 = (int)numericUpDown237.Value;

                //6.4b
                AuxillaryEngineEfficiency = (double)numericUpDown242.Value;
                AuxEngineKWHoutperTrip = TotalAuxEnergyProduction;
                numericUpDown241.Value = (decimal)AuxEngineKWHoutperTrip;
                AuxEngineMMBTUoutperTrip = (AuxEngineKWHoutperTrip * BTUperKWH) / 1000000;

                numericUpDown240.Value = (decimal)AuxEngineMMBTUoutperTrip;
                AuxEngineMMBTUinperTrip = AuxEngineMMBTUoutperTrip * (100 / AuxillaryEngineEfficiency);
                numericUpDown239.Value = (decimal)AuxEngineMMBTUinperTrip;
                //This one requires fuel specs from GREET
                AuxEngineGALLONperTrip = (1 / conventionalDieselBTUperGal) * 1000000 * AuxEngineMMBTUinperTrip;
                numericUpDown238.Value = (decimal)AuxEngineGALLONperTrip;

                //6.4c
                AuxResidualOilEE = ResidualOilEE;
                numericUpDown257.Value = (decimal)AuxResidualOilEE;
                AuxResidualOilMMBTU = AuxEngineMMBTUoutperTrip * (100 / AuxResidualOilEE);
                numericUpDown252.Value = (decimal)AuxResidualOilMMBTU;
                //This one requires Fuel Specs from GREET
                AuxResidualOilEAFC = (1 / residualOilBTUperGal) * 1000000 * AuxResidualOilMMBTU;
                numericUpDown247.Value = (decimal)AuxResidualOilEAFC;

                AuxLowSulfurDieselEE = LowSulfurDieselEE;
                numericUpDown256.Value = (decimal)AuxLowSulfurDieselEE;
                AuxLowSulfurDieselMMBTU = AuxEngineMMBTUoutperTrip * (100 / AuxLowSulfurDieselEE);
                numericUpDown251.Value = (decimal)AuxLowSulfurDieselMMBTU;
                //This one requires Fuel Specs from GREET
                AuxLowSulfurDieselEAFC = (1 /lowSulfurDieselBTUperGal) * 1000000 * AuxLowSulfurDieselMMBTU;
                numericUpDown246.Value = (decimal)AuxLowSulfurDieselEAFC;

                AuxNaturalGasEE = NaturalGasEE;
                numericUpDown255.Value = (decimal)AuxNaturalGasEE;
                AuxNaturalGasMMBTU = AuxEngineMMBTUoutperTrip * (100 / AuxNaturalGasEE);
                numericUpDown250.Value = (decimal)AuxNaturalGasMMBTU;
                //This one requires Fuel Specs from GREET
                AuxNaturalGasEAFC = (1 / natGasBTUperSCF) * 1000000 * AuxNaturalGasMMBTU;
                numericUpDown245.Value = (decimal)AuxNaturalGasEAFC;

                AuxBiodieselEE = BiodieselEE;
                numericUpDown254.Value = (decimal)AuxBiodieselEE;
                AuxBiodieselMMBTU = AuxEngineMMBTUoutperTrip * (100 / AuxBiodieselEE);
                numericUpDown249.Value = (decimal)AuxBiodieselMMBTU;
                //This one requires Fuel Specs from GREET
                AuxBiodieselEAFC = (1 / bioDieselBTUperGal) * 1000000 * AuxBiodieselMMBTU;
                numericUpDown244.Value = (decimal)AuxBiodieselEAFC;

                AuxFischerTropschEE = FischerTropschEE;
                numericUpDown253.Value = (decimal)AuxFischerTropschEE;
                AuxFischerTropschMMBTU = AuxEngineMMBTUoutperTrip * (100 / AuxFischerTropschEE);
                numericUpDown248.Value = (decimal)AuxFischerTropschMMBTU;
                //This one requires Fuel Specs from GREET
                AuxFischerTropschEAFC = (1 / fischerTropschBTUperGal) * 1000000 * AuxFischerTropschMMBTU;
                numericUpDown243.Value = (decimal)AuxFischerTropschEAFC;

                //6.4d
                AuxConventionalDieselFC = (int)numericUpDown293.Value;
                AuxConventionalDieselTotal = AuxConventionalDieselFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
                numericUpDown263.Value = (decimal)AuxConventionalDieselTotal;
                AuxResidualOilFC = (int)numericUpDown292.Value;
                AuxResidualOilTotal = AuxResidualOilFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
                numericUpDown262.Value = (decimal)AuxResidualOilTotal;
                AuxLowSulfurDieselFC = (int)numericUpDown291.Value;
                AuxLowSulfurDieselTotal = AuxLowSulfurDieselFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
                numericUpDown261.Value = (decimal)AuxLowSulfurDieselTotal;
                AuxNaturalGasFC = (int)numericUpDown290.Value;
                AuxNaturalGasTotal = AuxNaturalGasFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
                numericUpDown260.Value = (decimal)AuxNaturalGasTotal;
                AuxBiodieselFC = (int)numericUpDown289.Value;
                AuxBioDieselTotal = AuxBiodieselFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
                numericUpDown259.Value = (decimal)AuxBioDieselTotal;
                AuxFischerTropschFC = (int)numericUpDown268.Value;
                AuxFischerTropschTotal = AuxFischerTropschFC * TimeAuxActiveHours * NumberOfAuxillaryEnginesInUse;
                numericUpDown258.Value = (decimal)AuxFischerTropschTotal;
            }
            else
            {
                MessageBox.Show("Go Back And Complete Previous Tabs Before Submitting");
            }


        }
        #endregion
        #region Sends data from seventh set of inputs (Fuel Blend)
        private void button7_Click(object sender, EventArgs e)
        {
            if (one_complete == true && two_complete == true && three_complete == true && four_complete == true && five_complete == true && six_complete == true)
            {
                seven_complete = true;
                button7.BackColor = Color.Green;
                //7.1
                VolumetricPercentageOfFTDieselinFTDBlend = (double)numericUpDown114.Value;
                VolumetricPercentageOfBiodieselInBiodieselBlend = (double)numericUpDown115.Value;

                //7.2
                DieselForFischerTropschBlend = (int)numericUpDown120.Value;
                DieselForBiodieselBlend = (int)numericUpDown116.Value;
            }
            else
            {
                MessageBox.Show("Go Back And Complete Previous Tabs Before Submitting");
            }
        }
        #endregion

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new TEAMS();
            f.Show();
        }
        //This is what happens when you hit the open button in the menu strip
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "TEAMS Files | *.TEAMS";

            if (of.ShowDialog() == DialogResult.OK)
            {
                openedFile = of.FileName;
                System.IO.StreamReader sr = new System.IO.StreamReader(of.FileName);
                #region  Opening a save information goes in here
                //1
                EfficiencyForPetroleumRecovery = Convert.ToDouble(sr.ReadLine());
                ConventionalDieselSL =  Convert.ToInt32(sr.ReadLine());
                ConventionalDieselRE =  Convert.ToDouble(sr.ReadLine());
                LowSulfurDiesellSL = Convert.ToInt32(sr.ReadLine());
                LowSulfurDieselRE =  Convert.ToDouble(sr.ReadLine());
                CrudeOilSL = Convert.ToInt32(sr.ReadLine());
                ResidualOilSL =Convert.ToInt32(sr.ReadLine());
                ResidualOilRE =  Convert.ToDouble(sr.ReadLine());
                //2
                CompressedNaturalGasFS = Convert.ToInt32(sr.ReadLine());
                LiquifiedNaturalGasFS = Convert.ToInt32(sr.ReadLine());
                FistcherTropschDieselFS = Convert.ToInt32(sr.ReadLine());
                FischerTropschDieselPDNG = Convert.ToInt32(sr.ReadLine());
                FischerTopschDieselPDFG = Convert.ToInt32(sr.ReadLine());
                NANGSteamProductionCredit = Convert.ToInt32(sr.ReadLine());
                NNANGSteamProductionCredit = Convert.ToInt32(sr.ReadLine());
                NNAFGSteamProductionCredit = Convert.ToInt32(sr.ReadLine());
                LiquifiedNaturalGasNGEFP =  Convert.ToDouble(sr.ReadLine());
                FischerTropschDieselNGEFP =  Convert.ToDouble(sr.ReadLine());
                BoilingOffRatePerDayPP =  Convert.ToDouble(sr.ReadLine());
                BoilingOffRatePerDayTPB =  Convert.ToDouble(sr.ReadLine());
                BoilingOffRatePerDayBS =  Convert.ToDouble(sr.ReadLine());
                BoilingOffRatePerDayDBR =  Convert.ToDouble(sr.ReadLine());
                BoilingOffRatePerDayRSCP =  Convert.ToDouble(sr.ReadLine());
                DurationOfStageDaysPP =  Convert.ToDouble(sr.ReadLine());
                DurationOfStageDaysTPB =  Convert.ToDouble(sr.ReadLine());
                DurationOfStageDaysBS =  Convert.ToDouble(sr.ReadLine());
                DurationOfStageDaysDBR =  Convert.ToDouble(sr.ReadLine());
                DurationOfStageDaysRSCP =  Convert.ToDouble(sr.ReadLine());
                RateOfBoilingGasRecoveredPP =  Convert.ToDouble(sr.ReadLine());
                RateOfBoilingGasRecoveredTPB =  Convert.ToDouble(sr.ReadLine());
                RateOfBoilingGasRecoveredBS =  Convert.ToDouble(sr.ReadLine());
                RateOfBoilingGasRecoveredDBR =  Convert.ToDouble(sr.ReadLine());
                RateOfBoilingGasRecoveredRSCP =  Convert.ToDouble(sr.ReadLine());
                OceanTankerCO =Convert.ToInt32( sr.ReadLine());
                OceanTankerRO = Convert.ToInt32(sr.ReadLine());
                OceanTankerUSD = Convert.ToInt32(sr.ReadLine());
                OceanTankerUSLSD = Convert.ToInt32(sr.ReadLine());
                BargeCO =Convert.ToInt32( sr.ReadLine());
                BargeRO =Convert.ToInt32( sr.ReadLine());
                BargeUSD = Convert.ToInt32(sr.ReadLine());
                BargeUSLSD = Convert.ToInt32(sr.ReadLine());
                PipelineCO =Convert.ToInt32( sr.ReadLine());
                PipelineRO =Convert.ToInt32( sr.ReadLine());
                PipelineUSD = Convert.ToInt32(sr.ReadLine());
                PipelineUSLSD =Convert.ToInt32( sr.ReadLine());
                RailCO =Convert.ToInt32( sr.ReadLine());
                RailRO = Convert.ToInt32(sr.ReadLine());
                RailUSD = Convert.ToInt32(sr.ReadLine());
                RailUSLSD =Convert.ToInt32( sr.ReadLine());
                TruckCO = Convert.ToInt32(sr.ReadLine());
                TruckRO = Convert.ToInt32(sr.ReadLine());
                TruckUSD =Convert.ToInt32( sr.ReadLine());
                TruckUSLSD = Convert.ToInt32(sr.ReadLine());
                OceanTankerNA = Convert.ToInt32(sr.ReadLine());
                OceanTankerNNA =Convert.ToInt32( sr.ReadLine());
                BargeNA = Convert.ToInt32(sr.ReadLine());
                BargeNNA = Convert.ToInt32(sr.ReadLine());
                PipelineNA = Convert.ToInt32(sr.ReadLine());
                PipelineNNA =Convert.ToInt32( sr.ReadLine());
                RailNA = Convert.ToInt32(sr.ReadLine());
                RailNNA = Convert.ToInt32(sr.ReadLine());
                TruckNA =Convert.ToInt32( sr.ReadLine());
                TruckNNA = Convert.ToInt32(sr.ReadLine());
                OceanTankerNAFTD =Convert.ToInt32( sr.ReadLine());
                OceanTankerNNAFTD =Convert.ToInt32( sr.ReadLine());
                OceanTankerNNAFGFTD =Convert.ToInt32( sr.ReadLine());
                BargeNAFTD = Convert.ToInt32(sr.ReadLine());
                BargeNNAFTD = Convert.ToInt32(sr.ReadLine());
                BargeNNAFGFTD =Convert.ToInt32( sr.ReadLine());
                PipelineNAFTD =Convert.ToInt32( sr.ReadLine());
                PipelineNNAFTD = Convert.ToInt32(sr.ReadLine());
                PipelineNNAFGFTD = Convert.ToInt32(sr.ReadLine());
                RailNAFTD = Convert.ToInt32(sr.ReadLine());
                RailNNAFTD = Convert.ToInt32(sr.ReadLine());
                RailNNAFGFTD = Convert.ToInt32(sr.ReadLine());
                TruckNAFTD =Convert.ToInt32( sr.ReadLine());
                TruckNNAFTD = Convert.ToInt32(sr.ReadLine());
                TruckNNAFGFTD = Convert.ToInt32(sr.ReadLine());
                BargeAGC =Convert.ToInt32( sr.ReadLine());
                BargeSB = Convert.ToInt32(sr.ReadLine());
                BargeBD = Convert.ToInt32(sr.ReadLine());
                PipelineAGC = Convert.ToInt32(sr.ReadLine());
                PipelineSB = Convert.ToInt32(sr.ReadLine());
                PipelineBD =Convert.ToInt32( sr.ReadLine());
                RailAGC =Convert.ToInt32( sr.ReadLine());
                RailSB =Convert.ToInt32( sr.ReadLine());
                RailBD = Convert.ToInt32(sr.ReadLine());
                TruckTransitAGC = Convert.ToInt32(sr.ReadLine());
                TruckTransitSB = Convert.ToInt32(sr.ReadLine());
                TruckTransitBD = Convert.ToInt32(sr.ReadLine());
                TruckDistributionAGC = Convert.ToInt32(sr.ReadLine());
                TruckDistributionSB = Convert.ToInt32(sr.ReadLine());
                TruckDistributionBD = Convert.ToInt32(sr.ReadLine());
                OceanTankerCoal = Convert.ToInt32(sr.ReadLine());
                OceanTankerUO = Convert.ToInt32(sr.ReadLine());
                OceanTankerEU = Convert.ToInt32(sr.ReadLine());
                BargeCoal = Convert.ToInt32(sr.ReadLine());
                BargeUO = Convert.ToInt32(sr.ReadLine());
                BargeEU = Convert.ToInt32(sr.ReadLine());
                PipelineCoal = Convert.ToInt32(sr.ReadLine());
                PipelineUO = Convert.ToInt32(sr.ReadLine());
                PipelineEU = Convert.ToInt32(sr.ReadLine());
                RailCoal = Convert.ToInt32(sr.ReadLine());
                RailUO = Convert.ToInt32(sr.ReadLine());
                RailEU = Convert.ToInt32(sr.ReadLine());
                TruckCoal =Convert.ToInt32( sr.ReadLine());
                TruckUO =Convert.ToInt32( sr.ReadLine());
                TruckEU = Convert.ToInt32(sr.ReadLine());
                NGStationaryCombustion = Convert.ToInt32(sr.ReadLine());
                LiquifiedNaturalGasPlant =Convert.ToInt32( sr.ReadLine());
                FTDieselPlant = Convert.ToInt32(sr.ReadLine());
                NGElectricPowerPlant = Convert.ToInt32(sr.ReadLine());
                RefuelingStationUseofNorthAmericanNaturalGasForCNG =Convert.ToInt32( sr.ReadLine());
                RefuelingStationUseOfNonNorthAmericanNaturalGasForCNG =Convert.ToInt32( sr.ReadLine());
                //3
                SoybeanFarmingSD =  Convert.ToDouble(sr.ReadLine());
                SoyoilExtractionSD =  Convert.ToDouble(sr.ReadLine());
                SoyoilTransestrificationSD = Convert.ToDouble( sr.ReadLine());
                //4
                SelectionOfModelCalculatedOrUserInput = Convert.ToInt32(sr.ReadLine());
                ResidualOilUSAM =  Convert.ToDouble(sr.ReadLine());
                NaturalGasUSAM =  Convert.ToDouble(sr.ReadLine());
                CoalUSAM =  Convert.ToDouble(sr.ReadLine());
                NuclearPowerUSAM = Convert.ToDouble( sr.ReadLine());
                BiomassAndOtherUSAM =  Convert.ToDouble(sr.ReadLine());
                // 5
                VesselTypeID = sr.ReadLine();
                NumberOfEngines = Convert.ToInt32(sr.ReadLine());
                SingleEngineHP = Convert.ToInt32(sr.ReadLine());
                KWperHP =  Convert.ToDouble(sr.ReadLine());
                GALperBBL =  Convert.ToDouble(sr.ReadLine());
                BBLperTONNE =  Convert.ToDouble(sr.ReadLine());
                BTUperKWH =  Convert.ToDouble(sr.ReadLine());
                TotalTripDistanceInMiles = Convert.ToDouble( sr.ReadLine());
                TripTimeHours = Convert.ToDouble( sr.ReadLine());
                TripTimeMinutes = Convert.ToDouble( sr.ReadLine());
                POTIdle =  Convert.ToDouble(sr.ReadLine());
                POTManeuvering =  Convert.ToDouble(sr.ReadLine());
                POTPrecautionary =  Convert.ToDouble(sr.ReadLine());
                POTSlowCruise =  Convert.ToDouble(sr.ReadLine());
                POTFullCruise = Convert.ToDouble( sr.ReadLine());
                HPLFIdle = Convert.ToDouble( sr.ReadLine());
                HPLFManeuvering = Convert.ToDouble( sr.ReadLine());
                HPLFPrecautionary = Convert.ToDouble( sr.ReadLine());
                HPLFSlowCruise = Convert.ToDouble(sr.ReadLine());
                HPLFFullCruise = Convert.ToDouble(sr.ReadLine());
                SelectionOfModelCalculatedOrUserInputFuelConsumptionValues =Convert.ToInt32( sr.ReadLine());
                EngineEfficiency = Convert.ToDouble( sr.ReadLine());
                ResidualOilEE =  Convert.ToDouble(sr.ReadLine());
                LowSulfurDieselEE = Convert.ToDouble( sr.ReadLine());
                NaturalGasEE = Convert.ToDouble( sr.ReadLine());
                BiodieselEE =  Convert.ToDouble(sr.ReadLine());
                FischerTropschEE = Convert.ToDouble( sr.ReadLine());
                ConventionalDieselIdle =Convert.ToInt32( sr.ReadLine());
                ConventionalDieselManeuvering = Convert.ToInt32(sr.ReadLine());
                ConventionalDieselPrecautionary =Convert.ToInt32( sr.ReadLine());
                ConventionalDieselSlowCruise = Convert.ToInt32(sr.ReadLine());
                ConventionalDieselFullCruise =Convert.ToInt32( sr.ReadLine());
                ResidualOilIdle = Convert.ToInt32(sr.ReadLine());
                ResidualOilManeuvering = Convert.ToInt32(sr.ReadLine());
                ResidualOilPrecautionary = Convert.ToInt32(sr.ReadLine());
                ResidualOilSlowCruise = Convert.ToInt32(sr.ReadLine());
                ResidualOilFullCruise = Convert.ToInt32(sr.ReadLine());
                LowSulfurDieselIdle = Convert.ToInt32(sr.ReadLine());
                LowSulfurDieselManeuvering = Convert.ToInt32(sr.ReadLine());
                LowSulfurDieselPrecautionary = Convert.ToInt32(sr.ReadLine());
                LowSulfurDieselSlowCruise = Convert.ToInt32(sr.ReadLine());
                LowSulfurDieselFullCruise = Convert.ToInt32(sr.ReadLine());
                NaturalGasIdle = Convert.ToInt32(sr.ReadLine());
                NaturalGasManeuvering = Convert.ToInt32(sr.ReadLine());
                NaturalGasPrecautionary = Convert.ToInt32(sr.ReadLine());
                NaturalGasSlowCruise = Convert.ToInt32(sr.ReadLine());
                NaturalGasFullCruise = Convert.ToInt32(sr.ReadLine());
                BioDieselIdle = Convert.ToInt32(sr.ReadLine());
                BioDieselManeuvering = Convert.ToInt32(sr.ReadLine());
                BioDieselPrecautionary = Convert.ToInt32(sr.ReadLine());
                BioDieselSlowCruise = Convert.ToInt32(sr.ReadLine());
                BioDieselFullCruise = Convert.ToInt32(sr.ReadLine());
                FischerTropschIdle =Convert.ToInt32( sr.ReadLine());
                FischerTropschManeuvering = Convert.ToInt32(sr.ReadLine());
                FischerTropschPrecautionary = Convert.ToInt32(sr.ReadLine());
                FischerTropschSlowCruise = Convert.ToInt32(sr.ReadLine());
                FischerTropschFullCruise = Convert.ToInt32(sr.ReadLine());
                //6
                AuxillaryEngineFuelType = Convert.ToInt32(sr.ReadLine());
                NumberOfOnBoarAuxillaryEngines = Convert.ToInt32(sr.ReadLine());
                NumberOfAuxillaryEnginesInUse = Convert.ToInt32(sr.ReadLine());
                AuxillaryEnginesRatedHPperEngine = Convert.ToInt32(sr.ReadLine());
                PercentOfTripAuxillaryIsActive = Convert.ToDouble( sr.ReadLine());
                HPLoadFactorSingleEngine =  Convert.ToDouble(sr.ReadLine());
                SelectionOfModelCalculatedOrUserInputFuelConsumptionValues = Convert.ToInt32(sr.ReadLine());
                AuxillaryEngineEfficiency =  Convert.ToDouble(sr.ReadLine());
                AuxConventionalDieselFC = Convert.ToInt32(sr.ReadLine());
                AuxResidualOilFC = Convert.ToInt32(sr.ReadLine());
                AuxLowSulfurDieselFC = Convert.ToInt32(sr.ReadLine());
                AuxNaturalGasFC = Convert.ToInt32(sr.ReadLine());
                AuxBiodieselFC = Convert.ToInt32(sr.ReadLine());
                AuxFischerTropschFC = Convert.ToInt32(sr.ReadLine());
                //7
                VolumetricPercentageOfFTDieselinFTDBlend =  Convert.ToDouble(sr.ReadLine());
                VolumetricPercentageOfBiodieselInBiodieselBlend = Convert.ToDouble( sr.ReadLine());
                DieselForFischerTropschBlend = Convert.ToInt32(sr.ReadLine());
                DieselForBiodieselBlend = Convert.ToInt32(sr.ReadLine());//The Opening Logic, Used to load in the values from a saved file
                changeResults();
#endregion
                sr.Close();
            }
        }
        //This is what happens when you hit the save button in the menu strip
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            submitAll();
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "TEAMS Files | *.TEAMS";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(sf.FileName);
                #region The Saving Logic, where every variable that is inputted is saved into a file
                //1
                sr.WriteLine(EfficiencyForPetroleumRecovery);
                sr.WriteLine(ConventionalDieselSL);
                sr.WriteLine(ConventionalDieselRE);
                sr.WriteLine(LowSulfurDiesellSL);
                sr.WriteLine(LowSulfurDieselRE);
                sr.WriteLine(CrudeOilSL);
                sr.WriteLine(ResidualOilSL);
                sr.WriteLine(ResidualOilRE);
                //2
                sr.WriteLine(CompressedNaturalGasFS);
                sr.WriteLine(LiquifiedNaturalGasFS);
                sr.WriteLine(FistcherTropschDieselFS);
                sr.WriteLine(FischerTropschDieselPDNG);
                sr.WriteLine(FischerTopschDieselPDFG);
                sr.WriteLine(NANGSteamProductionCredit);
                sr.WriteLine(NNANGSteamProductionCredit);
                sr.WriteLine(NNAFGSteamProductionCredit);
                sr.WriteLine(LiquifiedNaturalGasNGEFP);
                sr.WriteLine(FischerTropschDieselNGEFP);
                sr.WriteLine(BoilingOffRatePerDayPP);
                sr.WriteLine(BoilingOffRatePerDayTPB);
                sr.WriteLine(BoilingOffRatePerDayBS);
                sr.WriteLine(BoilingOffRatePerDayDBR);
                sr.WriteLine(BoilingOffRatePerDayRSCP);
                sr.WriteLine(DurationOfStageDaysPP);
                sr.WriteLine(DurationOfStageDaysTPB);
                sr.WriteLine(DurationOfStageDaysBS);
                sr.WriteLine(DurationOfStageDaysDBR);
                sr.WriteLine(DurationOfStageDaysRSCP);
                sr.WriteLine(RateOfBoilingGasRecoveredPP);
                sr.WriteLine(RateOfBoilingGasRecoveredTPB);
                sr.WriteLine(RateOfBoilingGasRecoveredBS);
                sr.WriteLine(RateOfBoilingGasRecoveredDBR);
                sr.WriteLine(RateOfBoilingGasRecoveredRSCP);
                sr.WriteLine(OceanTankerCO);
                sr.WriteLine(OceanTankerRO);
                sr.WriteLine(OceanTankerUSD);
                sr.WriteLine(OceanTankerUSLSD);
                sr.WriteLine(BargeCO);
                sr.WriteLine(BargeRO);
                sr.WriteLine(BargeUSD);
                sr.WriteLine(BargeUSLSD);
                sr.WriteLine(PipelineCO);
                sr.WriteLine(PipelineRO);
                sr.WriteLine(PipelineUSD);
                sr.WriteLine(PipelineUSLSD);
                sr.WriteLine(RailCO);
                sr.WriteLine(RailRO);
                sr.WriteLine(RailUSD);
                sr.WriteLine(RailUSLSD);
                sr.WriteLine(TruckCO);
                sr.WriteLine(TruckRO);
                sr.WriteLine(TruckUSD);
                sr.WriteLine(TruckUSLSD);
                sr.WriteLine(OceanTankerNA);
                sr.WriteLine(OceanTankerNNA);
                sr.WriteLine(BargeNA);
                sr.WriteLine(BargeNNA);
                sr.WriteLine(PipelineNA);
                sr.WriteLine(PipelineNNA);
                sr.WriteLine(RailNA);
                sr.WriteLine(RailNNA);
                sr.WriteLine(TruckNA);
                sr.WriteLine(TruckNNA);
                sr.WriteLine(OceanTankerNAFTD);
                sr.WriteLine(OceanTankerNNAFTD);
                sr.WriteLine(OceanTankerNNAFGFTD);
                sr.WriteLine(BargeNAFTD);
                sr.WriteLine(BargeNNAFTD);
                sr.WriteLine(BargeNNAFGFTD);
                sr.WriteLine(PipelineNAFTD);
                sr.WriteLine(PipelineNNAFTD);
                sr.WriteLine(PipelineNNAFGFTD);
                sr.WriteLine(RailNAFTD);
                sr.WriteLine(RailNNAFTD);
                sr.WriteLine(RailNNAFGFTD);
                sr.WriteLine(TruckNAFTD);
                sr.WriteLine(TruckNNAFTD);
                sr.WriteLine(TruckNNAFGFTD);
                sr.WriteLine(BargeAGC);
                sr.WriteLine(BargeSB);
                sr.WriteLine(BargeBD);
                sr.WriteLine(PipelineAGC);
                sr.WriteLine(PipelineSB);
                sr.WriteLine(PipelineBD);
                sr.WriteLine(RailAGC);
                sr.WriteLine(RailSB);
                sr.WriteLine(RailBD);
                sr.WriteLine(TruckTransitAGC);
                sr.WriteLine(TruckTransitSB);
                sr.WriteLine(TruckTransitBD);
                sr.WriteLine(TruckDistributionAGC);
                sr.WriteLine(TruckDistributionSB);
                sr.WriteLine(TruckDistributionBD);
                sr.WriteLine(OceanTankerCoal);
                sr.WriteLine(OceanTankerUO);
                sr.WriteLine(OceanTankerEU);
                sr.WriteLine(BargeCoal);
                sr.WriteLine(BargeUO);
                sr.WriteLine(BargeEU);
                sr.WriteLine(PipelineCoal);
                sr.WriteLine(PipelineUO);
                sr.WriteLine(PipelineEU);
                sr.WriteLine(RailCoal);
                sr.WriteLine(RailUO);
                sr.WriteLine(RailEU);
                sr.WriteLine(TruckCoal);
                sr.WriteLine(TruckUO);
                sr.WriteLine(TruckEU);
                sr.WriteLine(NGStationaryCombustion);
                sr.WriteLine(LiquifiedNaturalGasPlant);
                sr.WriteLine(FTDieselPlant);
                sr.WriteLine(NGElectricPowerPlant);
                sr.WriteLine(RefuelingStationUseofNorthAmericanNaturalGasForCNG);
                sr.WriteLine(RefuelingStationUseOfNonNorthAmericanNaturalGasForCNG);
                //3
                sr.WriteLine(SoybeanFarmingSD);
                sr.WriteLine(SoyoilExtractionSD);
                sr.WriteLine(SoyoilTransestrificationSD);
                //4
                sr.WriteLine(SelectionOfModelCalculatedOrUserInput);
                sr.WriteLine(ResidualOilUSAM);
                sr.WriteLine(NaturalGasUSAM);
                sr.WriteLine(CoalUSAM);
                sr.WriteLine(NuclearPowerUSAM);
                sr.WriteLine(BiomassAndOtherUSAM);
                // 5
                sr.WriteLine(VesselTypeID);
                sr.WriteLine(NumberOfEngines);
                sr.WriteLine(SingleEngineHP);
                sr.WriteLine(KWperHP);
                sr.WriteLine(GALperBBL);
                sr.WriteLine(BBLperTONNE);
                sr.WriteLine(BTUperKWH);
                sr.WriteLine(TotalTripDistanceInMiles);
                sr.WriteLine(TripTimeHours);
                sr.WriteLine(TripTimeMinutes);
                sr.WriteLine(POTIdle);
                sr.WriteLine(POTManeuvering);
                sr.WriteLine(POTPrecautionary);
                sr.WriteLine(POTSlowCruise);
                sr.WriteLine(POTFullCruise);
                sr.WriteLine(HPLFIdle);
                sr.WriteLine(HPLFManeuvering);
                sr.WriteLine(HPLFPrecautionary);
                sr.WriteLine(HPLFSlowCruise);
                sr.WriteLine(HPLFFullCruise);
                sr.WriteLine(SelectionOfModelCalculatedOrUserInputFuelConsumptionValues);
                sr.WriteLine(EngineEfficiency);
                sr.WriteLine(ResidualOilEE);
                sr.WriteLine(LowSulfurDieselEE);
                sr.WriteLine(NaturalGasEE);
                sr.WriteLine(BiodieselEE);
                sr.WriteLine(FischerTropschEE);
                sr.WriteLine(ConventionalDieselIdle);
                sr.WriteLine(ConventionalDieselManeuvering);
                sr.WriteLine(ConventionalDieselPrecautionary);
                sr.WriteLine(ConventionalDieselSlowCruise);
                sr.WriteLine(ConventionalDieselFullCruise);
                sr.WriteLine(ResidualOilIdle);
                sr.WriteLine(ResidualOilManeuvering);
                sr.WriteLine(ResidualOilPrecautionary);
                sr.WriteLine(ResidualOilSlowCruise);
                sr.WriteLine(ResidualOilFullCruise);
                sr.WriteLine(LowSulfurDieselIdle);
                sr.WriteLine(LowSulfurDieselManeuvering);
                sr.WriteLine(LowSulfurDieselPrecautionary);
                sr.WriteLine(LowSulfurDieselSlowCruise);
                sr.WriteLine(LowSulfurDieselFullCruise);
                sr.WriteLine(NaturalGasIdle);
                sr.WriteLine(NaturalGasManeuvering);
                sr.WriteLine(NaturalGasPrecautionary);
                sr.WriteLine(NaturalGasSlowCruise);
                sr.WriteLine(NaturalGasFullCruise);
                sr.WriteLine(BioDieselIdle);
                sr.WriteLine(BioDieselManeuvering);
                sr.WriteLine(BioDieselPrecautionary);
                sr.WriteLine(BioDieselSlowCruise);
                sr.WriteLine(BioDieselFullCruise);
                sr.WriteLine(FischerTropschIdle);
                sr.WriteLine(FischerTropschManeuvering);
                sr.WriteLine(FischerTropschPrecautionary);
                sr.WriteLine(FischerTropschSlowCruise);
                sr.WriteLine(FischerTropschFullCruise);
                //6
                sr.WriteLine(AuxillaryEngineFuelType);
                sr.WriteLine(NumberOfOnBoarAuxillaryEngines);
                sr.WriteLine(NumberOfAuxillaryEnginesInUse);
                sr.WriteLine(AuxillaryEnginesRatedHPperEngine);
                sr.WriteLine(PercentOfTripAuxillaryIsActive);
                sr.WriteLine(HPLoadFactorSingleEngine);
                sr.WriteLine(SelectionOfModelCalculatedOrUserInputFuelConsumptionValues);
                sr.WriteLine(AuxillaryEngineEfficiency);
                sr.WriteLine(AuxConventionalDieselFC);
                sr.WriteLine(AuxResidualOilFC);
                sr.WriteLine(AuxLowSulfurDieselFC);
                sr.WriteLine(AuxNaturalGasFC);
                sr.WriteLine(AuxBiodieselFC);
                sr.WriteLine(AuxFischerTropschFC);
                //7
                sr.WriteLine(VolumetricPercentageOfFTDieselinFTDBlend);
                sr.WriteLine(VolumetricPercentageOfBiodieselInBiodieselBlend);
                sr.WriteLine(DieselForFischerTropschBlend);
                sr.WriteLine(DieselForBiodieselBlend);
#endregion
                MessageBox.Show("Successfully Saved " + sf.FileName);
                sr.Close();
            }
        }

        private void doThingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            submitAll();
        }


        private void editGREETVariablesToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            GVE.Show();
        }

        private void enableAdvancedUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (advanced == false)
            {
                MessageBox.Show("By selecting advanced user capabilities, you are rendering the data supplied by the GREET database null until you edit it within GREET yourself to your specifications. This is only for advanced users with an in depth knowledge base of the variables they need to edit in order to have TEAMS run a simulation.");
                advanced = true;
                pullFromGREET();
                enableAdvancedUserToolStripMenuItem.BackColor = Color.Green;
                enableAdvancedUserToolStripMenuItem.Text = "Disable Advanced User";
                u = new Update(this);
                u.Show();
            }
            else if (advanced == true)
            {
                advanced = false;
                pullFromGREET();
                enableAdvancedUserToolStripMenuItem.BackColor = Color.Yellow;
                enableAdvancedUserToolStripMenuItem.Text = "Enable Advanced User";
                u.Close();
            }
        }

        private void TEAMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            u.Close();
            GVE.Close();
        }
    }
}
