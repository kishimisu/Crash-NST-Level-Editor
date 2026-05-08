namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class Sewer_Hazard_Spinning_Fan_Blade_BehaviorData : CVscComponentData
    {
        public enum ENewEnum9_id_hdw1dx3p
        {
            NoFade = 0,
            Small = 1,
            Large = 2,
            Medium = 3,
        }

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _AkuAkuInvinciblityActive_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _AkuAkuInvinciblityActive_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_Effect_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Vfx_Effect_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 96, ctr: 88)] public ENewEnum9_id_hdw1dx3p _NewEnum9_id_hdw1dx3p;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Vfx_Effect_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Vfx_Effect_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Vfx_Effect_0x78 = new();
    }
}
