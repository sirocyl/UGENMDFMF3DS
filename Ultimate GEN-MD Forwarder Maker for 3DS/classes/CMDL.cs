// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.CMDL
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
  public class CMDL
  {
    public uint Type;
    public string Signature;
    public uint Revision;
    public uint NameOffset;
    public uint Unknown2;
    public uint Unknown3;
    public uint Flags;
    public bool IsBranchVisible;
    public uint NrChildren;
    public uint Unknown7;
    public uint NrAnimationGroupDescriptions;
    public uint AnimationGroupDescriptionsDictOffset;
    public Vector3 Scale;
    public Vector3 Rotation;
    public Vector3 Translation;
    public float[] LocalMatrix;
    public float[] WorldMatrix;
    public uint NrMeshes;
    public uint MeshOffsetsOffset;
    public uint NrMaterials;
    public uint MaterialsDictOffset;
    public uint NrShapes;
    public uint ShapeOffsetsOffset;
    public uint NrMeshNodes;
    public uint MeshNodeVisibilitiesDictOffset;
    public uint Unknown23;
    public uint Unknown24;
    public uint Unknown25;
    public uint SkeletonInfoSOBJOffset;
    public uint[] MeshOffsets;
    public uint[] ShapeOffsets;
    public string Name;
    public DICT AnimationInfoDict;
    public DICT MaterialsDict;
    public DICT MeshNodeVisibilitiesDict;
    public CMDL.GraphicsAnimationGroup[] AnimationGroupDescriptions;
    public CMDL.Mesh[] Meshes;
    public CMDL.SeparateDataShape[] Shapes;
    public CMDL.SkeletonCtr Skeleton;
    public CMDL.MeshNodeVisibilityCtr[] MeshNodeVisibilities;
    public CMDL.MTOB[] Materials;

    public CMDL(string Name)
    {
      this.Type = 1073741842U;
      this.Signature = "CMDL";
      this.Revision = 150994944U;
      this.Name = Name;
      this.Flags = 1U;
      this.IsBranchVisible = true;
      this.Scale = new Vector3(1f, 1f, 1f);
      this.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      this.Translation = new Vector3(0.0f, 0.0f, 0.0f);
      this.LocalMatrix = new float[12]
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
      };
      this.WorldMatrix = new float[12]
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
      };
      this.Unknown23 = 1U;
    }

    public CMDL(EndianBinaryReader er)
    {
      this.Type = er.ReadUInt32();
      this.Signature = er.ReadString(Encoding.ASCII, 4);
      if (this.Signature != "CMDL")
        throw new SignatureNotCorrectException(this.Signature, "CMDL", er.BaseStream.Position);
      this.Revision = er.ReadUInt32();
      this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      this.Unknown2 = er.ReadUInt32();
      this.Unknown3 = er.ReadUInt32();
      this.Flags = er.ReadUInt32();
      this.IsBranchVisible = (int) er.ReadUInt32() == 1;
      this.NrChildren = er.ReadUInt32();
      this.Unknown7 = er.ReadUInt32();
      this.NrAnimationGroupDescriptions = er.ReadUInt32();
      this.AnimationGroupDescriptionsDictOffset = er.ReadUInt32();
      if ((int) this.AnimationGroupDescriptionsDictOffset != 0)
        this.AnimationGroupDescriptionsDictOffset = this.AnimationGroupDescriptionsDictOffset + ((uint) er.BaseStream.Position - 4U);
      this.Scale = er.ReadVector3();
      this.Rotation = er.ReadVector3();
      this.Translation = er.ReadVector3();
      this.LocalMatrix = er.ReadSingles(12);
      this.WorldMatrix = er.ReadSingles(12);
      this.NrMeshes = er.ReadUInt32();
      this.MeshOffsetsOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      this.NrMaterials = er.ReadUInt32();
      this.MaterialsDictOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      this.NrShapes = er.ReadUInt32();
      this.ShapeOffsetsOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      this.NrMeshNodes = er.ReadUInt32();
      this.MeshNodeVisibilitiesDictOffset = er.ReadUInt32();
      if ((int) this.MeshNodeVisibilitiesDictOffset != 0)
        this.MeshNodeVisibilitiesDictOffset = this.MeshNodeVisibilitiesDictOffset + ((uint) er.BaseStream.Position - 4U);
      this.Unknown23 = er.ReadUInt32();
      this.Unknown24 = er.ReadUInt32();
      this.Unknown25 = er.ReadUInt32();
      if (((int) this.Type & 128) != 0)
        this.SkeletonInfoSOBJOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
      long position = er.BaseStream.Position;
      er.BaseStream.Position = (long) this.NameOffset;
      this.Name = er.ReadStringNT(Encoding.ASCII);
      if ((int) this.AnimationGroupDescriptionsDictOffset != 0)
      {
        er.BaseStream.Position = (long) this.AnimationGroupDescriptionsDictOffset;
        this.AnimationInfoDict = new DICT(er);
      }
      er.BaseStream.Position = (long) this.MeshOffsetsOffset;
      this.MeshOffsets = new uint[(int) this.NrMeshes];
      for (int index = 0; (long) index < (long) this.NrMeshes; ++index)
        this.MeshOffsets[index] = (uint) er.BaseStream.Position + er.ReadUInt32();
      er.BaseStream.Position = (long) this.MaterialsDictOffset;
      this.MaterialsDict = new DICT(er);
      this.Materials = new CMDL.MTOB[(int) this.NrMaterials];
      for (int index = 0; (long) index < (long) this.NrMaterials; ++index)
      {
        er.BaseStream.Position = (long) this.MaterialsDict[index].DataOffset;
        this.Materials[index] = new CMDL.MTOB(er);
      }
      er.BaseStream.Position = (long) this.ShapeOffsetsOffset;
      this.ShapeOffsets = new uint[(int) this.NrShapes];
      for (int index = 0; (long) index < (long) this.NrShapes; ++index)
        this.ShapeOffsets[index] = (uint) er.BaseStream.Position + er.ReadUInt32();
      if ((int) this.MeshNodeVisibilitiesDictOffset != 0)
      {
        er.BaseStream.Position = (long) this.MeshNodeVisibilitiesDictOffset;
        this.MeshNodeVisibilitiesDict = new DICT(er);
      }
      this.AnimationGroupDescriptions = new CMDL.GraphicsAnimationGroup[(int) this.NrAnimationGroupDescriptions];
      for (int index = 0; (long) index < (long) this.NrAnimationGroupDescriptions; ++index)
      {
        er.BaseStream.Position = (long) this.AnimationInfoDict[index].DataOffset;
        this.AnimationGroupDescriptions[index] = new CMDL.GraphicsAnimationGroup(er);
      }
      this.Meshes = new CMDL.Mesh[(int) this.NrMeshes];
      for (int index = 0; (long) index < (long) this.NrMeshes; ++index)
      {
        er.BaseStream.Position = (long) this.MeshOffsets[index];
        this.Meshes[index] = new CMDL.Mesh(er);
      }
      this.Shapes = new CMDL.SeparateDataShape[(int) this.NrShapes];
      for (int index = 0; (long) index < (long) this.NrShapes; ++index)
      {
        er.BaseStream.Position = (long) this.ShapeOffsets[index];
        this.Shapes[index] = new CMDL.SeparateDataShape(er);
      }
      this.MeshNodeVisibilities = new CMDL.MeshNodeVisibilityCtr[(int) this.NrMeshNodes];
      for (int index = 0; (long) index < (long) this.NrMeshNodes; ++index)
      {
        er.BaseStream.Position = (long) this.MeshNodeVisibilitiesDict[index].DataOffset;
        this.MeshNodeVisibilities[index] = new CMDL.MeshNodeVisibilityCtr(er);
      }
      if (((int) this.Type & 128) != 0)
      {
        er.BaseStream.Position = (long) this.SkeletonInfoSOBJOffset;
        this.Skeleton = new CMDL.SkeletonCtr(er);
      }
      er.BaseStream.Position = position;
    }

    public void Write(EndianBinaryWriter er, CGFXWriterContext c)
    {
      long position1 = er.BaseStream.Position;
      er.Write(this.Type);
      er.Write(this.Signature, Encoding.ASCII, false);
      er.Write(this.Revision);
      c.WriteStringReference(this.Name, er);
      er.Write(this.Unknown2);
      er.Write(this.Unknown3);
      er.Write(this.Flags);
      er.Write(this.IsBranchVisible ? 1U : 0U);
      er.Write(this.NrChildren);
      er.Write(this.Unknown7);
      er.Write(this.NrAnimationGroupDescriptions);
      long position2 = er.BaseStream.Position;
      er.Write(0U);
      er.WriteVector3(this.Scale);
      er.WriteVector3(this.Rotation);
      er.WriteVector3(this.Translation);
      er.Write(this.LocalMatrix, 0, 12);
      er.Write(this.WorldMatrix, 0, 12);
      er.Write(this.NrMeshes);
      long position3 = er.BaseStream.Position;
      er.Write(0U);
      er.Write(this.NrMaterials);
      long position4 = er.BaseStream.Position;
      er.Write(0U);
      er.Write(this.NrShapes);
      long position5 = er.BaseStream.Position;
      er.Write(0U);
      er.Write(this.NrMeshNodes);
      long position6 = er.BaseStream.Position;
      er.Write(0U);
      er.Write(this.Unknown23);
      er.Write(this.Unknown24);
      er.Write(this.Unknown25);
      long position7 = er.BaseStream.Position;
      if (this.Skeleton != null)
        er.Write(0U);
      while (er.BaseStream.Position % 8L != 0L)
        er.Write((byte) 0);
      long position8 = er.BaseStream.Position;
      er.BaseStream.Position = position3;
      er.Write((uint) (position8 - position3));
      er.BaseStream.Position = position8;
      er.Write(new uint[(int) this.NrMeshes], 0, (int) this.NrMeshes);
      long position9 = er.BaseStream.Position;
      er.BaseStream.Position = position5;
      er.Write((uint) (position9 - position5));
      er.BaseStream.Position = position9;
      er.Write(new uint[(int) this.NrShapes], 0, (int) this.NrShapes);
      long position10 = er.BaseStream.Position;
      if ((int) this.NrAnimationGroupDescriptions != 0 && this.AnimationInfoDict != null)
      {
        er.BaseStream.Position = position2;
        er.Write((uint) (position10 - position2));
        er.BaseStream.Position = position10;
        this.AnimationInfoDict.Write(er, c);
      }
      long position11 = er.BaseStream.Position;
      if ((int) this.NrMaterials != 0 && this.MaterialsDict != null)
      {
        er.BaseStream.Position = position4;
        er.Write((uint) (position11 - position4));
        er.BaseStream.Position = position11;
        this.MaterialsDict.Write(er, c);
      }
      long position12 = er.BaseStream.Position;
      if ((int) this.NrMeshNodes != 0 && this.MeshNodeVisibilitiesDict != null)
      {
        er.BaseStream.Position = position6;
        er.Write((uint) (position12 - position6));
        er.BaseStream.Position = position12;
        this.MeshNodeVisibilitiesDict.Write(er, c);
      }
      for (int index = 0; (long) index < (long) this.NrAnimationGroupDescriptions; ++index)
      {
        long position13 = er.BaseStream.Position;
        long num = er.BaseStream.Position = position10 + 28L + (long) (index * 16) + 12L;
        er.Write((uint) (position13 - num));
        er.BaseStream.Position = position13;
        this.AnimationGroupDescriptions[index].Write(er, c);
      }
      for (int index = 0; (long) index < (long) this.NrMeshes; ++index)
      {
        while (er.BaseStream.Position % 8L != 0L)
          er.Write((byte) 0);
        long position13 = er.BaseStream.Position;
        long num = er.BaseStream.Position = position8 + (long) (index * 4);
        er.Write((uint) (position13 - num));
        er.BaseStream.Position = position13;
        this.Meshes[index].Write(er, c, position1);
      }
      for (int index = 0; (long) index < (long) this.NrMaterials; ++index)
      {
        long position13 = er.BaseStream.Position;
        long num = er.BaseStream.Position = position11 + 28L + (long) (index * 16) + 12L;
        er.Write((uint) (position13 - num));
        er.BaseStream.Position = position13;
        this.Materials[index].Write(er, c);
      }
      for (int index = 0; (long) index < (long) this.NrShapes; ++index)
      {
        long position13 = er.BaseStream.Position;
        long num = er.BaseStream.Position = position9 + (long) (index * 4);
        er.Write((uint) (position13 - num));
        er.BaseStream.Position = position13;
        this.Shapes[index].Write(er, c);
      }
      for (int index = 0; (long) index < (long) this.NrMeshNodes; ++index)
      {
        long position13 = er.BaseStream.Position;
        long num = er.BaseStream.Position = position12 + 28L + (long) (index * 16) + 12L;
        er.Write((uint) (position13 - num));
        er.BaseStream.Position = position13;
        this.MeshNodeVisibilities[index].Write(er, c);
      }
    }

    public OBJ ToOBJ()
    {
      OBJ obj = new OBJ();
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int index = 0;
      CMDL cmdl = this;
      foreach (CMDL.SeparateDataShape separateDataShape in cmdl.Shapes)
      {
        CMDL Model = cmdl;
        Polygon vertexData = separateDataShape.GetVertexData(Model);
        CMDL.MTOB mtob = cmdl.Materials[(int) cmdl.Meshes[index].MaterialIndex];
        int num4 = -1;
        if (mtob.NrActiveTextureCoordiators > 0U && (int) mtob.TextureCoordiators[0].MappingMethod == 0)
          num4 = (int) mtob.TextureCoordiators[0].SourceCoordinate != 0 ? ((int) mtob.TextureCoordiators[0].SourceCoordinate != 1 ? 2 : 1) : 0;
        foreach (CMDL.SeparateDataShape.PrimitiveSet.Primitive.IndexStreamCtr indexStreamCtr in separateDataShape.PrimitiveSets[0].Primitives[0].IndexStreams)
        {
          foreach (Vector3 vector3 in indexStreamCtr.GetFaceData())
          {
            OBJ.OBJFace objFace = new OBJ.OBJFace();
            objFace.Material = mtob.Name;
            obj.Vertices.Add(vertexData.Vertex[(int) vector3.X]);
            obj.Vertices.Add(vertexData.Vertex[(int) vector3.Y]);
            obj.Vertices.Add(vertexData.Vertex[(int) vector3.Z]);
            objFace.VertexIndieces.Add(num1);
            objFace.VertexIndieces.Add(num1 + 1);
            objFace.VertexIndieces.Add(num1 + 2);
            num1 += 3;
            if (vertexData.Normals != null)
            {
              obj.Normals.Add(vertexData.Normals[(int) vector3.X]);
              obj.Normals.Add(vertexData.Normals[(int) vector3.Y]);
              obj.Normals.Add(vertexData.Normals[(int) vector3.Z]);
              objFace.NormalIndieces.Add(num2);
              objFace.NormalIndieces.Add(num2 + 1);
              objFace.NormalIndieces.Add(num2 + 2);
              num2 += 3;
            }
            if (num4 == 0)
            {
              obj.TexCoords.Add(vertexData.TexCoords[(int) vector3.X] * new Matrix34(mtob.TextureCoordiators[0].Matrix));
              obj.TexCoords.Add(vertexData.TexCoords[(int) vector3.Y] * new Matrix34(mtob.TextureCoordiators[0].Matrix));
              obj.TexCoords.Add(vertexData.TexCoords[(int) vector3.Z] * new Matrix34(mtob.TextureCoordiators[0].Matrix));
            }
            else if (num4 == 1)
            {
              obj.TexCoords.Add(vertexData.TexCoords2[(int) vector3.X] * new Matrix34(mtob.TextureCoordiators[0].Matrix));
              obj.TexCoords.Add(vertexData.TexCoords2[(int) vector3.Y] * new Matrix34(mtob.TextureCoordiators[0].Matrix));
              obj.TexCoords.Add(vertexData.TexCoords2[(int) vector3.Z] * new Matrix34(mtob.TextureCoordiators[0].Matrix));
            }
            else if (num4 == 2)
            {
              obj.TexCoords.Add(vertexData.TexCoords3[(int) vector3.X] * new Matrix34(mtob.TextureCoordiators[0].Matrix));
              obj.TexCoords.Add(vertexData.TexCoords3[(int) vector3.Y] * new Matrix34(mtob.TextureCoordiators[0].Matrix));
              obj.TexCoords.Add(vertexData.TexCoords3[(int) vector3.Z] * new Matrix34(mtob.TextureCoordiators[0].Matrix));
            }
            else
              goto label_14;
            objFace.TexCoordIndieces.Add(num3);
            objFace.TexCoordIndieces.Add(num3 + 1);
            objFace.TexCoordIndieces.Add(num3 + 2);
            num3 += 3;
label_14:
            obj.Faces.Add(objFace);
          }
        }
        ++index;
      }
      return obj;
    }

    public DAE ToDAE(CGFX Resource)
    {
      CMDL Model = this;
      DAE dae = new DAE();
      dae.Content.scene = new DAE.COLLADA._scene();
      dae.Content.scene.instance_visual_scene = new DAE.InstanceWithExtra();
      dae.Content.scene.instance_visual_scene.url = "#ID1";
      dae.Content.library_visual_scenes = new DAE.library_visual_scenes();
      DAE.visual_scene visualScene = new DAE.visual_scene("ID1");
      DAE.node node = new DAE.node(Model.Name);
      visualScene.node.Add(node);
      dae.Content.library_visual_scenes.visual_scene.Add(visualScene);
      dae.Content.library_geometries = new DAE.library_geometries();
      dae.Content.library_materials = new DAE.library_materials();
      dae.Content.library_effects = new DAE.library_effects();
      if (Resource.Data.Textures != null && Resource.Data.Textures.Length != 0)
        dae.Content.library_images = new DAE.library_images();
      int num1 = 2;
      foreach (CMDL.MTOB mtob in Model.Materials)
      {
        DAE.material material1 = new DAE.material();
        DAE.material material2 = material1;
        string str1 = "ID";
        int num2 = num1;
        int num3 = 1;
        int num4 = num2 + num3;
        string str2 = str1 + num2;
        material2.id = str2;
        material1.name = mtob.Name;
        DAE.effect effect1 = new DAE.effect();
        DAE.effect effect2 = effect1;
        string str3 = "ID";
        int num5 = num4;
        int num6 = 1;
        num1 = num5 + num6;
        string str4 = str3 + num5;
        effect2.id = str4;
        material1.instance_effect = new DAE.instance_effect();
        material1.instance_effect.url = "#" + effect1.id;
        effect1.profile_COMMON = new DAE.profile_COMMON();
        effect1.profile_COMMON.technique = new DAE.profile_COMMON._technique();
        effect1.profile_COMMON.technique.sid = "COMMON";
        effect1.profile_COMMON.technique.lambert = new DAE.profile_COMMON._technique._lambert();
        effect1.profile_COMMON.technique.lambert.diffuse = new DAE.common_color_or_texture_type();
        if (mtob.Tex0 != null && mtob.Tex0.TextureObject is ReferenceTexture)
        {
          string str5 = "ID";
          int num7 = num1;
          int num8 = 1;
          int num9 = num7 + num8;
          string str6 = str5 + num7;
          List<DAE.image> list1 = dae.Content.library_images.image;
          DAE.image image = new DAE.image();
          string str7 = str6;
          image.id = str7;
          string str8 = "Tex/" + ((ReferenceTexture) mtob.Tex0.TextureObject).LinkedTextureName + ".png";
          image.init_from = str8;
          list1.Add(image);
          DAE.common_newparam_type commonNewparamType1 = new DAE.common_newparam_type();
          string str9 = "ID";
          int num10 = num9;
          int num11 = 1;
          int num12 = num10 + num11;
          string str10 = str9 + num10;
          commonNewparamType1.sid = str10;
          DAE.fx_surface_common fxSurfaceCommon = new DAE.fx_surface_common();
          int num13 = 2;
          fxSurfaceCommon.type = (DAE.fx_surface_type_enum) num13;
          commonNewparamType1.choice = (object) fxSurfaceCommon;
          DAE.common_newparam_type commonNewparamType2 = commonNewparamType1;
          List<DAE.fx_surface_init_from_common> list2 = ((DAE.fx_surface_common) commonNewparamType2.choice).init_from;
          DAE.fx_surface_init_from_common surfaceInitFromCommon = new DAE.fx_surface_init_from_common();
          string str11 = str6;
          surfaceInitFromCommon.content = str11;
          list2.Add(surfaceInitFromCommon);
          effect1.profile_COMMON.newparam = new List<DAE.common_newparam_type>();
          effect1.profile_COMMON.newparam.Add(commonNewparamType2);
          List<DAE.common_newparam_type> list3 = effect1.profile_COMMON.newparam;
          DAE.common_newparam_type commonNewparamType3 = new DAE.common_newparam_type();
          string str12 = "ID";
          int num14 = num12;
          int num15 = 1;
          num1 = num14 + num15;
          string str13 = str12 + num14;
          commonNewparamType3.sid = str13;
          DAE.fx_sampler2D_common fxSampler2DCommon = new DAE.fx_sampler2D_common();
          string str14 = commonNewparamType2.sid;
          fxSampler2DCommon.source = str14;
          commonNewparamType3.choice = (object) fxSampler2DCommon;
          list3.Add(commonNewparamType3);
          DAE.common_color_or_texture_type colorOrTextureType = effect1.profile_COMMON.technique.lambert.diffuse;
          DAE.common_color_or_texture_type._texture texture = new DAE.common_color_or_texture_type._texture();
          string str15 = effect1.profile_COMMON.newparam[1].sid;
          texture.texture = str15;
          string str16 = "UVSET0";
          texture.texcoord = str16;
          colorOrTextureType.texture = texture;
        }
        else
        {
          effect1.profile_COMMON.technique.lambert.diffuse.color = new DAE.common_color_or_texture_type._color();
          effect1.profile_COMMON.technique.lambert.diffuse.color.content = Color.White;
        }
        dae.Content.library_materials.material.Add(material1);
        dae.Content.library_effects.effect.Add(effect1);
      }
      int index = 0;
      foreach (CMDL.SeparateDataShape separateDataShape in Model.Shapes)
      {
        DAE.geometry geometry1 = new DAE.geometry();
        DAE.geometry geometry2 = geometry1;
        string str1 = "ID";
        int num2 = num1;
        int num3 = 1;
        int num4 = num2 + num3;
        string str2 = str1 + num2;
        geometry2.id = str2;
        Polygon vertexData = separateDataShape.GetVertexData(Model);
        CMDL.MTOB mtob = Model.Materials[(int) Model.Meshes[index].MaterialIndex];
        geometry1.mesh = new DAE.mesh();
        DAE.mesh mesh = geometry1.mesh;
        DAE.vertices vertices = new DAE.vertices();
        string str3 = "ID";
        int num5 = num4;
        int num6 = 1;
        num1 = num5 + num6;
        string str4 = str3 + num5;
        vertices.id = str4;
        mesh.vertices = vertices;
        if (vertexData.Vertex != null)
        {
          DAE.source source1 = new DAE.source();
          string str5 = "ID";
          int num7 = num1;
          int num8 = 1;
          int num9 = num7 + num8;
          string str6 = str5 + num7;
          source1.id = str6;
          DAE.source source2 = source1;
          DAE.source source3 = source2;
          DAE.source._float_array floatArray = new DAE.source._float_array();
          string str7 = "ID";
          int num10 = num9;
          int num11 = 1;
          num1 = num10 + num11;
          string str8 = str7 + num10;
          floatArray.id = str8;
          long num12 = (long) (uint) (vertexData.Vertex.Length * 3);
          floatArray.count = (ulong) num12;
          source3.float_array = floatArray;
          foreach (Vector3 vector3 in vertexData.Vertex)
          {
            source2.float_array.content.Add((double) vector3.X);
            source2.float_array.content.Add((double) vector3.Y);
            source2.float_array.content.Add((double) vector3.Z);
          }
          source2.technique_common = new DAE.source._technique_common();
          source2.technique_common.accessor = new DAE.accessor();
          source2.technique_common.accessor.count = (ulong) (uint) vertexData.Vertex.Length;
          source2.technique_common.accessor.source = "#" + source2.float_array.id;
          source2.technique_common.accessor.stride = 3UL;
          List<DAE.param> list1 = source2.technique_common.accessor.param;
          DAE.param obj1 = new DAE.param();
          string str9 = "X";
          obj1.name = str9;
          string str10 = "float";
          obj1.type = str10;
          list1.Add(obj1);
          List<DAE.param> list2 = source2.technique_common.accessor.param;
          DAE.param obj2 = new DAE.param();
          string str11 = "Y";
          obj2.name = str11;
          string str12 = "float";
          obj2.type = str12;
          list2.Add(obj2);
          List<DAE.param> list3 = source2.technique_common.accessor.param;
          DAE.param obj3 = new DAE.param();
          string str13 = "Z";
          obj3.name = str13;
          string str14 = "float";
          obj3.type = str14;
          list3.Add(obj3);
          geometry1.mesh.source.Add(source2);
          List<DAE.InputLocal> list4 = geometry1.mesh.vertices.input;
          DAE.InputLocal inputLocal = new DAE.InputLocal();
          string str15 = "POSITION";
          inputLocal.semantic = str15;
          string str16 = "#" + source2.id;
          inputLocal.source = str16;
          list4.Add(inputLocal);
        }
        if (vertexData.Normals != null)
        {
          DAE.source source1 = new DAE.source();
          string str5 = "ID";
          int num7 = num1;
          int num8 = 1;
          int num9 = num7 + num8;
          string str6 = str5 + num7;
          source1.id = str6;
          DAE.source source2 = source1;
          DAE.source source3 = source2;
          DAE.source._float_array floatArray = new DAE.source._float_array();
          string str7 = "ID";
          int num10 = num9;
          int num11 = 1;
          num1 = num10 + num11;
          string str8 = str7 + num10;
          floatArray.id = str8;
          long num12 = (long) (uint) (vertexData.Normals.Length * 3);
          floatArray.count = (ulong) num12;
          source3.float_array = floatArray;
          foreach (Vector3 vector3 in vertexData.Normals)
          {
            source2.float_array.content.Add((double) vector3.X);
            source2.float_array.content.Add((double) vector3.Y);
            source2.float_array.content.Add((double) vector3.Z);
          }
          source2.technique_common = new DAE.source._technique_common();
          source2.technique_common.accessor = new DAE.accessor();
          source2.technique_common.accessor.count = (ulong) (uint) vertexData.Normals.Length;
          source2.technique_common.accessor.source = "#" + source2.float_array.id;
          source2.technique_common.accessor.stride = 3UL;
          List<DAE.param> list1 = source2.technique_common.accessor.param;
          DAE.param obj1 = new DAE.param();
          string str9 = "X";
          obj1.name = str9;
          string str10 = "float";
          obj1.type = str10;
          list1.Add(obj1);
          List<DAE.param> list2 = source2.technique_common.accessor.param;
          DAE.param obj2 = new DAE.param();
          string str11 = "Y";
          obj2.name = str11;
          string str12 = "float";
          obj2.type = str12;
          list2.Add(obj2);
          List<DAE.param> list3 = source2.technique_common.accessor.param;
          DAE.param obj3 = new DAE.param();
          string str13 = "Z";
          obj3.name = str13;
          string str14 = "float";
          obj3.type = str14;
          list3.Add(obj3);
          geometry1.mesh.source.Add(source2);
          List<DAE.InputLocal> list4 = geometry1.mesh.vertices.input;
          DAE.InputLocal inputLocal = new DAE.InputLocal();
          string str15 = "NORMAL";
          inputLocal.semantic = str15;
          string str16 = "#" + source2.id;
          inputLocal.source = str16;
          list4.Add(inputLocal);
        }
        DAE.source source4 = (DAE.source) null;
        if (vertexData.TexCoords != null && mtob.NrActiveTextureCoordiators > 0U && (int) mtob.TextureCoordiators[0].MappingMethod == 0)
        {
          Vector2[] vector2Array = (int) mtob.TextureCoordiators[0].SourceCoordinate != 0 ? ((int) mtob.TextureCoordiators[0].SourceCoordinate != 1 ? Enumerable.ToArray<Vector2>((IEnumerable<Vector2>) vertexData.TexCoords3) : Enumerable.ToArray<Vector2>((IEnumerable<Vector2>) vertexData.TexCoords2)) : Enumerable.ToArray<Vector2>((IEnumerable<Vector2>) vertexData.TexCoords);
          DAE.source source1 = new DAE.source();
          string str5 = "ID";
          int num7 = num1;
          int num8 = 1;
          int num9 = num7 + num8;
          string str6 = str5 + num7;
          source1.id = str6;
          source4 = source1;
          DAE.source source2 = source1;
          DAE.source source3 = source2;
          DAE.source._float_array floatArray = new DAE.source._float_array();
          string str7 = "ID";
          int num10 = num9;
          int num11 = 1;
          num1 = num10 + num11;
          string str8 = str7 + num10;
          floatArray.id = str8;
          long num12 = (long) (uint) (vector2Array.Length * 2);
          floatArray.count = (ulong) num12;
          source3.float_array = floatArray;
          foreach (Vector2 vector2_1 in vector2Array)
          {
            Vector2 vector2_2 = vector2_1 * new Matrix34(mtob.TextureCoordiators[0].Matrix);
            source2.float_array.content.Add((double) vector2_2.X);
            source2.float_array.content.Add((double) vector2_2.Y);
          }
          source2.technique_common = new DAE.source._technique_common();
          source2.technique_common.accessor = new DAE.accessor();
          source2.technique_common.accessor.count = (ulong) (uint) vertexData.TexCoords.Length;
          source2.technique_common.accessor.source = "#" + source2.float_array.id;
          source2.technique_common.accessor.stride = 2UL;
          List<DAE.param> list1 = source2.technique_common.accessor.param;
          DAE.param obj1 = new DAE.param();
          string str9 = "S";
          obj1.name = str9;
          string str10 = "float";
          obj1.type = str10;
          list1.Add(obj1);
          List<DAE.param> list2 = source2.technique_common.accessor.param;
          DAE.param obj2 = new DAE.param();
          string str11 = "T";
          obj2.name = str11;
          string str12 = "float";
          obj2.type = str12;
          list2.Add(obj2);
          geometry1.mesh.source.Add(source2);
        }
        DAE.source source5 = (DAE.source) null;
        if (vertexData.Colors != null)
        {
          DAE.source source1 = new DAE.source();
          string str5 = "ID";
          int num7 = num1;
          int num8 = 1;
          int num9 = num7 + num8;
          string str6 = str5 + num7;
          source1.id = str6;
          source5 = source1;
          DAE.source source2 = source1;
          DAE.source source3 = source2;
          DAE.source._float_array floatArray = new DAE.source._float_array();
          string str7 = "ID";
          int num10 = num9;
          int num11 = 1;
          num1 = num10 + num11;
          string str8 = str7 + num10;
          floatArray.id = str8;
          long num12 = (long) (uint) (vertexData.Colors.Length * 4);
          floatArray.count = (ulong) num12;
          source3.float_array = floatArray;
          foreach (Color color in vertexData.Colors)
          {
            source2.float_array.content.Add((double) color.R / (double) byte.MaxValue);
            source2.float_array.content.Add((double) color.G / (double) byte.MaxValue);
            source2.float_array.content.Add((double) color.B / (double) byte.MaxValue);
            source2.float_array.content.Add((double) color.A / (double) byte.MaxValue);
          }
          source2.technique_common = new DAE.source._technique_common();
          source2.technique_common.accessor = new DAE.accessor();
          source2.technique_common.accessor.count = (ulong) (uint) vertexData.Colors.Length;
          source2.technique_common.accessor.source = "#" + source2.float_array.id;
          source2.technique_common.accessor.stride = 4UL;
          List<DAE.param> list1 = source2.technique_common.accessor.param;
          DAE.param obj1 = new DAE.param();
          string str9 = "R";
          obj1.name = str9;
          string str10 = "float";
          obj1.type = str10;
          list1.Add(obj1);
          List<DAE.param> list2 = source2.technique_common.accessor.param;
          DAE.param obj2 = new DAE.param();
          string str11 = "G";
          obj2.name = str11;
          string str12 = "float";
          obj2.type = str12;
          list2.Add(obj2);
          List<DAE.param> list3 = source2.technique_common.accessor.param;
          DAE.param obj3 = new DAE.param();
          string str13 = "B";
          obj3.name = str13;
          string str14 = "float";
          obj3.type = str14;
          list3.Add(obj3);
          List<DAE.param> list4 = source2.technique_common.accessor.param;
          DAE.param obj4 = new DAE.param();
          string str15 = "A";
          obj4.name = str15;
          string str16 = "float";
          obj4.type = str16;
          list4.Add(obj4);
          geometry1.mesh.source.Add(source2);
        }
        foreach (CMDL.SeparateDataShape.PrimitiveSet.Primitive.IndexStreamCtr indexStreamCtr in separateDataShape.PrimitiveSets[0].Primitives[0].IndexStreams)
        {
          Vector3[] faceData = indexStreamCtr.GetFaceData();
          DAE.triangles triangles1 = new DAE.triangles();
          long num7 = (long) (uint) faceData.Length;
          triangles1.count = (ulong) num7;
          string str5 = mtob.Name;
          triangles1.material = str5;
          DAE.triangles triangles2 = triangles1;
          uint num8 = 0U;
          List<DAE.InputLocalOffset> list1 = triangles2.input;
          DAE.InputLocalOffset inputLocalOffset1 = new DAE.InputLocalOffset();
          int num9 = (int) num8;
          int num10 = 1;
          uint num11 = (uint) (num9 + num10);
          long num12 = (long) (uint) num9;
          inputLocalOffset1.offset = (ulong) num12;
          string str6 = "VERTEX";
          inputLocalOffset1.semantic = str6;
          string str7 = "#" + geometry1.mesh.vertices.id;
          inputLocalOffset1.source = str7;
          list1.Add(inputLocalOffset1);
          if (source4 != null)
          {
            List<DAE.InputLocalOffset> list2 = triangles2.input;
            DAE.InputLocalOffset inputLocalOffset2 = new DAE.InputLocalOffset();
            long num13 = (long) num11++;
            inputLocalOffset2.offset = (ulong) num13;
            string str8 = "TEXCOORD";
            inputLocalOffset2.semantic = str8;
            string str9 = "#" + source4.id;
            inputLocalOffset2.source = str9;
            list2.Add(inputLocalOffset2);
          }
          if (source5 != null)
          {
            List<DAE.InputLocalOffset> list2 = triangles2.input;
            DAE.InputLocalOffset inputLocalOffset2 = new DAE.InputLocalOffset();
            int num13 = (int) num11;
            int num14 = 1;
            uint num15 = (uint) (num13 + num14);
            long num16 = (long) (uint) num13;
            inputLocalOffset2.offset = (ulong) num16;
            string str8 = "COLOR";
            inputLocalOffset2.semantic = str8;
            string str9 = "#" + source5.id;
            inputLocalOffset2.source = str9;
            long num17 = 0L;
            inputLocalOffset2.set = (ulong) num17;
            list2.Add(inputLocalOffset2);
          }
          triangles2.p.Add(new DAE.p());
          foreach (Vector3 vector3 in faceData)
          {
            triangles2.p[0].content.Add((ulong) vector3.X);
            if (source4 != null)
              triangles2.p[0].content.Add((ulong) vector3.X);
            if (source5 != null)
              triangles2.p[0].content.Add((ulong) vector3.X);
            triangles2.p[0].content.Add((ulong) vector3.Y);
            if (source4 != null)
              triangles2.p[0].content.Add((ulong) vector3.Y);
            if (source5 != null)
              triangles2.p[0].content.Add((ulong) vector3.Y);
            triangles2.p[0].content.Add((ulong) vector3.Z);
            if (source4 != null)
              triangles2.p[0].content.Add((ulong) vector3.Z);
            if (source5 != null)
              triangles2.p[0].content.Add((ulong) vector3.Z);
          }
          geometry1.mesh.triangles.Add(triangles2);
        }
        dae.Content.library_geometries.geometry.Add(geometry1);
        DAE.instance_geometry instanceGeometry1 = new DAE.instance_geometry();
        string str17 = "#" + geometry1.id;
        instanceGeometry1.url = str17;
        DAE.instance_geometry instanceGeometry2 = instanceGeometry1;
        instanceGeometry2.bind_material = new DAE.bind_material();
        instanceGeometry2.bind_material.technique_common = new DAE.bind_material._technique_common();
        DAE.instance_material instanceMaterial = new DAE.instance_material();
        instanceMaterial.symbol = mtob.Name;
        instanceMaterial.target = "#" + dae.Content.library_materials.material[(int) Model.Meshes[index].MaterialIndex].id;
        List<DAE.instance_material._bind_vertex_input> list = instanceMaterial.bind_vertex_input;
        DAE.instance_material._bind_vertex_input bindVertexInput = new DAE.instance_material._bind_vertex_input();
        string str18 = "UVSET0";
        bindVertexInput.semantic = str18;
        string str19 = "TEXCOORD";
        bindVertexInput.input_semantic = str19;
        long num18 = 0L;
        bindVertexInput.input_set = (ulong) num18;
        list.Add(bindVertexInput);
        instanceGeometry2.bind_material.technique_common.instance_material.Add(instanceMaterial);
        node.instance_geometry.Add(instanceGeometry2);
        ++index;
      }
      return dae;
    }

    public MTL ToMTL(string TexDir)
    {
      MTL mtl = new MTL();
      foreach (CMDL.MTOB mtob in this.Materials)
      {
        MTL.MTLMaterial mtlMaterial1 = new MTL.MTLMaterial(mtob.Name);
        mtlMaterial1.DiffuseColor = mtob.MaterialColor.DiffuseU32;
        mtlMaterial1.AmbientColor = mtob.MaterialColor.AmbientU32;
        mtlMaterial1.Alpha = mtob.MaterialColor.Diffuse.W;
        mtlMaterial1.SpecularColor = mtob.MaterialColor.Specular0U32;
        if (mtob.Tex0 != null && mtob.Tex0.TextureObject is ReferenceTexture)
        {
          MTL.MTLMaterial mtlMaterial2 = mtlMaterial1;
          string str1 = TexDir.Replace('\\', '/');
          char[] chArray = new char[1];
          int index = 0;
          int num = 47;
          chArray[index] = (char) num;
          string str2 = str1.TrimEnd(chArray) + "/" + ((ReferenceTexture) mtob.Tex0.TextureObject).LinkedTextureName + ".png";
          mtlMaterial2.DiffuseMapPath = str2;
        }
        mtl.Materials.Add(mtlMaterial1);
      }
      return mtl;
    }

    public string ToMayaASCII(CGFX Resource)
    {
      MayaASCIIWriter mayaAsciiWriter1 = new MayaASCIIWriter();
      if (Resource.Data.Textures != null)
      {
        foreach (ImageTextureCtr imageTextureCtr in Resource.Data.Textures)
        {
          mayaAsciiWriter1.CreateNode("file", imageTextureCtr.Name.Replace('.', '_') + "_tex");
          mayaAsciiWriter1.BeginStatement("setAttr");
          mayaAsciiWriter1.WriteArgument("\".ftn\"");
          mayaAsciiWriter1.WriteArgument("-type", "\"string\"");
          mayaAsciiWriter1.WriteArgument("\"Tex/" + imageTextureCtr.Name + ".png\"");
          mayaAsciiWriter1.EndStatement();
          mayaAsciiWriter1.CreateNode("place2dTexture", imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.c", imageTextureCtr.Name.Replace('.', '_') + "_tex.c");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.tf", imageTextureCtr.Name.Replace('.', '_') + "_tex.tf");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.rf", imageTextureCtr.Name.Replace('.', '_') + "_tex.rf");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.mu", imageTextureCtr.Name.Replace('.', '_') + "_tex.mu");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.mv", imageTextureCtr.Name.Replace('.', '_') + "_tex.mv");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.s", imageTextureCtr.Name.Replace('.', '_') + "_tex.s");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.wu", imageTextureCtr.Name.Replace('.', '_') + "_tex.wu");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.wv", imageTextureCtr.Name.Replace('.', '_') + "_tex.wv");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.re", imageTextureCtr.Name.Replace('.', '_') + "_tex.re");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.of", imageTextureCtr.Name.Replace('.', '_') + "_tex.of");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.r", imageTextureCtr.Name.Replace('.', '_') + "_tex.ro");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.n", imageTextureCtr.Name.Replace('.', '_') + "_tex.n");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.vt1", imageTextureCtr.Name.Replace('.', '_') + "_tex.vt1");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.vt2", imageTextureCtr.Name.Replace('.', '_') + "_tex.vt2");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.vt3", imageTextureCtr.Name.Replace('.', '_') + "_tex.vt3");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.vc1", imageTextureCtr.Name.Replace('.', '_') + "_tex.vc1");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.o", imageTextureCtr.Name.Replace('.', '_') + "_tex.uv");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex_p2d.ofs", imageTextureCtr.Name.Replace('.', '_') + "_tex.fs");
          mayaAsciiWriter1.ConnectAttribute(imageTextureCtr.Name.Replace('.', '_') + "_tex.msg", ":defaultTextureList1.tx", true);
        }
      }
      foreach (CMDL.MTOB mtob in this.Materials)
      {
        mayaAsciiWriter1.CreateNode("phong", mtob.Name.Replace('.', '_'));
        mayaAsciiWriter1.BeginStatement("setAttr");
        mayaAsciiWriter1.WriteArgument("\".dc\"", 1);
        mayaAsciiWriter1.EndStatement();
        mayaAsciiWriter1.CreateNode("shadingEngine", mtob.Name.Replace('.', '_') + "_Sg");
        mayaAsciiWriter1.BeginStatement("setAttr");
        mayaAsciiWriter1.WriteArgument("\".ihi\"", 0);
        mayaAsciiWriter1.EndStatement();
        mayaAsciiWriter1.BeginStatement("setAttr");
        mayaAsciiWriter1.WriteArgument("\".ro\"", "yes");
        mayaAsciiWriter1.EndStatement();
        mayaAsciiWriter1.CreateNode("materialInfo", mtob.Name.Replace('.', '_') + "_In");
        mayaAsciiWriter1.ConnectAttribute(mtob.Name.Replace('.', '_') + ".oc", mtob.Name.Replace('.', '_') + "_Sg.ss");
        mayaAsciiWriter1.ConnectAttribute(mtob.Name.Replace('.', '_') + "_Sg.msg", mtob.Name.Replace('.', '_') + "_In.sg");
        mayaAsciiWriter1.ConnectAttribute(mtob.Name.Replace('.', '_') + ".msg", mtob.Name.Replace('.', '_') + "_In.m");
        mayaAsciiWriter1.ConnectAttribute(mtob.Name.Replace('.', '_') + "_Sg.pa", ":renderPartition.st", true);
        mayaAsciiWriter1.ConnectAttribute(mtob.Name.Replace('.', '_') + ".msg", ":defaultShaderList1.s", true);
        if (mtob.Tex0 != null && mtob.Tex0.TextureObject is ReferenceTexture)
        {
          mayaAsciiWriter1.ConnectAttribute(((ReferenceTexture) mtob.Tex0.TextureObject).LinkedTextureName.Replace('.', '_') + "_tex.oc", mtob.Name.Replace('.', '_') + ".c");
          mayaAsciiWriter1.ConnectAttribute(((ReferenceTexture) mtob.Tex0.TextureObject).LinkedTextureName.Replace('.', '_') + "_tex.msg", mtob.Name.Replace('.', '_') + "_In.t", true);
        }
      }
      int index = 0;
      foreach (CMDL.SeparateDataShape separateDataShape in this.Shapes)
      {
        CMDL.MTOB mtob = this.Materials[(int) this.Meshes[index].MaterialIndex];
        mayaAsciiWriter1.CreateNode("transform", "S" + (object) index + "_trans");
        mayaAsciiWriter1.CreateNode("mesh", "S" + (object) index + "_mesh", "S" + (object) index + "_trans");
        Polygon vertexData = separateDataShape.GetVertexData(this);
        int val1 = 0;
        foreach (CMDL.SeparateDataShape.PrimitiveSet.Primitive.IndexStreamCtr indexStreamCtr in separateDataShape.PrimitiveSets[0].Primitives[0].IndexStreams)
        {
          Vector3[] faceData = indexStreamCtr.GetFaceData();
          val1 += faceData.Length;
        }
        if (vertexData.TexCoords != null && mtob.NrActiveTextureCoordiators > 0U && (int) mtob.TextureCoordiators[0].MappingMethod == 0)
        {
          Vector2[] vector2Array = (int) mtob.TextureCoordiators[0].SourceCoordinate != 0 ? ((int) mtob.TextureCoordiators[0].SourceCoordinate != 1 ? vertexData.TexCoords3 : vertexData.TexCoords2) : vertexData.TexCoords;
          mayaAsciiWriter1.BeginStatement("setAttr");
          mayaAsciiWriter1.WriteArgument("\".uvst[0].uvsn\"");
          mayaAsciiWriter1.WriteArgument("-type", "\"string\"");
          mayaAsciiWriter1.WriteArgument("\"map1\"");
          mayaAsciiWriter1.EndStatement();
          mayaAsciiWriter1.BeginStatement("setAttr");
          mayaAsciiWriter1.WriteArgument("-s", vector2Array.Length);
          mayaAsciiWriter1.WriteArgument("\".uvst[0].uvsp[0:" + (object) (vector2Array.Length - 1) + "]\"");
          mayaAsciiWriter1.WriteArgument("-type", "\"float2\"");
          foreach (Vector2 vector2 in vector2Array)
          {
            mayaAsciiWriter1.WriteArgument(vector2.X);
            mayaAsciiWriter1.WriteArgument(vector2.Y);
          }
          mayaAsciiWriter1.EndStatement();
          mayaAsciiWriter1.BeginStatement("setAttr");
          mayaAsciiWriter1.WriteArgument("\".cuvs\"");
          mayaAsciiWriter1.WriteArgument("-type", "\"string\"");
          mayaAsciiWriter1.WriteArgument("\"map1\"");
          mayaAsciiWriter1.EndStatement();
        }
        if (vertexData.Vertex != null)
        {
          mayaAsciiWriter1.BeginStatement("setAttr");
          mayaAsciiWriter1.WriteArgument("-s", vertexData.Vertex.Length);
          mayaAsciiWriter1.WriteArgument("\".vt[0:" + (object) (vertexData.Vertex.Length - 1) + "]\"");
          foreach (Vector3 vector3 in vertexData.Vertex)
          {
            mayaAsciiWriter1.WriteArgument(vector3.X);
            mayaAsciiWriter1.WriteArgument(vector3.Y);
            mayaAsciiWriter1.WriteArgument(vector3.Z);
          }
          mayaAsciiWriter1.EndStatement();
          mayaAsciiWriter1.BeginStatement("setAttr");
          mayaAsciiWriter1.WriteArgument("-s", val1 * 3);
          mayaAsciiWriter1.WriteArgument("\".ed[0:" + (object) (val1 * 3 - 1) + "]\"");
          foreach (CMDL.SeparateDataShape.PrimitiveSet.Primitive.IndexStreamCtr indexStreamCtr in separateDataShape.PrimitiveSets[0].Primitives[0].IndexStreams)
          {
            foreach (Vector3 vector3 in indexStreamCtr.GetFaceData())
            {
              mayaAsciiWriter1.WriteArgument(vector3.X);
              mayaAsciiWriter1.WriteArgument(vector3.Y);
              mayaAsciiWriter1.WriteArgument(0);
              mayaAsciiWriter1.WriteArgument(vector3.Y);
              mayaAsciiWriter1.WriteArgument(vector3.Z);
              mayaAsciiWriter1.WriteArgument(0);
              mayaAsciiWriter1.WriteArgument(vector3.X);
              mayaAsciiWriter1.WriteArgument(vector3.Z);
              mayaAsciiWriter1.WriteArgument(0);
            }
          }
          mayaAsciiWriter1.EndStatement();
        }
        if (vertexData.Colors != null)
        {
          mayaAsciiWriter1.BeginStatement("setAttr");
          mayaAsciiWriter1.WriteArgument("-s", vertexData.Colors.Length);
          mayaAsciiWriter1.WriteArgument("\".clr[0:" + (object) (vertexData.Colors.Length - 1) + "]\"");
          foreach (Color color in vertexData.Colors)
          {
            mayaAsciiWriter1.WriteArgument((float) color.R / (float) byte.MaxValue);
            mayaAsciiWriter1.WriteArgument((float) color.G / (float) byte.MaxValue);
            mayaAsciiWriter1.WriteArgument((float) color.B / (float) byte.MaxValue);
            mayaAsciiWriter1.WriteArgument(1);
          }
          mayaAsciiWriter1.EndStatement();
        }
        mayaAsciiWriter1.BeginStatement("setAttr");
        mayaAsciiWriter1.WriteArgument("-s", val1);
        mayaAsciiWriter1.WriteArgument("\".fc[0:" + (object) (val1 - 1) + "]\"");
        mayaAsciiWriter1.WriteArgument("-type", "\"polyFaces\"");
        int num1 = 0;
        foreach (CMDL.SeparateDataShape.PrimitiveSet.Primitive.IndexStreamCtr indexStreamCtr in separateDataShape.PrimitiveSets[0].Primitives[0].IndexStreams)
        {
          foreach (Vector3 vector3 in indexStreamCtr.GetFaceData())
          {
            mayaAsciiWriter1.WriteArgument("\nf", 3);
            MayaASCIIWriter mayaAsciiWriter2 = mayaAsciiWriter1;
            int val2 = num1;
            int num2 = 1;
            int num3 = val2 + num2;
            mayaAsciiWriter2.WriteArgument(val2);
            MayaASCIIWriter mayaAsciiWriter3 = mayaAsciiWriter1;
            int val3 = num3;
            int num4 = 1;
            int num5 = val3 + num4;
            mayaAsciiWriter3.WriteArgument(val3);
            MayaASCIIWriter mayaAsciiWriter4 = mayaAsciiWriter1;
            int val4 = num5;
            int num6 = 1;
            num1 = val4 + num6;
            mayaAsciiWriter4.WriteArgument(val4);
            mayaAsciiWriter1.WriteArgument("\nmu", 0);
            mayaAsciiWriter1.WriteArgument(3);
            mayaAsciiWriter1.WriteArgument(vector3.X);
            mayaAsciiWriter1.WriteArgument(vector3.Y);
            mayaAsciiWriter1.WriteArgument(vector3.Z);
            if (vertexData.Colors != null)
            {
              mayaAsciiWriter1.WriteArgument("\nfc");
              mayaAsciiWriter1.WriteArgument(3);
              mayaAsciiWriter1.WriteArgument(vector3.X);
              mayaAsciiWriter1.WriteArgument(vector3.Y);
              mayaAsciiWriter1.WriteArgument(vector3.Z);
            }
          }
        }
        mayaAsciiWriter1.EndStatement();
        mayaAsciiWriter1.ConnectAttribute("S" + (object) index + "_mesh.iog", this.Materials[(int) this.Meshes[index].MaterialIndex].Name.Replace('.', '_') + "_Sg.dsm", true);
        ++index;
      }
      return mayaAsciiWriter1.Close();
    }

    public override string ToString()
    {
      return this.Name;
    }

    public class GraphicsAnimationGroup
    {
      public uint Type;
      public CMDL.GraphicsAnimationGroup.GraphicsAnimGroupFlags Flags;
      public uint NameOffset;
      public CMDL.GraphicsAnimationGroup.GraphicsMemberType MemberType;
      public uint NrMembers;
      public uint MemberInfoDICTOffset;
      public uint NrBlendOperations;
      public uint BlendOperationArrayOffset;
      public CMDL.GraphicsAnimationGroup.AnimGroupEvaluationTiming EvaluationTiming;
      public uint[] BlendOperations;
      public string Name;
      public DICT MemberInfoDICT;
      public CMDL.GraphicsAnimationGroup.AnimationGroupMember[] AnimationGroupMembers;

      public GraphicsAnimationGroup(EndianBinaryReader er)
      {
        this.Type = er.ReadUInt32();
        this.Flags = (CMDL.GraphicsAnimationGroup.GraphicsAnimGroupFlags) er.ReadUInt32();
        this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.MemberType = (CMDL.GraphicsAnimationGroup.GraphicsMemberType) er.ReadUInt32();
        this.NrMembers = er.ReadUInt32();
        this.MemberInfoDICTOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.NrBlendOperations = er.ReadUInt32();
        this.BlendOperationArrayOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.EvaluationTiming = (CMDL.GraphicsAnimationGroup.AnimGroupEvaluationTiming) er.ReadUInt32();
        long position = er.BaseStream.Position;
        er.BaseStream.Position = (long) this.NameOffset;
        this.Name = er.ReadStringNT(Encoding.ASCII);
        er.BaseStream.Position = (long) this.MemberInfoDICTOffset;
        this.MemberInfoDICT = new DICT(er);
        er.BaseStream.Position = (long) this.BlendOperationArrayOffset;
        this.BlendOperations = er.ReadUInt32s((int) this.NrBlendOperations);
        this.AnimationGroupMembers = new CMDL.GraphicsAnimationGroup.AnimationGroupMember[(int) this.NrMembers];
        for (int index = 0; (long) index < (long) this.NrMembers; ++index)
        {
          er.BaseStream.Position = (long) this.MemberInfoDICT[index].DataOffset;
          this.AnimationGroupMembers[index] = CMDL.GraphicsAnimationGroup.AnimationGroupMember.FromStream(er);
        }
        er.BaseStream.Position = position;
      }

      public void Write(EndianBinaryWriter er, CGFXWriterContext c)
      {
        er.Write(this.Type);
        er.Write((uint) this.Flags);
        c.WriteStringReference(this.Name, er);
        er.Write((uint) this.MemberType);
        er.Write(this.NrMembers);
        long position1 = er.BaseStream.Position;
        er.Write(0U);
        er.Write(this.NrBlendOperations);
        long position2 = er.BaseStream.Position;
        er.Write(0U);
        er.Write((uint) this.EvaluationTiming);
        long position3 = er.BaseStream.Position;
        er.BaseStream.Position = position2;
        er.Write((uint) (position3 - position2));
        er.BaseStream.Position = position3;
        er.Write(this.BlendOperations, 0, this.BlendOperations.Length);
        long position4;
        long num1 = position4 = er.BaseStream.Position;
        er.BaseStream.Position = position1;
        er.Write((uint) (position4 - position1));
        er.BaseStream.Position = position4;
        this.MemberInfoDICT.Write(er, c);
        for (int index = 0; index < this.AnimationGroupMembers.Length; ++index)
        {
          long position5 = er.BaseStream.Position;
          long num2 = er.BaseStream.Position = num1 + 28L + (long) (index * 16) + 12L;
          er.Write((uint) (position5 - num2));
          er.BaseStream.Position = position5;
          this.AnimationGroupMembers[index].Write(er, c);
        }
      }

      public override string ToString()
      {
        return this.Name;
      }

      [System.Flags]
      public enum GraphicsAnimGroupFlags : uint
      {
        IsTransform = 1U,
      }

      public enum GraphicsMemberType : uint
      {
        None,
        Bone,
        Material,
        Model,
        Light,
        Camera,
        Fog,
      }

      public enum AnimGroupEvaluationTiming : uint
      {
        BeforeWorldUpdate,
        AfterSceneCulling,
      }

      public class AnimationGroupMember
      {
        public CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType Type;
        public uint PathOffset;
        public uint MemberOffset;
        public uint BlendOperationIndex;
        public uint ObjectType;
        public uint MemberType;
        public uint ResMaterialPtr;
        public string Path;

        public AnimationGroupMember(EndianBinaryReader er)
        {
          this.Type = (CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType) er.ReadUInt32();
          this.PathOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.MemberOffset = er.ReadUInt32();
          this.BlendOperationIndex = er.ReadUInt32();
          this.ObjectType = er.ReadUInt32();
          this.MemberType = er.ReadUInt32();
          this.ResMaterialPtr = er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.PathOffset;
          this.Path = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = position;
        }

        public virtual void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          er.Write((uint) this.Type);
          c.WriteStringReference(this.Path, er);
          er.Write(this.MemberOffset);
          er.Write(this.BlendOperationIndex);
          er.Write(this.ObjectType);
          er.Write(this.MemberType);
          er.Write(this.ResMaterialPtr);
        }

        public static CMDL.GraphicsAnimationGroup.AnimationGroupMember FromStream(EndianBinaryReader er)
        {
          CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType animationGroupMemberType = (CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType) er.ReadUInt32();
          er.BaseStream.Position -= 4L;
          if (animationGroupMemberType <= CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.BlendOperationMember)
          {
            if (animationGroupMemberType <= CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.MeshMember)
            {
              if (animationGroupMemberType == CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.MeshNodeVisibilityMember)
                return (CMDL.GraphicsAnimationGroup.AnimationGroupMember) new CMDL.GraphicsAnimationGroup.MeshNodeVisibilityMember(er);
              if (animationGroupMemberType == CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.MeshMember)
                return (CMDL.GraphicsAnimationGroup.AnimationGroupMember) new CMDL.GraphicsAnimationGroup.MeshMember(er);
            }
            else
            {
              if (animationGroupMemberType == CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.TextureSamplerMember)
                return (CMDL.GraphicsAnimationGroup.AnimationGroupMember) new CMDL.GraphicsAnimationGroup.TextureSamplerMember(er);
              if (animationGroupMemberType == CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.BlendOperationMember)
                return (CMDL.GraphicsAnimationGroup.AnimationGroupMember) new CMDL.GraphicsAnimationGroup.BlendOperationMember(er);
            }
          }
          else if (animationGroupMemberType <= CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.ModelMember)
          {
            if (animationGroupMemberType == CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.MaterialColorMember)
              return (CMDL.GraphicsAnimationGroup.AnimationGroupMember) new CMDL.GraphicsAnimationGroup.MaterialColorMember(er);
            if (animationGroupMemberType == CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.ModelMember)
              return (CMDL.GraphicsAnimationGroup.AnimationGroupMember) new CMDL.GraphicsAnimationGroup.ModelMember(er);
          }
          else
          {
            if (animationGroupMemberType == CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.TextureMapperMember)
              return (CMDL.GraphicsAnimationGroup.AnimationGroupMember) new CMDL.GraphicsAnimationGroup.TextureMapperMember(er);
            if (animationGroupMemberType == CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.BoneMember)
              return (CMDL.GraphicsAnimationGroup.AnimationGroupMember) new CMDL.GraphicsAnimationGroup.BoneMember(er);
            if (animationGroupMemberType == CMDL.GraphicsAnimationGroup.AnimationGroupMember.AnimationGroupMemberType.TextureCoordinatorMember)
              return (CMDL.GraphicsAnimationGroup.AnimationGroupMember) new CMDL.GraphicsAnimationGroup.TextureCoordinatorMember(er);
          }
          return new CMDL.GraphicsAnimationGroup.AnimationGroupMember(er);
        }

        public override string ToString()
        {
          return this.Path;
        }

        public enum AnimationGroupMemberType : uint
        {
          MeshNodeVisibilityMember = 524288U,
          MeshMember = 16777216U,
          TextureSamplerMember = 33554432U,
          BlendOperationMember = 67108864U,
          MaterialColorMember = 134217728U,
          ModelMember = 268435456U,
          TextureMapperMember = 536870912U,
          BoneMember = 1073741824U,
          TextureCoordinatorMember = 2147483648U,
        }
      }

      public class MeshNodeVisibilityMember : CMDL.GraphicsAnimationGroup.AnimationGroupMember
      {
        public uint NodeNameOffset;
        public string NodeName;

        public MeshNodeVisibilityMember(EndianBinaryReader er)
          : base(er)
        {
          this.NodeNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.NodeNameOffset;
          this.NodeName = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = position;
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          c.WriteStringReference(this.NodeName, er);
          er.Write(this.ObjectType);
        }
      }

      public class MeshMember : CMDL.GraphicsAnimationGroup.AnimationGroupMember
      {
        public uint MeshIndex;

        public MeshMember(EndianBinaryReader er)
          : base(er)
        {
          this.MeshIndex = er.ReadUInt32();
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          er.Write(this.MeshIndex);
          er.Write(this.ObjectType);
        }
      }

      public class TextureSamplerMember : CMDL.GraphicsAnimationGroup.AnimationGroupMember
      {
        public uint MaterialNameOffset;
        public uint TextureMapperIndex;
        public string MaterialName;

        public TextureSamplerMember(EndianBinaryReader er)
          : base(er)
        {
          this.MaterialNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.TextureMapperIndex = er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.MaterialNameOffset;
          this.MaterialName = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = position;
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          c.WriteStringReference(this.MaterialName, er);
          er.Write(this.TextureMapperIndex);
        }
      }

      public class BlendOperationMember : CMDL.GraphicsAnimationGroup.AnimationGroupMember
      {
        public uint MaterialNameOffset;
        public string MaterialName;

        public BlendOperationMember(EndianBinaryReader er)
          : base(er)
        {
          this.MaterialNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.MaterialNameOffset;
          this.MaterialName = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = position;
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          c.WriteStringReference(this.MaterialName, er);
          er.Write(this.ObjectType);
        }
      }

      public class MaterialColorMember : CMDL.GraphicsAnimationGroup.AnimationGroupMember
      {
        public uint MaterialNameOffset;
        public string MaterialName;

        public MaterialColorMember(EndianBinaryReader er)
          : base(er)
        {
          this.MaterialNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.MaterialNameOffset;
          this.MaterialName = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = position;
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          c.WriteStringReference(this.MaterialName, er);
          er.Write(this.ObjectType);
        }
      }

      public class ModelMember : CMDL.GraphicsAnimationGroup.AnimationGroupMember
      {
        public ModelMember(EndianBinaryReader er)
          : base(er)
        {
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          er.Write(this.ObjectType);
        }
      }

      public class TextureMapperMember : CMDL.GraphicsAnimationGroup.AnimationGroupMember
      {
        public uint MaterialNameOffset;
        public uint TextureMapperIndex;
        public string MaterialName;

        public TextureMapperMember(EndianBinaryReader er)
          : base(er)
        {
          this.MaterialNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.TextureMapperIndex = er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.MaterialNameOffset;
          this.MaterialName = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = position;
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          c.WriteStringReference(this.MaterialName, er);
          er.Write(this.TextureMapperIndex);
        }
      }

      public class BoneMember : CMDL.GraphicsAnimationGroup.AnimationGroupMember
      {
        public uint BoneNameOffset;
        public string BoneName;

        public BoneMember(EndianBinaryReader er)
          : base(er)
        {
          this.BoneNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.BoneNameOffset;
          this.BoneName = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = position;
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          c.WriteStringReference(this.BoneName, er);
          er.Write(this.ObjectType);
        }
      }

      public class TextureCoordinatorMember : CMDL.GraphicsAnimationGroup.AnimationGroupMember
      {
        public uint MaterialNameOffset;
        public uint TextureCoordinatorIndex;
        public string MaterialName;

        public TextureCoordinatorMember(EndianBinaryReader er)
          : base(er)
        {
          this.MaterialNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.TextureCoordinatorIndex = er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.MaterialNameOffset;
          this.MaterialName = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = position;
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          c.WriteStringReference(this.MaterialName, er);
          er.Write(this.TextureCoordinatorIndex);
        }
      }
    }

    public class MeshNodeVisibilityCtr
    {
      public uint NameOffset;
      public bool Visible;
      public string Name;

      public MeshNodeVisibilityCtr(string Name)
      {
        this.Name = Name;
        this.Visible = true;
      }

      public MeshNodeVisibilityCtr(EndianBinaryReader er)
      {
        this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.Visible = (int) er.ReadUInt32() == 1;
        long position = er.BaseStream.Position;
        er.BaseStream.Position = (long) this.NameOffset;
        this.Name = er.ReadStringNT(Encoding.ASCII);
        er.BaseStream.Position = position;
      }

      public void Write(EndianBinaryWriter er, CGFXWriterContext c)
      {
        c.WriteStringReference(this.Name, er);
        er.Write(this.Visible ? 1U : 0U);
      }

      public override string ToString()
      {
        return this.Name;
      }
    }

    public class MTOB
    {
      private readonly int[] WrapMapper = new int[4]
      {
        2,
        3,
        0,
        1
      };
      private readonly int[] TexCombSrcMapper = new int[10]
      {
        33984,
        33985,
        33986,
        33987,
        34166,
        34167,
        34168,
        34169,
        25104,
        25105
      };
      public uint Type;
      public string Signature;
      public uint Revision;
      public uint NameOffset;
      public uint Unknown2;
      public uint Unknown3;
      public CMDL.MTOB.MaterialFlags Flags;
      public uint TexCoordConfig;
      public uint TranslucencyKind;
      public CMDL.MTOB.MaterialColorCtr MaterialColor;
      public CMDL.MTOB.RasterizationCtr Rasterization;
      public CMDL.MTOB.FragmentOperationCtr FragmentOperation;
      public uint NrActiveTextureCoordiators;
      public CMDL.MTOB.TextureCoordinatorCtr[] TextureCoordiators;
      public uint TexMapper0Offset;
      public uint TexMapper1Offset;
      public uint TexMapper2Offset;
      public uint ProcTexMapperOffset;
      public uint ShaderOffset;
      public uint FragmentShaderOffset;
      public uint ShaderProgramDescriptionIndex;
      public uint NrShaderParameters;
      public uint ShaderParametersOffsetArrayOffset;
      public uint LightSetIndex;
      public uint FogIndex;
      public uint ShadingParameterHash;
      public uint ShaderParametersHash;
      public uint TextureCoordinatorsHash;
      public uint TextureSamplersHash;
      public uint TextureMappersHash;
      public uint MaterialColorHash;
      public uint RasterizationHash;
      public uint FragmentLightingHash;
      public uint FragmentLightingTableHash;
      public uint FragmentLightingTableParametersHash;
      public uint TextureCombinersHash;
      public uint AlphaTestHash;
      public uint FragmentOperationHash;
      public uint MaterialId;
      public string Name;
      public CMDL.MTOB.TexInfo Tex0;
      public CMDL.MTOB.TexInfo Tex1;
      public CMDL.MTOB.TexInfo Tex2;
      public CMDL.MTOB.TexInfo ProcTex;
      public CMDL.MTOB.SHDR Shader;
      public CMDL.MTOB.FragmentShader FragShader;

      public MTOB(string Name)
      {
        this.Type = 134217728U;
        this.Signature = "MTOB";
        this.Revision = 100663299U;
        this.Name = Name;
        this.MaterialColor = new CMDL.MTOB.MaterialColorCtr();
        this.Rasterization = new CMDL.MTOB.RasterizationCtr();
        this.FragmentOperation = new CMDL.MTOB.FragmentOperationCtr();
        this.NrActiveTextureCoordiators = 0U;
        this.TextureCoordiators = new CMDL.MTOB.TextureCoordinatorCtr[3];
        this.TextureCoordiators[0] = new CMDL.MTOB.TextureCoordinatorCtr();
        this.TextureCoordiators[1] = new CMDL.MTOB.TextureCoordinatorCtr();
        this.TextureCoordiators[2] = new CMDL.MTOB.TextureCoordinatorCtr();
        this.Shader = new CMDL.MTOB.SHDR();
        this.FragShader = new CMDL.MTOB.FragmentShader();
      }

      public MTOB(EndianBinaryReader er)
      {
        this.Type = er.ReadUInt32();
        this.Signature = er.ReadString(Encoding.ASCII, 4);
        if (this.Signature != "MTOB")
          throw new SignatureNotCorrectException(this.Signature, "MTOB", er.BaseStream.Position);
        this.Revision = er.ReadUInt32();
        this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.Unknown2 = er.ReadUInt32();
        this.Unknown3 = er.ReadUInt32();
        this.Flags = (CMDL.MTOB.MaterialFlags) er.ReadUInt32();
        this.TexCoordConfig = er.ReadUInt32();
        this.TranslucencyKind = er.ReadUInt32();
        this.MaterialColor = new CMDL.MTOB.MaterialColorCtr(er);
        this.Rasterization = new CMDL.MTOB.RasterizationCtr(er);
        this.FragmentOperation = new CMDL.MTOB.FragmentOperationCtr(er);
        this.NrActiveTextureCoordiators = er.ReadUInt32();
        this.TextureCoordiators = new CMDL.MTOB.TextureCoordinatorCtr[3];
        this.TextureCoordiators[0] = new CMDL.MTOB.TextureCoordinatorCtr(er);
        this.TextureCoordiators[1] = new CMDL.MTOB.TextureCoordinatorCtr(er);
        this.TextureCoordiators[2] = new CMDL.MTOB.TextureCoordinatorCtr(er);
        this.TexMapper0Offset = er.ReadUInt32();
        if ((int) this.TexMapper0Offset != 0)
          this.TexMapper0Offset = this.TexMapper0Offset + ((uint) er.BaseStream.Position - 4U);
        this.TexMapper1Offset = er.ReadUInt32();
        if ((int) this.TexMapper1Offset != 0)
          this.TexMapper1Offset = this.TexMapper1Offset + ((uint) er.BaseStream.Position - 4U);
        this.TexMapper2Offset = er.ReadUInt32();
        if ((int) this.TexMapper2Offset != 0)
          this.TexMapper2Offset = this.TexMapper2Offset + ((uint) er.BaseStream.Position - 4U);
        this.ProcTexMapperOffset = er.ReadUInt32();
        if ((int) this.ProcTexMapperOffset != 0)
          this.ProcTexMapperOffset = this.ProcTexMapperOffset + ((uint) er.BaseStream.Position - 4U);
        this.ShaderOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.FragmentShaderOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.ShaderProgramDescriptionIndex = er.ReadUInt32();
        this.NrShaderParameters = er.ReadUInt32();
        this.ShaderParametersOffsetArrayOffset = er.ReadUInt32();
        this.LightSetIndex = er.ReadUInt32();
        this.FogIndex = er.ReadUInt32();
        this.ShadingParameterHash = er.ReadUInt32();
        this.ShaderParametersHash = er.ReadUInt32();
        this.TextureCoordinatorsHash = er.ReadUInt32();
        this.TextureSamplersHash = er.ReadUInt32();
        this.TextureMappersHash = er.ReadUInt32();
        this.MaterialColorHash = er.ReadUInt32();
        this.RasterizationHash = er.ReadUInt32();
        this.FragmentLightingHash = er.ReadUInt32();
        this.FragmentLightingTableHash = er.ReadUInt32();
        this.FragmentLightingTableParametersHash = er.ReadUInt32();
        this.TextureCombinersHash = er.ReadUInt32();
        this.AlphaTestHash = er.ReadUInt32();
        this.FragmentOperationHash = er.ReadUInt32();
        this.MaterialId = er.ReadUInt32();
        long position = er.BaseStream.Position;
        er.BaseStream.Position = (long) this.NameOffset;
        this.Name = er.ReadStringNT(Encoding.ASCII);
        if ((int) this.TexMapper0Offset != 0)
        {
          er.BaseStream.Position = (long) this.TexMapper0Offset;
          this.Tex0 = new CMDL.MTOB.TexInfo(er);
        }
        if ((int) this.TexMapper1Offset != 0)
        {
          er.BaseStream.Position = (long) this.TexMapper1Offset;
          this.Tex1 = new CMDL.MTOB.TexInfo(er);
        }
        if ((int) this.TexMapper2Offset != 0)
        {
          er.BaseStream.Position = (long) this.TexMapper2Offset;
          this.Tex2 = new CMDL.MTOB.TexInfo(er);
        }
        er.BaseStream.Position = (long) this.ShaderOffset;
        this.Shader = new CMDL.MTOB.SHDR(er);
        er.BaseStream.Position = (long) this.FragmentShaderOffset;
        this.FragShader = new CMDL.MTOB.FragmentShader(er);
        er.BaseStream.Position = position;
      }

      public void Write(EndianBinaryWriter er, CGFXWriterContext c)
      {
        er.Write(this.Type);
        er.Write(this.Signature, Encoding.ASCII, false);
        er.Write(this.Revision);
        c.WriteStringReference(this.Name, er);
        er.Write(this.Unknown2);
        er.Write(this.Unknown3);
        er.Write((uint) this.Flags);
        er.Write(this.TexCoordConfig);
        er.Write(this.TranslucencyKind);
        this.MaterialColor.Write(er);
        this.Rasterization.Write(er);
        this.FragmentOperation.Write(er);
        er.Write(this.NrActiveTextureCoordiators);
        for (int index = 0; index < 3; ++index)
          this.TextureCoordiators[index].Write(er);
        long position1 = er.BaseStream.Position;
        er.Write(0U);
        er.Write(0U);
        er.Write(0U);
        er.Write(0U);
        er.Write(0U);
        er.Write(0U);
        er.Write(this.ShaderProgramDescriptionIndex);
        er.Write(this.NrShaderParameters);
        er.Write(0U);
        er.Write(this.LightSetIndex);
        er.Write(this.FogIndex);
        er.Write(CGFXWriterContext.CalcHash(BitConverter.GetBytes((uint) (this.Flags | CMDL.MTOB.MaterialFlags.ParticleMaterialEnabled))));
        byte[] Data = new byte[(int) this.NrShaderParameters * 4];
        er.Write(CGFXWriterContext.CalcHash(Data));
        er.Write(0U);
        List<byte> list1 = new List<byte>();
        list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.TexCoordConfig));
        if (this.Tex0 != null && this.Tex0.Sampler is CMDL.MTOB.TexInfo.StandardTextureSamplerCtr)
        {
          CMDL.MTOB.TexInfo.StandardTextureSamplerCtr textureSamplerCtr = this.Tex0.Sampler as CMDL.MTOB.TexInfo.StandardTextureSamplerCtr;
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.X));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.Y));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.Z));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.W));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.WrapMapper[(int) (this.Tex0.Unknown12 >> 12) & 15]));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.WrapMapper[(int) (this.Tex0.Unknown12 >> 8) & 15]));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(0.0f));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.LodBias));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.MinFilter));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(1U));
        }
        if (this.Tex1 != null && this.Tex1.Sampler is CMDL.MTOB.TexInfo.StandardTextureSamplerCtr)
        {
          CMDL.MTOB.TexInfo.StandardTextureSamplerCtr textureSamplerCtr = this.Tex1.Sampler as CMDL.MTOB.TexInfo.StandardTextureSamplerCtr;
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.X));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.Y));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.Z));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.W));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.WrapMapper[(int) (this.Tex1.Unknown12 >> 12) & 15]));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.WrapMapper[(int) (this.Tex1.Unknown12 >> 8) & 15]));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(0.0f));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.LodBias));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.MinFilter));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(1U));
        }
        if (this.Tex2 != null && this.Tex2.Sampler is CMDL.MTOB.TexInfo.StandardTextureSamplerCtr)
        {
          CMDL.MTOB.TexInfo.StandardTextureSamplerCtr textureSamplerCtr = this.Tex2.Sampler as CMDL.MTOB.TexInfo.StandardTextureSamplerCtr;
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.X));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.Y));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.Z));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.BorderColor.W));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.WrapMapper[(int) (this.Tex2.Unknown12 >> 12) & 15]));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.WrapMapper[(int) (this.Tex2.Unknown12 >> 8) & 15]));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(0.0f));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.LodBias));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(textureSamplerCtr.MinFilter));
          list1.AddRange((IEnumerable<byte>) BitConverter.GetBytes(1U));
        }
        er.Write(CGFXWriterContext.CalcHash(list1.ToArray()));
        er.Write(0U);
        er.Write(this.MaterialColor.GetHash());
        er.Write(this.Rasterization.GetHash());
        List<byte> list2 = new List<byte>();
        list2.AddRange((IEnumerable<byte>) BitConverter.GetBytes((uint) this.FragShader.FragmentLighting.Flags));
        list2.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.FragShader.FragmentLighting.LayerConfig));
        list2.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.FragShader.FragmentLighting.FresnelConfig));
        list2.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.FragShader.FragmentLighting.BumpTextureIndex));
        list2.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.FragShader.FragmentLighting.BumpMode));
        list2.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.FragShader.FragmentLighting.IsBumpRenormalize));
        er.Write(CGFXWriterContext.CalcHash(list2.ToArray()));
        er.Write(0U);
        er.Write(this.FragShader.FragmentLightingTable.GetHash());
        er.Write(0U);
        er.Write(this.FragShader.AlphaTest.GetHash());
        er.Write(this.FragmentOperation.GetHash());
        er.Write(this.MaterialId);
        if (this.Tex0 != null)
        {
          long position2 = er.BaseStream.Position;
          er.BaseStream.Position = position1;
          er.Write((uint) (position2 - position1));
          er.BaseStream.Position = position2;
          this.Tex0.Write(er, c);
        }
        if (this.Tex1 != null)
        {
          long position2 = er.BaseStream.Position;
          er.BaseStream.Position = position1 + 4L;
          er.Write((uint) (position2 - (position1 + 4L)));
          er.BaseStream.Position = position2;
          this.Tex1.Write(er, c);
        }
        if (this.Tex2 != null)
        {
          long position2 = er.BaseStream.Position;
          er.BaseStream.Position = position1 + 8L;
          er.Write((uint) (position2 - (position1 + 8L)));
          er.BaseStream.Position = position2;
          this.Tex2.Write(er, c);
        }
        if (this.ProcTex != null)
        {
          long position2 = er.BaseStream.Position;
          er.BaseStream.Position = position1 + 12L;
          er.Write((uint) (position2 - (position1 + 12L)));
          er.BaseStream.Position = position2;
        }
        if (this.Shader != null)
        {
          long position2 = er.BaseStream.Position;
          er.BaseStream.Position = position1 + 16L;
          er.Write((uint) (position2 - (position1 + 16L)));
          er.BaseStream.Position = position2;
          this.Shader.Write(er, c);
        }
        if (this.FragShader == null)
          return;
        long position3 = er.BaseStream.Position;
        er.BaseStream.Position = position1 + 20L;
        er.Write((uint) (position3 - (position1 + 20L)));
        er.BaseStream.Position = position3;
        this.FragShader.Write(er, c);
      }

      public override string ToString()
      {
        return this.Name;
      }

      [System.Flags]
      public enum MaterialFlags : uint
      {
        FragmentLightEnabled = 1U,
        VertexLightEnabled = 2U,
        HemiSphereLightEnabled = 4U,
        HemiSphereOcclusionEnabled = 8U,
        FogEnabled = 16U,
        ParticleMaterialEnabled = 32U,
      }

      public class MaterialColorCtr
      {
        public Vector4 Emission;
        public Vector4 Ambient;
        public Vector4 Diffuse;
        public Vector4 Specular0;
        public Vector4 Specular1;
        public Vector4 Constant0;
        public Vector4 Constant1;
        public Vector4 Constant2;
        public Vector4 Constant3;
        public Vector4 Constant4;
        public Vector4 Constant5;
        public Color EmissionU32;
        public Color AmbientU32;
        public Color DiffuseU32;
        public Color Specular0U32;
        public Color Specular1U32;
        public Color Constant0U32;
        public Color Constant1U32;
        public Color Constant2U32;
        public Color Constant3U32;
        public Color Constant4U32;
        public Color Constant5U32;
        public uint CommandCache;

        public MaterialColorCtr()
        {
          this.Emission = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
          this.EmissionU32 = Color.FromArgb(0);
          this.Ambient = new Vector4(1f, 1f, 1f, 1f);
          this.AmbientU32 = Color.White;
          this.Diffuse = new Vector4(1f, 1f, 1f, 1f);
          this.DiffuseU32 = Color.White;
          this.Specular0 = new Vector4(0.33f, 0.33f, 0.33f, 0.0f);
          this.Specular0U32 = Color.FromArgb(0, 84, 84, 84);
          this.Specular1 = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
          this.Specular1U32 = Color.FromArgb(0);
          this.Constant0 = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
          this.Constant0U32 = Color.FromArgb(0);
          this.Constant1 = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
          this.Constant1U32 = Color.FromArgb(0);
          this.Constant2 = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
          this.Constant2U32 = Color.FromArgb(0);
          this.Constant3 = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
          this.Constant3U32 = Color.FromArgb(0);
          this.Constant4 = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
          this.Constant4U32 = Color.FromArgb(0);
          this.Constant5 = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
          this.Constant5U32 = Color.FromArgb(0);
          this.CommandCache = 0U;
        }

        public MaterialColorCtr(EndianBinaryReader er)
        {
          this.Emission = er.ReadVector4();
          this.Ambient = er.ReadVector4();
          this.Diffuse = er.ReadVector4();
          this.Specular0 = er.ReadVector4();
          this.Specular1 = er.ReadVector4();
          this.Constant0 = er.ReadVector4();
          this.Constant1 = er.ReadVector4();
          this.Constant2 = er.ReadVector4();
          this.Constant3 = er.ReadVector4();
          this.Constant4 = er.ReadVector4();
          this.Constant5 = er.ReadVector4();
          this.EmissionU32 = Extensions.ReadColor8(er);
          this.AmbientU32 = Extensions.ReadColor8(er);
          this.DiffuseU32 = Extensions.ReadColor8(er);
          this.Specular0U32 = Extensions.ReadColor8(er);
          this.Specular1U32 = Extensions.ReadColor8(er);
          this.Constant0U32 = Extensions.ReadColor8(er);
          this.Constant1U32 = Extensions.ReadColor8(er);
          this.Constant2U32 = Extensions.ReadColor8(er);
          this.Constant3U32 = Extensions.ReadColor8(er);
          this.Constant4U32 = Extensions.ReadColor8(er);
          this.Constant5U32 = Extensions.ReadColor8(er);
          this.CommandCache = er.ReadUInt32();
        }

        public void Write(EndianBinaryWriter er)
        {
          er.WriteVector4(this.Emission);
          er.WriteVector4(this.Ambient);
          er.WriteVector4(this.Diffuse);
          er.WriteVector4(this.Specular0);
          er.WriteVector4(this.Specular1);
          er.WriteVector4(this.Constant0);
          er.WriteVector4(this.Constant1);
          er.WriteVector4(this.Constant2);
          er.WriteVector4(this.Constant3);
          er.WriteVector4(this.Constant4);
          er.WriteVector4(this.Constant5);
          Extensions.WriteColor8(er, this.EmissionU32);
          Extensions.WriteColor8(er, this.AmbientU32);
          Extensions.WriteColor8(er, this.DiffuseU32);
          Extensions.WriteColor8(er, this.Specular0U32);
          Extensions.WriteColor8(er, this.Specular1U32);
          Extensions.WriteColor8(er, this.Constant0U32);
          Extensions.WriteColor8(er, this.Constant1U32);
          Extensions.WriteColor8(er, this.Constant2U32);
          Extensions.WriteColor8(er, this.Constant3U32);
          Extensions.WriteColor8(er, this.Constant4U32);
          Extensions.WriteColor8(er, this.Constant5U32);
          er.Write(this.CommandCache);
        }

        public uint GetHash()
        {
          byte[] Data = new byte[164];
          int num1 = 0;
          int Offset1 = num1;
          Vector4 vector4_1 = this.Emission;
          CGFXWriterContext.WriteFloatColorRGB(Data, Offset1, vector4_1);
          int num2 = num1 + 12;
          int Offset2 = num2;
          Vector4 vector4_2 = this.Ambient;
          CGFXWriterContext.WriteFloatColorRGBA(Data, Offset2, vector4_2);
          int num3 = num2 + 16;
          int Offset3 = num3;
          Vector4 vector4_3 = this.Diffuse;
          CGFXWriterContext.WriteFloatColorRGBA(Data, Offset3, vector4_3);
          int num4 = num3 + 16;
          int Offset4 = num4;
          Vector4 vector4_4 = this.Specular0;
          CGFXWriterContext.WriteFloatColorRGB(Data, Offset4, vector4_4);
          int num5 = num4 + 12;
          int Offset5 = num5;
          Vector4 vector4_5 = this.Specular1;
          CGFXWriterContext.WriteFloatColorRGB(Data, Offset5, vector4_5);
          int num6 = num5 + 12;
          int Offset6 = num6;
          Vector4 vector4_6 = this.Constant0;
          CGFXWriterContext.WriteFloatColorRGBA(Data, Offset6, vector4_6);
          int num7 = num6 + 16;
          int Offset7 = num7;
          Vector4 vector4_7 = this.Constant1;
          CGFXWriterContext.WriteFloatColorRGBA(Data, Offset7, vector4_7);
          int num8 = num7 + 16;
          int Offset8 = num8;
          Vector4 vector4_8 = this.Constant2;
          CGFXWriterContext.WriteFloatColorRGBA(Data, Offset8, vector4_8);
          int num9 = num8 + 16;
          int Offset9 = num9;
          Vector4 vector4_9 = this.Constant3;
          CGFXWriterContext.WriteFloatColorRGBA(Data, Offset9, vector4_9);
          int num10 = num9 + 16;
          int Offset10 = num10;
          Vector4 vector4_10 = this.Constant4;
          CGFXWriterContext.WriteFloatColorRGBA(Data, Offset10, vector4_10);
          int num11 = num10 + 16;
          int Offset11 = num11;
          Vector4 vector4_11 = this.Constant5;
          CGFXWriterContext.WriteFloatColorRGBA(Data, Offset11, vector4_11);
          int num12 = num11 + 16;
          return CGFXWriterContext.CalcHash(Data);
        }
      }

      public class RasterizationCtr
      {
        public CMDL.MTOB.RasterizationCtr.RasterizationFlags Flags;
        public uint CullingMode;
        public float PolygonOffsetUnit;
        public uint Command1;
        public uint Command2;

        public RasterizationCtr()
        {
          this.Flags = (CMDL.MTOB.RasterizationCtr.RasterizationFlags) 0;
          this.CullingMode = 3U;
          this.PolygonOffsetUnit = 0.0f;
          this.Command1 = 0U;
          this.Command2 = 65600U;
        }

        public RasterizationCtr(EndianBinaryReader er)
        {
          this.Flags = (CMDL.MTOB.RasterizationCtr.RasterizationFlags) er.ReadUInt32();
          this.CullingMode = er.ReadUInt32();
          this.PolygonOffsetUnit = er.ReadSingle();
          this.Command1 = er.ReadUInt32();
          this.Command2 = er.ReadUInt32();
        }

        public void Write(EndianBinaryWriter er)
        {
          er.Write((uint) this.Flags);
          er.Write(this.CullingMode);
          er.Write(this.PolygonOffsetUnit);
          er.Write(this.Command1);
          er.Write(this.Command2);
        }

        public uint GetHash()
        {
          byte[] Data = new byte[16];
          int Offset1 = 0;
          int num1 = (int) this.Flags;
          IOUtil.WriteU32LE(Data, Offset1, (uint) num1);
          int Offset2 = 4;
          int num2 = (int) this.Command1;
          IOUtil.WriteU32LE(Data, Offset2, (uint) num2);
          int Offset3 = 8;
          int num3 = (int) this.Command2;
          IOUtil.WriteU32LE(Data, Offset3, (uint) num3);
          int Offset4 = 12;
          double num4 = (double) this.PolygonOffsetUnit;
          IOUtil.WriteSingleLE(Data, Offset4, (float) num4);
          return CGFXWriterContext.CalcHash(Data);
        }

        [System.Flags]
        public enum RasterizationFlags : uint
        {
          PolygonOffsetEnabled = 1U,
        }
      }

      public class FragmentOperationCtr
      {
        private readonly uint[] DepthOpTransform = new uint[8]
        {
          0U,
          1U,
          4U,
          7U,
          2U,
          3U,
          6U,
          5U
        };
        private readonly uint[] BlendLogicOpTransform = new uint[16]
        {
          0U,
          8U,
          6U,
          1U,
          3U,
          4U,
          2U,
          5U,
          10U,
          9U,
          11U,
          12U,
          13U,
          14U,
          7U,
          15U
        };
        public CMDL.MTOB.FragmentOperationCtr.DepthOperationCtr DepthOperation;
        public CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr BlendOperation;
        public CMDL.MTOB.FragmentOperationCtr.StencilOperationCtr StencilOperation;

        public FragmentOperationCtr()
        {
          this.DepthOperation = new CMDL.MTOB.FragmentOperationCtr.DepthOperationCtr();
          this.BlendOperation = new CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr();
          this.StencilOperation = new CMDL.MTOB.FragmentOperationCtr.StencilOperationCtr();
        }

        public FragmentOperationCtr(EndianBinaryReader er)
        {
          this.DepthOperation = new CMDL.MTOB.FragmentOperationCtr.DepthOperationCtr(er);
          this.BlendOperation = new CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr(er);
          this.StencilOperation = new CMDL.MTOB.FragmentOperationCtr.StencilOperationCtr(er);
        }

        public void Write(EndianBinaryWriter er)
        {
          this.DepthOperation.Write(er);
          this.BlendOperation.Write(er);
          this.StencilOperation.Write(er);
        }

        public uint GetHash()
        {
          int num = (int) this.BlendOperation.Command4 == 0 ? (((int) (this.BlendOperation.Command3 >> 16) & 15) != 1 || ((int) (this.BlendOperation.Command3 >> 20) & 15) != 0 || (((int) (this.BlendOperation.Command3 >> 24) & 15) != 1 || ((int) (this.BlendOperation.Command3 >> 8) & (int) byte.MaxValue) != 0) ? (((int) (this.BlendOperation.Command3 >> 16) & 15) == 1 && ((int) (this.BlendOperation.Command3 >> 20) & 15) == 0 || (((int) (this.BlendOperation.Command3 >> 24) & 15) != 1 || ((int) (this.BlendOperation.Command3 >> 8) & (int) byte.MaxValue) != 0) ? 1 : 2) : 0) : 3;
          byte[] Data = new byte[76];
          IOUtil.WriteU32LE(Data, 0, (uint) this.DepthOperation.Flags);
          IOUtil.WriteU32LE(Data, 4, this.DepthOpTransform[(int) (this.DepthOperation.Command1 >> 4) & 15]);
          IOUtil.WriteU32LE(Data, 8, 0U);
          IOUtil.WriteU32LE(Data, 12, (uint) num);
          CGFXWriterContext.WriteFloatColorRGBA(Data, 16, this.BlendOperation.BlendColor);
          if (num != 3)
            IOUtil.WriteU32LE(Data, 32, 1U);
          else
            IOUtil.WriteU32LE(Data, 32, this.BlendLogicOpTransform[(int) this.BlendOperation.Command4]);
          if (num == 0)
          {
            IOUtil.WriteU32LE(Data, 36, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[6]);
            IOUtil.WriteU32LE(Data, 40, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[7]);
            IOUtil.WriteU32LE(Data, 44, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlEquation[0]);
            IOUtil.WriteU32LE(Data, 48, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[1]);
            IOUtil.WriteU32LE(Data, 52, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[0]);
            IOUtil.WriteU32LE(Data, 56, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlEquation[0]);
          }
          else if (num == 1)
          {
            IOUtil.WriteU32LE(Data, 36, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[(int) (this.BlendOperation.Command3 >> 16) & 15]);
            IOUtil.WriteU32LE(Data, 40, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[(int) (this.BlendOperation.Command3 >> 20) & 15]);
            IOUtil.WriteU32LE(Data, 44, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlEquation[(int) this.BlendOperation.Command3 & (int) byte.MaxValue]);
            IOUtil.WriteU32LE(Data, 48, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[1]);
            IOUtil.WriteU32LE(Data, 52, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[0]);
            IOUtil.WriteU32LE(Data, 56, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlEquation[0]);
          }
          else if (num == 2)
          {
            IOUtil.WriteU32LE(Data, 36, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[(int) (this.BlendOperation.Command3 >> 16) & 15]);
            IOUtil.WriteU32LE(Data, 40, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[(int) (this.BlendOperation.Command3 >> 20) & 15]);
            IOUtil.WriteU32LE(Data, 44, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlEquation[(int) this.BlendOperation.Command3 & (int) byte.MaxValue]);
            IOUtil.WriteU32LE(Data, 48, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[(int) (this.BlendOperation.Command3 >> 24) & 15]);
            IOUtil.WriteU32LE(Data, 52, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[(int) (this.BlendOperation.Command3 >> 28) & 15]);
            IOUtil.WriteU32LE(Data, 56, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlEquation[(int) (this.BlendOperation.Command3 >> 8) & (int) byte.MaxValue]);
          }
          else
          {
            IOUtil.WriteU32LE(Data, 36, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[6]);
            IOUtil.WriteU32LE(Data, 40, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[7]);
            IOUtil.WriteU32LE(Data, 44, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlEquation[0]);
            IOUtil.WriteU32LE(Data, 48, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[1]);
            IOUtil.WriteU32LE(Data, 52, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[0]);
            IOUtil.WriteU32LE(Data, 56, (uint) CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlEquation[0]);
          }
          IOUtil.WriteU32LE(Data, 60, this.StencilOperation.Command1);
          IOUtil.WriteU32LE(Data, 64, this.StencilOperation.Command2);
          IOUtil.WriteU32LE(Data, 68, this.StencilOperation.Command3);
          IOUtil.WriteU32LE(Data, 72, this.StencilOperation.Command4);
          return CGFXWriterContext.CalcHash(Data);
        }

        public class DepthOperationCtr
        {
          public CMDL.MTOB.FragmentOperationCtr.DepthOperationCtr.DepthFlags Flags;
          public uint Command1;
          public uint Command2;
          public uint Command3;
          public uint Command4;

          public DepthOperationCtr()
          {
            this.Flags = CMDL.MTOB.FragmentOperationCtr.DepthOperationCtr.DepthFlags.TestEnabled | CMDL.MTOB.FragmentOperationCtr.DepthOperationCtr.DepthFlags.MaskEnabled;
            this.Command1 = 65U;
            this.Command2 = 65799U;
            this.Command3 = 50331648U;
            this.Command4 = 524582U;
          }

          public DepthOperationCtr(EndianBinaryReader er)
          {
            this.Flags = (CMDL.MTOB.FragmentOperationCtr.DepthOperationCtr.DepthFlags) er.ReadUInt32();
            this.Command1 = er.ReadUInt32();
            this.Command2 = er.ReadUInt32();
            this.Command3 = er.ReadUInt32();
            this.Command4 = er.ReadUInt32();
          }

          public void Write(EndianBinaryWriter er)
          {
            er.Write((uint) this.Flags);
            er.Write(this.Command1);
            er.Write(this.Command2);
            er.Write(this.Command3);
            er.Write(this.Command4);
          }

          [System.Flags]
          public enum DepthFlags : uint
          {
            TestEnabled = 1U,
            MaskEnabled = 2U,
          }
        }

        public class BlendOperationCtr
        {
          public static readonly int[] GlFactor = new int[15]
          {
            0,
            1,
            768,
            769,
            774,
            775,
            770,
            771,
            772,
            773,
            32769,
            32770,
            32771,
            32772,
            776
          };
          public static readonly int[] GlEquation = new int[5]
          {
            32774,
            32778,
            32779,
            32775,
            32776
          };
          public uint Mode;
          public Vector4 BlendColor;
          public uint Command1;
          public uint Command2;
          public uint Command3;
          public uint Command4;
          public uint Command5;
          public uint Command6;

          public BlendOperationCtr()
          {
            this.Mode = 0U;
            this.BlendColor = new Vector4(0.0f, 0.0f, 0.0f, 1f);
            this.Command1 = 14942464U;
            this.Command2 = 2151612672U;
            this.Command3 = 1987444736U;
            this.Command4 = 0U;
            this.Command5 = 4278190080U;
            this.Command6 = 0U;
          }

          public BlendOperationCtr(EndianBinaryReader er)
          {
            this.Mode = er.ReadUInt32();
            this.BlendColor = er.ReadVector4();
            this.Command1 = er.ReadUInt32();
            this.Command2 = er.ReadUInt32();
            this.Command3 = er.ReadUInt32();
            this.Command4 = er.ReadUInt32();
            this.Command5 = er.ReadUInt32();
            this.Command6 = er.ReadUInt32();
          }

          public void Write(EndianBinaryWriter er)
          {
            er.Write(this.Mode);
            er.WriteVector4(this.BlendColor);
            er.Write(this.Command1);
            er.Write(this.Command2);
            er.Write(this.Command3);
            er.Write(this.Command4);
            er.Write(this.Command5);
            er.Write(this.Command6);
          }

          public void GlApply()
          {
            uint num1 = this.Command3 >> 28 & 15U;
            uint num2 = this.Command3 >> 24 & 15U;
            uint num3 = this.Command3 >> 20 & 15U;
            uint num4 = this.Command3 >> 16 & 15U;
            uint num5 = this.Command3 >> 8 & (uint) byte.MaxValue;
            uint num6 = this.Command3 & (uint) byte.MaxValue;
            if (((int) (this.Command1 >> 8) & (int) byte.MaxValue) == 1)
            {
              Gl.glEnable(3042);
              Gl.glBlendColor(this.BlendColor.X, this.BlendColor.Y, this.BlendColor.Z, this.BlendColor.W);
              Gl.glBlendFuncSeparate(CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[(int) num4], CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[(int) num3], CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[(int) num2], CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlFactor[(int) num1]);
              Gl.glBlendEquationSeparate(CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlEquation[(int) num6], CMDL.MTOB.FragmentOperationCtr.BlendOperationCtr.GlEquation[(int) num5]);
              Gl.glEnable(3042);
            }
            else
              Gl.glDisable(3042);
          }
        }

        public class StencilOperationCtr
        {
          public uint Command1;
          public uint Command2;
          public uint Command3;
          public uint Command4;

          public StencilOperationCtr()
          {
            this.Command1 = 4278190080U;
            this.Command2 = 852229U;
            this.Command3 = 0U;
            this.Command4 = 983302U;
          }

          public StencilOperationCtr(EndianBinaryReader er)
          {
            this.Command1 = er.ReadUInt32();
            this.Command2 = er.ReadUInt32();
            this.Command3 = er.ReadUInt32();
            this.Command4 = er.ReadUInt32();
          }

          public void Write(EndianBinaryWriter er)
          {
            er.Write(this.Command1);
            er.Write(this.Command2);
            er.Write(this.Command3);
            er.Write(this.Command4);
          }
        }
      }

      public class TextureCoordinatorCtr
      {
        public uint SourceCoordinate;
        public uint MappingMethod;
        public int ReferenceCamera;
        public uint MatrixMode;
        public Vector2 Scale;
        public float Rotate;
        public Vector2 Translate;
        public uint Unknown3;
        public float[] Matrix;

        public TextureCoordinatorCtr()
        {
          this.SourceCoordinate = 0U;
          this.MappingMethod = 0U;
          this.ReferenceCamera = 0;
          this.MatrixMode = 0U;
          this.Scale = new Vector2(0.0f, 0.0f);
          this.Rotate = 0.0f;
          this.Translate = new Vector2(0.0f, 0.0f);
          this.Unknown3 = 0U;
          this.Matrix = new float[12]
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
          };
        }

        public TextureCoordinatorCtr(EndianBinaryReader er)
        {
          this.SourceCoordinate = er.ReadUInt32();
          this.MappingMethod = er.ReadUInt32();
          this.ReferenceCamera = er.ReadInt32();
          this.MatrixMode = er.ReadUInt32();
          this.Scale = new Vector2(er.ReadSingle(), er.ReadSingle());
          this.Rotate = er.ReadSingle();
          this.Translate = new Vector2(er.ReadSingle(), er.ReadSingle());
          this.Unknown3 = er.ReadUInt32();
          this.Matrix = er.ReadSingles(12);
        }

        public void Write(EndianBinaryWriter er)
        {
          er.Write(this.SourceCoordinate);
          er.Write(this.MappingMethod);
          er.Write(this.ReferenceCamera);
          er.Write(this.MatrixMode);
          er.WriteVector2(this.Scale);
          er.Write(this.Rotate);
          er.WriteVector2(this.Translate);
          er.Write(this.Unknown3);
          er.Write(this.Matrix, 0, 12);
        }
      }

      public class TexInfo
      {
        public uint Type;
        public uint DynamicAllocator;
        public uint TXOBOffset;
        public uint SamplerOffset;
        public uint Unknown4;
        public ushort Unknown5;
        public ushort Unknown6;
        public uint Unknown7;
        public ushort Unknown8;
        public ushort Unknown9;
        public ushort Height;
        public ushort Width;
        public uint Unknown12;
        public uint Unknown13;
        public uint Unknown14;
        public uint Unknown15;
        public uint Unknown16;
        public uint Unknown17;
        public uint Unknown18;
        public uint Unknown19;
        public uint Unknown20;
        public uint CommandSizeToSend;
        public TXOB TextureObject;
        public CMDL.MTOB.TexInfo.TextureSamplerCtr Sampler;

        public TexInfo(string RefTex)
        {
          this.Type = (uint) 0xFFFFFFFF;
          this.DynamicAllocator = 0U;
          this.Unknown4 = 0U;
          this.Unknown5 = (ushort) 142;
          this.Unknown6 = (ushort) 1;
          this.Unknown7 = 4278190080U;
          this.Unknown8 = (ushort) 129;
          this.Unknown9 = (ushort) 32927;
          this.Unknown12 = 16785926U;
          this.CommandSizeToSend = 56U;
          this.TextureObject = (TXOB) new ReferenceTexture(RefTex);
          this.Sampler = (CMDL.MTOB.TexInfo.TextureSamplerCtr) new CMDL.MTOB.TexInfo.StandardTextureSamplerCtr();
        }

        public TexInfo(EndianBinaryReader er)
        {
          this.Type = er.ReadUInt32();
          this.DynamicAllocator = er.ReadUInt32();
          this.TXOBOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.SamplerOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.Unknown4 = er.ReadUInt32();
          this.Unknown5 = er.ReadUInt16();
          this.Unknown6 = er.ReadUInt16();
          this.Unknown7 = er.ReadUInt32();
          this.Unknown8 = er.ReadUInt16();
          this.Unknown9 = er.ReadUInt16();
          this.Height = er.ReadUInt16();
          this.Width = er.ReadUInt16();
          this.Unknown12 = er.ReadUInt32();
          this.Unknown13 = er.ReadUInt32();
          this.Unknown14 = er.ReadUInt32();
          this.Unknown15 = er.ReadUInt32();
          this.Unknown16 = er.ReadUInt32();
          this.Unknown17 = er.ReadUInt32();
          this.Unknown18 = er.ReadUInt32();
          this.Unknown19 = er.ReadUInt32();
          this.Unknown20 = er.ReadUInt32();
          this.CommandSizeToSend = er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.TXOBOffset;
          this.TextureObject = TXOB.FromStream(er);
          er.BaseStream.Position = (long) this.SamplerOffset;
          this.Sampler = CMDL.MTOB.TexInfo.TextureSamplerCtr.FromStream(er);
          er.BaseStream.Position = position;
        }

        public void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          long position1 = er.BaseStream.Position;
          er.Write(this.Type);
          er.Write(this.DynamicAllocator);
          long position2 = er.BaseStream.Position;
          er.Write(0U);
          er.Write(0U);
          er.Write(this.Unknown4);
          er.Write(this.Unknown5);
          er.Write(this.Unknown6);
          er.Write(this.Unknown7);
          er.Write(this.Unknown8);
          er.Write(this.Unknown9);
          er.Write(this.Height);
          er.Write(this.Width);
          er.Write(this.Unknown12);
          er.Write(this.Unknown13);
          er.Write(this.Unknown14);
          er.Write(this.Unknown15);
          er.Write(this.Unknown16);
          er.Write(this.Unknown17);
          er.Write(this.Unknown18);
          er.Write(this.Unknown19);
          er.Write(this.Unknown20);
          er.Write(this.CommandSizeToSend);
          long position3 = er.BaseStream.Position;
          er.BaseStream.Position = position2;
          er.Write((uint) (position3 - position2));
          er.BaseStream.Position = position3;
          this.TextureObject.Write(er, c);
          long position4 = er.BaseStream.Position;
          er.BaseStream.Position = position2 + 4L;
          er.Write((uint) (position4 - (position2 + 4L)));
          er.BaseStream.Position = position4;
          this.Sampler.Write(er, position1);
        }

        public class TextureSamplerCtr
        {
          public uint Type;
          public uint OwnerOffset;
          public uint MinFilter;

          public TextureSamplerCtr()
          {
            this.MinFilter = 5U;
          }

          public TextureSamplerCtr(EndianBinaryReader er)
          {
            this.Type = er.ReadUInt32();
            this.OwnerOffset = (uint) ((ulong) er.BaseStream.Position + (ulong) er.ReadInt32());
            this.MinFilter = er.ReadUInt32();
          }

          public static CMDL.MTOB.TexInfo.TextureSamplerCtr FromStream(EndianBinaryReader er)
          {
            uint num = er.ReadUInt32();
            er.BaseStream.Position -= 4L;
            if ((int) num == int.MinValue)
              return (CMDL.MTOB.TexInfo.TextureSamplerCtr) new CMDL.MTOB.TexInfo.StandardTextureSamplerCtr(er);
            return new CMDL.MTOB.TexInfo.TextureSamplerCtr(er);
          }

          public virtual void Write(EndianBinaryWriter er, long OwnerOffset)
          {
            er.Write(this.Type);
            er.Write((int) (OwnerOffset - er.BaseStream.Position));
            er.Write(this.MinFilter);
          }
        }

        public class StandardTextureSamplerCtr : CMDL.MTOB.TexInfo.TextureSamplerCtr
        {
          public Vector4 BorderColor;
          public float LodBias;

          public StandardTextureSamplerCtr()
          {
            this.Type = (uint)0xFFFFFFFF;
            this.BorderColor = new Vector4(0.0f, 0.0f, 0.0f, 1f);
            this.LodBias = 0.0f;
          }

          public StandardTextureSamplerCtr(EndianBinaryReader er)
            : base(er)
          {
            this.BorderColor = er.ReadVector4();
            this.LodBias = er.ReadSingle();
          }

          public override void Write(EndianBinaryWriter er, long OwnerOffset)
          {
            base.Write(er, OwnerOffset);
            er.WriteVector4(this.BorderColor);
            er.Write(this.LodBias);
          }
        }
      }

      public class SHDR
      {
        public uint Type;
        public string Signature;
        public uint Revision;
        public uint NameOffset;
        public uint Unknown2;
        public uint Unknown3;
        public uint LinkedShaderNameOffset;
        public uint Unknown4;
        public string Name;
        public string LinkedShaderName;

        public SHDR()
        {
          this.Type = 2147483649U;
          this.Signature = "SHDR";
          this.Revision = 100663296U;
          this.Name = "";
          this.LinkedShaderName = "DefaultShader";
        }

        public SHDR(EndianBinaryReader er)
        {
          this.Type = er.ReadUInt32();
          this.Signature = er.ReadString(Encoding.ASCII, 4);
          if (this.Signature != "SHDR")
            throw new SignatureNotCorrectException(this.Signature, "SHDR", er.BaseStream.Position);
          this.Revision = er.ReadUInt32();
          this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.Unknown2 = er.ReadUInt32();
          this.Unknown3 = er.ReadUInt32();
          this.LinkedShaderNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.Unknown4 = er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.NameOffset;
          this.Name = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = (long) this.LinkedShaderNameOffset;
          this.LinkedShaderName = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = position;
        }

        public void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          er.Write(this.Type);
          er.Write(this.Signature, Encoding.ASCII, false);
          er.Write(this.Revision);
          c.WriteStringReference(this.Name, er);
          er.Write(this.Unknown2);
          er.Write(this.Unknown3);
          c.WriteStringReference(this.LinkedShaderName, er);
          er.Write(this.Unknown4);
        }

        public override string ToString()
        {
          return this.Name;
        }
      }

      public class FragmentShader
      {
        public Vector4 BufferColor;
        public CMDL.MTOB.FragmentShader.FragmentLightingCtr FragmentLighting;
        public uint FragmentLightingTableOffset;
        public CMDL.MTOB.FragmentShader.TextureCombinerCtr[] TextureCombiners;
        public CMDL.MTOB.FragmentShader.AlphaTestCtr AlphaTest;
        public uint BufferCommand1;
        public uint BufferCommand2;
        public uint BufferCommand3;
        public uint BufferCommand4;
        public uint BufferCommand5;
        public uint BufferCommand6;
        public CMDL.MTOB.FragmentShader.FragmentLightingTableCtr FragmentLightingTable;

        public FragmentShader()
        {
          this.BufferColor = new Vector4(0.0f, 0.0f, 0.0f, 1f);
          this.FragmentLighting = new CMDL.MTOB.FragmentShader.FragmentLightingCtr();
          this.TextureCombiners = new CMDL.MTOB.FragmentShader.TextureCombinerCtr[6];
          this.TextureCombiners[0] = new CMDL.MTOB.FragmentShader.TextureCombinerCtr(0);
          this.TextureCombiners[1] = new CMDL.MTOB.FragmentShader.TextureCombinerCtr(1);
          this.TextureCombiners[2] = new CMDL.MTOB.FragmentShader.TextureCombinerCtr(2);
          this.TextureCombiners[3] = new CMDL.MTOB.FragmentShader.TextureCombinerCtr(3);
          this.TextureCombiners[4] = new CMDL.MTOB.FragmentShader.TextureCombinerCtr(4);
          this.TextureCombiners[5] = new CMDL.MTOB.FragmentShader.TextureCombinerCtr(5);
          this.AlphaTest = new CMDL.MTOB.FragmentShader.AlphaTestCtr();
          this.BufferCommand1 = 4278190080U;
          this.BufferCommand2 = 983293U;
          this.BufferCommand3 = 0U;
          this.BufferCommand4 = 131296U;
          this.BufferCommand5 = 1024U;
          this.BufferCommand6 = 131523U;
          this.FragmentLightingTable = new CMDL.MTOB.FragmentShader.FragmentLightingTableCtr();
        }

        public FragmentShader(EndianBinaryReader er)
        {
          this.BufferColor = er.ReadVector4();
          this.FragmentLighting = new CMDL.MTOB.FragmentShader.FragmentLightingCtr(er);
          this.FragmentLightingTableOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.TextureCombiners = new CMDL.MTOB.FragmentShader.TextureCombinerCtr[6];
          for (int index = 0; index < 6; ++index)
            this.TextureCombiners[index] = new CMDL.MTOB.FragmentShader.TextureCombinerCtr(er);
          this.AlphaTest = new CMDL.MTOB.FragmentShader.AlphaTestCtr(er);
          this.BufferCommand1 = er.ReadUInt32();
          this.BufferCommand2 = er.ReadUInt32();
          this.BufferCommand3 = er.ReadUInt32();
          this.BufferCommand4 = er.ReadUInt32();
          this.BufferCommand5 = er.ReadUInt32();
          this.BufferCommand6 = er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.FragmentLightingTableOffset;
          this.FragmentLightingTable = new CMDL.MTOB.FragmentShader.FragmentLightingTableCtr(er);
          er.BaseStream.Position = position;
        }

        public void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          er.WriteVector4(this.BufferColor);
          this.FragmentLighting.Write(er);
          long position1 = er.BaseStream.Position;
          er.Write(0U);
          for (int index = 0; index < 6; ++index)
            this.TextureCombiners[index].Write(er);
          this.AlphaTest.Write(er);
          er.Write(this.BufferCommand1);
          er.Write(this.BufferCommand2);
          er.Write(this.BufferCommand3);
          er.Write(this.BufferCommand4);
          er.Write(this.BufferCommand5);
          er.Write(this.BufferCommand6);
          if (this.FragmentLightingTable == null)
            return;
          long position2 = er.BaseStream.Position;
          er.BaseStream.Position = position1;
          er.Write((uint) (position2 - position1));
          er.BaseStream.Position = position2;
          this.FragmentLightingTable.Write(er, c);
        }

        public class FragmentLightingCtr
        {
          public CMDL.MTOB.FragmentShader.FragmentLightingCtr.FragmentLightingFlags Flags;
          public uint LayerConfig;
          public uint FresnelConfig;
          public uint BumpTextureIndex;
          public uint BumpMode;
          public bool IsBumpRenormalize;

          public FragmentLightingCtr()
          {
            this.IsBumpRenormalize = false;
          }

          public FragmentLightingCtr(EndianBinaryReader er)
          {
            this.Flags = (CMDL.MTOB.FragmentShader.FragmentLightingCtr.FragmentLightingFlags) er.ReadUInt32();
            this.LayerConfig = er.ReadUInt32();
            this.FresnelConfig = er.ReadUInt32();
            this.BumpTextureIndex = er.ReadUInt32();
            this.BumpMode = er.ReadUInt32();
            this.IsBumpRenormalize = (int) er.ReadUInt32() == 1;
          }

          public void Write(EndianBinaryWriter er)
          {
            er.Write((uint) this.Flags);
            er.Write(this.LayerConfig);
            er.Write(this.FresnelConfig);
            er.Write(this.BumpTextureIndex);
            er.Write(this.BumpMode);
            er.Write(this.IsBumpRenormalize ? 1U : 0U);
          }

          [System.Flags]
          public enum FragmentLightingFlags : uint
          {
            ClampHighLight = 1U,
            UseDistribution0 = 2U,
            UseDistribution1 = 4U,
            UseGeometricFactor0 = 8U,
            UseGeometricFactor1 = 16U,
            UseReflection = 32U,
          }
        }

        public class FragmentLightingTableCtr
        {
          public uint ReflectanceRSamplerOffset;
          public uint ReflectanceGSamplerOffset;
          public uint ReflectanceBSamplerOffset;
          public uint Distribution0SamplerOffset;
          public uint Distribution1SamplerOffset;
          public uint FresnelSamplerOffset;
          public CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr ReflectanceRSampler;
          public CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr ReflectanceGSampler;
          public CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr ReflectanceBSampler;
          public CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr Distribution0Sampler;
          public CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr Distribution1Sampler;
          public CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr FresnelSampler;

          public FragmentLightingTableCtr()
          {
          }

          public FragmentLightingTableCtr(EndianBinaryReader er)
          {
            this.ReflectanceRSamplerOffset = er.ReadUInt32();
            if ((int) this.ReflectanceRSamplerOffset != 0)
              this.ReflectanceRSamplerOffset = this.ReflectanceRSamplerOffset + ((uint) er.BaseStream.Position - 4U);
            this.ReflectanceGSamplerOffset = er.ReadUInt32();
            if ((int) this.ReflectanceGSamplerOffset != 0)
              this.ReflectanceGSamplerOffset = this.ReflectanceGSamplerOffset + ((uint) er.BaseStream.Position - 4U);
            this.ReflectanceBSamplerOffset = er.ReadUInt32();
            if ((int) this.ReflectanceBSamplerOffset != 0)
              this.ReflectanceBSamplerOffset = this.ReflectanceBSamplerOffset + ((uint) er.BaseStream.Position - 4U);
            this.Distribution0SamplerOffset = er.ReadUInt32();
            if ((int) this.Distribution0SamplerOffset != 0)
              this.Distribution0SamplerOffset = this.Distribution0SamplerOffset + ((uint) er.BaseStream.Position - 4U);
            this.Distribution1SamplerOffset = er.ReadUInt32();
            if ((int) this.Distribution1SamplerOffset != 0)
              this.Distribution1SamplerOffset = this.Distribution1SamplerOffset + ((uint) er.BaseStream.Position - 4U);
            this.FresnelSamplerOffset = er.ReadUInt32();
            if ((int) this.FresnelSamplerOffset != 0)
              this.FresnelSamplerOffset = this.FresnelSamplerOffset + ((uint) er.BaseStream.Position - 4U);
            if ((int) this.ReflectanceRSamplerOffset != 0)
            {
              er.BaseStream.Position = (long) this.ReflectanceRSamplerOffset;
              this.ReflectanceRSampler = new CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr(er);
            }
            if ((int) this.ReflectanceGSamplerOffset != 0)
            {
              er.BaseStream.Position = (long) this.ReflectanceGSamplerOffset;
              this.ReflectanceGSampler = new CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr(er);
            }
            if ((int) this.ReflectanceBSamplerOffset != 0)
            {
              er.BaseStream.Position = (long) this.ReflectanceBSamplerOffset;
              this.ReflectanceBSampler = new CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr(er);
            }
            if ((int) this.Distribution0SamplerOffset != 0)
            {
              er.BaseStream.Position = (long) this.Distribution0SamplerOffset;
              this.Distribution0Sampler = new CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr(er);
            }
            if ((int) this.Distribution1SamplerOffset != 0)
            {
              er.BaseStream.Position = (long) this.Distribution1SamplerOffset;
              this.Distribution1Sampler = new CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr(er);
            }
            if ((int) this.FresnelSamplerOffset == 0)
              return;
            er.BaseStream.Position = (long) this.FresnelSamplerOffset;
            this.FresnelSampler = new CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr(er);
          }

          public void Write(EndianBinaryWriter er, CGFXWriterContext c)
          {
            long position1 = er.BaseStream.Position;
            er.Write(0U);
            er.Write(0U);
            er.Write(0U);
            er.Write(0U);
            er.Write(0U);
            er.Write(0U);
            if (this.ReflectanceRSampler != null)
            {
              long position2 = er.BaseStream.Position;
              er.BaseStream.Position = position1;
              er.Write((uint) (position2 - position1));
              er.BaseStream.Position = position2;
              this.ReflectanceRSampler.Write(er, c);
            }
            if (this.ReflectanceGSampler != null)
            {
              long position2 = er.BaseStream.Position;
              er.BaseStream.Position = position1 + 4L;
              er.Write((uint) (position2 - (position1 + 4L)));
              er.BaseStream.Position = position2;
              this.ReflectanceGSampler.Write(er, c);
            }
            if (this.ReflectanceBSampler != null)
            {
              long position2 = er.BaseStream.Position;
              er.BaseStream.Position = position1 + 8L;
              er.Write((uint) (position2 - (position1 + 8L)));
              er.BaseStream.Position = position2;
              this.ReflectanceBSampler.Write(er, c);
            }
            if (this.Distribution0Sampler != null)
            {
              long position2 = er.BaseStream.Position;
              er.BaseStream.Position = position1 + 12L;
              er.Write((uint) (position2 - (position1 + 12L)));
              er.BaseStream.Position = position2;
              this.Distribution0Sampler.Write(er, c);
            }
            if (this.Distribution1Sampler != null)
            {
              long position2 = er.BaseStream.Position;
              er.BaseStream.Position = position1 + 16L;
              er.Write((uint) (position2 - (position1 + 16L)));
              er.BaseStream.Position = position2;
              this.Distribution1Sampler.Write(er, c);
            }
            if (this.FresnelSampler == null)
              return;
            long position3 = er.BaseStream.Position;
            er.BaseStream.Position = position1 + 20L;
            er.Write((uint) (position3 - (position1 + 20L)));
            er.BaseStream.Position = position3;
            this.FresnelSampler.Write(er, c);
          }

          public uint GetHash()
          {
            List<byte> list = new List<byte>();
            if (this.ReflectanceRSampler != null)
            {
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.ReflectanceRSampler.InputCommand));
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.ReflectanceRSampler.ScaleCommand));
            }
            if (this.ReflectanceGSampler != null)
            {
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.ReflectanceGSampler.InputCommand));
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.ReflectanceGSampler.ScaleCommand));
            }
            if (this.ReflectanceBSampler != null)
            {
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.ReflectanceBSampler.InputCommand));
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.ReflectanceBSampler.ScaleCommand));
            }
            if (this.Distribution0Sampler != null)
            {
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.Distribution0Sampler.InputCommand));
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.Distribution0Sampler.ScaleCommand));
            }
            if (this.Distribution1Sampler != null)
            {
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.Distribution1Sampler.InputCommand));
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.Distribution1Sampler.ScaleCommand));
            }
            if (this.FresnelSampler != null)
            {
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.FresnelSampler.InputCommand));
              list.AddRange((IEnumerable<byte>) BitConverter.GetBytes(this.FresnelSampler.ScaleCommand));
            }
            return CGFXWriterContext.CalcHash(list.ToArray());
          }

          public class LightingLookupTableCtr
          {
            public uint InputCommand;
            public uint ScaleCommand;
            public uint SamplerOffset;
            public CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr.ReferenceLookupTableCtr Sampler;

            public LightingLookupTableCtr(EndianBinaryReader er)
            {
              this.InputCommand = er.ReadUInt32();
              this.ScaleCommand = er.ReadUInt32();
              this.SamplerOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
              long position = er.BaseStream.Position;
              er.BaseStream.Position = (long) this.SamplerOffset;
              this.Sampler = new CMDL.MTOB.FragmentShader.FragmentLightingTableCtr.LightingLookupTableCtr.ReferenceLookupTableCtr(er);
              er.BaseStream.Position = position;
            }

            public void Write(EndianBinaryWriter er, CGFXWriterContext c)
            {
              er.Write(this.InputCommand);
              er.Write(this.ScaleCommand);
              er.Write(4U);
              this.Sampler.Write(er, c);
            }

            public class ReferenceLookupTableCtr
            {
              public uint Type;
              public uint BinaryPathOffset;
              public uint TableNameOffset;
              public uint TargetLUTOffset;
              public string BinaryPath;
              public string TableName;

              public ReferenceLookupTableCtr(EndianBinaryReader er)
              {
                this.Type = er.ReadUInt32();
                this.BinaryPathOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
                this.TableNameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
                this.TargetLUTOffset = er.ReadUInt32();
                if ((int) this.TargetLUTOffset != 0)
                  this.TargetLUTOffset = this.TargetLUTOffset + ((uint) er.BaseStream.Position - 4U);
                long position = er.BaseStream.Position;
                er.BaseStream.Position = (long) this.BinaryPathOffset;
                this.BinaryPath = er.ReadStringNT(Encoding.ASCII);
                er.BaseStream.Position = (long) this.TableNameOffset;
                this.TableName = er.ReadStringNT(Encoding.ASCII);
                er.BaseStream.Position = position;
              }

              public void Write(EndianBinaryWriter er, CGFXWriterContext c)
              {
                er.Write(this.Type);
                c.WriteStringReference(this.BinaryPath, er);
                c.WriteStringReference(this.TableName, er);
                er.Write(0U);
              }
            }
          }
        }

        public class TextureCombinerCtr
        {
          private static readonly uint[] Addresses = new uint[6]
          {
            192U,
            200U,
            208U,
            216U,
            240U,
            248U
          };
          public uint Constant;
          public ushort SrcRgb;
          public ushort SrcAlpha;
          public uint Address;
          public uint Operands;
          public ushort CombineRgb;
          public ushort CombineAlpha;
          public Color ConstRgba;
          public ushort ScaleRgb;
          public ushort ScaleAlpha;

          public TextureCombinerCtr(int Index)
          {
            this.SrcRgb = (ushort) 3808;
            this.SrcAlpha = (ushort) 3808;
            this.Address = 2152660992U | CMDL.MTOB.FragmentShader.TextureCombinerCtr.Addresses[Index];
            this.ConstRgba = Color.Black;
          }

          public TextureCombinerCtr(EndianBinaryReader er)
          {
            this.Constant = er.ReadUInt32();
            this.SrcRgb = er.ReadUInt16();
            this.SrcAlpha = er.ReadUInt16();
            this.Address = er.ReadUInt32();
            this.Operands = er.ReadUInt32();
            this.CombineRgb = er.ReadUInt16();
            this.CombineAlpha = er.ReadUInt16();
            this.ConstRgba = Extensions.ReadColor8(er);
            this.ScaleRgb = er.ReadUInt16();
            this.ScaleAlpha = er.ReadUInt16();
          }

          public void Write(EndianBinaryWriter er)
          {
            er.Write(this.Constant);
            er.Write(this.SrcRgb);
            er.Write(this.SrcAlpha);
            er.Write(this.Address);
            er.Write(this.Operands);
            er.Write(this.CombineRgb);
            er.Write(this.CombineAlpha);
            Extensions.WriteColor8(er, this.ConstRgba);
            er.Write(this.ScaleRgb);
            er.Write(this.ScaleAlpha);
          }
        }

        public class AlphaTestCtr
        {
          private readonly int[] GlAlphaFunc = new int[8]
          {
            512,
            519,
            514,
            517,
            513,
            515,
            516,
            518
          };
          private readonly uint[] ReverseFunc = new uint[8]
          {
            0U,
            1U,
            4U,
            7U,
            2U,
            3U,
            6U,
            5U
          };
          public uint Command1;
          public uint Command2;

          public AlphaTestCtr()
          {
            this.Command1 = 17U;
            this.Command2 = 983300U;
          }

          public AlphaTestCtr(EndianBinaryReader er)
          {
            this.Command1 = er.ReadUInt32();
            this.Command2 = er.ReadUInt32();
          }

          public void Write(EndianBinaryWriter er)
          {
            er.Write(this.Command1);
            er.Write(this.Command2);
          }

          public void GlApply()
          {
            if (((int) this.Command1 & 1) == 1)
            {
              Gl.glEnable(3008);
              Gl.glAlphaFunc(this.GlAlphaFunc[(int) (this.Command1 >> 4 & 15U)], (float) (((double) (this.Command1 >> 8) - 0.5) / (double) byte.MaxValue));
              Gl.glEnable(3008);
            }
            else
              Gl.glDisable(3008);
          }

          public uint GetHash()
          {
            byte[] Data = new byte[9];
            int index = 0;
            int num1 = (int) (byte) (this.Command1 & 1U);
            Data[index] = (byte) num1;
            int Offset1 = 1;
            int num2 = (int) this.ReverseFunc[(int) (this.Command1 >> 4) & 15];
            IOUtil.WriteU32LE(Data, Offset1, (uint) num2);
            int Offset2 = 5;
            double num3 = (double) (uint) ((double) (this.Command1 >> 8) - 0.5) / (double) byte.MaxValue;
            IOUtil.WriteSingleLE(Data, Offset2, (float) num3);
            return CGFXWriterContext.CalcHash(Data);
          }
        }
      }
    }

    public class Mesh
    {
      public uint Type;
      public string Signature;
      public uint Revision;
      public uint NameOffset;
      public uint Unknown2;
      public uint Unknown3;
      public uint ShapeIndex;
      public uint MaterialIndex;
      public uint OwnerModelOffset;
      public bool IsVisible;
      public byte RenderPriority;
      public short MeshNodeVisibilityIndex;
      public uint Unknown8;
      public uint Unknown9;
      public uint Unknown10;
      public uint Unknown11;
      public uint Unknown12;
      public uint Unknown13;
      public uint Unknown14;
      public uint Unknown15;
      public uint Unknown16;
      public uint Unknown17;
      public uint Unknown18;
      public uint Unknown19;
      public uint Unknown20;
      public uint Unknown21;
      public uint Unknown22;
      public uint Unknown23;
      public uint Unknown24;
      public uint Unknown25;
      public uint MeshNodeNameOffset;
      public uint Unknown27;
      public uint Unknown28;
      public uint Unknown29;
      public uint Unknown30;
      public string Name;
      public string MeshNodeName;

      public Mesh()
      {
        this.Type = 16777216U;
        this.Signature = "SOBJ";
        this.Revision = 0U;
        this.Name = "";
        this.IsVisible = true;
      }

      public Mesh(EndianBinaryReader er)
      {
        this.Type = er.ReadUInt32();
        this.Signature = er.ReadString(Encoding.ASCII, 4);
        if (this.Signature != "SOBJ")
          throw new SignatureNotCorrectException(this.Signature, "SOBJ", er.BaseStream.Position);
        this.Revision = er.ReadUInt32();
        this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.Unknown2 = er.ReadUInt32();
        this.Unknown3 = er.ReadUInt32();
        this.ShapeIndex = er.ReadUInt32();
        this.MaterialIndex = er.ReadUInt32();
        this.OwnerModelOffset = (uint) ((ulong) er.ReadInt32() + (ulong) (uint) er.BaseStream.Position);
        this.IsVisible = (int) er.ReadByte() == 1;
        this.RenderPriority = er.ReadByte();
        this.MeshNodeVisibilityIndex = er.ReadInt16();
        this.Unknown8 = er.ReadUInt32();
        this.Unknown9 = er.ReadUInt32();
        this.Unknown10 = er.ReadUInt32();
        this.Unknown11 = er.ReadUInt32();
        this.Unknown12 = er.ReadUInt32();
        this.Unknown13 = er.ReadUInt32();
        this.Unknown14 = er.ReadUInt32();
        this.Unknown15 = er.ReadUInt32();
        this.Unknown16 = er.ReadUInt32();
        this.Unknown17 = er.ReadUInt32();
        this.Unknown18 = er.ReadUInt32();
        this.Unknown19 = er.ReadUInt32();
        this.Unknown20 = er.ReadUInt32();
        this.Unknown21 = er.ReadUInt32();
        this.Unknown22 = er.ReadUInt32();
        this.Unknown23 = er.ReadUInt32();
        this.Unknown24 = er.ReadUInt32();
        this.Unknown25 = er.ReadUInt32();
        this.MeshNodeNameOffset = er.ReadUInt32();
        if ((int) this.MeshNodeNameOffset != 0)
          this.MeshNodeNameOffset = this.MeshNodeNameOffset + ((uint) er.BaseStream.Position - 4U);
        this.Unknown27 = er.ReadUInt32();
        this.Unknown28 = er.ReadUInt32();
        this.Unknown29 = er.ReadUInt32();
        this.Unknown30 = er.ReadUInt32();
        long position = er.BaseStream.Position;
        er.BaseStream.Position = (long) this.NameOffset;
        this.Name = er.ReadStringNT(Encoding.ASCII);
        if ((int) this.MeshNodeNameOffset != 0)
        {
          er.BaseStream.Position = (long) this.MeshNodeNameOffset;
          this.MeshNodeName = er.ReadStringNT(Encoding.ASCII);
        }
        er.BaseStream.Position = position;
      }

      public void Write(EndianBinaryWriter er, CGFXWriterContext c, long OwnerOffset)
      {
        er.Write(this.Type);
        er.Write(this.Signature, Encoding.ASCII, false);
        er.Write(this.Revision);
        c.WriteStringReference(this.Name, er);
        er.Write(this.Unknown2);
        er.Write(this.Unknown3);
        er.Write(this.ShapeIndex);
        er.Write(this.MaterialIndex);
        er.Write((int) (OwnerOffset - er.BaseStream.Position));
        er.Write(this.IsVisible ? (byte) 1 : (byte) 0);
        er.Write(this.RenderPriority);
        er.Write(this.MeshNodeVisibilityIndex);
        er.Write(this.Unknown8);
        er.Write(this.Unknown9);
        er.Write(this.Unknown10);
        er.Write(this.Unknown11);
        er.Write(this.Unknown12);
        er.Write(this.Unknown13);
        er.Write(this.Unknown14);
        er.Write(this.Unknown15);
        er.Write(this.Unknown16);
        er.Write(this.Unknown17);
        er.Write(this.Unknown18);
        er.Write(this.Unknown19);
        er.Write(this.Unknown20);
        er.Write(this.Unknown21);
        er.Write(this.Unknown22);
        er.Write(this.Unknown23);
        er.Write(this.Unknown24);
        er.Write(this.Unknown25);
        if (this.MeshNodeName != null)
          c.WriteStringReference(this.MeshNodeName, er);
        else
          er.Write(0U);
        er.Write(this.Unknown27);
        er.Write(this.Unknown28);
        er.Write(this.Unknown29);
        er.Write(this.Unknown30);
      }

      public override string ToString()
      {
        return this.Name;
      }
    }

    public class SeparateDataShape
    {
      public uint Type;
      public string Signature;
      public uint Revision;
      public uint NameOffset;
      public uint Unknown2;
      public uint Unknown3;
      public CMDL.SeparateDataShape.ShapeFlags Flags;
      public uint OrientedBoundingBoxOffset;
      public Vector3 PositionOffset;
      public uint NrPrimitiveSets;
      public uint PrimitiveSetOffsetsArrayOffset;
      public uint BaseAddress;
      public uint NrVertexAttributes;
      public uint VertexAttributeOffsetsArrayOffset;
      public uint BlendShapeOffset;
      public uint[] PrimitiveSetOffsets;
      public uint[] VertexAttributeOffsets;
      public string Name;
      public BoundingVolume BoundingBox;
      public CMDL.SeparateDataShape.PrimitiveSet[] PrimitiveSets;
      public CMDL.SeparateDataShape.VertexAttributeCtr[] VertexAttributes;
      public CMDL.SeparateDataShape.BlendShapeCtr BlendShape;

      public SeparateDataShape()
      {
        this.Type = 268435457U;
        this.Signature = "SOBJ";
        this.Revision = 0U;
        this.Name = "";
        this.BoundingBox = (BoundingVolume) new OrientedBoundingBox();
        this.PositionOffset = new Vector3(0.0f, 0.0f, 0.0f);
      }

      public SeparateDataShape(EndianBinaryReader er)
      {
        this.Type = er.ReadUInt32();
        this.Signature = er.ReadString(Encoding.ASCII, 4);
        if (this.Signature != "SOBJ")
          throw new SignatureNotCorrectException(this.Signature, "SOBJ", er.BaseStream.Position);
        this.Revision = er.ReadUInt32();
        this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.Unknown2 = er.ReadUInt32();
        this.Unknown3 = er.ReadUInt32();
        this.Flags = (CMDL.SeparateDataShape.ShapeFlags) er.ReadUInt32();
        this.OrientedBoundingBoxOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.PositionOffset = er.ReadVector3();
        this.NrPrimitiveSets = er.ReadUInt32();
        this.PrimitiveSetOffsetsArrayOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.BaseAddress = er.ReadUInt32();
        this.NrVertexAttributes = er.ReadUInt32();
        this.VertexAttributeOffsetsArrayOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.BlendShapeOffset = er.ReadUInt32();
        if ((int) this.BlendShapeOffset != 0)
          this.BlendShapeOffset = this.BlendShapeOffset + ((uint) er.BaseStream.Position - 4U);
        long position = er.BaseStream.Position;
        er.BaseStream.Position = (long) this.NameOffset;
        this.Name = er.ReadStringNT(Encoding.ASCII);
        er.BaseStream.Position = (long) this.OrientedBoundingBoxOffset;
        this.BoundingBox = BoundingVolume.FromStream(er);
        er.BaseStream.Position = (long) this.PrimitiveSetOffsetsArrayOffset;
        this.PrimitiveSetOffsets = new uint[(int) this.NrPrimitiveSets];
        for (int index = 0; (long) index < (long) this.NrPrimitiveSets; ++index)
          this.PrimitiveSetOffsets[index] = (uint) er.BaseStream.Position + er.ReadUInt32();
        er.BaseStream.Position = (long) this.VertexAttributeOffsetsArrayOffset;
        this.VertexAttributeOffsets = new uint[(int) this.NrVertexAttributes];
        for (int index = 0; (long) index < (long) this.NrVertexAttributes; ++index)
          this.VertexAttributeOffsets[index] = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.PrimitiveSets = new CMDL.SeparateDataShape.PrimitiveSet[(int) this.NrPrimitiveSets];
        for (int index = 0; (long) index < (long) this.NrPrimitiveSets; ++index)
        {
          er.BaseStream.Position = (long) this.PrimitiveSetOffsets[index];
          this.PrimitiveSets[index] = new CMDL.SeparateDataShape.PrimitiveSet(er);
        }
        this.VertexAttributes = new CMDL.SeparateDataShape.VertexAttributeCtr[(int) this.NrVertexAttributes];
        if ((int) this.NrVertexAttributes != 0)
        {
          for (int index = 0; (long) index < (long) this.NrVertexAttributes; ++index)
          {
            er.BaseStream.Position = (long) this.VertexAttributeOffsets[index];
            this.VertexAttributes[index] = CMDL.SeparateDataShape.VertexAttributeCtr.FromStream(er);
          }
        }
        if ((int) this.BlendShapeOffset != 0)
        {
          er.BaseStream.Position = (long) this.BlendShapeOffset;
          this.BlendShape = new CMDL.SeparateDataShape.BlendShapeCtr(er);
        }
        er.BaseStream.Position = position;
      }

      public void Write(EndianBinaryWriter er, CGFXWriterContext c)
      {
        er.Write(this.Type);
        er.Write(this.Signature, Encoding.ASCII, false);
        er.Write(this.Revision);
        c.WriteStringReference(this.Name, er);
        er.Write(this.Unknown2);
        er.Write(this.Unknown3);
        er.Write((uint) this.Flags);
        long position1 = er.BaseStream.Position;
        er.Write(0U);
        er.WriteVector3(this.PositionOffset);
        er.Write(this.NrPrimitiveSets);
        long position2 = er.BaseStream.Position;
        er.Write(0U);
        er.Write(this.BaseAddress);
        er.Write(this.NrVertexAttributes);
        long position3 = er.BaseStream.Position;
        er.Write(0U);
        long position4 = er.BaseStream.Position;
        er.Write(0U);
        long position5 = er.BaseStream.Position;
        er.BaseStream.Position = position2;
        er.Write((uint) (position5 - position2));
        er.BaseStream.Position = position5;
        er.Write(new uint[(int) this.NrPrimitiveSets], 0, (int) this.NrPrimitiveSets);
        long position6 = er.BaseStream.Position;
        er.BaseStream.Position = position3;
        er.Write((uint) (position6 - position3));
        er.BaseStream.Position = position6;
        er.Write(new uint[(int) this.NrVertexAttributes], 0, (int) this.NrVertexAttributes);
        long position7 = er.BaseStream.Position;
        er.BaseStream.Position = position1;
        er.Write((uint) (position7 - position1));
        er.BaseStream.Position = position7;
        this.BoundingBox.Write(er);
        for (int index = 0; (long) index < (long) this.NrPrimitiveSets; ++index)
        {
          long position8 = er.BaseStream.Position;
          er.BaseStream.Position = position5 + (long) (4 * index);
          er.Write((uint) (position8 - (position5 + (long) (4 * index))));
          er.BaseStream.Position = position8;
          this.PrimitiveSets[index].Write(er, c);
        }
        for (int index = 0; (long) index < (long) this.NrVertexAttributes; ++index)
        {
          long position8 = er.BaseStream.Position;
          er.BaseStream.Position = position6 + (long) (4 * index);
          er.Write((uint) (position8 - (position6 + (long) (4 * index))));
          er.BaseStream.Position = position8;
          this.VertexAttributes[index].Write(er, c);
        }
        if (this.BlendShape == null)
          return;
        long position9 = er.BaseStream.Position;
        er.BaseStream.Position = position4;
        er.Write((uint) (position9 - position4));
        er.BaseStream.Position = position9;
        this.BlendShape.Write(er);
      }

      public Polygon GetVertexData(CMDL Model)
      {
        Polygon Destination = new Polygon();
        foreach (CMDL.SeparateDataShape.VertexAttributeCtr vertexAttributeCtr in this.VertexAttributes)
          vertexAttributeCtr.GetVertexData(Destination, this.PrimitiveSets[0], Model);
        return Destination;
      }

      public override string ToString()
      {
        return this.Name;
      }

      [System.Flags]
      public enum ShapeFlags : uint
      {
        HasBeenSetup = 1U,
      }

      public enum DataType : uint
      {
        GL_BYTE = 5120U,
        GL_UNSIGNED_BYTE = 5121U,
        GL_SHORT = 5122U,
        GL_FLOAT = 5126U,
      }

      public class PrimitiveSet
      {
        public uint NrRelatedBones;
        public uint RelatedBonesArrayOffset;
        public uint SkinningMode;
        public uint NrPrimitives;
        public uint PrimitiveOffsetsArrayOffset;
        public uint[] RelatedBones;
        public uint[] PrimitiveOffsets;
        public CMDL.SeparateDataShape.PrimitiveSet.Primitive[] Primitives;

        public PrimitiveSet()
        {
          this.NrRelatedBones = 0U;
          this.SkinningMode = 0U;
        }

        public PrimitiveSet(EndianBinaryReader er)
        {
          this.NrRelatedBones = er.ReadUInt32();
          this.RelatedBonesArrayOffset = er.ReadUInt32();
          if ((int) this.RelatedBonesArrayOffset != 0)
            this.RelatedBonesArrayOffset = this.RelatedBonesArrayOffset + ((uint) er.BaseStream.Position - 4U);
          this.SkinningMode = er.ReadUInt32();
          this.NrPrimitives = er.ReadUInt32();
          this.PrimitiveOffsetsArrayOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          long position = er.BaseStream.Position;
          if ((int) this.RelatedBonesArrayOffset != 0)
          {
            er.BaseStream.Position = (long) this.RelatedBonesArrayOffset;
            this.RelatedBones = er.ReadUInt32s((int) this.NrRelatedBones);
          }
          er.BaseStream.Position = (long) this.PrimitiveOffsetsArrayOffset;
          this.PrimitiveOffsets = new uint[(int) this.NrPrimitives];
          for (int index = 0; (long) index < (long) this.NrPrimitives; ++index)
            this.PrimitiveOffsets[index] = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.Primitives = new CMDL.SeparateDataShape.PrimitiveSet.Primitive[(int) this.NrPrimitives];
          for (int index = 0; (long) index < (long) this.NrPrimitives; ++index)
          {
            er.BaseStream.Position = (long) this.PrimitiveOffsets[index];
            this.Primitives[index] = new CMDL.SeparateDataShape.PrimitiveSet.Primitive(er);
          }
        }

        public void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          er.Write(this.NrRelatedBones);
          if ((int) this.NrRelatedBones != 0)
            er.Write(16U);
          else
            er.Write(0U);
          er.Write(this.SkinningMode);
          er.Write(this.NrPrimitives);
          if ((int) this.NrRelatedBones != 0 && (int) this.NrPrimitives != 0)
            er.Write((uint) (4 + (int) this.NrRelatedBones * 4));
          else if ((int) this.NrRelatedBones == 0 && (int) this.NrPrimitives != 0)
            er.Write(4U);
          else
            er.Write(0U);
          er.Write(this.RelatedBones, 0, (int) this.NrRelatedBones);
          long position1 = er.BaseStream.Position;
          er.Write(new uint[(int) this.NrPrimitives], 0, (int) this.NrPrimitives);
          for (int index = 0; (long) index < (long) this.NrPrimitives; ++index)
          {
            long position2 = er.BaseStream.Position;
            er.BaseStream.Position = position1 + (long) (4 * index);
            er.Write((uint) (position2 - (position1 + (long) (4 * index))));
            er.BaseStream.Position = position2;
            this.Primitives[index].Write(er, c);
          }
        }

        public class Primitive
        {
          public uint NrIndexStreams;
          public uint IndexStreamOffsetsArrayOffset;
          public uint NrBufferObjects;
          public uint BufferObjectArrayOffset;
          public uint Flags;
          public uint CommandAllocator;
          public uint[] IndexStreamOffsets;
          public uint[] BufferObjects;
          public CMDL.SeparateDataShape.PrimitiveSet.Primitive.IndexStreamCtr[] IndexStreams;

          public Primitive()
          {
          }

          public Primitive(EndianBinaryReader er)
          {
            this.NrIndexStreams = er.ReadUInt32();
            this.IndexStreamOffsetsArrayOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
            this.NrBufferObjects = er.ReadUInt32();
            this.BufferObjectArrayOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
            this.Flags = er.ReadUInt32();
            this.CommandAllocator = er.ReadUInt32();
            long position = er.BaseStream.Position;
            er.BaseStream.Position = (long) this.IndexStreamOffsetsArrayOffset;
            this.IndexStreamOffsets = new uint[(int) this.NrIndexStreams];
            for (int index = 0; (long) index < (long) this.NrIndexStreams; ++index)
              this.IndexStreamOffsets[index] = (uint) er.BaseStream.Position + er.ReadUInt32();
            er.BaseStream.Position = (long) this.BufferObjectArrayOffset;
            this.BufferObjects = er.ReadUInt32s((int) this.NrBufferObjects);
            this.IndexStreams = new CMDL.SeparateDataShape.PrimitiveSet.Primitive.IndexStreamCtr[(int) this.NrIndexStreams];
            for (int index = 0; (long) index < (long) this.NrIndexStreams; ++index)
            {
              er.BaseStream.Position = (long) this.IndexStreamOffsets[index];
              this.IndexStreams[index] = new CMDL.SeparateDataShape.PrimitiveSet.Primitive.IndexStreamCtr(er);
            }
          }

          public void Write(EndianBinaryWriter er, CGFXWriterContext c)
          {
            er.Write(this.NrIndexStreams);
            if ((int) this.NrIndexStreams != 0)
              er.Write(20U);
            else
              er.Write(0U);
            er.Write(this.NrBufferObjects);
            if ((int) this.NrIndexStreams != 0 && (int) this.NrBufferObjects != 0)
              er.Write((uint) (12 + (int) this.NrIndexStreams * 4));
            else if ((int) this.NrIndexStreams == 0 && (int) this.NrBufferObjects != 0)
              er.Write(12U);
            else
              er.Write(0U);
            er.Write(this.Flags);
            er.Write(this.CommandAllocator);
            long position1 = er.BaseStream.Position;
            er.Write(new uint[(int) this.NrIndexStreams], 0, (int) this.NrIndexStreams);
            er.Write(this.BufferObjects, 0, (int) this.NrBufferObjects);
            for (int index = 0; (long) index < (long) this.NrIndexStreams; ++index)
            {
              long position2 = er.BaseStream.Position;
              er.BaseStream.Position = position1 + (long) (4 * index);
              er.Write((uint) (position2 - (position1 + (long) (4 * index))));
              er.BaseStream.Position = position2;
              this.IndexStreams[index].Write(er, c);
            }
          }

          public class IndexStreamCtr
          {
            public uint FormatType;
            public byte PrimitiveMode;
            public bool IsVisible;
            public uint FaceDataLength;
            public uint FaceDataOffset;
            public uint BufferObject;
            public uint LocationFlag;
            public uint CommandCache;
            public uint CommandCacheSize;
            public uint LocationAddress;
            public uint MemoryArea;
            public uint BoundingBoxOffset;
            public BoundingVolume BoundingBox;
            public byte[] FaceData;

            public IndexStreamCtr()
            {
              this.FormatType = 5121U;
              this.PrimitiveMode = (byte) 0;
              this.IsVisible = true;
            }

            public IndexStreamCtr(EndianBinaryReader er)
            {
              this.FormatType = er.ReadUInt32();
              this.PrimitiveMode = er.ReadByte();
              this.IsVisible = (int) er.ReadByte() == 1;
              int num = (int) er.ReadUInt16();
              this.FaceDataLength = er.ReadUInt32();
              this.FaceDataOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
              this.BufferObject = er.ReadUInt32();
              this.LocationFlag = er.ReadUInt32();
              this.CommandCache = er.ReadUInt32();
              this.CommandCacheSize = er.ReadUInt32();
              this.LocationAddress = er.ReadUInt32();
              this.MemoryArea = er.ReadUInt32();
              this.BoundingBoxOffset = er.ReadUInt32();
              if ((int) this.BoundingBoxOffset != 0)
                this.BoundingBoxOffset = this.BoundingBoxOffset + ((uint) er.BaseStream.Position - 4U);
              long position = er.BaseStream.Position;
              er.BaseStream.Position = (long) this.FaceDataOffset;
              this.FaceData = er.ReadBytes((int) this.FaceDataLength);
              if ((int) this.BoundingBoxOffset != 0)
              {
                er.BaseStream.Position = (long) this.BoundingBoxOffset;
                this.BoundingBox = BoundingVolume.FromStream(er);
              }
              er.BaseStream.Position = position;
            }

            public void Write(EndianBinaryWriter er, CGFXWriterContext c)
            {
              er.Write(this.FormatType);
              er.Write(this.PrimitiveMode);
              er.Write(this.IsVisible ? (byte) 1 : (byte) 0);
              er.Write((ushort) 0);
              er.Write(this.FaceDataLength);
              c.WriteDataReference(this.FaceData, er);
              er.Write(this.BufferObject);
              er.Write(this.LocationFlag);
              er.Write(this.CommandCache);
              er.Write(this.CommandCacheSize);
              er.Write(this.LocationAddress);
              er.Write(this.MemoryArea);
              if (this.BoundingBox != null)
              {
                er.Write(4U);
                this.BoundingBox.Write(er);
              }
              else
                er.Write(0U);
            }

            public Vector3[] GetFaceData()
            {
              int Offset = 0;
              Vector3[] vector3Array;
              if ((int) this.FormatType == 5123)
              {
                int length = (int) (this.FaceDataLength / 2U / 3U);
                vector3Array = new Vector3[length];
                for (int index = 0; index < length; ++index)
                {
                  vector3Array[index] = new Vector3((float) IOUtil.ReadU16LE(this.FaceData, Offset), (float) IOUtil.ReadU16LE(this.FaceData, Offset + 2), (float) IOUtil.ReadU16LE(this.FaceData, Offset + 4));
                  Offset += 6;
                }
              }
              else if ((int) this.FormatType == 5121)
              {
                int length = (int) (this.FaceDataLength / 3U);
                vector3Array = new Vector3[length];
                for (int index = 0; index < length; ++index)
                {
                  vector3Array[index] = new Vector3((float) this.FaceData[Offset], (float) this.FaceData[Offset + 1], (float) this.FaceData[Offset + 2]);
                  Offset += 3;
                }
              }
              else
                vector3Array = new Vector3[0];
              return vector3Array;
            }
          }
        }
      }

      public class VertexAttributeCtr
      {
        public uint Type;
        public CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage Usage;
        public CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeFlags Flags;

        public VertexAttributeCtr()
        {
        }

        public VertexAttributeCtr(EndianBinaryReader er)
        {
          this.Type = er.ReadUInt32();
          this.Usage = (CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage) er.ReadUInt32();
          this.Flags = (CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeFlags) er.ReadUInt32();
        }

        public virtual void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          er.Write(this.Type);
          er.Write((uint) this.Usage);
          er.Write((uint) this.Flags);
        }

        public static CMDL.SeparateDataShape.VertexAttributeCtr FromStream(EndianBinaryReader er)
        {
          uint num = er.ReadUInt32();
          er.BaseStream.Position -= 4L;
          if ((int) num == 1073741826)
            return (CMDL.SeparateDataShape.VertexAttributeCtr) new CMDL.SeparateDataShape.InterleavedVertexStreamCtr(er);
          if ((int) num == int.MinValue)
            return (CMDL.SeparateDataShape.VertexAttributeCtr) new CMDL.SeparateDataShape.VertexParamAttributeCtr(er);
          return new CMDL.SeparateDataShape.VertexAttributeCtr(er);
        }

        public virtual void GetVertexData(Polygon Destination, CMDL.SeparateDataShape.PrimitiveSet PrimitiveSet, CMDL Model)
        {
        }

        public enum VertexAttributeUsage : uint
        {
          Position,
          Normal,
          Tangent,
          Color,
          TextureCoordinate0,
          TextureCoordinate1,
          TextureCoordinate2,
          BoneIndex,
          BoneWeight,
          UserAttribute0,
          UserAttribute1,
          UserAttribute2,
          UserAttribute3,
          UserAttribute4,
          UserAttribute5,
          UserAttribute6,
          UserAttribute7,
          UserAttribute8,
          UserAttribute9,
          UserAttribute10,
          UserAttribute11,
          Interleave,
          Quantity,
        }

        [System.Flags]
        public enum VertexAttributeFlags : uint
        {
          VertexParam = 1U,
          Interleave = 2U,
        }
      }

      public class InterleavedVertexStreamCtr : CMDL.SeparateDataShape.VertexAttributeCtr
      {
        public uint BufferObject;
        public uint LocationFlag;
        public uint VertexStreamLength;
        public uint VertexStreamOffset;
        public uint LocationAddress;
        public uint MemoryArea;
        public uint VertexDataEntrySize;
        public uint NrVertexStreams;
        public uint VertexStreamsOffsetArrayOffset;
        public uint[] VertexStreamsOffsetArray;
        public byte[] VertexStream;
        public CMDL.SeparateDataShape.InterleavedVertexStreamCtr.VertexStreamCtr[] VertexStreams;

        public InterleavedVertexStreamCtr()
        {
          this.Type = 1073741826U;
          this.Usage = CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.Interleave;
          this.Flags = CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeFlags.Interleave;
        }

        public InterleavedVertexStreamCtr(EndianBinaryReader er)
          : base(er)
        {
          this.BufferObject = er.ReadUInt32();
          this.LocationFlag = er.ReadUInt32();
          this.VertexStreamLength = er.ReadUInt32();
          this.VertexStreamOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.LocationAddress = er.ReadUInt32();
          this.MemoryArea = er.ReadUInt32();
          this.VertexDataEntrySize = er.ReadUInt32();
          this.NrVertexStreams = er.ReadUInt32();
          this.VertexStreamsOffsetArrayOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.VertexStreamsOffsetArrayOffset;
          this.VertexStreamsOffsetArray = new uint[(int) this.NrVertexStreams];
          for (int index = 0; (long) index < (long) this.NrVertexStreams; ++index)
            this.VertexStreamsOffsetArray[index] = (uint) er.BaseStream.Position + er.ReadUInt32();
          er.BaseStream.Position = (long) this.VertexStreamOffset;
          this.VertexStream = er.ReadBytes((int) this.VertexStreamLength);
          this.VertexStreams = new CMDL.SeparateDataShape.InterleavedVertexStreamCtr.VertexStreamCtr[(int) this.NrVertexStreams];
          for (int index = 0; (long) index < (long) this.NrVertexStreams; ++index)
          {
            er.BaseStream.Position = (long) this.VertexStreamsOffsetArray[index];
            this.VertexStreams[index] = new CMDL.SeparateDataShape.InterleavedVertexStreamCtr.VertexStreamCtr(er);
          }
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          er.Write(this.BufferObject);
          er.Write(this.LocationFlag);
          er.Write(this.VertexStreamLength);
          c.WriteDataReference(this.VertexStream, er);
          er.Write(this.LocationAddress);
          er.Write(this.MemoryArea);
          er.Write(this.VertexDataEntrySize);
          er.Write(this.NrVertexStreams);
          if ((int) this.NrVertexStreams != 0)
            er.Write(4U);
          else
            er.Write(0U);
          long position1 = er.BaseStream.Position;
          er.Write(new uint[(int) this.NrVertexStreams], 0, (int) this.NrVertexStreams);
          for (int index = 0; (long) index < (long) this.NrVertexStreams; ++index)
          {
            long position2 = er.BaseStream.Position;
            er.BaseStream.Position = position1 + (long) (4 * index);
            er.Write((uint) (position2 - (position1 + (long) (4 * index))));
            er.BaseStream.Position = position2;
            this.VertexStreams[index].Write(er, c);
          }
        }

        public override void GetVertexData(Polygon Destination, CMDL.SeparateDataShape.PrimitiveSet PrimitiveSet, CMDL Model)
        {
          Polygon polygon = Destination;
          int length1 = (int) (this.VertexStreamLength / this.VertexDataEntrySize);
          int num1 = 0;
          byte[] Data = this.VertexStream;
          foreach (CMDL.SeparateDataShape.VertexAttributeCtr vertexAttributeCtr in this.VertexStreams)
          {
            switch (vertexAttributeCtr.Usage)
            {
              case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.Position:
                polygon.Vertex = new Vector3[length1];
                break;
              case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.Normal:
                polygon.Normals = new Vector3[length1];
                break;
              case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.Color:
                polygon.Colors = new Color[length1];
                break;
              case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.TextureCoordinate0:
                polygon.TexCoords = new Vector2[length1];
                break;
              case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.TextureCoordinate1:
                polygon.TexCoords2 = new Vector2[length1];
                break;
              case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.TextureCoordinate2:
                polygon.TexCoords3 = new Vector2[length1];
                break;
            }
          }
          for (int index1 = 0; index1 < length1; ++index1)
          {
            byte[] numArray1 = new byte[0];
            foreach (CMDL.SeparateDataShape.InterleavedVertexStreamCtr.VertexStreamCtr vertexStreamCtr in this.VertexStreams)
            {
              float[] numArray2 = new float[(int) vertexStreamCtr.NrComponents];
              int num2 = 0;
              for (int index2 = 0; (long) index2 < (long) vertexStreamCtr.NrComponents; ++index2)
              {
                switch (vertexStreamCtr.FormatType)
                {
                  case CMDL.SeparateDataShape.DataType.GL_BYTE:
                    numArray2[index2] = (float) (sbyte) Data[num1 + (int) vertexStreamCtr.Offset + num2] * vertexStreamCtr.Scale;
                    ++num2;
                    break;
                  case CMDL.SeparateDataShape.DataType.GL_UNSIGNED_BYTE:
                    numArray2[index2] = (float) Data[num1 + (int) vertexStreamCtr.Offset + num2] * vertexStreamCtr.Scale;
                    ++num2;
                    break;
                  case CMDL.SeparateDataShape.DataType.GL_SHORT:
                    numArray2[index2] = (float) IOUtil.ReadS16LE(Data, num1 + (int) vertexStreamCtr.Offset + num2) * vertexStreamCtr.Scale;
                    num2 += 2;
                    break;
                  case CMDL.SeparateDataShape.DataType.GL_FLOAT:
                    numArray2[index2] = BitConverter.ToSingle(Data, num1 + (int) vertexStreamCtr.Offset + num2);
                    num2 += 4;
                    break;
                }
              }
              switch (vertexStreamCtr.Usage)
              {
                case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.Position:
                  polygon.Vertex[index1] = new Vector3(numArray2[0], numArray2[1], numArray2[2]);
                  if (PrimitiveSet.RelatedBones != null && PrimitiveSet.RelatedBones.Length == 1)
                  {
                    polygon.Vertex[index1] = polygon.Vertex[index1] * Model.Skeleton.GetMatrix((int) PrimitiveSet.RelatedBones[0]);
                    break;
                  }
                  break;
                case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.Normal:
                  polygon.Normals[index1] = new Vector3(numArray2[0], numArray2[1], numArray2[2]);
                  break;
                case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.Tangent:
                  Vector3 vector3 = new Vector3(numArray2[0], numArray2[1], numArray2[2]);
                  break;
                case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.Color:
                  if ((double) numArray2[0] < 0.0)
                    numArray2[0] = 0.0f;
                  if ((double) numArray2[0] > 1.0)
                    numArray2[0] = 1f;
                  if ((double) numArray2[1] < 0.0)
                    numArray2[1] = 0.0f;
                  if ((double) numArray2[1] > 1.0)
                    numArray2[1] = 1f;
                  if ((double) numArray2[2] < 0.0)
                    numArray2[2] = 0.0f;
                  if ((double) numArray2[2] > 1.0)
                    numArray2[2] = 1f;
                  if (numArray2.Length > 3 && (double) numArray2[3] < 0.0)
                    numArray2[3] = 0.0f;
                  if (numArray2.Length > 3 && (double) numArray2[3] > 1.0)
                    numArray2[3] = 1f;
                  polygon.Colors[index1] = vertexStreamCtr.FormatType == CMDL.SeparateDataShape.DataType.GL_BYTE || vertexStreamCtr.FormatType == CMDL.SeparateDataShape.DataType.GL_UNSIGNED_BYTE ? (numArray2.Length <= 3 ? Color.FromArgb((int) byte.MaxValue, (int) ((double) numArray2[0] * (double) byte.MaxValue), (int) ((double) numArray2[1] * (double) byte.MaxValue), (int) ((double) numArray2[2] * (double) byte.MaxValue)) : Color.FromArgb((int) ((double) numArray2[3] * (double) byte.MaxValue), (int) ((double) numArray2[0] * (double) byte.MaxValue), (int) ((double) numArray2[1] * (double) byte.MaxValue), (int) ((double) numArray2[2] * (double) byte.MaxValue))) : Color.White;
                  break;
                case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.TextureCoordinate0:
                  polygon.TexCoords[index1] = new Vector2(numArray2[0], numArray2[1]);
                  break;
                case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.TextureCoordinate1:
                  polygon.TexCoords2[index1] = new Vector2(numArray2[0], numArray2[1]);
                  break;
                case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.TextureCoordinate2:
                  polygon.TexCoords3[index1] = new Vector2(numArray2[0], numArray2[1]);
                  break;
                case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.BoneIndex:
                  if ((int) vertexStreamCtr.NrComponents == 1)
                  {
                    byte num3 = Data[(long) num1 + (long) vertexStreamCtr.Offset];
                    polygon.Vertex[index1] = polygon.Vertex[index1] * Model.Skeleton.GetMatrix((int) PrimitiveSet.RelatedBones[(int) num3]);
                    break;
                  }
                  numArray1 = new byte[(int) vertexStreamCtr.NrComponents];
                  for (int index2 = 0; (long) index2 < (long) vertexStreamCtr.NrComponents; ++index2)
                    numArray1[index2] = Data[(long) num1 + (long) vertexStreamCtr.Offset + (long) index2];
                  break;
                case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.BoneWeight:
                  int length2 = numArray1.Length;
                  break;
              }
            }
            num1 += (int) this.VertexDataEntrySize;
          }
        }

        public class VertexStreamCtr : CMDL.SeparateDataShape.VertexAttributeCtr
        {
          public uint BufferObject;
          public uint LocationFlag;
          public uint VertexStreamLength;
          public uint VertexStreamOffset;
          public uint LocationAddress;
          public uint MemoryArea;
          public CMDL.SeparateDataShape.DataType FormatType;
          public uint NrComponents;
          public float Scale;
          public uint Offset;

          public VertexStreamCtr(CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage Usage, CMDL.SeparateDataShape.DataType FormatType, int NrComponents, int Offset, float Scale = 1f)
          {
            this.Type = 1073741825U;
            this.Flags = (CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeFlags) 0;
            this.Usage = Usage;
            this.FormatType = FormatType;
            this.NrComponents = (uint) NrComponents;
            this.Scale = Scale;
            this.Offset = (uint) Offset;
          }

          public VertexStreamCtr(EndianBinaryReader er)
            : base(er)
          {
            this.BufferObject = er.ReadUInt32();
            this.LocationFlag = er.ReadUInt32();
            this.VertexStreamLength = er.ReadUInt32();
            this.VertexStreamOffset = er.ReadUInt32();
            this.LocationAddress = er.ReadUInt32();
            this.MemoryArea = er.ReadUInt32();
            this.FormatType = (CMDL.SeparateDataShape.DataType) er.ReadUInt32();
            this.NrComponents = er.ReadUInt32();
            this.Scale = er.ReadSingle();
            this.Offset = er.ReadUInt32();
          }

          public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
          {
            base.Write(er, c);
            er.Write(this.BufferObject);
            er.Write(this.LocationFlag);
            er.Write(this.VertexStreamLength);
            er.Write(0U);
            er.Write(this.LocationAddress);
            er.Write(this.MemoryArea);
            er.Write((uint) this.FormatType);
            er.Write(this.NrComponents);
            er.Write(this.Scale);
            er.Write(this.Offset);
          }
        }
      }

      public class VertexParamAttributeCtr : CMDL.SeparateDataShape.VertexAttributeCtr
      {
        public CMDL.SeparateDataShape.DataType FormatType;
        public uint NrComponents;
        public float Scale;
        public uint NrAttributes;
        public uint AttributeArrayOffset;
        public float[] Attributes;

        public VertexParamAttributeCtr(CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage Usage, params float[] Attributes)
        {
          this.Type = (uint)0xFFFFFFFF;
          this.Flags = CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeFlags.VertexParam;
          this.Usage = Usage;
          this.FormatType = CMDL.SeparateDataShape.DataType.GL_FLOAT;
          this.Scale = 1f;
          this.NrAttributes = (uint) Attributes.Length;
          this.Attributes = Attributes;
        }

        public VertexParamAttributeCtr(EndianBinaryReader er)
          : base(er)
        {
          this.FormatType = (CMDL.SeparateDataShape.DataType) er.ReadUInt32();
          this.NrComponents = er.ReadUInt32();
          this.Scale = er.ReadSingle();
          this.NrAttributes = er.ReadUInt32();
          this.AttributeArrayOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.AttributeArrayOffset;
          this.Attributes = er.ReadSingles((int) this.NrAttributes);
          er.BaseStream.Position = position;
        }

        public override void Write(EndianBinaryWriter er, CGFXWriterContext c)
        {
          base.Write(er, c);
          er.Write((uint) this.FormatType);
          er.Write(this.NrComponents);
          er.Write(this.Scale);
          er.Write(this.NrAttributes);
          if ((int) this.NrAttributes != 0)
            er.Write(4U);
          else
            er.Write(0U);
          er.Write(this.Attributes, 0, (int) this.NrAttributes);
        }

        public override void GetVertexData(Polygon Destination, CMDL.SeparateDataShape.PrimitiveSet PrimitiveSet, CMDL Model)
        {
          int length = Destination.Vertex.Length;
          switch (this.Usage)
          {
            case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.Normal:
              Destination.Normals = new Vector3[length];
              for (int index = 0; index < length; ++index)
                Destination.Normals[index] = new Vector3(this.Attributes[0], this.Attributes[1], this.Attributes[2]);
              break;
            case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.Color:
              Destination.Colors = new Color[length];
              for (int index = 0; index < length; ++index)
                Destination.Colors[index] = this.NrAttributes <= 3U ? Color.FromArgb((int) byte.MaxValue, (int) ((double) this.Attributes[0] * (double) byte.MaxValue), (int) ((double) this.Attributes[1] * (double) byte.MaxValue), (int) ((double) this.Attributes[2] * (double) byte.MaxValue)) : Color.FromArgb((int) ((double) this.Attributes[3] * (double) byte.MaxValue), (int) ((double) this.Attributes[0] * (double) byte.MaxValue), (int) ((double) this.Attributes[1] * (double) byte.MaxValue), (int) ((double) this.Attributes[2] * (double) byte.MaxValue));
              break;
            case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.TextureCoordinate0:
              Destination.TexCoords = new Vector2[length];
              for (int index = 0; index < length; ++index)
                Destination.TexCoords[index] = new Vector2(this.Attributes[0], this.Attributes[1]);
              break;
            case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.TextureCoordinate1:
              Destination.TexCoords2 = new Vector2[length];
              for (int index = 0; index < length; ++index)
                Destination.TexCoords2[index] = new Vector2(this.Attributes[0], this.Attributes[1]);
              break;
            case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.TextureCoordinate2:
              Destination.TexCoords3 = new Vector2[length];
              for (int index = 0; index < length; ++index)
                Destination.TexCoords3[index] = new Vector2(this.Attributes[0], this.Attributes[1]);
              break;
            case CMDL.SeparateDataShape.VertexAttributeCtr.VertexAttributeUsage.BoneIndex:
              Matrix34 matrix = Model.Skeleton.GetMatrix((int) this.Attributes[0]);
              for (int index = 0; index < length; ++index)
                Destination.Vertex[index] *= matrix;
              break;
          }
        }
      }

      public class BlendShapeCtr
      {
        public uint Unknown1;
        public uint Unknown2;
        public uint Unknown3;
        public uint Unknown4;
        public uint Unknown5;

        public BlendShapeCtr(EndianBinaryReader er)
        {
          this.Unknown1 = er.ReadUInt32();
          this.Unknown2 = er.ReadUInt32();
          this.Unknown3 = er.ReadUInt32();
          this.Unknown4 = er.ReadUInt32();
          this.Unknown5 = er.ReadUInt32();
        }

        public void Write(EndianBinaryWriter er)
        {
          er.Write(this.Unknown1);
          er.Write(this.Unknown2);
          er.Write(this.Unknown3);
          er.Write(this.Unknown4);
          er.Write(this.Unknown5);
        }
      }
    }

    public class SkeletonCtr
    {
      public uint Type;
      public string Signature;
      public uint Revision;
      public uint NameOffset;
      public uint Unknown2;
      public uint Unknown3;
      public uint NrBones;
      public uint BoneDictionaryOffset;
      public uint RootBoneOffset;
      public CMDL.SkeletonCtr.SkeletonScalingRule ScalingRule;
      public CMDL.SkeletonCtr.SkeletonFlags Flags;
      public string Name;
      public DICT BoneDictionary;
      public CMDL.SkeletonCtr.Bone[] Bones;

      public SkeletonCtr(EndianBinaryReader er)
      {
        this.Type = er.ReadUInt32();
        this.Signature = er.ReadString(Encoding.ASCII, 4);
        if (this.Signature != "SOBJ")
          throw new SignatureNotCorrectException(this.Signature, "SOBJ", er.BaseStream.Position);
        this.Revision = er.ReadUInt32();
        this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.Unknown2 = er.ReadUInt32();
        this.Unknown3 = er.ReadUInt32();
        this.NrBones = er.ReadUInt32();
        this.BoneDictionaryOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.RootBoneOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
        this.ScalingRule = (CMDL.SkeletonCtr.SkeletonScalingRule) er.ReadUInt32();
        this.Flags = (CMDL.SkeletonCtr.SkeletonFlags) er.ReadUInt32();
        long position = er.BaseStream.Position;
        er.BaseStream.Position = (long) this.NameOffset;
        this.Name = er.ReadStringNT(Encoding.ASCII);
        er.BaseStream.Position = (long) this.BoneDictionaryOffset;
        this.BoneDictionary = new DICT(er);
        this.Bones = new CMDL.SkeletonCtr.Bone[(int) this.NrBones];
        for (int index = 0; (long) index < (long) this.NrBones; ++index)
        {
          er.BaseStream.Position = (long) this.BoneDictionary[index].DataOffset;
          this.Bones[index] = new CMDL.SkeletonCtr.Bone(er);
        }
        er.BaseStream.Position = position;
      }

      public Matrix34 GetMatrix(int JointID)
      {
        int index1 = -1;
        for (int index2 = 0; (long) index2 < (long) this.NrBones; ++index2)
        {
          if ((long) this.Bones[index2].JointID == (long) JointID)
          {
            index1 = index2;
            break;
          }
        }
        if (index1 == -1)
          return Matrix34.Identity;
        Matrix34 matrix1 = this.Bones[index1].GetMatrix();
        Matrix34 matrix2 = this.GetMatrix(this.Bones[index1].ParentID);
        int num = (int) (this.Bones[index1].Flags & CMDL.SkeletonCtr.Bone.BoneFlags.HasSkinningMatrix);
        Matrix34 matrix34 = matrix2;
        return matrix1 * matrix34;
      }

      public override string ToString()
      {
        return this.Name;
      }

      public enum SkeletonScalingRule : uint
      {
        Standard,
        Maya,
        Softimage,
      }

      [System.Flags]
      public enum SkeletonFlags : uint
      {
        IsModelCoordinate = 1U,
        IsTranslateAnimationEnabled = 2U,
      }

      public class Bone
      {
        public uint NameOffset;
        public CMDL.SkeletonCtr.Bone.BoneFlags Flags;
        public uint JointID;
        public int ParentID;
        public uint ParentOffset;
        public uint ChildOffset;
        public uint PreviousSiblingOffset;
        public uint NextSiblingOffset;
        public Vector3 Scale;
        public Vector3 Rotation;
        public Vector3 Translation;
        public float[] LocalMatrix;
        public float[] WorldMatrix;
        public float[] InverseBaseMatrix;
        public CMDL.SkeletonCtr.Bone.BBMode BillboardMode;
        public uint Unknown6;
        public uint Unknown7;
        public string Name;

        public Bone(EndianBinaryReader er)
        {
          this.NameOffset = (uint) er.BaseStream.Position + er.ReadUInt32();
          this.Flags = (CMDL.SkeletonCtr.Bone.BoneFlags) er.ReadUInt32();
          this.JointID = er.ReadUInt32();
          this.ParentID = er.ReadInt32();
          this.ParentOffset = this.ParentID != -1 ? (uint) ((ulong) er.BaseStream.Position + (ulong) er.ReadInt32()) : er.ReadUInt32();
          this.ChildOffset = er.ReadUInt32();
          if ((int) this.ChildOffset != 0)
            this.ChildOffset = this.ChildOffset + (uint) ((ulong) er.BaseStream.Position - 4UL);
          this.PreviousSiblingOffset = er.ReadUInt32();
          if ((int) this.PreviousSiblingOffset != 0)
            this.PreviousSiblingOffset = this.PreviousSiblingOffset + (uint) ((ulong) er.BaseStream.Position - 4UL);
          this.NextSiblingOffset = er.ReadUInt32();
          if ((int) this.NextSiblingOffset != 0)
            this.NextSiblingOffset = this.NextSiblingOffset + (uint) ((ulong) er.BaseStream.Position - 4UL);
          this.Scale = new Vector3(er.ReadSingle(), er.ReadSingle(), er.ReadSingle());
          this.Rotation = new Vector3(er.ReadSingle(), er.ReadSingle(), er.ReadSingle());
          this.Translation = new Vector3(er.ReadSingle(), er.ReadSingle(), er.ReadSingle());
          this.LocalMatrix = er.ReadSingles(12);
          this.WorldMatrix = er.ReadSingles(12);
          this.InverseBaseMatrix = er.ReadSingles(12);
          this.BillboardMode = (CMDL.SkeletonCtr.Bone.BBMode) er.ReadUInt32();
          this.Unknown6 = er.ReadUInt32();
          this.Unknown7 = er.ReadUInt32();
          long position = er.BaseStream.Position;
          er.BaseStream.Position = (long) this.NameOffset;
          this.Name = er.ReadStringNT(Encoding.ASCII);
          er.BaseStream.Position = position;
        }

        public Matrix34 GetMatrix()
        {
          Matrix34 matrix34 = Matrix34.Identity;
          float num1 = (float) Math.Sin((double) this.Rotation.X);
          float num2 = (float) Math.Cos((double) this.Rotation.X);
          float num3 = (float) Math.Sin((double) this.Rotation.Y);
          float num4 = (float) Math.Cos((double) this.Rotation.Y);
          float num5 = (float) Math.Sin((double) this.Rotation.Z);
          float num6 = (float) Math.Cos((double) this.Rotation.Z);
          matrix34[2, 0] = -num3;
          matrix34[0, 0] = num6 * num4;
          matrix34[1, 0] = num5 * num4;
          matrix34[2, 1] = num4 * num1;
          matrix34[2, 2] = num4 * num2;
          matrix34[0, 1] = (float) ((double) num1 * (double) num6 * (double) num3 - (double) num2 * (double) num5);
          matrix34[1, 2] = (float) ((double) num2 * (double) num5 * (double) num3 - (double) num1 * (double) num6);
          matrix34[0, 2] = (float) ((double) num2 * (double) num6 * (double) num3 + (double) num1 * (double) num5);
          matrix34[1, 1] = (float) ((double) num1 * (double) num5 * (double) num3 + (double) num2 * (double) num6);
          matrix34.Row0 *= new Vector4(this.Scale, 1f);
          matrix34.Row1 *= new Vector4(this.Scale, 1f);
          matrix34.Row2 *= new Vector4(this.Scale, 1f);
          matrix34[0, 3] = this.Translation.X;
          matrix34[1, 3] = this.Translation.Y;
          matrix34[2, 3] = this.Translation.Z;
          return matrix34;
        }

        public override string ToString()
        {
          return this.Name;
        }

        [System.Flags]
        public enum BoneFlags : uint
        {
          IsIdentity = 1U,
          IsTranslateZero = 2U,
          IsRotateZero = 4U,
          IsScaleOne = 8U,
          IsUniformScale = 16U,
          IsSegmentScaleCompensate = 32U,
          IsNeedRendering = 64U,
          IsLocalMatrixCalculate = 128U,
          IsWorldMatrixCalculate = 256U,
          HasSkinningMatrix = 512U,
        }

        public enum BBMode : uint
        {
          Off,
          World,
          WorldViewpoint,
          Screen,
          ScreenViewpoint,
          YAxial,
          YAxialViewpoint,
        }
      }
    }
  }
}
