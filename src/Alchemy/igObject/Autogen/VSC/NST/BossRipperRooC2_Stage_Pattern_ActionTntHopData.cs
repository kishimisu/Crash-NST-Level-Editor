namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
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

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x34;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
        [FieldAttr(nst: 76, ctr: 68)] public bool _Bool;
        [FieldAttr(nst: 80, ctr: 72)] public ENewEnum14_id_r08p8mb8 _NewEnum14_id_r08p8mb8;
        [FieldAttr(nst: 84, ctr: 76)] public ENewEnum15_id_i77zfglu _NewEnum15_id_i77zfglu;
    }
}
