// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.ImageTextureCtr
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.Drawing;
using Ultimate_GEN_MD_Forwarder_Maker_for_3DS;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class ImageTextureCtr : PixelBasedTexture
  {
    public uint TextureImageOffset;
    public ImageTextureCtr.PixelBasedImageCtr TextureImage;

    public ImageTextureCtr(string Name, Bitmap Tex, Textures.ImageFormat Format)
    {
      this.Type = 536870929U;
      this.Name = Name;
      this.Width = (uint) Tex.Width;
      this.Height = (uint) Tex.Height;
      this.HWFormat = Format;
      this.GLFormat = PixelBasedTexture.GLFormats[(int) Format];
      this.GLType = PixelBasedTexture.GLTypes[(int) Format];
      this.NrLevels = 1U;
      this.TextureImage = new ImageTextureCtr.PixelBasedImageCtr(Tex, Format);
    }

    public ImageTextureCtr(EndianBinaryReader er)
      : base(er)
    {
      this.TextureImageOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      long position = er.BaseStream.Position;
      er.BaseStream.Position = (long) this.TextureImageOffset;
      this.TextureImage = new ImageTextureCtr.PixelBasedImageCtr(er);
      er.BaseStream.Position = position;
    }

    public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
    {
      base.Write(er, c);
      if (this.TextureImage != null)
        er.Write(4U);
      else
        er.Write(0U);
      if (this.TextureImage == null)
        return;
      this.TextureImage.Write(er, c);
    }

    public Bitmap GetBitmap(int Level = 0)
    {
      int num1 = Level;
      uint num2 = this.Width;
      uint num3 = this.Height;
      int bpp = Textures.GetBpp(this.HWFormat);
      int Offset = 0;
      for (; num1 > 0; --num1)
      {
        Offset += (int) ((long) (num2 * num3) * (long) bpp / 8L);
        num2 /= 2U;
        num3 /= 2U;
      }
      return Textures.ToBitmap(this.TextureImage.Data, Offset, (int) num2, (int) num3, this.HWFormat, false);
    }

    public void SetBitmap(Bitmap bmp)
    {
      this.TextureImage.Data = Textures.FromBitmap(bmp, this.HWFormat, false);
    }

    public class PixelBasedImageCtr
    {
      public uint Height;
      public uint Width;
      public uint DataSize;
      public uint DataOffset;
      public uint DynamicAllocator;
      public uint BitsPerPixel;
      public uint LocationAddress;
      public uint MemoryAddress;
      public byte[] Data;

      public PixelBasedImageCtr(Bitmap Tex, Textures.ImageFormat Format)
      {
        this.Width = (uint) Tex.Width;
        this.Height = (uint) Tex.Height;
        this.BitsPerPixel = (uint) Textures.GetBpp(Format);
        this.Data = Textures.FromBitmap(Tex, Format, false);
        this.DataSize = (uint) this.Data.Length;
      }

      public PixelBasedImageCtr(EndianBinaryReader er)
      {
        this.Height = er.ReadUInt32();
        this.Width = er.ReadUInt32();
        this.DataSize = er.ReadUInt32();
        this.DataOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.DynamicAllocator = er.ReadUInt32();
        this.BitsPerPixel = er.ReadUInt32();
        this.LocationAddress = er.ReadUInt32();
        this.MemoryAddress = er.ReadUInt32();
        long position = er.BaseStream.Position;
        er.BaseStream.Position = (long) this.DataOffset;
        this.Data = er.ReadBytes((int) this.DataSize);
        er.BaseStream.Position = position;
      }

      public void Write(EndianBinaryWriter er, CGFXWriterContext c)
      {
        er.Write(this.Height);
        er.Write(this.Width);
        er.Write(this.DataSize);
        c.WriteDataReference(this.Data, er);
        er.Write(this.DynamicAllocator);
        er.Write(this.BitsPerPixel);
        er.Write(this.LocationAddress);
        er.Write(this.MemoryAddress);
      }
    }
  }
}
