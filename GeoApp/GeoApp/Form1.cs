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
using System.Threading;

namespace GeoApp
{
    public partial class Form1 : Form
    {
        // Public Variables
        public bool input_file_available = false; // Does not become true until user selects a file to read from
        public string input_file_name; // The input text file to parse for scores
        public string test_key; // This houses the test key for this particular run
        public string tie_breaker_key; // Houses the string for a tie_breaker
        public string[] student_answer_bank = new string[1000]; // Keeps all student answers in memory
        public int number_of_students; // Total amount of students
        public int processed_students; // Current amt of processed student scores.

        public Form1()
        {
            InitializeComponent();
        }

        private void calcScores_Click(object sender, EventArgs e)
        {
            if (input_file_available)
            {
                processed_students = 0;
                CalculateWithProgress();
            }
            else
            {
                MessageBox.Show("Please select an input file first.");
            }
            input_file_available = false;
        }

        private void getFileButton_Click(object sender, EventArgs e)
        {
            Stream my_stream = null;
            OpenFileDialog input_file_dialogue = new OpenFileDialog();

            // input_file_dialogue.InitialDirectory = "c:\\";
            input_file_dialogue.RestoreDirectory = true;
            number_of_students = 0;

            if (input_file_dialogue.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((my_stream = input_file_dialogue.OpenFile()) != null)
                    {
                        StreamReader input_stream = new StreamReader(my_stream);
                        string current_line;

                        // Enough instances to qualify opening a file!
                        int instance_amount = 0;

                        while ((current_line = input_stream.ReadLine()) != null)
                        {
                            if (current_line.Contains("JUNIORTESTKEY"))
                            {
                                test_key = current_line;
                                instance_amount++;
                            }
                            else if (current_line.Contains("JUNIORTIEBREAKER"))
                            {
                                tie_breaker_key = current_line;
                                instance_amount++;
                            }
                            else
                            {
                                student_answer_bank[number_of_students] = current_line;
                                number_of_students++;
                                if (instance_amount == 2)
                                {
                                    instance_amount++;
                                }
                            }
                        }
                        if (instance_amount == 3)
                        {
                            input_file_name = input_file_dialogue.FileName.ToString(); // sets the usable file
                            input_file_available = true; // file is now available
                            fileLabel.Text = input_file_name;
                            calcScores.BackColor = Color.Green;
                        }
                        else
                        {
                            MessageBox.Show("ERROR: Invalid Read File!");
                        }

                        my_stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        // Progress Bar
        private void CalculateWithProgress()
        {
            // Display the ProgressBar control.
            progressOfApplicationBar.Visible = true;
            // Set Minimum to 1 to represent the first file being copied.
            progressOfApplicationBar.Minimum = 1;
            // Set Maximum to the total number of files to copy.
            progressOfApplicationBar.Maximum = number_of_students;
            // Set the initial value of the ProgressBar.
            progressOfApplicationBar.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            progressOfApplicationBar.Step = 1;

            // Loop through all files to copy.
            for (int x = 0; x < number_of_students; x++)
            {
                // Copy the file and increment the ProgressBar if successful.
                if (CalculateStudentScore(student_answer_bank[x]) == true)
                {
                    // Perform the increment on the ProgressBar.
                    progressOfApplicationBar.PerformStep();
                }
            }

            // Check if everyone was processed correctly
            if (processed_students != number_of_students)
            {
                MessageBox.Show("ERROR: Unable to Process Students");
            }
            else
            {
                DumpData();
            }
        }

        // calculate students work line by line
        public bool CalculateStudentScore(string students_line)
        {
            Console.WriteLine(students_line);

            // Parse user data
            string[] student_data = students_line.Split(",".ToCharArray());

            if (student_data.Length == 5)
            {

                string last_name = student_data[0];
                string first_name = student_data[1];
                string students_class = student_data[2];
                string school_id = student_data[3];
                string answers = student_data[4];
                int student_score = GetStudentScore(answers);

                Console.WriteLine("Score: " + student_score.ToString());
                student_answer_bank[processed_students] = student_score.ToString() + "," + last_name + "," + first_name + "," + students_class + "," + school_id + "," + answers;
                processed_students++;
            }
            else
            {
                MessageBox.Show("ERROR: Unable to Process Student data:\n" + students_line);
                return false;
            }

            return true;
        }

        public int GetStudentScore(string input_answers)
        {
            int score;

            // Scoring info
            int total_correct = 0; // Total correct
            int priority_correct = 0; // Priority Correct from Tie Breaker Key
            int secondary_correct = 0; // Secondary Correct for Tie Breaker Key

            // calculate score
            char[] student_answers = input_answers.ToCharArray();
            char[] answer_key = test_key.ToCharArray();
            char[] tie_break = tie_breaker_key.ToCharArray();

            for (int i=0; i < 40; i++)
            {
                if (student_answers[i] == answer_key[i])
                {
                    total_correct++;
                    if (!(tie_break[i].ToString().Equals("*")))
                    {
                        if (tie_break[i].ToString().Equals("1"))
                        {
                            priority_correct++;
                        } 
                        else
                        {
                            secondary_correct++;
                        }
                    }
                }
            }

            score = (total_correct * 10000) + (priority_correct * 100) + (secondary_correct);

            return score;
        }

        // Dump results to respective files
        public void DumpData()
        {
            sortByScore(student_answer_bank);
            // This needs to be sorted from largest to smallest!
            // We also need to output this data to a file
            individualTextBox.Text = String.Format("{0,6} | {1,20} | {2,20} | {3,20} | {4,20} | {5,40}" + System.Environment.NewLine, "SCORE", "FIRST NAME", "LAST NAME", "CLASS", "SCHOOL", "ANSWERS");
            for (int i = 0; i < number_of_students; i++)
            {
                string[] std_data = student_answer_bank[i].Split(',');//single quotes for char, double for string so we don't need no extra function call
                string write_this = String.Format("{0,-6} | {1,20} | {2,-20} | {3,20} | {4,-20} | {5,40}", std_data[0], std_data[1], std_data[2], std_data[3], std_data[4], std_data[5]);
                individualTextBox.Text = (individualTextBox.Text + write_this+ System.Environment.NewLine);
            }
        }

        public void sortByScore(string[] arrayToSort)
        {
            string[] keyArray = new string[number_of_students];
            for (int i = 0; i < number_of_students; i++)
            {
                string[] splittedString = arrayToSort[i].Split(',');
                keyArray[i] = splittedString[0];
            }
            Array.Sort(keyArray, arrayToSort);
        }
    }
}
