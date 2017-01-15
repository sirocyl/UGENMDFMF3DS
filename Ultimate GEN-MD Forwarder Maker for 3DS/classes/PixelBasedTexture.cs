// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.PixelBasedTexture
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using Ultimate_GEN_MD_Forwarder_Maker_for_3DS;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class PixelBasedTexture : TXOB
  {
    protected static readonly uint[] GLFormats = new uint[14]
    {
      26450U,
      26452U,
      26450U,
      26452U,
      26450U,
      26456U,
      26457U,
      26455U,
      26454U,
      26456U,
      26455U,
      26454U,
      26458U,
      26459U
    };
    protected static readonly uint[] GLTypes = new uint[14]
    {
      5121U,
      5121U,
      32820U,
      33635U,
      32819U,
      5121U,
      5121U,
      5121U,
      5121U,
      26464U,
      26465U,
      26465U,
      0U,
      0U
    };
    public uint Height;
    public uint Width;
    public uint GLFormat;
    public uint GLType;
    public uint NrLevels;
    public uint TextureObject;
    public uint LocationFlag;
    public Textures.ImageFormat HWFormat;

    public PixelBasedTexture()
    {
    }

    public PixelBasedTexture(EndianBinaryReader er)
      : base(er)
    {
      this.Height = er.ReadUInt32();
      this.Width = er.ReadUInt32();
      this.GLFormat = er.ReadUInt32();
      this.GLType = er.ReadUInt32();
      this.NrLevels = er.ReadUInt32();
      this.TextureObject = er.ReadUInt32();
      this.LocationFlag = er.ReadUInt32();
      this.HWFormat = (Textures.ImageFormat) er.ReadUInt32();
    }

    public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
    {
      base.Write(er, c);
      er.Write(this.Height);
      er.Write(this.Width);
      er.Write(this.GLFormat);
      er.Write(this.GLType);
      er.Write(this.NrLevels);
      er.Write(this.TextureObject);
      er.Write(this.LocationFlag);
      er.Write((uint) this.HWFormat);
    }
  }
}
