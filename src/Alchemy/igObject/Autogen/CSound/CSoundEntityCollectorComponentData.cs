namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CSoundEntityCollectorComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CTriggerVolumeComponentData? _collectionVolume;
        [FieldAttr(32)] public CEntity? _dummyEntity;
        [FieldAttr(40)] public float _positionDamping = 0.15f;
    }
}
