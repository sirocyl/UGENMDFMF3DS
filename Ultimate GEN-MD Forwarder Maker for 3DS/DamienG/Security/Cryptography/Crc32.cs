// Decompiled with JetBrains decompiler
// Type: DamienG.Security.Cryptography.Crc32
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DamienG.Security.Cryptography
{
  public sealed class Crc32 : HashAlgorithm
  {
    public const uint DefaultPolynomial = 3988292384U;
    public const uint DefaultSeed = 4294967295U;
    private static uint[] defaultTable;
    private readonly uint seed;
    private readonly uint[] table;
    private uint hash;

    public override int HashSize
    {
      get
      {
        return 32;
      }
    }

    public Crc32()
      : this(3988292384U, uint.MaxValue)
    {
    }

    public Crc32(uint polynomial, uint seed)
    {
      this.table = Crc32.InitializeTable(polynomial);
      this.seed = this.hash = seed;
    }

    public override void Initialize()
    {
      this.hash = this.seed;
    }

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
      this.hash = Crc32.CalculateHash(this.table, this.hash, (IList<byte>) array, ibStart, cbSize);
    }

    protected override byte[] HashFinal()
    {
      byte[] numArray = Crc32.UInt32ToBigEndianBytes(~this.hash);
      this.HashValue = numArray;
      return numArray;
    }

    public static uint Compute(byte[] buffer)
    {
      return Crc32.Compute(uint.MaxValue, buffer);
    }

    public static uint Compute(uint seed, byte[] buffer)
    {
      return Crc32.Compute(3988292384U, seed, buffer);
    }

    public static uint Compute(uint polynomial, uint seed, byte[] buffer)
    {
      return ~Crc32.CalculateHash(Crc32.InitializeTable(polynomial), seed, (IList<byte>) buffer, 0, buffer.Length);
    }

    private static uint[] InitializeTable(uint polynomial)
    {
      if ((int) polynomial == -306674912 && Crc32.defaultTable != null)
        return Crc32.defaultTable;
      uint[] numArray = new uint[256];
      for (int index1 = 0; index1 < 256; ++index1)
      {
        uint num = (uint) index1;
        for (int index2 = 0; index2 < 8; ++index2)
        {
          if (((int) num & 1) == 1)
            num = num >> 1 ^ polynomial;
          else
            num >>= 1;
        }
        numArray[index1] = num;
      }
      if ((int) polynomial == -306674912)
        Crc32.defaultTable = numArray;
      return numArray;
    }

    private static uint CalculateHash(uint[] table, uint seed, IList<byte> buffer, int start, int size)
    {
      uint num = seed;
      for (int index = start; index < start + size; ++index)
        num = num >> 8 ^ table[(int) buffer[index] ^ (int) num & (int) byte.MaxValue];
      return num;
    }

    private static byte[] UInt32ToBigEndianBytes(uint uint32)
    {
      byte[] bytes = BitConverter.GetBytes(uint32);
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) bytes);
      return bytes;
    }
  }
}
