using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    {
        BindingList<UserModel> users = new BindingList<UserModel>();

        string filePath = @"StandardDataSet.csv";

        public int firstNamePosition;
        public int lastNamePosition;
        public int agePosition;
        public int isAlivePosition;

        public ChallengeForm()
        {
            InitializeComponent();

            LoadListFromFile();

            WireUpDropDown();
        }

        private void WireUpDropDown()
        {
            usersListBox.DataSource = users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        private void LoadListFromFile()
        {
            string[] parts = File.ReadAllLines(filePath);

            string[] headers = parts[0].Split(',');

            for (int i = 0; i < headers.Length; i++)
            {
                if (headers[i] == "FirstName") firstNamePosition = i;
                else if (headers[i] == "LastName") lastNamePosition = i;
                else if (headers[i] == "Age") agePosition = i;
                else if (headers[i] == "IsAlive") isAlivePosition = i;
            }

            foreach (string part in parts.Skip(1))
            {
                string[] columns = part.Split(',');

                bool isAgeParsed = int.TryParse(columns[agePosition], out int age);
                bool isIsAliveParsed = bool.TryParse(columns[isAlivePosition], out bool isAlive);

                if (columns[isAlivePosition] == "1")
                {
                    isAlive = true;
                    isIsAliveParsed = true;
                }

                if (isAgeParsed && isAgeParsed)
                {
                    users.Add(new UserModel
                    {
                        FirstName = columns[firstNamePosition],
                        LastName = columns[lastNamePosition],
                        Age = age,
                        IsAlive = isAlive
                    });
                }
                else
                {
                    throw new InvalidDataException();
                }
            }

        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            users.Add(new UserModel
            {
                FirstName = firstNameText.Text,
                LastName = lastNameText.Text,
                Age = (int)agePicker.Value,
                IsAlive = isAliveCheckbox.Checked
            });
            firstNameText.Text = "";
            lastNameText.Text = "";
            agePicker.Value = 0;
            isAliveCheckbox.Checked = false;
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            List<string> parts = new List<string>();

            int howManyColumns = 4;
            string line = "";

            for (int i = 0; i < howManyColumns; i++)
            {
                
                if (firstNamePosition == i) line += "FirstName";
                else if (lastNamePosition == i) line += "LastName";
                else if (agePosition == i) line += "Age";
                else if (isAlivePosition == i) line += "IsAlive";

                if (i != howManyColumns - 1) line += ",";
            }

            parts.Add(line);

            foreach (UserModel user in users)
            {
                line = "";

                for (int i = 0; i < howManyColumns; i++)
                {
                    if (firstNamePosition == i) line += user.FirstName;
                    else if (lastNamePosition == i) line += user.LastName;
                    else if (agePosition == i) line += user.Age;
                    else if (isAlivePosition == i) line += user.IsAlive;

                    if (i != howManyColumns - 1) line += ",";
                }
                parts.Add(line);
            }

            File.WriteAllLines(filePath, parts);

            MessageBox.Show("Data has been saved.");
        }
    }
}

