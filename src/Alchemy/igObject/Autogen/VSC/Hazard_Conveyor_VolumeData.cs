namespace Alchemy
{
    // VSC object extracted from: Hazard_Conveyor_Volume.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class Hazard_Conveyor_VolumeData : CVscComponentData
    {
        [FieldAttr(40)] public float _Float_0x28;
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(56)] public igHandleMetaField _Bolt_Point_0x38 = new();
        [FieldAttr(64)] public igHandleMetaField _Bolt_Point_0x40 = new();
        [FieldAttr(72)] public float _Float_0x48;
    }
}
