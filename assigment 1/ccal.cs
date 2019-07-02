using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;

namespace assigment_1
{
    class ccal
    {
        public float xs, ys, xe, ye;
        public float dx, dy, m, inv_m;
        public float cx, cy;
        public int dir;
        public int spyd = 10;
        public Bitmap n;
        public Rectangle rcD;
        public Rectangle rcS;
        public int flagmove = 0;
        public List<Bitmap> im;
        public Bitmap pt;
        int spd = 10;
        public bool x_based = true;
        public int iframe;


        public void Calc()
        {
            dy = ye - ys;
            dx = xe - xs;
            m = dy / dx;
            cx = xs;
            cy = ys;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                x_based = true;
                if (xs < xe)
                    dir = 1;
                else
                    dir = -1;
            }
            else
            {
                x_based = false;
                if (ys < ye)
                    dir = 1;
                else
                    dir = -1;
            }


        }
        public void isStopX()
        {
            if (dir == 1)
            {
                if (cx > xe)
                {
                    // you finshied your trip
                    float t;
                    t = xs; xs = xe; xe = t;
                    t = ys; ys = ye; ye = t;
                    Calc();
                }
            }
            else
            {
                if (cx < xe)
                {
                    // you finshied your trip
                    float t;
                    t = xs; xs = xe; xe = t;
                    t = ys; ys = ye; ye = t;
                    Calc();
                }
            }
        }
        public void isStopY()
        {
            if (dir == 1)
            {
                if (cy > ye)
                {
                    // you finshied your trip
                    float t;
                    t = xs; xs = xe; xe = t;
                    t = ys; ys = ye; ye = t;
                    Calc();
                }
            }
            else
            {
                if (cy < ye)
                {
                    // you finshied your trip
                    float t;
                    t = xs; xs = xe; xe = t;
                    t = ys; ys = ye; ye = t;
                    Calc();
                }
            }
        }
        public void MoveStep()
        {
            if (x_based)
            {
                cx += dir * spd;
                cy += dir * m * spd;
                isStopX();
            }
            else
            {
                cy += dir * spd;
                cx += dir * (1.0f / m) * spd;
                isStopY();
            }

        }
    }
}
