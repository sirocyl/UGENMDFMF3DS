// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.Vector3
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.ComponentModel;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  [TypeConverter(typeof (Vector3TypeConverter))]
  public struct Vector3
  {
    private float x;
    private float y;
    private float z;

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
        return (float) Math.Sqrt((double) this.X * (double) this.X + (double) this.Y * (double) this.Y + (double) this.Z * (double) this.Z);
      }
    }

    public Vector3(float Value)
    {
      this = new Vector3(Value, Value, Value);
    }

    public Vector3(Vector2 Vector, float Z)
    {
      this = new Vector3(Vector.X, Vector.Y, Z);
    }

    public Vector3(float X, float Y, float Z)
    {
      this.x = X;
      this.y = Y;
      this.z = Z;
    }

    public static Vector3 operator +(Vector3 Left, Vector3 Right)
    {
      return new Vector3(Left.X + Right.X, Left.Y + Right.Y, Left.Z + Right.Z);
    }

    public static Vector3 operator +(Vector3 Left, float Right)
    {
      return new Vector3(Left.X + Right, Left.Y + Right, Left.Z + Right);
    }

    public static Vector3 operator -(Vector3 Left, Vector3 Right)
    {
      return new Vector3(Left.X - Right.X, Left.Y - Right.Y, Left.Z - Right.Z);
    }

    public static Vector3 operator -(Vector3 Left, float Right)
    {
      return new Vector3(Left.X - Right, Left.Y - Right, Left.Z - Right);
    }

    public static Vector3 operator -(Vector3 Left)
    {
      return new Vector3(-Left.X, -Left.Y, -Left.Z);
    }

    public static Vector3 operator *(Vector3 Left, Vector3 Right)
    {
      return new Vector3(Left.X * Right.X, Left.Y * Right.Y, Left.Z * Right.Z);
    }

    public static Vector3 operator *(Vector3 Left, float Right)
    {
      return new Vector3(Left.X * Right, Left.Y * Right, Left.Z * Right);
    }

    public static Vector3 operator *(float Left, Vector3 Right)
    {
      return new Vector3(Left * Right.X, Left * Right.Y, Left * Right.Z);
    }

    public static Vector3 operator /(Vector3 Left, float Right)
    {
      return new Vector3(Left.X / Right, Left.Y / Right, Left.Z / Right);
    }

    public static bool operator ==(Vector3 Left, Vector3 Right)
    {
      return Left.Equals((object) Right);
    }

    public static bool operator !=(Vector3 Left, Vector3 Right)
    {
      return !Left.Equals((object) Right);
    }

    public void Normalize()
    {
      this = this / this.Length;
    }

    public float Dot(Vector3 Right)
    {
      return (float) ((double) this.X * (double) Right.X + (double) this.Y * (double) Right.Y + (double) this.Z * (double) Right.Z);
    }

    public Vector3 Cross(Vector3 Right)
    {
      return new Vector3((float) ((double) this.Y * (double) Right.Z - (double) Right.Y * (double) this.Z), (float) ((double) this.Z * (double) Right.X - (double) Right.Z * (double) this.X), (float) ((double) this.X * (double) Right.Y - (double) Right.X * (double) this.Y));
    }

    public float Angle(Vector3 Right)
    {
      return (float) Math.Acos((double) this.Dot(Right) / ((double) this.Length * (double) Right.Length));
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Vector3))
        return false;
      Vector3 vector3 = (Vector3) obj;
      if ((double) vector3.X == (double) this.X && (double) vector3.Y == (double) this.Y)
        return (double) vector3.Z == (double) this.Z;
      return false;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string ToString()
    {
      object[] objArray = new object[7];
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
      string str4 = ")";
      objArray[index7] = (object) str4;
      return string.Concat(objArray);
    }
  }
}
