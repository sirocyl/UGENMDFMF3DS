// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.NativeMethods
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  internal static class NativeMethods
  {
    [DllImport("shell32.dll")]
    public static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, uint cidl, [MarshalAs(UnmanagedType.LPArray), In] IntPtr[] apidl, uint dwFlags);

    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr ILCreateFromPath([MarshalAs(UnmanagedType.LPTStr)] string pszPath);

    public static void OpenFolderAndSelectFiles(string folder, params string[] filesToSelect)
    {
      IntPtr fromPath = NativeMethods.ILCreateFromPath(folder);
      IntPtr[] apidl = new IntPtr[filesToSelect.Length];
      for (int index = 0; index < filesToSelect.Length; ++index)
        apidl[index] = NativeMethods.ILCreateFromPath(filesToSelect[index]);
      NativeMethods.SHOpenFolderAndSelectItems(fromPath, (uint) filesToSelect.Length, apidl, 0U);
      object[] objArray1 = new object[1];
      int index1 = 0;
      objArray1[index1] = fromPath;
      NativeMethods.ReleaseComObject(objArray1);
      object[] objArray2 = new object[1];
      int index2 = 0;
      IntPtr[] numArray = apidl;
      objArray2[index2] = (object) numArray;
      NativeMethods.ReleaseComObject(objArray2);
    }

    private static void ReleaseComObject(params object[] comObjs)
    {
      foreach (object o in comObjs)
      {
        if (o != null && Marshal.IsComObject(o))
          Marshal.ReleaseComObject(o);
      }
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    [ComImport]
    public interface IShellLinkW
    {
      [MethodImpl(MethodImplOptions.PreserveSig)]
      int GetPath(StringBuilder pszFile, int cch, [In, Out] ref NativeMethods.WIN32_FIND_DATAW pfd, uint fFlags);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int GetIDList(out IntPtr ppidl);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int SetIDList([In] ref IntPtr pidl);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int GetDescription(StringBuilder pszName, int cch);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int GetWorkingDirectory(StringBuilder pszDir, int cch);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int GetArguments(StringBuilder pszArgs, int cch);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int GetHotkey(out ushort pwHotkey);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int SetHotkey(ushort wHotkey);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int GetShowCmd(out int piShowCmd);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int SetShowCmd(int iShowCmd);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int GetIconLocation(StringBuilder pszIconPath, int cch, out int piIcon);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, uint dwReserved);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int Resolve(IntPtr hwnd, uint fFlags);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

    [BestFitMapping(false)]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WIN32_FIND_DATAW
    {
      public uint dwFileAttributes;
      public FILETIME ftCreationTime;
      public FILETIME ftLastAccessTime;
      public FILETIME ftLastWriteTime;
      public uint nFileSizeHigh;
      public uint nFileSizeLow;
      public uint dwReserved0;
      public uint dwReserved1;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
      public string cFileName;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
      public string cAlternateFileName;
    }
  }
}
