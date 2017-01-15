// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.CGFX
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.IO;
using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class CGFX
  {
    public CGFX.CGFXHeader Header;
    public CGFX.DATA Data;

    public CGFX()
    {
      this.Header = new CGFX.CGFXHeader();
      this.Data = new CGFX.DATA();
    }

    public CGFX(byte[] Data)
    {
      EndianBinaryReader er = new EndianBinaryReader((Stream) new MemoryStream(Data), Endianness.LittleEndian);
      try
      {
        this.Header = new CGFX.CGFXHeader(er);
        this.Data = new CGFX.DATA(er);
      }
      finally
      {
        er.Close();
      }
    }

    public byte[] Write()
    {
      MemoryStream memoryStream = new MemoryStream();
      int num = 1;
      EndianBinaryWriter er = new EndianBinaryWriter((Stream) memoryStream, (Endianness) num);
      this.Header.NrBlocks = 1U;
      this.Header.Write(er);
      CGFXWriterContext c = new CGFXWriterContext();
      this.Data.Write(er, c);
      if (c.DoWriteIMAGBlock())
      {
        long position = er.BaseStream.Position;
        er.BaseStream.Position = 16L;
        er.Write(2U);
        er.BaseStream.Position = position;
        c.WriteIMAGBlock(er);
      }
      long position1 = er.BaseStream.Position;
      er.BaseStream.Position = 12L;
      er.BaseStream.Position = position1;
      byte[] numArray = memoryStream.ToArray();
      er.Close();
      return numArray;
    }

    public class CGFXHeader
    {
      public string Signature;
      public ushort Endianness;
      public ushort HeaderSize;
      public uint Version;
      public uint FileSize;
      public uint NrBlocks;

      public CGFXHeader()
      {
        this.Signature = "CGFX";
        this.Endianness = (ushort) 65279;
        this.HeaderSize = (ushort) 20;
        this.Version = 83886080U;
      }

      public CGFXHeader(EndianBinaryReader er)
      {
        this.Signature = er.ReadString(Encoding.ASCII, 4);
        if (this.Signature != "CGFX")
          throw new SignatureNotCorrectException(this.Signature, "CGFX", er.BaseStream.Position - 4L);
        this.Endianness = er.ReadUInt16();
        this.HeaderSize = er.ReadUInt16();
        this.Version = er.ReadUInt32();
        this.FileSize = er.ReadUInt32();
        this.NrBlocks = er.ReadUInt32();
      }

      public void Write(EndianBinaryWriter er)
      {
        er.Write(this.Signature, Encoding.ASCII, false);
        er.Write(this.Endianness);
        er.Write(this.HeaderSize);
        er.Write(this.Version);
        er.Write(this.FileSize);
        er.Write(this.NrBlocks);
      }
    }

    public class DATA
    {
      public string Signature;
      public uint SectionSize;
      public CGFX.DATA.DictionaryInfo[] DictionaryEntries;
      public DICT[] Dictionaries;
      public CMDL[] Models;
      public ImageTextureCtr[] Textures;
      public CANM[] SkeletonAnimations;
      public CANM[] MaterialAnimations;
      public CANM[] VisibilityAnimations;

      public DATA()
      {
        this.Signature = "DATA";
        this.DictionaryEntries = new CGFX.DATA.DictionaryInfo[16];
        this.Dictionaries = new DICT[16];
      }

      public DATA(EndianBinaryReader er)
      {
        this.Signature = er.ReadString(Encoding.ASCII, 4);
        if (this.Signature != "DATA")
          throw new SignatureNotCorrectException(this.Signature, "DATA", er.BaseStream.Position - 4L);
        this.SectionSize = er.ReadUInt32();
        this.DictionaryEntries = new CGFX.DATA.DictionaryInfo[16];
        for (int index = 0; index < 16; ++index)
          this.DictionaryEntries[index] = new CGFX.DATA.DictionaryInfo(er);
        this.Dictionaries = new DICT[16];
        for (int index = 0; index < 16; ++index)
        {
          if (index == 15 && (int) this.DictionaryEntries[index].NrItems == 1413695812)
          {
            this.DictionaryEntries[index].NrItems = 0U;
            this.DictionaryEntries[index].Offset = 0U;
          }
          if ((int) this.DictionaryEntries[index].Offset != 0)
          {
            long position = er.BaseStream.Position;
            er.BaseStream.Position = (long) this.DictionaryEntries[index].Offset;
            this.Dictionaries[index] = new DICT(er);
            er.BaseStream.Position = position;
          }
          else
            this.Dictionaries[index] = (DICT) null;
        }
        if (this.Dictionaries[0] != null)
        {
          this.Models = new CMDL[this.Dictionaries[0].Count];
          for (int index = 0; index < this.Dictionaries[0].Count; ++index)
          {
            long position = er.BaseStream.Position;
            er.BaseStream.Position = (long) this.Dictionaries[0][index].DataOffset;
            this.Models[index] = new CMDL(er);
            er.BaseStream.Position = position;
          }
        }
        if (this.Dictionaries[1] != null)
        {
          this.Textures = new ImageTextureCtr[this.Dictionaries[1].Count];
          for (int index = 0; index < this.Dictionaries[1].Count; ++index)
          {
            long position = er.BaseStream.Position;
            er.BaseStream.Position = (long) this.Dictionaries[1][index].DataOffset;
            this.Textures[index] = (ImageTextureCtr) TXOB.FromStream(er);
            er.BaseStream.Position = position;
          }
        }
        if (this.Dictionaries[9] != null)
        {
          this.SkeletonAnimations = new CANM[this.Dictionaries[9].Count];
          for (int index = 0; index < this.Dictionaries[9].Count; ++index)
          {
            long position = er.BaseStream.Position;
            er.BaseStream.Position = (long) this.Dictionaries[9][index].DataOffset;
            this.SkeletonAnimations[index] = new CANM(er);
            er.BaseStream.Position = position;
          }
        }
        if (this.Dictionaries[10] != null)
        {
          this.MaterialAnimations = new CANM[this.Dictionaries[10].Count];
          for (int index = 0; index < this.Dictionaries[10].Count; ++index)
          {
            long position = er.BaseStream.Position;
            er.BaseStream.Position = (long) this.Dictionaries[10][index].DataOffset;
            this.MaterialAnimations[index] = new CANM(er);
            er.BaseStream.Position = position;
          }
        }
        if (this.Dictionaries[11] == null)
          return;
        this.VisibilityAnimations = new CANM[this.Dictionaries[11].Count];
        for (int index = 0; index < this.Dictionaries[11].Count; ++index)
        {
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.Dictionaries[11][index].DataOffset;
          this.VisibilityAnimations[index] = new CANM(er);
          er.BaseStream.Position = position;
        }
      }

      public void Write(EndianBinaryWriter er, CGFXWriterContext c)
      {
        long position1 = er.BaseStream.Position;
        er.Write(this.Signature, Encoding.ASCII, false);
        er.Write(this.SectionSize);
        for (int index = 0; index < 16; ++index)
        {
          long position2 = er.BaseStream.Position;
          if (this.Dictionaries[index] != null && (index == 0 || index == 1))
          {
            long position3 = er.BaseStream.Position;
            er.Write((uint) this.Dictionaries[index].Count);
            er.Write(0U);
          }
          else if (index == 9)
          {
            er.Write(1U);
          }
          else
          {
            er.Write(0U);
            er.Write(0U);
          }
        }
        long[] numArray = new long[16];
        for (int index = 0; index < 16; ++index)
        {
          if (this.Dictionaries[index] != null && (index == 0 || index == 1))
          {
            numArray[index] = er.BaseStream.Position;
            er.BaseStream.Position = position1 + 8L + (long) (index * 8) + 4L;
            er.Write((uint) (numArray[index] - (position1 + 16L + (long) (index * 8) + 4L)));
            er.BaseStream.Position = numArray[index];
            this.Dictionaries[index].Write(er, c);
          }
        }
        if (this.Dictionaries[0] != null)
        {
          for (int index = 0; index < this.Dictionaries[0].Count; ++index)
          {
            long position2 = er.BaseStream.Position;
            long num = er.BaseStream.Position = numArray[0] + 28L + (long) (index * 16) + 12L;
            er.Write((uint) (position2 - num));
            er.BaseStream.Position = position2;
            this.Models[index].Write(er, c);
          }
        }
        if (this.Dictionaries[1] != null)
        {
          for (int index = 0; index < this.Dictionaries[1].Count; ++index)
          {
            long position2 = er.BaseStream.Position;
            long num = er.BaseStream.Position = numArray[1] + 28L + (long) (index * 16) + 12L;
            er.Write((uint) (position2 - num));
            er.BaseStream.Position = position2;
            this.Textures[index].Write(er, c);
          }
        }
        c.WriteStringTable(er);
        if (c.DoWriteIMAGBlock())
        {
          int imagBlockSize = c.GetIMAGBlockSize();
          while ((er.BaseStream.Position + (long) imagBlockSize) % 64L != 0L)
            er.Write((byte) 0);
        }
        long position4 = er.BaseStream.Position;
        er.BaseStream.Position = position4;
      }

      public class DictionaryInfo
      {
        public uint NrItems;
        public uint Offset;

        public DictionaryInfo(EndianBinaryReader er)
        {
          this.NrItems = er.ReadUInt32();
          long position = er.BaseStream.Position;
          this.Offset = er.ReadUInt32();
          if ((int) this.Offset == 0)
            return;
          this.Offset = this.Offset + (uint) position;
        }
      }
    }
  }
}
