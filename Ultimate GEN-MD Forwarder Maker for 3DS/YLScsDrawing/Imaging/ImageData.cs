// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.YLScsDrawing.Imaging.ImageData
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.YLScsDrawing.Imaging
{
  public class ImageData : IDisposable
  {
    private byte[,] _red;
    private byte[,] _green;
    private byte[,] _blue;
    private byte[,] _alpha;
    private bool _disposed;

    public byte[,] A
    {
      get
      {
        return this._alpha;
      }
      set
      {
        this._alpha = value;
      }
    }

    public byte[,] B
    {
      get
      {
        return this._blue;
      }
      set
      {
        this._blue = value;
      }
    }

    public byte[,] G
    {
      get
      {
        return this._green;
      }
      set
      {
        this._green = value;
      }
    }

    public byte[,] R
    {
      get
      {
        return this._red;
      }
      set
      {
        this._red = value;
      }
    }

    public ImageData Clone()
    {
      ImageData imageData = new ImageData();
      byte[,] numArray1 = (byte[,]) this._alpha.Clone();
      imageData.A = numArray1;
      byte[,] numArray2 = (byte[,]) this._blue.Clone();
      imageData.B = numArray2;
      byte[,] numArray3 = (byte[,]) this._green.Clone();
      imageData.G = numArray3;
      byte[,] numArray4 = (byte[,]) this._red.Clone();
      imageData.R = numArray4;
      return imageData;
    }

    public void FromBitmap(Bitmap srcBmp)
    {
      int width = srcBmp.Width;
      int height = srcBmp.Height;
      this._alpha = new byte[width, height];
      this._blue = new byte[width, height];
      this._green = new byte[width, height];
      this._red = new byte[width, height];
      BitmapData bitmapdata = srcBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      IntPtr scan0 = bitmapdata.Scan0;
      int length1 = bitmapdata.Stride * srcBmp.Height;
      byte[] numArray = new byte[length1];
      byte[] destination = numArray;
      int startIndex = 0;
      int length2 = length1;
      Marshal.Copy(scan0, destination, startIndex, length2);
      int num = bitmapdata.Stride - width * 4;
      int index1 = 0;
      for (int index2 = 0; index2 < height; ++index2)
      {
        for (int index3 = 0; index3 < width; ++index3)
        {
          this._blue[index3, index2] = numArray[index1];
          this._green[index3, index2] = numArray[index1 + 1];
          this._red[index3, index2] = numArray[index1 + 2];
          this._alpha[index3, index2] = numArray[index1 + 3];
          index1 += 4;
        }
        index1 += num;
      }
      srcBmp.UnlockBits(bitmapdata);
    }

    public Bitmap ToBitmap()
    {
      int num1 = 0;
      int num2 = 0;
      if (this._alpha != null)
      {
        num1 = Math.Max(num1, this._alpha.GetLength(0));
        num2 = Math.Max(num2, this._alpha.GetLength(1));
      }
      if (this._blue != null)
      {
        num1 = Math.Max(num1, this._blue.GetLength(0));
        num2 = Math.Max(num2, this._blue.GetLength(1));
      }
      if (this._green != null)
      {
        num1 = Math.Max(num1, this._green.GetLength(0));
        num2 = Math.Max(num2, this._green.GetLength(1));
      }
      if (this._red != null)
      {
        num1 = Math.Max(num1, this._red.GetLength(0));
        num2 = Math.Max(num2, this._red.GetLength(1));
      }
      Bitmap bitmap = new Bitmap(num1, num2, PixelFormat.Format32bppArgb);
      BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, num1, num2), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = bitmapdata.Stride * bitmap.Height;
      byte[] source = new byte[length];
      int num3 = bitmapdata.Stride - num1 * 4;
      int index = 0;
      for (int y = 0; y < num2; ++y)
      {
        for (int x = 0; x < num1; ++x)
        {
          source[index] = ImageData.checkArray(this._blue, x, y) ? this._blue[x, y] : (byte) 0;
          source[index + 1] = ImageData.checkArray(this._green, x, y) ? this._green[x, y] : (byte) 0;
          source[index + 2] = ImageData.checkArray(this._red, x, y) ? this._red[x, y] : (byte) 0;
          source[index + 3] = ImageData.checkArray(this._alpha, x, y) ? this._alpha[x, y] : byte.MaxValue;
          index += 4;
        }
        index += num3;
      }
      Marshal.Copy(source, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata);
      return bitmap;
    }

    private static bool checkArray(byte[,] array, int x, int y)
    {
      return array != null && x < array.GetLength(0) && y < array.GetLength(1);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this._disposed)
        return;
      if (disposing)
      {
        this._alpha = (byte[,]) null;
        this._blue = (byte[,]) null;
        this._green = (byte[,]) null;
        this._red = (byte[,]) null;
      }
      this._disposed = true;
    }
  }
}
