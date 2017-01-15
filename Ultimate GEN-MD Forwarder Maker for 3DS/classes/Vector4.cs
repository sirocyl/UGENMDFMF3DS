// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.Vector4
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.ComponentModel;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  [TypeConverter(typeof (ValueTypeTypeConverter))]
  public struct Vector4
  {
    private float x;
    private float y;
    private float z;
    private float w;

    public float X
    {
      get
      {
        return this.x;
      }
      set
      {
        this.x = value;
      }
    }

    public float Y
    {
      get
      {
        return this.y;
      }
      set
      {
        this.y = value;
      }
    }

    public float Z
    {
      get
      {
        return this.z;
      }
      set
      {
        this.z = value;
      }
    }

    public float W
    {
      get
      {
        return this.w;
      }
      set
      {
        this.w = value;
      }
    }

    public float this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return this.X;
          case 1:
            return this.Y;
          case 2:
            return this.Z;
          case 3:
            return this.W;
          default:
            throw new IndexOutOfRangeException();
        }
      }
      set
      {
        switch (index)
        {
          case 0:
            this.X = value;
            break;
          case 1:
            this.Y = value;
            break;
          case 2:
            this.Z = value;
            break;
          case 3:
            this.W = value;
            break;
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    [Browsable(false)]
    public float Length
    {
      get
      {
        return (float) Math.Sqrt((double) this.X * (double) this.X + (double) this.Y * (double) this.Y + (double) this.Z * (double) this.Z + (double) this.W * (double) this.W);
      }
    }

    public Vector4(float Value)
    {
      this = new Vector4(Value, Value, Value, Value);
    }

    public Vector4(Vector2 Vector, float Z, float W)
    {
      this = new Vector4(Vector.X, Vector.Y, Z, W);
    }

    public Vector4(Vector2 Vector1, Vector2 Vector2)
    {
      this = new Vector4(Vector1.X, Vector1.Y, Vector2.X, Vector2.Y);
    }

    public Vector4(Vector3 Vector, float W)
    {
      this = new Vector4(Vector.X, Vector.Y, Vector.Z, W);
    }

    public Vector4(float X, float Y, float Z, float W)
    {
      this.x = X;
      this.y = Y;
      this.z = Z;
      this.w = W;
    }

    public static Vector4 operator +(Vector4 Left, Vector4 Right)
    {
      return new Vector4(Left.X + Right.X, Left.Y + Right.Y, Left.Z + Right.Z, Left.W + Right.W);
    }

    public static Vector4 operator +(Vector4 Left, float Right)
    {
      return new Vector4(Left.X + Right, Left.Y + Right, Left.Z + Right, Left.W + Right);
    }

    public static Vector4 operator -(Vector4 Left, Vector4 Right)
    {
      return new Vector4(Left.X - Right.X, Left.Y - Right.Y, Left.Z - Right.Z, Left.W - Right.W);
    }

    public static Vector4 operator -(Vector4 Left, float Right)
    {
      return new Vector4(Left.X - Right, Left.Y - Right, Left.Z - Right, Left.W - Right);
    }

    public static Vector4 operator -(Vector4 Left)
    {
      return new Vector4(-Left.X, -Left.Y, -Left.Z, -Left.W);
    }

    public static Vector4 operator *(Vector4 Left, Vector4 Right)
    {
      return new Vector4(Left.X * Right.X, Left.Y * Right.Y, Left.Z * Right.Z, Left.W * Right.W);
    }

    public static Vector4 operator *(Vector4 Left, float Right)
    {
      return new Vector4(Left.X * Right, Left.Y * Right, Left.Z * Right, Left.W * Right);
    }

    public static Vector4 operator *(float Left, Vector4 Right)
    {
      return new Vector4(Left * Right.X, Left * Right.Y, Left * Right.Z, Left * Right.W);
    }

    public static Vector4 operator /(Vector4 Left, float Right)
    {
      return new Vector4(Left.X / Right, Left.Y / Right, Left.Z / Right, Left.W / Right);
    }

    public static bool operator ==(Vector4 Left, Vector4 Right)
    {
      return Left.Equals((object) Right);
    }

    public static bool operator !=(Vector4 Left, Vector4 Right)
    {
      return !Left.Equals((object) Right);
    }

    public void Normalize()
    {
      this = this / this.Length;
    }

    public float Dot(Vector4 Right)
    {
      return (float) ((double) this.X * (double) Right.X + (double) this.Y * (double) Right.Y + (double) this.Z * (double) Right.Z);
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Vector4))
        return false;
      Vector4 vector4 = (Vector4) obj;
      if ((double) vector4.X == (double) this.X && (double) vector4.Y == (double) this.Y && (double) vector4.Z == (double) this.Z)
        return (double) vector4.W == (double) this.W;
      return false;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string ToString()
    {
      object[] objArray = new object[9];
      int index1 = 0;
      string str1 = "(";
      objArray[index1] = (object) str1;
      int index2 = 1;
      objArray[index2] = this.X;
      int index3 = 2;
      string str2 = "; ";
      objArray[index3] = (object) str2;
      int index4 = 3;
      objArray[index4] = this.Y;
      int index5 = 4;
      string str3 = "; ";
      objArray[index5] = (object) str3;
      int index6 = 5;
      objArray[index6] = this.Z;
      int index7 = 6;
      string str4 = "; ";
      objArray[index7] = (object) str4;
      int index8 = 7;
      objArray[index8] = this.W;
      int index9 = 8;
      string str5 = ")";
      objArray[index9] = (object) str5;
      return string.Concat(objArray);
    }
  }
}
