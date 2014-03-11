namespace TEAMSModule
{
    partial class ReductionsGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel11 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel12 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel13 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel14 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel15 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.reduction_graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.reduction_graph)).BeginInit();
            this.SuspendLayout();
            // 
            // reduction_graph
            // 
            customLabel11.Text = "IFO 380 (A)";
            customLabel11.ToPosition = 2D;
            customLabel12.FromPosition = 1D;
            customLabel12.Text = "DMA (ARB) (A)";
            customLabel12.ToPosition = 3D;
            customLabel13.FromPosition = 2D;
            customLabel13.Text = "DMB (Global) (A)";
            customLabel13.ToPosition = 4D;
            customLabel14.FromPosition = 3D;
            customLabel14.Text = "Biodiesel (BD, Methlyester) (A)";
            customLabel14.ToPosition = 5D;
            customLabel15.FromPosition = 4D;
            customLabel15.Text = "Natural Gas (A)";
            customLabel15.ToPosition = 6D;
            chartArea3.AxisX.CustomLabels.Add(customLabel11);
            chartArea3.AxisX.CustomLabels.Add(customLabel12);
            chartArea3.AxisX.CustomLabels.Add(customLabel13);
            chartArea3.AxisX.CustomLabels.Add(customLabel14);
            chartArea3.AxisX.CustomLabels.Add(customLabel15);
            chartArea3.AxisY.LabelStyle.Format = "#%";
            chartArea3.Name = "ChartArea1";
            this.reduction_graph.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend";
            this.reduction_graph.Legends.Add(legend3);
            this.reduction_graph.Location = new System.Drawing.Point(12, 12);
            this.reduction_graph.Name = "reduction_graph";
            this.reduction_graph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.Legend = "Legend";
            series3.LegendText = "Percent Change";
            series3.Name = "percent_change";
            this.reduction_graph.Series.Add(series3);
            this.reduction_graph.Size = new System.Drawing.Size(823, 452);
            this.reduction_graph.TabIndex = 0;
            this.reduction_graph.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title";
            title3.Text = "Title";
            this.reduction_graph.Titles.Add(title3);
            // 
            // ReductionsGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 476);
            this.Controls.Add(this.reduction_graph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReductionsGraph";
            this.Text = "Reductions in Energy Use and Emissions by Fuel Type";
            this.Load += new System.EventHandler(this.BarGraphSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reduction_graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart reduction_graph;
    }
}