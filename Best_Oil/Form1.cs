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
using static System.Collections.Specialized.BitVector32;

namespace Best_Oil
{

    public partial class Form1 : Form
    {
        string modeLanguage = "Ua";
        bool admin;
        List<string> names_for_petrol = new List<string>();
        List<double> prices_for_petrol = new List<double>();

        List<string> namesProduct = new List<string>();
        List<double> pricesProduct = new List<double>();

        List<Product> products = new List<Product>();

        public Form1(bool admin = false)
        {
            this.admin = admin;
            
            InitializeComponent();
            load();

            if (admin)
            {
                groupBox3.Visible = false;
                groupBox5.Visible = false;
                groupBox6.Visible = false;
                panel3.Visible = true;
                panel4.Visible = true;
                groupBox4.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;  

                groupBox1.Size = new Size(300, 300);
                groupBox2.Size = new Size(310, 300);
                this.MinimumSize = new Size(700, 350);
                this.Size = new Size(700, 350);
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
            if (modeLanguage == "Ua")
            {
                groupBox5.Text = "До оплати";
                label3.Text = "Грн";
            }
            else if (modeLanguage == "En")
            {
                groupBox5.Text = "Payment";
                label3.Text = "Grn";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = false;

            if (modeLanguage == "Ua")
            {
                groupBox5.Text = "Кількість";
                label3.Text = "Л";
            }
            else if (modeLanguage == "En")
            {
                groupBox5.Text = "Amount";
                label3.Text = "L";
            }
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
            if (groupBox5.Text == "До оплати" || groupBox5.Text == "Payment")
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
            if (admin)
            {
                panel3.Visible = true;
                panel4.Visible = true;
            }
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

        public void load()
        {
            using (FileStream fs = new FileStream("load\\product_for_petrol.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (i % 2 == 0)
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

            comboBox1.DataSource = names_for_petrol;

            panel3.Visible = false;
            panel4.Visible = false;

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

        private void button4_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm("A" , "Petrol");
            addForm.ShowDialog();
            load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm("E" , "Petrol" , comboBox1.SelectedItem.ToString() , textBox11.Text);
            addForm.ShowDialog();
            load();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm("A", "Cafe");
            addForm.ShowDialog();
            load();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm("E", "Cafe");
            addForm.ShowDialog();
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm("D", "Petrol");
            addForm.ShowDialog();
            load();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm("D", "Cafe");
            addForm.ShowDialog();
            load();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modeLanguage = "En";

            SettingsToolStripMenuItem.Text = "Settings";
            LanguageToolStripMenuItem.Text = "Language";
            groupBox1.Text = "Refueling";
            groupBox2.Text = "Mini - Cafe";
            label1.Text = "Petrol";
            label2.Text = "Cost";
            label11.Text = "L";
            label12.Text = "grn";
            groupBox5.Text = "Payment";
            groupBox6.Text = "Payment";

            if (label3.Text == "Грн") label3.Text = "Grn";
            else label3.Text = "L";

            label8.Text = "Grn";
            groupBox3.Text = "Total";
            label10.Text = "Grn";
            button1.Text = "Get sum";
            radioButton1.Text = "Amount";
            radioButton2.Text = "Sum";


        }

        private void UkrainianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modeLanguage = "Ua";

            SettingsToolStripMenuItem.Text = "Налаштування";
            LanguageToolStripMenuItem.Text = "Мова";
            groupBox1.Text = "Заправка";
            groupBox2.Text = "Міні - Кафе";
            label1.Text = "Бензин";
            label2.Text = "Ціна";
            label11.Text = "Л";
            label12.Text = "Грн";
            groupBox5.Text = "До сплати";
            groupBox6.Text = "До сплати";

            if (label3.Text == "Grn") label3.Text = "Грн";
            else label3.Text = "Л";

            label8.Text = "Грн";
            groupBox3.Text = "Всього до сплати";
            label10.Text = "Грн";
            button1.Text = "Розрахувати";
            radioButton1.Text = "Кількість";
            radioButton2.Text = "Сумма";
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

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
