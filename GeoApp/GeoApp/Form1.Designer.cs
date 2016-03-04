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
            this.progressOfApplicationBar = new System.Windows.Forms.ProgressBar();
            this.getFileButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.calcScores = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.individualTab = new System.Windows.Forms.TabPage();
            this.individualTextBox = new System.Windows.Forms.TextBox();
            this.teamTab = new System.Windows.Forms.TabPage();
            this.teamTabTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.runProTab.SuspendLayout();
            this.results.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.individualTab.SuspendLayout();
            this.teamTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.runProTab);
            this.tabControl1.Controls.Add(this.results);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(810, 614);
            this.tabControl1.TabIndex = 0;
            // 
            // runProTab
            // 
            this.runProTab.Controls.Add(this.progressOfApplicationBar);
            this.runProTab.Controls.Add(this.getFileButton);
            this.runProTab.Controls.Add(this.fileLabel);
            this.runProTab.Controls.Add(this.calcScores);
            this.runProTab.Location = new System.Drawing.Point(4, 25);
            this.runProTab.Margin = new System.Windows.Forms.Padding(2);
            this.runProTab.Name = "runProTab";
            this.runProTab.Padding = new System.Windows.Forms.Padding(2);
            this.runProTab.Size = new System.Drawing.Size(802, 585);
            this.runProTab.TabIndex = 0;
            this.runProTab.Text = "Main";
            this.runProTab.UseVisualStyleBackColor = true;
            // 
            // progressOfApplicationBar
            // 
            this.progressOfApplicationBar.BackColor = System.Drawing.SystemColors.Menu;
            this.progressOfApplicationBar.Location = new System.Drawing.Point(7, 528);
            this.progressOfApplicationBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressOfApplicationBar.Name = "progressOfApplicationBar";
            this.progressOfApplicationBar.Size = new System.Drawing.Size(788, 32);
            this.progressOfApplicationBar.TabIndex = 3;
            // 
            // getFileButton
            // 
            this.getFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getFileButton.Location = new System.Drawing.Point(217, 29);
            this.getFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.getFileButton.Name = "getFileButton";
            this.getFileButton.Size = new System.Drawing.Size(336, 94);
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
            this.fileLabel.Location = new System.Drawing.Point(7, 2);
            this.fileLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(788, 25);
            this.fileLabel.TabIndex = 1;
            this.fileLabel.Text = "Please Select File to Read Scores";
            this.fileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // calcScores
            // 
            this.calcScores.AutoSize = true;
            this.calcScores.BackColor = System.Drawing.Color.Transparent;
            this.calcScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcScores.Location = new System.Drawing.Point(217, 394);
            this.calcScores.Margin = new System.Windows.Forms.Padding(2);
            this.calcScores.Name = "calcScores";
            this.calcScores.Size = new System.Drawing.Size(336, 130);
            this.calcScores.TabIndex = 0;
            this.calcScores.Text = "Calculate Scores";
            this.calcScores.UseVisualStyleBackColor = false;
            this.calcScores.Click += new System.EventHandler(this.calcScores_Click);
            // 
            // results
            // 
            this.results.Controls.Add(this.tabControl2);
            this.results.Location = new System.Drawing.Point(4, 25);
            this.results.Margin = new System.Windows.Forms.Padding(2);
            this.results.Name = "results";
            this.results.Padding = new System.Windows.Forms.Padding(2);
            this.results.Size = new System.Drawing.Size(802, 585);
            this.results.TabIndex = 1;
            this.results.Text = "Results";
            this.results.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.individualTab);
            this.tabControl2.Controls.Add(this.teamTab);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(2, 2);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(798, 581);
            this.tabControl2.TabIndex = 0;
            // 
            // individualTab
            // 
            this.individualTab.Controls.Add(this.individualTextBox);
            this.individualTab.Location = new System.Drawing.Point(4, 25);
            this.individualTab.Margin = new System.Windows.Forms.Padding(0);
            this.individualTab.Name = "individualTab";
            this.individualTab.Padding = new System.Windows.Forms.Padding(2);
            this.individualTab.Size = new System.Drawing.Size(790, 552);
            this.individualTab.TabIndex = 0;
            this.individualTab.Text = "Individual";
            this.individualTab.UseVisualStyleBackColor = true;
            // 
            // individualTextBox
            // 
            this.individualTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.individualTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.individualTextBox.Location = new System.Drawing.Point(2, 2);
            this.individualTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.individualTextBox.Multiline = true;
            this.individualTextBox.Name = "individualTextBox";
            this.individualTextBox.ReadOnly = true;
            this.individualTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.individualTextBox.Size = new System.Drawing.Size(786, 548);
            this.individualTextBox.TabIndex = 0;
            this.individualTextBox.WordWrap = false;
            // 
            // teamTab
            // 
            this.teamTab.Controls.Add(this.teamTabTextBox);
            this.teamTab.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTab.Location = new System.Drawing.Point(4, 25);
            this.teamTab.Margin = new System.Windows.Forms.Padding(2);
            this.teamTab.Name = "teamTab";
            this.teamTab.Padding = new System.Windows.Forms.Padding(2);
            this.teamTab.Size = new System.Drawing.Size(790, 552);
            this.teamTab.TabIndex = 1;
            this.teamTab.Text = "Team";
            this.teamTab.UseVisualStyleBackColor = true;
            // 
            // teamTabTextBox
            // 
            this.teamTabTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamTabTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTabTextBox.Location = new System.Drawing.Point(2, 2);
            this.teamTabTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.teamTabTextBox.Multiline = true;
            this.teamTabTextBox.Name = "teamTabTextBox";
            this.teamTabTextBox.ReadOnly = true;
            this.teamTabTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.teamTabTextBox.Size = new System.Drawing.Size(786, 548);
            this.teamTabTextBox.TabIndex = 1;
            this.teamTabTextBox.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 614);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Geo Competition";
            this.tabControl1.ResumeLayout(false);
            this.runProTab.ResumeLayout(false);
            this.runProTab.PerformLayout();
            this.results.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.individualTab.ResumeLayout(false);
            this.individualTab.PerformLayout();
            this.teamTab.ResumeLayout(false);
            this.teamTab.PerformLayout();
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
        private System.Windows.Forms.ProgressBar progressOfApplicationBar;
        private System.Windows.Forms.TextBox individualTextBox;
        private System.Windows.Forms.TextBox teamTabTextBox;
    }
}

