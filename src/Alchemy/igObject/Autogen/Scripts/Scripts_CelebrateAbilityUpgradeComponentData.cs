namespace Alchemy
{
    [ObjectAttr(96, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_CelebrateAbilityUpgradeComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_CelebrateAbilityUpgradeComponent_
    {
        [FieldAttr(40)] public float Delay = 0.5f;
        [FieldAttr(48)] public string? BehaviorEvent = "";
        [FieldAttr(56)] public string? CelebrationVO = "VO1_Champ_Banter_Upgrade";
        [FieldAttr(64)] public CVfxEffectDotNetHandle? Vfx;
        [FieldAttr(72)] public float ScaleBobs = 2.25f;
        [FieldAttr(76)] public float ScaleAmount = 1.5f;
        [FieldAttr(80)] public float ScaleDuration = 0.667f;
        [FieldAttr(84)] public float CelebrationDuration = 3.75f;
        [FieldAttr(88)] public float BroadcastRadius = 1000.0f;
    }
}
