// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.Textures
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Drawing;
using System.Drawing.Imaging;
using Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS
{
  public class Textures
  {
    private static int[] Tile_Order = new int[64]
    {
      0,
      1,
      8,
      9,
      2,
      3,
      10,
      11,
      16,
      17,
      24,
      25,
      18,
      19,
      26,
      27,
      4,
      5,
      12,
      13,
      6,
      7,
      14,
      15,
      20,
      21,
      28,
      29,
      22,
      23,
      30,
      31,
      32,
      33,
      40,
      41,
      34,
      35,
      42,
      43,
      48,
      49,
      56,
      57,
      50,
      51,
      58,
      59,
      36,
      37,
      44,
      45,
      38,
      39,
      46,
      47,
      52,
      53,
      60,
      61,
      54,
      55,
      62,
      63
    };
    private static int[,] Modulation_Table = new int[8, 4]
    {
      {
        2,
        8,
        -2,
        -8
      },
      {
        5,
        17,
        -5,
        -17
      },
      {
        9,
        29,
        -9,
        -29
      },
      {
        13,
        42,
        -13,
        -42
      },
      {
        18,
        60,
        -18,
        -60
      },
      {
        24,
        80,
        -24,
        -80
      },
      {
        33,
        106,
        -33,
        -106
      },
      {
        47,
        183,
        -47,
        -183
      }
    };
    private static readonly int[] Bpp = new int[14]
    {
      32,
      24,
      16,
      16,
      16,
      16,
      16,
      8,
      8,
      8,
      4,
      4,
      4,
      8
    };
    private static readonly int[] TileOrder = new int[16]
    {
      0,
      1,
      4,
      5,
      2,
      3,
      6,
      7,
      8,
      9,
      12,
      13,
      10,
      11,
      14,
      15
    };
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
    private static float Texture_Insertion_Percentage;

    public static int GetBpp(Textures.ImageFormat Format)
    {
      return Textures.Bpp[(int) Format];
    }

    public static Bitmap ToBitmap(byte[] Data, int Width, int Height, Textures.ImageFormat Format, bool ExactSize = false)
    {
      return Textures.ToBitmap(Data, 0, Width, Height, Format, ExactSize);
    }

    private static int ColorClamp(int Color)
    {
      if (Color > (int) byte.MaxValue)
        Color = (int) byte.MaxValue;
      if (Color < 0)
        Color = 0;
      return Color;
    }

    public static unsafe Bitmap ToBitmap(byte[] Data, int Offset, int Width, int Height, Textures.ImageFormat Format, bool ExactSize = false)
    {
      if (Data == null || Data.Length < 1 || (Offset < 0 || Offset >= Data.Length) || (Width < 1 || Height < 1))
        return (Bitmap) null;
      if (ExactSize && (Width % 8 != 0 || Height % 8 != 0))
        return (Bitmap) null;
      int width = Width;
      int height = Height;
      if (!ExactSize)
      {
        Width = 1 << (int) Math.Ceiling(Math.Log((double) Width, 2.0));
        Height = 1 << (int) Math.Ceiling(Math.Log((double) Height, 2.0));
      }
      Bitmap bitmap = new Bitmap(width, height);
      BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
      uint* numPtr = (uint*) (void*) bitmapdata.Scan0;
      int Offset1 = Offset;
      int num1 = bitmapdata.Stride / 4;
      switch (Format)
      {
        case Textures.ImageFormat.RGBA8:
          int num2 = 0;
          while (num2 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num2 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    numPtr[(num2 + num5) * num1 + num3 + num4] = GFXUtil.ConvertColorFormat(IOUtil.ReadU32LE(Data, Offset1 + num6 * 4), ColorFormat.RGBA8888, ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 256;
              num3 += 8;
            }
            num2 += 8;
          }
          break;
        case Textures.ImageFormat.RGB8:
          int num7 = 0;
          while (num7 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num7 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    numPtr[(num7 + num5) * num1 + num3 + num4] = GFXUtil.ConvertColorFormat(IOUtil.ReadU24LE(Data, Offset1 + num6 * 3), ColorFormat.RGB888, ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 192;
              num3 += 8;
            }
            num7 += 8;
          }
          break;
        case Textures.ImageFormat.RGBA5551:
          int num8 = 0;
          while (num8 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num8 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    numPtr[(num8 + num5) * num1 + num3 + num4] = GFXUtil.ConvertColorFormat((uint) IOUtil.ReadU16LE(Data, Offset1 + num6 * 2), ColorFormat.ARGB1555, ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 128;
              num3 += 8;
            }
            num8 += 8;
          }
          break;
        case Textures.ImageFormat.RGB565:
          int num9 = 0;
          while (num9 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num9 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    numPtr[(num9 + num5) * num1 + num3 + num4] = GFXUtil.ConvertColorFormat((uint) IOUtil.ReadU16LE(Data, Offset1 + num6 * 2), ColorFormat.RGB565, ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 128;
              num3 += 8;
            }
            num9 += 8;
          }
          break;
        case Textures.ImageFormat.RGBA4:
          int num10 = 0;
          while (num10 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num10 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    numPtr[(num10 + num5) * num1 + num3 + num4] = GFXUtil.ConvertColorFormat((uint) IOUtil.ReadU16LE(Data, Offset1 + num6 * 2), ColorFormat.RGBA4444, ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 128;
              num3 += 8;
            }
            num10 += 8;
          }
          break;
        case Textures.ImageFormat.LA8:
          int num11 = 0;
          while (num11 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num11 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    numPtr[(num11 + num5) * num1 + num3 + num4] = GFXUtil.ToColorFormat((int) Data[Offset1 + num6 * 2], (int) Data[Offset1 + num6 * 2 + 1], (int) Data[Offset1 + num6 * 2 + 1], (int) Data[Offset1 + num6 * 2 + 1], ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 128;
              num3 += 8;
            }
            num11 += 8;
          }
          break;
        case Textures.ImageFormat.HILO8:
          int num12 = 0;
          while (num12 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num12 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    numPtr[(num12 + num5) * num1 + num3 + num4] = GFXUtil.ToColorFormat((int) Data[Offset1 + num6 * 2], (int) Data[Offset1 + num6 * 2 + 1], (int) Data[Offset1 + num6 * 2 + 1], (int) Data[Offset1 + num6 * 2 + 1], ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 128;
              num3 += 8;
            }
            num12 += 8;
          }
          break;
        case Textures.ImageFormat.L8:
          int num13 = 0;
          while (num13 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num13 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    numPtr[(num13 + num5) * num1 + num3 + num4] = GFXUtil.ToColorFormat((int) Data[Offset1 + num6], (int) Data[Offset1 + num6], (int) Data[Offset1 + num6], ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 64;
              num3 += 8;
            }
            num13 += 8;
          }
          break;
        case Textures.ImageFormat.A8:
          int num14 = 0;
          while (num14 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num14 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    numPtr[(num14 + num5) * num1 + num3 + num4] = GFXUtil.ToColorFormat((int) Data[Offset1 + num6], (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 64;
              num3 += 8;
            }
            num14 += 8;
          }
          break;
        case Textures.ImageFormat.LA4:
          int num15 = 0;
          while (num15 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num15 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    numPtr[(num15 + num5) * num1 + num3 + num4] = GFXUtil.ToColorFormat((int) (byte) (((int) Data[Offset1 + num6] & 15) * 17), (int) (byte) (((int) Data[Offset1 + num6] >> 4) * 17), (int) (byte) (((int) Data[Offset1 + num6] >> 4) * 17), (int) (byte) (((int) Data[Offset1 + num6] >> 4) * 17), ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 64;
              num3 += 8;
            }
            num15 += 8;
          }
          break;
        case Textures.ImageFormat.L4:
          int num16 = 0;
          while (num16 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num16 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    int num17 = (num6 & 1) * 4;
                    numPtr[(num16 + num5) * num1 + num3 + num4] = GFXUtil.ToColorFormat((int) (byte) (((int) Data[Offset1 + num6 / 2] >> num17 & 15) * 17), (int) (byte) (((int) Data[Offset1 + num6 / 2] >> num17 & 15) * 17), (int) (byte) (((int) Data[Offset1 + num6 / 2] >> num17 & 15) * 17), ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 32;
              num3 += 8;
            }
            num16 += 8;
          }
          break;
        case Textures.ImageFormat.A4:
          int num18 = 0;
          while (num18 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num4 = index % 8;
                if (num3 + num4 < width)
                {
                  int num5 = index / 8;
                  if (num18 + num5 < height)
                  {
                    int num6 = Textures.TileOrder[num4 % 4 + num5 % 4 * 4] + 16 * (num4 / 4) + 32 * (num5 / 4);
                    int num17 = (num6 & 1) * 4;
                    numPtr[(num18 + num5) * num1 + num3 + num4] = GFXUtil.ToColorFormat((int) (byte) (((int) Data[Offset1 + num6 / 2] >> num17 & 15) * 17), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, ColorFormat.ARGB8888);
                  }
                }
              }
              Offset1 += 32;
              num3 += 8;
            }
            num18 += 8;
          }
          break;
        case Textures.ImageFormat.ETC1:
        case Textures.ImageFormat.ETC1A4:
          int num19 = 0;
          while (num19 < Height)
          {
            int num3 = 0;
            while (num3 < Width)
            {
              int num4 = 0;
              while (num4 < 8)
              {
                int num5 = 0;
                while (num5 < 8)
                {
                  ulong num6 = ulong.MaxValue;
                  if (Format == Textures.ImageFormat.ETC1A4)
                  {
                    num6 = IOUtil.ReadU64LE(Data, Offset1);
                    Offset1 += 8;
                  }
                  ulong num17 = IOUtil.ReadU64LE(Data, Offset1);
                  int num20 = ((long) (num17 >> 33) & 1L) == 1L ? 1 : 0;
                  bool flag1 = ((long) (num17 >> 32) & 1L) == 1L;
                  int num21;
                  int num22;
                  int num23;
                  int num24;
                  int num25;
                  int num26;
                  if (num20 != 0)
                  {
                    int num27 = (int) ((long) (num17 >> 59) & 31L);
                    int num28 = (int) ((long) (num17 >> 51) & 31L);
                    int num29 = (int) ((long) (num17 >> 43) & 31L);
                    num21 = num27 << 3 | (num27 & 28) >> 2;
                    num22 = num28 << 3 | (num28 & 28) >> 2;
                    num23 = num29 << 3 | (num29 & 28) >> 2;
                    int num30 = num27 + ((int) ((long) (num17 >> 56) & 7L) << 29 >> 29);
                    int num31 = num28 + ((int) ((long) (num17 >> 48) & 7L) << 29 >> 29);
                    int num32 = num29 + ((int) ((long) (num17 >> 40) & 7L) << 29 >> 29);
                    num24 = num30 << 3 | (num30 & 28) >> 2;
                    num25 = num31 << 3 | (num31 & 28) >> 2;
                    num26 = num32 << 3 | (num32 & 28) >> 2;
                  }
                  else
                  {
                    num21 = (int) ((long) (num17 >> 60) & 15L) * 17;
                    num22 = (int) ((long) (num17 >> 52) & 15L) * 17;
                    num23 = (int) ((long) (num17 >> 44) & 15L) * 17;
                    num24 = (int) ((long) (num17 >> 56) & 15L) * 17;
                    num25 = (int) ((long) (num17 >> 48) & 15L) * 17;
                    num26 = (int) ((long) (num17 >> 40) & 15L) * 17;
                  }
                  int index1 = (int) ((long) (num17 >> 37) & 7L);
                  int index2 = (int) ((long) (num17 >> 34) & 7L);
                  for (int index3 = 0; index3 < 4; ++index3)
                  {
                    for (int index4 = 0; index4 < 4; ++index4)
                    {
                      if (num3 + num5 + index4 < width && num19 + num4 + index3 < height)
                      {
                        int index5 = (int) ((long) (num17 >> index4 * 4 + index3) & 1L);
                        bool flag2 = ((long) (num17 >> index4 * 4 + index3 + 16) & 1L) == 1L;
                        uint num27;
                        if (flag1 && index3 < 2 || !flag1 && index4 < 2)
                        {
                          int num28 = Textures.ETC1Modifiers[index1, index5] * (flag2 ? -1 : 1);
                          num27 = GFXUtil.ToColorFormat((int) (byte) ((num6 >> (index4 * 4 + index3) * 4 & 15UL) * 17UL), (int) (byte) Textures.ColorClamp(num21 + num28), (int) (byte) Textures.ColorClamp(num22 + num28), (int) (byte) Textures.ColorClamp(num23 + num28), ColorFormat.ARGB8888);
                        }
                        else
                        {
                          int num28 = Textures.ETC1Modifiers[index2, index5] * (flag2 ? -1 : 1);
                          num27 = GFXUtil.ToColorFormat((int) (byte) ((num6 >> (index4 * 4 + index3) * 4 & 15UL) * 17UL), (int) (byte) Textures.ColorClamp(num24 + num28), (int) (byte) Textures.ColorClamp(num25 + num28), (int) (byte) Textures.ColorClamp(num26 + num28), ColorFormat.ARGB8888);
                        }
                        numPtr[(num4 + index3) * num1 + num3 + num5 + index4] = num27;
                      }
                    }
                  }
                  Offset1 += 8;
                  num5 += 4;
                }
                num4 += 4;
              }
              num3 += 8;
            }
            numPtr += num1 * 8;
            num19 += 8;
          }
          break;
      }
      bitmap.UnlockBits(bitmapdata);
      return bitmap;
    }

    public static unsafe byte[] FromBitmap(Bitmap Picture, Textures.ImageFormat Format, bool ExactSize = false)
    {
      if (ExactSize && (Picture.Width % 8 != 0 || Picture.Height % 8 != 0))
        return (byte[]) null;
      int width = Picture.Width;
      int height = Picture.Height;
      int num1 = Picture.Width;
      int num2 = Picture.Height;
      if (!ExactSize)
      {
        num1 = 1 << (int) Math.Ceiling(Math.Log((double) Picture.Width, 2.0));
        num2 = 1 << (int) Math.Ceiling(Math.Log((double) Picture.Height, 2.0));
      }
      byte[] Data = new byte[num1 * num2 * Textures.GetBpp(Format) / 8];
      int Offset = 0;
      BitmapData bitmapdata = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadOnly, Picture.PixelFormat);
      uint* numPtr = (uint*) (void*) bitmapdata.Scan0;
      switch (Format)
      {
        case Textures.ImageFormat.RGBA8:
          int num3 = 0;
          while (num3 < num2)
          {
            int num4 = 0;
            while (num4 < num1)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num5 = index % 8;
                if (num4 + num5 < width)
                {
                  int num6 = index / 8;
                  if (num3 + num6 < height)
                  {
                    int num7 = Textures.TileOrder[num5 % 4 + num6 % 4 * 4] + 16 * (num5 / 4) + 32 * (num6 / 4);
                    Color color = Color.FromArgb((int) numPtr[(num3 + num6) * bitmapdata.Stride / 4 + num4 + num5]);
                    Data[Offset + num7 * 4] = color.A;
                    Data[Offset + num7 * 4 + 1] = color.B;
                    Data[Offset + num7 * 4 + 2] = color.G;
                    Data[Offset + num7 * 4 + 3] = color.R;
                  }
                }
              }
              Offset += 256;
              num4 += 8;
            }
            num3 += 8;
          }
          break;
        case Textures.ImageFormat.RGB8:
          int num8 = 0;
          while (num8 < num2)
          {
            int num4 = 0;
            while (num4 < num1)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num5 = index % 8;
                if (num4 + num5 < width)
                {
                  int num6 = index / 8;
                  if (num8 + num6 < height)
                  {
                    int num7 = Textures.TileOrder[num5 % 4 + num6 % 4 * 4] + 16 * (num5 / 4) + 32 * (num6 / 4);
                    Color color = Color.FromArgb((int) numPtr[(num8 + num6) * bitmapdata.Stride / 4 + num4 + num5]);
                    Data[Offset + num7 * 3] = color.B;
                    Data[Offset + num7 * 3 + 1] = color.G;
                    Data[Offset + num7 * 3 + 2] = color.R;
                  }
                }
              }
              Offset += 192;
              num4 += 8;
            }
            num8 += 8;
          }
          break;
        case Textures.ImageFormat.RGB565:
          int num9 = 0;
          while (num9 < num2)
          {
            int num4 = 0;
            while (num4 < num1)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num5 = index % 8;
                if (num4 + num5 < width)
                {
                  int num6 = index / 8;
                  if (num9 + num6 < height)
                  {
                    int num7 = Textures.TileOrder[num5 % 4 + num6 % 4 * 4] + 16 * (num5 / 4) + 32 * (num6 / 4);
                    IOUtil.WriteU16LE(Data, Offset + num7 * 2, (ushort) GFXUtil.ConvertColorFormat(numPtr[(num9 + num6) * bitmapdata.Stride / 4 + num4 + num5], ColorFormat.ARGB8888, ColorFormat.RGB565));
                  }
                }
              }
              Offset += 128;
              num4 += 8;
            }
            num9 += 8;
          }
          break;
        case Textures.ImageFormat.LA8:
          int num10 = 0;
          while (num10 < num2)
          {
            int num4 = 0;
            while (num4 < num1)
            {
              for (int index = 0; index < 64; ++index)
              {
                int num5 = index % 8;
                if (num4 + num5 < width)
                {
                  int num6 = index / 8;
                  if (num10 + num6 < height)
                  {
                    int num7 = Textures.TileOrder[num5 % 4 + num6 % 4 * 4] + 16 * (num5 / 4) + 32 * (num6 / 4);
                    Color color = Color.FromArgb((int) numPtr[(num10 + num6) * bitmapdata.Stride / 4 + num4 + num5]);
                    Data[Offset + num7 * 2] = color.A;
                    Data[Offset + num7 * 2 + 1] = (byte) Math.Round((double) (((int) color.R + (int) color.G + (int) color.B) / 3));
                  }
                }
              }
              Offset += 128;
              num4 += 8;
            }
            num10 += 8;
          }
          break;
        case Textures.ImageFormat.ETC1:
        case Textures.ImageFormat.ETC1A4:
          int num11 = 0;
          while (num11 < num2)
          {
            int num4 = 0;
            while (num4 < num1)
            {
              int num5 = 0;
              while (num5 < 8)
              {
                int num6 = 0;
                while (num6 < 8)
                {
                  if (Format == Textures.ImageFormat.ETC1A4)
                  {
                    ulong num7 = 0UL;
                    int num12 = 0;
                    for (int index1 = 0; index1 < 4; ++index1)
                    {
                      for (int index2 = 0; index2 < 4; ++index2)
                      {
                        uint num13 = (num4 + num6 + index1 < width ? (num11 + num5 + index2 < height ? numPtr[(num11 + num5 + index2) * (bitmapdata.Stride / 4) + num4 + num6 + index1] : 16777215U) : 16777215U) >> 24 >> 4;
                        num7 |= (ulong) num13 << num12 * 4;
                        ++num12;
                      }
                    }
                    IOUtil.WriteU64LE(Data, Offset, num7);
                    Offset += 8;
                  }
                  Color[] Colors = new Color[16];
                  for (int index1 = 0; index1 < 4; ++index1)
                  {
                    for (int index2 = 0; index2 < 4; ++index2)
                      Colors[index1 * 4 + index2] = num4 + num6 + index2 < width ? (num11 + num5 + index1 < height ? Color.FromArgb((int) numPtr[(num11 + num5 + index1) * (bitmapdata.Stride / 4) + num4 + num6 + index2]) : Color.Transparent) : Color.Transparent;
                  }
                  IOUtil.WriteU64LE(Data, Offset, ETC1.GenETC1(Colors));
                  Offset += 8;
                  num6 += 4;
                }
                num5 += 4;
              }
              num4 += 8;
            }
            num11 += 8;
          }
          break;
        default:
          throw new NotImplementedException("This format is not implemented yet.");
      }
      Picture.UnlockBits(bitmapdata);
      return Data;
    }

    public enum ImageFormat : uint
    {
      RGBA8,
      RGB8,
      RGBA5551,
      RGB565,
      RGBA4,
      LA8,
      HILO8,
      L8,
      A8,
      LA4,
      L4,
      A4,
      ETC1,
      ETC1A4,
    }
  }
}
