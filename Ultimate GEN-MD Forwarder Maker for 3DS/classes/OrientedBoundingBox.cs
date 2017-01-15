// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.OrientedBoundingBox
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class OrientedBoundingBox : BoundingVolume
  {
    public Vector3 CenterPosition;
    public float[] OrientationMatrix;
    public Vector3 Size;

    public OrientedBoundingBox()
    {
      this.Type = (uint)0xFFFFFFFF;
      this.CenterPosition = new Vector3(0.0f, 0.0f, 0.0f);
      this.OrientationMatrix = new float[9]
      {
        1f,
        0.0f,
        0.0f,
        0.0f,
        1f,
        0.0f,
        0.0f,
        0.0f,
        1f
      };
      this.Size = new Vector3(1f, 1f, 1f);
    }

    public OrientedBoundingBox(EndianBinaryReader er)
      : base(er)
    {
      this.CenterPosition = er.ReadVector3();
      this.OrientationMatrix = er.ReadSingles(9);
      this.Size = er.ReadVector3();
    }

    public override void Write(EndianBinaryWriter er)
    {
      base.Write(er);
      er.WriteVector3(this.CenterPosition);
      er.Write(this.OrientationMatrix, 0, 9);
      er.WriteVector3(this.Size);
    }
  }
}
