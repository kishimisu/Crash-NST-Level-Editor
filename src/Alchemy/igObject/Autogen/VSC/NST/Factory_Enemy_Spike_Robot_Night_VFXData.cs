namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class Factory_Enemy_Spike_Robot_Night_VFXData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Bool_0x28;
        [FieldAttr(nst: 41, ctr: 33)] public bool _Bool_0x29;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Bolt_Point = new();
    }
}
