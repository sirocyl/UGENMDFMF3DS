// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.MTL
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class MTL
  {
    public List<MTL.MTLMaterial> Materials;

    public MTL()
    {
      this.Materials = new List<MTL.MTLMaterial>();
    }

    public MTL(byte[] Data)
    {
      CultureInfo cultureInfo = new CultureInfo("en-US");
      this.Materials = new List<MTL.MTLMaterial>();
      MTL.MTLMaterial mtlMaterial = (MTL.MTLMaterial) null;
      TextReader textReader = (TextReader) new StreamReader((Stream) new MemoryStream(Data));
      string str1;
      while ((str1 = textReader.ReadLine()) != null)
      {
        string str2 = str1.Trim();
        if (str2.Length >= 1 && !str2.StartsWith("#"))
        {
          string str3 = str2;
          char[] separator = new char[1];
          int index = 0;
          int num1 = 32;
          separator[index] = (char) num1;
          int num2 = 1;
          string[] strArray = str3.Split(separator, (StringSplitOptions) num2);
          if (strArray.Length >= 1)
          {
            string str4 = strArray[0];
            if (!(str4 == "newmtl"))
            {
              if (!(str4 == "Ka"))
              {
                if (!(str4 == "Kd"))
                {
                  if (!(str4 == "Ks"))
                  {
                    if (!(str4 == "d"))
                    {
                      if (str4 == "map_Kd")
                        mtlMaterial.DiffuseMapPath = str2.Substring(strArray[0].Length + 1).Trim();
                    }
                    else if (strArray.Length >= 2)
                      mtlMaterial.Alpha = float.Parse(strArray[1], (IFormatProvider) cultureInfo);
                  }
                  else if (strArray.Length >= 4)
                  {
                    float num3 = float.Parse(strArray[1], (IFormatProvider) cultureInfo);
                    float num4 = float.Parse(strArray[2], (IFormatProvider) cultureInfo);
                    float num5 = float.Parse(strArray[3], (IFormatProvider) cultureInfo);
                    mtlMaterial.SpecularColor = Color.FromArgb((int) ((double) num3 * (double) byte.MaxValue), (int) ((double) num4 * (double) byte.MaxValue), (int) ((double) num5 * (double) byte.MaxValue));
                  }
                }
                else if (strArray.Length >= 4)
                {
                  float num3 = float.Parse(strArray[1], (IFormatProvider) cultureInfo);
                  float num4 = float.Parse(strArray[2], (IFormatProvider) cultureInfo);
                  float num5 = float.Parse(strArray[3], (IFormatProvider) cultureInfo);
                  mtlMaterial.DiffuseColor = Color.FromArgb((int) ((double) num3 * (double) byte.MaxValue), (int) ((double) num4 * (double) byte.MaxValue), (int) ((double) num5 * (double) byte.MaxValue));
                }
              }
              else if (strArray.Length >= 4)
              {
                float num3 = float.Parse(strArray[1], (IFormatProvider) cultureInfo);
                float num4 = float.Parse(strArray[2], (IFormatProvider) cultureInfo);
                float num5 = float.Parse(strArray[3], (IFormatProvider) cultureInfo);
                mtlMaterial.AmbientColor = Color.FromArgb((int) ((double) num3 * (double) byte.MaxValue), (int) ((double) num4 * (double) byte.MaxValue), (int) ((double) num5 * (double) byte.MaxValue));
              }
            }
            else if (strArray.Length >= 2)
            {
              if (mtlMaterial != null)
                this.Materials.Add(mtlMaterial);
              mtlMaterial = new MTL.MTLMaterial(strArray[1]);
            }
          }
        }
      }
      if (mtlMaterial != null && !this.Materials.Contains(mtlMaterial))
        this.Materials.Add(mtlMaterial);
      textReader.Close();
    }

    public string GetSaveDefaultFileFilter()
    {
      return "Material Library (*.mtl)|*.mtl";
    }

    public byte[] Write()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("# Created by Every File Explorer");
      stringBuilder.AppendLine();
      foreach (MTL.MTLMaterial mtlMaterial in this.Materials)
      {
        stringBuilder.AppendFormat("newmtl {0}\n", (object) mtlMaterial.Name);
        stringBuilder.AppendFormat("Ka {0} {1} {2}\n", (object) ((float) mtlMaterial.AmbientColor.R / (float) byte.MaxValue).ToString().Replace(",", "."), (object) ((float) mtlMaterial.AmbientColor.G / (float) byte.MaxValue).ToString().Replace(",", "."), (object) ((float) mtlMaterial.AmbientColor.B / (float) byte.MaxValue).ToString().Replace(",", "."));
        stringBuilder.AppendFormat("Kd {0} {1} {2}\n", (object) ((float) mtlMaterial.DiffuseColor.R / (float) byte.MaxValue).ToString().Replace(",", "."), (object) ((float) mtlMaterial.DiffuseColor.G / (float) byte.MaxValue).ToString().Replace(",", "."), (object) ((float) mtlMaterial.DiffuseColor.B / (float) byte.MaxValue).ToString().Replace(",", "."));
        stringBuilder.AppendFormat("Ks {0} {1} {2}\n", (object) ((float) mtlMaterial.SpecularColor.R / (float) byte.MaxValue).ToString().Replace(",", "."), (object) ((float) mtlMaterial.SpecularColor.G / (float) byte.MaxValue).ToString().Replace(",", "."), (object) ((float) mtlMaterial.SpecularColor.B / (float) byte.MaxValue).ToString().Replace(",", "."));
        stringBuilder.AppendFormat("d {0}\n", (object) mtlMaterial.Alpha.ToString().Replace(",", "."));
        if (mtlMaterial.DiffuseMapPath != null)
          stringBuilder.AppendFormat("map_Kd {0}\n", (object) mtlMaterial.DiffuseMapPath);
        stringBuilder.AppendLine();
      }
      return Encoding.ASCII.GetBytes(stringBuilder.ToString());
    }

    public MTL.MTLMaterial GetMaterialByName(string Name)
    {
      foreach (MTL.MTLMaterial mtlMaterial in this.Materials)
      {
        if (mtlMaterial.Name == Name)
          return mtlMaterial;
      }
      return (MTL.MTLMaterial) null;
    }

    public class MTLMaterial
    {
      public float Alpha = 1f;
      public string Name;
      public Color DiffuseColor;
      public Color AmbientColor;
      public Color SpecularColor;
      public string DiffuseMapPath;

      public MTLMaterial(string Name)
      {
        this.Name = Name;
      }

      public override string ToString()
      {
        return this.Name;
      }
    }
  }
}
