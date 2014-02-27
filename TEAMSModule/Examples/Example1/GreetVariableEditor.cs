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
    public partial class Fuel_Specs : Form
    {
        TEAMS te;
        public Fuel_Specs(TEAMS t)
        {
            te = t;
            InitializeComponent();
        }

        //Method that makes it such that the values in the numeric up downs, are the ones being presented by GREET
        public void variableSetter()
        {
            this.numericUpDown3.Value = (decimal)te.crudeOilBTUperGal;
            this.numericUpDown41.Value = (decimal)te.crudeOilDensity;
            this.numericUpDown20.Value = (decimal)te.crudeOilCarbonRatio;
            this.numericUpDown30.Value = (decimal)te.crudeOilSulfurRatio;
            this.numericUpDown40.Value = (decimal)te.crudeOilSulfurRatioActual;

            this.numericUpDown6.Value = (decimal)te.conventionalDieselBTUperGal;
            this.numericUpDown43.Value = (decimal)te.conventionalDieselDensity;
            this.numericUpDown19.Value = (decimal)te.conventionalDieselCarbonRatio;
            this.numericUpDown29.Value = (decimal)te.conventionalDieselSulfurRatio;
            this.numericUpDown39.Value = (decimal)te.conventionalDieselSulfurRatioActual;

            this.numericUpDown5.Value = (decimal)te.lowSulfurDieselBTUperGal;
            this.numericUpDown45.Value = (decimal)te.lowSulfurDieselDensity;
            this.numericUpDown18.Value = (decimal)te.lowSulfurDieselCarbonRatio;
            this.numericUpDown28.Value = (decimal)te.lowSulfurDieselSulfurRatio;
            this.numericUpDown38.Value = (decimal)te.lowSulfurDieselSulfurRatioActual;

            this.numericUpDown4.Value = (decimal)te.liquifiedPetroleumGasBTUperGal;
            this.numericUpDown47.Value = (decimal)te.liquifiedPetroleumGasDensity;
            this.numericUpDown17.Value = (decimal)te.liquifiedPetroleumGasCarbonRatio;
            this.numericUpDown27.Value = (decimal)te.liquifiedPetroleumGasSulfurRatio;
            this.numericUpDown37.Value = (decimal)te.liquifiedPetroleumGasSulfurRatioActual;

            this.numericUpDown9.Value = (decimal)te.residualOilBTUperGal;
            this.numericUpDown49.Value = (decimal)te.residualOilDensity;
            this.numericUpDown16.Value = (decimal)te.residualOilCarbonRatio;
            this.numericUpDown26.Value = (decimal)te.residualOilSulfurRatio;
            this.numericUpDown36.Value = (decimal)te.residualOilSulfurRatioActual;

            this.numericUpDown8.Value = (decimal)te.liquifiedNaturalGasBTUperGal;
            this.numericUpDown50.Value = (decimal)te.liquifiedNaturalGasDensity;
            this.numericUpDown15.Value = (decimal)te.liquifiedNaturalGasCarbonRatio;
            this.numericUpDown25.Value = (decimal)te.liquifiedNaturalGasSulfurRatio;
            this.numericUpDown35.Value = (decimal)te.liquifiedNaturalGasSulfurRatioActual;

            this.numericUpDown7.Value = (decimal)te.bioDieselBTUperGal;
            this.numericUpDown48.Value = (decimal)te.bioDieselDensity;
            this.numericUpDown14.Value = (decimal)te.bioDieselCarbonRatio;
            this.numericUpDown24.Value = (decimal)te.bioDieselSulfurRatio;
            this.numericUpDown34.Value = (decimal)te.bioDieselSulfurRatioActual;

            this.numericUpDown12.Value = (decimal)te.fischerTropschBTUperGal;
            this.numericUpDown46.Value = (decimal)te.fischerTropschDensity;
            this.numericUpDown13.Value = (decimal)te.fischerTropschCarbonRatio;
            this.numericUpDown23.Value = (decimal)te.fischerTropschSulfurRatio;
            this.numericUpDown33.Value = (decimal)te.fischerTropschSulfurRatioActual;

            this.numericUpDown11.Value = (decimal)te.natGasBTUperSCF;
            this.numericUpDown44.Value = (decimal)te.natGasGramsperSCF;
            this.numericUpDown2.Value = (decimal)te.natGasCarbonRatio;
            this.numericUpDown22.Value = (decimal)te.natGasSulfurRatio;
            this.numericUpDown32.Value = (decimal)te.natGasSulfurRatioActual;

            this.numericUpDown10.Value = (decimal)te.coalBTuperTON;
            this.numericUpDown1.Value = (decimal)te.coalCarbonRatio;
            this.numericUpDown21.Value = (decimal)te.coalSulfurRatio;
            this.numericUpDown31.Value = (decimal)te.coalSulfurRatioActual;
        }
        //On load, pulls the current values from the simulation
        private void GreetVariableEditor_Load(object sender, EventArgs e)
        {
            variableSetter();
        }
        //Button that saves your changes to the data, and supplies them to the simulation
        private void button1_Click(object sender, EventArgs e)
        {
            te.crudeOilBTUperGal = (double)numericUpDown3.Value;
            te.crudeOilDensity = (double)numericUpDown41.Value;
            te.crudeOilCarbonRatio = (double)numericUpDown20.Value;
            te.crudeOilSulfurRatio = (double)numericUpDown30.Value;
            te.crudeOilSulfurRatioActual = (double)numericUpDown40.Value;

            te.conventionalDieselBTUperGal = (double)numericUpDown6.Value;
            te.conventionalDieselDensity = (double)numericUpDown43.Value;
            te.conventionalDieselCarbonRatio = (double)numericUpDown19.Value;
            te.conventionalDieselSulfurRatio = (double)numericUpDown29.Value;
            te.conventionalDieselSulfurRatioActual = (double)numericUpDown39.Value;

            te.lowSulfurDieselBTUperGal = (double)numericUpDown5.Value;
            te.lowSulfurDieselDensity = (double)numericUpDown45.Value;
            te.lowSulfurDieselCarbonRatio = (double)numericUpDown18.Value;
            te.lowSulfurDieselSulfurRatio = (double)numericUpDown28.Value;
            te.lowSulfurDieselSulfurRatioActual = (double)numericUpDown38.Value;

            te.liquifiedPetroleumGasBTUperGal = (double)numericUpDown4.Value;
            te.liquifiedPetroleumGasDensity = (double)numericUpDown47.Value;
            te.liquifiedPetroleumGasCarbonRatio = (double)numericUpDown17.Value;
            te.liquifiedPetroleumGasSulfurRatio = (double)numericUpDown27.Value;
            te.liquifiedPetroleumGasSulfurRatioActual = (double)numericUpDown37.Value;

            te.residualOilBTUperGal = (double)numericUpDown9.Value;
            te.residualOilDensity = (double)numericUpDown49.Value;
            te.residualOilCarbonRatio = (double)numericUpDown16.Value;
            te.residualOilSulfurRatio = (double)numericUpDown26.Value;
            te.residualOilSulfurRatioActual = (double)numericUpDown36.Value;

            te.liquifiedNaturalGasBTUperGal = (double)numericUpDown8.Value;
            te.liquifiedNaturalGasDensity = (double)numericUpDown50.Value;
            te.liquifiedNaturalGasCarbonRatio = (double)numericUpDown15.Value;
            te.liquifiedNaturalGasSulfurRatio = (double)numericUpDown25.Value;
            te.liquifiedNaturalGasSulfurRatioActual = (double)numericUpDown35.Value;

            te.bioDieselBTUperGal = (double)numericUpDown7.Value;
            te.bioDieselDensity = (double)numericUpDown48.Value;
            te.bioDieselCarbonRatio = (double)numericUpDown14.Value;
            te.bioDieselSulfurRatio = (double)numericUpDown24.Value;
            te.bioDieselSulfurRatioActual = (double)numericUpDown34.Value;

            te.fischerTropschBTUperGal = (double)numericUpDown12.Value;
            te.fischerTropschDensity = (double)numericUpDown46.Value;
            te.fischerTropschCarbonRatio = (double)numericUpDown13.Value;
            te.fischerTropschSulfurRatio = (double)numericUpDown23.Value;
            te.fischerTropschSulfurRatioActual = (double)numericUpDown33.Value;

            te.GHPCO2 = (int)numericUpDown42.Value;
            te.GHPCH4 = (int)numericUpDown51.Value;
            te.GHPN2O = (int)numericUpDown52.Value;
            te.GHPVOC = (int)numericUpDown53.Value;
            te.GHPCO = (int)numericUpDown54.Value;
            te.GHPNO2 = (int)numericUpDown55.Value;

            te.CarbonRatioVOC = (double)numericUpDown61.Value;
            te.CarbonRatioCO = (double)numericUpDown60.Value;
            te.CarbonRatioCH4 = (double)numericUpDown59.Value;
            te.CarbonRatioCO2 = (double)numericUpDown58.Value;
            te.CarbonRatioSO2 = (double)numericUpDown57.Value;
        }
        //Reset Button
        private void button2_Click(object sender, EventArgs e)
        {
            te.pullFromGREET();
            variableSetter();
        }

        private void Fuel_Specs_FormClosing(object sender, FormClosingEventArgs e)
        {
            te.GVE = new Fuel_Specs(te);
        }
    }
}
