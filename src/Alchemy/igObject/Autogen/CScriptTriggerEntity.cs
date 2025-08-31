namespace Alchemy
{
    [ObjectAttr(264, 8)]
    public class CScriptTriggerEntity : CGameEntity
    {
        [FieldAttr(224)] public bool _activated;
        [FieldAttr(228)] public float _maxRadiusInExtents;
        [FieldAttr(232)] public float _maxRadiusSquared;
        [FieldAttr(236)] public bool _onlyPlayersCanTrigger = true;
        [FieldAttr(237)] public bool _autoAabb;
        [FieldAttr(240)] public uint _originalFastFlags;
        [FieldAttr(248)] public CTriggerVolumeGenericShapeComponentData? _triggerVolumeComponentData;
        [FieldAttr(256)] public bool _enableCollisionRequested = true;
    }
}
