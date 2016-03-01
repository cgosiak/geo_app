using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GeoApp
{
    public partial class Form1 : Form
    {
        // Public Variables
        public bool input_file_available = false; // Does not become true until user selects a file to read from
        public string input_file_name; // The input text file to parse for scores

        public Form1()
        {
            InitializeComponent();
        }

        private void calcScores_Click(object sender, EventArgs e)
        {
            if (input_file_available)
            {
                int x = 0;
            }
            else
            {
                MessageBox.Show("Please select an input file first.");
            }
        }

        private void getFileButton_Click(object sender, EventArgs e)
        {
            Stream my_stream = null;
            OpenFileDialog input_file_dialogue = new OpenFileDialog();

            // input_file_dialogue.InitialDirectory = "c:\\";
            input_file_dialogue.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            input_file_dialogue.FilterIndex = 2;
            input_file_dialogue.RestoreDirectory = true;

            if (input_file_dialogue.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((my_stream = input_file_dialogue.OpenFile()) != null)
                    {
                        input_file_name = input_file_dialogue.FileName.ToString(); // sets the usable file
                        input_file_available = true; // file is now available
                        fileLabel.Text = input_file_name;
                        my_stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
