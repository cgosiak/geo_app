namespace GeoApp
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.runProTab = new System.Windows.Forms.TabPage();
            this.individual = new System.Windows.Forms.TabPage();
            this.teams = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.runProTab);
            this.tabControl1.Controls.Add(this.individual);
            this.tabControl1.Controls.Add(this.teams);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 397);
            this.tabControl1.TabIndex = 0;
            // 
            // runProTab
            // 
            this.runProTab.Location = new System.Drawing.Point(4, 25);
            this.runProTab.Name = "runProTab";
            this.runProTab.Padding = new System.Windows.Forms.Padding(3);
            this.runProTab.Size = new System.Drawing.Size(744, 368);
            this.runProTab.TabIndex = 0;
            this.runProTab.Text = "Main";
            this.runProTab.UseVisualStyleBackColor = true;
            // 
            // individual
            // 
            this.individual.Location = new System.Drawing.Point(4, 25);
            this.individual.Name = "individual";
            this.individual.Padding = new System.Windows.Forms.Padding(3);
            this.individual.Size = new System.Drawing.Size(744, 368);
            this.individual.TabIndex = 1;
            this.individual.Text = "Individual Results";
            this.individual.UseVisualStyleBackColor = true;
            // 
            // teams
            // 
            this.teams.Location = new System.Drawing.Point(4, 25);
            this.teams.Name = "teams";
            this.teams.Padding = new System.Windows.Forms.Padding(3);
            this.teams.Size = new System.Drawing.Size(744, 368);
            this.teams.TabIndex = 2;
            this.teams.Text = "Team Results";
            this.teams.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 421);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Geo Competition";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage runProTab;
        private System.Windows.Forms.TabPage individual;
        private System.Windows.Forms.TabPage teams;
    }
}

