namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class igGraphicsMaterial : igMaterial
    {
        [ObjectAttr(4)]
        public class MaterialBitField : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public u8 _sortKey = 8;
            [FieldAttr(4, size: 2)] public EigDrawType _drawType;
            [FieldAttr(6, size: 2)] public EigGraphicsMaterialAnimationTimeSource _timeSource;
        }

        [FieldAttr(24)] public u64 _globalTechniqueMask;
        [FieldAttr(32)] public MaterialBitField _materialBitField = new();
        [FieldAttr(36)] public float _sortDepthOffset;
        [FieldAttr(40)] public igHandleMetaField _effectHandle = new();
        [FieldAttr(48)] public igMemoryCommandStream? _commonState;
        [FieldAttr(56)] public igVectorMetaField<igMemoryCommandStream> _techniques = new();
        [FieldAttr(80)] public igGraphicsMaterialAnimationList? _animations;
        [FieldAttr(88)] public igGraphicsObjectSet? _graphicsObjects;
    }
}
