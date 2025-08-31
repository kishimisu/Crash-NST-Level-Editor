namespace Alchemy
{
    // VSC object extracted from: BossPapuPapu_AiHandler_c.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class BossPapuPapu_AiHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public float _AiUpdateDeltaTime;
        [FieldAttr(44)] public float _AttackSpinStartDelay;
        [FieldAttr(48)] public float _AttackSpinSpeedMultiplier;
        [FieldAttr(52)] public float _ResumeBossFightDelay;
        [FieldAttr(56)] public float _IntroMoveSpeedMultiplier;
        [FieldAttr(60)] public int _AttackSpinPlayerLapCountStart;
        [FieldAttr(64)] public igHandleMetaField _Float_List = new();
    }
}
