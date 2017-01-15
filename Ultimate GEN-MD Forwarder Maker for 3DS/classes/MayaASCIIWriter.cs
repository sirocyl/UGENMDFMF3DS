// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.MayaASCIIWriter
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.IO;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class MayaASCIIWriter
  {
    private StringWriter mWriter;

    public MayaASCIIWriter()
    {
      this.mWriter = new StringWriter();
      this.WriteComment("Maya ASCII 3.0 scene");
      this.WriteComment("Created by Every File Explorer");
      this.mWriter.WriteLine();
      this.BeginStatement("requires");
      this.WriteArgument("maya", "\"3.0\"");
      this.EndStatement();
      this.BeginStatement("currentUnit");
      this.WriteArgument("-l", "centimeter");
      this.WriteArgument("-a", "degree");
      this.WriteArgument("-t", "film");
      this.EndStatement();
    }

    public void WriteComment(string comment)
    {
      this.mWriter.WriteLine("//" + comment);
    }

    public void BeginStatement(string keyword)
    {
      this.mWriter.Write(keyword);
    }

    public void WriteArgument(int val)
    {
      this.WriteArgument(val.ToString());
    }

    public void WriteArgument(float val)
    {
      this.WriteArgument(val.ToString().Replace(",", "."));
    }

    public void WriteArgument(string arg)
    {
      this.mWriter.Write(" " + arg);
    }

    public void WriteArgument(string arg, int val)
    {
      this.WriteArgument(arg, val.ToString());
    }

    public void WriteArgument(string arg, float val)
    {
      this.WriteArgument(arg, val.ToString().Replace(",", "."));
    }

    public void WriteArgument(string arg, string val)
    {
      this.mWriter.Write(" " + arg + " " + val);
    }

    public void EndStatement()
    {
      this.mWriter.WriteLine(";");
    }

    public void CreateNode(string Type, string Name)
    {
      this.CreateNode(Type, Name, (string) null, false, false);
    }

    public void CreateNode(string Type, string Name, bool Shared)
    {
      this.CreateNode(Type, Name, (string) null, Shared, false);
    }

    public void CreateNode(string Type, string Name, string Parent)
    {
      this.CreateNode(Type, Name, Parent, false, false);
    }

    public void CreateNode(string Type, string Name, string Parent, bool Shared)
    {
      this.CreateNode(Type, Name, Parent, Shared, false);
    }

    public void CreateNode(string Type, string Name, string Parent, bool Shared, bool SkipSelect)
    {
      this.BeginStatement("createNode");
      this.WriteArgument(Type);
      this.WriteArgument("-n", "\"" + Name + "\"");
      if (Parent != null)
        this.WriteArgument("-p", "\"" + Parent + "\"");
      if (Shared)
        this.WriteArgument("-s");
      if (SkipSelect)
        this.WriteArgument("-ss");
      this.EndStatement();
    }

    public void ConnectAttribute(string FirstNode, string SecondNode)
    {
      this.ConnectAttribute(FirstNode, SecondNode, false);
    }

    public void ConnectAttribute(string FirstNode, string SecondNode, bool NextAvailable)
    {
      this.BeginStatement("connectAttr");
      this.WriteArgument("\"" + FirstNode + "\"");
      this.WriteArgument("\"" + SecondNode + "\"");
      if (NextAvailable)
        this.WriteArgument("-na");
      this.EndStatement();
    }

    public string Close()
    {
      this.mWriter.Flush();
      string str = this.mWriter.ToString();
      this.mWriter.Close();
      return str;
    }
  }
}
