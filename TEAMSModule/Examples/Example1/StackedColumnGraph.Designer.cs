namespace TEAMSModule
{
    partial class StackedColumnGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel3 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel4 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel5 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel6 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel7 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel8 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel9 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel10 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel11 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel12 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.stacked_graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.stacked_graph)).BeginInit();
            this.SuspendLayout();
            // 
            // stacked_graph
            // 
            customLabel1.Text = "Total \nEnergy";
            customLabel1.ToPosition = 2D;
            customLabel2.FromPosition = 1D;
            customLabel2.Text = "Fossil \nFuels";
            customLabel2.ToPosition = 3D;
            customLabel3.FromPosition = 2D;
            customLabel3.Text = "Petroleum";
            customLabel3.ToPosition = 4D;
            customLabel4.FromPosition = 3D;
            customLabel4.Text = "CO2";
            customLabel4.ToPosition = 5D;
            customLabel5.FromPosition = 4D;
            customLabel5.Text = "CH4";
            customLabel5.ToPosition = 6D;
            customLabel6.FromPosition = 5D;
            customLabel6.Text = "N2O";
            customLabel6.ToPosition = 7D;
            customLabel7.FromPosition = 6D;
            customLabel7.Text = "GHGs";
            customLabel7.ToPosition = 8D;
            customLabel8.FromPosition = 7D;
            customLabel8.Text = "VOC";
            customLabel8.ToPosition = 9D;
            customLabel9.FromPosition = 8D;
            customLabel9.Text = "CO";
            customLabel9.ToPosition = 10D;
            customLabel10.FromPosition = 9D;
            customLabel10.Text = "NOx";
            customLabel10.ToPosition = 11D;
            customLabel11.FromPosition = 10D;
            customLabel11.Text = "PM10";
            customLabel11.ToPosition = 12D;
            customLabel12.FromPosition = 11D;
            customLabel12.Text = "SOx";
            customLabel12.ToPosition = 13D;
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.CustomLabels.Add(customLabel2);
            chartArea1.AxisX.CustomLabels.Add(customLabel3);
            chartArea1.AxisX.CustomLabels.Add(customLabel4);
            chartArea1.AxisX.CustomLabels.Add(customLabel5);
            chartArea1.AxisX.CustomLabels.Add(customLabel6);
            chartArea1.AxisX.CustomLabels.Add(customLabel7);
            chartArea1.AxisX.CustomLabels.Add(customLabel8);
            chartArea1.AxisX.CustomLabels.Add(customLabel9);
            chartArea1.AxisX.CustomLabels.Add(customLabel10);
            chartArea1.AxisX.CustomLabels.Add(customLabel11);
            chartArea1.AxisX.CustomLabels.Add(customLabel12);
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Angle = 90;
            chartArea1.Name = "ChartArea1";
            this.stacked_graph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.stacked_graph.Legends.Add(legend1);
            this.stacked_graph.Location = new System.Drawing.Point(10, 11);
            this.stacked_graph.Name = "stacked_graph";
            this.stacked_graph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series1.Legend = "Legend1";
            series1.Name = "Upstream";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series2.Legend = "Legend1";
            series2.LegendText = "Vessel Operation";
            series2.Name = "VesselOperation";
            this.stacked_graph.Series.Add(series1);
            this.stacked_graph.Series.Add(series2);
            this.stacked_graph.Size = new System.Drawing.Size(832, 513);
            this.stacked_graph.TabIndex = 3;
            this.stacked_graph.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "title";
            title1.Text = "Title";
            this.stacked_graph.Titles.Add(title1);
            // 
            // StackedColumnGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 553);
            this.Controls.Add(this.stacked_graph);
            this.Name = "StackedColumnGraph";
            this.Text = "Graphs";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stacked_graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart stacked_graph;

    }
}

