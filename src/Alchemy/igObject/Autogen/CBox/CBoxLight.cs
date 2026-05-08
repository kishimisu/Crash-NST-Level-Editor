namespace Alchemy
{
    [ObjectAttr(nst: 464, ctr: 448, align: 16)]
    public class CBoxLight : igRenderLight
    {
        [FieldAttr(nst: 80, ctr: 68)] public igVec3fMetaField _rotation = new();
        [FieldAttr(nst: 92, ctr: 80)] public igVec3fMetaField _min = new();
        [FieldAttr(nst: 104, ctr: 92)] public igVec3fMetaField _max = new();
        [FieldAttr(nst: 116, ctr: 104)] public float _nearAttenuation;
        [FieldAttr(nst: 120, ctr: 108)] public float _attenuation;
        [FieldAttr(nst: 124, ctr: 112)] public float _xFalloff;
        [FieldAttr(nst: 128, ctr: 116)] public float _yFalloff;
        [FieldAttr(nst: 132, ctr: 120)] public float _wrap;
        [FieldAttr(nst: 136, ctr: 128)] public string? _cookieTextureName = "loosetextures";
        [FieldAttr(nst: 144, ctr: 136)] public bool _overrideUVs;
        [FieldAttr(nst: 148, ctr: 140)] public igVec2fMetaField[] _UVs = new igVec2fMetaField[4];
        [FieldAttr(nst: 184, ctr: 176)] public igVfxAnimatedFrame? _uvAnimation;
        [FieldAttr(nst: 192, ctr: 184)] public bool _distanceCull = true;
        [FieldAttr(ctr: 185)] public u8 _forceViewportDisableFlags;
        [FieldAttr(nst: 196, ctr: 188)] public uint _uvAnimationInstance = new();
        [FieldAttr(nst: 204, ctr: 196)] public igRandomMetaField _rng = new();
        [FieldAttr(nst: 224, ctr: 208)] public igMatrix44fMetaField _worldToLocalMatrix = new();
        [FieldAttr(nst: 288, ctr: 272)] public igVec4fMetaField _direction = new();
        [FieldAttr(nst: 304, ctr: 288)] public igVec4fMetaField[] _corners = new igVec4fMetaField[8];
        [FieldAttr(nst: 432, ctr: 416)] public igObjectDirectory? _imageDirectory;
        [FieldAttr(nst: 440, ctr: 424)] public igHandleMetaField _imageHandle = new();
        [FieldAttr(nst: 448, ctr: 432)] public CBoxLightPeachesCallback? _peachesCallback;
    }
}
