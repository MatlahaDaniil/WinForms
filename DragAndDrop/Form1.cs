using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DragAndDrop
{
    public partial class Form1 : Form
    {
        int p = 0, f = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void list_with_money_MouseDown(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ListView listView = sender as System.Windows.Forms.ListView;
            listView.DoDragDrop((ListViewItem)listView.FocusedItem.Clone(), DragDropEffects.Copy);
        }

        private void GetMoneyList_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(ListViewItem)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void GetMoneyList_DragDrop(object sender, DragEventArgs e)
        { 
            ListViewItem item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            GetMoneyList.Items.Add(item);

            result_money(char.Parse(item.Text.Remove(0, item.Text.Length - 1)), int.Parse(item.Text.Remove(item.Text.Length - 1, 1)));
        }

        private void Reset_btn_Click(object sender, EventArgs e)
        {
            GetMoneyList.Clear();
            print_Money_lbl.Text = "0f 0p";
            p = 0;
            f = 0;
        }

        private void GetMoneyList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void result_money(char type , int money)
        {
            if(type == 'p')
            {
                p += money;
                if(p >= 100)
                {
                    f++;
                    p -= 100;
                }
            }
            else
            {
                f += money;
            }

            print_Money_lbl.Text = $"{f} f {p} p";
        }
    }


}

