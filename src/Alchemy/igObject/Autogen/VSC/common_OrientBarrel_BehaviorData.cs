namespace Alchemy
{
    // VSC object extracted from: common_OrientBarrel_Behavior.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_OrientBarrel_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public float _Float_0x28;
        [FieldAttr(44)] public float _Float_0x2c;
        [FieldAttr(48)] public string? _Death_State = null;
        [FieldAttr(56)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(64)] public igHandleMetaField _Sound = new();
        [FieldAttr(72)] public float _Float_0x48;
    }
}
