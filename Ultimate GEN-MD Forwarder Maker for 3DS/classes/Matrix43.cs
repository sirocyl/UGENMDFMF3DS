// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.Matrix43
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public struct Matrix43
  {
    public static readonly Matrix43 Identity = new Matrix43(new float[12]
    {
      1f,
      0.0f,
      0.0f,
      0.0f,
      1f,
      0.0f,
      0.0f,
      0.0f,
      1f,
      0.0f,
      0.0f,
      0.0f
    });
    private Vector3 row0;
    private Vector3 row1;
    private Vector3 row2;
    private Vector3 row3;

    public float this[int index]
    {
      get
      {
        return this[index / 3, index % 3];
      }
      set
      {
        this[index / 3, index % 3] = value;
      }
    }

    public float this[int row, int column]
    {
      get
      {
        switch (row)
        {
          case 0:
            return this.row0[column];
          case 1:
            return this.row1[column];
          case 2:
            return this.row2[column];
          case 3:
            return this.row3[column];
          default:
            throw new IndexOutOfRangeException();
        }
      }
      set
      {
        switch (row)
        {
          case 0:
            this.row0[column] = value;
            break;
          case 1:
            this.row1[column] = value;
            break;
          case 2:
            this.row2[column] = value;
            break;
          case 3:
            this.row3[column] = value;
            break;
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    public Matrix43(params float[] Matrix)
    {
      if (Matrix == null || Matrix.Length != 12)
        throw new ArgumentException();
      this.row0 = new Vector3();
      this.row1 = new Vector3();
      this.row2 = new Vector3();
      this.row3 = new Vector3();
      for (int index = 0; index < 12; ++index)
        this[index / 3, index % 3] = Matrix[index];
    }

    public static Matrix43 operator *(Matrix43 Left, Matrix43 Right)
    {
      Matrix44 matrix44 = new Matrix44(Left, new Vector4(0.0f, 0.0f, 0.0f, 1f)) * new Matrix44(Right, new Vector4(0.0f, 0.0f, 0.0f, 1f));
      Matrix43 matrix43 = new Matrix43();
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
          matrix43[index1, index2] = matrix44[index1, index2];
      }
      return matrix43;
    }

    public static Matrix43 operator *(Matrix43 Left, float Right)
    {
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
            Left[index1, index2] = Left[index1, index2]*Right;
        }
      }
      return Left;
    }

    public static Matrix43 operator *(float Left, Matrix43 Right)
    {
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
            Right[index1, index2] = Right[index1, index2]*Left;
        }
      }
      return Right;
    }
  }
}
