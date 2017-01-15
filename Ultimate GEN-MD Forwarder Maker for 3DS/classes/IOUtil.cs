// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.IOUtil
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class IOUtil
  {
    public static short ReadS16LE(byte[] Data, int Offset)
    {
      return (short) ((int) Data[Offset] | (int) Data[Offset + 1] << 8);
    }

    public static short[] ReadS16sLE(byte[] Data, int Offset, int Count)
    {
      short[] numArray = new short[Count];
      for (int index = 0; index < Count; ++index)
        numArray[index] = IOUtil.ReadS16LE(Data, Offset + index * 2);
      return numArray;
    }

    public static short ReadS16BE(byte[] Data, int Offset)
    {
      return (short) ((int) Data[Offset] << 8 | (int) Data[Offset + 1]);
    }

    public static void WriteS16LE(byte[] Data, int Offset, short Value)
    {
      Data[Offset] = (byte) ((uint) Value & (uint) byte.MaxValue);
      Data[Offset + 1] = (byte) ((int) Value >> 8 & (int) byte.MaxValue);
    }

    public static void WriteS16sLE(byte[] Data, int Offset, short[] Values)
    {
      for (int index = 0; index < Values.Length; ++index)
        IOUtil.WriteS16LE(Data, Offset + index * 2, Values[index]);
    }

    public static ushort ReadU16LE(byte[] Data, int Offset)
    {
      return (ushort) ((uint) Data[Offset] | (uint) Data[Offset + 1] << 8);
    }

    public static ushort ReadU16BE(byte[] Data, int Offset)
    {
      return (ushort) ((uint) Data[Offset] << 8 | (uint) Data[Offset + 1]);
    }

    public static void WriteU16LE(byte[] Data, int Offset, ushort Value)
    {
      Data[Offset] = (byte) ((uint) Value & (uint) byte.MaxValue);
      Data[Offset + 1] = (byte) ((int) Value >> 8 & (int) byte.MaxValue);
    }

    public static uint ReadU24LE(byte[] Data, int Offset)
    {
      return (uint) ((int) Data[Offset] | (int) Data[Offset + 1] << 8 | (int) Data[Offset + 2] << 16);
    }

    public static uint ReadU32LE(byte[] Data, int Offset)
    {
      return (uint) ((int) Data[Offset] | (int) Data[Offset + 1] << 8 | (int) Data[Offset + 2] << 16 | (int) Data[Offset + 3] << 24);
    }

    public static uint ReadU32BE(byte[] Data, int Offset)
    {
      return (uint) ((int) Data[Offset] << 24 | (int) Data[Offset + 1] << 16 | (int) Data[Offset + 2] << 8) | (uint) Data[Offset + 3];
    }

    public static void WriteU32LE(byte[] Data, int Offset, uint Value)
    {
      Data[Offset] = (byte) (Value & (uint) byte.MaxValue);
      Data[Offset + 1] = (byte) (Value >> 8 & (uint) byte.MaxValue);
      Data[Offset + 2] = (byte) (Value >> 16 & (uint) byte.MaxValue);
      Data[Offset + 3] = (byte) (Value >> 24 & (uint) byte.MaxValue);
    }

    public static ulong ReadU64LE(byte[] Data, int Offset)
    {
      return (ulong) ((long) Data[Offset] | (long) Data[Offset + 1] << 8 | (long) Data[Offset + 2] << 16 | (long) Data[Offset + 3] << 24 | (long) Data[Offset + 4] << 32 | (long) Data[Offset + 5] << 40 | (long) Data[Offset + 6] << 48 | (long) Data[Offset + 7] << 56);
    }

    public static ulong ReadU64BE(byte[] Data, int Offset)
    {
      return (ulong) ((long) Data[Offset] << 56 | (long) Data[Offset + 1] << 48 | (long) Data[Offset + 2] << 40 | (long) Data[Offset + 3] << 32 | (long) Data[Offset + 4] << 24 | (long) Data[Offset + 5] << 16 | (long) Data[Offset + 6] << 8) | (ulong) Data[Offset + 7];
    }

    public static void WriteU64LE(byte[] Data, int Offset, ulong Value)
    {
      Data[Offset] = (byte) (Value & (ulong) byte.MaxValue);
      Data[Offset + 1] = (byte) (Value >> 8 & (ulong) byte.MaxValue);
      Data[Offset + 2] = (byte) (Value >> 16 & (ulong) byte.MaxValue);
      Data[Offset + 3] = (byte) (Value >> 24 & (ulong) byte.MaxValue);
      Data[Offset + 4] = (byte) (Value >> 32 & (ulong) byte.MaxValue);
      Data[Offset + 5] = (byte) (Value >> 40 & (ulong) byte.MaxValue);
      Data[Offset + 6] = (byte) (Value >> 48 & (ulong) byte.MaxValue);
      Data[Offset + 7] = (byte) (Value >> 56 & (ulong) byte.MaxValue);
    }

    public static void WriteSingleLE(byte[] Data, int Offset, float Value)
    {
      byte[] bytes = BitConverter.GetBytes(Value);
      Data[Offset] = bytes[0];
      Data[1 + Offset] = bytes[1];
      Data[2 + Offset] = bytes[2];
      Data[3 + Offset] = bytes[3];
    }
  }
}
