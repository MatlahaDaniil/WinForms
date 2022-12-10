namespace DragAndDrop
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("1f", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("2f", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("5f", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("5p", 3);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("10f", 4);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("10p", 5);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("20p", 6);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("50p", 7);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.list_with_money = new System.Windows.Forms.ListView();
            this.GetMoneyList = new System.Windows.Forms.ListView();
            this.print_Money_lbl = new System.Windows.Forms.Label();
            this.Reset_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1f.jpg");
            this.imageList1.Images.SetKeyName(1, "2f.jpg");
            this.imageList1.Images.SetKeyName(2, "5f.jpg");
            this.imageList1.Images.SetKeyName(3, "5p.jpg");
            this.imageList1.Images.SetKeyName(4, "10f.jpg");
            this.imageList1.Images.SetKeyName(5, "10p.jpg");
            this.imageList1.Images.SetKeyName(6, "20p.jpg");
            this.imageList1.Images.SetKeyName(7, "50p.jpg");
            // 
            // list_with_money
            // 
            this.list_with_money.HideSelection = false;
            listViewItem1.Tag = "1";
            listViewItem2.Tag = "2";
            listViewItem3.Tag = "5";
            listViewItem4.Tag = "0.05";
            listViewItem5.Tag = "10";
            listViewItem6.Tag = "0.10";
            listViewItem7.Tag = "0.2";
            listViewItem8.Tag = "0.5";
            this.list_with_money.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.list_with_money.LargeImageList = this.imageList1;
            this.list_with_money.Location = new System.Drawing.Point(12, 78);
            this.list_with_money.Name = "list_with_money";
            this.list_with_money.Size = new System.Drawing.Size(360, 360);
            this.list_with_money.TabIndex = 0;
            this.list_with_money.UseCompatibleStateImageBehavior = false;
            this.list_with_money.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_with_money_MouseDown);
            // 
            // GetMoneyList
            // 
            this.GetMoneyList.AllowDrop = true;
            this.GetMoneyList.HideSelection = false;
            this.GetMoneyList.LargeImageList = this.imageList1;
            this.GetMoneyList.Location = new System.Drawing.Point(378, 78);
            this.GetMoneyList.Name = "GetMoneyList";
            this.GetMoneyList.Size = new System.Drawing.Size(410, 360);
            this.GetMoneyList.TabIndex = 1;
            this.GetMoneyList.UseCompatibleStateImageBehavior = false;
            this.GetMoneyList.SelectedIndexChanged += new System.EventHandler(this.GetMoneyList_SelectedIndexChanged);
            this.GetMoneyList.DragDrop += new System.Windows.Forms.DragEventHandler(this.GetMoneyList_DragDrop);
            this.GetMoneyList.DragEnter += new System.Windows.Forms.DragEventHandler(this.GetMoneyList_DragEnter);
            // 
            // print_Money_lbl
            // 
            this.print_Money_lbl.AutoSize = true;
            this.print_Money_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.print_Money_lbl.Location = new System.Drawing.Point(315, 20);
            this.print_Money_lbl.Name = "print_Money_lbl";
            this.print_Money_lbl.Size = new System.Drawing.Size(136, 55);
            this.print_Money_lbl.TabIndex = 2;
            this.print_Money_lbl.Text = "0f 0p";
            this.print_Money_lbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // Reset_btn
            // 
            this.Reset_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Reset_btn.Location = new System.Drawing.Point(597, 20);
            this.Reset_btn.Name = "Reset_btn";
            this.Reset_btn.Size = new System.Drawing.Size(191, 52);
            this.Reset_btn.TabIndex = 3;
            this.Reset_btn.Text = "Reset";
            this.Reset_btn.UseVisualStyleBackColor = true;
            this.Reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Reset_btn);
            this.Controls.Add(this.print_Money_lbl);
            this.Controls.Add(this.GetMoneyList);
            this.Controls.Add(this.list_with_money);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView list_with_money;
        private System.Windows.Forms.ListView GetMoneyList;
        private System.Windows.Forms.Label print_Money_lbl;
        private System.Windows.Forms.Button Reset_btn;
    }
}

