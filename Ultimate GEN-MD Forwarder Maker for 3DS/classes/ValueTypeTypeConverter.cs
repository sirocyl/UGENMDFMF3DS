// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.ValueTypeTypeConverter
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class ValueTypeTypeConverter : ExpandableObjectConverter
  {
    public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
    {
      if (propertyValues == null)
        throw new ArgumentNullException("propertyValues");
      object instance = Activator.CreateInstance(context.PropertyDescriptor.PropertyType);
      foreach (DictionaryEntry dictionaryEntry in propertyValues)
      {
        PropertyInfo property = context.PropertyDescriptor.PropertyType.GetProperty(dictionaryEntry.Key.ToString());
        if (property != (PropertyInfo) null && property.CanWrite)
          property.SetValue(instance, Convert.ChangeType(dictionaryEntry.Value, property.PropertyType), (object[]) null);
      }
      return instance;
    }
  }
}
