namespace Alchemy
{
    [ObjectAttr(168, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_VortexComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_VortexComponent_
    {
        [FieldAttr(40)] public bool StartOn;
        [FieldAttr(41)] public bool Repel;
        [FieldAttr(48)] public CTriggerVolumeSphereComponentData? VortexData;
        [FieldAttr(56)] public float VortexLife = -1.0f;
        [FieldAttr(60)] public bool RemoveVortexEntOnLifeEnd;
        [FieldAttr(64)] public float StartDelay;
        [FieldAttr(68)] public float VortexIntensityMax = 9.0f;
        [FieldAttr(72)] public float VortexIntensityMin = 4.0f;
        [FieldAttr(76)] public float VortexSuctionScale = 0.5f;
        [FieldAttr(80)] public bool KillVelocityOnRemove = true;
        [FieldAttr(88)] public CEntityMessage? StartMessageOverride;
        [FieldAttr(96)] public CEntityMessage? EndMessageOverride;
        [FieldAttr(104)] public bool SizeChangeOverTime;
        [FieldAttr(112)] public RangedFloat? SizeRange;
        [FieldAttr(120)] public float SizeChangeDuration = 3.0f;
        [FieldAttr(124)] public bool Orbit;
        [FieldAttr(128)] public float OrbitStrength = 5.0f;
        [FieldAttr(136)] public CEntityMessage? VictimEnterMessage;
        [FieldAttr(144)] public CEntityMessage? VictimExitMessage;
        [FieldAttr(152)] public CEntityMessage? SelfVictimEnterMessage;
        [FieldAttr(160)] public CEntityMessage? SelfVictimExitMessage;
    }
}
