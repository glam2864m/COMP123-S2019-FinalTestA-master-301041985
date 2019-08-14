using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * STUDENT NAME: Yen-Hao Fan
 * STUDENT ID: 301041985
 * DESCRIPTION: This is the Hero Generator Form
 */

namespace COMP123_S2019_FinalTestA.Views
{
    public partial class HeroGenerator : COMP123_S2019_FinalTestA.Views.MasterForm
    {
        public HeroGenerator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the event handler for the BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// This is the event handler for the NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
        }

        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            LoadNames();
            GenerateNames();
        }

        private void GenerateNames()
        {
            FirstNameDataLabel.Text = Program.caracter.FirstName;
            LastNameDataLabel.Text = Program.caracter.LastName;
        }

        private void LoadNames()
        {
            string FirstNameFile = @"..\..\Data\firstNames.txt";
            var ReadFirstNames = File.ReadAllLines(FirstNameFile);
            List<string> FirstNameList = ReadFirstNames.ToList();
            int FirstNameEndNumber = ReadFirstNames.Length;
            int FirstNameRadomNumber = new Random().Next(0, FirstNameEndNumber);
            Program.caracter.FirstName = FirstNameList[FirstNameRadomNumber];

            string LastNameFile = @"..\..\Data\lastNames.txt";
            var ReadLastNames = File.ReadAllLines(LastNameFile);
            List<string> LastNameList = ReadLastNames.ToList();
            int LastNameEndNumber = ReadLastNames.Length;
            int LastNameRadomNumber = new Random().Next(0, LastNameEndNumber);
            LastNameDataLabel.Text = LastNameList[LastNameRadomNumber];
            Program.caracter.LastName = LastNameList[LastNameRadomNumber];
        }

        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            List<int> fightList = new List<int>(Enumerable.Range(10, 50));
            fightList = fightList.OrderBy(num => rand.Next()).ToList<int>();

            List<int> agilityList = new List<int>(Enumerable.Range(10, 50));
            agilityList = agilityList.OrderBy(num => rand.Next()).ToList<int>();

            List<int> strengthList = new List<int>(Enumerable.Range(10, 50));
            strengthList = strengthList.OrderBy(num => rand.Next()).ToList<int>();

            List<int> enduranceList = new List<int>(Enumerable.Range(10, 50));
            enduranceList = enduranceList.OrderBy(num => rand.Next()).ToList<int>();

            List<int> reasonList = new List<int>(Enumerable.Range(10, 50));
            reasonList = reasonList.OrderBy(num => rand.Next()).ToList<int>();

            List<int> intuitionList = new List<int>(Enumerable.Range(10, 50));
            intuitionList = intuitionList.OrderBy(num => rand.Next()).ToList<int>();

            List<int> psycheList = new List<int>(Enumerable.Range(10, 50));
            psycheList = psycheList.OrderBy(num => rand.Next()).ToList<int>();

            List<int> popularityList = new List<int>(Enumerable.Range(10, 50));
            popularityList = popularityList.OrderBy(num => rand.Next()).ToList<int>();


            int i = 0;
            do
            {
                fightList[i].ToString();
                agilityList[i].ToString();
                strengthList[i].ToString();
                enduranceList[i].ToString();
                reasonList[i].ToString();
                intuitionList[i].ToString();
                psycheList[i].ToString();
                popularityList[i].ToString();
            }
            while (i > 1);

            Program.caracter.Fighting = fightList[i].ToString();
            Program.caracter.Agility = agilityList[i].ToString();
            Program.caracter.Strength = strengthList[i].ToString();
            Program.caracter.Endurance = enduranceList[i].ToString();
            Program.caracter.Reason = reasonList[i].ToString();
            Program.caracter.Intuition = intuitionList[i].ToString();
            Program.caracter.Psyche = psycheList[i].ToString();
            Program.caracter.Popularity = popularityList[i].ToString();

            FirstNameDataLabel.Text = Program.caracter.FirstName;
            LastNameDataLabel.Text = Program.caracter.LastName;
            HeroNameLabel.Text = Program.caracter.HeroName;
            FightingDataLabel.Text = Program.caracter.Fighting;
            AgilityDataLabel.Text = Program.caracter.Agility;
            StrengthDataLabel.Text = Program.caracter.Strength;
            EnduranceDataLabel.Text = Program.caracter.Endurance;
            ReasonDataLabel.Text = Program.caracter.Reason;
            IntuitionDataLabel.Text = Program.caracter.Intuition;
            PsycheDataLabel.Text = Program.caracter.Psyche;
            PopularityDataLabel.Text = Program.caracter.Popularity;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            using (StreamWriter outputStream = new StreamWriter(
             File.Open("caracter.txt", FileMode.Create)))
            {
                outputStream.WriteLine(Program.caracter.FirstName);
                outputStream.WriteLine(Program.caracter.LastName);
                outputStream.WriteLine(Program.caracter.Fighting);
                outputStream.WriteLine(Program.caracter.Agility);
                outputStream.WriteLine(Program.caracter.Reason);
                outputStream.WriteLine(Program.caracter.Endurance);
                outputStream.WriteLine(Program.caracter.Intuition);
                outputStream.WriteLine(Program.caracter.Psyche);
                outputStream.WriteLine(Program.caracter.Popularity);

                outputStream.Close();
                outputStream.Dispose();


                MessageBox.Show("File Saved Successfully!", "Saving...",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader inputStream = new StreamReader(File.Open("caracter.txt", FileMode.Open)))
                {

                    Program.caracter.FirstName = inputStream.ReadLine();
                    Program.caracter.LastName = inputStream.ReadLine();
                    Program.caracter.Fighting = inputStream.ReadLine();
                    Program.caracter.Agility = inputStream.ReadLine();
                    Program.caracter.Reason = inputStream.ReadLine();
                    Program.caracter.Endurance = inputStream.ReadLine();
                    Program.caracter.Intuition = inputStream.ReadLine();
                    Program.caracter.Psyche = inputStream.ReadLine();
                    Program.caracter.Popularity = inputStream.ReadLine();

                    inputStream.Close();
                    inputStream.Dispose();
                }
            }
            
            catch (IOException exception)
            {
                Debug.WriteLine("ERROR: " + exception.Message);
            }

            FirstNameDataLabel.Text = Program.caracter.FirstName;
            LastNameDataLabel.Text = Program.caracter.LastName;
            HeroNameLabel.Text = Program.caracter.HeroName;
            FightingDataLabel.Text = Program.caracter.Fighting;
            AgilityDataLabel.Text = Program.caracter.Agility;
            StrengthDataLabel.Text = Program.caracter.Strength;
            EnduranceDataLabel.Text = Program.caracter.Endurance;
            ReasonDataLabel.Text = Program.caracter.Reason;
            IntuitionDataLabel.Text = Program.caracter.Intuition;
            PsycheDataLabel.Text = Program.caracter.Psyche;
            PopularityDataLabel.Text = Program.caracter.Popularity;
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Program.aboutForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HeroGenerator_Load(object sender, EventArgs e)
        {
            LoadNames();
            GenerateNames();
        }
    }
    } 
