// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.ETC1
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Drawing;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class ETC1
  {
    private static readonly int[,] ETC1Modifiers = new int[8, 2]
    {
      {
        2,
        8
      },
      {
        5,
        17
      },
      {
        9,
        29
      },
      {
        13,
        42
      },
      {
        18,
        60
      },
      {
        24,
        80
      },
      {
        33,
        106
      },
      {
        47,
        183
      }
    };

    private static int GenModifier(out Color BaseColor, Color[] Pixels)
    {
      Color color1 = Color.White;
      Color color2 = Color.Black;
      int num1 = int.MaxValue;
      int num2 = int.MinValue;
      for (int index = 0; index < 8; ++index)
      {
        if ((int) Pixels[index].A != 0)
        {
          int num3 = ((int) Pixels[index].R + (int) Pixels[index].G + (int) Pixels[index].B) / 3;
          if (num3 > num2)
          {
            num2 = num3;
            color1 = Pixels[index];
          }
          if (num3 < num1)
          {
            num1 = num3;
            color2 = Pixels[index];
          }
        }
      }
      int num4 = ((int) color1.R - (int) color2.R + ((int) color1.G - (int) color2.G) + ((int) color1.B - (int) color2.B)) / 3;
      int num5 = int.MaxValue;
      int index1 = -1;
      int num6 = -1;
      for (int index2 = 0; index2 < 8; ++index2)
      {
        int num3 = ETC1.ETC1Modifiers[index2, 0] * 2;
        int num7 = ETC1.ETC1Modifiers[index2, 0] + ETC1.ETC1Modifiers[index2, 1];
        int num8 = ETC1.ETC1Modifiers[index2, 1] * 2;
        if (num3 > (int) byte.MaxValue)
          num3 = (int) byte.MaxValue;
        if (num7 > (int) byte.MaxValue)
          num7 = (int) byte.MaxValue;
        if (num8 > (int) byte.MaxValue)
          num8 = (int) byte.MaxValue;
        if (Math.Abs(num4 - num3) < num5)
        {
          num5 = Math.Abs(num4 - num3);
          index1 = index2;
          num6 = 0;
        }
        if (Math.Abs(num4 - num7) < num5)
        {
          num5 = Math.Abs(num4 - num7);
          index1 = index2;
          num6 = 1;
        }
        if (Math.Abs(num4 - num8) < num5)
        {
          num5 = Math.Abs(num4 - num8);
          index1 = index2;
          num6 = 2;
        }
      }
      if (num6 == 1)
      {
        float num3 = (float) ETC1.ETC1Modifiers[index1, 0] / (float) ETC1.ETC1Modifiers[index1, 1];
        float num7 = 1f - num3;
        BaseColor = Color.FromArgb((int) ((double) color2.R * (double) num3 + (double) color1.R * (double) num7), (int) ((double) color2.G * (double) num3 + (double) color1.G * (double) num7), (int) ((double) color2.B * (double) num3 + (double) color1.B * (double) num7));
      }
      else
        BaseColor = Color.FromArgb(((int) color2.R + (int) color1.R) / 2, ((int) color2.G + (int) color1.G) / 2, ((int) color2.B + (int) color1.B) / 2);
      return index1;
    }

    private static ulong GenHorizontal(Color[] Colors)
    {
      ulong Data = 0UL;
      ETC1.SetFlipMode(ref Data, false);
      Color[] leftColors = ETC1.GetLeftColors(Colors);
      Color BaseColor1;
      int num1 = ETC1.GenModifier(out BaseColor1, leftColors);
      ETC1.SetTable1(ref Data, num1);
      ETC1.GenPixDiff(ref Data, leftColors, BaseColor1, num1, 0, 2, 0, 4);
      Color[] rightColors = ETC1.GetRightColors(Colors);
      Color BaseColor2;
      int num2 = ETC1.GenModifier(out BaseColor2, rightColors);
      ETC1.SetTable2(ref Data, num2);
      ETC1.GenPixDiff(ref Data, rightColors, BaseColor2, num2, 2, 4, 0, 4);
      ETC1.SetBaseColors(ref Data, BaseColor1, BaseColor2);
      return Data;
    }

    private static ulong GenVertical(Color[] Colors)
    {
      ulong Data = 0UL;
      ETC1.SetFlipMode(ref Data, true);
      Color[] topColors = ETC1.GetTopColors(Colors);
      Color BaseColor1;
      int num1 = ETC1.GenModifier(out BaseColor1, topColors);
      ETC1.SetTable1(ref Data, num1);
      ETC1.GenPixDiff(ref Data, topColors, BaseColor1, num1, 0, 4, 0, 2);
      Color[] bottomColors = ETC1.GetBottomColors(Colors);
      Color BaseColor2;
      int num2 = ETC1.GenModifier(out BaseColor2, bottomColors);
      ETC1.SetTable2(ref Data, num2);
      ETC1.GenPixDiff(ref Data, bottomColors, BaseColor2, num2, 0, 4, 2, 4);
      ETC1.SetBaseColors(ref Data, BaseColor1, BaseColor2);
      return Data;
    }

    private static int GetScore(Color[] Original, Color[] Encode)
    {
      int num = 0;
      for (int index = 0; index < 16; ++index)
        num = num + Math.Abs((int) Encode[index].R - (int) Original[index].R) + Math.Abs((int) Encode[index].G - (int) Original[index].G) + Math.Abs((int) Encode[index].B - (int) Original[index].B);
      return num;
    }

    public static ulong GenETC1(Color[] Colors)
    {
      ulong Data1 = ETC1.GenHorizontal(Colors);
      ulong Data2 = ETC1.GenVertical(Colors);
      if (ETC1.GetScore(Colors, ETC1.DecodeETC1(Data1, ulong.MaxValue)) >= ETC1.GetScore(Colors, ETC1.DecodeETC1(Data2, ulong.MaxValue)))
        return Data2;
      return Data1;
    }

    private static void GenPixDiff(ref ulong Data, Color[] Pixels, Color BaseColor, int Modifier, int XOffs, int XEnd, int YOffs, int YEnd)
    {
      int num1 = ((int) BaseColor.R + (int) BaseColor.G + (int) BaseColor.B) / 3;
      int index1 = 0;
      for (int index2 = YOffs; index2 < YEnd; ++index2)
      {
        for (int index3 = XOffs; index3 < XEnd; ++index3)
        {
          int num2 = ((int) Pixels[index1].R + (int) Pixels[index1].G + (int) Pixels[index1].B) / 3 - num1;
          int num3 = 0;
          if (num2 < num3)
            Data = Data | (ulong) (1L << index3 * 4 + index2 + 16);
          int num4 = Math.Abs(num2) - ETC1.ETC1Modifiers[Modifier, 0];
          if (Math.Abs(Math.Abs(num2) - ETC1.ETC1Modifiers[Modifier, 1]) < Math.Abs(num4))
            Data = Data | (ulong) (1L << index3 * 4 + index2);
          ++index1;
        }
      }
    }

    private static Color[] GetLeftColors(Color[] Pixels)
    {
      Color[] colorArray = new Color[8];
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 2; ++index2)
          colorArray[index1 * 2 + index2] = Pixels[index1 * 4 + index2];
      }
      return colorArray;
    }

    private static Color[] GetRightColors(Color[] Pixels)
    {
      Color[] colorArray = new Color[8];
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 2; index2 < 4; ++index2)
          colorArray[index1 * 2 + index2 - 2] = Pixels[index1 * 4 + index2];
      }
      return colorArray;
    }

    private static Color[] GetTopColors(Color[] Pixels)
    {
      Color[] colorArray = new Color[8];
      for (int index1 = 0; index1 < 2; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
          colorArray[index1 * 4 + index2] = Pixels[index1 * 4 + index2];
      }
      return colorArray;
    }

    private static Color[] GetBottomColors(Color[] Pixels)
    {
      Color[] colorArray = new Color[8];
      for (int index1 = 2; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
          colorArray[(index1 - 2) * 4 + index2] = Pixels[index1 * 4 + index2];
      }
      return colorArray;
    }

    private static void SetFlipMode(ref ulong Data, bool Mode)
    {
      Data = Data & 18446744069414584319UL;
      Data = Data | (ulong) ((Mode ? 1L : 0L) << 32);
    }

    private static void SetDiffMode(ref ulong Data, bool Mode)
    {
      Data = Data & 18446744065119617023UL;
      Data = Data | (ulong) ((Mode ? 1L : 0L) << 33);
    }

    private static void SetTable1(ref ulong Data, int Table)
    {
      Data = Data & 18446743111636877311UL;
      Data = Data | (ulong) (Table & 7) << 37;
    }

    private static void SetTable2(ref ulong Data, int Table)
    {
      Data = Data & 18446743953450467327UL;
      Data = Data | (ulong) (Table & 7) << 34;
    }

    private static void SetBaseColors(ref ulong Data, Color Color1, Color Color2)
    {
      int num1 = (int) Color1.R;
      int num2 = (int) Color1.G;
      int num3 = (int) Color1.B;
      int num4 = (int) Color2.R;
      int num5 = (int) Color2.G;
      int num6 = (int) Color2.B;
      int num7 = (num4 - num1) / 8;
      int num8 = (num5 - num2) / 8;
      int num9 = (num6 - num3) / 8;
      if (num7 > -4 && num7 < 3 && (num8 > -4 && num8 < 3) && (num9 > -4 && num9 < 3))
      {
        ETC1.SetDiffMode(ref Data, true);
        int num10 = num1 / 8;
        int num11 = num2 / 8;
        int num12 = num3 / 8;
        Data = Data | (ulong) num10 << 59;
        Data = Data | (ulong) num11 << 51;
        Data = Data | (ulong) num12 << 43;
        Data = Data | (ulong) (num7 & 7) << 56;
        Data = Data | (ulong) (num8 & 7) << 48;
        Data = Data | (ulong) (num9 & 7) << 40;
      }
      else
      {
        Data = Data | (ulong) (num1 / 17) << 60;
        Data = Data | (ulong) (num2 / 17) << 52;
        Data = Data | (ulong) (num3 / 17) << 44;
        Data = Data | (ulong) (num4 / 17) << 56;
        Data = Data | (ulong) (num5 / 17) << 48;
        Data = Data | (ulong) (num6 / 17) << 40;
      }
    }

    public static Color[] DecodeETC1(ulong Data, ulong Alpha = 18446744073709551615UL)
    {
      Color[] colorArray = new Color[16];
      int num1 = ((long) (Data >> 33) & 1L) == 1L ? 1 : 0;
      bool flag1 = ((long) (Data >> 32) & 1L) == 1L;
      int num2;
      int num3;
      int num4;
      int num5;
      int num6;
      int num7;
      if (num1 != 0)
      {
        int num8 = (int) ((long) (Data >> 59) & 31L);
        int num9 = (int) ((long) (Data >> 51) & 31L);
        int num10 = (int) ((long) (Data >> 43) & 31L);
        num2 = num8 << 3 | (num8 & 28) >> 2;
        num3 = num9 << 3 | (num9 & 28) >> 2;
        num4 = num10 << 3 | (num10 & 28) >> 2;
        int num11 = num8 + ((int) ((long) (Data >> 56) & 7L) << 29 >> 29);
        int num12 = num9 + ((int) ((long) (Data >> 48) & 7L) << 29 >> 29);
        int num13 = num10 + ((int) ((long) (Data >> 40) & 7L) << 29 >> 29);
        num5 = num11 << 3 | (num11 & 28) >> 2;
        num6 = num12 << 3 | (num12 & 28) >> 2;
        num7 = num13 << 3 | (num13 & 28) >> 2;
      }
      else
      {
        num2 = (int) ((long) (Data >> 60) & 15L) * 17;
        num3 = (int) ((long) (Data >> 52) & 15L) * 17;
        num4 = (int) ((long) (Data >> 44) & 15L) * 17;
        num5 = (int) ((long) (Data >> 56) & 15L) * 17;
        num6 = (int) ((long) (Data >> 48) & 15L) * 17;
        num7 = (int) ((long) (Data >> 40) & 15L) * 17;
      }
      int index1 = (int) ((long) (Data >> 37) & 7L);
      int index2 = (int) ((long) (Data >> 34) & 7L);
      for (int index3 = 0; index3 < 4; ++index3)
      {
        for (int index4 = 0; index4 < 4; ++index4)
        {
          int index5 = (int) ((long) (Data >> index4 * 4 + index3) & 1L);
          bool flag2 = ((long) (Data >> index4 * 4 + index3 + 16) & 1L) == 1L;
          uint num8;
          if (flag1 && index3 < 2 || !flag1 && index4 < 2)
          {
            int num9 = ETC1.ETC1Modifiers[index1, index5] * (flag2 ? -1 : 1);
            num8 = GFXUtil.ToColorFormat((int) (byte) ((Alpha >> (index4 * 4 + index3) * 4 & 15UL) * 17UL), (int) (byte) ETC1.ColorClamp(num2 + num9), (int) (byte) ETC1.ColorClamp(num3 + num9), (int) (byte) ETC1.ColorClamp(num4 + num9), ColorFormat.ARGB8888);
          }
          else
          {
            int num9 = ETC1.ETC1Modifiers[index2, index5] * (flag2 ? -1 : 1);
            num8 = GFXUtil.ToColorFormat((int) (byte) ((Alpha >> (index4 * 4 + index3) * 4 & 15UL) * 17UL), (int) (byte) ETC1.ColorClamp(num5 + num9), (int) (byte) ETC1.ColorClamp(num6 + num9), (int) (byte) ETC1.ColorClamp(num7 + num9), ColorFormat.ARGB8888);
          }
          colorArray[index3 * 4 + index4] = Color.FromArgb((int) num8);
        }
      }
      return colorArray;
    }

    private static int ColorClamp(int Color)
    {
      if (Color > (int) byte.MaxValue)
        Color = (int) byte.MaxValue;
      if (Color < 0)
        Color = 0;
      return Color;
    }
  }
}
