namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CDSPOverrideComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public bool _startActive = true;
        [FieldAttr(32)] public igHandleMetaField _overrideSet = new();
        [FieldAttr(40)] public bool _allowCameraToTrigger;
        [FieldAttr(41)] public bool _ignoreChecksForCanPlayerControl;
    }
}
