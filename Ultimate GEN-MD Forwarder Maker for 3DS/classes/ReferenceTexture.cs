// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.ReferenceTexture
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class ReferenceTexture : TXOB
  {
    public uint LinkedTextureNameOffset;
    public uint LinkedTextureOffset;
    public string LinkedTextureName;

    public ReferenceTexture(string RefTex)
    {
      this.Type = 536870916U;
      this.LinkedTextureName = RefTex;
    }

    public ReferenceTexture(EndianBinaryReader er)
      : base(er)
    {
      this.LinkedTextureNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      this.LinkedTextureOffset = er.ReadUInt32();
      if ((int) this.LinkedTextureOffset != 0)
        this.LinkedTextureOffset = this.LinkedTextureOffset + ((uint) er.BaseStream.Position - 4U);
      long position = er.BaseStream.Position;
      er.BaseStream.Position = (long) this.LinkedTextureNameOffset;
      this.LinkedTextureName = er.ReadStringNT(Encoding.ASCII);
      er.BaseStream.Position = position;
    }

    public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
    {
      base.Write(er, c);
      c.WriteStringReference(this.LinkedTextureName, er);
      if ((int) this.LinkedTextureOffset == 0)
        er.Write(0U);
      else
        er.Write(0U);
    }
  }
}
