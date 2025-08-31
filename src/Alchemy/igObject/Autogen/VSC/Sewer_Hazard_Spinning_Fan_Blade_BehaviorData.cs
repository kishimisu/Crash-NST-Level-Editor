namespace Alchemy
{
    // VSC object extracted from: Sewer_Hazard_Spinning_Fan_Blade_Behavior.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class Sewer_Hazard_Spinning_Fan_Blade_BehaviorData : CVscComponentData
    {
        public enum ENewEnum9_id_hdw1dx3p
        {
            NoFade = 0,
            Small = 1,
            Large = 2,
            Medium = 3,
        }

        [FieldAttr(40)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(48)] public igHandleMetaField _Sound = new();
        [FieldAttr(56)] public igHandleMetaField _AkuAkuInvinciblityActive_0x38 = new();
        [FieldAttr(64)] public igHandleMetaField _AkuAkuInvinciblityActive_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Vfx_Effect_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Vfx_Effect_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(96)] public ENewEnum9_id_hdw1dx3p _NewEnum9_id_hdw1dx3p;
        [FieldAttr(104)] public igHandleMetaField _Vfx_Effect_0x68 = new();
        [FieldAttr(112)] public igHandleMetaField _Vfx_Effect_0x70 = new();
        [FieldAttr(120)] public igHandleMetaField _Vfx_Effect_0x78 = new();
    }
}
