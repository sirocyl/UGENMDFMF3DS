// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.GFXUtil
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class GFXUtil
  {
    public static Bitmap Resize(Bitmap Original, int Width, int Height)
    {
      if (Original.Width == Width && Original.Height == Height)
        return Original;
      Bitmap bitmap = new Bitmap(Width, Height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.DrawImage((Image) Original, 0, 0, Width, Height);
        graphics.Flush();
      }
      return bitmap;
    }

    public static uint ConvertColorFormat(uint InColor, ColorFormat InputFormat, ColorFormat OutputFormat)
    {
      if (InputFormat == OutputFormat)
        return InColor;
      uint A;
      if (InputFormat.ASize == 0)
      {
        A = (uint) byte.MaxValue;
      }
      else
      {
        uint num = (uint) ~(-1 << InputFormat.ASize);
        A = ((uint) (((int) (InColor >> InputFormat.AShift) & (int) num) * (int) byte.MaxValue) + num / 2U) / num;
      }
      uint num1 = (uint) ~(-1 << InputFormat.RSize);
      uint R = ((uint) (((int) (InColor >> InputFormat.RShift) & (int) num1) * (int) byte.MaxValue) + num1 / 2U) / num1;
      uint num2 = (uint) ~(-1 << InputFormat.GSize);
      uint G = ((uint) (((int) (InColor >> InputFormat.GShift) & (int) num2) * (int) byte.MaxValue) + num2 / 2U) / num2;
      uint num3 = (uint) ~(-1 << InputFormat.BSize);
      uint B = ((uint) (((int) (InColor >> InputFormat.BShift) & (int) num3) * (int) byte.MaxValue) + num3 / 2U) / num3;
      return GFXUtil.ToColorFormat(A, R, G, B, OutputFormat);
    }

    public static uint ToColorFormat(int R, int G, int B, ColorFormat OutputFormat)
    {
      return GFXUtil.ToColorFormat((uint) byte.MaxValue, (uint) R, (uint) G, (uint) B, OutputFormat);
    }

    public static uint ToColorFormat(int A, int R, int G, int B, ColorFormat OutputFormat)
    {
      return GFXUtil.ToColorFormat((uint) A, (uint) R, (uint) G, (uint) B, OutputFormat);
    }

    public static uint ToColorFormat(uint R, uint G, uint B, ColorFormat OutputFormat)
    {
      return GFXUtil.ToColorFormat((uint) byte.MaxValue, R, G, B, OutputFormat);
    }

    public static uint ToColorFormat(uint A, uint R, uint G, uint B, ColorFormat OutputFormat)
    {
      uint num1 = 0U;
      if (OutputFormat.ASize != 0)
      {
        uint num2 = (uint) ~(-1 << OutputFormat.ASize);
        num1 |= (uint) ((int) A * (int) num2 + (int) sbyte.MaxValue) / (uint) byte.MaxValue << OutputFormat.AShift;
      }
      uint num3 = (uint) ~(-1 << OutputFormat.RSize);
      uint num4 = num1 | (uint) ((int) R * (int) num3 + (int) sbyte.MaxValue) / (uint) byte.MaxValue << OutputFormat.RShift;
      uint num5 = (uint) ~(-1 << OutputFormat.GSize);
      uint num6 = num4 | (uint) ((int) G * (int) num5 + (int) sbyte.MaxValue) / (uint) byte.MaxValue << OutputFormat.GShift;
      uint num7 = (uint) ~(-1 << OutputFormat.BSize);
      return num6 | (uint) ((int) B * (int) num7 + (int) sbyte.MaxValue) / (uint) byte.MaxValue << OutputFormat.BShift;
    }
  }
}
