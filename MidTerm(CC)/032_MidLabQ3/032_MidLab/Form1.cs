using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _032_MidLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string GeneratePassword()
        {
            Random random = new Random();
            StringBuilder password = new StringBuilder();

            // Rule (d): Must contain initials of first and last name, which are A and H
            password.Append("AA");

            // Rule (a): At least one uppercase alphabet
            char uppercaseChar = (char)random.Next('A', 'Z' + 1);
            password.Append(uppercaseChar);

            // Rule (b): At least 4 numbers, 2 numbers must be 32
            int[] requiredNumbers = { 3, 2 }; // These numbers represent "32"
            int[] otherNumbers = { 0, 1, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 2; i++)
            {
                int num = requiredNumbers[i];
                password.Append(num);
            }
            for (int i = 0; i < 2; i++)
            {
                int num = otherNumbers[random.Next(otherNumbers.Length)];
                password.Append(num);
            }

            // Rule (c): At least 2 special characters
            string specialChars = "!@#$%^&*()_+";
            for (int i = 0; i < 2; i++)
            {
                char specialChar = specialChars[random.Next(specialChars.Length)];
                password.Append(specialChar);
            }

            // Shuffle the characters in the password for better randomness
            string shuffledPassword = new string(password.ToString().ToCharArray().OrderBy(x => random.Next()).ToArray());

            // Ensure the password length does not exceed 16 characters
            return shuffledPassword.Length <= 16 ? shuffledPassword : shuffledPassword.Substring(0, 16);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string password = GeneratePassword();
            PasswordLabel.Text = password;
        }
    }
}
