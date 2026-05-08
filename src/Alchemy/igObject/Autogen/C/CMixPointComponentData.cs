namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 8)]
    public class CMixPointComponentData : CEntityComponentData
    {
        [FieldAttr(nst: 24, ctr: 16)] public float _traversalMixMinRadius = 100.0f;
        [FieldAttr(nst: 28, ctr: 20)] public float _traversalMixMaxRadius = 1000.0f;
        [FieldAttr(nst: 32, ctr: 24)] public float _traversalMixTrack1MaxVolume = 1.0f;
        [FieldAttr(nst: 36, ctr: 28)] public float _traversalMixTrack2MaxVolume = 1.0f;
        [FieldAttr(nst: 40, ctr: 32)] public float _traversalMixTrack3MaxVolume;
        [FieldAttr(nst: 44, ctr: 36)] public float _traversalMixTrack4MaxVolume;
        [FieldAttr(nst: 48, ctr: 40)] public float _traversalMixTrack5MaxVolume;
        [FieldAttr(nst: 52, ctr: 44)] public bool _startActive = true;
        [FieldAttr(nst: 56, ctr: 48)] public igVec3fMetaField _entityRelativeOffset = new();
    }
}
