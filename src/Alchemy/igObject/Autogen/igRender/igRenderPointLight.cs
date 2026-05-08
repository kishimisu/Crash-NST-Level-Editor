namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 80, align: 16)]
    public class igRenderPointLight : igRenderLight
    {
        [FieldAttr(nst: 80, ctr: 68)] public igVec2fMetaField _attenuation = new();
        [FieldAttr(nst: 88, ctr: 76)] public bool _distanceCull = true;
        [FieldAttr(ctr: 77)] public u8 _forceViewportDisableFlags;
    }
}
