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

namespace Best_Oil
{
    public partial class Form1 : Form
    {

        List<string> names_for_petrol = new List<string>();
        List<double> prices_for_petrol = new List<double>();

        List<string> namesProduct = new List<string>();
        List<double> pricesProduct = new List<double>();

        List<Product> products = new List<Product>();

        public Form1()
        {

            InitializeComponent();       
            load();


            comboBox1.DataSource = names_for_petrol;


            for (int i = 0; i < namesProduct.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Location = new Point(3, 12 + i * 28);
                checkBox.Text = namesProduct[i];
                checkBox.CheckedChanged += CheckBox_CheckedChanged;

                TextBox textBoxPrice = new TextBox();
                textBoxPrice.Location = new Point(115, 12 + i * 28);
                textBoxPrice.Size = new Size(65, 22);
                textBoxPrice.Text = pricesProduct[i].ToString();
                textBoxPrice.ReadOnly = true;

                NumericUpDown numericUpDownAmount = new NumericUpDown();
                numericUpDownAmount.Location = new Point(200, 12 + i * 28);
                numericUpDownAmount.Size = new Size(70, 16);
                numericUpDownAmount.Minimum = 0;
                numericUpDownAmount.Maximum = 1000;
                numericUpDownAmount.Enabled = false;
                numericUpDownAmount.ValueChanged += NumericUpDownAmount_ValueChanged;

                products.Add(new Product
                {
                    Name = namesProduct[i],
                    Price = (decimal)pricesProduct[i],
                    CheckBox_Enable = checkBox,
                    TextBox_Price = textBoxPrice,
                    Amount = numericUpDownAmount
                });

                panel1.Controls.Add(numericUpDownAmount);
                panel1.Controls.Add(checkBox);
                panel1.Controls.Add(textBoxPrice);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Clear();
            textBox11.Text = prices_for_petrol[comboBox1.SelectedIndex].ToString();
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

        //////////////////////////////////////////////

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].CheckBox_Enable == check)
                {
                    products[i].Amount.Enabled = check.Checked;
                    NumericUpDownAmount_ValueChanged(sender, e);
                    break;
                }
            }
        }

        private void NumericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            decimal SumAll = 0;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].CheckBox_Enable.Checked == true)
                {
                    SumAll += products[i].Price * products[i].Amount.Value;
                }
            }
            label7.Text = String.Format("{0:0.00}", SumAll);
        }

        void load()
        {
            using (FileStream fs = new FileStream("load\\product_for_petrol.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if(i % 2 == 0)
                            {
                                names_for_petrol.Add(sr.ReadLine());
                            }
                            else
                            {
                                prices_for_petrol.Add(double.Parse(sr.ReadLine()));
                            }
                        }
                    }
                }
            }

            using (FileStream fs = new FileStream("load\\product_for_cafe.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (i % 2 == 0)
                            {
                               namesProduct.Add(sr.ReadLine());
                            }
                            else
                            {
                                pricesProduct.Add(double.Parse(sr.ReadLine()));
                            }
                        }
                    }
                }
            }

        }

    }
    

    

    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public CheckBox CheckBox_Enable { get; set; }
        public TextBox TextBox_Price { get; set; }
        public NumericUpDown Amount { get; set; }
    }
}
