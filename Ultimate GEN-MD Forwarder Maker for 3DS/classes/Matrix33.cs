// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.Matrix33
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public struct Matrix33
  {
    public static readonly Matrix33 Identity = new Matrix33(new float[9]
    {
      1f,
      0.0f,
      0.0f,
      0.0f,
      1f,
      0.0f,
      0.0f,
      0.0f,
      1f
    });
    private Vector3 row0;
    private Vector3 row1;
    private Vector3 row2;

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
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    public Matrix33(params float[] Matrix)
    {
      if (Matrix == null || Matrix.Length != 9)
        throw new ArgumentException();
      this.row0 = new Vector3();
      this.row1 = new Vector3();
      this.row2 = new Vector3();
      for (int index = 0; index < 9; ++index)
        this[index / 3, index % 3] = Matrix[index];
    }

    public static explicit operator float[](Matrix33 Matrix)
    {
      float[] numArray = new float[9];
      for (int index = 0; index < 9; ++index)
        numArray[index] = Matrix[index];
      return numArray;
    }

    public static Matrix33 operator *(Matrix33 Left, Matrix33 Right)
    {
      Matrix33 matrix33 = new Matrix33();
      for (int index1 = 0; index1 < 3; ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
          for (int index3 = 0; index3 < 3; ++index3)
          {
            matrix33[index1, index2] = matrix33[index1, index2] + Left[index3, index2] * Right[index1, index3];
          }
        }
      }
      return matrix33;
    }

    public static Matrix33 operator *(Matrix33 Left, float Right)
    {
      for (int index1 = 0; index1 < 3; ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
            Left[index1, index2] = Left[index1, index2]*Right;
        }
      }
      return Left;
    }

    public static Matrix33 operator *(float Left, Matrix33 Right)
    {
      for (int index1 = 0; index1 < 3; ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
        {
            Right[index1, index2] = Right[index1, index2]*Left;
        }
      }
      return Right;
    }

    public static Matrix33 CreateScale(Vector3 Scale)
    {
      Matrix33 matrix33 = Matrix33.Identity;
      matrix33[0, 0] = Scale.X;
      matrix33[1, 1] = Scale.Y;
      matrix33[2, 2] = Scale.Z;
      return matrix33;
    }
  }
}
