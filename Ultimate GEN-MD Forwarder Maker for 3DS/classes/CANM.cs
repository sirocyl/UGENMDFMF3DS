// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.CANM
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System.Text;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class CANM
  {
    public string Signature;
    public uint Revision;
    public uint NameOffset;
    public uint TargetAnimationGroupNameOffset;
    public uint LoopMode;
    public float FrameSize;
    public uint NrMemberAnimations;
    public uint MemberAnimationDictOffset;
    public uint NrUserDataEntries;
    public uint UserDataOffset;
    public string Name;
    public string TargetAnimationGroupName;
    public DICT MemberAnimationDictionary;
    public CANM.MemberAnimationData[] MemberAnimations;

    public CANM(EndianBinaryReader er)
    {
      this.Signature = er.ReadString(Encoding.ASCII, 4);
      if (this.Signature != "CANM")
        throw new SignatureNotCorrectException(this.Signature, "CANM", er.BaseStream.Position);
      this.Revision = er.ReadUInt32();
      this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      this.TargetAnimationGroupNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      this.LoopMode = er.ReadUInt32();
      this.FrameSize = er.ReadSingle();
      this.NrMemberAnimations = er.ReadUInt32();
      this.MemberAnimationDictOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      this.NrUserDataEntries = er.ReadUInt32();
      this.UserDataOffset = er.ReadUInt32();
      long position = er.BaseStream.Position;
      er.BaseStream.Position = (long) this.NameOffset;
      this.Name = er.ReadStringNT(Encoding.ASCII);
      er.BaseStream.Position = (long) this.TargetAnimationGroupNameOffset;
      this.TargetAnimationGroupName = er.ReadStringNT(Encoding.ASCII);
      er.BaseStream.Position = (long) this.MemberAnimationDictOffset;
      this.MemberAnimationDictionary = new DICT(er);
      this.MemberAnimations = new CANM.MemberAnimationData[(int) this.NrMemberAnimations];
      for (int index = 0; (long) index < (long) this.NrMemberAnimations; ++index)
      {
        er.BaseStream.Position = (long) this.MemberAnimationDictionary[index].DataOffset;
        this.MemberAnimations[index] = new CANM.MemberAnimationData(er);
      }
      er.BaseStream.Position = position;
    }

    public override string ToString()
    {
      return this.Name;
    }

    public class MemberAnimationData
    {
      public uint Flags;
      public uint PathOffset;
      public CANM.MemberAnimationData.AnimationType PrimitiveType;
      public object[] ConstValues;
      public CANM.MemberAnimationData.AnimationCurve[] Curves;
      public string Path;

      public MemberAnimationData(EndianBinaryReader er)
      {
        this.Flags = er.ReadUInt32();
        this.PathOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.PrimitiveType = (CANM.MemberAnimationData.AnimationType) er.ReadUInt32();
        switch (this.PrimitiveType)
        {
          case CANM.MemberAnimationData.AnimationType.Vector2Animation:
            this.ConstValues = new object[2];
            this.Curves = new CANM.MemberAnimationData.AnimationCurve[2];
            if (((int) this.Flags & 1) != 0)
              this.ConstValues[0] = (object) er.ReadSingle();
            else if (((int) this.Flags & 4) != 0)
            {
              int num1 = (int) er.ReadUInt32();
            }
            else
            {
              long num2 = er.BaseStream.Position + (long) er.ReadUInt32();
              long position = er.BaseStream.Position;
              er.BaseStream.Position = num2;
              this.Curves[0] = (CANM.MemberAnimationData.AnimationCurve) new CANM.MemberAnimationData.FloatAnimationCurve(er);
              er.BaseStream.Position = position;
            }
            if (((int) this.Flags & 2) != 0)
            {
              this.ConstValues[1] = (object) er.ReadSingle();
              break;
            }
            if (((int) this.Flags & 8) != 0)
            {
              int num2 = (int) er.ReadUInt32();
              break;
            }
            long num3 = er.BaseStream.Position + (long) er.ReadUInt32();
            long position1 = er.BaseStream.Position;
            er.BaseStream.Position = num3;
            this.Curves[1] = (CANM.MemberAnimationData.AnimationCurve) new CANM.MemberAnimationData.FloatAnimationCurve(er);
            er.BaseStream.Position = position1;
            break;
          case CANM.MemberAnimationData.AnimationType.BakedTransformAnimation:
            this.Curves = new CANM.MemberAnimationData.AnimationCurve[3];
            if (((int) this.Flags & 16) != 0)
            {
              int num4 = (int) er.ReadUInt32();
            }
            else
            {
              long num2 = er.BaseStream.Position + (long) er.ReadUInt32();
              long position2 = er.BaseStream.Position;
              er.BaseStream.Position = num2;
              this.Curves[0] = (CANM.MemberAnimationData.AnimationCurve) new CANM.MemberAnimationData.Matrix33Curve(er);
              er.BaseStream.Position = position2;
            }
            if (((int) this.Flags & 8) != 0)
            {
              int num5 = (int) er.ReadUInt32();
            }
            else
            {
              long num2 = er.BaseStream.Position + (long) er.ReadUInt32();
              long position2 = er.BaseStream.Position;
              er.BaseStream.Position = num2;
              this.Curves[1] = (CANM.MemberAnimationData.AnimationCurve) new CANM.MemberAnimationData.Vector3Curve(er);
              er.BaseStream.Position = position2;
            }
            if (((int) this.Flags & 32) != 0)
            {
              int num2 = (int) er.ReadUInt32();
              break;
            }
            long num6 = er.BaseStream.Position + (long) er.ReadUInt32();
            long position3 = er.BaseStream.Position;
            er.BaseStream.Position = num6;
            this.Curves[2] = (CANM.MemberAnimationData.AnimationCurve) new CANM.MemberAnimationData.Vector3Curve(er);
            er.BaseStream.Position = position3;
            break;
        }
        long position4 = er.BaseStream.Position;
        er.BaseStream.Position = (long) this.PathOffset;
        this.Path = er.ReadStringNT(Encoding.ASCII);
        er.BaseStream.Position = position4;
      }

      public override string ToString()
      {
        return this.Path;
      }

      public enum AnimationType
      {
        FloatAnimation,
        IntAnimation,
        BoolAnimation,
        Vector2Animation,
        Vector3Animation,
        TransformAnimation,
        RgbaColorAnimation,
        TextureAnimation,
        BakedTransformAnimation,
        FullBakedAnimation,
      }

      public class AnimationCurve
      {
        public float StartFrame;
        public float EndFrame;
        public byte PreRepeatMethod;
        public byte PostRepeatMethod;
        public ushort Padding;
        public uint Flags;

        public AnimationCurve(EndianBinaryReader er)
        {
          this.StartFrame = er.ReadSingle();
          this.EndFrame = er.ReadSingle();
          this.PreRepeatMethod = er.ReadByte();
          this.PostRepeatMethod = er.ReadByte();
          this.Padding = er.ReadUInt16();
          this.Flags = er.ReadUInt32();
        }
      }

      public class FloatAnimationCurve : CANM.MemberAnimationData.AnimationCurve
      {
        public uint NrSegments;
        public uint[] SegmentOffsets;
        public CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment[] Segments;

        public FloatAnimationCurve(EndianBinaryReader er)
          : base(er)
        {
          this.NrSegments = er.ReadUInt32();
          this.SegmentOffsets = new uint[(int) this.NrSegments];
          for (int index = 0; (long) index < (long) this.NrSegments; ++index)
            this.SegmentOffsets[index] = (uint) er.BaseStream.Position + er.ReadUInt32();
          long position = er.BaseStream.Position;
          this.Segments = new CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment[(int) this.NrSegments];
          for (int index = 0; (long) index < (long) this.NrSegments; ++index)
          {
            er.BaseStream.Position = (long) this.SegmentOffsets[index];
            this.Segments[index] = new CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment(er);
          }
          er.BaseStream.Position = position;
        }

        public class FloatSegment
        {
          public float StartFrame;
          public float EndFrame;
          public uint Flags;
          public float SingleKeyValue;
          public uint NrKeys;
          public float Speed;
          public float Scale;
          public float Offset;
          public float FrameScale;
          public CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.Key[] Keys;

          public FloatSegment(EndianBinaryReader er)
          {
            this.StartFrame = er.ReadSingle();
            this.EndFrame = er.ReadSingle();
            this.Flags = er.ReadUInt32();
            if (((int) this.Flags & 1) == 1)
            {
              this.SingleKeyValue = er.ReadSingle();
            }
            else
            {
              this.NrKeys = er.ReadUInt32();
              this.Speed = er.ReadSingle();
              int num1 = (int) this.Flags;
              CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType quantizationType = (CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType) ((int) (this.Flags >> 5) & 7);
              switch (quantizationType)
              {
                case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.Hermite128:
                case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.StepLinear64:
                case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.UnifiedHermite96:
                  this.Keys = new CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.Key[(int) this.NrKeys];
                  for (int index = 0; (long) index < (long) this.NrKeys; ++index)
                  {
                    CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.Key key = new CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.Key();
                    switch (quantizationType)
                    {
                      case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.Hermite128:
                        key.Frame = er.ReadSingle();
                        key.Value = er.ReadSingle();
                        key.InSlope = er.ReadSingle();
                        key.OutSlope = er.ReadSingle();
                        break;
                      case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.Hermite64:
                        int num2 = (int) er.ReadUInt32();
                        key.InSlope = (float) (er.ReadInt16() * (1.0 / 256.0));
                        key.OutSlope = (float) (er.ReadInt16() * (1.0 / 256.0));
                        break;
                      case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.Hermite48:
                        er.ReadBytes(3);
                        er.ReadBytes(3);
                        break;
                      case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.UnifiedHermite96:
                        key.Frame = er.ReadSingle();
                        key.Value = er.ReadSingle();
                        key.InSlope = key.OutSlope = er.ReadSingle();
                        break;
                      case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.UnifiedHermite48:
                        key.Frame = (float) (er.ReadUInt16() * (1.0 / 32.0));
                        key.Value = (float) er.ReadInt16();
                        key.InSlope = key.OutSlope = (float) (er.ReadInt16() * (1.0 / 256.0));
                        break;
                      case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.UnifiedHermite32:
                        key.Frame = (float) er.ReadByte();
                        er.ReadBytes(3);
                        break;
                      case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.StepLinear64:
                        key.Frame = er.ReadSingle();
                        key.Value = er.ReadSingle();
                        break;
                      case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.StepLinear32:
                        uint num3 = er.ReadUInt32();
                        key.Frame = (float) (num3 & 4095U);
                        key.Value = (float) ((int) num3 >> 12);
                        break;
                    }
                    this.Keys[index] = key;
                  }
                  break;
                default:
                  this.Scale = er.ReadSingle();
                  this.Offset = er.ReadSingle();
                  this.FrameScale = er.ReadSingle();
                  goto case CANM.MemberAnimationData.FloatAnimationCurve.FloatSegment.QuantizationType.Hermite128;
              }
            }
          }

          public enum QuantizationType : uint
          {
            Hermite128,
            Hermite64,
            Hermite48,
            UnifiedHermite96,
            UnifiedHermite48,
            UnifiedHermite32,
            StepLinear64,
            StepLinear32,
          }

          public class Key
          {
            public float Frame;
            public float Value;
            public float InSlope;
            public float OutSlope;
          }
        }
      }

      public class Vector3Curve : CANM.MemberAnimationData.AnimationCurve
      {
        public Vector3 ConstantValue;
        public uint ConstantFlag;
        public Vector3[] Values;
        public uint[] ValueFlags;

        public Vector3Curve(EndianBinaryReader er)
          : base(er)
        {
          if (((int) this.Flags & 1) != 0)
          {
            this.ConstantValue = er.ReadVector3();
            this.ConstantFlag = er.ReadUInt32();
          }
          else
          {
            this.Values = new Vector3[(int) ((double) this.EndFrame - (double) this.StartFrame)];
            this.ValueFlags = new uint[(int) ((double) this.EndFrame - (double) this.StartFrame)];
            for (int index = 0; (double) index < (double) this.EndFrame - (double) this.StartFrame; ++index)
            {
              this.Values[index] = er.ReadVector3();
              this.ValueFlags[index] = er.ReadUInt32();
            }
          }
        }
      }

      public class Matrix33Curve : CANM.MemberAnimationData.AnimationCurve
      {
        public Vector4 ConstantValue;
        public uint ConstantFlag;
        public Vector4[] Values;
        public uint[] ValueFlags;

        public Matrix33Curve(EndianBinaryReader er)
          : base(er)
        {
          if (((int) this.Flags & 1) != 0)
          {
            this.ConstantValue = er.ReadVector4();
            this.ConstantFlag = er.ReadUInt32();
          }
          else
          {
            this.Values = new Vector4[(int) ((double) this.EndFrame - (double) this.StartFrame)];
            this.ValueFlags = new uint[(int) ((double) this.EndFrame - (double) this.StartFrame)];
            for (int index = 0; (double) index < (double) this.EndFrame - (double) this.StartFrame; ++index)
            {
              this.Values[index] = er.ReadVector4();
              this.ValueFlags[index] = er.ReadUInt32();
            }
          }
        }
      }
    }
  }
}
