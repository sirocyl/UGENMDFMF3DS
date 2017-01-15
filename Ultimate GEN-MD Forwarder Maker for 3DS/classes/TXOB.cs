// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.TXOB
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class TXOB
  {
    public uint Type;
    public string Signature;
    public uint Revision;
    public uint NameOffset;
    public uint Unknown2;
    public uint Unknown3;
    public string Name;

    public TXOB()
    {
      this.Signature = "TXOB";
      this.Revision = 83886080U;
      this.Name = "";
    }

    public TXOB(EndianBinaryReader er)
    {
      this.Type = er.ReadUInt32();
      this.Signature = er.ReadString(Encoding.ASCII, 4);
      if (this.Signature != "TXOB")
        throw new SignatureNotCorrectException(this.Signature, "TXOB", er.BaseStream.Position);
      this.Revision = er.ReadUInt32();
      this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      this.Unknown2 = er.ReadUInt32();
      this.Unknown3 = er.ReadUInt32();
      long position = er.BaseStream.Position;
      er.BaseStream.Position = (long) this.NameOffset;
      this.Name = er.ReadStringNT(Encoding.ASCII);
      er.BaseStream.Position = position;
    }

    public virtual void Write(EndianBinaryWriter er, CGFXWriterContext c)
    {
      er.Write(this.Type);
      er.Write(this.Signature, Encoding.ASCII, false);
      er.Write(this.Revision);
      c.WriteStringReference(this.Name, er);
      er.Write(this.Unknown2);
      er.Write(this.Unknown3);
    }

    public static TXOB FromStream(EndianBinaryReader er)
    {
      uint num = er.ReadUInt32();
      er.BaseStream.Position -= 4L;
      if ((int) num == 536870916)
        return (TXOB) new ReferenceTexture(er);
      if ((int) num == 536870929)
        return (TXOB) new ImageTextureCtr(er);
      return new TXOB(er);
    }

    public override string ToString()
    {
      return this.Name;
    }
  }
}
