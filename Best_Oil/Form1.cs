using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Best_Oil
{
    public partial class Form1 : Form
    {
        List<string> names = new List<string> { "A-76", "A-92", "A-95", "Дизель", "Газ", "A-44", "A-80" };
        List<double> prices = new List<double> { 10.40, 24.80, 9.00, 11.00, 3.46, 5.65, 7.15 };
        List<double> prices_for_food = new List<double> { 4.0, 5.40, 7.20, 4.20 };

        int save_last_num = 1;
        double[] arr_for_sum;

        public Form1()
        {

            InitializeComponent();
            comboBox1.DataSource = names;
            textBox3.Text = prices_for_food.ElementAt(0).ToString();
            textBox6.Text = prices_for_food.ElementAt(1).ToString();
            textBox8.Text = prices_for_food.ElementAt(2).ToString();
            textBox10.Text = prices_for_food.ElementAt(3).ToString();
            arr_for_sum = new double[prices_for_food.Count];
            for (int i = 0; i < arr_for_sum.Length; i++)
            {
                arr_for_sum[i] = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Clear();
            textBox11.Text = prices[comboBox1.SelectedIndex].ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.ReadOnly = true;
            textBox1.ReadOnly = false;  
            groupBox5.Text = "До оплати";
            label3.Text = "Грн";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = false;
            groupBox5.Text = "Кількість";
            label3.Text = "Л";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int amount = int.Parse(textBox1.Text);
                label4.Text = (amount * decimal.Parse(textBox11.Text)).ToString();
            }
            else
            {
                label4.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int sum = int.Parse(textBox2.Text);
                float num = sum / float.Parse(textBox11.Text);
                label4.Text = num.ToString();
            }
            else
            {
                label4.Text = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.Clear();
                textBox4.ReadOnly = false;
            }
            else
            {
                double temp = double.Parse(textBox4.Text);
                save_last_num = 0;
                arr_for_sum[0] -= (temp * double.Parse(textBox3.Text));
                textBox4.Text = "0";
                textBox4.ReadOnly = true;
                ShowFoodCost();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                save_last_num = 0;
                int amount = int.Parse(textBox4.Text);
                double money = amount * double.Parse(textBox3.Text);
                save_last_num = amount;
                arr_for_sum[0] = money;
                ShowFoodCost();
            }
            else if (textBox4.Text == "")
            {
                arr_for_sum[0] = (double.Parse(label7.Text) - double.Parse(textBox3.Text)) * save_last_num;
                ShowFoodCost();
            }
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                save_last_num = 0;
                int amount = int.Parse(textBox5.Text);
                double money = amount * double.Parse(textBox6.Text);
                save_last_num = amount;
                arr_for_sum[1] = money;
                ShowFoodCost();
            }
            else if(textBox5.Text == "")
            {
                arr_for_sum[1] = (double.Parse(label7.Text) - double.Parse(textBox6.Text)) * save_last_num;
                ShowFoodCost();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox5.Clear();
                textBox5.ReadOnly = false;
            }
            else
            {
                double temp = double.Parse(textBox5.Text);
                save_last_num = 0;
                arr_for_sum[1] -= (temp * double.Parse(textBox6.Text));
                textBox5.Text = "0";
                textBox5.ReadOnly = true;
                ShowFoodCost();
            }
        }




        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox7.Clear();
                textBox7.ReadOnly = false;
            }
            else
            {
                double temp = double.Parse(textBox7.Text);
                save_last_num = 0;
                arr_for_sum[2] -= (temp * double.Parse(textBox8.Text));
                textBox7.Text = "0";
                textBox7.ReadOnly = true;
                ShowFoodCost();
            }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                save_last_num = 0;
                int amount = int.Parse(textBox7.Text);
                double money = amount * double.Parse(textBox8.Text);
                save_last_num = amount;
                arr_for_sum[2] = money;
                ShowFoodCost();
            }
            else if (textBox5.Text == "")
            {
                arr_for_sum[2] = (double.Parse(label7.Text) - double.Parse(textBox8.Text)) * save_last_num;
                ShowFoodCost();
            }
        }  
            
        

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox9.Clear();
                textBox9.ReadOnly = false;
            }
            else
            {
                double temp = double.Parse(textBox9.Text);
                save_last_num = 0;
                arr_for_sum[3] -= (temp * double.Parse(textBox10.Text));
                textBox9.Text = "0";
                textBox9.ReadOnly = true;
                ShowFoodCost();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                save_last_num = 0;
                int amount = int.Parse(textBox9.Text);
                double money = amount * double.Parse(textBox10.Text);
                save_last_num = amount;
                arr_for_sum[3] = money;
                ShowFoodCost();
            }
            else if (textBox5.Text == "")
            {
                arr_for_sum[3] = (double.Parse(label9.Text) - double.Parse(textBox10.Text)) * save_last_num;
                ShowFoodCost();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox5.Text == "До оплати") 
            {
                label9.Text = Convert.ToString(double.Parse(label4.Text) + double.Parse(label7.Text));
            }
            else
            {
                label9.Text = Convert.ToString(double.Parse(textBox2.Text) + double.Parse(label7.Text));
            }
        } 
        
        void ShowFoodCost()
        {
            label7.Text = "";
            double sum = 0;
            for (int i = 0; i < arr_for_sum.Length; i++)
            {
                sum += arr_for_sum[i];
            }
            label7.Text = sum.ToString();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
