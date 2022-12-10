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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Best_Oil
{
    public partial class AddForm : Form
    {
        string mode, group, name_product, price_product;

        List<string> price_list = new List<string>();
        List<string> names_list = new List<string>();

        public AddForm(string mode, string group, string n = "", string p = "")
        {
            InitializeComponent();
            this.mode = mode;
            this.group = group;
            this.name_product = n;
            this.price_product = p;
            textBox1.Text = name_product;
            textBox2.Text = price_product;
            label3.Visible = false;
            comboBox1.Visible = false;

            if (mode == "E" && group == "Cafe")
            {
                textBox1.Location = new System.Drawing.Point(127, 50);
                label1.Location = new System.Drawing.Point(2, 50);

                textBox2.Location = new System.Drawing.Point(127, 88);
                label2.Location = new System.Drawing.Point(2, 88);

                label3.Visible = true;
                comboBox1.Visible = true;

                using (FileStream fs = new FileStream("load\\product_for_cafe.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        int i = 0;
                        while (!sr.EndOfStream)
                        {
                            if (i % 2 == 0)
                                names_list.Add(sr.ReadLine());
                            else
                                price_list.Add(sr.ReadLine());

                            i++;
                        }
                    }
                }
                comboBox1.DataSource = names_list;
            }
            else if (mode == "D" && group == "Petrol")
            {
                label3.Visible = true;
                comboBox1.Visible = true;

                textBox1.Visible = false;
                label1.Visible = false;
                textBox2.Visible = false;
                label2.Visible = false;

                using (FileStream fs = new FileStream("load\\product_for_petrol.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        int i = 0;
                        while (!sr.EndOfStream)
                        {
                            if (i % 2 == 0)
                                names_list.Add(sr.ReadLine());
                            else
                                price_list.Add(sr.ReadLine());

                            i++;
                        }
                    }
                }
                comboBox1.DataSource = names_list;
            }
            else if (mode == "D" && group == "Cafe")
            {
                label3.Visible = true;
                comboBox1.Visible = true;

                textBox1.Visible = false;
                label1.Visible = false;
                textBox2.Visible = false;
                label2.Visible = false;

                using (FileStream fs = new FileStream("load\\product_for_cafe.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        int i = 0;
                        while (!sr.EndOfStream)
                        {
                            if (i % 2 == 0)
                                names_list.Add(sr.ReadLine());
                            else
                                price_list.Add(sr.ReadLine());

                            i++;
                        }
                    }
                }
                comboBox1.DataSource = names_list;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
            textBox2.Text = price_list[comboBox1.SelectedIndex].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            switch (mode)
            {
                case "A":
                    Add_product();
                    break;

                case "E":
                    Edit_product();
                    break;

                case "D":
                    Delete_product();
                    break;

                default:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }

        }

        void Add_product()
        {
            bool check = true;
            if (group == "Petrol")
            {
                using (FileStream fs = new FileStream("load\\product_for_petrol.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            if (textBox1.Text == sr.ReadLine())
                            {
                                MessageBox.Show("Такий продукт вже існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                check = false;
                                this.DialogResult = DialogResult.Cancel;
                            }
                        }
                    }
                }
                if (check)
                {
                    using (StreamWriter sw = File.AppendText("load\\product_for_petrol.txt"))
                    {
                        sw.WriteLine(textBox1.Text + "\n" + textBox2.Text);
                        this.DialogResult = DialogResult.OK;
                    }
                }

            }
            else if (group == "Cafe")
            {
                using (FileStream fs = new FileStream("load\\product_for_cafe.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            if (textBox1.Text == sr.ReadLine())
                            {
                                MessageBox.Show("Такий продукт вже існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                check = false;
                                this.DialogResult = DialogResult.Cancel;
                            }
                        }
                    }
                }
                if (check)
                {
                    using (StreamWriter sw = File.AppendText("load\\product_for_cafe.txt"))
                    {
                        sw.WriteLine(textBox1.Text + "\n" + textBox2.Text);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        void Edit_product()
        {
            string str = "";
            if (group == "Petrol")
            {
                using (FileStream fs = new FileStream("load\\product_for_petrol.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (name_product == line)
                            {
                                str += textBox1.Text + "\n" + textBox2.Text + "\n";
                                this.DialogResult = DialogResult.Cancel;
                                sr.ReadLine();
                            }
                            else
                            {
                                str += line + "\n";
                            }
                        }
                    }
                }

                using (FileStream fs = new FileStream("load\\product_for_petrol.txt", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sr = new StreamWriter(fs))
                    {
                        sr.Write(str);
                    }
                }
            }
            else if (group == "Cafe")
            {
                using (FileStream fs = new FileStream("load\\product_for_cafe.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (comboBox1.SelectedItem.ToString() == line)
                            {
                                str += textBox1.Text + "\n" + textBox2.Text + "\n";
                                this.DialogResult = DialogResult.OK;
                                sr.ReadLine();
                            }
                            else
                            {
                                str += line + "\n";
                            }
                        }
                    }
                }

                using (FileStream fs = new FileStream("load\\product_for_cafe.txt", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sr = new StreamWriter(fs))
                    {
                        sr.Write(str);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            this.DialogResult = DialogResult.Cancel;
        }


        void Delete_product()
        {
            string delete_name, new_string = "";

            if (group == "Petrol")
            {
                delete_name = comboBox1.SelectedItem.ToString();

                using (FileStream fs = new FileStream("load\\product_for_petrol.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (delete_name == line)
                            {
                                sr.ReadLine();
                                sr.ReadLine();
                            }
                            else
                            {
                                new_string += line + "\n";
                            }
                        }
                    }
                }

                using (FileStream fs = new FileStream("load\\product_for_petrol.txt", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sr = new StreamWriter(fs))
                    {
                        sr.Write(new_string);
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            else if (group == "Cafe")
            {

                delete_name = comboBox1.SelectedItem.ToString();

                using (FileStream fs = new FileStream("load\\product_for_cafe.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (delete_name == line)
                            {
                                sr.ReadLine();
                                sr.ReadLine();
                            }
                            else
                            {
                                new_string += line + "\n";
                            }
                        }
                    }
                }

                using (FileStream fs = new FileStream("load\\product_for_cafe.txt", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sr = new StreamWriter(fs))
                    {
                        sr.Write(new_string);
                    }
                }
            }
        }

    }
}

