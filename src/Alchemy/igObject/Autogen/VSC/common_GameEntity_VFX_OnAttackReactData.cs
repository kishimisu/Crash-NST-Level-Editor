namespace Alchemy
{
    // VSC object extracted from: common_GameEntity_VFX_OnAttackReact.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_GameEntity_VFX_OnAttackReactData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity = new();
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(56)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(64)] public bool _Bool;
        [FieldAttr(68)] public float _Float;
        [FieldAttr(72)] public igHandleMetaField _Sound = new();
    }
}
