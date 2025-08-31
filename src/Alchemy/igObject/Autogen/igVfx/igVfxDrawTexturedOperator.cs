namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igVfxDrawTexturedOperator : igVfxDrawOperator
    {
        [ObjectAttr(4)]
        public class TexturedFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _lockMaskUVs;
        }

        [FieldAttr(32)] public TexturedFlags _texturedFlags = new();
        [FieldAttr(40)] public igHandleMetaField _material = new();
        [FieldAttr(48)] public igVfxAnimatedFrame? _animatedFrame;
        [FieldAttr(56)] public igVfxAnimatedFrame? _animatedFrameMask;
        [FieldAttr(64)] public u32 /* igStructMetaField */ _animatedFrameInstance;
        [FieldAttr(68)] public u32 /* igStructMetaField */ _animatedFrameMaskInstance;
    }
}
