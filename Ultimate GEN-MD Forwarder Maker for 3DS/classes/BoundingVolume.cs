// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.BoundingVolume
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class BoundingVolume
  {
    public uint Type;

    public BoundingVolume()
    {
    }

    public BoundingVolume(EndianBinaryReader er)
    {
      this.Type = er.ReadUInt32();
    }

    public virtual void Write(EndianBinaryWriter er)
    {
      er.Write(this.Type);
    }

    public static BoundingVolume FromStream(EndianBinaryReader er)
    {
      uint num = er.ReadUInt32();
      er.BaseStream.Position -= 4L;
      if ((int) num == int.MinValue)
        return (BoundingVolume) new OrientedBoundingBox(er);
      return new BoundingVolume(er);
    }
  }
}
