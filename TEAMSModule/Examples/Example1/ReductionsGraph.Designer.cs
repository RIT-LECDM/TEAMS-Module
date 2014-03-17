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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel3 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel4 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel5 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.reduction_graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.reduction_graph)).BeginInit();
            this.SuspendLayout();
            // 
            // reduction_graph
            // 
            customLabel1.Text = "IFO 380 (A)";
            customLabel1.ToPosition = 2D;
            customLabel2.FromPosition = 1D;
            customLabel2.Text = "DMA (ARB) (A)";
            customLabel2.ToPosition = 3D;
            customLabel3.FromPosition = 2D;
            customLabel3.Text = "DMB (Global) (A)";
            customLabel3.ToPosition = 4D;
            customLabel4.FromPosition = 3D;
            customLabel4.Text = "Biodiesel (BD, Methlyester) (A)";
            customLabel4.ToPosition = 5D;
            customLabel5.FromPosition = 4D;
            customLabel5.Text = "Natural Gas (A)";
            customLabel5.ToPosition = 6D;
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.CustomLabels.Add(customLabel2);
            chartArea1.AxisX.CustomLabels.Add(customLabel3);
            chartArea1.AxisX.CustomLabels.Add(customLabel4);
            chartArea1.AxisX.CustomLabels.Add(customLabel5);
            chartArea1.AxisY.LabelStyle.Format = "#%";
            chartArea1.BackSecondaryColor = System.Drawing.Color.Red;
            chartArea1.Name = "ChartArea1";
            this.reduction_graph.ChartAreas.Add(chartArea1);
            this.reduction_graph.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            legend1.Name = "Legend";
            this.reduction_graph.Legends.Add(legend1);
            this.reduction_graph.Location = new System.Drawing.Point(13, 15);
            this.reduction_graph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reduction_graph.Name = "reduction_graph";
            this.reduction_graph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            series1.Legend = "Legend";
            series1.LegendText = "Percent Change";
            series1.Name = "percent_change";
            this.reduction_graph.Series.Add(series1);
            this.reduction_graph.Size = new System.Drawing.Size(1100, 568);
            this.reduction_graph.TabIndex = 0;
            this.reduction_graph.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title";
            title1.Text = "Title";
            this.reduction_graph.Titles.Add(title1);
            // 
            // ReductionsGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 586);
            this.Controls.Add(this.reduction_graph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ReductionsGraph";
            this.Text = "Reductions in Energy Use and Emissions by Fuel Type";
            ((System.ComponentModel.ISupportInitialize)(this.reduction_graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart reduction_graph;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}