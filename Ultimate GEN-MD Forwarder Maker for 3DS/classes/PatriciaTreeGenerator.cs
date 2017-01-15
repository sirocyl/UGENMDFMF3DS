// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.PatriciaTreeGenerator
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Collections.Generic;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  internal class PatriciaTreeGenerator
  {
    private List<PatriciaTreeGenerator.PatTreeNode> Nodes = new List<PatriciaTreeGenerator.PatTreeNode>();
    private int StringLength;

    public PatriciaTreeGenerator.PatTreeNode[] TreeNodes
    {
      get
      {
        return this.Nodes.ToArray();
      }
    }

    public PatriciaTreeGenerator(int StringLength)
    {
      this.StringLength = StringLength;
      this.AddRootPatTreeNode();
    }

    private PatriciaTreeGenerator.PatTreeNode AddRootPatTreeNode()
    {
      PatriciaTreeGenerator.PatTreeNode patTreeNode = new PatriciaTreeGenerator.PatTreeNode();
      patTreeNode.refbit = (uint) (this.StringLength * 8 - 1);
      patTreeNode.left = patTreeNode;
      patTreeNode.right = patTreeNode;
      patTreeNode.idxEntry = 0;
      patTreeNode.name = new string(char.MinValue, this.StringLength);
      this.Nodes.Add(patTreeNode);
      return patTreeNode;
    }

    public PatriciaTreeGenerator.PatTreeNode AddPatTreeNode(string Name, int Index)
    {
      Name = Name.PadRight(this.StringLength, char.MinValue);
      PatriciaTreeGenerator.PatTreeNode patTreeNode1 = new PatriciaTreeGenerator.PatTreeNode();
      patTreeNode1.name = Name;
      PatriciaTreeGenerator.PatTreeNode patTreeNode2 = this.Nodes[0];
      PatriciaTreeGenerator.PatTreeNode patTreeNode3 = patTreeNode2.left;
      uint bit = (uint) (this.StringLength * 8 - 1);
      for (; patTreeNode2.refbit > patTreeNode3.refbit; patTreeNode3 = PatriciaTreeGenerator.GetBit(Name, patTreeNode3.refbit) ? patTreeNode3.right : patTreeNode3.left)
        patTreeNode2 = patTreeNode3;
      while (PatriciaTreeGenerator.GetBit(patTreeNode3.name, bit) == PatriciaTreeGenerator.GetBit(Name, bit))
        --bit;
      PatriciaTreeGenerator.PatTreeNode patTreeNode4 = this.Nodes[0];
      PatriciaTreeGenerator.PatTreeNode patTreeNode5;
      for (patTreeNode5 = patTreeNode4.left; patTreeNode4.refbit > patTreeNode5.refbit && patTreeNode5.refbit > bit; patTreeNode5 = PatriciaTreeGenerator.GetBit(Name, patTreeNode5.refbit) ? patTreeNode5.right : patTreeNode5.left)
        patTreeNode4 = patTreeNode5;
      patTreeNode1.refbit = bit;
      patTreeNode1.left = PatriciaTreeGenerator.GetBit(Name, patTreeNode1.refbit) ? patTreeNode5 : patTreeNode1;
      patTreeNode1.right = PatriciaTreeGenerator.GetBit(Name, patTreeNode1.refbit) ? patTreeNode1 : patTreeNode5;
      if (PatriciaTreeGenerator.GetBit(Name, patTreeNode4.refbit))
        patTreeNode4.right = patTreeNode1;
      else
        patTreeNode4.left = patTreeNode1;
      patTreeNode1.idxEntry = Index;
      this.Nodes.Add(patTreeNode1);
      return patTreeNode1;
    }

    private static bool GetBit(string name, uint bit)
    {
      if (name == null || (long) (bit / 8U) >= (long) name.Length)
        throw new ArgumentException();
      return ((int) name[(int) bit / 8] >> ((int) bit & 7) & 1) == 1;
    }

    public void Sort()
    {
      SortedDictionary<string, PatriciaTreeGenerator.PatTreeNode> sortedDictionary = new SortedDictionary<string, PatriciaTreeGenerator.PatTreeNode>();
      foreach (PatriciaTreeGenerator.PatTreeNode patTreeNode in this.Nodes)
      {
        if (!(patTreeNode.name.TrimEnd(new char[1]) == ""))
          sortedDictionary.Add(patTreeNode.name.TrimEnd(new char[1]), patTreeNode);
      }
      List<PatriciaTreeGenerator.PatTreeNode> list1 = new List<PatriciaTreeGenerator.PatTreeNode>();
      foreach (PatriciaTreeGenerator.PatTreeNode patTreeNode in sortedDictionary.Values)
        list1.Add(patTreeNode);
      List<PatriciaTreeGenerator.PatTreeNode> list2 = new List<PatriciaTreeGenerator.PatTreeNode>();
      for (int index1 = 0; index1 < this.Nodes.Count - 1; ++index1)
      {
        int index2 = -1;
        int num = -1;
        for (int index3 = 0; index3 < list1.Count; ++index3)
        {
          if (list1[index3].name.TrimEnd(new char[1]).Length > num)
          {
            index2 = index3;
            num = list1[index3].name.TrimEnd(new char[1]).Length;
          }
        }
        list2.Add(list1[index2]);
        list1.RemoveAt(index2);
      }
      list2.Insert(0, this.Nodes[0]);
      this.Nodes = list2;
    }

    public static PatriciaTreeGenerator Generate(string[] Names)
    {
      int StringLength = 0;
      foreach (string str in Names)
      {
        if (str.Length > StringLength)
          StringLength = str.Length;
      }
      PatriciaTreeGenerator patriciaTreeGenerator = new PatriciaTreeGenerator(StringLength);
      for (int Index = 0; Index < Names.Length; ++Index)
        patriciaTreeGenerator.AddPatTreeNode(Names[Index], Index);
      patriciaTreeGenerator.Sort();
      return patriciaTreeGenerator;
    }

    public class PatTreeNode
    {
      public uint refbit;
      public PatriciaTreeGenerator.PatTreeNode left;
      public PatriciaTreeGenerator.PatTreeNode right;
      public int idxEntry;
      public string name;

      public override string ToString()
      {
        return this.name;
      }
    }
  }
}
