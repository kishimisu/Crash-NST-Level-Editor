namespace Alchemy
{
    // VSC object extracted from: Enemies_LoopingShadowVFX_Controller.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class Enemies_LoopingShadowVFX_ControllerData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Bool;
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(56)] public igHandleMetaField _Bolt_Point = new();
    }
}
