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
            this.getFileButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.calcScores = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.individualTab = new System.Windows.Forms.TabPage();
            this.teamTab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.runProTab.SuspendLayout();
            this.results.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.runProTab);
            this.tabControl1.Controls.Add(this.results);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 397);
            this.tabControl1.TabIndex = 0;
            // 
            // runProTab
            // 
            this.runProTab.Controls.Add(this.getFileButton);
            this.runProTab.Controls.Add(this.fileLabel);
            this.runProTab.Controls.Add(this.calcScores);
            this.runProTab.Location = new System.Drawing.Point(4, 29);
            this.runProTab.Name = "runProTab";
            this.runProTab.Padding = new System.Windows.Forms.Padding(3);
            this.runProTab.Size = new System.Drawing.Size(744, 364);
            this.runProTab.TabIndex = 0;
            this.runProTab.Text = "Main";
            this.runProTab.UseVisualStyleBackColor = true;
            // 
            // getFileButton
            // 
            this.getFileButton.Location = new System.Drawing.Point(314, 113);
            this.getFileButton.Name = "getFileButton";
            this.getFileButton.Size = new System.Drawing.Size(125, 30);
            this.getFileButton.TabIndex = 2;
            this.getFileButton.Text = "Open File";
            this.getFileButton.UseVisualStyleBackColor = true;
            this.getFileButton.Click += new System.EventHandler(this.getFileButton_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fileLabel.Location = new System.Drawing.Point(83, 80);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(586, 30);
            this.fileLabel.TabIndex = 1;
            this.fileLabel.Text = "Please Select File to Read Scores";
            this.fileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // calcScores
            // 
            this.calcScores.AutoSize = true;
            this.calcScores.BackColor = System.Drawing.Color.Transparent;
            this.calcScores.Location = new System.Drawing.Point(563, 318);
            this.calcScores.Name = "calcScores";
            this.calcScores.Size = new System.Drawing.Size(175, 40);
            this.calcScores.TabIndex = 0;
            this.calcScores.Text = "Calcualte Scores";
            this.calcScores.UseVisualStyleBackColor = false;
            this.calcScores.Click += new System.EventHandler(this.calcScores_Click);
            // 
            // results
            // 
            this.results.Controls.Add(this.tabControl2);
            this.results.Location = new System.Drawing.Point(4, 29);
            this.results.Name = "results";
            this.results.Padding = new System.Windows.Forms.Padding(3);
            this.results.Size = new System.Drawing.Size(744, 364);
            this.results.TabIndex = 1;
            this.results.Text = "Results";
            this.results.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.individualTab);
            this.tabControl2.Controls.Add(this.teamTab);
            this.tabControl2.Location = new System.Drawing.Point(-4, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(752, 365);
            this.tabControl2.TabIndex = 0;
            // 
            // individualTab
            // 
            this.individualTab.Location = new System.Drawing.Point(4, 29);
            this.individualTab.Margin = new System.Windows.Forms.Padding(0);
            this.individualTab.Name = "individualTab";
            this.individualTab.Padding = new System.Windows.Forms.Padding(3);
            this.individualTab.Size = new System.Drawing.Size(744, 332);
            this.individualTab.TabIndex = 0;
            this.individualTab.Text = "Individual";
            this.individualTab.UseVisualStyleBackColor = true;
            // 
            // teamTab
            // 
            this.teamTab.Location = new System.Drawing.Point(4, 29);
            this.teamTab.Name = "teamTab";
            this.teamTab.Padding = new System.Windows.Forms.Padding(3);
            this.teamTab.Size = new System.Drawing.Size(744, 332);
            this.teamTab.TabIndex = 1;
            this.teamTab.Text = "Team";
            this.teamTab.UseVisualStyleBackColor = true;
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
            this.runProTab.ResumeLayout(false);
            this.runProTab.PerformLayout();
            this.results.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage runProTab;
        private System.Windows.Forms.TabPage results;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage individualTab;
        private System.Windows.Forms.TabPage teamTab;
        private System.Windows.Forms.Button calcScores;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button getFileButton;
    }
}

