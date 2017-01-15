// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.YLScsDrawing.Geometry.Vector
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Drawing;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.YLScsDrawing.Geometry
{
  public struct Vector
  {
    private double _x;
    private double _y;

    public double X
    {
      get
      {
        return this._x;
      }
      set
      {
        this._x = value;
      }
    }

    public double Y
    {
      get
      {
        return this._y;
      }
      set
      {
        this._y = value;
      }
    }

    public double Magnitude
    {
      get
      {
        return Math.Sqrt(this.X * this.X + this.Y * this.Y);
      }
    }

    public Vector(double x, double y)
    {
      this._x = x;
      this._y = y;
    }

    public Vector(PointF pt)
    {
      this._x = (double) pt.X;
      this._y = (double) pt.Y;
    }

    public Vector(PointF st, PointF end)
    {
      this._x = (double) end.X - (double) st.X;
      this._y = (double) end.Y - (double) st.Y;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
      return new Vector(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static Vector operator -(Vector v1, Vector v2)
    {
      return new Vector(v1.X - v2.X, v1.Y - v2.Y);
    }

    public static Vector operator -(Vector v)
    {
      return new Vector(-v.X, -v.Y);
    }

    public static Vector operator *(double c, Vector v)
    {
      return new Vector(c * v.X, c * v.Y);
    }

    public static Vector operator *(Vector v, double c)
    {
      return new Vector(c * v.X, c * v.Y);
    }

    public static Vector operator /(Vector v, double c)
    {
      return new Vector(v.X / c, v.Y / c);
    }

    public double CrossProduct(Vector v)
    {
      return this._x * v.Y - v.X * this._y;
    }

    public double DotProduct(Vector v)
    {
      return this._x * v.X + this._y * v.Y;
    }

    public static bool IsClockwise(PointF pt1, PointF pt2, PointF pt3)
    {
      return new Vector(pt2, pt1).CrossProduct(new Vector(pt2, pt3)) < 0.0;
    }

    public static bool IsCCW(PointF pt1, PointF pt2, PointF pt3)
    {
      return new Vector(pt2, pt1).CrossProduct(new Vector(pt2, pt3)) > 0.0;
    }

    public static double DistancePointLine(PointF pt, PointF lnA, PointF lnB)
    {
      Vector vector = new Vector(lnA, lnB);
      return Math.Abs(new Vector(lnA, pt).CrossProduct(vector / vector.Magnitude));
    }

    public void Rotate(int Degree)
    {
      double num1 = (double) Degree * Math.PI / 180.0;
      double num2 = Math.Sin(num1);
      double num3 = Math.Cos(num1);
      double num4 = this._x * num3 - this._y * num2;
      double num5 = this._x * num2 + this._y * num3;
      this._x = num4;
      this._y = num5;
    }

    public PointF ToPointF()
    {
      return new PointF((float) this._x, (float) this._y);
    }
  }
}
