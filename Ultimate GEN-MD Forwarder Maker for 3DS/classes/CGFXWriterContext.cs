// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.CGFXWriterContext
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class CGFXWriterContext
  {
    private Dictionary<long, byte[]> IMAGBlockEntries = new Dictionary<long, byte[]>();
    private Dictionary<long, string> StringTableEntries = new Dictionary<long, string>();

    public void WriteDataReference(byte[] Data, EndianBinaryWriter er)
    {
      this.IMAGBlockEntries.Add(er.BaseStream.Position, Data);
      er.Write(0U);
    }

    public void WriteStringReference(string s, EndianBinaryWriter er)
    {
      this.StringTableEntries.Add(er.BaseStream.Position, s);
      er.Write(0U);
    }

    public void WriteStringTable(EndianBinaryWriter er)
    {
      Dictionary<string, long> dictionary = new Dictionary<string, long>();
      foreach (KeyValuePair<long, string> keyValuePair in this.StringTableEntries)
      {
        if (dictionary.ContainsKey(keyValuePair.Value))
        {
          long position = er.BaseStream.Position;
          er.BaseStream.Position = keyValuePair.Key;
          er.Write((uint) (dictionary[keyValuePair.Value] - keyValuePair.Key));
          er.BaseStream.Position = position;
        }
        else
        {
          long position = er.BaseStream.Position;
          er.BaseStream.Position = keyValuePair.Key;
          er.Write((uint) (position - keyValuePair.Key));
          er.BaseStream.Position = position;
          dictionary.Add(keyValuePair.Value, position);
          er.Write(keyValuePair.Value, Encoding.ASCII, true);
        }
      }
    }

    public bool DoWriteIMAGBlock()
    {
      return this.IMAGBlockEntries.Count > 0;
    }

    public int GetIMAGBlockSize()
    {
      int num = 0;
      foreach (KeyValuePair<long, byte[]> keyValuePair in this.IMAGBlockEntries)
      {
        num += keyValuePair.Value.Length;
        while (num % 128 != 0)
          ++num;
      }
      while (num % 8 != 0)
        ++num;
      return num + 8;
    }

    public void WriteIMAGBlock(EndianBinaryWriter er)
    {
      er.Write("IMAG", Encoding.ASCII, false);
      er.Write((uint) this.GetIMAGBlockSize());
      foreach (KeyValuePair<long, byte[]> keyValuePair in this.IMAGBlockEntries)
      {
        long position = er.BaseStream.Position;
        er.BaseStream.Position = keyValuePair.Key;
        er.Write((uint) (position - keyValuePair.Key));
        er.BaseStream.Position = position;
        er.Write(keyValuePair.Value, 0, keyValuePair.Value.Length);
        while (er.BaseStream.Position % 128L != 0L)
          er.Write((byte) 0);
      }
      while (er.BaseStream.Position % 64L != 0L)
        er.Write((byte) 0);
    }

    public static uint CalcHash(byte[] Data)
    {
      uint num = 0U;
      byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Data);
      for (int index = 0; index < hash.Length; ++index)
        num ^= (uint) hash[index] << index % 4 * 8;
      if ((int) num == 0)
        return 1U;
      return num;
    }

    public static void WriteFloatColorRGB(byte[] Data, int Offset, Vector4 Value)
    {
      IOUtil.WriteSingleLE(Data, Offset, Value.X);
      IOUtil.WriteSingleLE(Data, Offset + 4, Value.Y);
      IOUtil.WriteSingleLE(Data, Offset + 8, Value.Z);
    }

    public static void WriteFloatColorRGBA(byte[] Data, int Offset, Vector4 Value)
    {
      IOUtil.WriteSingleLE(Data, Offset, Value.X);
      IOUtil.WriteSingleLE(Data, Offset + 4, Value.Y);
      IOUtil.WriteSingleLE(Data, Offset + 8, Value.Z);
      IOUtil.WriteSingleLE(Data, Offset + 12, Value.W);
    }
  }
}
