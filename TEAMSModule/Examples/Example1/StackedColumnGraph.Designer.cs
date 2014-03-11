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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel37 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel38 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel39 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel40 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel41 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel42 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel43 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel44 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel45 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel46 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel47 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel48 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.stacked_graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.stacked_graph)).BeginInit();
            this.SuspendLayout();
            // 
            // stacked_graph
            // 
            customLabel37.Text = "Total \nEnergy";
            customLabel37.ToPosition = 2D;
            customLabel38.FromPosition = 1D;
            customLabel38.Text = "Fossil \nFuels";
            customLabel38.ToPosition = 3D;
            customLabel39.FromPosition = 2D;
            customLabel39.Text = "Petroleum";
            customLabel39.ToPosition = 4D;
            customLabel40.FromPosition = 3D;
            customLabel40.Text = "CO2";
            customLabel40.ToPosition = 5D;
            customLabel41.FromPosition = 4D;
            customLabel41.Text = "CH4";
            customLabel41.ToPosition = 6D;
            customLabel42.FromPosition = 5D;
            customLabel42.Text = "N2O";
            customLabel42.ToPosition = 7D;
            customLabel43.FromPosition = 6D;
            customLabel43.Text = "GHGs";
            customLabel43.ToPosition = 8D;
            customLabel44.FromPosition = 7D;
            customLabel44.Text = "VOC";
            customLabel44.ToPosition = 9D;
            customLabel45.FromPosition = 8D;
            customLabel45.Text = "CO";
            customLabel45.ToPosition = 10D;
            customLabel46.FromPosition = 9D;
            customLabel46.Text = "NOx";
            customLabel46.ToPosition = 11D;
            customLabel47.FromPosition = 10D;
            customLabel47.Text = "PM10";
            customLabel47.ToPosition = 12D;
            customLabel48.FromPosition = 11D;
            customLabel48.Text = "SOx";
            customLabel48.ToPosition = 13D;
            chartArea4.AxisX.CustomLabels.Add(customLabel37);
            chartArea4.AxisX.CustomLabels.Add(customLabel38);
            chartArea4.AxisX.CustomLabels.Add(customLabel39);
            chartArea4.AxisX.CustomLabels.Add(customLabel40);
            chartArea4.AxisX.CustomLabels.Add(customLabel41);
            chartArea4.AxisX.CustomLabels.Add(customLabel42);
            chartArea4.AxisX.CustomLabels.Add(customLabel43);
            chartArea4.AxisX.CustomLabels.Add(customLabel44);
            chartArea4.AxisX.CustomLabels.Add(customLabel45);
            chartArea4.AxisX.CustomLabels.Add(customLabel46);
            chartArea4.AxisX.CustomLabels.Add(customLabel47);
            chartArea4.AxisX.CustomLabels.Add(customLabel48);
            chartArea4.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Angle = 90;
            chartArea4.Name = "ChartArea1";
            this.stacked_graph.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.stacked_graph.Legends.Add(legend4);
            this.stacked_graph.Location = new System.Drawing.Point(10, 11);
            this.stacked_graph.Name = "stacked_graph";
            this.stacked_graph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series7.Legend = "Legend1";
            series7.Name = "Upstream";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series8.Legend = "Legend1";
            series8.LegendText = "Vessel Operation";
            series8.Name = "VesselOperation";
            this.stacked_graph.Series.Add(series7);
            this.stacked_graph.Series.Add(series8);
            this.stacked_graph.Size = new System.Drawing.Size(832, 513);
            this.stacked_graph.TabIndex = 3;
            this.stacked_graph.Text = "chart1";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.Name = "title";
            title4.Text = "Title";
            this.stacked_graph.Titles.Add(title4);
            // 
            // StackedColumnGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 553);
            this.Controls.Add(this.stacked_graph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StackedColumnGraph";
            this.Text = "Contribution of Each Stage to Total Fuel-Cycle Energy Consumption and Emissions";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stacked_graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart stacked_graph;

    }
}

