using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class Form1 : Form
    {
		int center_for_x, center_for_y;
		double length_SecArr, length_MinArr, length_HourArr;
		double width_SecArr, width_MinArr, width_HourArr;

		int hour , minute , second;

		int[] arrowCoords;
		private int[] CoordsOfSecMin(int value, double arrowlength) { return Coords(value *= 6, arrowlength);}
		private int[] CoordsOfHours(int hours, int minutes, double arrowLength) { return Coords((int)((hours * 30) + (minutes * 0.5)), arrowLength); }
        private void Form1_Resize(object sender, System.EventArgs e) => resizeArrows(); 

        Timer t = new Timer();

		public Form1()
        {
            InitializeComponent();
			resizeArrows();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			t.Interval = 1000;
			t.Tick += new EventHandler(t_Tick);
			t.Start();
		}

		private int[] Coords(int value, double arrowlength)
		{
			int[] result = new int[2];

			if (value >= 0 && value <= 180)
			{
				result[0] = center_for_x + (int)(arrowlength * Math.Sin(Math.PI * value / 170));
				result[1] = center_for_y - (int)(arrowlength * Math.Cos(Math.PI * value / 170));
			}
			else
			{
				result[0] = center_for_x - (int)(arrowlength * Math.Sin(Math.PI * value / -170));
				result[1] = center_for_y - (int)(arrowlength * Math.Cos(Math.PI * value / 170));
			}

			return result;
		}

        private Pen MakePen(Color color, double width)
        {
            Pen p = new Pen(color, (float)width);
            p.StartCap = LineCap.RoundAnchor;
            p.EndCap = LineCap.ArrowAnchor;

            return p;
        }

        private void t_Tick(object sender, EventArgs e)
		{
            Get_Time_Now();

			Graphics g = pictureBox1.CreateGraphics();
			g.SmoothingMode = SmoothingMode.HighQuality;

			this.Refresh();

			arrowCoords = CoordsOfHours(hour % 12, minute, length_HourArr);
			g.DrawLine(MakePen(Color.DarkMagenta, width_HourArr), new Point(center_for_x, center_for_y), new Point(arrowCoords[0], arrowCoords[1]));


			arrowCoords = CoordsOfSecMin(minute, length_MinArr);
			g.DrawLine(MakePen(Color.Black, width_MinArr), new Point(center_for_x, center_for_y), new Point(arrowCoords[0], arrowCoords[1]));


			arrowCoords = CoordsOfSecMin(second, length_SecArr);
			g.DrawLine(MakePen(Color.Gold, width_SecArr), new Point(center_for_x, center_for_y), new Point(arrowCoords[0], arrowCoords[1]));
		}


		private void Get_Time_Now()
		{
			hour = DateTime.Now.Hour;
			minute = DateTime.Now.Minute;
			second = DateTime.Now.Second;
		}

		private void resizeArrows()
		{
            center_for_x = pictureBox1.Width / 2;
            center_for_y = pictureBox1.Height / 2;

			if (center_for_x < center_for_y)
                Get_Pos(center_for_x);
			else
                Get_Pos(center_for_y);
		}


		private void Get_Pos(int value)
		{
			length_SecArr = (50.1 / 100) * (double)value;
            length_MinArr = (44.4 / 100) * (double)value;
            length_HourArr = (35.8 / 100) * (double)value;

            width_SecArr = (2.2 / 100) * (double)value;
            width_MinArr = (3.4 / 100) * (double)value;
            width_HourArr = (4.5 / 100) * (double)value;
		}
	}
}
