// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.ColorMatrix
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.Drawing;
using System.Drawing.Imaging;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS
{
  public class ColorMatrix
  {
    public float[][] Matrix { get; set; }

    public Bitmap Apply(Bitmap OriginalImage)
    {
      Bitmap bitmap = new Bitmap(OriginalImage.Width, OriginalImage.Height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        System.Drawing.Imaging.ColorMatrix newColorMatrix = new System.Drawing.Imaging.ColorMatrix(this.Matrix);
        using (ImageAttributes imageAttr = new ImageAttributes())
        {
          imageAttr.SetColorMatrix(newColorMatrix);
          graphics.DrawImage((Image) OriginalImage, new Rectangle(0, 0, OriginalImage.Width, OriginalImage.Height), 0, 0, OriginalImage.Width, OriginalImage.Height, GraphicsUnit.Pixel, imageAttr);
        }
      }
      return bitmap;
    }
  }
}
