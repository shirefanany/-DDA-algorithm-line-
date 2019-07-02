using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace assigment_1
{
    public partial class Form1 : Form
    {
        Bitmap off;
        Timer tt = new Timer();
        public float xs, ys, xe, ye;
        public float dx, dy, m, inv_m;
        public float cx, cy;
        public int dir;
        public int flagrun = 0;
        public bool x_based = true;
        public int spd = 10;
        int iselected = 0;
        //float dx, dy, m, inv_m, cx, cy;
        List<ccal> L_standhero = new List<ccal>();
        List<ccal> L_movehero = new List<ccal>();
        Graphics g;

        int counttick = 0;
       // Timer t = new Timer();

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            // create_movinghero();
            create_standhero();
            DrawDubb();



        }

        void create_standhero()
        {

            Graphics g = this.CreateGraphics();
            ccal pnn = new ccal();

            pnn.xs = 500;
            pnn.ys = 500;

            //   pnn.im = new List<Bitmap>();


            Bitmap pp = new Bitmap("actor1.bmp");
            pp.MakeTransparent(pp.GetPixel(0, 0));
            pnn.pt = pp;


            L_standhero.Add(pnn);


        }
        void create_movinghero()
        {
            Graphics g = this.CreateGraphics();
            ccal pnn = new ccal();
            pnn.xs = L_standhero[0].rcD.X;
            pnn.ys = L_standhero[0].rcD.Y;
            pnn.im = new List<Bitmap>();
            for (int i = 1; i <= 3; i++)
            {
                Bitmap pp = new Bitmap("actor" + (i) + ".bmp");
                pp.MakeTransparent(pp.GetPixel(0, 0));
                pnn.im.Add(pp);
            }



            L_movehero.Add(pnn);
        }
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(Form1_Load);
            this.Paint += new PaintEventHandler(Form1_Paint);

            tt.Tick += new EventHandler(tt_Tick);
            tt.Interval = 10;
           // t.Start();
            tt.Start();

            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }





        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            flagrun = 1;
            for (int i = 0; i < L_standhero.Count; i++)
            {
                L_standhero[i].xs =  L_standhero[i].cx;
                L_standhero[i].ys =  L_standhero[i].cy;
                L_standhero[i].xe = e.X;
                L_standhero[i].ye = e.Y;

                L_standhero[i].Calc();
                
                //L_standhero[i].Calc();
            }

        }



        void tt_Tick(object sender, EventArgs e)
        {

           
            L_standhero[0].MoveStep();

            DrawDubb();
            counttick++;


        }


        void DrawScene(Graphics g2)
        {
            ccal pnn = new ccal();
            Bitmap n = new Bitmap("back.jpg");
            Rectangle rcD = new Rectangle(0, 0, this.ClientSize.Width + 1200, this.ClientSize.Height + 500);
            Rectangle rcS = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            g2.DrawImage(n, rcD, rcS, GraphicsUnit.Pixel);
           
            
                g2.DrawImage(L_standhero[0].pt, L_standhero[0].cx, L_standhero[0].cy);
            
            if (flagrun == 1)
            {
                for (int i = 1; i < L_movehero.Count; i++)
                {
                    int j = L_movehero[i].iframe;
                    g2.DrawImage(L_movehero[i].im[j], L_movehero[i].cx, L_movehero[i].cy);

                }
            }


        }

        void DrawDubb()
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            Graphics g = this.CreateGraphics();
            g.DrawImage(off, 0, 0);

        }
    }
}
