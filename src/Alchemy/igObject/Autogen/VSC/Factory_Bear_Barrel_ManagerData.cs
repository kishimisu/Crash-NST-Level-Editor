namespace Alchemy
{
    // VSC object extracted from: Factory_Bear_Barrel_Manager_c.igz

    [ObjectAttr(184, metaType: typeof(CVscComponentData))]
    public class Factory_Bear_Barrel_ManagerData : CVscComponentData
    {
        public enum EBarrelSupplyBehavior
        {
            LeftSideOnly = 0,
            RightSideOnly = 1,
            AlternateLeftAndRight = 2,
            AlternateRightAndLeft = 3,
        }

        [FieldAttr(40)] public igHandleMetaField _BoltPointVariable_id_aq7ccbz6_variable = new();
        [FieldAttr(48)] public igHandleMetaField _LeftLoadSpawner = new();
        [FieldAttr(56)] public igHandleMetaField _RightLoadSpawner = new();
        [FieldAttr(64)] public igHandleMetaField _BarrelList = new();
        [FieldAttr(72)] public EBarrelSupplyBehavior _BarrelSupplyBehavior;
        [FieldAttr(80)] public igHandleMetaField _SplineAttachBehaviorVariable_id_quzbqi2g_variable = new();
        [FieldAttr(88)] public igHandleMetaField _SplineRotationMoverVariable_id_iczamq7i_variable = new();
        [FieldAttr(96)] public igHandleMetaField _SplineVelocityMoverVariable_id_fk4l1hdk_variable = new();
        [FieldAttr(104)] public string? _LeftLift = null;
        [FieldAttr(112)] public string? _Reset = null;
        [FieldAttr(120)] public string? _RightGrab = null;
        [FieldAttr(128)] public string? _LeftGrab = null;
        [FieldAttr(136)] public string? _RightLift = null;
        [FieldAttr(144)] public float _Float_0x90;
        [FieldAttr(148)] public float _Float_0x94;
        [FieldAttr(152)] public float _Float_0x98;
        [FieldAttr(160)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(168)] public bool _Bool_0xa8;
        [FieldAttr(172)] public float _Float_0xac;
        [FieldAttr(176)] public bool _Bool_0xb0;
        [FieldAttr(177)] public bool _Bool_0xb1;
    }
}
