namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemies_LoopingShadowVFX_ControllerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Bool;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Bolt_Point = new();
    }
}
