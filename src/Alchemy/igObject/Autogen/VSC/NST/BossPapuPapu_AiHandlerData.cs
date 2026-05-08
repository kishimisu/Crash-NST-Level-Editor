namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class BossPapuPapu_AiHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _AiUpdateDeltaTime;
        [FieldAttr(nst: 44, ctr: 36)] public float _AttackSpinStartDelay;
        [FieldAttr(nst: 48, ctr: 40)] public float _AttackSpinSpeedMultiplier;
        [FieldAttr(nst: 52, ctr: 44)] public float _ResumeBossFightDelay;
        [FieldAttr(nst: 56, ctr: 48)] public float _IntroMoveSpeedMultiplier;
        [FieldAttr(nst: 60, ctr: 52)] public int _AttackSpinPlayerLapCountStart;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Float_List = new();
    }
}
