// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.Utils
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS
{
  internal class Utils
  {
    private static Random random = new Random();
    internal const ushort PROCESSOR_ARCHITECTURE_INTEL = (ushort) 0;
    internal const ushort PROCESSOR_ARCHITECTURE_IA64 = (ushort) 6;
    internal const ushort PROCESSOR_ARCHITECTURE_AMD64 = (ushort) 9;
    internal const ushort PROCESSOR_ARCHITECTURE_UNKNOWN = (ushort) 65535;

    [DllImport("kernel32.dll")]
    internal static extern void GetNativeSystemInfo(ref Utils.SYSTEM_INFO lpSystemInfo);

    [DllImport("kernel32.dll")]
    internal static extern void GetSystemInfo(ref Utils.SYSTEM_INFO lpSystemInfo);

    public static Utils.Platform GetPlatform()
    {
      Utils.SYSTEM_INFO lpSystemInfo = new Utils.SYSTEM_INFO();
      if (Environment.OSVersion.Version.Major > 5 || Environment.OSVersion.Version.Major >= 5 && Environment.OSVersion.Version.Minor >= 1)
        Utils.GetNativeSystemInfo(ref lpSystemInfo);
      else
        Utils.GetSystemInfo(ref lpSystemInfo);
      switch (lpSystemInfo.wProcessorArchitecture)
      {
        case (ushort) 0:
          return Utils.Platform.X86;
        case (ushort) 6:
        case (ushort) 9:
          return Utils.Platform.X64;
        default:
          return Utils.Platform.Unknown;
      }
    }

    public static string GetSubstringByString(string a, string b, string c)
    {
      return c.Substring(c.IndexOf(a) + a.Length, c.IndexOf(b) - c.IndexOf(a) - a.Length);
    }

    public static Bitmap AdjustBrightness(Bitmap Image, int Value)
    {
      float num1 = (float) Value / (float) byte.MaxValue;
      ColorMatrix colorMatrix1 = new ColorMatrix();
      ColorMatrix colorMatrix2 = colorMatrix1;
      float[][] numArray1 = new float[5][];
      int index1 = 0;
      float[] numArray2 = new float[5];
      int index2 = 0;
      double num2 = 1.0;
      numArray2[index2] = (float) num2;
      numArray1[index1] = numArray2;
      int index3 = 1;
      float[] numArray3 = new float[5];
      int index4 = 1;
      double num3 = 1.0;
      numArray3[index4] = (float) num3;
      numArray1[index3] = numArray3;
      int index5 = 2;
      float[] numArray4 = new float[5];
      int index6 = 2;
      double num4 = 1.0;
      numArray4[index6] = (float) num4;
      numArray1[index5] = numArray4;
      int index7 = 3;
      float[] numArray5 = new float[5];
      int index8 = 3;
      double num5 = 1.0;
      numArray5[index8] = (float) num5;
      numArray1[index7] = numArray5;
      int index9 = 4;
      float[] numArray6 = new float[5];
      int index10 = 0;
      double num6 = (double) num1;
      numArray6[index10] = (float) num6;
      int index11 = 1;
      double num7 = (double) num1;
      numArray6[index11] = (float) num7;
      int index12 = 2;
      double num8 = (double) num1;
      numArray6[index12] = (float) num8;
      int index13 = 3;
      double num9 = 1.0;
      numArray6[index13] = (float) num9;
      int index14 = 4;
      double num10 = 1.0;
      numArray6[index14] = (float) num10;
      numArray1[index9] = numArray6;
      colorMatrix2.Matrix = numArray1;
      return colorMatrix1.Apply(Image);
    }

    public static byte[] ReplaceByOffset(byte[] dataToModify, byte[] dataWithReplacer, int startIndex)
    {
      long length = (long) Math.Max(dataToModify.Length, startIndex + dataWithReplacer.Length);
      List<byte> list = new List<byte>();
      for (int index = 0; (long) index < length; ++index)
      {
        if (index < startIndex || index >= startIndex + dataWithReplacer.Length)
          list.Add(dataToModify[index]);
        else
          list.Add(dataWithReplacer[index - startIndex]);
      }
      byte[] numArray = new byte[length];
      return list.ToArray();
    }

    public static byte[] SubArray(byte[] data, long index, long length)
    {
      byte[] numArray = new byte[length];
      Array.Copy((Array) data, index, (Array) numArray, 0L, length);
      return numArray;
    }

    public static byte[] FillWithZeroUntil(byte[] arr, int until)
    {
      byte[] numArray = new byte[until];
      for (int index = 0; index < until; ++index)
        numArray[index] = index >= arr.Length ? (byte) 0 : arr[index];
      return numArray;
    }

    public static byte[] StringToByteArray(string hex)
    {
      if (hex.Length % 2 == 1)
        throw new Exception("The binary key cannot have an odd number of digits");
      byte[] numArray = new byte[hex.Length >> 1];
      for (int index = 0; index < hex.Length >> 1; ++index)
        numArray[index] = (byte) ((Utils.GetHexVal(hex[index << 1]) << 4) + Utils.GetHexVal(hex[(index << 1) + 1]));
      return numArray;
    }

    public static int GetHexVal(char hex)
    {
      int num1 = (int) hex;
      int num2 = 58;
      int num3 = num1 < num2 ? 48 : 55;
      return num1 - num3;
    }

    public static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height, InterpolationMode mode, bool transparency)
    {
      Bitmap bitmap = !transparency ? new Bitmap(width, height, PixelFormat.Format32bppRgb) : new Bitmap(width, height, PixelFormat.Format32bppArgb);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.InterpolationMode = mode;
        graphics.DrawImage((Image) sourceBMP, 0, 0, width, height);
      }
      return bitmap;
    }

    public static Bitmap RemoveTransparency(Bitmap bmp, Color backColor)
    {
      Size size = bmp.Size;
      int width1 = size.Width;
      size = bmp.Size;
      int height1 = size.Height;
      Bitmap bitmap1 = new Bitmap(width1, height1);
      Graphics graphics = Graphics.FromImage((Image) bitmap1);
      Pen pen = new Pen((Brush) new SolidBrush(backColor));
      int x1 = 0;
      int y1 = 0;
      int width2 = bitmap1.Width;
      int height2 = bitmap1.Height;
      graphics.DrawRectangle(pen, x1, y1, width2, height2);
      Bitmap bitmap2 = bmp;
      int x2 = 0;
      int y2 = 0;
      graphics.DrawImage((Image) bitmap2, x2, y2);
      return bitmap1;
    }

    public static Bitmap CropImage(Bitmap source, Rectangle section)
    {
      Bitmap bitmap = new Bitmap(section.Width, section.Height);
      Graphics.FromImage((Image) bitmap).DrawImage((Image) source, 0, 0, section, GraphicsUnit.Pixel);
      return bitmap;
    }

    public static Bitmap ReplaceColor(Bitmap sourceBitmap, Color sourceColor, Color destColor)
    {
      destColor = Color.FromArgb((int) byte.MaxValue, destColor);
      int num = sourceColor.ToArgb();
      Bitmap bitmap = new Bitmap((Image) sourceBitmap);
      for (int x = 0; x < bitmap.Width; ++x)
      {
        for (int y = 0; y < bitmap.Height; ++y)
        {
          if (bitmap.GetPixel(x, y).ToArgb() == num)
            bitmap.SetPixel(x, y, destColor);
        }
      }
      return bitmap;
    }

    public static string RandomString(int length, string chars)
    {
        var rnd = new Random();
        var sb = new StringBuilder();
        for (var i = 0; i < length; i++)
            sb.Append(chars[rnd.Next()%chars.Length]);
        return sb.ToString();
    }

    public static unsafe Bitmap DoApplyMask(Bitmap input, Bitmap mask)
    {
      Bitmap bitmap = new Bitmap(input.Width, input.Height, PixelFormat.Format32bppArgb);
      bitmap.MakeTransparent();
      Rectangle rect = new Rectangle(0, 0, input.Width, input.Height);
      BitmapData bitmapdata1 = mask.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
      BitmapData bitmapdata2 = input.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
      BitmapData bitmapdata3 = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
      for (int index1 = 0; index1 < input.Height; ++index1)
      {
        byte* numPtr1 = (byte*) ((IntPtr) (void*) bitmapdata1.Scan0 + index1 * bitmapdata1.Stride);
        byte* numPtr2 = (byte*) ((IntPtr) (void*) bitmapdata2.Scan0 + index1 * bitmapdata2.Stride);
        byte* numPtr3 = (byte*) ((IntPtr) (void*) bitmapdata3.Scan0 + index1 * bitmapdata3.Stride);
        for (int index2 = 0; index2 < input.Width; ++index2)
        {
          if ((int) numPtr1[4 * index2] == 0)
          {
            numPtr3[4 * index2] = numPtr2[4 * index2];
            numPtr3[4 * index2 + 1] = numPtr2[4 * index2 + 1];
            numPtr3[4 * index2 + 2] = numPtr2[4 * index2 + 2];
            numPtr3[4 * index2 + 3] = byte.MaxValue;
          }
          else
          {
            numPtr3[4 * index2] = (byte) 0;
            numPtr3[4 * index2 + 1] = (byte) 0;
            numPtr3[4 * index2 + 2] = (byte) 0;
            numPtr3[4 * index2 + 3] = (byte) 0;
          }
        }
      }
      mask.UnlockBits(bitmapdata1);
      input.UnlockBits(bitmapdata2);
      bitmap.UnlockBits(bitmapdata3);
      return bitmap;
    }

    public static Bitmap ApplyBlend(Bitmap baseLayer, Bitmap topLayer)
    {
      Bitmap bitmap = new Bitmap(baseLayer.Width, baseLayer.Height);
      for (int x = 0; x < bitmap.Width; ++x)
      {
        for (int y = 0; y < bitmap.Height; ++y)
        {
          Color pixel1 = baseLayer.GetPixel(x, y);
          Color pixel2 = topLayer.GetPixel(x, y);
          bitmap.SetPixel(x, y, Color.FromArgb(Utils.OverlayByte(pixel1.A, pixel2.A), Utils.OverlayByte(pixel1.R, pixel2.R), Utils.OverlayByte(pixel1.G, pixel2.G), Utils.OverlayByte(pixel1.B, pixel2.B)));
        }
      }
      return bitmap;
    }

    private static int OverlayByte(byte a, byte b)
    {
      float num1 = Utils.standar(a);
      float num2 = Utils.standar(b);
      if ((double) num1 <= 0.498039215803146)
        return (int) Utils.destandar(2f * num1 * num2);
      return (int) Utils.destandar((float) (1.0 - 2.0 * (1.0 - (double) num1) * ((double) num1 - (double) num2)));
    }

    private static float standar(byte a)
    {
      return (float) a / (float) byte.MaxValue;
    }

    private static byte destandar(float a)
    {
      return (byte) ((double) a * (double) byte.MaxValue);
    }

    public static Bitmap MergeBitmaps(Bitmap baseBmp, Bitmap topBmp)
    {
      if (baseBmp.Width != topBmp.Width || baseBmp.Height != topBmp.Height)
        throw new NotImplementedException();
      Bitmap bitmap1 = new Bitmap(baseBmp.Width, baseBmp.Height, PixelFormat.Format32bppArgb);
      Graphics graphics = Graphics.FromImage((Image) bitmap1);
      int num = 0;
      graphics.CompositingMode = (CompositingMode) num;
      Bitmap bitmap2 = baseBmp;
      int x1 = 0;
      int y1 = 0;
      graphics.DrawImage((Image) bitmap2, x1, y1);
      Bitmap bitmap3 = topBmp;
      int x2 = 0;
      int y2 = 0;
      graphics.DrawImage((Image) bitmap3, x2, y2);
      return bitmap1;
    }

    public static Bitmap FillColor(Bitmap sourceBitmap, Color destColor, Rectangle sourceRectangle)
    {
      destColor = Color.FromArgb((int) byte.MaxValue, destColor);
      Bitmap bitmap = new Bitmap((Image) sourceBitmap);
      for (int x = sourceRectangle.X; x < sourceRectangle.Width; ++x)
      {
        for (int y = sourceRectangle.Y; y < sourceRectangle.Height; ++y)
          bitmap.SetPixel(x, y, destColor);
      }
      return bitmap;
    }

    public static Bitmap MakeGrayscale3(Bitmap original)
    {
      Bitmap bitmap = new Bitmap(original.Width, original.Height);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      float[][] newColorMatrix1 = new float[5][];
      int index1 = 0;
      float[] numArray1 = new float[5]
      {
        0.3f,
        0.3f,
        0.3f,
        0.0f,
        0.0f
      };
      newColorMatrix1[index1] = numArray1;
      int index2 = 1;
      float[] numArray2 = new float[5]
      {
        0.59f,
        0.59f,
        0.59f,
        0.0f,
        0.0f
      };
      newColorMatrix1[index2] = numArray2;
      int index3 = 2;
      float[] numArray3 = new float[5]
      {
        0.11f,
        0.11f,
        0.11f,
        0.0f,
        0.0f
      };
      newColorMatrix1[index3] = numArray3;
      int index4 = 3;
      float[] numArray4 = new float[5];
      int index5 = 3;
      double num1 = 1.0;
      numArray4[index5] = (float) num1;
      newColorMatrix1[index4] = numArray4;
      int index6 = 4;
      float[] numArray5 = new float[5];
      int index7 = 4;
      double num2 = 1.0;
      numArray5[index7] = (float) num2;
      newColorMatrix1[index6] = numArray5;
      System.Drawing.Imaging.ColorMatrix newColorMatrix2 = new System.Drawing.Imaging.ColorMatrix(newColorMatrix1);
      ImageAttributes imageAttr = new ImageAttributes();
      imageAttr.SetColorMatrix(newColorMatrix2);
      graphics.DrawImage((Image) original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, imageAttr);
      graphics.Dispose();
      return bitmap;
    }

    public static void DeleteDirectory(string target_dir)
    {
      string[] files = Directory.GetFiles(target_dir);
      string[] directories = Directory.GetDirectories(target_dir);
      foreach (string path in files)
      {
        int num = 128;
        File.SetAttributes(path, (FileAttributes) num);
        File.Delete(path);
      }
      foreach (string target_dir1 in directories)
        Utils.DeleteDirectory(target_dir1);
      Directory.Delete(target_dir, false);
    }

    public enum Platform
    {
      X86,
      X64,
      Unknown,
    }

    internal struct SYSTEM_INFO
    {
      public ushort wProcessorArchitecture;
      public ushort wReserved;
      public uint dwPageSize;
      public IntPtr lpMinimumApplicationAddress;
      public IntPtr lpMaximumApplicationAddress;
      public UIntPtr dwActiveProcessorMask;
      public uint dwNumberOfProcessors;
      public uint dwProcessorType;
      public uint dwAllocationGranularity;
      public ushort wProcessorLevel;
      public ushort wProcessorRevision;
    }
  }
}
