// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.OBJ
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class OBJ
  {
    public string MTLPath;
    public List<Vector3> Vertices;
    public List<Vector3> Normals;
    public List<Vector2> TexCoords;
    public List<OBJ.OBJFace> Faces;

    public OBJ()
    {
      this.Vertices = new List<Vector3>();
      this.Normals = new List<Vector3>();
      this.TexCoords = new List<Vector2>();
      this.Faces = new List<OBJ.OBJFace>();
    }

    public OBJ(byte[] Data)
    {
      CultureInfo cultureInfo = new CultureInfo("en-US");
      string str1 = (string) null;
      this.Vertices = new List<Vector3>();
      this.Normals = new List<Vector3>();
      this.TexCoords = new List<Vector2>();
      this.Faces = new List<OBJ.OBJFace>();
      TextReader textReader = (TextReader) new StreamReader((Stream) new MemoryStream(Data));
      string str2;
      while ((str2 = textReader.ReadLine()) != null)
      {
        string str3 = str2.Trim();
        if (str3.Length >= 1 && !str3.StartsWith("#"))
        {
          string str4 = str3;
          char[] separator = new char[1];
          int index1 = 0;
          int num1 = 32;
          separator[index1] = (char) num1;
          int num2 = 1;
          string[] strArray1 = str4.Split(separator, (StringSplitOptions) num2);
          if (strArray1.Length >= 1)
          {
            string str5 = strArray1[0];
            if (!(str5 == "mtllib"))
            {
              if (!(str5 == "usemtl"))
              {
                if (!(str5 == "v"))
                {
                  if (!(str5 == "vn"))
                  {
                    if (!(str5 == "vt"))
                    {
                      if (str5 == "f" && strArray1.Length >= 4)
                      {
                        OBJ.OBJFace objFace = new OBJ.OBJFace();
                        objFace.Material = str1;
                        for (int index2 = 0; index2 < strArray1.Length - 1; ++index2)
                        {
                          string str6 = strArray1[index2 + 1];
                          char[] chArray = new char[1];
                          int index3 = 0;
                          int num3 = 47;
                          chArray[index3] = (char) num3;
                          string[] strArray2 = str6.Split(chArray);
                          objFace.VertexIndieces.Add(int.Parse(strArray2[0]) - 1);
                          if (strArray2.Length > 1)
                          {
                            if (strArray2[1] != "")
                              objFace.TexCoordIndieces.Add(int.Parse(strArray2[1]) - 1);
                            if (strArray2.Length > 2 && strArray2[2] != "")
                              objFace.NormalIndieces.Add(int.Parse(strArray2[2]) - 1);
                          }
                        }
                        this.Faces.Add(objFace);
                      }
                    }
                    else if (strArray1.Length >= 3)
                      this.TexCoords.Add(new Vector2(float.Parse(strArray1[1], (IFormatProvider) cultureInfo), float.Parse(strArray1[2], (IFormatProvider) cultureInfo)));
                  }
                  else if (strArray1.Length >= 4)
                    this.Normals.Add(new Vector3(float.Parse(strArray1[1], (IFormatProvider) cultureInfo), float.Parse(strArray1[2], (IFormatProvider) cultureInfo), float.Parse(strArray1[3], (IFormatProvider) cultureInfo)));
                }
                else if (strArray1.Length >= 4)
                  this.Vertices.Add(new Vector3(float.Parse(strArray1[1], (IFormatProvider) cultureInfo), float.Parse(strArray1[2], (IFormatProvider) cultureInfo), float.Parse(strArray1[3], (IFormatProvider) cultureInfo)));
              }
              else if (strArray1.Length >= 2)
                str1 = strArray1[1];
            }
            else if (strArray1.Length >= 2)
              this.MTLPath = str3.Substring(strArray1[0].Length + 1).Trim();
          }
        }
      }
      textReader.Close();
    }

    public string GetSaveDefaultFileFilter()
    {
      return "Wavefront OBJ File (*.obj)|*.obj";
    }

    public byte[] Write()
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.AppendLine("# Created by Every File Explorer");
      stringBuilder1.AppendLine();
      if (this.MTLPath != null)
        stringBuilder1.AppendFormat("mtllib {0}\n", (object) this.MTLPath);
      stringBuilder1.AppendLine();
      foreach (Vector3 vector3 in this.Vertices)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        string format = "v {0} {1} {2}\n";
        float num = vector3.X;
        string str1 = num.ToString().Replace(",", ".");
        num = vector3.Y;
        string str2 = num.ToString().Replace(",", ".");
        num = vector3.Z;
        string str3 = num.ToString().Replace(",", ".");
        stringBuilder2.AppendFormat(format, (object) str1, (object) str2, (object) str3);
      }
      stringBuilder1.AppendLine();
      foreach (Vector3 vector3 in this.Normals)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        string format = "vn {0} {1} {2}\n";
        float num = vector3.X;
        string str1 = num.ToString().Replace(",", ".");
        num = vector3.Y;
        string str2 = num.ToString().Replace(",", ".");
        num = vector3.Z;
        string str3 = num.ToString().Replace(",", ".");
        stringBuilder2.AppendFormat(format, (object) str1, (object) str2, (object) str3);
      }
      stringBuilder1.AppendLine();
      foreach (Vector2 vector2 in this.TexCoords)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        string format = "vt {0} {1}\n";
        float num = vector2.X;
        string str1 = num.ToString().Replace(",", ".");
        num = vector2.Y;
        string str2 = num.ToString().Replace(",", ".");
        stringBuilder2.AppendFormat(format, (object) str1, (object) str2);
      }
      stringBuilder1.AppendLine();
      string str = (string) null;
      foreach (OBJ.OBJFace objFace in this.Faces)
      {
        bool flag1 = (uint) objFace.VertexIndieces.Count > 0U;
        bool flag2 = objFace.NormalIndieces.Count != 0 && objFace.NormalIndieces.Count == objFace.VertexIndieces.Count;
        bool flag3 = objFace.TexCoordIndieces.Count != 0 && objFace.TexCoordIndieces.Count == objFace.VertexIndieces.Count;
        if (!flag1)
          throw new Exception("Face has no vertex entries!");
        if (str != objFace.Material)
        {
          stringBuilder1.AppendFormat("usemtl {0}\n", (object) objFace.Material);
          stringBuilder1.AppendLine();
          str = objFace.Material;
        }
        stringBuilder1.Append("f");
        int count = objFace.VertexIndieces.Count;
        for (int index = 0; index < count; ++index)
        {
          if (flag1 & flag2 & flag3)
            stringBuilder1.AppendFormat(" {0}/{1}/{2}", (object) (objFace.VertexIndieces[index] + 1), (object) (objFace.TexCoordIndieces[index] + 1), (object) (objFace.NormalIndieces[index] + 1));
          else if (flag1 & flag3)
            stringBuilder1.AppendFormat(" {0}/{1}", (object) (objFace.VertexIndieces[index] + 1), (object) (objFace.TexCoordIndieces[index] + 1));
          else if (flag1 & flag2)
            stringBuilder1.AppendFormat(" {0}//{1}", (object) (objFace.VertexIndieces[index] + 1), (object) (objFace.NormalIndieces[index] + 1));
          else
            stringBuilder1.AppendFormat(" {0}", (object) (objFace.VertexIndieces[index] + 1));
        }
        stringBuilder1.AppendLine();
      }
      return Encoding.ASCII.GetBytes(stringBuilder1.ToString());
    }

    public class OBJFace
    {
      public List<int> VertexIndieces;
      public List<int> NormalIndieces;
      public List<int> TexCoordIndieces;
      public string Material;

      public OBJFace()
      {
        this.VertexIndieces = new List<int>();
        this.NormalIndieces = new List<int>();
        this.TexCoordIndieces = new List<int>();
      }
    }
  }
}
