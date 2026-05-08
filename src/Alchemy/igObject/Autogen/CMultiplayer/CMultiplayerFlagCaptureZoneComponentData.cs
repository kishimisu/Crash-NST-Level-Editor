namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 40, align: 8)]
    public class CMultiplayerFlagCaptureZoneComponentData : CEntityComponentData
    {
        [FieldAttr(nst: 24, ctr: 16)] public int _teamIndex;
        [FieldAttr(ctr: 20)] public bool _exclusiveCapture;
        [FieldAttr(ctr: 24)] public igHandleMetaField _teamFlag = new();
        [FieldAttr(ctr: 32)] public igHandleMetaField _effect = new();
    }
}
