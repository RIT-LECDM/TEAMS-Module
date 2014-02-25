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
    public partial class ResultsSheet : Form
    {
        TEAMS te;

        //Variables for the results 
        #region Table 1 Variables in the form of lists, the lists will each be a different collumn of the spreadsheet on table 1
        public List<double> ROone = new List<double>();
        public List<double> CDone = new List<double>();
        public List<double> LSDone = new List<double>();
        public List<double> LNGone = new List<double>();
        public List<double> BDone = new List<double>();
        public List<double> FTone = new List<double>();

        #endregion
        #region Table 2,3,4,5,6,7 variables in list form, similar to up above
        public List<double> CDFS = new List<double>();
        public List<double> CDF = new List<double>();
        public List<double> CDO = new List<double>();

        public List<double> ROFS = new List<double>();
        public List<double> ROF = new List<double>();
        public List<double> ROO = new List<double>();

        public List<double> LSDFS = new List<double>();
        public List<double> LSDF = new List<double>();
        public List<double> LSDO = new List<double>();

        public List<double> NGFS = new List<double>();
        public List<double> NGF = new List<double>();
        public List<double> NGO = new List<double>();

        public List<double> BDFS = new List<double>();
        public List<double> BDF = new List<double>();
        public List<double> BDO = new List<double>();

        public List<double> FTFS = new List<double>();
        public List<double> FTF = new List<double>();
        public List<double> FTO = new List<double>();

        #endregion
        public ResultsSheet(TEAMS t)
        {
            te = t;
            InitializeComponent();
            populateListsWithResults();
            correctNumbersDisplayed();
        }

        public void populateListsWithResults()
        {
            #region Table 1 list population
            //The numbers being added are just placeholders for the results that will actually be populating those spaces
            ROone.Add(0);
            ROone.Add(1);
            ROone.Add(2);
            ROone.Add(3);
            ROone.Add(4);
            ROone.Add(5);
            ROone.Add(6);
            ROone.Add(7);
            ROone.Add(8);
            ROone.Add(9);
            ROone.Add(10);
            ROone.Add(11);
            ROone.Add(12);

            CDone.Add(0);
            CDone.Add(1);
            CDone.Add(2);
            CDone.Add(3);
            CDone.Add(4);
            CDone.Add(5);
            CDone.Add(6);
            CDone.Add(7);
            CDone.Add(8);
            CDone.Add(9);
            CDone.Add(10);
            CDone.Add(11);
            CDone.Add(12);

            LSDone.Add(0);
            LSDone.Add(1);
            LSDone.Add(2);
            LSDone.Add(3);
            LSDone.Add(4);
            LSDone.Add(5);
            LSDone.Add(6);
            LSDone.Add(7);
            LSDone.Add(8);
            LSDone.Add(9);
            LSDone.Add(10);
            LSDone.Add(11);
            LSDone.Add(12);

            LNGone.Add(0);
            LNGone.Add(1);
            LNGone.Add(2);
            LNGone.Add(3);
            LNGone.Add(4);
            LNGone.Add(5);
            LNGone.Add(6);
            LNGone.Add(7);
            LNGone.Add(8);
            LNGone.Add(9);
            LNGone.Add(10);
            LNGone.Add(11);
            LNGone.Add(12);

            BDone.Add(0);
            BDone.Add(1);
            BDone.Add(2);
            BDone.Add(3);
            BDone.Add(4);
            BDone.Add(5);
            BDone.Add(6);
            BDone.Add(7);
            BDone.Add(8);
            BDone.Add(9);
            BDone.Add(10);
            BDone.Add(11);
            BDone.Add(12);

            FTone.Add(0);
            FTone.Add(1);
            FTone.Add(2);
            FTone.Add(3);
            FTone.Add(4);
            FTone.Add(5);
            FTone.Add(6);
            FTone.Add(7);
            FTone.Add(8);
            FTone.Add(9);
            FTone.Add(10);
            FTone.Add(11);
            FTone.Add(12);

#endregion
            #region Table 2 List Population
            CDFS.Add(0);
            CDFS.Add(1);
            CDFS.Add(2);
            CDFS.Add(3);
            CDFS.Add(4);
            CDFS.Add(5);
            CDFS.Add(6);
            CDFS.Add(7);
            CDFS.Add(8);
            CDFS.Add(9);
            CDFS.Add(10);
            CDFS.Add(11);
            CDFS.Add(12);

            CDF.Add(0);
            CDF.Add(1);
            CDF.Add(2);
            CDF.Add(3);
            CDF.Add(4);
            CDF.Add(5);
            CDF.Add(6);
            CDF.Add(7);
            CDF.Add(8);
            CDF.Add(9);
            CDF.Add(10);
            CDF.Add(11);
            CDF.Add(12);

            CDO.Add(0);
            CDO.Add(1);
            CDO.Add(2);
            CDO.Add(3);
            CDO.Add(4);
            CDO.Add(5);
            CDO.Add(6);
            CDO.Add(7);
            CDO.Add(8);
            CDO.Add(9);
            CDO.Add(10);
            CDO.Add(11);
            CDO.Add(12);
            #endregion
            #region Table 3 List Population
            ROFS.Add(0);
            ROFS.Add(1);
            ROFS.Add(2);
            ROFS.Add(3);
            ROFS.Add(4);
            ROFS.Add(5);
            ROFS.Add(6);
            ROFS.Add(7);
            ROFS.Add(8);
            ROFS.Add(9);
            ROFS.Add(10);
            ROFS.Add(11);
            ROFS.Add(12);

            ROF.Add(0);
            ROF.Add(1);
            ROF.Add(2);
            ROF.Add(3);
            ROF.Add(4);
            ROF.Add(5);
            ROF.Add(6);
            ROF.Add(7);
            ROF.Add(8);
            ROF.Add(9);
            ROF.Add(10);
            ROF.Add(11);
            ROF.Add(12);

            ROO.Add(0);
            ROO.Add(1);
            ROO.Add(2);
            ROO.Add(3);
            ROO.Add(4);
            ROO.Add(5);
            ROO.Add(6);
            ROO.Add(7);
            ROO.Add(8);
            ROO.Add(9);
            ROO.Add(10);
            ROO.Add(11);
            ROO.Add(12);
            #endregion
            #region Table 4 List Population
            LSDFS.Add(0);
            LSDFS.Add(1);
            LSDFS.Add(2);
            LSDFS.Add(3);
            LSDFS.Add(4);
            LSDFS.Add(5);
            LSDFS.Add(6);
            LSDFS.Add(7);
            LSDFS.Add(8);
            LSDFS.Add(9);
            LSDFS.Add(10);
            LSDFS.Add(11);
            LSDFS.Add(12);

            LSDF.Add(0);
            LSDF.Add(1);
            LSDF.Add(2);
            LSDF.Add(3);
            LSDF.Add(4);
            LSDF.Add(5);
            LSDF.Add(6);
            LSDF.Add(7);
            LSDF.Add(8);
            LSDF.Add(9);
            LSDF.Add(10);
            LSDF.Add(11);
            LSDF.Add(12);

            LSDO.Add(0);
            LSDO.Add(1);
            LSDO.Add(2);
            LSDO.Add(3);
            LSDO.Add(4);
            LSDO.Add(5);
            LSDO.Add(6);
            LSDO.Add(7);
            LSDO.Add(8);
            LSDO.Add(9);
            LSDO.Add(10);
            LSDO.Add(11);
            LSDO.Add(12);
            #endregion
            #region Table 5 List Population
            NGFS.Add(0);
            NGFS.Add(1);
            NGFS.Add(2);
            NGFS.Add(3);
            NGFS.Add(4);
            NGFS.Add(5);
            NGFS.Add(6);
            NGFS.Add(7);
            NGFS.Add(8);
            NGFS.Add(9);
            NGFS.Add(10);
            NGFS.Add(11);
            NGFS.Add(12);

            NGF.Add(0);
            NGF.Add(1);
            NGF.Add(2);
            NGF.Add(3);
            NGF.Add(4);
            NGF.Add(5);
            NGF.Add(6);
            NGF.Add(7);
            NGF.Add(8);
            NGF.Add(9);
            NGF.Add(10);
            NGF.Add(11);
            NGF.Add(12);

            NGO.Add(0);
            NGO.Add(1);
            NGO.Add(2);
            NGO.Add(3);
            NGO.Add(4);
            NGO.Add(5);
            NGO.Add(6);
            NGO.Add(7);
            NGO.Add(8);
            NGO.Add(9);
            NGO.Add(10);
            NGO.Add(11);
            NGO.Add(12);
            #endregion
            #region Table 6 List Population
            BDFS.Add(0);
            BDFS.Add(1);
            BDFS.Add(2);
            BDFS.Add(3);
            BDFS.Add(4);
            BDFS.Add(5);
            BDFS.Add(6);
            BDFS.Add(7);
            BDFS.Add(8);
            BDFS.Add(9);
            BDFS.Add(10);
            BDFS.Add(11);
            BDFS.Add(12);

            BDF.Add(0);
            BDF.Add(1);
            BDF.Add(2);
            BDF.Add(3);
            BDF.Add(4);
            BDF.Add(5);
            BDF.Add(6);
            BDF.Add(7);
            BDF.Add(8);
            BDF.Add(9);
            BDF.Add(10);
            BDF.Add(11);
            BDF.Add(12);

            BDO.Add(0);
            BDO.Add(1);
            BDO.Add(2);
            BDO.Add(3);
            BDO.Add(4);
            BDO.Add(5);
            BDO.Add(6);
            BDO.Add(7);
            BDO.Add(8);
            BDO.Add(9);
            BDO.Add(10);
            BDO.Add(11);
            BDO.Add(12);
            #endregion
            #region Table 7 List Population
            FTFS.Add(0);
            FTFS.Add(1);
            FTFS.Add(2);
            FTFS.Add(3);
            FTFS.Add(4);
            FTFS.Add(5);
            FTFS.Add(6);
            FTFS.Add(7);
            FTFS.Add(8);
            FTFS.Add(9);
            FTFS.Add(10);
            FTFS.Add(11);
            FTFS.Add(12);

            FTF.Add(0);
            FTF.Add(1);
            FTF.Add(2);
            FTF.Add(3);
            FTF.Add(4);
            FTF.Add(5);
            FTF.Add(6);
            FTF.Add(7);
            FTF.Add(8);
            FTF.Add(9);
            FTF.Add(10);
            FTF.Add(11);
            FTF.Add(12);

            FTO.Add(0);
            FTO.Add(1);
            FTO.Add(2);
            FTO.Add(3);
            FTO.Add(4);
            FTO.Add(5);
            FTO.Add(6);
            FTO.Add(7);
            FTO.Add(8);
            FTO.Add(9);
            FTO.Add(10);
            FTO.Add(11);
            FTO.Add(12);
            #endregion
        }
        public void correctNumbersDisplayed()
        {
            #region Table 1 numericUpDown assignments
            numericUpDown1.Value = (decimal)ROone.ElementAt(0);
            numericUpDown12.Value = (decimal)ROone.ElementAt(1);
            numericUpDown18.Value = (decimal)ROone.ElementAt(2);
            numericUpDown24.Value = (decimal)ROone.ElementAt(3);
            numericUpDown30.Value = (decimal)ROone.ElementAt(4);
            numericUpDown36.Value = (decimal)ROone.ElementAt(5);
            numericUpDown42.Value = (decimal)ROone.ElementAt(6);
            numericUpDown48.Value = (decimal)ROone.ElementAt(7);
            numericUpDown54.Value = (decimal)ROone.ElementAt(8);
            numericUpDown60.Value = (decimal)ROone.ElementAt(9);
            numericUpDown66.Value = (decimal)ROone.ElementAt(10);
            numericUpDown72.Value = (decimal)ROone.ElementAt(11);
            numericUpDown78.Value = (decimal)ROone.ElementAt(12);

            numericUpDown2.Value = (decimal)CDone.ElementAt(0);
            numericUpDown11.Value = (decimal)CDone.ElementAt(1);
            numericUpDown17.Value = (decimal)CDone.ElementAt(2);
            numericUpDown23.Value = (decimal)CDone.ElementAt(3);
            numericUpDown29.Value = (decimal)CDone.ElementAt(4);
            numericUpDown35.Value = (decimal)CDone.ElementAt(5);
            numericUpDown41.Value = (decimal)CDone.ElementAt(6);
            numericUpDown47.Value = (decimal)CDone.ElementAt(7);
            numericUpDown53.Value = (decimal)CDone.ElementAt(8);
            numericUpDown59.Value = (decimal)CDone.ElementAt(9);
            numericUpDown65.Value = (decimal)CDone.ElementAt(10);
            numericUpDown71.Value = (decimal)CDone.ElementAt(11);
            numericUpDown77.Value = (decimal)CDone.ElementAt(12);

            numericUpDown3.Value = (decimal)LSDone.ElementAt(0);
            numericUpDown10.Value = (decimal)LSDone.ElementAt(1);
            numericUpDown16.Value = (decimal)LSDone.ElementAt(2);
            numericUpDown22.Value = (decimal)LSDone.ElementAt(3);
            numericUpDown28.Value = (decimal)LSDone.ElementAt(4);
            numericUpDown34.Value = (decimal)LSDone.ElementAt(5);
            numericUpDown40.Value = (decimal)LSDone.ElementAt(6);
            numericUpDown46.Value = (decimal)LSDone.ElementAt(7);
            numericUpDown52.Value = (decimal)LSDone.ElementAt(8);
            numericUpDown58.Value = (decimal)LSDone.ElementAt(9);
            numericUpDown64.Value = (decimal)LSDone.ElementAt(10);
            numericUpDown70.Value = (decimal)LSDone.ElementAt(11);
            numericUpDown76.Value = (decimal)LSDone.ElementAt(12);

            numericUpDown4.Value = (decimal)LNGone.ElementAt(0);
            numericUpDown9.Value = (decimal)LNGone.ElementAt(1);
            numericUpDown15.Value = (decimal)LNGone.ElementAt(2);
            numericUpDown21.Value = (decimal)LNGone.ElementAt(3);
            numericUpDown27.Value = (decimal)LNGone.ElementAt(4);
            numericUpDown33.Value = (decimal)LNGone.ElementAt(5);
            numericUpDown39.Value = (decimal)LNGone.ElementAt(6);
            numericUpDown45.Value = (decimal)LNGone.ElementAt(7);
            numericUpDown51.Value = (decimal)LNGone.ElementAt(8);
            numericUpDown57.Value = (decimal)LNGone.ElementAt(9);
            numericUpDown63.Value = (decimal)LNGone.ElementAt(10);
            numericUpDown69.Value = (decimal)LNGone.ElementAt(11);
            numericUpDown75.Value = (decimal)LNGone.ElementAt(12);

            numericUpDown5.Value = (decimal)BDone.ElementAt(0);
            numericUpDown8.Value = (decimal)BDone.ElementAt(1);
            numericUpDown14.Value = (decimal)BDone.ElementAt(2);
            numericUpDown20.Value = (decimal)BDone.ElementAt(3);
            numericUpDown26.Value = (decimal)BDone.ElementAt(4);
            numericUpDown32.Value = (decimal)BDone.ElementAt(5);
            numericUpDown38.Value = (decimal)BDone.ElementAt(6);
            numericUpDown44.Value = (decimal)BDone.ElementAt(7);
            numericUpDown50.Value = (decimal)BDone.ElementAt(8);
            numericUpDown56.Value = (decimal)BDone.ElementAt(9);
            numericUpDown62.Value = (decimal)BDone.ElementAt(10);
            numericUpDown68.Value = (decimal)BDone.ElementAt(11);
            numericUpDown74.Value = (decimal)BDone.ElementAt(12);

            numericUpDown6.Value = (decimal)FTone.ElementAt(0);
            numericUpDown7.Value = (decimal)FTone.ElementAt(1);
            numericUpDown13.Value = (decimal)FTone.ElementAt(2);
            numericUpDown19.Value = (decimal)FTone.ElementAt(3);
            numericUpDown25.Value = (decimal)FTone.ElementAt(4);
            numericUpDown31.Value = (decimal)FTone.ElementAt(5);
            numericUpDown37.Value = (decimal)FTone.ElementAt(6);
            numericUpDown43.Value = (decimal)FTone.ElementAt(7);
            numericUpDown49.Value = (decimal)FTone.ElementAt(8);
            numericUpDown55.Value = (decimal)FTone.ElementAt(9);
            numericUpDown61.Value = (decimal)FTone.ElementAt(10);
            numericUpDown67.Value = (decimal)FTone.ElementAt(11);
            numericUpDown73.Value = (decimal)FTone.ElementAt(12);

#endregion
            #region Table 2 numericUpDown assignments
            numericUpDown117.Value = (decimal)CDFS.ElementAt(0);
            numericUpDown114.Value = (decimal)CDFS.ElementAt(1);
            numericUpDown111.Value = (decimal)CDFS.ElementAt(2);
            numericUpDown108.Value = (decimal)CDFS.ElementAt(3);
            numericUpDown105.Value = (decimal)CDFS.ElementAt(4);
            numericUpDown102.Value = (decimal)CDFS.ElementAt(5);
            numericUpDown99.Value = (decimal)CDFS.ElementAt(6);
            numericUpDown96.Value = (decimal)CDFS.ElementAt(7);
            numericUpDown93.Value = (decimal)CDFS.ElementAt(8);
            numericUpDown90.Value = (decimal)CDFS.ElementAt(9);
            numericUpDown87.Value = (decimal)CDFS.ElementAt(10);
            numericUpDown84.Value = (decimal)CDFS.ElementAt(11);
            numericUpDown81.Value = (decimal)CDFS.ElementAt(12);

            numericUpDown116.Value = (decimal)CDF.ElementAt(0);
            numericUpDown113.Value = (decimal)CDF.ElementAt(1);
            numericUpDown110.Value = (decimal)CDF.ElementAt(2);
            numericUpDown107.Value = (decimal)CDF.ElementAt(3);
            numericUpDown104.Value = (decimal)CDF.ElementAt(4);
            numericUpDown101.Value = (decimal)CDF.ElementAt(5);
            numericUpDown98.Value = (decimal)CDF.ElementAt(6);
            numericUpDown95.Value = (decimal)CDF.ElementAt(7);
            numericUpDown92.Value = (decimal)CDF.ElementAt(8);
            numericUpDown89.Value = (decimal)CDF.ElementAt(9);
            numericUpDown86.Value = (decimal)CDF.ElementAt(10);
            numericUpDown83.Value = (decimal)CDF.ElementAt(11);
            numericUpDown80.Value = (decimal)CDF.ElementAt(12);

            numericUpDown115.Value = (decimal)CDO.ElementAt(0);
            numericUpDown112.Value = (decimal)CDO.ElementAt(1);
            numericUpDown109.Value = (decimal)CDO.ElementAt(2);
            numericUpDown106.Value = (decimal)CDO.ElementAt(3);
            numericUpDown103.Value = (decimal)CDO.ElementAt(4);
            numericUpDown100.Value = (decimal)CDO.ElementAt(5);
            numericUpDown97.Value = (decimal)CDO.ElementAt(6);
            numericUpDown94.Value = (decimal)CDO.ElementAt(7);
            numericUpDown91.Value = (decimal)CDO.ElementAt(8);
            numericUpDown88.Value = (decimal)CDO.ElementAt(9);
            numericUpDown85.Value = (decimal)CDO.ElementAt(10);
            numericUpDown82.Value = (decimal)CDO.ElementAt(11);
            numericUpDown79.Value = (decimal)CDO.ElementAt(12);
            #endregion
            #region Table 3 numericUpDown assignments
            numericUpDown156.Value = (decimal)ROFS.ElementAt(0);
            numericUpDown153.Value = (decimal)ROFS.ElementAt(1);
            numericUpDown150.Value = (decimal)ROFS.ElementAt(2);
            numericUpDown147.Value = (decimal)ROFS.ElementAt(3);
            numericUpDown144.Value = (decimal)ROFS.ElementAt(4);
            numericUpDown141.Value = (decimal)ROFS.ElementAt(5);
            numericUpDown138.Value = (decimal)ROFS.ElementAt(6);
            numericUpDown135.Value = (decimal)ROFS.ElementAt(7);
            numericUpDown132.Value = (decimal)ROFS.ElementAt(8);
            numericUpDown129.Value = (decimal)ROFS.ElementAt(9);
            numericUpDown126.Value = (decimal)ROFS.ElementAt(10);
            numericUpDown123.Value = (decimal)ROFS.ElementAt(11);
            numericUpDown120.Value = (decimal)ROFS.ElementAt(12);

            numericUpDown155.Value = (decimal)ROF.ElementAt(0);
            numericUpDown152.Value = (decimal)ROF.ElementAt(1);
            numericUpDown149.Value = (decimal)ROF.ElementAt(2);
            numericUpDown146.Value = (decimal)ROF.ElementAt(3);
            numericUpDown143.Value = (decimal)ROF.ElementAt(4);
            numericUpDown140.Value = (decimal)ROF.ElementAt(5);
            numericUpDown137.Value = (decimal)ROF.ElementAt(6);
            numericUpDown134.Value = (decimal)ROF.ElementAt(7);
            numericUpDown131.Value = (decimal)ROF.ElementAt(8);
            numericUpDown128.Value = (decimal)ROF.ElementAt(9);
            numericUpDown125.Value = (decimal)ROF.ElementAt(10);
            numericUpDown122.Value = (decimal)ROF.ElementAt(11);
            numericUpDown119.Value = (decimal)ROF.ElementAt(12);

            numericUpDown154.Value = (decimal)ROO.ElementAt(0);
            numericUpDown151.Value = (decimal)ROO.ElementAt(1);
            numericUpDown148.Value = (decimal)ROO.ElementAt(2);
            numericUpDown145.Value = (decimal)ROO.ElementAt(3);
            numericUpDown142.Value = (decimal)ROO.ElementAt(4);
            numericUpDown139.Value = (decimal)ROO.ElementAt(5);
            numericUpDown136.Value = (decimal)ROO.ElementAt(6);
            numericUpDown133.Value = (decimal)ROO.ElementAt(7);
            numericUpDown130.Value = (decimal)ROO.ElementAt(8);
            numericUpDown127.Value = (decimal)ROO.ElementAt(9);
            numericUpDown124.Value = (decimal)ROO.ElementAt(10);
            numericUpDown121.Value = (decimal)ROO.ElementAt(11);
            numericUpDown118.Value = (decimal)ROO.ElementAt(12);
            #endregion
            #region Table 4 numericUpDown assignments
            numericUpDown195.Value = (decimal)LSDFS.ElementAt(0);
            numericUpDown192.Value = (decimal)LSDFS.ElementAt(1);
            numericUpDown189.Value = (decimal)LSDFS.ElementAt(2);
            numericUpDown186.Value = (decimal)LSDFS.ElementAt(3);
            numericUpDown183.Value = (decimal)LSDFS.ElementAt(4);
            numericUpDown180.Value = (decimal)LSDFS.ElementAt(5);
            numericUpDown177.Value = (decimal)LSDFS.ElementAt(6);
            numericUpDown174.Value = (decimal)LSDFS.ElementAt(7);
            numericUpDown171.Value = (decimal)LSDFS.ElementAt(8);
            numericUpDown168.Value = (decimal)LSDFS.ElementAt(9);
            numericUpDown165.Value = (decimal)LSDFS.ElementAt(10);
            numericUpDown162.Value = (decimal)LSDFS.ElementAt(11);
            numericUpDown159.Value = (decimal)LSDFS.ElementAt(12);

            numericUpDown194.Value = (decimal)LSDF.ElementAt(0);
            numericUpDown191.Value = (decimal)LSDF.ElementAt(1);
            numericUpDown188.Value = (decimal)LSDF.ElementAt(2);
            numericUpDown185.Value = (decimal)LSDF.ElementAt(3);
            numericUpDown182.Value = (decimal)LSDF.ElementAt(4);
            numericUpDown179.Value = (decimal)LSDF.ElementAt(5);
            numericUpDown176.Value = (decimal)LSDF.ElementAt(6);
            numericUpDown173.Value = (decimal)LSDF.ElementAt(7);
            numericUpDown170.Value = (decimal)LSDF.ElementAt(8);
            numericUpDown167.Value = (decimal)LSDF.ElementAt(9);
            numericUpDown164.Value = (decimal)LSDF.ElementAt(10);
            numericUpDown161.Value = (decimal)LSDF.ElementAt(11);
            numericUpDown158.Value = (decimal)LSDF.ElementAt(12);

            numericUpDown193.Value = (decimal)LSDO.ElementAt(0);
            numericUpDown190.Value = (decimal)LSDO.ElementAt(1);
            numericUpDown187.Value = (decimal)LSDO.ElementAt(2);
            numericUpDown184.Value = (decimal)LSDO.ElementAt(3);
            numericUpDown181.Value = (decimal)LSDO.ElementAt(4);
            numericUpDown178.Value = (decimal)LSDO.ElementAt(5);
            numericUpDown175.Value = (decimal)LSDO.ElementAt(6);
            numericUpDown172.Value = (decimal)LSDO.ElementAt(7);
            numericUpDown169.Value = (decimal)LSDO.ElementAt(8);
            numericUpDown166.Value = (decimal)LSDO.ElementAt(9);
            numericUpDown163.Value = (decimal)LSDO.ElementAt(10);
            numericUpDown160.Value = (decimal)LSDO.ElementAt(11);
            numericUpDown157.Value = (decimal)LSDO.ElementAt(12);
            #endregion
            #region Table 5 numericUpDown assignments
            numericUpDown273.Value = (decimal)NGFS.ElementAt(0);
            numericUpDown270.Value = (decimal)NGFS.ElementAt(1);
            numericUpDown267.Value = (decimal)NGFS.ElementAt(2);
            numericUpDown264.Value = (decimal)NGFS.ElementAt(3);
            numericUpDown261.Value = (decimal)NGFS.ElementAt(4);
            numericUpDown258.Value = (decimal)NGFS.ElementAt(5);
            numericUpDown255.Value = (decimal)NGFS.ElementAt(6);
            numericUpDown252.Value = (decimal)NGFS.ElementAt(7);
            numericUpDown249.Value = (decimal)NGFS.ElementAt(8);
            numericUpDown246.Value = (decimal)NGFS.ElementAt(9);
            numericUpDown243.Value = (decimal)NGFS.ElementAt(10);
            numericUpDown240.Value = (decimal)NGFS.ElementAt(11);
            numericUpDown237.Value = (decimal)NGFS.ElementAt(12);

            numericUpDown272.Value = (decimal)NGF.ElementAt(0);
            numericUpDown269.Value = (decimal)NGF.ElementAt(1);
            numericUpDown266.Value = (decimal)NGF.ElementAt(2);
            numericUpDown263.Value = (decimal)NGF.ElementAt(3);
            numericUpDown260.Value = (decimal)NGF.ElementAt(4);
            numericUpDown257.Value = (decimal)NGF.ElementAt(5);
            numericUpDown254.Value = (decimal)NGF.ElementAt(6);
            numericUpDown251.Value = (decimal)NGF.ElementAt(7);
            numericUpDown248.Value = (decimal)NGF.ElementAt(8);
            numericUpDown245.Value = (decimal)NGF.ElementAt(9);
            numericUpDown242.Value = (decimal)NGF.ElementAt(10);
            numericUpDown239.Value = (decimal)NGF.ElementAt(11);
            numericUpDown236.Value = (decimal)NGF.ElementAt(12);

            numericUpDown271.Value = (decimal)NGO.ElementAt(0);
            numericUpDown268.Value = (decimal)NGO.ElementAt(1);
            numericUpDown265.Value = (decimal)NGO.ElementAt(2);
            numericUpDown262.Value = (decimal)NGO.ElementAt(3);
            numericUpDown259.Value = (decimal)NGO.ElementAt(4);
            numericUpDown256.Value = (decimal)NGO.ElementAt(5);
            numericUpDown253.Value = (decimal)NGO.ElementAt(6);
            numericUpDown250.Value = (decimal)NGO.ElementAt(7);
            numericUpDown247.Value = (decimal)NGO.ElementAt(8);
            numericUpDown244.Value = (decimal)NGO.ElementAt(9);
            numericUpDown241.Value = (decimal)NGO.ElementAt(10);
            numericUpDown238.Value = (decimal)NGO.ElementAt(11);
            numericUpDown235.Value = (decimal)NGO.ElementAt(12);
            #endregion
            #region Table 6 numericUpDown assignments
            numericUpDown234.Value = (decimal)BDFS.ElementAt(0);
            numericUpDown231.Value = (decimal)BDFS.ElementAt(1);
            numericUpDown228.Value = (decimal)BDFS.ElementAt(2);
            numericUpDown225.Value = (decimal)BDFS.ElementAt(3);
            numericUpDown222.Value = (decimal)BDFS.ElementAt(4);
            numericUpDown219.Value = (decimal)BDFS.ElementAt(5);
            numericUpDown216.Value = (decimal)BDFS.ElementAt(6);
            numericUpDown213.Value = (decimal)BDFS.ElementAt(7);
            numericUpDown210.Value = (decimal)BDFS.ElementAt(8);
            numericUpDown207.Value = (decimal)BDFS.ElementAt(9);
            numericUpDown204.Value = (decimal)BDFS.ElementAt(10);
            numericUpDown201.Value = (decimal)BDFS.ElementAt(11);
            numericUpDown198.Value = (decimal)BDFS.ElementAt(12);

            numericUpDown233.Value = (decimal)BDF.ElementAt(0);
            numericUpDown230.Value = (decimal)BDF.ElementAt(1);
            numericUpDown227.Value = (decimal)BDF.ElementAt(2);
            numericUpDown224.Value = (decimal)BDF.ElementAt(3);
            numericUpDown221.Value = (decimal)BDF.ElementAt(4);
            numericUpDown218.Value = (decimal)BDF.ElementAt(5);
            numericUpDown215.Value = (decimal)BDF.ElementAt(6);
            numericUpDown212.Value = (decimal)BDF.ElementAt(7);
            numericUpDown209.Value = (decimal)BDF.ElementAt(8);
            numericUpDown206.Value = (decimal)BDF.ElementAt(9);
            numericUpDown203.Value = (decimal)BDF.ElementAt(10);
            numericUpDown200.Value = (decimal)BDF.ElementAt(11);
            numericUpDown197.Value = (decimal)BDF.ElementAt(12);

            numericUpDown232.Value = (decimal)BDO.ElementAt(0);
            numericUpDown229.Value = (decimal)BDO.ElementAt(1);
            numericUpDown226.Value = (decimal)BDO.ElementAt(2);
            numericUpDown223.Value = (decimal)BDO.ElementAt(3);
            numericUpDown220.Value = (decimal)BDO.ElementAt(4);
            numericUpDown217.Value = (decimal)BDO.ElementAt(5);
            numericUpDown214.Value = (decimal)BDO.ElementAt(6);
            numericUpDown211.Value = (decimal)BDO.ElementAt(7);
            numericUpDown208.Value = (decimal)BDO.ElementAt(8);
            numericUpDown205.Value = (decimal)BDO.ElementAt(9);
            numericUpDown202.Value = (decimal)BDO.ElementAt(10);
            numericUpDown199.Value = (decimal)BDO.ElementAt(11);
            numericUpDown196.Value = (decimal)BDO.ElementAt(12);
            #endregion
            #region Table 7 numericUpDown assignments
            numericUpDown312.Value = (decimal)FTFS.ElementAt(0);
            numericUpDown309.Value = (decimal)FTFS.ElementAt(1);
            numericUpDown306.Value = (decimal)FTFS.ElementAt(2);
            numericUpDown303.Value = (decimal)FTFS.ElementAt(3);
            numericUpDown300.Value = (decimal)FTFS.ElementAt(4);
            numericUpDown297.Value = (decimal)FTFS.ElementAt(5);
            numericUpDown294.Value = (decimal)FTFS.ElementAt(6);
            numericUpDown291.Value = (decimal)FTFS.ElementAt(7);
            numericUpDown288.Value = (decimal)FTFS.ElementAt(8);
            numericUpDown285.Value = (decimal)FTFS.ElementAt(9);
            numericUpDown282.Value = (decimal)FTFS.ElementAt(10);
            numericUpDown279.Value = (decimal)FTFS.ElementAt(11);
            numericUpDown276.Value = (decimal)FTFS.ElementAt(12);

            numericUpDown311.Value = (decimal)FTF.ElementAt(0);
            numericUpDown308.Value = (decimal)FTF.ElementAt(1);
            numericUpDown305.Value = (decimal)FTF.ElementAt(2);
            numericUpDown302.Value = (decimal)FTF.ElementAt(3);
            numericUpDown299.Value = (decimal)FTF.ElementAt(4);
            numericUpDown296.Value = (decimal)FTF.ElementAt(5);
            numericUpDown293.Value = (decimal)FTF.ElementAt(6);
            numericUpDown290.Value = (decimal)FTF.ElementAt(7);
            numericUpDown287.Value = (decimal)FTF.ElementAt(8);
            numericUpDown284.Value = (decimal)FTF.ElementAt(9);
            numericUpDown281.Value = (decimal)FTF.ElementAt(10);
            numericUpDown278.Value = (decimal)FTF.ElementAt(11);
            numericUpDown275.Value = (decimal)FTF.ElementAt(12);

            numericUpDown310.Value = (decimal)FTO.ElementAt(0);
            numericUpDown307.Value = (decimal)FTO.ElementAt(1);
            numericUpDown304.Value = (decimal)FTO.ElementAt(2);
            numericUpDown301.Value = (decimal)FTO.ElementAt(3);
            numericUpDown298.Value = (decimal)FTO.ElementAt(4);
            numericUpDown295.Value = (decimal)FTO.ElementAt(5);
            numericUpDown292.Value = (decimal)FTO.ElementAt(6);
            numericUpDown289.Value = (decimal)FTO.ElementAt(7);
            numericUpDown286.Value = (decimal)FTO.ElementAt(8);
            numericUpDown283.Value = (decimal)FTO.ElementAt(9);
            numericUpDown280.Value = (decimal)FTO.ElementAt(10);
            numericUpDown277.Value = (decimal)FTO.ElementAt(11);
            numericUpDown274.Value = (decimal)FTO.ElementAt(12);
            #endregion
        }
        public string selectFuelType()
        {
            if (te.AuxiliaryEngineFuelType == 1)
            {
                return "Conventional Diesel";
            }
            else if (te.AuxiliaryEngineFuelType == 2)
            {
                return "Residual Oil";
            }
            else if (te.AuxiliaryEngineFuelType == 3)
            {
                return "Low Sulfur Diesel";
            }
            else if (te.AuxiliaryEngineFuelType == 4)
            {
                return "Natural Gas";
            }
            else if (te.AuxiliaryEngineFuelType == 5)
            {
                return "Biodiesel";
            }
            else if (te.AuxiliaryEngineFuelType == 6)
            {
                return "Fischer Tropsch Diesel";
            }
            else
                return " You must have broken it somewhere";
        }

        public void correctTextForInputs()
        {
            //Loading the correct text for the results sheet, based on the inputs
            label175.Text = selectFuelType();
            label61.Text = selectFuelType();
            label64.Text = selectFuelType();
            label86.Text = selectFuelType();
            label108.Text = selectFuelType();
            label130.Text = selectFuelType();
            label152.Text = selectFuelType();
            label54.Text = te.VesselTypeID;
            label67.Text = te.VesselTypeID;
            label89.Text = te.VesselTypeID;
            label154.Text = te.VesselTypeID;
            label111.Text = te.VesselTypeID;
            label133.Text = te.VesselTypeID;
            label154.Text = te.VesselTypeID;
            label155.Text = te.VesselTypeID;
        }
        //This is the sheet that will display all of the numeric results from the simulation, as opposed to the graphical ones which will be on another sheet that comes up at the same time
        private void ResultsSheet_Load(object sender, EventArgs e)
        {
            correctTextForInputs();
        }
    }
}
