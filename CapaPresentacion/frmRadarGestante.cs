using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmRadarGestante : Form
    {
        public frmRadarGestante()
        {
            InitializeComponent();
        }

        Timer t = new Timer();

        int WIDTH = 300, HEIGHT = 300, HAND = 150;

        int u;
        int cx, cy;

        int x,y;

        int tx, ty, lim = 20;

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        Bitmap bmp;
        Pen p;
        Graphics g;



        private void frmRadarGestante_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(WIDTH, HEIGHT + 1);

            this.BackColor = Color.Black;

            cx = WIDTH / 2;
            cy = HEIGHT / 2;


            u = 0;

            //timer
            t.Interval = 5;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            p = new Pen(Color.Green, 1f);

            g = Graphics.FromImage(bmp);

            int tu = (u - lim) % 360;

            if (u >= 0 && u <= 180)
            {
                x = cx + (int)(HAND * Math.Sin(Math.PI * u / 180));
                y = cy - (int)(HAND * Math.Cos(Math.PI * u / 180));
            }
            else
            {
                x = cx - (int)(HAND * -Math.Sin(Math.PI * u / 180));
                y = cy - (int)(HAND * Math.Cos(Math.PI * u / 180));
            }

            if (tu >= 0 && tu <= 180)
            {
                tx = cx + (int)(HAND * Math.Sin(Math.PI * tu / 180));
                ty = cy - (int)(HAND * Math.Cos(Math.PI * tu / 180));
            }
            else
            {
                tx = cx - (int)(HAND * -Math.Sin(Math.PI * tu / 180));
                ty = cy - (int)(HAND * Math.Cos(Math.PI * tu / 180));
            }

            g.DrawEllipse(p, 0, 0, WIDTH, HEIGHT);
            g.DrawEllipse(p, 80, 80, WIDTH - 160, HEIGHT - 160);

            g.DrawLine(p, new Point(cx, 0), new Point(cx, HEIGHT));
            g.DrawLine(p, new Point(0, cy), new Point(WIDTH, cy));

            g.DrawLine(new Pen(Color.Black, 1f), new Point(cx, cy), new Point(tx, ty));
            g.DrawLine(p, new Point(cx, cy), new Point(x, y));

            pictureBox1.Image = bmp;
            Label nombre = new Label();
            nombre.Text = "Adelmo Ugkum Ampam";
            nombre.Location = new Point(450, 20);
            nombre.ForeColor = Color.Green;
            nombre.BringToFront();
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(nombre);

            p.Dispose();
            g.Dispose();

            u++;

            if (u == 360)
            {
                u = 0;
               
            }
        }
    }
}
