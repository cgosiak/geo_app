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
        public string outputFilePath; //

        public string test_key; // This houses the test key for this particular run
        public string tie_breaker_key; // Houses the string for a tie_breaker
        public string[] student_answer_bank = new string[1000]; // Keeps all student answers in memory
        public List<string[]> schoolStuff = new List<string[]>();
        public int number_of_students; // Total amount of students
        public int processed_students; // Current amt of processed student scores.

        public const string INDIV_FILE_NAME = "individualScores.txt";
        public const string TEAM_FILE_NAME = "teamScores.txt";
        public const string INDIV_OUT_HEADER_ONE = "\t\t\tBemidji State University";
        public const string INDIV_OUT_HEADER_TWO = "\t\tJunior Division Scores With Tiebreakers";
        public const string TEAM_OUT_HEADER_ONE = "\t\t\tBemidji State University";
        public const string TEAM_OUT_HEADER_TWO = "\t\t\tJunior Division Team Scores\n";

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
                                instance_amount = instance_amount + 1;
                            }
                            else if (current_line.Contains("JUNIORTIEBREAKER"))
                            {
                                tie_breaker_key = current_line;
                                instance_amount = instance_amount + 2;
                            }
                            else if (! String.IsNullOrWhiteSpace(current_line))
                            {
                                student_answer_bank[number_of_students] = current_line;
                                number_of_students++;
                                instance_amount = instance_amount | 4;
                            }
                        }
                        if (instance_amount == 7)
                        {
                            input_file_name = input_file_dialogue.FileName.ToString(); // sets the usable file
                            input_file_available = true; // file is now available
                            fileLabel.Text = input_file_name;
                            calcScores.BackColor = Color.Green;
                            getFileButton.BackColor = Color.Transparent;
                            setUpOutput();
                        }
                        else if (instance_amount < 7)
                        {
                            if ((instance_amount & 1) != 1)
                            {
                                MessageBox.Show("No test key found. File must have a line with \"JUNIORTESTKEY\"");
                            }
                            if ((instance_amount & 2) != 2)
                            {
                                MessageBox.Show("No tie breaker found. File must have a line with \"JUNIORTIEBREAKER\"");
                            }
                            if ((instance_amount & 4) != 4)
                            {
                                MessageBox.Show("No student entries found...");
                            }
                        } else
                        {
                            MessageBox.Show("More than one test key or tie breaker found");
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
                else
                {
                    break;
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
                calcScores.BackColor = Color.Firebrick;
                getFileButton.BackColor = Color.Green;
            }
        }

        // calculate students work line by line
        public bool CalculateStudentScore(string students_line)
        {
            //Console.WriteLine(students_line);

            // Parse user data
            string[] student_data = students_line.Split(",".ToCharArray());

            if (student_data.Length == 5)
            {

                string last_name = student_data[0];
                string first_name = student_data[1];
                string students_class = student_data[2];
                string school_id = student_data[3];
                string answers = student_data[4];
                int n_u_m_b_e_rC_o_r_r_e_c_t = 0;
                int student_score = GetStudentScore(answers, ref n_u_m_b_e_rC_o_r_r_e_c_t);
                if (student_score == -1)
                {
                    MessageBox.Show(last_name + ", " + first_name + " answer string does not match length of answer key. Score is assigned -1");

                } else if (student_score == -2)
                {
                    MessageBox.Show("Tie breaker key length is shorter than the length of the answer key. Unable to process student data.");
                    return false;
                } else if (student_score == -3)
                {
                    MessageBox.Show("Answer key is shorter than tie breaker key. Unable to process student data.");
                    return false;
                }

                //Console.WriteLine("Score: " + student_score.ToString());
                student_answer_bank[processed_students] = student_score.ToString() + "," + last_name + "," + first_name + "," + students_class + "," + school_id + "," + answers + "," + n_u_m_b_e_rC_o_r_r_e_c_t.ToString();
                processed_students++;
            }
            else
            {
                MessageBox.Show("ERROR: Unable to Process Student data:\n" + students_line);
                return false;
            }

            return true;
        }

        public int GetStudentScore(string input_answers, ref int numCorrect)
        {
            int score;

            // Scoring info
            int total_correct = 0; // Total correct
            int priority_correct = 0; // Priority Correct from Tie Breaker Key
            int secondary_correct = 0; // Secondary Correct for Tie Breaker Key

            // calculate score
            char[] student_answers = input_answers.ToCharArray();
            char[] answer_key = test_key.Split(",".ToCharArray())[4].ToCharArray();
            char[] tie_break = tie_breaker_key.Split(",".ToCharArray())[4].ToCharArray();

            if (answer_key.Length < tie_break.Length)
            {
                return -3;
            }
            if (answer_key.Length > tie_break.Length)
            {
                return -2;
            }
            if (student_answers.Length < answer_key.Length)
            {
                return -1;
            }

            for (int i=0; i < answer_key.Length; i++)
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
            numCorrect = total_correct;
            score = (total_correct * 10000) + (priority_correct * 100) + (secondary_correct);

            return score;
        }

        // Dump results to respective files
        public void DumpData()
        {
            sortByScore();
            sortBySchool();
            individualTextBox.Text = String.Format("{0,6} | {1,20} | {2,-20} | {3,20} | {4,-20} | {5,-40}" + Environment.NewLine, "SCORE", "LAST NAME", "FIRST NAME", "CLASS", "SCHOOL", "ANSWERS");
            for (int i = number_of_students-1; i >= 0; i--)//goes from top to bottom because not dynamic size means reverse doesn't work
            {
                string[] std_data = student_answer_bank[i].Split(',');//single quotes for char, double for string so we don't need no extra function call
                string write_this = String.Format("{0,-6} | {1,20} | {2,-20} | {3,20} | {4,-20} | {5,-40}", std_data[0], std_data[1], std_data[2], std_data[3], std_data[4], std_data[5]);
                individualTextBox.Text += write_this+ Environment.NewLine;
            }

            teamTabTextBox.Text = String.Format("{0,-20} | {1,20} | {2,-20}" + Environment.NewLine, "CORRECT", "LAST NAME", "FIRST NAME");
            int topSchoolScore = 0;
            string topSchoolCode = "";
            for (int i = 0; i < schoolStuff.Count(); i++)
            {
                int topThreeScore = 0;
                string schoolCode = schoolStuff[i][0].Split(',')[4];//one of the grossest lines of c# I have ever written, goes to current school, first student there, splits the student info string, then uses only the school code (from index 4)
                string writeItYourself = String.Format(Environment.NewLine + "{0,-6}" + Environment.NewLine + "======", schoolCode);
                teamTabTextBox.Text = (teamTabTextBox.Text + writeItYourself + Environment.NewLine);
                for (int j = 0; j < schoolStuff[i].Count(); j++)
                {
                    string[] splittedString = schoolStuff[i][j].Split(',');
                    if (j < 3)//since students in each school are in descending order, this gets the scores from the top 3
                    {
                        topThreeScore += Convert.ToInt32(splittedString[6]);
                    }
                    string makeMe = String.Format("{0,-20} | {1,20} | {2,-20}" + Environment.NewLine, splittedString[6], splittedString[1], splittedString[2]);
                    teamTabTextBox.Text += makeMe;
                }
                teamTabTextBox.Text += String.Format(Environment.NewLine + "Team Score: {0,5}" + Environment.NewLine, topThreeScore);
                if (topThreeScore > topSchoolScore)//finding highest scoring school
                {
                    topSchoolScore = topThreeScore;
                    topSchoolCode = schoolCode;
                } else if (topThreeScore == topSchoolScore)
                {
                    topSchoolCode += "," + schoolCode;
                }
            }
            teamTabTextBox.Text += String.Format(Environment.NewLine + Environment.NewLine + "====================================" + Environment.NewLine + "Top School(s): {0,10}" + Environment.NewLine + "Score: {1,10}", topSchoolCode, topSchoolScore);
            schoolStuff = new List<string[]>();//resets school stuff just in case user reads in another file without closing and reopening

            string individualOutputFileName = outputFilePath + INDIV_FILE_NAME;
            string teamOutputFileName = outputFilePath + TEAM_FILE_NAME;
            File.WriteAllText(individualOutputFileName, INDIV_OUT_HEADER_ONE + Environment.NewLine + INDIV_OUT_HEADER_TWO + Environment.NewLine + individualTextBox.Text);//simplest method for writing to file I have ever seen
            File.WriteAllText(teamOutputFileName, TEAM_OUT_HEADER_ONE + Environment.NewLine + TEAM_OUT_HEADER_TWO + Environment.NewLine + teamTabTextBox.Text);

        }

        public void sortByScore()//hardcoded to sort our global answer_bank array
        {
            int[] keyArray = new int[number_of_students];//keyArray to hold scores to sort by
            for (int i = 0; i < number_of_students; i++)
            {
                string[] splittedString = student_answer_bank[i].Split(',');
                keyArray[i] = Convert.ToInt32(splittedString[0]);//pull score out of splitted string and convert to int for proper sorting
            }
            Array.Sort(keyArray, student_answer_bank);//method that uses first array to sort second
        }

        public void sortBySchool()
        {
            string[] answerBankCopy = (string[]) student_answer_bank.Clone();//make a copy of answer_bank so we don't mess up the inappropriately global array
            int[] keyArray = new int[number_of_students];//another key array, this is for sorting by school
            for (int i = 0; i < number_of_students; i++)
            {
                string[] splittedString = answerBankCopy[i].Split(',');
                keyArray[i] = Convert.ToInt32(splittedString[4]);
            }
            Array.Sort(keyArray, answerBankCopy);

            
            List<string> schoolBuilder = new List<string>();//using lists for dynamic allocation and school separation
            string prevSchoolCode = "";
            for (int i = 0; i < number_of_students; i++)//build up a school of students
            {
                string[] splitString = answerBankCopy[i].Split(',');
                if (splitString[4] != prevSchoolCode)//if we have reached a different school
                {
                    if (i != 0)//not the very first iteration
                    {
                        schoolStuff.Add(schoolBuilder.ToArray());//puts our newly grouped school into List of schools
                        schoolBuilder = new List<string>();//clears out the school so it is ready to begin again
                    }
                    prevSchoolCode = splitString[4];

                }
                schoolBuilder.Add(answerBankCopy[i]);//putting a student into the school
            }
            
            for (int i = 0; i < schoolStuff.Count; i++)//sorting each individual school by number of correct questions for each student
            {
                int[] tempKeys = new int[schoolStuff[i].Length];//the key array thing again
                for (int j = 0; j < schoolStuff[i].Length; j++)
                {
                    string[] splittedItUp = schoolStuff[i][j].Split(',');
                    tempKeys[j] = Convert.ToInt32(splittedItUp[6]);//grabbing total correct answers
                }
                Array.Sort(tempKeys, schoolStuff[i]);
                Array.Reverse(schoolStuff[i]);//reverse so in descending order
            }
        }

        public void setUpOutput()
        {
            int cutPosition = input_file_name.LastIndexOf('\\');
            char[] newPath = new char[++cutPosition];
            input_file_name.CopyTo(0,newPath,0,cutPosition);
            outputFilePath = new string(newPath);
        }
    }
}
