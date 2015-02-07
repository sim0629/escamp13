using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GmfGame
{
    public class GmfVec
    {
        public float X = 0;
        public float Y = 0;

        public void Normalize()
        {
            float len = Length();
            if (Math.Abs(len) > 0)
            {
                X /= len;
                Y /= len;
            }
        }

        public GmfVec() { }

        public GmfVec(float x, float y)
        {
            X = x; Y = y;
        }

        public GmfVec(GmfVec v)
        {
            X = v.X;
            Y = v.Y;
        }

        public float Length()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public static GmfVec operator -(GmfVec left, GmfVec right)
        {
            GmfVec v = new GmfVec();
            v.X = left.X - right.X;
            v.Y = left.Y - right.Y;
            return v;
        }

        public static GmfVec operator +(GmfVec left, GmfVec right)
        {
            GmfVec v = new GmfVec();
            v.X = left.X + right.X;
            v.Y = left.Y + right.Y;
            return v;
        }

        public static GmfVec operator *(float mult, GmfVec right)
        {
            GmfVec v = new GmfVec();
            v.X = right.X * mult;
            v.Y = right.Y * mult;
            return v;
        }

        public static GmfVec operator *(GmfVec left, float mult)
        {
            GmfVec v = new GmfVec();
            v.X = left.X * mult;
            v.Y = left.Y * mult;
            return v;
        }
        
        public static GmfVec operator /(GmfVec left, float div)
        {
            GmfVec v = new GmfVec();
            v.X = left.X / div;
            v.Y = left.Y / div;
            return v;
        }

        public static implicit operator GmfVec(PointF point)
        {
            GmfVec v = new GmfVec();
            v.X = point.X;
            v.Y = point.Y;
            return v;
        }

        public static implicit operator PointF(GmfVec v)
        {
            PointF p = new PointF();
            p.X = v.X;
            p.Y = v.Y;
            return p;
        }

        public static implicit operator GmfVec(Point point)
        {
            GmfVec v = new GmfVec();
            v.X = point.X;
            v.Y = point.Y;
            return v;
        }

        public static implicit operator Point(GmfVec v)
        {
            Point p = new Point();
            p.X = (int)v.X;
            p.Y = (int)v.Y;
            return p;
        }

        public static implicit operator GmfVec(Size s)
        {
            GmfVec v = new GmfVec();
            v.X = s.Width;
            v.Y = s.Height;
            return v;
        }

        public static implicit operator Size(GmfVec v)
        {
            Size s = new Size((int)v.X, (int)v.Y);
            return s;
        }
    }
}
