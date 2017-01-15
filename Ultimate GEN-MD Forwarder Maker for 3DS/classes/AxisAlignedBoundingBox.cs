// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.AxisAlignedBoundingBox
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class AxisAlignedBoundingBox : BoundingVolume
  {
    public Vector3 CenterPosition;
    public Vector3 Size;

    public AxisAlignedBoundingBox(EndianBinaryReader er)
      : base(er)
    {
      this.CenterPosition = er.ReadVector3();
      this.Size = er.ReadVector3();
    }

    public override void Write(EndianBinaryWriter er)
    {
      base.Write(er);
      er.WriteVector3(this.CenterPosition);
      er.WriteVector3(this.Size);
    }
  }
}
