// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.Vector2
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.ComponentModel;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  [TypeConverter(typeof (Vector2TypeConverter))]
  public struct Vector2
  {
    private float x;
    private float y;

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

    public float this[int index]
    {
      get
      {
        if (index == 0)
          return this.X;
        if (index == 1)
          return this.Y;
        throw new IndexOutOfRangeException();
      }
      set
      {
        if (index != 0)
        {
          if (index != 1)
            throw new IndexOutOfRangeException();
          this.Y = value;
        }
        else
          this.X = value;
      }
    }

    [Browsable(false)]
    public float Length
    {
      get
      {
        return (float) Math.Sqrt((double) this.X * (double) this.X + (double) this.Y * (double) this.Y);
      }
    }

    public Vector2(float Value)
    {
      this = new Vector2(Value, Value);
    }

    public Vector2(float X, float Y)
    {
      this.x = X;
      this.y = Y;
    }

    public static Vector2 operator +(Vector2 Left, Vector2 Right)
    {
      return new Vector2(Left.X + Right.X, Left.Y + Right.Y);
    }

    public static Vector2 operator +(Vector2 Left, float Right)
    {
      return new Vector2(Left.X + Right, Left.Y + Right);
    }

    public static Vector2 operator -(Vector2 Left, Vector2 Right)
    {
      return new Vector2(Left.X - Right.X, Left.Y - Right.Y);
    }

    public static Vector2 operator -(Vector2 Left, float Right)
    {
      return new Vector2(Left.X - Right, Left.Y - Right);
    }

    public static Vector2 operator -(Vector2 Left)
    {
      return new Vector2(-Left.X, -Left.Y);
    }

    public static Vector2 operator *(Vector2 Left, Vector2 Right)
    {
      return new Vector2(Left.X * Right.X, Left.Y * Right.Y);
    }

    public static Vector2 operator *(Vector2 Left, float Right)
    {
      return new Vector2(Left.X * Right, Left.Y * Right);
    }

    public static Vector2 operator *(float Left, Vector2 Right)
    {
      return new Vector2(Left * Right.X, Left * Right.Y);
    }

    public static Vector2 operator /(Vector2 Left, float Right)
    {
      return new Vector2(Left.X / Right, Left.Y / Right);
    }

    public static bool operator ==(Vector2 Left, Vector2 Right)
    {
      return Left.Equals((object) Right);
    }

    public static bool operator !=(Vector2 Left, Vector2 Right)
    {
      return !Left.Equals((object) Right);
    }

    public void Normalize()
    {
      this = this / this.Length;
    }

    public float Dot(Vector2 Right)
    {
      return (float) ((double) this.X * (double) Right.X + (double) this.Y * (double) Right.Y);
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Vector2))
        return false;
      Vector2 vector2 = (Vector2) obj;
      if ((double) vector2.X == (double) this.X)
        return (double) vector2.Y == (double) this.Y;
      return false;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string ToString()
    {
      object[] objArray = new object[5];
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
      string str3 = ")";
      objArray[index5] = (object) str3;
      return string.Concat(objArray);
    }
  }
}
