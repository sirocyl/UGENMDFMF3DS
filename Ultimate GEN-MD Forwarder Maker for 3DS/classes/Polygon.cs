// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.Polygon
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.Drawing;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class Polygon
  {
    public PolygonType PolyType;
    public Vector3[] Normals;
    public Vector2[] TexCoords;
    public Vector2[] TexCoords2;
    public Vector2[] TexCoords3;
    public Vector3[] Vertex;
    public Color[] Colors;

    public Polygon()
    {
    }

    public Polygon(PolygonType PolyType, Vector3[] Vertex, Vector3[] Normals, Vector2[] TexCoords, Color[] Colors = null)
    {
      this.PolyType = PolyType;
      this.Normals = Normals;
      this.TexCoords = TexCoords;
      this.Vertex = Vertex;
      this.Colors = Colors;
    }
  }
}
