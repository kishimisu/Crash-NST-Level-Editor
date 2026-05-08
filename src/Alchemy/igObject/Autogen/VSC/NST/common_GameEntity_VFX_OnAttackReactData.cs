namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_GameEntity_VFX_OnAttackReactData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Sound = new();
    }
}
