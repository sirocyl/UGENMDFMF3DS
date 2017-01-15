// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.DICT
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.Collections.Generic;
using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class DICT
  {
    private string Signature;
    private uint SectionSize;
    private uint NrEntries;
    private DICT.Node RootNode;
    private List<DICT.Node> Entries;

    public int Count
    {
      get
      {
        return this.Entries.Count;
      }
    }

    public DICT.Node this[int index]
    {
      get
      {
        return this.Entries[index];
      }
      set
      {
        this.Entries[index] = value;
        this.RegenerateTree();
      }
    }

    public DICT.Node this[string index]
    {
      get
      {
        return this.Entries[this.IndexOf(index)];
      }
      set
      {
        this.Entries[this.IndexOf(index)] = value;
        this.RegenerateTree();
      }
    }

    public DICT()
    {
      this.Signature = "DICT";
      this.RootNode = new DICT.Node();
      this.Entries = new List<DICT.Node>();
    }

    public DICT(EndianBinaryReader er)
    {
      this.Signature = er.ReadString(Encoding.ASCII, 4);
      if (this.Signature != "DICT")
        throw new SignatureNotCorrectException(this.Signature, "DICT", er.BaseStream.Position);
      this.SectionSize = er.ReadUInt32();
      this.NrEntries = er.ReadUInt32();
      this.RootNode = new DICT.Node(er);
      this.Entries = new List<DICT.Node>();
      for (int index = 0; (long) index < (long) this.NrEntries; ++index)
        this.Entries.Add(new DICT.Node(er));
    }

    public void Write(EndianBinaryWriter er, CGFXWriterContext c)
    {
      long position1 = er.BaseStream.Position;
      er.Write(this.Signature, Encoding.ASCII, false);
      er.Write(0U);
      er.Write((uint) this.Entries.Count);
      this.RootNode.Write(er, c);
      foreach (DICT.Node node in this.Entries)
        node.Write(er, c);
      long position2 = er.BaseStream.Position;
      er.BaseStream.Position = position1 + 4L;
      er.Write((uint) (position2 - position1));
      er.BaseStream.Position = position2;
    }

    public int IndexOf(uint Offset)
    {
      for (int index = 0; (long) index < (long) this.NrEntries; ++index)
      {
        if ((int) this.Entries[index].DataOffset == (int) Offset)
          return index;
      }
      return -1;
    }

    public int IndexOf(string Name)
    {
      for (int index = 0; (long) index < (long) this.NrEntries; ++index)
      {
        if (this.Entries[index].Name == Name)
          return index;
      }
      return -1;
    }

    public void Add(string Name)
    {
      List<DICT.Node> list = this.Entries;
      DICT.Node node = new DICT.Node();
      string str = Name;
      node.Name = str;
      list.Add(node);
      this.NrEntries = (uint) this.Entries.Count;
      this.RegenerateTree();
    }

    public void Remove(DICT.Node Entry)
    {
      this.Entries.Remove(Entry);
      this.NrEntries = (uint) this.Entries.Count;
      this.RegenerateTree();
    }

    public void RemoveAt(int Index)
    {
      this.Entries.RemoveAt(Index);
      this.RegenerateTree();
    }

    private void RegenerateTree()
    {
      List<string> list = new List<string>();
      foreach (DICT.Node node in this.Entries)
        list.Add(node.Name);
      PatriciaTreeGenerator patriciaTreeGenerator = PatriciaTreeGenerator.Generate(list.ToArray());
      bool flag = true;
      foreach (PatriciaTreeGenerator.PatTreeNode patTreeNode in patriciaTreeGenerator.TreeNodes)
      {
        if (flag)
        {
          patTreeNode.idxEntry = -1;
          this.RootNode.LeftIndex = (ushort) (patTreeNode.left.idxEntry + 1);
          this.RootNode.RightIndex = (ushort) (patTreeNode.right.idxEntry + 1);
          this.RootNode.RefBit = uint.MaxValue;
          flag = false;
        }
        else
        {
          this.Entries[patTreeNode.idxEntry].LeftIndex = (ushort) (patTreeNode.left.idxEntry + 1);
          this.Entries[patTreeNode.idxEntry].RightIndex = (ushort) (patTreeNode.right.idxEntry + 1);
          this.Entries[patTreeNode.idxEntry].RefBit = patTreeNode.refbit;
        }
      }
    }

    public class Node
    {
      public uint RefBit;
      public ushort LeftIndex;
      public ushort RightIndex;
      public uint NameOffset;
      public uint DataOffset;
      public string Name;

      public Node()
      {
      }

      public Node(EndianBinaryReader er)
      {
        this.RefBit = er.ReadUInt32();
        this.LeftIndex = er.ReadUInt16();
        this.RightIndex = er.ReadUInt16();
        this.NameOffset = er.ReadUInt32();
        if ((int) this.NameOffset != 0)
          this.NameOffset = this.NameOffset + ((uint) er.BaseStream.Position - 4U);
        this.DataOffset = er.ReadUInt32();
        if ((int) this.DataOffset != 0)
          this.DataOffset = this.DataOffset + ((uint) er.BaseStream.Position - 4U);
        if ((int) this.NameOffset == 0)
          return;
        long position = er.BaseStream.Position;
        er.BaseStream.Position = (long) this.NameOffset;
        this.Name = er.ReadStringNT(Encoding.ASCII);
        er.BaseStream.Position = position;
      }

      public void Write(EndianBinaryWriter er, CGFXWriterContext c)
      {
        er.Write(this.RefBit);
        er.Write(this.LeftIndex);
        er.Write(this.RightIndex);
        if (this.Name != null)
          c.WriteStringReference(this.Name, er);
        else
          er.Write(0U);
        er.Write(0U);
      }

      public override string ToString()
      {
        return this.Name;
      }
    }
  }
}
