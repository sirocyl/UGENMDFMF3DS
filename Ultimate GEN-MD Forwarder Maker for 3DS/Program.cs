// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.Program
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Windows.Forms;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      try
      {
        Application.Run((Form) new frmMain());
      }
      catch
      {
        GC.Collect();
        GC.WaitForPendingFinalizers();
      }
    }
  }
}
