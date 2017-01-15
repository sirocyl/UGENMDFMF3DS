// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.Matrix44
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public struct Matrix44
  {
    public static readonly Matrix44 Identity = new Matrix44(new float[16]
    {
      1f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      1f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      1f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      1f
    });
    private Vector4 row0;
    private Vector4 row1;
    private Vector4 row2;
    private Vector4 row3;

    public Vector4 Row0
    {
      get
      {
        return this.row0;
      }
      set
      {
        this.row0 = value;
      }
    }

    public Vector4 Row1
    {
      get
      {
        return this.row1;
      }
      set
      {
        this.row1 = value;
      }
    }

    public Vector4 Row2
    {
      get
      {
        return this.row2;
      }
      set
      {
        this.row2 = value;
      }
    }

    public Vector4 Row3
    {
      get
      {
        return this.row3;
      }
      set
      {
        this.row3 = value;
      }
    }

    public float this[int index]
    {
      get
      {
        return this[index / 4, index % 4];
      }
      set
      {
        this[index / 4, index % 4] = value;
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

    public Matrix44(params float[] Matrix)
    {
      if (Matrix == null || Matrix.Length != 16)
        throw new ArgumentException();
      this.row0 = new Vector4();
      this.row1 = new Vector4();
      this.row2 = new Vector4();
      this.row3 = new Vector4();
      for (int index = 0; index < 16; ++index)
        this[index / 4, index % 4] = Matrix[index];
    }

    public Matrix44(Matrix33 Matrix)
    {
      this = new Matrix44(Matrix, 0.0f, 0.0f, 0.0f, new Vector4());
    }

    public Matrix44(Matrix33 Matrix, float M14, float M24, float M34, Vector4 Row3)
    {
      this.row0 = new Vector4();
      this.row1 = new Vector4();
      this.row2 = new Vector4();
      this.row3 = Row3;
      for (int index = 0; index < 9; ++index)
        this[index / 3, index % 3] = Matrix[index];
      this.row0.W = M14;
      this.row1.W = M24;
      this.row2.W = M34;
    }

    public Matrix44(Matrix34 Matrix)
    {
      this = new Matrix44(Matrix, new Vector4());
    }

    public Matrix44(Matrix34 Matrix, Vector4 Row3)
    {
      this.row0 = new Vector4();
      this.row1 = new Vector4();
      this.row2 = new Vector4();
      this.row3 = Row3;
      for (int index = 0; index < 12; ++index)
        this[index / 4, index % 4] = Matrix[index];
    }

    public Matrix44(Matrix43 Matrix)
    {
      this = new Matrix44(Matrix, new Vector4());
    }

    public Matrix44(Matrix43 Matrix, Vector4 Column3)
    {
      this.row0 = new Vector4();
      this.row1 = new Vector4();
      this.row2 = new Vector4();
      this.row3 = new Vector4();
      this.row0.W = Column3.X;
      this.row1.W = Column3.Y;
      this.row2.W = Column3.Z;
      this.row3.W = Column3.W;
      for (int index = 0; index < 12; ++index)
        this[index / 3, index % 3] = Matrix[index];
    }

    public static explicit operator float[](Matrix44 Matrix)
    {
      float[] numArray = new float[16];
      for (int index = 0; index < 16; ++index)
        numArray[index] = Matrix[index];
      return numArray;
    }

    public static Matrix44 operator *(Matrix44 Left, Matrix44 Right)
    {
      Matrix44 matrix44 = new Matrix44();
      matrix44[0] = (float) ((double) Left[0] * (double) Right[0] + (double) Left[4] * (double) Right[1] + (double) Left[8] * (double) Right[2] + (double) Left[12] * (double) Right[3]);
      matrix44[1] = (float) ((double) Left[1] * (double) Right[0] + (double) Left[5] * (double) Right[1] + (double) Left[9] * (double) Right[2] + (double) Left[13] * (double) Right[3]);
      matrix44[2] = (float) ((double) Left[2] * (double) Right[0] + (double) Left[6] * (double) Right[1] + (double) Left[10] * (double) Right[2] + (double) Left[14] * (double) Right[3]);
      matrix44[3] = (float) ((double) Left[3] * (double) Right[0] + (double) Left[7] * (double) Right[1] + (double) Left[11] * (double) Right[2] + (double) Left[15] * (double) Right[3]);
      matrix44[4] = (float) ((double) Left[0] * (double) Right[4] + (double) Left[4] * (double) Right[5] + (double) Left[8] * (double) Right[6] + (double) Left[12] * (double) Right[7]);
      matrix44[5] = (float) ((double) Left[1] * (double) Right[4] + (double) Left[5] * (double) Right[5] + (double) Left[9] * (double) Right[6] + (double) Left[13] * (double) Right[7]);
      matrix44[6] = (float) ((double) Left[2] * (double) Right[4] + (double) Left[6] * (double) Right[5] + (double) Left[10] * (double) Right[6] + (double) Left[14] * (double) Right[7]);
      matrix44[7] = (float) ((double) Left[3] * (double) Right[4] + (double) Left[7] * (double) Right[5] + (double) Left[11] * (double) Right[6] + (double) Left[15] * (double) Right[7]);
      matrix44[8] = (float) ((double) Left[0] * (double) Right[8] + (double) Left[4] * (double) Right[9] + (double) Left[8] * (double) Right[10] + (double) Left[12] * (double) Right[11]);
      matrix44[9] = (float) ((double) Left[1] * (double) Right[8] + (double) Left[5] * (double) Right[9] + (double) Left[9] * (double) Right[10] + (double) Left[13] * (double) Right[11]);
      matrix44[10] = (float) ((double) Left[2] * (double) Right[8] + (double) Left[6] * (double) Right[9] + (double) Left[10] * (double) Right[10] + (double) Left[14] * (double) Right[11]);
      matrix44[11] = (float) ((double) Left[3] * (double) Right[8] + (double) Left[7] * (double) Right[9] + (double) Left[11] * (double) Right[10] + (double) Left[15] * (double) Right[11]);
      matrix44[12] = (float) ((double) Left[0] * (double) Right[12] + (double) Left[4] * (double) Right[13] + (double) Left[8] * (double) Right[14] + (double) Left[12] * (double) Right[15]);
      matrix44[13] = (float) ((double) Left[1] * (double) Right[12] + (double) Left[5] * (double) Right[13] + (double) Left[9] * (double) Right[14] + (double) Left[13] * (double) Right[15]);
      matrix44[14] = (float) ((double) Left[2] * (double) Right[12] + (double) Left[6] * (double) Right[13] + (double) Left[10] * (double) Right[14] + (double) Left[14] * (double) Right[15]);
      matrix44[15] = (float) ((double) Left[3] * (double) Right[12] + (double) Left[7] * (double) Right[13] + (double) Left[11] * (double) Right[14] + (double) Left[15] * (double) Right[15]);
      return matrix44;
    }

    public static Vector3 operator *(Vector3 Left, Matrix44 Right)
    {
      Vector3 vector3 = new Vector3();
      vector3[0] = (float) ((double) Left.X * (double) Right[0] + (double) Left.Y * (double) Right[4] + (double) Left.Z * (double) Right[8]) + Right[12];
      vector3[1] = (float) ((double) Left.X * (double) Right[1] + (double) Left.Y * (double) Right[5] + (double) Left.Z * (double) Right[9]) + Right[13];
      vector3[2] = (float) ((double) Left.X * (double) Right[2] + (double) Left.Y * (double) Right[6] + (double) Left.Z * (double) Right[10]) + Right[14];
      return vector3;
    }

    public static Vector3 operator *(Matrix44 Left, Vector3 Right)
    {
      return Right * Left;
    }

    public static Matrix44 operator *(Matrix44 Left, float Right)
    {
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
            Left[index1, index2] = Left[index1, index2]*Right;
        }
      }
      return Left;
    }

    public static Matrix44 operator *(float Left, Matrix44 Right)
    {
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          Right[index1, index2] = Right[index1, index2]*Left;
        }
      }
      return Right;
    }

    public static Matrix44 CreateTranslation(Vector3 Translation)
    {
      Matrix44 matrix44 = Matrix44.Identity;
      matrix44[3, 0] = Translation.X;
      matrix44[3, 1] = Translation.Y;
      matrix44[3, 2] = Translation.Z;
      return matrix44;
    }

    public static Matrix44 CreateScale(Vector3 Scale)
    {
      Matrix44 matrix44 = Matrix44.Identity;
      matrix44[0, 0] = Scale.X;
      matrix44[1, 1] = Scale.Y;
      matrix44[2, 2] = Scale.Z;
      return matrix44;
    }
  }
}
