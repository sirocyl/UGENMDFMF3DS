// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.Vector3TypeConverter
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.ComponentModel;
using System.Globalization;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class Vector3TypeConverter : ValueTypeTypeConverter
  {
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (!(value.GetType() == typeof (string)))
        return base.ConvertFrom(context, culture, value);
      string str = ((string) value).Trim('(', ')', ' ');
      char[] chArray = new char[1];
      int index = 0;
      int num = 59;
      chArray[index] = (char) num;
      string[] strArray = str.Split(chArray);
      if (strArray.Length != 3)
        throw new Exception("Wrong formatting!");
      return (object) new Vector3(float.Parse(strArray[0]), float.Parse(strArray[1]), float.Parse(strArray[2]));
    }
  }
}
