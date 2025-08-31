namespace Alchemy
{
    // VSC object extracted from: BossRipperRooC2_Stage_Pattern_ActionJump.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class BossRipperRooC2_Stage_Pattern_ActionTntHopData : CVscComponentData
    {
        public enum ENewEnum14_id_r08p8mb8
        {
            TurnToDestination = 0,
            TurnToPlayer = 1,
            MadTwirlToPlayer = 2,
        }

        public enum ENewEnum15_id_i77zfglu
        {
            CleverJumpVariant1 = 0,
            CleverJumpVariant2 = 1,
            CleverJumpVariantLeanLeft = 2,
            CleverJumpVariantLeanRight = 3,
        }

        [FieldAttr(40)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(48)] public float _Float_0x30;
        [FieldAttr(52)] public float _Float_0x34;
        [FieldAttr(56)] public float _Float_0x38;
        [FieldAttr(64)] public igHandleMetaField _Entity = new();
        [FieldAttr(72)] public float _Float_0x48;
        [FieldAttr(76)] public bool _Bool;
        [FieldAttr(80)] public ENewEnum14_id_r08p8mb8 _NewEnum14_id_r08p8mb8;
        [FieldAttr(84)] public ENewEnum15_id_i77zfglu _NewEnum15_id_i77zfglu;
    }
}
