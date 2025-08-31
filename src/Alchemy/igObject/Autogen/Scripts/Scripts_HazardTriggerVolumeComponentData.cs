namespace Alchemy
{
    [ObjectAttr(160, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_HazardTriggerVolumeComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_HazardTriggerVolumeComponent_
    {
        public enum EOnTriggerVolumeRegisterTypes : uint
        {
            OnEnter = 0,
            OnTouch = 1,
        }

        [FieldAttr(40)] public bool ActiveAtStartup = true;
        [FieldAttr(48)] public CEntityMessage? StartMessage;
        [FieldAttr(56)] public CEntityMessage? StopMessage;
        [FieldAttr(64)] public EOnTriggerVolumeRegisterTypes OnTriggerHandler;
        [FieldAttr(72)] public CTriggerVolumeComponentData? TriggerVolume;
        [FieldAttr(80)] public CDamageData? DamageData;
        [FieldAttr(88)] public CDamageData? DamageDataPVP;
        [FieldAttr(96)] public bool NotifyFriendsOnce;
        [FieldAttr(104)] public CVfxEffectDotNetHandle? HazardOnVfx;
        [FieldAttr(112)] public igHandleMetaField HazardOnVfxBoltPoint = new();
        [FieldAttr(120)] public igHandleMetaField HazardOnSfx = new();
        [FieldAttr(128)] public float HazardOnSFXFadoutTime = 0.25f;
        [FieldAttr(132)] public float Cooldown = 1.0f;
        [FieldAttr(136)] public bool SizeChangeOverTime;
        [FieldAttr(144)] public RangedFloat? SizeRange;
        [FieldAttr(152)] public float SizeChangeDuration = 3.0f;
        [FieldAttr(156)] public float SizeChangeStartDelay;
    }
}
