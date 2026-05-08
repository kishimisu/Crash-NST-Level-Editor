namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class AirJet_VFX_ModCustomizationData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _VFX_Pure_Bone_R_Wing = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _VFX_Pure_Bone_L_Wing = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _VFX_Pure_Bone_SecondaryMod = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _EBOLT_ORIGIN = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Pri_Detach = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _VFX_Sec_Attach = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _VFX_Sec_Detatch = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Pri_Attach = new();
    }
}
