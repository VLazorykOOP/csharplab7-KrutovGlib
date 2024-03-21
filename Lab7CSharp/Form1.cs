using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBoxInput.Text;
            if (!string.IsNullOrEmpty(inputText))
            {
                char[] randomizedChars = inputText.ToCharArray().OrderBy(c => Guid.NewGuid()).ToArray();
                richTextBoxOutput.Text = new string(randomizedChars);
            }
            else
            {
                MessageBox.Show("Please enter some text in the input field.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBoxOutput.Clear();
            string inputText = textBoxInput.Text.ToUpper(); // Переведіть введений текст у верхній регістр для порівняння
            ArrayList newString = new ArrayList();
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'V', 'U', 'W', 'X', 'Y', 'Z' };

            foreach (char letter in alphabet)
            {
                if (!inputText.Contains(letter.ToString()))
                {
                    newString.Add(char.ToLower(letter)); // Переведіть кожну літеру у нижній регістр та додайте до newString
                }
            }

            richTextBoxOutput.AppendText(string.Join("", newString.ToArray())); // Додаємо всі символи у новому рядку
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }
    }
}
