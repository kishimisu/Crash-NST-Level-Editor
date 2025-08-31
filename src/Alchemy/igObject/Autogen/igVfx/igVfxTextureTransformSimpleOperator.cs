namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxTextureTransformSimpleOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _diffuse = true;
            [FieldAttr(1, size: 1)] public bool _mask;
            [FieldAttr(2, size: 3)] public igVfxTextureTransform.ERotate _uvRotation;
            [FieldAttr(5, size: 2)] public igVfxTextureTransform.EMirror _uMirror;
            [FieldAttr(7, size: 2)] public igVfxTextureTransform.EMirror _vMirror;
        }

        [FieldAttr(24)] public Flags _flags = new();
    }
}
