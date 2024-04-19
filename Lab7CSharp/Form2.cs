using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.TIF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIF";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file. Original error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Bitmap originalImage = new Bitmap(pictureBox.Image);
                Bitmap monochromeImage = MakeMonochrome(originalImage);
                pictureBox.Image = monochromeImage;
            }
            else
            {
                MessageBox.Show("Please load an image first.");
            }
        }

        private Bitmap MakeMonochrome(Bitmap original)
        {
            Bitmap monochrome = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    int grayScale = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    monochrome.SetPixel(x, y, newColor);
                }
            }

            return monochrome;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image.Save(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file. Original error: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }


    }
}
