using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(224)]
    public class hkxMaterial : hkxAttributeHolder
    {
        public override uint Hash => 0x785ec362;

        [FieldAttr(32)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(40)] public hkMemory<hkxMaterialTextureStage> _stages; // TYPE_ARRAY, ctype: hkxMaterialTextureStage, subtype: TYPE_STRUCT
        [FieldAttr(64)] public Vector4 _diffuseColor; // TYPE_VECTOR4
        [FieldAttr(80)] public Vector4 _ambientColor; // TYPE_VECTOR4
        [FieldAttr(96)] public Vector4 _specularColor; // TYPE_VECTOR4
        [FieldAttr(112)] public Vector4 _emissiveColor; // TYPE_VECTOR4
        [FieldAttr(128)] public hkMemoryPtr<hkxMaterial> _subMaterials; // TYPE_ARRAY, ctype: hkxMaterial, subtype: TYPE_POINTER
        [FieldAttr(144)] public hkReferencedObject _extraData; // TYPE_POINTER, ctype: hkReferencedObject, subtype: TYPE_STRUCT
        [FieldAttr(152)] public float _uvMapScale_0; // TYPE_REAL, arrsize: 2
        [FieldAttr(156)] public float _uvMapScale_1;
        [FieldAttr(160)] public float _uvMapOffset_0; // TYPE_REAL, arrsize: 2
        [FieldAttr(164)] public float _uvMapOffset_1;
        [FieldAttr(168)] public float _uvMapRotation; // TYPE_REAL
        [FieldAttr(172)] public EUVMappingAlgorithm _uvMapAlgorithm; // TYPE_ENUM, etype: UVMappingAlgorithm, subtype: TYPE_UINT32
        [FieldAttr(176)] public float _specularMultiplier; // TYPE_REAL
        [FieldAttr(180)] public float _specularExponent; // TYPE_REAL
        [FieldAttr(184)] public ETransparency _transparency; // TYPE_ENUM, etype: Transparency, subtype: TYPE_UINT8
        [FieldAttr(192)] public u64 _userData; // TYPE_ULONG
        [FieldAttr(200)] public hkMemory<hkxMaterialProperty> _properties; // TYPE_ARRAY, ctype: hkxMaterialProperty, subtype: TYPE_STRUCT
    }
}