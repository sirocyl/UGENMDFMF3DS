// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.YLScsDrawing.Imaging.Filters.FreeTransform
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Drawing;
using Ultimate_GEN_MD_Forwarder_Maker_for_3DS.YLScsDrawing.Geometry;
using Ultimate_GEN_MD_Forwarder_Maker_for_3DS.YLScsDrawing.Imaging;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.YLScsDrawing.Imaging.Filters
{
  public class FreeTransform
  {
    private PointF[] vertex = new PointF[4];
    private ImageData srcCB = new ImageData();
    private Vector AB;
    private Vector BC;
    private Vector CD;
    private Vector DA;
    private Rectangle rect;
    private int srcW;
    private int srcH;
    private bool isBilinear;

    public Bitmap Bitmap
    {
      get
      {
        return this.getTransformedBitmap();
      }
      set
      {
        try
        {
          this.srcCB.FromBitmap(value);
          this.srcH = value.Height;
          this.srcW = value.Width;
        }
        catch
        {
          this.srcW = 0;
          this.srcH = 0;
        }
      }
    }

    public Point ImageLocation
    {
      get
      {
        return this.rect.Location;
      }
      set
      {
        this.rect.Location = value;
      }
    }

    public bool IsBilinearInterpolation
    {
      get
      {
        return this.isBilinear;
      }
      set
      {
        this.isBilinear = value;
      }
    }

    public int ImageWidth
    {
      get
      {
        return this.rect.Width;
      }
    }

    public int ImageHeight
    {
      get
      {
        return this.rect.Height;
      }
    }

    public PointF VertexLeftTop
    {
      get
      {
        return this.vertex[0];
      }
      set
      {
        this.vertex[0] = value;
        this.setVertex();
      }
    }

    public PointF VertexTopRight
    {
      get
      {
        return this.vertex[1];
      }
      set
      {
        this.vertex[1] = value;
        this.setVertex();
      }
    }

    public PointF VertexRightBottom
    {
      get
      {
        return this.vertex[2];
      }
      set
      {
        this.vertex[2] = value;
        this.setVertex();
      }
    }

    public PointF VertexBottomLeft
    {
      get
      {
        return this.vertex[3];
      }
      set
      {
        this.vertex[3] = value;
        this.setVertex();
      }
    }

    public PointF[] FourCorners
    {
      get
      {
        return this.vertex;
      }
      set
      {
        this.vertex = value;
        this.setVertex();
      }
    }

    private void setVertex()
    {
      float val1_1 = float.MaxValue;
      float val1_2 = float.MaxValue;
      float val1_3 = float.MinValue;
      float val1_4 = float.MinValue;
      for (int index = 0; index < 4; ++index)
      {
        val1_3 = Math.Max(val1_3, this.vertex[index].X);
        val1_4 = Math.Max(val1_4, this.vertex[index].Y);
        val1_1 = Math.Min(val1_1, this.vertex[index].X);
        val1_2 = Math.Min(val1_2, this.vertex[index].Y);
      }
      this.rect = new Rectangle((int) val1_1, (int) val1_2, (int) ((double) val1_3 - (double) val1_1), (int) ((double) val1_4 - (double) val1_2));
      this.AB = new Vector(this.vertex[0], this.vertex[1]);
      this.BC = new Vector(this.vertex[1], this.vertex[2]);
      this.CD = new Vector(this.vertex[2], this.vertex[3]);
      this.DA = new Vector(this.vertex[3], this.vertex[0]);
      this.AB = this.AB / this.AB.Magnitude;
      this.BC = this.BC / this.BC.Magnitude;
      this.CD = this.CD / this.CD.Magnitude;
      this.DA = this.DA / this.DA.Magnitude;
    }

    private bool isOnPlaneABCD(PointF pt)
    {
      return !Vector.IsCCW(pt, this.vertex[0], this.vertex[1]) && !Vector.IsCCW(pt, this.vertex[1], this.vertex[2]) && (!Vector.IsCCW(pt, this.vertex[2], this.vertex[3]) && !Vector.IsCCW(pt, this.vertex[3], this.vertex[0]));
    }

    private Bitmap getTransformedBitmap()
    {
      if (this.srcH == 0 || this.srcW == 0)
        return (Bitmap) null;
      ImageData imageData = new ImageData();
      imageData.A = new byte[this.rect.Width, this.rect.Height];
      imageData.B = new byte[this.rect.Width, this.rect.Height];
      imageData.G = new byte[this.rect.Width, this.rect.Height];
      imageData.R = new byte[this.rect.Width, this.rect.Height];
      PointF pointF = new PointF();
      for (int y = 0; y < this.rect.Height; ++y)
      {
        for (int x = 0; x < this.rect.Width; ++x)
        {
          Point point = new Point(x, y);
          point.Offset(this.rect.Location);
          if (this.isOnPlaneABCD((PointF) point))
          {
            Vector vector = new Vector(this.vertex[0], (PointF) point);
            double num1 = Math.Abs(vector.CrossProduct(this.AB));
            vector = new Vector(this.vertex[1], (PointF) point);
            double num2 = Math.Abs(vector.CrossProduct(this.BC));
            vector = new Vector(this.vertex[2], (PointF) point);
            double num3 = Math.Abs(vector.CrossProduct(this.CD));
            vector = new Vector(this.vertex[3], (PointF) point);
            double num4 = Math.Abs(vector.CrossProduct(this.DA));
            pointF.X = (float) this.srcW * (float) (num4 / (num4 + num2));
            pointF.Y = (float) this.srcH * (float) (num1 / (num1 + num3));
            int index1 = (int) pointF.X;
            int index2 = (int) pointF.Y;
            if (index1 >= 0 && index1 < this.srcW && (index2 >= 0 && index2 < this.srcH))
            {
              if (this.isBilinear)
              {
                int index3 = index1 == this.srcW - 1 ? index1 : index1 + 1;
                int index4 = index2 == this.srcH - 1 ? index2 : index2 + 1;
                float num5 = pointF.X - (float) index1;
                if ((double) num5 < 0.0)
                  num5 = 0.0f;
                float num6 = 1f - num5;
                double num7 = 1.0 - (double) num6;
                float num8 = pointF.Y - (float) index2;
                if ((double) num8 < 0.0)
                  num8 = 0.0f;
                float num9 = 1f - num8;
                float num10 = 1f - num9;
                float num11 = num6 * num9;
                float num12 = num6 * num10;
                double num13 = (double) num9;
                float num14 = (float) (num7 * num13);
                double num15 = (double) num10;
                float num16 = (float) (num7 * num15);
                float num17 = (float) ((double) this.srcCB.A[index1, index2] * (double) num11 + (double) this.srcCB.A[index3, index2] * (double) num14 + (double) this.srcCB.A[index1, index4] * (double) num12 + (double) this.srcCB.A[index3, index4] * (double) num16);
                imageData.A[x, y] = (byte) num17;
                float num18 = (float) ((double) this.srcCB.B[index1, index2] * (double) num11 + (double) this.srcCB.B[index3, index2] * (double) num14 + (double) this.srcCB.B[index1, index4] * (double) num12 + (double) this.srcCB.B[index3, index4] * (double) num16);
                imageData.B[x, y] = (byte) num18;
                float num19 = (float) ((double) this.srcCB.G[index1, index2] * (double) num11 + (double) this.srcCB.G[index3, index2] * (double) num14 + (double) this.srcCB.G[index1, index4] * (double) num12 + (double) this.srcCB.G[index3, index4] * (double) num16);
                imageData.G[x, y] = (byte) num19;
                float num20 = (float) ((double) this.srcCB.R[index1, index2] * (double) num11 + (double) this.srcCB.R[index3, index2] * (double) num14 + (double) this.srcCB.R[index1, index4] * (double) num12 + (double) this.srcCB.R[index3, index4] * (double) num16);
                imageData.R[x, y] = (byte) num20;
              }
              else
              {
                imageData.A[x, y] = this.srcCB.A[index1, index2];
                imageData.B[x, y] = this.srcCB.B[index1, index2];
                imageData.G[x, y] = this.srcCB.G[index1, index2];
                imageData.R[x, y] = this.srcCB.R[index1, index2];
              }
            }
          }
        }
      }
      return imageData.ToBitmap();
    }
  }
}
