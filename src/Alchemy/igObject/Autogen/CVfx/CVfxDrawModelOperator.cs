namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CVfxDrawModelOperator : igVfxDrawOperator
    {
        public enum EDrawMode : uint
        {
            kDrawModeAuto = 0,
            kDrawModeHudPortrait1 = 1,
            kDrawModeHudPortrait2 = 2,
        }

        [ObjectAttr(4)]
        public class ModelFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isSkinned;
            [FieldAttr(1, size: 1)] public bool _fitToScale;
            [FieldAttr(2, size: 1)] public bool _keepAspectRatio = false;
            [FieldAttr(3, size: 1)] public bool _useBoltAnimation;
            [FieldAttr(4, size: 1)] public bool _useAlphaForFade = false;
            [FieldAttr(5, size: 2)] public CVfxDrawModelOperator.EDrawMode _drawMode;
        }

        [FieldAttr(32)] public string? _modelName = null;
        [FieldAttr(40)] public string? _animationName = null;
        [FieldAttr(48)] public string? _animationSourceModelName = null;
        [FieldAttr(56)] public ModelFlags _modelFlags = new();
        [FieldAttr(64)] public CFxMaterialRedirectTable? _materialOverrides;
        [FieldAttr(72)] public igHandleMetaField _modelCacheHandle = new();
        [FieldAttr(80)] public u32 /* igStructMetaField */ _instance;
    }
}
