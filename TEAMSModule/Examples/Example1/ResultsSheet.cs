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
        #region Table 8 Variable Lists
        public List<double> T8_FSM = new List<double>();
        public List<double> T8_FSA = new List<double>();
        public List<double> T8_FM = new List<double>();
        public List<double> T8_FA = new List<double>();
        public List<double> T8_OM = new List<double>();
        public List<double> T8_OA = new List<double>();
        public List<double> T8_Total = new List<double>();
        public List<double> T8_CentFS = new List<double>();
        public List<double> T8_CentF = new List<double>();
        public List<double> T8_CentO = new List<double>();
        #endregion
        #region Table 9 Variable Lists
        public List<double> T9_FSM = new List<double>();
        public List<double> T9_FSA = new List<double>();
        public List<double> T9_FM = new List<double>();
        public List<double> T9_FA = new List<double>();
        public List<double> T9_OM = new List<double>();
        public List<double> T9_OA = new List<double>();
        public List<double> T9_Total = new List<double>();
        public List<double> T9_CentFS = new List<double>();
        public List<double> T9_CentF = new List<double>();
        public List<double> T9_CentO = new List<double>();
        #endregion
        #region Table 10 Variable Lists
        public List<double> T10_FSM = new List<double>();
        public List<double> T10_FSA = new List<double>();
        public List<double> T10_FM = new List<double>();
        public List<double> T10_FA = new List<double>();
        public List<double> T10_OM = new List<double>();
        public List<double> T10_OA = new List<double>();
        public List<double> T10_Total = new List<double>();
        public List<double> T10_CentFS = new List<double>();
        public List<double> T10_CentF = new List<double>();
        public List<double> T10_CentO = new List<double>();
        #endregion
        #region Table 11 Variable Lists
        public List<double> T11_FSM = new List<double>();
        public List<double> T11_FSA = new List<double>();
        public List<double> T11_FM = new List<double>();
        public List<double> T11_FA = new List<double>();
        public List<double> T11_OM = new List<double>();
        public List<double> T11_OA = new List<double>();
        public List<double> T11_Total = new List<double>();
        public List<double> T11_CentFS = new List<double>();
        public List<double> T11_CentF = new List<double>();
        public List<double> T11_CentO = new List<double>();
        #endregion
        #region Table 12 Variable Lists
        public List<double> T12_FSM = new List<double>();
        public List<double> T12_FSA = new List<double>();
        public List<double> T12_FM = new List<double>();
        public List<double> T12_FA = new List<double>();
        public List<double> T12_OM = new List<double>();
        public List<double> T12_OA = new List<double>();
        public List<double> T12_Total = new List<double>();
        public List<double> T12_CentFS = new List<double>();
        public List<double> T12_CentF = new List<double>();
        public List<double> T12_CentO = new List<double>();
        #endregion
        #region Table 13 Variable Lists
        public List<double> T13_FSM = new List<double>();
        public List<double> T13_FSA = new List<double>();
        public List<double> T13_FM = new List<double>();
        public List<double> T13_FA = new List<double>();
        public List<double> T13_OM = new List<double>();
        public List<double> T13_OA = new List<double>();
        public List<double> T13_Total = new List<double>();
        public List<double> T13_CentFS = new List<double>();
        public List<double> T13_CentF = new List<double>();
        public List<double> T13_CentO = new List<double>();
        #endregion
        #region Table 14 Variable Lists
        public List<double> T14_RO = new List<double>();
        public List<double> T14_LSD = new List<double>();
        public List<double> T14_NG = new List<double>();
        public List<double> T14_BD = new List<double>();
        public List<double> T14_FTD = new List<double>();

        #endregion
        public ResultsSheet(TEAMS t)
        {
            te = t;
            InitializeComponent();
            populateListsWithResults();
            correctNumbersDisplayed();
        }

        //This is where you populate the lists that hold all the data in this form (Lists are needed since there are well over a thousand variables) SO here you will do the calculations
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
            #region Table 8 List Population
            T8_FSM.Add(0);
            T8_FSM.Add(1);
            T8_FSM.Add(2);
            T8_FSM.Add(3);
            T8_FSM.Add(4);
            T8_FSM.Add(5);
            T8_FSM.Add(6);
            T8_FSM.Add(7);
            T8_FSM.Add(8);
            T8_FSM.Add(9);
            T8_FSM.Add(10);
            T8_FSM.Add(11);
            T8_FSM.Add(12);

            T8_FSA.Add(0);
            T8_FSA.Add(1);
            T8_FSA.Add(2);
            T8_FSA.Add(3);
            T8_FSA.Add(4);
            T8_FSA.Add(5);
            T8_FSA.Add(6);
            T8_FSA.Add(7);
            T8_FSA.Add(8);
            T8_FSA.Add(9);
            T8_FSA.Add(10);
            T8_FSA.Add(11);
            T8_FSA.Add(12);

            T8_FM.Add(0);
            T8_FM.Add(1);
            T8_FM.Add(2);
            T8_FM.Add(3);
            T8_FM.Add(4);
            T8_FM.Add(5);
            T8_FM.Add(6);
            T8_FM.Add(7);
            T8_FM.Add(8);
            T8_FM.Add(9);
            T8_FM.Add(10);
            T8_FM.Add(11);
            T8_FM.Add(12);

            T8_FA.Add(0);
            T8_FA.Add(1);
            T8_FA.Add(2);
            T8_FA.Add(3);
            T8_FA.Add(4);
            T8_FA.Add(5);
            T8_FA.Add(6);
            T8_FA.Add(7);
            T8_FA.Add(8);
            T8_FA.Add(9);
            T8_FA.Add(10);
            T8_FA.Add(11);
            T8_FA.Add(12);

            T8_OM.Add(0);
            T8_OM.Add(1);
            T8_OM.Add(2);
            T8_OM.Add(3);
            T8_OM.Add(4);
            T8_OM.Add(5);
            T8_OM.Add(6);
            T8_OM.Add(7);
            T8_OM.Add(8);
            T8_OM.Add(9);
            T8_OM.Add(10);
            T8_OM.Add(11);
            T8_OM.Add(12);

            T8_OA.Add(0);
            T8_OA.Add(1);
            T8_OA.Add(2);
            T8_OA.Add(3);
            T8_OA.Add(4);
            T8_OA.Add(5);
            T8_OA.Add(6);
            T8_OA.Add(7);
            T8_OA.Add(8);
            T8_OA.Add(9);
            T8_OA.Add(10);
            T8_OA.Add(11);
            T8_OA.Add(12);

            T8_Total.Add(0);
            T8_Total.Add(1);
            T8_Total.Add(2);
            T8_Total.Add(3);
            T8_Total.Add(4);
            T8_Total.Add(5);
            T8_Total.Add(6);
            T8_Total.Add(7);
            T8_Total.Add(8);
            T8_Total.Add(9);
            T8_Total.Add(10);
            T8_Total.Add(11);
            T8_Total.Add(12);

            T8_CentFS.Add(0);
            T8_CentFS.Add(1);
            T8_CentFS.Add(2);
            T8_CentFS.Add(3);
            T8_CentFS.Add(4);
            T8_CentFS.Add(5);
            T8_CentFS.Add(6);
            T8_CentFS.Add(7);
            T8_CentFS.Add(8);
            T8_CentFS.Add(9);
            T8_CentFS.Add(10);
            T8_CentFS.Add(11);
            T8_CentFS.Add(12);

            T8_CentF.Add(0);
            T8_CentF.Add(1);
            T8_CentF.Add(2);
            T8_CentF.Add(3);
            T8_CentF.Add(4);
            T8_CentF.Add(5);
            T8_CentF.Add(6);
            T8_CentF.Add(7);
            T8_CentF.Add(8);
            T8_CentF.Add(9);
            T8_CentF.Add(10);
            T8_CentF.Add(11);
            T8_CentF.Add(12);

            T8_CentO.Add(0);
            T8_CentO.Add(1);
            T8_CentO.Add(2);
            T8_CentO.Add(3);
            T8_CentO.Add(4);
            T8_CentO.Add(5);
            T8_CentO.Add(6);
            T8_CentO.Add(7);
            T8_CentO.Add(8);
            T8_CentO.Add(9);
            T8_CentO.Add(10);
            T8_CentO.Add(11);
            T8_CentO.Add(12);
            #endregion
            #region Table 9 List Population
            T9_FSM.Add(0);
            T9_FSM.Add(1);
            T9_FSM.Add(2);
            T9_FSM.Add(3);
            T9_FSM.Add(4);
            T9_FSM.Add(5);
            T9_FSM.Add(6);
            T9_FSM.Add(7);
            T9_FSM.Add(8);
            T9_FSM.Add(9);
            T9_FSM.Add(10);
            T9_FSM.Add(11);
            T9_FSM.Add(12);

            T9_FSA.Add(0);
            T9_FSA.Add(1);
            T9_FSA.Add(2);
            T9_FSA.Add(3);
            T9_FSA.Add(4);
            T9_FSA.Add(5);
            T9_FSA.Add(6);
            T9_FSA.Add(7);
            T9_FSA.Add(8);
            T9_FSA.Add(9);
            T9_FSA.Add(10);
            T9_FSA.Add(11);
            T9_FSA.Add(12);

            T9_FM.Add(0);
            T9_FM.Add(1);
            T9_FM.Add(2);
            T9_FM.Add(3);
            T9_FM.Add(4);
            T9_FM.Add(5);
            T9_FM.Add(6);
            T9_FM.Add(7);
            T9_FM.Add(8);
            T9_FM.Add(9);
            T9_FM.Add(10);
            T9_FM.Add(11);
            T9_FM.Add(12);

            T9_FA.Add(0);
            T9_FA.Add(1);
            T9_FA.Add(2);
            T9_FA.Add(3);
            T9_FA.Add(4);
            T9_FA.Add(5);
            T9_FA.Add(6);
            T9_FA.Add(7);
            T9_FA.Add(8);
            T9_FA.Add(9);
            T9_FA.Add(10);
            T9_FA.Add(11);
            T9_FA.Add(12);

            T9_OM.Add(0);
            T9_OM.Add(1);
            T9_OM.Add(2);
            T9_OM.Add(3);
            T9_OM.Add(4);
            T9_OM.Add(5);
            T9_OM.Add(6);
            T9_OM.Add(7);
            T9_OM.Add(8);
            T9_OM.Add(9);
            T9_OM.Add(10);
            T9_OM.Add(11);
            T9_OM.Add(12);

            T9_OA.Add(0);
            T9_OA.Add(1);
            T9_OA.Add(2);
            T9_OA.Add(3);
            T9_OA.Add(4);
            T9_OA.Add(5);
            T9_OA.Add(6);
            T9_OA.Add(7);
            T9_OA.Add(8);
            T9_OA.Add(9);
            T9_OA.Add(10);
            T9_OA.Add(11);
            T9_OA.Add(12);

            T9_Total.Add(0);
            T9_Total.Add(1);
            T9_Total.Add(2);
            T9_Total.Add(3);
            T9_Total.Add(4);
            T9_Total.Add(5);
            T9_Total.Add(6);
            T9_Total.Add(7);
            T9_Total.Add(8);
            T9_Total.Add(9);
            T9_Total.Add(10);
            T9_Total.Add(11);
            T9_Total.Add(12);

            T9_CentFS.Add(0);
            T9_CentFS.Add(1);
            T9_CentFS.Add(2);
            T9_CentFS.Add(3);
            T9_CentFS.Add(4);
            T9_CentFS.Add(5);
            T9_CentFS.Add(6);
            T9_CentFS.Add(7);
            T9_CentFS.Add(8);
            T9_CentFS.Add(9);
            T9_CentFS.Add(10);
            T9_CentFS.Add(11);
            T9_CentFS.Add(12);

            T9_CentF.Add(0);
            T9_CentF.Add(1);
            T9_CentF.Add(2);
            T9_CentF.Add(3);
            T9_CentF.Add(4);
            T9_CentF.Add(5);
            T9_CentF.Add(6);
            T9_CentF.Add(7);
            T9_CentF.Add(8);
            T9_CentF.Add(9);
            T9_CentF.Add(10);
            T9_CentF.Add(11);
            T9_CentF.Add(12);

            T9_CentO.Add(0);
            T9_CentO.Add(1);
            T9_CentO.Add(2);
            T9_CentO.Add(3);
            T9_CentO.Add(4);
            T9_CentO.Add(5);
            T9_CentO.Add(6);
            T9_CentO.Add(7);
            T9_CentO.Add(8);
            T9_CentO.Add(9);
            T9_CentO.Add(10);
            T9_CentO.Add(11);
            T9_CentO.Add(12);
            #endregion
            #region Table 10 List Population
            T10_FSM.Add(0);
            T10_FSM.Add(1);
            T10_FSM.Add(2);
            T10_FSM.Add(3);
            T10_FSM.Add(4);
            T10_FSM.Add(5);
            T10_FSM.Add(6);
            T10_FSM.Add(7);
            T10_FSM.Add(8);
            T10_FSM.Add(9);
            T10_FSM.Add(10);
            T10_FSM.Add(11);
            T10_FSM.Add(12);

            T10_FSA.Add(0);
            T10_FSA.Add(1);
            T10_FSA.Add(2);
            T10_FSA.Add(3);
            T10_FSA.Add(4);
            T10_FSA.Add(5);
            T10_FSA.Add(6);
            T10_FSA.Add(7);
            T10_FSA.Add(8);
            T10_FSA.Add(9);
            T10_FSA.Add(10);
            T10_FSA.Add(11);
            T10_FSA.Add(12);

            T10_FM.Add(0);
            T10_FM.Add(1);
            T10_FM.Add(2);
            T10_FM.Add(3);
            T10_FM.Add(4);
            T10_FM.Add(5);
            T10_FM.Add(6);
            T10_FM.Add(7);
            T10_FM.Add(8);
            T10_FM.Add(9);
            T10_FM.Add(10);
            T10_FM.Add(11);
            T10_FM.Add(12);

            T10_FA.Add(0);
            T10_FA.Add(1);
            T10_FA.Add(2);
            T10_FA.Add(3);
            T10_FA.Add(4);
            T10_FA.Add(5);
            T10_FA.Add(6);
            T10_FA.Add(7);
            T10_FA.Add(8);
            T10_FA.Add(9);
            T10_FA.Add(10);
            T10_FA.Add(11);
            T10_FA.Add(12);

            T10_OM.Add(0);
            T10_OM.Add(1);
            T10_OM.Add(2);
            T10_OM.Add(3);
            T10_OM.Add(4);
            T10_OM.Add(5);
            T10_OM.Add(6);
            T10_OM.Add(7);
            T10_OM.Add(8);
            T10_OM.Add(9);
            T10_OM.Add(10);
            T10_OM.Add(11);
            T10_OM.Add(12);

            T10_OA.Add(0);
            T10_OA.Add(1);
            T10_OA.Add(2);
            T10_OA.Add(3);
            T10_OA.Add(4);
            T10_OA.Add(5);
            T10_OA.Add(6);
            T10_OA.Add(7);
            T10_OA.Add(8);
            T10_OA.Add(9);
            T10_OA.Add(10);
            T10_OA.Add(11);
            T10_OA.Add(12);

            T10_Total.Add(0);
            T10_Total.Add(1);
            T10_Total.Add(2);
            T10_Total.Add(3);
            T10_Total.Add(4);
            T10_Total.Add(5);
            T10_Total.Add(6);
            T10_Total.Add(7);
            T10_Total.Add(8);
            T10_Total.Add(9);
            T10_Total.Add(10);
            T10_Total.Add(11);
            T10_Total.Add(12);

            T10_CentFS.Add(0);
            T10_CentFS.Add(1);
            T10_CentFS.Add(2);
            T10_CentFS.Add(3);
            T10_CentFS.Add(4);
            T10_CentFS.Add(5);
            T10_CentFS.Add(6);
            T10_CentFS.Add(7);
            T10_CentFS.Add(8);
            T10_CentFS.Add(9);
            T10_CentFS.Add(10);
            T10_CentFS.Add(11);
            T10_CentFS.Add(12);

            T10_CentF.Add(0);
            T10_CentF.Add(1);
            T10_CentF.Add(2);
            T10_CentF.Add(3);
            T10_CentF.Add(4);
            T10_CentF.Add(5);
            T10_CentF.Add(6);
            T10_CentF.Add(7);
            T10_CentF.Add(8);
            T10_CentF.Add(9);
            T10_CentF.Add(10);
            T10_CentF.Add(11);
            T10_CentF.Add(12);

            T10_CentO.Add(0);
            T10_CentO.Add(1);
            T10_CentO.Add(2);
            T10_CentO.Add(3);
            T10_CentO.Add(4);
            T10_CentO.Add(5);
            T10_CentO.Add(6);
            T10_CentO.Add(7);
            T10_CentO.Add(8);
            T10_CentO.Add(9);
            T10_CentO.Add(10);
            T10_CentO.Add(11);
            T10_CentO.Add(12);
            #endregion
            #region Table 11 List Population
            T11_FSM.Add(0);
            T11_FSM.Add(1);
            T11_FSM.Add(2);
            T11_FSM.Add(3);
            T11_FSM.Add(4);
            T11_FSM.Add(5);
            T11_FSM.Add(6);
            T11_FSM.Add(7);
            T11_FSM.Add(8);
            T11_FSM.Add(9);
            T11_FSM.Add(10);
            T11_FSM.Add(11);
            T11_FSM.Add(12);

            T11_FSA.Add(0);
            T11_FSA.Add(1);
            T11_FSA.Add(2);
            T11_FSA.Add(3);
            T11_FSA.Add(4);
            T11_FSA.Add(5);
            T11_FSA.Add(6);
            T11_FSA.Add(7);
            T11_FSA.Add(8);
            T11_FSA.Add(9);
            T11_FSA.Add(10);
            T11_FSA.Add(11);
            T11_FSA.Add(12);

            T11_FM.Add(0);
            T11_FM.Add(1);
            T11_FM.Add(2);
            T11_FM.Add(3);
            T11_FM.Add(4);
            T11_FM.Add(5);
            T11_FM.Add(6);
            T11_FM.Add(7);
            T11_FM.Add(8);
            T11_FM.Add(9);
            T11_FM.Add(10);
            T11_FM.Add(11);
            T11_FM.Add(12);

            T11_FA.Add(0);
            T11_FA.Add(1);
            T11_FA.Add(2);
            T11_FA.Add(3);
            T11_FA.Add(4);
            T11_FA.Add(5);
            T11_FA.Add(6);
            T11_FA.Add(7);
            T11_FA.Add(8);
            T11_FA.Add(9);
            T11_FA.Add(10);
            T11_FA.Add(11);
            T11_FA.Add(12);

            T11_OM.Add(0);
            T11_OM.Add(1);
            T11_OM.Add(2);
            T11_OM.Add(3);
            T11_OM.Add(4);
            T11_OM.Add(5);
            T11_OM.Add(6);
            T11_OM.Add(7);
            T11_OM.Add(8);
            T11_OM.Add(9);
            T11_OM.Add(10);
            T11_OM.Add(11);
            T11_OM.Add(12);

            T11_OA.Add(0);
            T11_OA.Add(1);
            T11_OA.Add(2);
            T11_OA.Add(3);
            T11_OA.Add(4);
            T11_OA.Add(5);
            T11_OA.Add(6);
            T11_OA.Add(7);
            T11_OA.Add(8);
            T11_OA.Add(9);
            T11_OA.Add(10);
            T11_OA.Add(11);
            T11_OA.Add(12);

            T11_Total.Add(0);
            T11_Total.Add(1);
            T11_Total.Add(2);
            T11_Total.Add(3);
            T11_Total.Add(4);
            T11_Total.Add(5);
            T11_Total.Add(6);
            T11_Total.Add(7);
            T11_Total.Add(8);
            T11_Total.Add(9);
            T11_Total.Add(10);
            T11_Total.Add(11);
            T11_Total.Add(12);

            T11_CentFS.Add(0);
            T11_CentFS.Add(1);
            T11_CentFS.Add(2);
            T11_CentFS.Add(3);
            T11_CentFS.Add(4);
            T11_CentFS.Add(5);
            T11_CentFS.Add(6);
            T11_CentFS.Add(7);
            T11_CentFS.Add(8);
            T11_CentFS.Add(9);
            T11_CentFS.Add(10);
            T11_CentFS.Add(11);
            T11_CentFS.Add(12);

            T11_CentF.Add(0);
            T11_CentF.Add(1);
            T11_CentF.Add(2);
            T11_CentF.Add(3);
            T11_CentF.Add(4);
            T11_CentF.Add(5);
            T11_CentF.Add(6);
            T11_CentF.Add(7);
            T11_CentF.Add(8);
            T11_CentF.Add(9);
            T11_CentF.Add(10);
            T11_CentF.Add(11);
            T11_CentF.Add(12);

            T11_CentO.Add(0);
            T11_CentO.Add(1);
            T11_CentO.Add(2);
            T11_CentO.Add(3);
            T11_CentO.Add(4);
            T11_CentO.Add(5);
            T11_CentO.Add(6);
            T11_CentO.Add(7);
            T11_CentO.Add(8);
            T11_CentO.Add(9);
            T11_CentO.Add(10);
            T11_CentO.Add(11);
            T11_CentO.Add(12);
            #endregion
            #region Table 12 List Population
            T12_FSM.Add(0);
            T12_FSM.Add(1);
            T12_FSM.Add(2);
            T12_FSM.Add(3);
            T12_FSM.Add(4);
            T12_FSM.Add(5);
            T12_FSM.Add(6);
            T12_FSM.Add(7);
            T12_FSM.Add(8);
            T12_FSM.Add(9);
            T12_FSM.Add(10);
            T12_FSM.Add(11);
            T12_FSM.Add(12);

            T12_FSA.Add(0);
            T12_FSA.Add(1);
            T12_FSA.Add(2);
            T12_FSA.Add(3);
            T12_FSA.Add(4);
            T12_FSA.Add(5);
            T12_FSA.Add(6);
            T12_FSA.Add(7);
            T12_FSA.Add(8);
            T12_FSA.Add(9);
            T12_FSA.Add(10);
            T12_FSA.Add(11);
            T12_FSA.Add(12);

            T12_FM.Add(0);
            T12_FM.Add(1);
            T12_FM.Add(2);
            T12_FM.Add(3);
            T12_FM.Add(4);
            T12_FM.Add(5);
            T12_FM.Add(6);
            T12_FM.Add(7);
            T12_FM.Add(8);
            T12_FM.Add(9);
            T12_FM.Add(10);
            T12_FM.Add(11);
            T12_FM.Add(12);

            T12_FA.Add(0);
            T12_FA.Add(1);
            T12_FA.Add(2);
            T12_FA.Add(3);
            T12_FA.Add(4);
            T12_FA.Add(5);
            T12_FA.Add(6);
            T12_FA.Add(7);
            T12_FA.Add(8);
            T12_FA.Add(9);
            T12_FA.Add(10);
            T12_FA.Add(11);
            T12_FA.Add(12);

            T12_OM.Add(0);
            T12_OM.Add(1);
            T12_OM.Add(2);
            T12_OM.Add(3);
            T12_OM.Add(4);
            T12_OM.Add(5);
            T12_OM.Add(6);
            T12_OM.Add(7);
            T12_OM.Add(8);
            T12_OM.Add(9);
            T12_OM.Add(10);
            T12_OM.Add(11);
            T12_OM.Add(12);

            T12_OA.Add(0);
            T12_OA.Add(1);
            T12_OA.Add(2);
            T12_OA.Add(3);
            T12_OA.Add(4);
            T12_OA.Add(5);
            T12_OA.Add(6);
            T12_OA.Add(7);
            T12_OA.Add(8);
            T12_OA.Add(9);
            T12_OA.Add(10);
            T12_OA.Add(11);
            T12_OA.Add(12);

            T12_Total.Add(0);
            T12_Total.Add(1);
            T12_Total.Add(2);
            T12_Total.Add(3);
            T12_Total.Add(4);
            T12_Total.Add(5);
            T12_Total.Add(6);
            T12_Total.Add(7);
            T12_Total.Add(8);
            T12_Total.Add(9);
            T12_Total.Add(10);
            T12_Total.Add(11);
            T12_Total.Add(12);

            T12_CentFS.Add(0);
            T12_CentFS.Add(1);
            T12_CentFS.Add(2);
            T12_CentFS.Add(3);
            T12_CentFS.Add(4);
            T12_CentFS.Add(5);
            T12_CentFS.Add(6);
            T12_CentFS.Add(7);
            T12_CentFS.Add(8);
            T12_CentFS.Add(9);
            T12_CentFS.Add(10);
            T12_CentFS.Add(11);
            T12_CentFS.Add(12);

            T12_CentF.Add(0);
            T12_CentF.Add(1);
            T12_CentF.Add(2);
            T12_CentF.Add(3);
            T12_CentF.Add(4);
            T12_CentF.Add(5);
            T12_CentF.Add(6);
            T12_CentF.Add(7);
            T12_CentF.Add(8);
            T12_CentF.Add(9);
            T12_CentF.Add(10);
            T12_CentF.Add(11);
            T12_CentF.Add(12);

            T12_CentO.Add(0);
            T12_CentO.Add(1);
            T12_CentO.Add(2);
            T12_CentO.Add(3);
            T12_CentO.Add(4);
            T12_CentO.Add(5);
            T12_CentO.Add(6);
            T12_CentO.Add(7);
            T12_CentO.Add(8);
            T12_CentO.Add(9);
            T12_CentO.Add(10);
            T12_CentO.Add(11);
            T12_CentO.Add(12);
            #endregion
            #region Table 13 List Population
            T13_FSM.Add(0);
            T13_FSM.Add(1);
            T13_FSM.Add(2);
            T13_FSM.Add(3);
            T13_FSM.Add(4);
            T13_FSM.Add(5);
            T13_FSM.Add(6);
            T13_FSM.Add(7);
            T13_FSM.Add(8);
            T13_FSM.Add(9);
            T13_FSM.Add(10);
            T13_FSM.Add(11);
            T13_FSM.Add(12);

            T13_FSA.Add(0);
            T13_FSA.Add(1);
            T13_FSA.Add(2);
            T13_FSA.Add(3);
            T13_FSA.Add(4);
            T13_FSA.Add(5);
            T13_FSA.Add(6);
            T13_FSA.Add(7);
            T13_FSA.Add(8);
            T13_FSA.Add(9);
            T13_FSA.Add(10);
            T13_FSA.Add(11);
            T13_FSA.Add(12);

            T13_FM.Add(0);
            T13_FM.Add(1);
            T13_FM.Add(2);
            T13_FM.Add(3);
            T13_FM.Add(4);
            T13_FM.Add(5);
            T13_FM.Add(6);
            T13_FM.Add(7);
            T13_FM.Add(8);
            T13_FM.Add(9);
            T13_FM.Add(10);
            T13_FM.Add(11);
            T13_FM.Add(12);

            T13_FA.Add(0);
            T13_FA.Add(1);
            T13_FA.Add(2);
            T13_FA.Add(3);
            T13_FA.Add(4);
            T13_FA.Add(5);
            T13_FA.Add(6);
            T13_FA.Add(7);
            T13_FA.Add(8);
            T13_FA.Add(9);
            T13_FA.Add(10);
            T13_FA.Add(11);
            T13_FA.Add(12);

            T13_OM.Add(0);
            T13_OM.Add(1);
            T13_OM.Add(2);
            T13_OM.Add(3);
            T13_OM.Add(4);
            T13_OM.Add(5);
            T13_OM.Add(6);
            T13_OM.Add(7);
            T13_OM.Add(8);
            T13_OM.Add(9);
            T13_OM.Add(10);
            T13_OM.Add(11);
            T13_OM.Add(12);

            T13_OA.Add(0);
            T13_OA.Add(1);
            T13_OA.Add(2);
            T13_OA.Add(3);
            T13_OA.Add(4);
            T13_OA.Add(5);
            T13_OA.Add(6);
            T13_OA.Add(7);
            T13_OA.Add(8);
            T13_OA.Add(9);
            T13_OA.Add(10);
            T13_OA.Add(11);
            T13_OA.Add(12);

            T13_Total.Add(0);
            T13_Total.Add(1);
            T13_Total.Add(2);
            T13_Total.Add(3);
            T13_Total.Add(4);
            T13_Total.Add(5);
            T13_Total.Add(6);
            T13_Total.Add(7);
            T13_Total.Add(8);
            T13_Total.Add(9);
            T13_Total.Add(10);
            T13_Total.Add(11);
            T13_Total.Add(12);

            T13_CentFS.Add(0);
            T13_CentFS.Add(1);
            T13_CentFS.Add(2);
            T13_CentFS.Add(3);
            T13_CentFS.Add(4);
            T13_CentFS.Add(5);
            T13_CentFS.Add(6);
            T13_CentFS.Add(7);
            T13_CentFS.Add(8);
            T13_CentFS.Add(9);
            T13_CentFS.Add(10);
            T13_CentFS.Add(11);
            T13_CentFS.Add(12);

            T13_CentF.Add(0);
            T13_CentF.Add(1);
            T13_CentF.Add(2);
            T13_CentF.Add(3);
            T13_CentF.Add(4);
            T13_CentF.Add(5);
            T13_CentF.Add(6);
            T13_CentF.Add(7);
            T13_CentF.Add(8);
            T13_CentF.Add(9);
            T13_CentF.Add(10);
            T13_CentF.Add(11);
            T13_CentF.Add(12);

            T13_CentO.Add(0);
            T13_CentO.Add(1);
            T13_CentO.Add(2);
            T13_CentO.Add(3);
            T13_CentO.Add(4);
            T13_CentO.Add(5);
            T13_CentO.Add(6);
            T13_CentO.Add(7);
            T13_CentO.Add(8);
            T13_CentO.Add(9);
            T13_CentO.Add(10);
            T13_CentO.Add(11);
            T13_CentO.Add(12);
            #endregion
            #region Table 14 List Population
            T14_RO.Add(0);
            T14_RO.Add(1);
            T14_RO.Add(2);
            T14_RO.Add(3);
            T14_RO.Add(4);
            T14_RO.Add(5);
            T14_RO.Add(6);
            T14_RO.Add(7);
            T14_RO.Add(8);
            T14_RO.Add(9);
            T14_RO.Add(10);
            T14_RO.Add(11);
            T14_RO.Add(12);

            T14_LSD.Add(0);
            T14_LSD.Add(1);
            T14_LSD.Add(2);
            T14_LSD.Add(3);
            T14_LSD.Add(4);
            T14_LSD.Add(5);
            T14_LSD.Add(6);
            T14_LSD.Add(7);
            T14_LSD.Add(8);
            T14_LSD.Add(9);
            T14_LSD.Add(10);
            T14_LSD.Add(11);
            T14_LSD.Add(12);

            T14_NG.Add(0);
            T14_NG.Add(1);
            T14_NG.Add(2);
            T14_NG.Add(3);
            T14_NG.Add(4);
            T14_NG.Add(5);
            T14_NG.Add(6);
            T14_NG.Add(7);
            T14_NG.Add(8);
            T14_NG.Add(9);
            T14_NG.Add(10);
            T14_NG.Add(11);
            T14_NG.Add(12);

            T14_BD.Add(0);
            T14_BD.Add(1);
            T14_BD.Add(2);
            T14_BD.Add(3);
            T14_BD.Add(4);
            T14_BD.Add(5);
            T14_BD.Add(6);
            T14_BD.Add(7);
            T14_BD.Add(8);
            T14_BD.Add(9);
            T14_BD.Add(10);
            T14_BD.Add(11);
            T14_BD.Add(12);

            T14_FTD.Add(0);
            T14_FTD.Add(1);
            T14_FTD.Add(2);
            T14_FTD.Add(3);
            T14_FTD.Add(4);
            T14_FTD.Add(5);
            T14_FTD.Add(6);
            T14_FTD.Add(7);
            T14_FTD.Add(8);
            T14_FTD.Add(9);
            T14_FTD.Add(10);
            T14_FTD.Add(11);
            T14_FTD.Add(12);
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
            #region Table 8 numericUpDown assignments
            numericUpDown353.Value = (decimal)T8_FSM.ElementAt(0);
            numericUpDown350.Value = (decimal)T8_FSM.ElementAt(1);
            numericUpDown347.Value = (decimal)T8_FSM.ElementAt(2);
            numericUpDown344.Value = (decimal)T8_FSM.ElementAt(3);
            numericUpDown341.Value = (decimal)T8_FSM.ElementAt(4);
            numericUpDown338.Value = (decimal)T8_FSM.ElementAt(5);
            numericUpDown335.Value = (decimal)T8_FSM.ElementAt(6);
            numericUpDown332.Value = (decimal)T8_FSM.ElementAt(7);
            numericUpDown329.Value = (decimal)T8_FSM.ElementAt(8);
            numericUpDown326.Value = (decimal)T8_FSM.ElementAt(9);
            numericUpDown323.Value = (decimal)T8_FSM.ElementAt(10);
            numericUpDown320.Value = (decimal)T8_FSM.ElementAt(11);
            numericUpDown317.Value = (decimal)T8_FSM.ElementAt(12);

            numericUpDown352.Value = (decimal)T8_FSA.ElementAt(0);
            numericUpDown349.Value = (decimal)T8_FSA.ElementAt(1);
            numericUpDown346.Value = (decimal)T8_FSA.ElementAt(2);
            numericUpDown343.Value = (decimal)T8_FSA.ElementAt(3);
            numericUpDown340.Value = (decimal)T8_FSA.ElementAt(4);
            numericUpDown337.Value = (decimal)T8_FSA.ElementAt(5);
            numericUpDown334.Value = (decimal)T8_FSA.ElementAt(6);
            numericUpDown331.Value = (decimal)T8_FSA.ElementAt(7);
            numericUpDown328.Value = (decimal)T8_FSA.ElementAt(8);
            numericUpDown325.Value = (decimal)T8_FSA.ElementAt(9);
            numericUpDown322.Value = (decimal)T8_FSA.ElementAt(10);
            numericUpDown319.Value = (decimal)T8_FSA.ElementAt(11);
            numericUpDown316.Value = (decimal)T8_FSA.ElementAt(12);

            numericUpDown366.Value = (decimal)T8_FM.ElementAt(0);
            numericUpDown364.Value = (decimal)T8_FM.ElementAt(1);
            numericUpDown362.Value = (decimal)T8_FM.ElementAt(2);
            numericUpDown360.Value = (decimal)T8_FM.ElementAt(3);
            numericUpDown358.Value = (decimal)T8_FM.ElementAt(4);
            numericUpDown356.Value = (decimal)T8_FM.ElementAt(5);
            numericUpDown354.Value = (decimal)T8_FM.ElementAt(6);
            numericUpDown348.Value = (decimal)T8_FM.ElementAt(7);
            numericUpDown342.Value = (decimal)T8_FM.ElementAt(8);
            numericUpDown336.Value = (decimal)T8_FM.ElementAt(9);
            numericUpDown330.Value = (decimal)T8_FM.ElementAt(10);
            numericUpDown324.Value = (decimal)T8_FM.ElementAt(11);
            numericUpDown318.Value = (decimal)T8_FM.ElementAt(12);

            numericUpDown365.Value = (decimal)T8_FA.ElementAt(0);
            numericUpDown363.Value = (decimal)T8_FA.ElementAt(1);
            numericUpDown361.Value = (decimal)T8_FA.ElementAt(2);
            numericUpDown359.Value = (decimal)T8_FA.ElementAt(3);
            numericUpDown357.Value = (decimal)T8_FA.ElementAt(4);
            numericUpDown355.Value = (decimal)T8_FA.ElementAt(5);
            numericUpDown351.Value = (decimal)T8_FA.ElementAt(6);
            numericUpDown345.Value = (decimal)T8_FA.ElementAt(7);
            numericUpDown339.Value = (decimal)T8_FA.ElementAt(8);
            numericUpDown333.Value = (decimal)T8_FA.ElementAt(9);
            numericUpDown327.Value = (decimal)T8_FA.ElementAt(10);
            numericUpDown321.Value = (decimal)T8_FA.ElementAt(11);
            numericUpDown315.Value = (decimal)T8_FA.ElementAt(12);

            numericUpDown392.Value = (decimal)T8_OM.ElementAt(0);
            numericUpDown390.Value = (decimal)T8_OM.ElementAt(1);
            numericUpDown388.Value = (decimal)T8_OM.ElementAt(2);
            numericUpDown386.Value = (decimal)T8_OM.ElementAt(3);
            numericUpDown384.Value = (decimal)T8_OM.ElementAt(4);
            numericUpDown382.Value = (decimal)T8_OM.ElementAt(5);
            numericUpDown380.Value = (decimal)T8_OM.ElementAt(6);
            numericUpDown378.Value = (decimal)T8_OM.ElementAt(7);
            numericUpDown376.Value = (decimal)T8_OM.ElementAt(8);
            numericUpDown374.Value = (decimal)T8_OM.ElementAt(9);
            numericUpDown372.Value = (decimal)T8_OM.ElementAt(10);
            numericUpDown370.Value = (decimal)T8_OM.ElementAt(11);
            numericUpDown368.Value = (decimal)T8_OM.ElementAt(12);

            numericUpDown391.Value = (decimal)T8_OA.ElementAt(0);
            numericUpDown389.Value = (decimal)T8_OA.ElementAt(1);
            numericUpDown387.Value = (decimal)T8_OA.ElementAt(2);
            numericUpDown385.Value = (decimal)T8_OA.ElementAt(3);
            numericUpDown383.Value = (decimal)T8_OA.ElementAt(4);
            numericUpDown381.Value = (decimal)T8_OA.ElementAt(5);
            numericUpDown379.Value = (decimal)T8_OA.ElementAt(6);
            numericUpDown377.Value = (decimal)T8_OA.ElementAt(7);
            numericUpDown375.Value = (decimal)T8_OA.ElementAt(8);
            numericUpDown373.Value = (decimal)T8_OA.ElementAt(9);
            numericUpDown371.Value = (decimal)T8_OA.ElementAt(10);
            numericUpDown369.Value = (decimal)T8_OA.ElementAt(11);
            numericUpDown367.Value = (decimal)T8_OA.ElementAt(12);

            numericUpDown417.Value = (decimal)T8_Total.ElementAt(0);
            numericUpDown415.Value = (decimal)T8_Total.ElementAt(1);
            numericUpDown413.Value = (decimal)T8_Total.ElementAt(2);
            numericUpDown411.Value = (decimal)T8_Total.ElementAt(3);
            numericUpDown409.Value = (decimal)T8_Total.ElementAt(4);
            numericUpDown407.Value = (decimal)T8_Total.ElementAt(5);
            numericUpDown405.Value = (decimal)T8_Total.ElementAt(6);
            numericUpDown403.Value = (decimal)T8_Total.ElementAt(7);
            numericUpDown401.Value = (decimal)T8_Total.ElementAt(8);
            numericUpDown399.Value = (decimal)T8_Total.ElementAt(9);
            numericUpDown397.Value = (decimal)T8_Total.ElementAt(10);
            numericUpDown395.Value = (decimal)T8_Total.ElementAt(11);
            numericUpDown393.Value = (decimal)T8_Total.ElementAt(12);

            numericUpDown444.Value = (decimal)T8_CentFS.ElementAt(0);
            numericUpDown442.Value = (decimal)T8_CentFS.ElementAt(1);
            numericUpDown440.Value = (decimal)T8_CentFS.ElementAt(2);
            numericUpDown438.Value = (decimal)T8_CentFS.ElementAt(3);
            numericUpDown436.Value = (decimal)T8_CentFS.ElementAt(4);
            numericUpDown434.Value = (decimal)T8_CentFS.ElementAt(5);
            numericUpDown432.Value = (decimal)T8_CentFS.ElementAt(6);
            numericUpDown430.Value = (decimal)T8_CentFS.ElementAt(7);
            numericUpDown428.Value = (decimal)T8_CentFS.ElementAt(8);
            numericUpDown426.Value = (decimal)T8_CentFS.ElementAt(9);
            numericUpDown424.Value = (decimal)T8_CentFS.ElementAt(10);
            numericUpDown422.Value = (decimal)T8_CentFS.ElementAt(11);
            numericUpDown420.Value = (decimal)T8_CentFS.ElementAt(12);

            numericUpDown443.Value = (decimal)T8_CentF.ElementAt(0);
            numericUpDown441.Value = (decimal)T8_CentF.ElementAt(1);
            numericUpDown439.Value = (decimal)T8_CentF.ElementAt(2);
            numericUpDown437.Value = (decimal)T8_CentF.ElementAt(3);
            numericUpDown435.Value = (decimal)T8_CentF.ElementAt(4);
            numericUpDown433.Value = (decimal)T8_CentF.ElementAt(5);
            numericUpDown431.Value = (decimal)T8_CentF.ElementAt(6);
            numericUpDown429.Value = (decimal)T8_CentF.ElementAt(7);
            numericUpDown427.Value = (decimal)T8_CentF.ElementAt(8);
            numericUpDown425.Value = (decimal)T8_CentF.ElementAt(9);
            numericUpDown423.Value = (decimal)T8_CentF.ElementAt(10);
            numericUpDown421.Value = (decimal)T8_CentF.ElementAt(11);
            numericUpDown419.Value = (decimal)T8_CentF.ElementAt(12);

            numericUpDown457.Value = (decimal)T8_CentO.ElementAt(0);
            numericUpDown456.Value = (decimal)T8_CentO.ElementAt(1);
            numericUpDown455.Value = (decimal)T8_CentO.ElementAt(2);
            numericUpDown454.Value = (decimal)T8_CentO.ElementAt(3);
            numericUpDown453.Value = (decimal)T8_CentO.ElementAt(4);
            numericUpDown452.Value = (decimal)T8_CentO.ElementAt(5);
            numericUpDown451.Value = (decimal)T8_CentO.ElementAt(6);
            numericUpDown450.Value = (decimal)T8_CentO.ElementAt(7);
            numericUpDown449.Value = (decimal)T8_CentO.ElementAt(8);
            numericUpDown448.Value = (decimal)T8_CentO.ElementAt(9);
            numericUpDown447.Value = (decimal)T8_CentO.ElementAt(10);
            numericUpDown446.Value = (decimal)T8_CentO.ElementAt(11);
            numericUpDown445.Value = (decimal)T8_CentO.ElementAt(12);
            #endregion
            #region Table 9 numericUpDown assignments
            numericUpDown574.Value = (decimal)T9_FSM.ElementAt(0);
            numericUpDown572.Value = (decimal)T9_FSM.ElementAt(1);
            numericUpDown570.Value = (decimal)T9_FSM.ElementAt(2);
            numericUpDown568.Value = (decimal)T9_FSM.ElementAt(3);
            numericUpDown566.Value = (decimal)T9_FSM.ElementAt(4);
            numericUpDown564.Value = (decimal)T9_FSM.ElementAt(5);
            numericUpDown562.Value = (decimal)T9_FSM.ElementAt(6);
            numericUpDown560.Value = (decimal)T9_FSM.ElementAt(7);
            numericUpDown558.Value = (decimal)T9_FSM.ElementAt(8);
            numericUpDown556.Value = (decimal)T9_FSM.ElementAt(9);
            numericUpDown554.Value = (decimal)T9_FSM.ElementAt(10);
            numericUpDown552.Value = (decimal)T9_FSM.ElementAt(11);
            numericUpDown550.Value = (decimal)T9_FSM.ElementAt(12);

            numericUpDown573.Value = (decimal)T9_FSA.ElementAt(0);
            numericUpDown571.Value = (decimal)T9_FSA.ElementAt(1);
            numericUpDown569.Value = (decimal)T9_FSA.ElementAt(2);
            numericUpDown567.Value = (decimal)T9_FSA.ElementAt(3);
            numericUpDown565.Value = (decimal)T9_FSA.ElementAt(4);
            numericUpDown563.Value = (decimal)T9_FSA.ElementAt(5);
            numericUpDown561.Value = (decimal)T9_FSA.ElementAt(6);
            numericUpDown559.Value = (decimal)T9_FSA.ElementAt(7);
            numericUpDown557.Value = (decimal)T9_FSA.ElementAt(8);
            numericUpDown555.Value = (decimal)T9_FSA.ElementAt(9);
            numericUpDown553.Value = (decimal)T9_FSA.ElementAt(10);
            numericUpDown551.Value = (decimal)T9_FSA.ElementAt(11);
            numericUpDown549.Value = (decimal)T9_FSA.ElementAt(12);

            numericUpDown548.Value = (decimal)T9_FM.ElementAt(0);
            numericUpDown544.Value = (decimal)T9_FM.ElementAt(1);
            numericUpDown540.Value = (decimal)T9_FM.ElementAt(2);
            numericUpDown536.Value = (decimal)T9_FM.ElementAt(3);
            numericUpDown532.Value = (decimal)T9_FM.ElementAt(4);
            numericUpDown538.Value = (decimal)T9_FM.ElementAt(5);
            numericUpDown524.Value = (decimal)T9_FM.ElementAt(6);
            numericUpDown507.Value = (decimal)T9_FM.ElementAt(7);
            numericUpDown503.Value = (decimal)T9_FM.ElementAt(8);
            numericUpDown499.Value = (decimal)T9_FM.ElementAt(9);
            numericUpDown482.Value = (decimal)T9_FM.ElementAt(10);
            numericUpDown471.Value = (decimal)T9_FM.ElementAt(11);
            numericUpDown459.Value = (decimal)T9_FM.ElementAt(12);

            numericUpDown546.Value = (decimal)T9_FA.ElementAt(0);
            numericUpDown542.Value = (decimal)T9_FA.ElementAt(1);
            numericUpDown538.Value = (decimal)T9_FA.ElementAt(2);
            numericUpDown534.Value = (decimal)T9_FA.ElementAt(3);
            numericUpDown530.Value = (decimal)T9_FA.ElementAt(4);
            numericUpDown526.Value = (decimal)T9_FA.ElementAt(5);
            numericUpDown509.Value = (decimal)T9_FA.ElementAt(6);
            numericUpDown505.Value = (decimal)T9_FA.ElementAt(7);
            numericUpDown501.Value = (decimal)T9_FA.ElementAt(8);
            numericUpDown497.Value = (decimal)T9_FA.ElementAt(9);
            numericUpDown477.Value = (decimal)T9_FA.ElementAt(10);
            numericUpDown465.Value = (decimal)T9_FA.ElementAt(11);
            numericUpDown410.Value = (decimal)T9_FA.ElementAt(12);

            numericUpDown547.Value = (decimal)T9_OM.ElementAt(0);
            numericUpDown543.Value = (decimal)T9_OM.ElementAt(1);
            numericUpDown539.Value = (decimal)T9_OM.ElementAt(2);
            numericUpDown535.Value = (decimal)T9_OM.ElementAt(3);
            numericUpDown531.Value = (decimal)T9_OM.ElementAt(4);
            numericUpDown527.Value = (decimal)T9_OM.ElementAt(5);
            numericUpDown510.Value = (decimal)T9_OM.ElementAt(6);
            numericUpDown506.Value = (decimal)T9_OM.ElementAt(7);
            numericUpDown502.Value = (decimal)T9_OM.ElementAt(8);
            numericUpDown498.Value = (decimal)T9_OM.ElementAt(9);
            numericUpDown480.Value = (decimal)T9_OM.ElementAt(10);
            numericUpDown468.Value = (decimal)T9_OM.ElementAt(11);
            numericUpDown416.Value = (decimal)T9_OM.ElementAt(12);

            numericUpDown545.Value = (decimal)T9_OA.ElementAt(0);
            numericUpDown541.Value = (decimal)T9_OA.ElementAt(1);
            numericUpDown537.Value = (decimal)T9_OA.ElementAt(2);
            numericUpDown533.Value = (decimal)T9_OA.ElementAt(3);
            numericUpDown529.Value = (decimal)T9_OA.ElementAt(4);
            numericUpDown525.Value = (decimal)T9_OA.ElementAt(5);
            numericUpDown508.Value = (decimal)T9_OA.ElementAt(6);
            numericUpDown504.Value = (decimal)T9_OA.ElementAt(7);
            numericUpDown500.Value = (decimal)T9_OA.ElementAt(8);
            numericUpDown496.Value = (decimal)T9_OA.ElementAt(9);
            numericUpDown474.Value = (decimal)T9_OA.ElementAt(10);
            numericUpDown462.Value = (decimal)T9_OA.ElementAt(11);
            numericUpDown404.Value = (decimal)T9_OA.ElementAt(12);

            numericUpDown511.Value = (decimal)T9_Total.ElementAt(0);
            numericUpDown512.Value = (decimal)T9_Total.ElementAt(1);
            numericUpDown514.Value = (decimal)T9_Total.ElementAt(2);
            numericUpDown515.Value = (decimal)T9_Total.ElementAt(3);
            numericUpDown516.Value = (decimal)T9_Total.ElementAt(4);
            numericUpDown517.Value = (decimal)T9_Total.ElementAt(5);
            numericUpDown518.Value = (decimal)T9_Total.ElementAt(6);
            numericUpDown519.Value = (decimal)T9_Total.ElementAt(7);
            numericUpDown521.Value = (decimal)T9_Total.ElementAt(8);
            numericUpDown522.Value = (decimal)T9_Total.ElementAt(9);
            numericUpDown523.Value = (decimal)T9_Total.ElementAt(10);
            numericUpDown520.Value = (decimal)T9_Total.ElementAt(11);
            numericUpDown513.Value = (decimal)T9_Total.ElementAt(12);

            numericUpDown481.Value = (decimal)T9_CentFS.ElementAt(0);
            numericUpDown478.Value = (decimal)T9_CentFS.ElementAt(1);
            numericUpDown475.Value = (decimal)T9_CentFS.ElementAt(2);
            numericUpDown472.Value = (decimal)T9_CentFS.ElementAt(3);
            numericUpDown469.Value = (decimal)T9_CentFS.ElementAt(4);
            numericUpDown466.Value = (decimal)T9_CentFS.ElementAt(5);
            numericUpDown463.Value = (decimal)T9_CentFS.ElementAt(6);
            numericUpDown460.Value = (decimal)T9_CentFS.ElementAt(7);
            numericUpDown418.Value = (decimal)T9_CentFS.ElementAt(8);
            numericUpDown412.Value = (decimal)T9_CentFS.ElementAt(9);
            numericUpDown406.Value = (decimal)T9_CentFS.ElementAt(10);
            numericUpDown400.Value = (decimal)T9_CentFS.ElementAt(11);
            numericUpDown396.Value = (decimal)T9_CentFS.ElementAt(12);

            numericUpDown479.Value = (decimal)T9_CentF.ElementAt(0);
            numericUpDown476.Value = (decimal)T9_CentF.ElementAt(1);
            numericUpDown473.Value = (decimal)T9_CentF.ElementAt(2);
            numericUpDown470.Value = (decimal)T9_CentF.ElementAt(3);
            numericUpDown467.Value = (decimal)T9_CentF.ElementAt(4);
            numericUpDown464.Value = (decimal)T9_CentF.ElementAt(5);
            numericUpDown461.Value = (decimal)T9_CentF.ElementAt(6);
            numericUpDown458.Value = (decimal)T9_CentF.ElementAt(7);
            numericUpDown414.Value = (decimal)T9_CentF.ElementAt(8);
            numericUpDown408.Value = (decimal)T9_CentF.ElementAt(9);
            numericUpDown402.Value = (decimal)T9_CentF.ElementAt(10);
            numericUpDown398.Value = (decimal)T9_CentF.ElementAt(11);
            numericUpDown394.Value = (decimal)T9_CentF.ElementAt(12);

            numericUpDown485.Value = (decimal)T9_CentO.ElementAt(0);
            numericUpDown487.Value = (decimal)T9_CentO.ElementAt(1);
            numericUpDown489.Value = (decimal)T9_CentO.ElementAt(2);
            numericUpDown491.Value = (decimal)T9_CentO.ElementAt(3);
            numericUpDown493.Value = (decimal)T9_CentO.ElementAt(4);
            numericUpDown495.Value = (decimal)T9_CentO.ElementAt(5);
            numericUpDown494.Value = (decimal)T9_CentO.ElementAt(6);
            numericUpDown492.Value = (decimal)T9_CentO.ElementAt(7);
            numericUpDown490.Value = (decimal)T9_CentO.ElementAt(8);
            numericUpDown488.Value = (decimal)T9_CentO.ElementAt(9);
            numericUpDown486.Value = (decimal)T9_CentO.ElementAt(10);
            numericUpDown484.Value = (decimal)T9_CentO.ElementAt(11);
            numericUpDown483.Value = (decimal)T9_CentO.ElementAt(12);
            #endregion
            #region Table 10 numericUpDown assignments
            numericUpDown704.Value = (decimal)T10_FSM.ElementAt(0);
            numericUpDown702.Value = (decimal)T10_FSM.ElementAt(1);
            numericUpDown700.Value = (decimal)T10_FSM.ElementAt(2);
            numericUpDown698.Value = (decimal)T10_FSM.ElementAt(3);
            numericUpDown696.Value = (decimal)T10_FSM.ElementAt(4);
            numericUpDown694.Value = (decimal)T10_FSM.ElementAt(5);
            numericUpDown692.Value = (decimal)T10_FSM.ElementAt(6);
            numericUpDown690.Value = (decimal)T10_FSM.ElementAt(7);
            numericUpDown688.Value = (decimal)T10_FSM.ElementAt(8);
            numericUpDown686.Value = (decimal)T10_FSM.ElementAt(9);
            numericUpDown684.Value = (decimal)T10_FSM.ElementAt(10);
            numericUpDown682.Value = (decimal)T10_FSM.ElementAt(11);
            numericUpDown680.Value = (decimal)T10_FSM.ElementAt(12);

            numericUpDown703.Value = (decimal)T10_FSA.ElementAt(0);
            numericUpDown701.Value = (decimal)T10_FSA.ElementAt(1);
            numericUpDown699.Value = (decimal)T10_FSA.ElementAt(2);
            numericUpDown697.Value = (decimal)T10_FSA.ElementAt(3);
            numericUpDown695.Value = (decimal)T10_FSA.ElementAt(4);
            numericUpDown693.Value = (decimal)T10_FSA.ElementAt(5);
            numericUpDown691.Value = (decimal)T10_FSA.ElementAt(6);
            numericUpDown689.Value = (decimal)T10_FSA.ElementAt(7);
            numericUpDown687.Value = (decimal)T10_FSA.ElementAt(8);
            numericUpDown685.Value = (decimal)T10_FSA.ElementAt(9);
            numericUpDown683.Value = (decimal)T10_FSA.ElementAt(10);
            numericUpDown681.Value = (decimal)T10_FSA.ElementAt(11);
            numericUpDown679.Value = (decimal)T10_FSA.ElementAt(12);

            numericUpDown678.Value = (decimal)T10_FM.ElementAt(0);
            numericUpDown674.Value = (decimal)T10_FM.ElementAt(1);
            numericUpDown670.Value = (decimal)T10_FM.ElementAt(2);
            numericUpDown666.Value = (decimal)T10_FM.ElementAt(3);
            numericUpDown662.Value = (decimal)T10_FM.ElementAt(4);
            numericUpDown658.Value = (decimal)T10_FM.ElementAt(5);
            numericUpDown654.Value = (decimal)T10_FM.ElementAt(6);
            numericUpDown637.Value = (decimal)T10_FM.ElementAt(7);
            numericUpDown633.Value = (decimal)T10_FM.ElementAt(8);
            numericUpDown629.Value = (decimal)T10_FM.ElementAt(9);
            numericUpDown612.Value = (decimal)T10_FM.ElementAt(10);
            numericUpDown601.Value = (decimal)T10_FM.ElementAt(11);
            numericUpDown589.Value = (decimal)T10_FM.ElementAt(12);

            numericUpDown676.Value = (decimal)T10_FA.ElementAt(0);
            numericUpDown672.Value = (decimal)T10_FA.ElementAt(1);
            numericUpDown668.Value = (decimal)T10_FA.ElementAt(2);
            numericUpDown664.Value = (decimal)T10_FA.ElementAt(3);
            numericUpDown660.Value = (decimal)T10_FA.ElementAt(4);
            numericUpDown656.Value = (decimal)T10_FA.ElementAt(5);
            numericUpDown639.Value = (decimal)T10_FA.ElementAt(6);
            numericUpDown635.Value = (decimal)T10_FA.ElementAt(7);
            numericUpDown631.Value = (decimal)T10_FA.ElementAt(8);
            numericUpDown627.Value = (decimal)T10_FA.ElementAt(9);
            numericUpDown607.Value = (decimal)T10_FA.ElementAt(10);
            numericUpDown595.Value = (decimal)T10_FA.ElementAt(11);
            numericUpDown583.Value = (decimal)T10_FA.ElementAt(12);

            numericUpDown677.Value = (decimal)T10_OM.ElementAt(0);
            numericUpDown673.Value = (decimal)T10_OM.ElementAt(1);
            numericUpDown669.Value = (decimal)T10_OM.ElementAt(2);
            numericUpDown665.Value = (decimal)T10_OM.ElementAt(3);
            numericUpDown661.Value = (decimal)T10_OM.ElementAt(4);
            numericUpDown657.Value = (decimal)T10_OM.ElementAt(5);
            numericUpDown640.Value = (decimal)T10_OM.ElementAt(6);
            numericUpDown636.Value = (decimal)T10_OM.ElementAt(7);
            numericUpDown632.Value = (decimal)T10_OM.ElementAt(8);
            numericUpDown628.Value = (decimal)T10_OM.ElementAt(9);
            numericUpDown610.Value = (decimal)T10_OM.ElementAt(10);
            numericUpDown598.Value = (decimal)T10_OM.ElementAt(11);
            numericUpDown586.Value = (decimal)T10_OM.ElementAt(12);

            numericUpDown675.Value = (decimal)T10_OA.ElementAt(0);
            numericUpDown671.Value = (decimal)T10_OA.ElementAt(1);
            numericUpDown667.Value = (decimal)T10_OA.ElementAt(2);
            numericUpDown663.Value = (decimal)T10_OA.ElementAt(3);
            numericUpDown659.Value = (decimal)T10_OA.ElementAt(4);
            numericUpDown655.Value = (decimal)T10_OA.ElementAt(5);
            numericUpDown638.Value = (decimal)T10_OA.ElementAt(6);
            numericUpDown634.Value = (decimal)T10_OA.ElementAt(7);
            numericUpDown630.Value = (decimal)T10_OA.ElementAt(8);
            numericUpDown626.Value = (decimal)T10_OA.ElementAt(9);
            numericUpDown604.Value = (decimal)T10_OA.ElementAt(10);
            numericUpDown592.Value = (decimal)T10_OA.ElementAt(11);
            numericUpDown580.Value = (decimal)T10_OA.ElementAt(12);

            numericUpDown641.Value = (decimal)T10_Total.ElementAt(0);
            numericUpDown642.Value = (decimal)T10_Total.ElementAt(1);
            numericUpDown644.Value = (decimal)T10_Total.ElementAt(2);
            numericUpDown645.Value = (decimal)T10_Total.ElementAt(3);
            numericUpDown646.Value = (decimal)T10_Total.ElementAt(4);
            numericUpDown647.Value = (decimal)T10_Total.ElementAt(5);
            numericUpDown648.Value = (decimal)T10_Total.ElementAt(6);
            numericUpDown649.Value = (decimal)T10_Total.ElementAt(7);
            numericUpDown651.Value = (decimal)T10_Total.ElementAt(8);
            numericUpDown652.Value = (decimal)T10_Total.ElementAt(9);
            numericUpDown653.Value = (decimal)T10_Total.ElementAt(10);
            numericUpDown650.Value = (decimal)T10_Total.ElementAt(11);
            numericUpDown643.Value = (decimal)T10_Total.ElementAt(12);

            numericUpDown611.Value = (decimal)T10_CentFS.ElementAt(0);
            numericUpDown608.Value = (decimal)T10_CentFS.ElementAt(1);
            numericUpDown605.Value = (decimal)T10_CentFS.ElementAt(2);
            numericUpDown602.Value = (decimal)T10_CentFS.ElementAt(3);
            numericUpDown599.Value = (decimal)T10_CentFS.ElementAt(4);
            numericUpDown596.Value = (decimal)T10_CentFS.ElementAt(5);
            numericUpDown593.Value = (decimal)T10_CentFS.ElementAt(6);
            numericUpDown590.Value = (decimal)T10_CentFS.ElementAt(7);
            numericUpDown587.Value = (decimal)T10_CentFS.ElementAt(8);
            numericUpDown584.Value = (decimal)T10_CentFS.ElementAt(9);
            numericUpDown581.Value = (decimal)T10_CentFS.ElementAt(10);
            numericUpDown578.Value = (decimal)T10_CentFS.ElementAt(11);
            numericUpDown576.Value = (decimal)T10_CentFS.ElementAt(12);

            numericUpDown609.Value = (decimal)T10_CentF.ElementAt(0);
            numericUpDown606.Value = (decimal)T10_CentF.ElementAt(1);
            numericUpDown603.Value = (decimal)T10_CentF.ElementAt(2);
            numericUpDown600.Value = (decimal)T10_CentF.ElementAt(3);
            numericUpDown597.Value = (decimal)T10_CentF.ElementAt(4);
            numericUpDown594.Value = (decimal)T10_CentF.ElementAt(5);
            numericUpDown591.Value = (decimal)T10_CentF.ElementAt(6);
            numericUpDown588.Value = (decimal)T10_CentF.ElementAt(7);
            numericUpDown585.Value = (decimal)T10_CentF.ElementAt(8);
            numericUpDown582.Value = (decimal)T10_CentF.ElementAt(9);
            numericUpDown579.Value = (decimal)T10_CentF.ElementAt(10);
            numericUpDown577.Value = (decimal)T10_CentF.ElementAt(11);
            numericUpDown575.Value = (decimal)T10_CentF.ElementAt(12);

            numericUpDown615.Value = (decimal)T10_CentO.ElementAt(0);
            numericUpDown617.Value = (decimal)T10_CentO.ElementAt(1);
            numericUpDown619.Value = (decimal)T10_CentO.ElementAt(2);
            numericUpDown621.Value = (decimal)T10_CentO.ElementAt(3);
            numericUpDown623.Value = (decimal)T10_CentO.ElementAt(4);
            numericUpDown625.Value = (decimal)T10_CentO.ElementAt(5);
            numericUpDown624.Value = (decimal)T10_CentO.ElementAt(6);
            numericUpDown622.Value = (decimal)T10_CentO.ElementAt(7);
            numericUpDown620.Value = (decimal)T10_CentO.ElementAt(8);
            numericUpDown618.Value = (decimal)T10_CentO.ElementAt(9);
            numericUpDown616.Value = (decimal)T10_CentO.ElementAt(10);
            numericUpDown614.Value = (decimal)T10_CentO.ElementAt(11);
            numericUpDown613.Value = (decimal)T10_CentO.ElementAt(12);
            #endregion
            #region Table 11 numericUpDown assignments
            numericUpDown834.Value = (decimal)T11_FSM.ElementAt(0);
            numericUpDown832.Value = (decimal)T11_FSM.ElementAt(1);
            numericUpDown830.Value = (decimal)T11_FSM.ElementAt(2);
            numericUpDown828.Value = (decimal)T11_FSM.ElementAt(3);
            numericUpDown826.Value = (decimal)T11_FSM.ElementAt(4);
            numericUpDown824.Value = (decimal)T11_FSM.ElementAt(5);
            numericUpDown822.Value = (decimal)T11_FSM.ElementAt(6);
            numericUpDown820.Value = (decimal)T11_FSM.ElementAt(7);
            numericUpDown818.Value = (decimal)T11_FSM.ElementAt(8);
            numericUpDown816.Value = (decimal)T11_FSM.ElementAt(9);
            numericUpDown814.Value = (decimal)T11_FSM.ElementAt(10);
            numericUpDown812.Value = (decimal)T11_FSM.ElementAt(11);
            numericUpDown810.Value = (decimal)T11_FSM.ElementAt(12);

            numericUpDown833.Value = (decimal)T11_FSA.ElementAt(0);
            numericUpDown831.Value = (decimal)T11_FSA.ElementAt(1);
            numericUpDown829.Value = (decimal)T11_FSA.ElementAt(2);
            numericUpDown827.Value = (decimal)T11_FSA.ElementAt(3);
            numericUpDown825.Value = (decimal)T11_FSA.ElementAt(4);
            numericUpDown823.Value = (decimal)T11_FSA.ElementAt(5);
            numericUpDown821.Value = (decimal)T11_FSA.ElementAt(6);
            numericUpDown819.Value = (decimal)T11_FSA.ElementAt(7);
            numericUpDown817.Value = (decimal)T11_FSA.ElementAt(8);
            numericUpDown815.Value = (decimal)T11_FSA.ElementAt(9);
            numericUpDown813.Value = (decimal)T11_FSA.ElementAt(10);
            numericUpDown811.Value = (decimal)T11_FSA.ElementAt(11);
            numericUpDown809.Value = (decimal)T11_FSA.ElementAt(12);

            numericUpDown808.Value = (decimal)T11_FM.ElementAt(0);
            numericUpDown804.Value = (decimal)T11_FM.ElementAt(1);
            numericUpDown800.Value = (decimal)T11_FM.ElementAt(2);
            numericUpDown796.Value = (decimal)T11_FM.ElementAt(3);
            numericUpDown792.Value = (decimal)T11_FM.ElementAt(4);
            numericUpDown788.Value = (decimal)T11_FM.ElementAt(5);
            numericUpDown784.Value = (decimal)T11_FM.ElementAt(6);
            numericUpDown767.Value = (decimal)T11_FM.ElementAt(7);
            numericUpDown763.Value = (decimal)T11_FM.ElementAt(8);
            numericUpDown759.Value = (decimal)T11_FM.ElementAt(9);
            numericUpDown742.Value = (decimal)T11_FM.ElementAt(10);
            numericUpDown731.Value = (decimal)T11_FM.ElementAt(11);
            numericUpDown719.Value = (decimal)T11_FM.ElementAt(12);

            numericUpDown806.Value = (decimal)T11_FA.ElementAt(0);
            numericUpDown802.Value = (decimal)T11_FA.ElementAt(1);
            numericUpDown798.Value = (decimal)T11_FA.ElementAt(2);
            numericUpDown794.Value = (decimal)T11_FA.ElementAt(3);
            numericUpDown790.Value = (decimal)T11_FA.ElementAt(4);
            numericUpDown786.Value = (decimal)T11_FA.ElementAt(5);
            numericUpDown769.Value = (decimal)T11_FA.ElementAt(6);
            numericUpDown765.Value = (decimal)T11_FA.ElementAt(7);
            numericUpDown761.Value = (decimal)T11_FA.ElementAt(8);
            numericUpDown757.Value = (decimal)T11_FA.ElementAt(9);
            numericUpDown737.Value = (decimal)T11_FA.ElementAt(10);
            numericUpDown725.Value = (decimal)T11_FA.ElementAt(11);
            numericUpDown713.Value = (decimal)T11_FA.ElementAt(12);

            numericUpDown807.Value = (decimal)T11_OM.ElementAt(0);
            numericUpDown803.Value = (decimal)T11_OM.ElementAt(1);
            numericUpDown799.Value = (decimal)T11_OM.ElementAt(2);
            numericUpDown795.Value = (decimal)T11_OM.ElementAt(3);
            numericUpDown791.Value = (decimal)T11_OM.ElementAt(4);
            numericUpDown787.Value = (decimal)T11_OM.ElementAt(5);
            numericUpDown770.Value = (decimal)T11_OM.ElementAt(6);
            numericUpDown766.Value = (decimal)T11_OM.ElementAt(7);
            numericUpDown762.Value = (decimal)T11_OM.ElementAt(8);
            numericUpDown758.Value = (decimal)T11_OM.ElementAt(9);
            numericUpDown740.Value = (decimal)T11_OM.ElementAt(10);
            numericUpDown728.Value = (decimal)T11_OM.ElementAt(11);
            numericUpDown716.Value = (decimal)T11_OM.ElementAt(12);

            numericUpDown805.Value = (decimal)T11_OA.ElementAt(0);
            numericUpDown801.Value = (decimal)T11_OA.ElementAt(1);
            numericUpDown797.Value = (decimal)T11_OA.ElementAt(2);
            numericUpDown793.Value = (decimal)T11_OA.ElementAt(3);
            numericUpDown789.Value = (decimal)T11_OA.ElementAt(4);
            numericUpDown785.Value = (decimal)T11_OA.ElementAt(5);
            numericUpDown768.Value = (decimal)T11_OA.ElementAt(6);
            numericUpDown764.Value = (decimal)T11_OA.ElementAt(7);
            numericUpDown760.Value = (decimal)T11_OA.ElementAt(8);
            numericUpDown756.Value = (decimal)T11_OA.ElementAt(9);
            numericUpDown735.Value = (decimal)T11_OA.ElementAt(10);
            numericUpDown722.Value = (decimal)T11_OA.ElementAt(11);
            numericUpDown710.Value = (decimal)T11_OA.ElementAt(12);

            numericUpDown771.Value = (decimal)T11_Total.ElementAt(0);
            numericUpDown772.Value = (decimal)T11_Total.ElementAt(1);
            numericUpDown774.Value = (decimal)T11_Total.ElementAt(2);
            numericUpDown775.Value = (decimal)T11_Total.ElementAt(3);
            numericUpDown776.Value = (decimal)T11_Total.ElementAt(4);
            numericUpDown777.Value = (decimal)T11_Total.ElementAt(5);
            numericUpDown778.Value = (decimal)T11_Total.ElementAt(6);
            numericUpDown779.Value = (decimal)T11_Total.ElementAt(7);
            numericUpDown781.Value = (decimal)T11_Total.ElementAt(8);
            numericUpDown782.Value = (decimal)T11_Total.ElementAt(9);
            numericUpDown783.Value = (decimal)T11_Total.ElementAt(10);
            numericUpDown780.Value = (decimal)T11_Total.ElementAt(11);
            numericUpDown773.Value = (decimal)T11_Total.ElementAt(12);

            numericUpDown741.Value = (decimal)T11_CentFS.ElementAt(0);
            numericUpDown738.Value = (decimal)T11_CentFS.ElementAt(1);
            numericUpDown735.Value = (decimal)T11_CentFS.ElementAt(2);
            numericUpDown732.Value = (decimal)T11_CentFS.ElementAt(3);
            numericUpDown729.Value = (decimal)T11_CentFS.ElementAt(4);
            numericUpDown726.Value = (decimal)T11_CentFS.ElementAt(5);
            numericUpDown723.Value = (decimal)T11_CentFS.ElementAt(6);
            numericUpDown720.Value = (decimal)T11_CentFS.ElementAt(7);
            numericUpDown717.Value = (decimal)T11_CentFS.ElementAt(8);
            numericUpDown714.Value = (decimal)T11_CentFS.ElementAt(9);
            numericUpDown711.Value = (decimal)T11_CentFS.ElementAt(10);
            numericUpDown708.Value = (decimal)T11_CentFS.ElementAt(11);
            numericUpDown706.Value = (decimal)T11_CentFS.ElementAt(12);

            numericUpDown739.Value = (decimal)T11_CentF.ElementAt(0);
            numericUpDown736.Value = (decimal)T11_CentF.ElementAt(1);
            numericUpDown733.Value = (decimal)T11_CentF.ElementAt(2);
            numericUpDown730.Value = (decimal)T11_CentF.ElementAt(3);
            numericUpDown727.Value = (decimal)T11_CentF.ElementAt(4);
            numericUpDown724.Value = (decimal)T11_CentF.ElementAt(5);
            numericUpDown721.Value = (decimal)T11_CentF.ElementAt(6);
            numericUpDown718.Value = (decimal)T11_CentF.ElementAt(7);
            numericUpDown715.Value = (decimal)T11_CentF.ElementAt(8);
            numericUpDown712.Value = (decimal)T11_CentF.ElementAt(9);
            numericUpDown709.Value = (decimal)T11_CentF.ElementAt(10);
            numericUpDown707.Value = (decimal)T11_CentF.ElementAt(11);
            numericUpDown705.Value = (decimal)T11_CentF.ElementAt(12);

            numericUpDown745.Value = (decimal)T11_CentO.ElementAt(0);
            numericUpDown747.Value = (decimal)T11_CentO.ElementAt(1);
            numericUpDown749.Value = (decimal)T11_CentO.ElementAt(2);
            numericUpDown751.Value = (decimal)T11_CentO.ElementAt(3);
            numericUpDown753.Value = (decimal)T11_CentO.ElementAt(4);
            numericUpDown755.Value = (decimal)T11_CentO.ElementAt(5);
            numericUpDown754.Value = (decimal)T11_CentO.ElementAt(6);
            numericUpDown752.Value = (decimal)T11_CentO.ElementAt(7);
            numericUpDown750.Value = (decimal)T11_CentO.ElementAt(8);
            numericUpDown748.Value = (decimal)T11_CentO.ElementAt(9);
            numericUpDown746.Value = (decimal)T11_CentO.ElementAt(10);
            numericUpDown744.Value = (decimal)T11_CentO.ElementAt(11);
            numericUpDown743.Value = (decimal)T11_CentO.ElementAt(12);
            #endregion
            #region Table 12 numericUpDown assignments
            numericUpDown964.Value = (decimal)T12_FSM.ElementAt(0);
            numericUpDown962.Value = (decimal)T12_FSM.ElementAt(1);
            numericUpDown960.Value = (decimal)T12_FSM.ElementAt(2);
            numericUpDown958.Value = (decimal)T12_FSM.ElementAt(3);
            numericUpDown956.Value = (decimal)T12_FSM.ElementAt(4);
            numericUpDown954.Value = (decimal)T12_FSM.ElementAt(5);
            numericUpDown952.Value = (decimal)T12_FSM.ElementAt(6);
            numericUpDown950.Value = (decimal)T12_FSM.ElementAt(7);
            numericUpDown948.Value = (decimal)T12_FSM.ElementAt(8);
            numericUpDown946.Value = (decimal)T12_FSM.ElementAt(9);
            numericUpDown944.Value = (decimal)T12_FSM.ElementAt(10);
            numericUpDown942.Value = (decimal)T12_FSM.ElementAt(11);
            numericUpDown940.Value = (decimal)T12_FSM.ElementAt(12);

            numericUpDown963.Value = (decimal)T12_FSA.ElementAt(0);
            numericUpDown961.Value = (decimal)T12_FSA.ElementAt(1);
            numericUpDown959.Value = (decimal)T12_FSA.ElementAt(2);
            numericUpDown957.Value = (decimal)T12_FSA.ElementAt(3);
            numericUpDown955.Value = (decimal)T12_FSA.ElementAt(4);
            numericUpDown953.Value = (decimal)T12_FSA.ElementAt(5);
            numericUpDown951.Value = (decimal)T12_FSA.ElementAt(6);
            numericUpDown949.Value = (decimal)T12_FSA.ElementAt(7);
            numericUpDown947.Value = (decimal)T12_FSA.ElementAt(8);
            numericUpDown945.Value = (decimal)T12_FSA.ElementAt(9);
            numericUpDown943.Value = (decimal)T12_FSA.ElementAt(10);
            numericUpDown941.Value = (decimal)T12_FSA.ElementAt(11);
            numericUpDown939.Value = (decimal)T12_FSA.ElementAt(12);

            numericUpDown938.Value = (decimal)T12_FM.ElementAt(0);
            numericUpDown934.Value = (decimal)T12_FM.ElementAt(1);
            numericUpDown930.Value = (decimal)T12_FM.ElementAt(2);
            numericUpDown926.Value = (decimal)T12_FM.ElementAt(3);
            numericUpDown922.Value = (decimal)T12_FM.ElementAt(4);
            numericUpDown918.Value = (decimal)T12_FM.ElementAt(5);
            numericUpDown914.Value = (decimal)T12_FM.ElementAt(6);
            numericUpDown897.Value = (decimal)T12_FM.ElementAt(7);
            numericUpDown893.Value = (decimal)T12_FM.ElementAt(8);
            numericUpDown889.Value = (decimal)T12_FM.ElementAt(9);
            numericUpDown872.Value = (decimal)T12_FM.ElementAt(10);
            numericUpDown861.Value = (decimal)T12_FM.ElementAt(11);
            numericUpDown849.Value = (decimal)T12_FM.ElementAt(12);

            numericUpDown936.Value = (decimal)T12_FA.ElementAt(0);
            numericUpDown932.Value = (decimal)T12_FA.ElementAt(1);
            numericUpDown928.Value = (decimal)T12_FA.ElementAt(2);
            numericUpDown924.Value = (decimal)T12_FA.ElementAt(3);
            numericUpDown920.Value = (decimal)T12_FA.ElementAt(4);
            numericUpDown916.Value = (decimal)T12_FA.ElementAt(5);
            numericUpDown899.Value = (decimal)T12_FA.ElementAt(6);
            numericUpDown895.Value = (decimal)T12_FA.ElementAt(7);
            numericUpDown891.Value = (decimal)T12_FA.ElementAt(8);
            numericUpDown887.Value = (decimal)T12_FA.ElementAt(9);
            numericUpDown867.Value = (decimal)T12_FA.ElementAt(10);
            numericUpDown855.Value = (decimal)T12_FA.ElementAt(11);
            numericUpDown843.Value = (decimal)T12_FA.ElementAt(12);

            numericUpDown937.Value = (decimal)T12_OM.ElementAt(0);
            numericUpDown933.Value = (decimal)T12_OM.ElementAt(1);
            numericUpDown929.Value = (decimal)T12_OM.ElementAt(2);
            numericUpDown925.Value = (decimal)T12_OM.ElementAt(3);
            numericUpDown921.Value = (decimal)T12_OM.ElementAt(4);
            numericUpDown917.Value = (decimal)T12_OM.ElementAt(5);
            numericUpDown900.Value = (decimal)T12_OM.ElementAt(6);
            numericUpDown896.Value = (decimal)T12_OM.ElementAt(7);
            numericUpDown892.Value = (decimal)T12_OM.ElementAt(8);
            numericUpDown888.Value = (decimal)T12_OM.ElementAt(9);
            numericUpDown870.Value = (decimal)T12_OM.ElementAt(10);
            numericUpDown858.Value = (decimal)T12_OM.ElementAt(11);
            numericUpDown846.Value = (decimal)T12_OM.ElementAt(12);

            numericUpDown935.Value = (decimal)T12_OA.ElementAt(0);
            numericUpDown931.Value = (decimal)T12_OA.ElementAt(1);
            numericUpDown927.Value = (decimal)T12_OA.ElementAt(2);
            numericUpDown923.Value = (decimal)T12_OA.ElementAt(3);
            numericUpDown919.Value = (decimal)T12_OA.ElementAt(4);
            numericUpDown915.Value = (decimal)T12_OA.ElementAt(5);
            numericUpDown898.Value = (decimal)T12_OA.ElementAt(6);
            numericUpDown894.Value = (decimal)T12_OA.ElementAt(7);
            numericUpDown890.Value = (decimal)T12_OA.ElementAt(8);
            numericUpDown886.Value = (decimal)T12_OA.ElementAt(9);
            numericUpDown864.Value = (decimal)T12_OA.ElementAt(10);
            numericUpDown852.Value = (decimal)T12_OA.ElementAt(11);
            numericUpDown840.Value = (decimal)T12_OA.ElementAt(12);

            numericUpDown901.Value = (decimal)T12_Total.ElementAt(0);
            numericUpDown902.Value = (decimal)T12_Total.ElementAt(1);
            numericUpDown904.Value = (decimal)T12_Total.ElementAt(2);
            numericUpDown905.Value = (decimal)T12_Total.ElementAt(3);
            numericUpDown906.Value = (decimal)T12_Total.ElementAt(4);
            numericUpDown907.Value = (decimal)T12_Total.ElementAt(5);
            numericUpDown908.Value = (decimal)T12_Total.ElementAt(6);
            numericUpDown909.Value = (decimal)T12_Total.ElementAt(7);
            numericUpDown911.Value = (decimal)T12_Total.ElementAt(8);
            numericUpDown912.Value = (decimal)T12_Total.ElementAt(9);
            numericUpDown913.Value = (decimal)T12_Total.ElementAt(10);
            numericUpDown910.Value = (decimal)T12_Total.ElementAt(11);
            numericUpDown903.Value = (decimal)T12_Total.ElementAt(12);

            numericUpDown871.Value = (decimal)T12_CentFS.ElementAt(0);
            numericUpDown868.Value = (decimal)T12_CentFS.ElementAt(1);
            numericUpDown865.Value = (decimal)T12_CentFS.ElementAt(2);
            numericUpDown862.Value = (decimal)T12_CentFS.ElementAt(3);
            numericUpDown859.Value = (decimal)T12_CentFS.ElementAt(4);
            numericUpDown856.Value = (decimal)T12_CentFS.ElementAt(5);
            numericUpDown853.Value = (decimal)T12_CentFS.ElementAt(6);
            numericUpDown850.Value = (decimal)T12_CentFS.ElementAt(7);
            numericUpDown847.Value = (decimal)T12_CentFS.ElementAt(8);
            numericUpDown844.Value = (decimal)T12_CentFS.ElementAt(9);
            numericUpDown841.Value = (decimal)T12_CentFS.ElementAt(10);
            numericUpDown838.Value = (decimal)T12_CentFS.ElementAt(11);
            numericUpDown836.Value = (decimal)T12_CentFS.ElementAt(12);

            numericUpDown869.Value = (decimal)T12_CentF.ElementAt(0);
            numericUpDown866.Value = (decimal)T12_CentF.ElementAt(1);
            numericUpDown863.Value = (decimal)T12_CentF.ElementAt(2);
            numericUpDown860.Value = (decimal)T12_CentF.ElementAt(3);
            numericUpDown857.Value = (decimal)T12_CentF.ElementAt(4);
            numericUpDown854.Value = (decimal)T12_CentF.ElementAt(5);
            numericUpDown851.Value = (decimal)T12_CentF.ElementAt(6);
            numericUpDown858.Value = (decimal)T12_CentF.ElementAt(7);
            numericUpDown845.Value = (decimal)T12_CentF.ElementAt(8);
            numericUpDown842.Value = (decimal)T12_CentF.ElementAt(9);
            numericUpDown839.Value = (decimal)T12_CentF.ElementAt(10);
            numericUpDown837.Value = (decimal)T12_CentF.ElementAt(11);
            numericUpDown835.Value = (decimal)T12_CentF.ElementAt(12);

            numericUpDown875.Value = (decimal)T12_CentO.ElementAt(0);
            numericUpDown877.Value = (decimal)T12_CentO.ElementAt(1);
            numericUpDown879.Value = (decimal)T12_CentO.ElementAt(2);
            numericUpDown881.Value = (decimal)T12_CentO.ElementAt(3);
            numericUpDown883.Value = (decimal)T12_CentO.ElementAt(4);
            numericUpDown885.Value = (decimal)T12_CentO.ElementAt(5);
            numericUpDown884.Value = (decimal)T12_CentO.ElementAt(6);
            numericUpDown882.Value = (decimal)T12_CentO.ElementAt(7);
            numericUpDown880.Value = (decimal)T12_CentO.ElementAt(8);
            numericUpDown878.Value = (decimal)T12_CentO.ElementAt(9);
            numericUpDown876.Value = (decimal)T12_CentO.ElementAt(10);
            numericUpDown874.Value = (decimal)T12_CentO.ElementAt(11);
            numericUpDown873.Value = (decimal)T12_CentO.ElementAt(12);
            #endregion
            #region Table 13 numericUpDown assignments
            numericUpDown1094.Value = (decimal)T13_FSM.ElementAt(0);
            numericUpDown1092.Value = (decimal)T13_FSM.ElementAt(1);
            numericUpDown1090.Value = (decimal)T13_FSM.ElementAt(2);
            numericUpDown1088.Value = (decimal)T13_FSM.ElementAt(3);
            numericUpDown1086.Value = (decimal)T13_FSM.ElementAt(4);
            numericUpDown1084.Value = (decimal)T13_FSM.ElementAt(5);
            numericUpDown1082.Value = (decimal)T13_FSM.ElementAt(6);
            numericUpDown1080.Value = (decimal)T13_FSM.ElementAt(7);
            numericUpDown1078.Value = (decimal)T13_FSM.ElementAt(8);
            numericUpDown1076.Value = (decimal)T13_FSM.ElementAt(9);
            numericUpDown1074.Value = (decimal)T13_FSM.ElementAt(10);
            numericUpDown1072.Value = (decimal)T13_FSM.ElementAt(11);
            numericUpDown1070.Value = (decimal)T13_FSM.ElementAt(12);

            numericUpDown1093.Value = (decimal)T13_FSA.ElementAt(0);
            numericUpDown1091.Value = (decimal)T13_FSA.ElementAt(1);
            numericUpDown1089.Value = (decimal)T13_FSA.ElementAt(2);
            numericUpDown1087.Value = (decimal)T13_FSA.ElementAt(3);
            numericUpDown1085.Value = (decimal)T13_FSA.ElementAt(4);
            numericUpDown1083.Value = (decimal)T13_FSA.ElementAt(5);
            numericUpDown1081.Value = (decimal)T13_FSA.ElementAt(6);
            numericUpDown1079.Value = (decimal)T13_FSA.ElementAt(7);
            numericUpDown1077.Value = (decimal)T13_FSA.ElementAt(8);
            numericUpDown1075.Value = (decimal)T13_FSA.ElementAt(9);
            numericUpDown1073.Value = (decimal)T13_FSA.ElementAt(10);
            numericUpDown1071.Value = (decimal)T13_FSA.ElementAt(11);
            numericUpDown1069.Value = (decimal)T13_FSA.ElementAt(12);

            numericUpDown1068.Value = (decimal)T13_FM.ElementAt(0);
            numericUpDown1064.Value = (decimal)T13_FM.ElementAt(1);
            numericUpDown1060.Value = (decimal)T13_FM.ElementAt(2);
            numericUpDown1056.Value = (decimal)T13_FM.ElementAt(3);
            numericUpDown1052.Value = (decimal)T13_FM.ElementAt(4);
            numericUpDown1048.Value = (decimal)T13_FM.ElementAt(5);
            numericUpDown1044.Value = (decimal)T13_FM.ElementAt(6);
            numericUpDown1027.Value = (decimal)T13_FM.ElementAt(7);
            numericUpDown1023.Value = (decimal)T13_FM.ElementAt(8);
            numericUpDown1019.Value = (decimal)T13_FM.ElementAt(9);
            numericUpDown1002.Value = (decimal)T13_FM.ElementAt(10);
            numericUpDown991.Value = (decimal)T13_FM.ElementAt(11);
            numericUpDown979.Value = (decimal)T13_FM.ElementAt(12);

            numericUpDown1066.Value = (decimal)T13_FA.ElementAt(0);
            numericUpDown1062.Value = (decimal)T13_FA.ElementAt(1);
            numericUpDown1058.Value = (decimal)T13_FA.ElementAt(2);
            numericUpDown1054.Value = (decimal)T13_FA.ElementAt(3);
            numericUpDown1050.Value = (decimal)T13_FA.ElementAt(4);
            numericUpDown1046.Value = (decimal)T13_FA.ElementAt(5);
            numericUpDown1029.Value = (decimal)T13_FA.ElementAt(6);
            numericUpDown1025.Value = (decimal)T13_FA.ElementAt(7);
            numericUpDown1021.Value = (decimal)T13_FA.ElementAt(8);
            numericUpDown1017.Value = (decimal)T13_FA.ElementAt(9);
            numericUpDown997.Value = (decimal)T13_FA.ElementAt(10);
            numericUpDown985.Value = (decimal)T13_FA.ElementAt(11);
            numericUpDown973.Value = (decimal)T13_FA.ElementAt(12);

            numericUpDown1067.Value = (decimal)T13_OM.ElementAt(0);
            numericUpDown1063.Value = (decimal)T13_OM.ElementAt(1);
            numericUpDown1059.Value = (decimal)T13_OM.ElementAt(2);
            numericUpDown1055.Value = (decimal)T13_OM.ElementAt(3);
            numericUpDown1051.Value = (decimal)T13_OM.ElementAt(4);
            numericUpDown1047.Value = (decimal)T13_OM.ElementAt(5);
            numericUpDown1030.Value = (decimal)T13_OM.ElementAt(6);
            numericUpDown1026.Value = (decimal)T13_OM.ElementAt(7);
            numericUpDown1022.Value = (decimal)T13_OM.ElementAt(8);
            numericUpDown1018.Value = (decimal)T13_OM.ElementAt(9);
            numericUpDown1000.Value = (decimal)T13_OM.ElementAt(10);
            numericUpDown988.Value = (decimal)T13_OM.ElementAt(11);
            numericUpDown976.Value = (decimal)T13_OM.ElementAt(12);

            numericUpDown1065.Value = (decimal)T13_OA.ElementAt(0);
            numericUpDown1061.Value = (decimal)T13_OA.ElementAt(1);
            numericUpDown1057.Value = (decimal)T13_OA.ElementAt(2);
            numericUpDown1053.Value = (decimal)T13_OA.ElementAt(3);
            numericUpDown1049.Value = (decimal)T13_OA.ElementAt(4);
            numericUpDown1045.Value = (decimal)T13_OA.ElementAt(5);
            numericUpDown1028.Value = (decimal)T13_OA.ElementAt(6);
            numericUpDown1024.Value = (decimal)T13_OA.ElementAt(7);
            numericUpDown1020.Value = (decimal)T13_OA.ElementAt(8);
            numericUpDown1016.Value = (decimal)T13_OA.ElementAt(9);
            numericUpDown994.Value = (decimal)T13_OA.ElementAt(10);
            numericUpDown982.Value = (decimal)T13_OA.ElementAt(11);
            numericUpDown970.Value = (decimal)T13_OA.ElementAt(12);

            numericUpDown1031.Value = (decimal)T13_Total.ElementAt(0);
            numericUpDown1032.Value = (decimal)T13_Total.ElementAt(1);
            numericUpDown1034.Value = (decimal)T13_Total.ElementAt(2);
            numericUpDown1035.Value = (decimal)T13_Total.ElementAt(3);
            numericUpDown1036.Value = (decimal)T13_Total.ElementAt(4);
            numericUpDown1037.Value = (decimal)T13_Total.ElementAt(5);
            numericUpDown1038.Value = (decimal)T13_Total.ElementAt(6);
            numericUpDown1039.Value = (decimal)T13_Total.ElementAt(7);
            numericUpDown1041.Value = (decimal)T13_Total.ElementAt(8);
            numericUpDown1043.Value = (decimal)T13_Total.ElementAt(9);
            numericUpDown1042.Value = (decimal)T13_Total.ElementAt(10);
            numericUpDown1040.Value = (decimal)T13_Total.ElementAt(11);
            numericUpDown1033.Value = (decimal)T13_Total.ElementAt(12);

            numericUpDown1001.Value = (decimal)T13_CentFS.ElementAt(0);
            numericUpDown998.Value = (decimal)T13_CentFS.ElementAt(1);
            numericUpDown995.Value = (decimal)T13_CentFS.ElementAt(2);
            numericUpDown992.Value = (decimal)T13_CentFS.ElementAt(3);
            numericUpDown989.Value = (decimal)T13_CentFS.ElementAt(4);
            numericUpDown986.Value = (decimal)T13_CentFS.ElementAt(5);
            numericUpDown983.Value = (decimal)T13_CentFS.ElementAt(6);
            numericUpDown980.Value = (decimal)T13_CentFS.ElementAt(7);
            numericUpDown977.Value = (decimal)T13_CentFS.ElementAt(8);
            numericUpDown974.Value = (decimal)T13_CentFS.ElementAt(9);
            numericUpDown971.Value = (decimal)T13_CentFS.ElementAt(10);
            numericUpDown968.Value = (decimal)T13_CentFS.ElementAt(11);
            numericUpDown966.Value = (decimal)T13_CentFS.ElementAt(12);

            numericUpDown999.Value = (decimal)T13_CentF.ElementAt(0);
            numericUpDown996.Value = (decimal)T13_CentF.ElementAt(1);
            numericUpDown993.Value = (decimal)T13_CentF.ElementAt(2);
            numericUpDown990.Value = (decimal)T13_CentF.ElementAt(3);
            numericUpDown987.Value = (decimal)T13_CentF.ElementAt(4);
            numericUpDown984.Value = (decimal)T13_CentF.ElementAt(5);
            numericUpDown981.Value = (decimal)T13_CentF.ElementAt(6);
            numericUpDown978.Value = (decimal)T13_CentF.ElementAt(7);
            numericUpDown975.Value = (decimal)T13_CentF.ElementAt(8);
            numericUpDown972.Value = (decimal)T13_CentF.ElementAt(9);
            numericUpDown969.Value = (decimal)T13_CentF.ElementAt(10);
            numericUpDown967.Value = (decimal)T13_CentF.ElementAt(11);
            numericUpDown965.Value = (decimal)T13_CentF.ElementAt(12);

            numericUpDown1005.Value = (decimal)T13_CentO.ElementAt(0);
            numericUpDown1007.Value = (decimal)T13_CentO.ElementAt(1);
            numericUpDown1009.Value = (decimal)T13_CentO.ElementAt(2);
            numericUpDown1011.Value = (decimal)T13_CentO.ElementAt(3);
            numericUpDown1013.Value = (decimal)T13_CentO.ElementAt(4);
            numericUpDown1015.Value = (decimal)T13_CentO.ElementAt(5);
            numericUpDown1014.Value = (decimal)T13_CentO.ElementAt(6);
            numericUpDown1012.Value = (decimal)T13_CentO.ElementAt(7);
            numericUpDown1010.Value = (decimal)T13_CentO.ElementAt(8);
            numericUpDown1008.Value = (decimal)T13_CentO.ElementAt(9);
            numericUpDown1006.Value = (decimal)T13_CentO.ElementAt(10);
            numericUpDown1004.Value = (decimal)T13_CentO.ElementAt(11);
            numericUpDown1003.Value = (decimal)T13_CentO.ElementAt(12);
            #endregion
            #region Table 14 numericUpDown assignments
            numericUpDown1148.Value = (decimal)T14_RO.ElementAt(0);
            numericUpDown1144.Value = (decimal)T14_RO.ElementAt(1);
            numericUpDown1140.Value = (decimal)T14_RO.ElementAt(2);
            numericUpDown1136.Value = (decimal)T14_RO.ElementAt(3);
            numericUpDown1132.Value = (decimal)T14_RO.ElementAt(4);
            numericUpDown1128.Value = (decimal)T14_RO.ElementAt(5);
            numericUpDown1124.Value = (decimal)T14_RO.ElementAt(6);
            numericUpDown1120.Value = (decimal)T14_RO.ElementAt(7);
            numericUpDown1116.Value = (decimal)T14_RO.ElementAt(8);
            numericUpDown1112.Value = (decimal)T14_RO.ElementAt(9);
            numericUpDown1108.Value = (decimal)T14_RO.ElementAt(10);
            numericUpDown1104.Value = (decimal)T14_RO.ElementAt(11);
            numericUpDown1100.Value = (decimal)T14_RO.ElementAt(12);

            numericUpDown1150.Value = (decimal)T14_LSD.ElementAt(0);
            numericUpDown1154.Value = (decimal)T14_LSD.ElementAt(1);
            numericUpDown1156.Value = (decimal)T14_LSD.ElementAt(2);
            numericUpDown1158.Value = (decimal)T14_LSD.ElementAt(3);
            numericUpDown1162.Value = (decimal)T14_LSD.ElementAt(4);
            numericUpDown1164.Value = (decimal)T14_LSD.ElementAt(5);
            numericUpDown1166.Value = (decimal)T14_LSD.ElementAt(6);
            numericUpDown1170.Value = (decimal)T14_LSD.ElementAt(7);
            numericUpDown1172.Value = (decimal)T14_LSD.ElementAt(8);
            numericUpDown1174.Value = (decimal)T14_LSD.ElementAt(9);
            numericUpDown1169.Value = (decimal)T14_LSD.ElementAt(10);
            numericUpDown1161.Value = (decimal)T14_LSD.ElementAt(11);
            numericUpDown1153.Value = (decimal)T14_LSD.ElementAt(12);

            numericUpDown1152.Value = (decimal)T14_NG.ElementAt(0);
            numericUpDown1155.Value = (decimal)T14_NG.ElementAt(1);
            numericUpDown1157.Value = (decimal)T14_NG.ElementAt(2);
            numericUpDown1160.Value = (decimal)T14_NG.ElementAt(3);
            numericUpDown1163.Value = (decimal)T14_NG.ElementAt(4);
            numericUpDown1165.Value = (decimal)T14_NG.ElementAt(5);
            numericUpDown1168.Value = (decimal)T14_NG.ElementAt(6);
            numericUpDown1171.Value = (decimal)T14_NG.ElementAt(7);
            numericUpDown1173.Value = (decimal)T14_NG.ElementAt(8);
            numericUpDown1175.Value = (decimal)T14_NG.ElementAt(9);
            numericUpDown1167.Value = (decimal)T14_NG.ElementAt(10);
            numericUpDown1159.Value = (decimal)T14_NG.ElementAt(11);
            numericUpDown1151.Value = (decimal)T14_NG.ElementAt(12);

            numericUpDown1146.Value = (decimal)T14_BD.ElementAt(0);
            numericUpDown1142.Value = (decimal)T14_BD.ElementAt(1);
            numericUpDown1138.Value = (decimal)T14_BD.ElementAt(2);
            numericUpDown1134.Value = (decimal)T14_BD.ElementAt(3);
            numericUpDown1130.Value = (decimal)T14_BD.ElementAt(4);
            numericUpDown1126.Value = (decimal)T14_BD.ElementAt(5);
            numericUpDown1122.Value = (decimal)T14_BD.ElementAt(6);
            numericUpDown1118.Value = (decimal)T14_BD.ElementAt(7);
            numericUpDown1114.Value = (decimal)T14_BD.ElementAt(8);
            numericUpDown1110.Value = (decimal)T14_BD.ElementAt(9);
            numericUpDown1106.Value = (decimal)T14_BD.ElementAt(10);
            numericUpDown1102.Value = (decimal)T14_BD.ElementAt(11);
            numericUpDown1098.Value = (decimal)T14_BD.ElementAt(12);

            numericUpDown1145.Value = (decimal)T14_FTD.ElementAt(0);
            numericUpDown1141.Value = (decimal)T14_FTD.ElementAt(1);
            numericUpDown1137.Value = (decimal)T14_FTD.ElementAt(2);
            numericUpDown1133.Value = (decimal)T14_FTD.ElementAt(3);
            numericUpDown1129.Value = (decimal)T14_FTD.ElementAt(4);
            numericUpDown1125.Value = (decimal)T14_FTD.ElementAt(5);
            numericUpDown1121.Value = (decimal)T14_FTD.ElementAt(6);
            numericUpDown1117.Value = (decimal)T14_FTD.ElementAt(7);
            numericUpDown1113.Value = (decimal)T14_FTD.ElementAt(8);
            numericUpDown1109.Value = (decimal)T14_FTD.ElementAt(9);
            numericUpDown1105.Value = (decimal)T14_FTD.ElementAt(10);
            numericUpDown1101.Value = (decimal)T14_FTD.ElementAt(11);
            numericUpDown1097.Value = (decimal)T14_FTD.ElementAt(12);
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
