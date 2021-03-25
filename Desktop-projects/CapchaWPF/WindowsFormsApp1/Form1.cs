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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int l = 1;
        private Random rand = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            string s1 = textBox2.Text;
            if (l < 3)
            {
                if (s != "admin" & s1 != "admin")
                {
                    MessageBox.Show("Неправильный пароль!");
                    l++;
                }
                else
                {
                    MessageBox.Show("Вы успешо зашли");
                    label3.Visible = false;
                    textBox3.Visible = false;
                }
            }
            else
            {
                label3.Visible = true;
                textBox3.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button1.Enabled = false;
                pictureBox1.Visible = true;
                pictureBox1.Image.Dispose();
                code = "";
                CreateImage();
            }
            
        }

        private void CreateImage()
        {
            string code = GetRandomText();

            Bitmap bitmap = new Bitmap(200, 50, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Yellow);
            Rectangle rect = new Rectangle(0, 0, 200, 50);

            SolidBrush b = new SolidBrush(Color.Black);
            SolidBrush White = new SolidBrush(Color.White);

            int counter = 0;

            g.DrawRectangle(pen, rect);
            g.FillRectangle(b, rect);

            for (int i = 0; i < code.Length; i++)
            {
                g.DrawString(code[i].ToString(), new Font("Georgia", 10 + rand.Next(14, 18)), White, new PointF(10 + counter, 10));
                counter += 20;
            }

            DrawRandomLines(g);

            if (File.Exists("d:/tempimage.bmp"))
            {

                try
                {
                    File.Delete("d:/tempimage.bmp");
                    bitmap.Save("d:/tempimage.bmp");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                bitmap.Save("d:/tempimage.bmp");

            }

            g.Dispose();
            bitmap.Dispose();
            pictureBox1.Image = Image.FromFile("d:/tempimage.bmp");

        }
        private void DrawRandomLines(Graphics g)
        {
            SolidBrush green = new SolidBrush(Color.Green);
            //For Creating Lines on The Captcha
            for (int i = 0; i < 20; i++)
            {
                g.DrawLines(new Pen(green, 2), GetRandomPoints());
            }

        }
        private Point[] GetRandomPoints()
        {
            Point[] points = { new Point(rand.Next(10, 150), rand.Next(10, 150)), new Point(rand.Next(10, 100), rand.Next(10, 100)) };
            return points;
        }

        string code;
        private string GetRandomText()
        {
            StringBuilder randomText = new StringBuilder();

            if (String.IsNullOrEmpty(code))
            {
                string alphabets = "abcdefghijklmnopqrstuvwxyz1234567890";

                Random r = new Random();
                for (int j = 0; j <= 5; j++)
                {

                    randomText.Append(alphabets[r.Next(alphabets.Length)]);
                }

                code = randomText.ToString();
            }

            return code;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == code.ToString())
            {
                MessageBox.Show("Успешно!");
                pictureBox1.Visible = false;
                label3.Visible = false;
                textBox3.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button1.Enabled = true;
                l = 1;
            }
            else
            {
                MessageBox.Show("Неправильная Captcha");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateImage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            code = "";
            CreateImage();
        }
    }
}
