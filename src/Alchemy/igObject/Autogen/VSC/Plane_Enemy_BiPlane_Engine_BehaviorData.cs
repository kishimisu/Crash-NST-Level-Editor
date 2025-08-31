namespace Alchemy
{
    // VSC object extracted from: Plane_Enemy_BiPlane_Engine_Behavior.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class Plane_Enemy_BiPlane_Engine_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public int _Int_0x28;
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect_0x30 = new();
        [FieldAttr(56)] public int _Int_0x38;
        [FieldAttr(64)] public igHandleMetaField _Vfx_Effect_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Bolt_Point_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Bolt_Point_0x50 = new();
    }
}
