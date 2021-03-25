using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Обработка функции
        double Func(double x)
        {
            double y = Convert.ToDouble(textBox1.Text);
            double d = Convert.ToDouble(textBox2.Text);
            double c;
            double summ = 0;
            if (radioButton1.Checked)
            {
                c = Convert.ToDouble(textBox6.Text);
                summ = ((y * Math.Pow(x, 2)) + (d * x)) + c;
            }
            else
            {
                if (radioButton2.Checked)
                    summ = y + (d / x);
                else
                {
                    if (radioButton3.Checked)
                        summ = y * Math.Sin(d * x);
                    else
                    {
                        if (radioButton4.Checked)
                            summ = y * Math.Pow(x, 2) + (d / x);
                    }
                }
            }
            return summ;
        }
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Находим минимум и максимум функции с метод деления отрезка пополам
            listBox1.Items.Clear();
            listBox1.Items.Insert(0,"Минимум функции:" );
            double a = Convert.ToDouble(textBox3.Text);
            double b = Convert.ToDouble(textBox4.Text);
            double E = Convert.ToDouble(textBox5.Text);
            int k = 1;
            double xm = (a + b) / 2;
            listBox1.Items.Insert(1, 1 + " итерация: " + "    x = " + xm + ";    f(x) = " + Func(xm) + "; \n");
            double L = b - a;
            double x1, x2;
            do
            {
                x1 = a + (L / 4);
                x2 = b - (L / 4);
                if (Func(x1) < Func(xm))
                {
                    b = xm;
                    xm = (a + b) / 2;

                }
                else
                {
                    if (Func(x1) >= Func(xm))
                    {
                        if (Func(xm) > Func(x2))
                        {
                            a = xm;
                            xm = (a + b) / 2;
                        }
                        else
                        {
                            if (Func(xm) <= Func(x2))
                            {
                                b = x2;
                                a = x1;
                                xm = (a + b) / 2;
                            }
                        }
                    }
                    k += 1;
                    listBox1.Items.Insert(k, k + " итерация: " + "    x = " + xm + ";    f(x) = " + Func(xm) + "; \n");
                }
                L = b - a;
            }
            while (Math.Abs(L) >= E);
            a = Convert.ToDouble(textBox3.Text);
            b = Convert.ToDouble(textBox4.Text);
            E = Convert.ToDouble(textBox5.Text);
            k = 1;
            xm = (a + b) / 2;
            listBox2.Items.Clear();
            listBox2.Items.Insert(0, "Максимум функции:");
            listBox2.Items.Insert(1, 1 + " итерация: " + "    x = " + xm + ";    f(x) = " + Func(xm) + "; \n");
            L = b - a;
            do
            {
                x1 = a + (L / 4);
                x2 = b - (L / 4);
                if (Func(x1) > Func(xm))
                {
                    a = xm;
                    xm = (a + b) / 2;

                }
                else
                {
                      if (Func(x1) <= Func(xm))
                    {
                        if (Func(xm) < Func(x2))
                        {
                            a = xm;
                            xm = (a + b) / 2;
                        }
                        else
                        {
                            if (Func(xm) >= Func(x2))
                            {
                                b = x2;
                                a = x1;
                                xm = (a + b) / 2;
                            }
                        }

                        k += 1;
                        listBox2.Items.Insert(k, k + " итерация: " + "    x = " + xm + ";    f(x) = " + Func(xm) + "; \n");
                    }
                }
                L = b - a;
            } while (Math.Abs(L) >= E);
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Enabled = true;
        }

        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Enabled = false;
        }

        private void radioButton4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Enabled = false;
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Enabled = false;
        }

        //Метод фибоначчи
        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox3.Items.Insert(0, "Минимум функции:");
            double a = Convert.ToDouble(textBox9.Text);
            double b = Convert.ToDouble(textBox7.Text);
            double E = Convert.ToDouble(textBox8.Text);
            int n = Convert.ToInt32(textBox16.Text);
            int k = 1;
            double x1, x2, L2, L;
            ////////////////////Числа фибоначчи//////////////////////////
            double[] F = new double[n + 1];
            F[1] = 1;
            F[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                F[i] = F[i - 1] + F[i - 2];
            }
            //////////////////////////////////////////////////////////////
            L = b - a;
            L2 = (F[n - 1] / F[n] * L) + (Math.Pow(-1, n) * E / F[n]);
            x2 = a + L2;
            for (int i = n; i >= 1; i--)
            {

                x1 = a + (b - x2);
                if (x1 < x2 & Func(x1) < Func(x2))
                {
                    b = x2;
                    x2 = x1;
                    //xm = (a + b) / 2;
                    listBox3.Items.Insert(k, k + " итерация: " + "    x = " + x2 + ";    f(x) = " + Func(x2) + "; \n");
                }
                else
                {
                    if (x1 > x2 & Func(x1) < Func(x2))
                    {
                        a = x2;
                        x2 = x1;
                        listBox3.Items.Insert(k, k + " итерация: " + "    x = " + x2 + ";    f(x) = " + Func(x2) + "; \n");
                    }
                    else
                    {
                        if (x1 < x2 & Func(x1) >= Func(x2))
                        {
                            a = x1;
                            listBox3.Items.Insert(k, k + " итерация: " + "    x = " + x1 + ";    f(x) = " + Func(x1) + "; \n");
                        }
                        else
                        {
                            if (x1 > x2 & Func(x1) >= Func(x2))
                            {
                                b = x1;
                                listBox3.Items.Insert(k, k + " итерация: " + "    x = " + x2 + ";    f(x) = " + Func(x2) + "; \n");
                            }
                        }
                    }
                }
                k++;
            }

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            listBox5.Items.Insert(0, "Минимум функции:");
            double a = Convert.ToDouble(textBox12.Text);
            double b = Convert.ToDouble(textBox10.Text);
            double E = Convert.ToDouble(textBox11.Text);
            int k = 1;
            double tau = (1 + Math.Sqrt(5)) / 2;
            double L = b - a;
            double x1, x2, xm;
            x1 = a + (((3 - Math.Sqrt(5)) / 2) * L);
            x2 = a + b - x1;
            do
            {
                if (Func(x1) <= Func(x2))
                {
                    b = x2;
                    x2 = x1;
                    x1 = a + b - x2;
                }
                else
                {
                    if (Func(x1) > Func(x2))
                    {
                        a = x1;
                        x1 = x2;
                        x2 = a + b - x1;

                    }
                }
                xm = (a + b) / 2;
                listBox5.Items.Insert(k, k + " итерация: " + "    x = " + xm + ";    f(x) = " + Func(xm) + "; \n");
                k++;
            }
            while (Math.Abs(b - a) >= E);
        }

        //находим мин x,y;
        public struct XYmin
        {
            public double yMin;
            public double xMin;
        }
        public static XYmin Minxy(double y1, double x1, double y2, double x2, double y3, double x3)
        {
            XYmin xYmin;
            double ymin = y1;
            double xmin = x1;
            if (ymin > y2)
            {
                ymin = y2;
                xmin = x2;
                if (ymin > y3)
                {
                    ymin = y3;
                    xmin = x3;
                }
            }
            else
            {
                if (ymin > y3)
                {
                    ymin = y3;
                    xmin = x3;
                }
            }
            xYmin.xMin = xmin;
            xYmin.yMin = ymin;
            return xYmin;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listBox7.Items.Clear();
            listBox7.Items.Insert(0, "Минимум функции:");
            double E1 = Convert.ToDouble(textBox14.Text);
            double E2 = Convert.ToDouble(textBox17.Text);
            double x1 = Convert.ToDouble(textBox19.Text);
            double detX = Convert.ToDouble(textBox18.Text);
            XYmin Fmin = new XYmin();
            double xi,xi1,xi2,x2, x3 = 0, y1, y2, y3;
            int k = 1;
            //шаг 2
            x2 = x1 + detX;
            //шаг 3
            y1 = Func(x1);
            y2 = Func(x2);
            //шаг 4
            if (Func(x1) > Func(x2))
            {
                x3 = x1 + 2 * detX;
            }
            else
            {
                if (Func(x1) <= Func(x2))
                {
                    x3 = x1 - detX;
                }
            }
            //шаг 5
            y3 = Func(x3);
            do
            {
                //шаг 6
                Fmin = Minxy(y1, x1, y2, x2, y3, x3);
                //шаг 7
                xi1 = ((Math.Pow(x2, 2) - Math.Pow(x3, 2)) * y1 + (Math.Pow(x3, 2) - Math.Pow(x1, 2)) * y2 + (Math.Pow(x1, 2) - Math.Pow(x2, 2)) * y3);
                xi2 = ((x2 - x3) * y1 + (x3 - x1) * y2 + (x1 - x2) * y3);
                xi = 0.5 * (xi1 / xi2);
                //шаг 8
                listBox7.Items.Insert(k, k + " итерация: " + "    x = " + xi + ";    f(x) = " + Func(xi) + "; \n");
                if (Math.Abs((Fmin.yMin - Func(xi)) / Func(xi)) > E1 & Math.Abs((Fmin.xMin - xi) / xi) > E2)
                {
                    if (x1 <= xi & xi <= x3)
                    {
                        if (xi < Fmin.xMin)
                        {
                            x3 = x2;
                            x2 = xi;
                            y1 = Func(x1);
                            y2 = Func(x2);
                            y3 = Func(x3);
                        }
                        else
                        {
                            if (xi >= Fmin.xMin)
                            {
                                x3 = x2;
                                x2 = Fmin.xMin;
                                y1 = Func(x1);
                                y2 = Func(x2);
                                y3 = Func(x3);
                            }
                        }
                    }
                    else
                    {
                        x1 = xi;
                        //шаг 2
                        x2 = x1 + detX;
                        //шаг 3
                        y1 = Func(x1);
                        y2 = Func(x2);
                        //шаг 4
                        if (Func(x1) > Func(x2))
                        {
                            x3 = x1 + 2 * detX;
                        }
                        else
                        {
                            if (Func(x1) <= Func(x2))
                            {
                                x3 = x1 - detX;
                            }
                        }
                        //шаг 5
                        y3 = Func(x3);
                    }
                }
                k++;
            }
            while (Math.Abs((Fmin.yMin - Func(xi)) / Func(xi)) > E1 & Math.Abs((Fmin.xMin - xi) / xi) > E2);
        }

        private void textBox18_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedIndex == tabControl1.TabCount - 1)
            {
                label18.Visible = true;
                textBox18.Visible = true;
                label19.Visible = true;
                textBox19.Visible = true;
            }
            else
            {
                label18.Visible = false;
                textBox18.Visible = false;
                label19.Visible = false;
                textBox19.Visible = false;
            }
        }

        /*else
{
label13.Visible = true;
label13.Text = "Значение не найдено";
}*/
        //}
    }
}
