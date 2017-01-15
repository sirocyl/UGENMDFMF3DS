// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.EndianBinaryWriter
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.IO;
using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class EndianBinaryWriter : IDisposable
  {
    private bool disposed;
    private byte[] buffer;

    public Stream BaseStream { get; private set; }

    public Endianness Endianness { get; set; }

    public Endianness SystemEndianness
    {
      get
      {
        return !BitConverter.IsLittleEndian ? Endianness.BigEndian : Endianness.LittleEndian;
      }
    }

    private bool Reverse
    {
      get
      {
        return this.SystemEndianness != this.Endianness;
      }
    }

    public EndianBinaryWriter(Stream baseStream)
      : this(baseStream, Endianness.BigEndian)
    {
    }

    public EndianBinaryWriter(Stream baseStream, Endianness endianness)
    {
      if (baseStream == null)
        throw new ArgumentNullException("baseStream");
      if (!baseStream.CanWrite)
        throw new ArgumentException("baseStream");
      this.BaseStream = baseStream;
      this.Endianness = endianness;
    }

    ~EndianBinaryWriter()
    {
      try
      {
        this.Dispose(false);
      }
      finally
      {
        // ISSUE: explicit finalizer call
        // ISSUE: explicit non-virtual call
        // base.Finalize();
      }
    }

    private void WriteBuffer(int bytes, int stride)
    {
      if (this.Reverse)
      {
        int index = 0;
        while (index < bytes)
        {
          Array.Reverse((Array) this.buffer, index, stride);
          index += stride;
        }
      }
      this.BaseStream.Write(this.buffer, 0, bytes);
    }

    private void CreateBuffer(int size)
    {
      if (this.buffer != null && this.buffer.Length >= size)
        return;
      this.buffer = new byte[size];
    }

    public void Write(byte value)
    {
      this.CreateBuffer(1);
      this.buffer[0] = value;
      this.WriteBuffer(1, 1);
    }

    public void Write(byte[] value, int offset, int count)
    {
      this.CreateBuffer(count);
      Array.Copy((Array) value, offset, (Array) this.buffer, 0, count);
      this.WriteBuffer(count, 1);
    }

    public void Write(sbyte value)
    {
      this.CreateBuffer(1);
      this.buffer[0] = (byte) value;
      this.WriteBuffer(1, 1);
    }

    public void Write(sbyte[] value, int offset, int count)
    {
      this.CreateBuffer(count);
      for (int index = 0; index < count; ++index)
        this.buffer[index] = (byte) value[index + offset];
      this.WriteBuffer(count, 1);
    }

    public void Write(char value, Encoding encoding)
    {
      int encodingSize = EndianBinaryWriter.GetEncodingSize(encoding);
      this.CreateBuffer(encodingSize);
      Array.Copy((Array) encoding.GetBytes(new string(value, 1)), 0, (Array) this.buffer, 0, encodingSize);
      this.WriteBuffer(encodingSize, encodingSize);
    }

    public void Write(char[] value, int offset, int count, Encoding encoding)
    {
      int encodingSize = EndianBinaryWriter.GetEncodingSize(encoding);
      this.CreateBuffer(encodingSize * count);
      Array.Copy((Array) encoding.GetBytes(value, offset, count), 0, (Array) this.buffer, 0, count * encodingSize);
      this.WriteBuffer(encodingSize * count, encodingSize);
    }

    private static int GetEncodingSize(Encoding encoding)
    {
      return encoding == Encoding.UTF8 || encoding == Encoding.ASCII || encoding != Encoding.Unicode && encoding != Encoding.BigEndianUnicode ? 1 : 2;
    }

    public void Write(string value, Encoding encoding, bool nullTerminated)
    {
      this.Write(value.ToCharArray(), 0, value.Length, encoding);
      if (!nullTerminated)
        return;
      this.Write(char.MinValue, encoding);
    }

    public void Write(double value)
    {
      this.CreateBuffer(8);
      Array.Copy((Array) BitConverter.GetBytes(value), 0, (Array) this.buffer, 0, 8);
      this.WriteBuffer(8, 8);
    }

    public void Write(double[] value, int offset, int count)
    {
      this.CreateBuffer(8 * count);
      for (int index = 0; index < count; ++index)
        Array.Copy((Array) BitConverter.GetBytes(value[index + offset]), 0, (Array) this.buffer, index * 8, 8);
      this.WriteBuffer(8 * count, 8);
    }

    public void Write(float value)
    {
      this.CreateBuffer(4);
      Array.Copy((Array) BitConverter.GetBytes(value), 0, (Array) this.buffer, 0, 4);
      this.WriteBuffer(4, 4);
    }

    public void Write(float[] value, int offset, int count)
    {
      this.CreateBuffer(4 * count);
      for (int index = 0; index < count; ++index)
        Array.Copy((Array) BitConverter.GetBytes(value[index + offset]), 0, (Array) this.buffer, index * 4, 4);
      this.WriteBuffer(4 * count, 4);
    }

    public void Write(int value)
    {
      this.CreateBuffer(4);
      Array.Copy((Array) BitConverter.GetBytes(value), 0, (Array) this.buffer, 0, 4);
      this.WriteBuffer(4, 4);
    }

    public void Write(int[] value, int offset, int count)
    {
      this.CreateBuffer(4 * count);
      for (int index = 0; index < count; ++index)
        Array.Copy((Array) BitConverter.GetBytes(value[index + offset]), 0, (Array) this.buffer, index * 4, 4);
      this.WriteBuffer(4 * count, 4);
    }

    public void Write(long value)
    {
      this.CreateBuffer(8);
      Array.Copy((Array) BitConverter.GetBytes(value), 0, (Array) this.buffer, 0, 8);
      this.WriteBuffer(8, 8);
    }

    public void Write(long[] value, int offset, int count)
    {
      this.CreateBuffer(8 * count);
      for (int index = 0; index < count; ++index)
        Array.Copy((Array) BitConverter.GetBytes(value[index + offset]), 0, (Array) this.buffer, index * 8, 8);
      this.WriteBuffer(8 * count, 8);
    }

    public void Write(short value)
    {
      this.CreateBuffer(2);
      Array.Copy((Array) BitConverter.GetBytes(value), 0, (Array) this.buffer, 0, 2);
      this.WriteBuffer(2, 2);
    }

    public void Write(short[] value, int offset, int count)
    {
      this.CreateBuffer(2 * count);
      for (int index = 0; index < count; ++index)
        Array.Copy((Array) BitConverter.GetBytes(value[index + offset]), 0, (Array) this.buffer, index * 2, 2);
      this.WriteBuffer(2 * count, 2);
    }

    public void Write(ushort value)
    {
      this.CreateBuffer(2);
      Array.Copy((Array) BitConverter.GetBytes(value), 0, (Array) this.buffer, 0, 2);
      this.WriteBuffer(2, 2);
    }

    public void Write(ushort[] value, int offset, int count)
    {
      this.CreateBuffer(2 * count);
      for (int index = 0; index < count; ++index)
        Array.Copy((Array) BitConverter.GetBytes(value[index + offset]), 0, (Array) this.buffer, index * 2, 2);
      this.WriteBuffer(2 * count, 2);
    }

    public void Write(uint value)
    {
      this.CreateBuffer(4);
      Array.Copy((Array) BitConverter.GetBytes(value), 0, (Array) this.buffer, 0, 4);
      this.WriteBuffer(4, 4);
    }

    public void Write(uint[] value, int offset, int count)
    {
      this.CreateBuffer(4 * count);
      for (int index = 0; index < count; ++index)
        Array.Copy((Array) BitConverter.GetBytes(value[index + offset]), 0, (Array) this.buffer, index * 4, 4);
      this.WriteBuffer(4 * count, 4);
    }

    public void Write(ulong value)
    {
      this.CreateBuffer(8);
      Array.Copy((Array) BitConverter.GetBytes(value), 0, (Array) this.buffer, 0, 8);
      this.WriteBuffer(8, 8);
    }

    public void Write(ulong[] value, int offset, int count)
    {
      this.CreateBuffer(8 * count);
      for (int index = 0; index < count; ++index)
        Array.Copy((Array) BitConverter.GetBytes(value[index + offset]), 0, (Array) this.buffer, index * 8, 8);
      this.WriteBuffer(8 * count, 8);
    }

    public void WriteVector2(Vector2 Vector)
    {
      this.Write(Vector.X);
      this.Write(Vector.Y);
    }

    public void WriteVector3(Vector3 Vector)
    {
      this.Write(Vector.X);
      this.Write(Vector.Y);
      this.Write(Vector.Z);
    }

    public void WriteVector4(Vector4 Vector)
    {
      this.Write(Vector.X);
      this.Write(Vector.Y);
      this.Write(Vector.Z);
      this.Write(Vector.W);
    }

    public void WriteFx16(float Value)
    {
      this.Write((short) ((double) Value * 4096.0));
    }

    public void WriteFx32(float Value)
    {
      this.Write((int) ((double) Value * 4096.0));
    }

    public void WriteVecFx32(Vector3 Value)
    {
      this.WriteFx32(Value.X);
      this.WriteFx32(Value.Y);
      this.WriteFx32(Value.Z);
    }

    public void Close()
    {
      this.Dispose();
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing && this.BaseStream != null)
        this.BaseStream.Close();
      this.buffer = (byte[]) null;
      this.disposed = true;
    }
  }
}
