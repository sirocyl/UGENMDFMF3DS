// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.Extensions
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.Drawing;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public static class Extensions
  {
    public static Color ReadColor8(this EndianBinaryReader er)
    {
      int red = (int) er.ReadByte();
      int green = (int) er.ReadByte();
      int blue = (int) er.ReadByte();
      return Color.FromArgb((int) er.ReadByte(), red, green, blue);
    }

    public static Color ReadColor4Singles(this EndianBinaryReader er)
    {
      float num1 = er.ReadSingle();
      float num2 = er.ReadSingle();
      float num3 = er.ReadSingle();
      return Color.FromArgb((int) (0.5 + (double) er.ReadSingle() * (double) byte.MaxValue), (int) (0.5 + (double) num1 * (double) byte.MaxValue), (int) (0.5 + (double) num2 * (double) byte.MaxValue), (int) (0.5 + (double) num3 * (double) byte.MaxValue));
    }

    public static void WriteColor8(this EndianBinaryWriter er, Color Value)
    {
      er.Write(Value.R);
      er.Write(Value.G);
      er.Write(Value.B);
      er.Write(Value.A);
    }

    public static void WriteColor4Singles(this EndianBinaryWriter er, Color Value)
    {
      er.Write((float) Value.R / (float) byte.MaxValue);
      er.Write((float) Value.G / (float) byte.MaxValue);
      er.Write((float) Value.B / (float) byte.MaxValue);
      er.Write((float) Value.A / (float) byte.MaxValue);
    }
  }
}
