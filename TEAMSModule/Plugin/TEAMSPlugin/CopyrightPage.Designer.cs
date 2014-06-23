namespace TEAMSModule
{
    partial class Copyright
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Copyright));
            this.I_Understand_Button = new System.Windows.Forms.Button();
            this.Copyright_Textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // I_Understand_Button
            // 
            this.I_Understand_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(140)))), ((int)(((byte)(51)))));
            this.I_Understand_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.I_Understand_Button.Font = new System.Drawing.Font("Times New Roman", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.I_Understand_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.I_Understand_Button.Location = new System.Drawing.Point(250, 500);
            this.I_Understand_Button.Name = "I_Understand_Button";
            this.I_Understand_Button.Size = new System.Drawing.Size(200, 50);
            this.I_Understand_Button.TabIndex = 3;
            this.I_Understand_Button.Text = "I Understand";
            this.I_Understand_Button.UseVisualStyleBackColor = false;
            this.I_Understand_Button.Click += new System.EventHandler(this.I_Understand_Button_Click);
            // 
            // Copyright_Textbox
            // 
            this.Copyright_Textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(140)))), ((int)(((byte)(51)))));
            this.Copyright_Textbox.Font = new System.Drawing.Font("Times New Roman", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Copyright_Textbox.HideSelection = false;
            this.Copyright_Textbox.Location = new System.Drawing.Point(10, 12);
            this.Copyright_Textbox.Multiline = true;
            this.Copyright_Textbox.Name = "Copyright_Textbox";
            this.Copyright_Textbox.ReadOnly = true;
            this.Copyright_Textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Copyright_Textbox.Size = new System.Drawing.Size(660, 482);
            this.Copyright_Textbox.TabIndex = 4;
            this.Copyright_Textbox.Text = resources.GetString("Copyright_Textbox.Text");
            this.Copyright_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Copyright
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(17)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(684, 662);
            this.Controls.Add(this.Copyright_Textbox);
            this.Controls.Add(this.I_Understand_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "Copyright";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEAMS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button I_Understand_Button;
        private System.Windows.Forms.TextBox Copyright_Textbox;
    }
}