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
using PlugInsInterfaces.DataTypes.Technology;
using TEAMSModule;

namespace WindowsApplication1
{
    public partial class TEAMS : Form
    {
        //Input Variables
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
        //6.1 Auxiliary Engine Fuel Type to Present On Results Sheet;
        //1 = Conventional Diesel 2 = Residual Oil 3 = Low Sulfur Diesel 4 = Natural gas 5 = Biodiesel 6 = Fischer Tropsch Diesel
        public int AuxiliaryEngineFuelType = 1;

        //6.2 Auxiliary Engine Variables
        public int NumberOfOnBoarAuxiliaryEngines;
        public int NumberOfAuxiliaryEnginesInUse;
        public int AuxiliaryEnginesRatedHPperEngine;
        public int TotalOnboardAUxHP;

        //6.3 Auxiliary Engine Characterization (Conventional Diesel as Baseline Fuel)
        public double PercentOfTripAuxiliaryIsActive;
        public double TimeAuxActiveHours;
        public double HPLoadFactorSingleEngine;
        public double ActiveHPPerAuxEngine;
        public double TotalAuxEnergyProduction;

        //6.4a Selection of Medel Calculated or User Input Fuel Consumption Values Conventional Diesel as Baseline Fuel
        //1 = Simlate using GPH derived from User-Entered Auxiliary engine specifications 2 = Simlate using user entered GPH
        public int SelectionOfModelCalculatedOrUserInputFuelConsumptionValues6 = 1;

        //6.4b Calculation of Auxiliary Engine Fuel use Using Conventional Diesel as Baseline Fuel
        public double AuxiliaryEngineEfficiency;
        public double AuxEngineKWHoutperTrip;
        public double AuxEngineMMBTUoutperTrip;
        public double AuxEngineMMBTUinperTrip;
        public double AuxEngineGALLONperTrip;

        //6.4c Calculation of Auxiliary Engine Fuel Use Using Alternative Fuels
        //EE = Engine Efficiency AuxMMBTU = Auxiliary MMTBUin/Trip EAFC = Auxiliary Engine Alternativee Fuel Consumption
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

        //6.4d  Auxiliary Engine Fuel Consumption (Only if you're using user entered GPH for your simulation
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

        //Program Variables
        public bool five_complete;
        public bool six_complete;
        public bool runSimActive;
        #region Greet Variables
        //GREET Variables
        //btu/Gal

        #region Results Variables
        public double CD_WTP_TE;
        public double CD_WTP_FF;
        public double CD_WTP_CF;
        public double CD_WTP_NG;
        public double CD_WTP_PF;
        public double CD_WTP_VOC;
        public double CD_WTP_CO;
        public double CD_WTP_NOX;
        public double CD_WTP_PM10;
        public double CD_WTP_PM25;
        public double CD_WTP_SOX;
        public double CD_WTP_CH4;
        public double CD_WTP_CO2;
        public double CD_WTP_N2O;
        public double CD_WTP_PM10_TBW;
        public double CD_WTP_PM25_TBW;
        public double CD_WTP_PM25_CO2Biogenic;

        public double CD_VO_TE;
        public double CD_VO_FF;
        public double CD_VO_CF;
        public double CD_VO_NG;
        public double CD_VO_PF;
        public double CD_VO_VOC;
        public double CD_VO_CO;
        public double CD_VO_NOX;
        public double CD_VO_PM10;
        public double CD_VO_PM25;
        public double CD_VO_SOX;
        public double CD_VO_CH4;
        public double CD_VO_CO2;
        public double CD_VO_N2O;
        public double CD_VO_PM10_TBW;
        public double CD_VO_PM25_TBW;
        public double CD_VO_PM25_CO2Biogenic;

        public double CD_Total_TE;
        public double CD_Total_FF;
        public double CD_Total_CF;
        public double CD_Total_NG;
        public double CD_Total_PF;
        public double CD_Total_VOC;
        public double CD_Total_CO;
        public double CD_Total_NOX;
        public double CD_Total_PM10;
        public double CD_Total_PM25;
        public double CD_Total_SOX;
        public double CD_Total_CH4;
        public double CD_Total_CO2;
        public double CD_Total_N2O;
        public double CD_Total_PM10_TBW;
        public double CD_Total_PM25_TBW;
        public double CD_Total_PM25_CO2Biogenic;

        public double RO_WTP_TE;
        public double RO_WTP_FF;
        public double RO_WTP_CF;
        public double RO_WTP_NG;
        public double RO_WTP_PF;
        public double RO_WTP_VOC;
        public double RO_WTP_CO;
        public double RO_WTP_NOX;
        public double RO_WTP_PM10;
        public double RO_WTP_PM25;
        public double RO_WTP_SOX;
        public double RO_WTP_CH4;
        public double RO_WTP_CO2;
        public double RO_WTP_N2O;
        public double RO_WTP_PM10_TBW;
        public double RO_WTP_PM25_TBW;
        public double RO_WTP_PM25_CO2Biogenic;

        public double RO_VO_TE;
        public double RO_VO_FF;
        public double RO_VO_CF;
        public double RO_VO_NG;
        public double RO_VO_PF;
        public double RO_VO_VOC;
        public double RO_VO_CO;
        public double RO_VO_NOX;
        public double RO_VO_PM10;
        public double RO_VO_PM25;
        public double RO_VO_SOX;
        public double RO_VO_CH4;
        public double RO_VO_CO2;
        public double RO_VO_N2O;
        public double RO_VO_PM10_TBW;
        public double RO_VO_PM25_TBW;
        public double RO_VO_PM25_CO2Biogenic;

        public double RO_Total_TE;
        public double RO_Total_FF;
        public double RO_Total_CF;
        public double RO_Total_NG;
        public double RO_Total_PF;
        public double RO_Total_VOC;
        public double RO_Total_CO;
        public double RO_Total_NOX;
        public double RO_Total_PM10;
        public double RO_Total_PM25;
        public double RO_Total_SOX;
        public double RO_Total_CH4;
        public double RO_Total_CO2;
        public double RO_Total_N2O;
        public double RO_Total_PM10_TBW;
        public double RO_Total_PM25_TBW;
        public double RO_Total_PM25_CO2Biogenic;

        public double LSD_WTP_TE;
        public double LSD_WTP_FF;
        public double LSD_WTP_CF;
        public double LSD_WTP_NG;
        public double LSD_WTP_PF;
        public double LSD_WTP_VOC;
        public double LSD_WTP_CO;
        public double LSD_WTP_NOX;
        public double LSD_WTP_PM10;
        public double LSD_WTP_PM25;
        public double LSD_WTP_SOX;
        public double LSD_WTP_CH4;
        public double LSD_WTP_CO2;
        public double LSD_WTP_N2O;
        public double LSD_WTP_PM10_TBW;
        public double LSD_WTP_PM25_TBW;
        public double LSD_WTP_PM25_CO2Biogenic;

        public double LSD_VO_TE;
        public double LSD_VO_FF;
        public double LSD_VO_CF;
        public double LSD_VO_NG;
        public double LSD_VO_PF;
        public double LSD_VO_VOC;
        public double LSD_VO_CO;
        public double LSD_VO_NOX;
        public double LSD_VO_PM10;
        public double LSD_VO_PM25;
        public double LSD_VO_SOX;
        public double LSD_VO_CH4;
        public double LSD_VO_CO2;
        public double LSD_VO_N2O;
        public double LSD_VO_PM10_TBW;
        public double LSD_VO_PM25_TBW;
        public double LSD_VO_PM25_CO2Biogenic;

        public double LSD_Total_TE;
        public double LSD_Total_FF;
        public double LSD_Total_CF;
        public double LSD_Total_NG;
        public double LSD_Total_PF;
        public double LSD_Total_VOC;
        public double LSD_Total_CO;
        public double LSD_Total_NOX;
        public double LSD_Total_PM10;
        public double LSD_Total_PM25;
        public double LSD_Total_SOX;
        public double LSD_Total_CH4;
        public double LSD_Total_CO2;
        public double LSD_Total_N2O;
        public double LSD_Total_PM10_TBW;
        public double LSD_Total_PM25_TBW;
        public double LSD_Total_PM25_CO2Biogenic;

        public double NG_WTP_TE;
        public double NG_WTP_FF;
        public double NG_WTP_CF;
        public double NG_WTP_NG;
        public double NG_WTP_PF;
        public double NG_WTP_VOC;
        public double NG_WTP_CO;
        public double NG_WTP_NOX;
        public double NG_WTP_PM10;
        public double NG_WTP_PM25;
        public double NG_WTP_SOX;
        public double NG_WTP_CH4;
        public double NG_WTP_CO2;
        public double NG_WTP_N2O;
        public double NG_WTP_PM10_TBW;
        public double NG_WTP_PM25_TBW;
        public double NG_WTP_PM25_CO2Biogenic;

        public double NG_VO_TE;
        public double NG_VO_FF;
        public double NG_VO_CF;
        public double NG_VO_NG;
        public double NG_VO_PF;
        public double NG_VO_VOC;
        public double NG_VO_CO;
        public double NG_VO_NOX;
        public double NG_VO_PM10;
        public double NG_VO_PM25;
        public double NG_VO_SOX;
        public double NG_VO_CH4;
        public double NG_VO_CO2;
        public double NG_VO_N2O;
        public double NG_VO_PM10_TBW;
        public double NG_VO_PM25_TBW;
        public double NG_VO_PM25_CO2Biogenic;

        public double NG_Total_TE;
        public double NG_Total_FF;
        public double NG_Total_CF;
        public double NG_Total_NG;
        public double NG_Total_PF;
        public double NG_Total_VOC;
        public double NG_Total_CO;
        public double NG_Total_NOX;
        public double NG_Total_PM10;
        public double NG_Total_PM25;
        public double NG_Total_SOX;
        public double NG_Total_CH4;
        public double NG_Total_CO2;
        public double NG_Total_N2O;
        public double NG_Total_PM10_TBW;
        public double NG_Total_PM25_TBW;
        public double NG_Total_PM25_CO2Biogenic;

        public double BD_WTP_TE;
        public double BD_WTP_FF;
        public double BD_WTP_CF;
        public double BD_WTP_NG;
        public double BD_WTP_PF;
        public double BD_WTP_VOC;
        public double BD_WTP_CO;
        public double BD_WTP_NOX;
        public double BD_WTP_PM10;
        public double BD_WTP_PM25;
        public double BD_WTP_SOX;
        public double BD_WTP_CH4;
        public double BD_WTP_CO2;
        public double BD_WTP_N2O;
        public double BD_WTP_PM10_TBW;
        public double BD_WTP_PM25_TBW;
        public double BD_WTP_PM25_CO2Biogenic;

        public double BD_VO_TE;
        public double BD_VO_FF;
        public double BD_VO_CF;
        public double BD_VO_NG;
        public double BD_VO_PF;
        public double BD_VO_VOC;
        public double BD_VO_CO;
        public double BD_VO_NOX;
        public double BD_VO_PM10;
        public double BD_VO_PM25;
        public double BD_VO_SOX;
        public double BD_VO_CH4;
        public double BD_VO_CO2;
        public double BD_VO_N2O;
        public double BD_VO_PM10_TBW;
        public double BD_VO_PM25_TBW;
        public double BD_VO_PM25_CO2Biogenic;

        public double BD_Total_TE;
        public double BD_Total_FF;
        public double BD_Total_CF;
        public double BD_Total_NG;
        public double BD_Total_PF;
        public double BD_Total_VOC;
        public double BD_Total_CO;
        public double BD_Total_NOX;
        public double BD_Total_PM10;
        public double BD_Total_PM25;
        public double BD_Total_SOX;
        public double BD_Total_CH4;
        public double BD_Total_CO2;
        public double BD_Total_N2O;
        public double BD_Total_PM10_TBW;
        public double BD_Total_PM25_TBW;
        public double BD_Total_PM25_CO2Biogenic;

        public double FTD_WTP_TE;
        public double FTD_WTP_FF;
        public double FTD_WTP_CF;
        public double FTD_WTP_NG;
        public double FTD_WTP_PF;
        public double FTD_WTP_VOC;
        public double FTD_WTP_CO;
        public double FTD_WTP_NOX;
        public double FTD_WTP_PM10;
        public double FTD_WTP_PM25;
        public double FTD_WTP_SOX;
        public double FTD_WTP_CH4;
        public double FTD_WTP_CO2;
        public double FTD_WTP_N2O;
        public double FTD_WTP_PM10_TBW;
        public double FTD_WTP_PM25_TBW;
        public double FTD_WTP_PM25_CO2Biogenic;

        public double FTD_VO_TE;
        public double FTD_VO_FF;
        public double FTD_VO_CF;
        public double FTD_VO_NG;
        public double FTD_VO_PF;
        public double FTD_VO_VOC;
        public double FTD_VO_CO;
        public double FTD_VO_NOX;
        public double FTD_VO_PM10;
        public double FTD_VO_PM25;
        public double FTD_VO_SOX;
        public double FTD_VO_CH4;
        public double FTD_VO_CO2;
        public double FTD_VO_N2O;
        public double FTD_VO_PM10_TBW;
        public double FTD_VO_PM25_TBW;
        public double FTD_VO_PM25_CO2Biogenic;

        public double FTD_Total_TE;
        public double FTD_Total_FF;
        public double FTD_Total_CF;
        public double FTD_Total_NG;
        public double FTD_Total_PF;
        public double FTD_Total_VOC;
        public double FTD_Total_CO;
        public double FTD_Total_NOX;
        public double FTD_Total_PM10;
        public double FTD_Total_PM25;
        public double FTD_Total_SOX;
        public double FTD_Total_CH4;
        public double FTD_Total_CO2;
        public double FTD_Total_N2O;
        public double FTD_Total_PM10_TBW;
        public double FTD_Total_PM25_TBW;
        public double FTD_Total_PM25_CO2Biogenic;
        #endregion
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
        #region ID Variables
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
        #endregion
        #region Emissions Variables
        public double NOX_gphphr_out;
        public double CO_gphphr_out;
        public double VOC_gphphr_out;
        public double PM10_gphphr_out;
        public double PM25_gphphr_out;

        #endregion
        public Update u;
        public Fuel_Specs GVE;
        public GREETFormattedResults gfr;
        public TEAMS()
        {
            InitializeComponent();
            pullFromGREET();
            useDefaults();
            changeResults();
            GVE = new Fuel_Specs(this);
            u = new Update(this);
        }
        /// <summary>
        /// Grabs all of the data needed to do calculations from GREET resources, pathways, and mixes.
        /// </summary>
        public void pullFromGREET()
        {
            IGDataDictionary<int, IResource> resources = ResultsAccess.controler.CurrentProject.Data.Resources;
            IGDataDictionary<int, IPathway> pathways = ResultsAccess.controler.CurrentProject.Data.Pathways;
            IGDataDictionary<int, IMix> mixes = ResultsAccess.controler.CurrentProject.Data.Mixes;
            //These are the Fuel_Specs information being replicated as needed
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
                IData data = ResultsAccess.controler.CurrentProject.Data;
                IResults path = myPathway.GetUpstreamResults(data).ElementAt(0).Value;
                CD_Total_TE = (path.LifeCycleResources().ElementAt(13).Value.Value + path.LifeCycleResources().ElementAt(12).Value.Value + path.LifeCycleResources().ElementAt(11).Value.Value + path.LifeCycleResources().ElementAt(10).Value.Value + path.LifeCycleResources().ElementAt(9).Value.Value + path.LifeCycleResources().ElementAt(8).Value.Value + path.LifeCycleResources().ElementAt(7).Value.Value + path.LifeCycleResources().ElementAt(6).Value.Value + path.LifeCycleResources().ElementAt(5).Value.Value + path.LifeCycleResources().ElementAt(4).Value.Value + path.LifeCycleResources().ElementAt(3).Value.Value + path.LifeCycleResources().ElementAt(2).Value.Value + path.LifeCycleResources().ElementAt(1).Value.Value + path.LifeCycleResources().ElementAt(0).Value.Value);
                CD_WTP_TE = (CD_Total_TE - 1);
                CD_VO_TE = 1;
                CD_Total_FF = path.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                CD_Total_CF = path.LifeCycleResourcesGroups(data).ElementAt(3).Value.Value;
                CD_Total_NG = path.LifeCycleResourcesGroups(data).ElementAt(1).Value.Value;
                CD_Total_PF = path.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;
                CD_WTP_VOC = path.LifeCycleEmissions().ElementAt(0).Value.Value;
                CD_WTP_CO = path.LifeCycleEmissions().ElementAt(1).Value.Value;
                CD_WTP_NOX = path.LifeCycleEmissions().ElementAt(2).Value.Value;
                CD_WTP_PM10 = path.LifeCycleEmissions().ElementAt(3).Value.Value;
                CD_WTP_PM25 = path.LifeCycleEmissions().ElementAt(4).Value.Value;
                CD_WTP_SOX = path.LifeCycleEmissions().ElementAt(5).Value.Value;
                CD_WTP_CH4 = path.LifeCycleEmissions().ElementAt(6).Value.Value;
                CD_WTP_N2O = path.LifeCycleEmissions().ElementAt(7).Value.Value;
                CD_WTP_CO2 = path.LifeCycleEmissions().ElementAt(8).Value.Value;
                CD_WTP_PM25_CO2Biogenic = path.LifeCycleEmissions().ElementAt(9).Value.Value;
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
                data = ResultsAccess.controler.CurrentProject.Data;
                path = myPathway.GetUpstreamResults(data).ElementAt(0).Value;
                LSD_Total_TE = (path.LifeCycleResources().ElementAt(13).Value.Value + path.LifeCycleResources().ElementAt(12).Value.Value + path.LifeCycleResources().ElementAt(11).Value.Value + path.LifeCycleResources().ElementAt(10).Value.Value + path.LifeCycleResources().ElementAt(9).Value.Value + path.LifeCycleResources().ElementAt(8).Value.Value + path.LifeCycleResources().ElementAt(7).Value.Value + path.LifeCycleResources().ElementAt(6).Value.Value + path.LifeCycleResources().ElementAt(5).Value.Value + path.LifeCycleResources().ElementAt(4).Value.Value + path.LifeCycleResources().ElementAt(3).Value.Value + path.LifeCycleResources().ElementAt(2).Value.Value + path.LifeCycleResources().ElementAt(1).Value.Value + path.LifeCycleResources().ElementAt(0).Value.Value);
                LSD_WTP_TE = (LSD_Total_TE - 1);
                LSD_VO_TE = 1;
                LSD_Total_FF = path.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                LSD_Total_CF = path.LifeCycleResourcesGroups(data).ElementAt(3).Value.Value;
                LSD_Total_NG = path.LifeCycleResourcesGroups(data).ElementAt(1).Value.Value;
                LSD_Total_PF = path.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;
                LSD_WTP_VOC = path.LifeCycleEmissions().ElementAt(0).Value.Value;
                LSD_WTP_CO = path.LifeCycleEmissions().ElementAt(1).Value.Value;
                LSD_WTP_NOX = path.LifeCycleEmissions().ElementAt(2).Value.Value;
                LSD_WTP_PM10 = path.LifeCycleEmissions().ElementAt(3).Value.Value;
                LSD_WTP_PM25 = path.LifeCycleEmissions().ElementAt(4).Value.Value;
                LSD_WTP_SOX = path.LifeCycleEmissions().ElementAt(5).Value.Value;
                LSD_WTP_CH4 = path.LifeCycleEmissions().ElementAt(6).Value.Value;
                LSD_WTP_N2O = path.LifeCycleEmissions().ElementAt(7).Value.Value;
                LSD_WTP_CO2 = path.LifeCycleEmissions().ElementAt(8).Value.Value;
                LSD_WTP_PM25_CO2Biogenic = path.LifeCycleEmissions().ElementAt(9).Value.Value;
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
                data = ResultsAccess.controler.CurrentProject.Data;
                path = myPathway.GetUpstreamResults(data).ElementAt(0).Value;
                RO_Total_TE = (path.LifeCycleResources().ElementAt(13).Value.Value + path.LifeCycleResources().ElementAt(12).Value.Value + path.LifeCycleResources().ElementAt(11).Value.Value + path.LifeCycleResources().ElementAt(10).Value.Value + path.LifeCycleResources().ElementAt(9).Value.Value + path.LifeCycleResources().ElementAt(8).Value.Value + path.LifeCycleResources().ElementAt(7).Value.Value + path.LifeCycleResources().ElementAt(6).Value.Value + path.LifeCycleResources().ElementAt(5).Value.Value + path.LifeCycleResources().ElementAt(4).Value.Value + path.LifeCycleResources().ElementAt(3).Value.Value + path.LifeCycleResources().ElementAt(2).Value.Value + path.LifeCycleResources().ElementAt(1).Value.Value + path.LifeCycleResources().ElementAt(0).Value.Value);
                RO_WTP_TE = (RO_Total_TE - 1);
                RO_VO_TE = 1;
                RO_Total_FF = path.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                RO_Total_CF = path.LifeCycleResourcesGroups(data).ElementAt(3).Value.Value;
                RO_Total_NG = path.LifeCycleResourcesGroups(data).ElementAt(1).Value.Value;
                RO_Total_PF = path.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;
                RO_WTP_VOC = path.LifeCycleEmissions().ElementAt(0).Value.Value;
                RO_WTP_CO = path.LifeCycleEmissions().ElementAt(1).Value.Value;
                RO_WTP_NOX = path.LifeCycleEmissions().ElementAt(2).Value.Value;
                RO_WTP_PM10 = path.LifeCycleEmissions().ElementAt(3).Value.Value;
                RO_WTP_PM25 = path.LifeCycleEmissions().ElementAt(4).Value.Value;
                RO_WTP_SOX = path.LifeCycleEmissions().ElementAt(5).Value.Value;
                RO_WTP_CH4 = path.LifeCycleEmissions().ElementAt(6).Value.Value;
                RO_WTP_N2O = path.LifeCycleEmissions().ElementAt(7).Value.Value;
                RO_WTP_CO2 = path.LifeCycleEmissions().ElementAt(8).Value.Value;
                RO_WTP_PM25_CO2Biogenic = path.LifeCycleEmissions().ElementAt(9).Value.Value;

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
                data = ResultsAccess.controler.CurrentProject.Data;
                path = myPathway.GetUpstreamResults(data).ElementAt(0).Value;

                NG_Total_TE = (path.LifeCycleResources().ElementAt(13).Value.Value + path.LifeCycleResources().ElementAt(12).Value.Value + path.LifeCycleResources().ElementAt(11).Value.Value + path.LifeCycleResources().ElementAt(10).Value.Value + path.LifeCycleResources().ElementAt(9).Value.Value + path.LifeCycleResources().ElementAt(8).Value.Value + path.LifeCycleResources().ElementAt(7).Value.Value + path.LifeCycleResources().ElementAt(6).Value.Value + path.LifeCycleResources().ElementAt(5).Value.Value + path.LifeCycleResources().ElementAt(4).Value.Value + path.LifeCycleResources().ElementAt(3).Value.Value + path.LifeCycleResources().ElementAt(2).Value.Value + path.LifeCycleResources().ElementAt(1).Value.Value + path.LifeCycleResources().ElementAt(0).Value.Value);
                NG_WTP_TE = (NG_Total_TE - 1);
                NG_VO_TE = 1;
                NG_Total_FF = path.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;
                NG_Total_PF = path.LifeCycleResourcesGroups(data).ElementAt(1).Value.Value;
                NG_Total_CF = path.LifeCycleResourcesGroups(data).ElementAt(4).Value.Value;
                NG_Total_NG = path.LifeCycleResourcesGroups(data).ElementAt(3).Value.Value;
                NG_WTP_VOC = path.LifeCycleEmissions().ElementAt(0).Value.Value;
                NG_WTP_CO = path.LifeCycleEmissions().ElementAt(1).Value.Value;
                NG_WTP_NOX = path.LifeCycleEmissions().ElementAt(2).Value.Value;
                NG_WTP_PM10 = path.LifeCycleEmissions().ElementAt(3).Value.Value;
                NG_WTP_PM25 = path.LifeCycleEmissions().ElementAt(4).Value.Value;
                NG_WTP_SOX = path.LifeCycleEmissions().ElementAt(5).Value.Value;
                NG_WTP_CH4 = path.LifeCycleEmissions().ElementAt(6).Value.Value;
                NG_WTP_N2O = path.LifeCycleEmissions().ElementAt(7).Value.Value;
                NG_WTP_CO2 = path.LifeCycleEmissions().ElementAt(8).Value.Value;
                NG_WTP_PM25_CO2Biogenic = path.LifeCycleEmissions().ElementAt(9).Value.Value;

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
                data = ResultsAccess.controler.CurrentProject.Data;
                path = myPathway.GetUpstreamResults(data).ElementAt(0).Value;
                BD_Total_TE = (path.LifeCycleResources().ElementAt(13).Value.Value + path.LifeCycleResources().ElementAt(12).Value.Value + path.LifeCycleResources().ElementAt(11).Value.Value + path.LifeCycleResources().ElementAt(10).Value.Value + path.LifeCycleResources().ElementAt(9).Value.Value + path.LifeCycleResources().ElementAt(8).Value.Value + path.LifeCycleResources().ElementAt(7).Value.Value + path.LifeCycleResources().ElementAt(6).Value.Value + path.LifeCycleResources().ElementAt(5).Value.Value + path.LifeCycleResources().ElementAt(4).Value.Value + path.LifeCycleResources().ElementAt(3).Value.Value + path.LifeCycleResources().ElementAt(2).Value.Value + path.LifeCycleResources().ElementAt(1).Value.Value + path.LifeCycleResources().ElementAt(0).Value.Value);
                BD_WTP_TE = BD_Total_TE;
                BD_VO_TE = 1;
                BD_Total_FF = path.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                BD_Total_CF = path.LifeCycleResourcesGroups(data).ElementAt(3).Value.Value;
                BD_Total_PF = path.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;
                BD_Total_NG = path.LifeCycleResourcesGroups(data).ElementAt(1).Value.Value;
                BD_WTP_VOC = path.LifeCycleEmissions().ElementAt(0).Value.Value;
                BD_WTP_CO = path.LifeCycleEmissions().ElementAt(1).Value.Value;
                BD_WTP_NOX = path.LifeCycleEmissions().ElementAt(2).Value.Value;
                BD_WTP_PM10 = path.LifeCycleEmissions().ElementAt(3).Value.Value;
                BD_WTP_PM25 = path.LifeCycleEmissions().ElementAt(4).Value.Value;
                BD_WTP_SOX = path.LifeCycleEmissions().ElementAt(5).Value.Value;
                BD_WTP_CH4 = path.LifeCycleEmissions().ElementAt(6).Value.Value;
                BD_WTP_N2O = path.LifeCycleEmissions().ElementAt(7).Value.Value;
                BD_WTP_CO2 = path.LifeCycleEmissions().ElementAt(8).Value.Value;
                BD_WTP_PM25_CO2Biogenic = path.LifeCycleEmissions().ElementAt(9).Value.Value;
                //MessageBox.Show(path.LifeCycleEmissions().ElementAt(0).Value.Value.ToString());
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
                data = ResultsAccess.controler.CurrentProject.Data;
                path = myPathway.GetUpstreamResults(data).ElementAt(0).Value;
                FTD_Total_TE = (path.LifeCycleResources().ElementAt(13).Value.Value + path.LifeCycleResources().ElementAt(12).Value.Value + path.LifeCycleResources().ElementAt(11).Value.Value + path.LifeCycleResources().ElementAt(10).Value.Value + path.LifeCycleResources().ElementAt(9).Value.Value + path.LifeCycleResources().ElementAt(8).Value.Value + path.LifeCycleResources().ElementAt(7).Value.Value + path.LifeCycleResources().ElementAt(6).Value.Value + path.LifeCycleResources().ElementAt(5).Value.Value + path.LifeCycleResources().ElementAt(4).Value.Value + path.LifeCycleResources().ElementAt(3).Value.Value + path.LifeCycleResources().ElementAt(2).Value.Value + path.LifeCycleResources().ElementAt(1).Value.Value + path.LifeCycleResources().ElementAt(0).Value.Value);
                FTD_WTP_TE = (FTD_Total_TE - 1);
                FTD_VO_TE = 1;
                FTD_Total_FF = path.LifeCycleResourcesGroups(data).ElementAt(0).Value.Value;
                FTD_Total_CF = path.LifeCycleResourcesGroups(data).ElementAt(3).Value.Value;
                FTD_Total_PF = path.LifeCycleResourcesGroups(data).ElementAt(2).Value.Value;
                FTD_Total_NG = path.LifeCycleResourcesGroups(data).ElementAt(1).Value.Value;
                FTD_WTP_VOC = path.LifeCycleEmissions().ElementAt(0).Value.Value;
                FTD_WTP_CO = path.LifeCycleEmissions().ElementAt(1).Value.Value;
                FTD_WTP_NOX = path.LifeCycleEmissions().ElementAt(2).Value.Value;
                FTD_WTP_PM10 = path.LifeCycleEmissions().ElementAt(3).Value.Value;
                FTD_WTP_PM25 = path.LifeCycleEmissions().ElementAt(4).Value.Value;
                FTD_WTP_SOX = path.LifeCycleEmissions().ElementAt(5).Value.Value;
                FTD_WTP_CH4 = path.LifeCycleEmissions().ElementAt(6).Value.Value;
                FTD_WTP_N2O = path.LifeCycleEmissions().ElementAt(7).Value.Value;
                FTD_WTP_CO2 = path.LifeCycleEmissions().ElementAt(8).Value.Value;
                FTD_WTP_PM25_CO2Biogenic = path.LifeCycleEmissions().ElementAt(9).Value.Value;
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
                data = ResultsAccess.controler.CurrentProject.Data;
                path = myPathway.GetUpstreamResults(data).ElementAt(0).Value;

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
                data = ResultsAccess.controler.CurrentProject.Data;

                //label251.Text = coalBTuperTON.ToString();
                #endregion
        }
        #region This will recalculate every value that is determined by taking in other values and applying calculation
        public void doCalculations()
        {
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
            TotalOnboardAUxHP = NumberOfAuxiliaryEnginesInUse * AuxiliaryEnginesRatedHPperEngine;
            TimeAuxActiveHours = (PercentOfTripAuxiliaryIsActive / 100) * TotalTripTimeHours;
            ActiveHPPerAuxEngine = (HPLoadFactorSingleEngine / 100) * AuxiliaryEnginesRatedHPperEngine;
            TotalAuxEnergyProduction = NumberOfAuxiliaryEnginesInUse * ActiveHPPerAuxEngine * TimeAuxActiveHours * KWperHP;
            AuxEngineKWHoutperTrip = TotalAuxEnergyProduction;
            AuxEngineMMBTUoutperTrip = (AuxEngineKWHoutperTrip * BTUperKWH) / 1000000;
            AuxEngineMMBTUinperTrip = AuxEngineMMBTUoutperTrip * (100 / AuxiliaryEngineEfficiency);
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
            AuxConventionalDieselTotal = AuxConventionalDieselFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
            AuxResidualOilTotal = AuxResidualOilFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
            AuxLowSulfurDieselTotal = AuxLowSulfurDieselFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
            AuxNaturalGasTotal = AuxNaturalGasFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
            AuxBioDieselTotal = AuxBiodieselFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
            AuxFischerTropschTotal = AuxFischerTropschFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
        }
        #endregion
        #region This will make it so that all the values shown are consistent with the code values of the variables
        public void changeResults()
        {
            //5 
            textBox1.Text = (string)VesselTypeID;
            numericUpDown1.Value = (decimal)NOX_gphphr_out;
            numericUpDown2.Value = (decimal)CO_gphphr_out;
            numericUpDown3.Value = (decimal)VOC_gphphr_out;
            numericUpDown4.Value = (decimal)PM10_gphphr_out;
            numericUpDown5.Value = (decimal)PM25_gphphr_out;

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
            numericUpDown227.Value = (decimal)AuxiliaryEngineFuelType;
            numericUpDown228.Value = (decimal)NumberOfOnBoarAuxiliaryEngines;
            numericUpDown229.Value = (decimal)NumberOfAuxiliaryEnginesInUse;
            numericUpDown230.Value = (decimal)AuxiliaryEnginesRatedHPperEngine;
            numericUpDown232.Value = (decimal)PercentOfTripAuxiliaryIsActive;
            numericUpDown234.Value = (decimal)HPLoadFactorSingleEngine;
            numericUpDown237.Value = (decimal)SelectionOfModelCalculatedOrUserInputFuelConsumptionValues6;
            numericUpDown242.Value = (decimal)AuxiliaryEngineEfficiency;
            numericUpDown293.Value = (decimal)AuxConventionalDieselFC;
            numericUpDown292.Value = (decimal)AuxResidualOilFC;
            numericUpDown291.Value = (decimal)AuxLowSulfurDieselFC;
            numericUpDown290.Value = (decimal)AuxNaturalGasFC;
            numericUpDown289.Value = (decimal)AuxBiodieselFC;
            numericUpDown268.Value = (decimal)AuxFischerTropschFC;

            doCalculations();
            //All Results That Needed Calculation
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

            NOX_gphphr_out = 7.94;
            CO_gphphr_out = 7.94;
            VOC_gphphr_out = 7.94;
            PM10_gphphr_out = 7.94;
            PM25_gphphr_out = 7.94;

            #endregion
            #region Teams 6.1 - 6.4d
            //6.1 Auxiliary Engine Fuel Type to Present On Results Sheet;
            //1 = Conventional Diesel 2 = Residual Oil 3 = Low Sulfur Diesel 4 = Natural gas 5 = Biodiesel 6 = Fischer Tropsch Diesel
            AuxiliaryEngineFuelType = 1;

            //6.2 Auxiliary Engine Variables
            NumberOfOnBoarAuxiliaryEngines = 4;
            NumberOfAuxiliaryEnginesInUse = 2;
            AuxiliaryEnginesRatedHPperEngine = 1400;

            //6.3 Auxiliary Engine Characterization (Conventional Diesel as Baseline Fuel)
            PercentOfTripAuxiliaryIsActive = 50.00;
            HPLoadFactorSingleEngine = 80.00;

            //6.4a Selection of Medel Calculated or User Input Fuel Consumption Values Conventional Diesel as Baseline Fuel
            //1 = Simlate using GPH derived from User-Entered Auxiliary engine specifications 2 = Simlate using user entered GPH
            SelectionOfModelCalculatedOrUserInputFuelConsumptionValues6 = 1;

            //6.4b Calculation of Auxiliary Engine Fuel use Using Conventional Diesel as Baseline Fuel
            AuxiliaryEngineEfficiency = 40.00;

            //6.4c Calculation of Auxiliary Engine Fuel Use Using Alternative Fuels
            //EE = Engine Efficiency AuxMMBTU = Auxiliary MMTBUin/Trip EAFC = Auxiliary Engine Alternativee Fuel Consumption

            //6.4d  Auxiliary Engine Fuel Consumption (Only if you're using user entered GPH for your simulation
            //FC = Fuel Consumption 
            AuxConventionalDieselFC = 9;
            AuxResidualOilFC = 10;
            AuxLowSulfurDieselFC = 11;
            AuxNaturalGasFC = 800;
            AuxBiodieselFC = 9;
            AuxFischerTropschFC = 10;
            #endregion
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
            if (five_complete == true && six_complete == true)
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
                gfr = new GREETFormattedResults(this);
                gfr.Show();
            }
        }
        #region Sends data from fifth set of inputs (Main Engine)
        private void button5_Click(object sender, EventArgs e)
        {
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

                //Fuel Inputs
                NOX_gphphr_out = (double)numericUpDown1.Value;
                CO_gphphr_out = (double)numericUpDown2.Value;
                VOC_gphphr_out = (double)numericUpDown3.Value;
                PM10_gphphr_out = (double)numericUpDown4.Value;
                PM25_gphphr_out = (double)numericUpDown5.Value;
                five_complete = true;

                doCalculations();
                changeResults();
        }
        #endregion
        #region Sends data from sixth set of inputs (Aux Engine)
        private void button6_Click(object sender, EventArgs e)
        {
                button6.BackColor = Color.Green;
                //6.1
                AuxiliaryEngineFuelType = (int)numericUpDown227.Value;

                //6.2
                NumberOfOnBoarAuxiliaryEngines = (int)numericUpDown228.Value;
                NumberOfAuxiliaryEnginesInUse = (int)numericUpDown229.Value;
                AuxiliaryEnginesRatedHPperEngine = (int)numericUpDown230.Value;
                TotalOnboardAUxHP = NumberOfAuxiliaryEnginesInUse * AuxiliaryEnginesRatedHPperEngine;
                numericUpDown231.Value = (decimal)TotalOnboardAUxHP;

                //6.3
                PercentOfTripAuxiliaryIsActive = (double)numericUpDown232.Value;
                TimeAuxActiveHours = (PercentOfTripAuxiliaryIsActive / 100) * TotalTripTimeHours;
                numericUpDown233.Value = (decimal)TimeAuxActiveHours;
                HPLoadFactorSingleEngine = (double)numericUpDown234.Value;
                ActiveHPPerAuxEngine = (HPLoadFactorSingleEngine / 100) * AuxiliaryEnginesRatedHPperEngine;
                numericUpDown235.Value = (decimal)ActiveHPPerAuxEngine;
                TotalAuxEnergyProduction = NumberOfAuxiliaryEnginesInUse * ActiveHPPerAuxEngine * TimeAuxActiveHours * KWperHP;
                numericUpDown236.Value = (decimal)TotalAuxEnergyProduction;

                //6.4a 
                SelectionOfModelCalculatedOrUserInputFuelConsumptionValues6 = (int)numericUpDown237.Value;

                //6.4b
                AuxiliaryEngineEfficiency = (double)numericUpDown242.Value;
                AuxEngineKWHoutperTrip = TotalAuxEnergyProduction;
                numericUpDown241.Value = (decimal)AuxEngineKWHoutperTrip;
                AuxEngineMMBTUoutperTrip = (AuxEngineKWHoutperTrip * BTUperKWH) / 1000000;

                numericUpDown240.Value = (decimal)AuxEngineMMBTUoutperTrip;
                AuxEngineMMBTUinperTrip = AuxEngineMMBTUoutperTrip * (100 / AuxiliaryEngineEfficiency);
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
                AuxConventionalDieselTotal = AuxConventionalDieselFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
                numericUpDown263.Value = (decimal)AuxConventionalDieselTotal;
                AuxResidualOilFC = (int)numericUpDown292.Value;
                AuxResidualOilTotal = AuxResidualOilFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
                numericUpDown262.Value = (decimal)AuxResidualOilTotal;
                AuxLowSulfurDieselFC = (int)numericUpDown291.Value;
                AuxLowSulfurDieselTotal = AuxLowSulfurDieselFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
                numericUpDown261.Value = (decimal)AuxLowSulfurDieselTotal;
                AuxNaturalGasFC = (int)numericUpDown290.Value;
                AuxNaturalGasTotal = AuxNaturalGasFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
                numericUpDown260.Value = (decimal)AuxNaturalGasTotal;
                AuxBiodieselFC = (int)numericUpDown289.Value;
                AuxBioDieselTotal = AuxBiodieselFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
                numericUpDown259.Value = (decimal)AuxBioDieselTotal;
                AuxFischerTropschFC = (int)numericUpDown268.Value;
                AuxFischerTropschTotal = AuxFischerTropschFC * TimeAuxActiveHours * NumberOfAuxiliaryEnginesInUse;
                numericUpDown258.Value = (decimal)AuxFischerTropschTotal;
                six_complete = true;
                doCalculations();
                changeResults();
        }
        #endregion

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new TEAMS();
            f.Show();
        }
        private void TEAMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            u.Close();
            GVE.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            u.Close();
            GVE.Close();
            this.Close();
        }

        private void submitAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object sender2 = sender;
            EventArgs e2 = e;
            button5_Click(sender2, e2);
            button6_Click(sender2, e2);
        }

    }
}
