// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.Matrix34
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public struct Matrix34
  {
    public static readonly Matrix34 Identity = new Matrix34(new float[12]
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
      0.0f
    });
    private Vector4 row0;
    private Vector4 row1;
    private Vector4 row2;

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

    public Matrix34(params float[] Matrix)
    {
      if (Matrix == null || Matrix.Length != 12)
        throw new ArgumentException();
      this.row0 = new Vector4();
      this.row1 = new Vector4();
      this.row2 = new Vector4();
      for (int index = 0; index < 12; ++index)
        this[index / 4, index % 4] = Matrix[index];
    }

    public static Matrix34 operator *(Matrix34 Left, Matrix34 Right)
    {
      Matrix44 matrix44 = new Matrix44(Left, new Vector4(0.0f, 0.0f, 0.0f, 1f)) * new Matrix44(Right, new Vector4(0.0f, 0.0f, 0.0f, 1f));
      Matrix34 matrix34 = new Matrix34();
      for (int index = 0; index < 12; ++index)
        matrix34[index] = matrix44[index];
      return matrix34;
    }

    public static Vector3 operator *(Vector3 Vector, Matrix34 Matrix)
    {
      Vector4 vector4 = Matrix.Row0;
      double num1 = (double) vector4.X * (double) Vector.X;
      vector4 = Matrix.Row0;
      double num2 = (double) vector4.Y * (double) Vector.Y;
      double num3 = num1 + num2;
      vector4 = Matrix.Row0;
      double num4 = (double) vector4.Z * (double) Vector.Z;
      double num5 = num3 + num4;
      vector4 = Matrix.Row1;
      double num6 = (double) vector4.X * (double) Vector.X;
      vector4 = Matrix.Row1;
      double num7 = (double) vector4.Y * (double) Vector.Y;
      double num8 = num6 + num7;
      vector4 = Matrix.Row1;
      double num9 = (double) vector4.Z * (double) Vector.Z;
      double num10 = num8 + num9;
      vector4 = Matrix.Row2;
      double num11 = (double) vector4.X * (double) Vector.X;
      vector4 = Matrix.Row2;
      double num12 = (double) vector4.Y * (double) Vector.Y;
      double num13 = num11 + num12;
      vector4 = Matrix.Row2;
      double num14 = (double) vector4.Z * (double) Vector.Z;
      double num15 = num13 + num14;
      Vector3 vector3_1 = new Vector3((float) num5, (float) num10, (float) num15);
      vector4 = Matrix.Row0;
      double num16 = (double) vector4.W;
      vector4 = Matrix.Row1;
      double num17 = (double) vector4.W;
      vector4 = Matrix.Row2;
      double num18 = (double) vector4.W;
      Vector3 vector3_2 = new Vector3((float) num16, (float) num17, (float) num18);
      return vector3_1 + vector3_2;
    }

    public static Vector3 operator *(Matrix34 Matrix, Vector3 Vector)
    {
      return Vector * Matrix;
    }

    public static Vector2 operator *(Vector2 Vector, Matrix34 Matrix)
    {
      Vector4 vector4 = Matrix.Row0;
      double num1 = (double) vector4.X * (double) Vector.X;
      vector4 = Matrix.Row0;
      double num2 = (double) vector4.Y * (double) Vector.Y;
      double num3 = num1 + num2;
      vector4 = Matrix.Row0;
      double num4 = (double) vector4.Z;
      double num5 = num3 + num4;
      vector4 = Matrix.Row1;
      double num6 = (double) vector4.X * (double) Vector.X;
      vector4 = Matrix.Row1;
      double num7 = (double) vector4.Y * (double) Vector.Y;
      double num8 = num6 + num7;
      vector4 = Matrix.Row1;
      double num9 = (double) vector4.Z;
      double num10 = num8 + num9;
      Vector2 vector2_1 = new Vector2((float) num5, (float) num10);
      vector4 = Matrix.Row0;
      double num11 = (double) vector4.W;
      vector4 = Matrix.Row1;
      double num12 = (double) vector4.W;
      Vector2 vector2_2 = new Vector2((float) num11, (float) num12);
      return vector2_1 + vector2_2;
    }

    public static Vector2 operator *(Matrix34 Matrix, Vector2 Vector)
    {
      return Vector * Matrix;
    }

    public static Matrix34 operator *(Matrix34 Left, float Right)
    {
      for (int index1 = 0; index1 < 3; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
            Left[index1, index2] = Left[index1, index2]*Right;
        }
      }
      return Left;
    }

    public static Matrix34 operator *(float Left, Matrix34 Right)
    {
      for (int index1 = 0; index1 < 3; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
            Right[index1, index2] = Right[index1, index2]*Left;
        }
      }
      return Right;
    }
  }
}
