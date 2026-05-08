namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 8)]
    public class CDynamicCloudComponentData : CEntityComponentData
    {
        [FieldAttr(nst: 24, ctr: 16)] public igVec2fMetaField _playerFadeRadii = new();
        [FieldAttr(nst: 32, ctr: 24)] public bool _dissipateOnEnter = true;
        [FieldAttr(nst: 36, ctr: 28)] public float _dissipateDuration = 6.0f;
        [FieldAttr(nst: 40, ctr: 32)] public float _dissipateEaseInDuration;
        [FieldAttr(nst: 44, ctr: 36)] public float _dissipateEaseOutDuration;
        [FieldAttr(nst: 48, ctr: 40)] public bool _isMultiFade;
        [FieldAttr(nst: 49, ctr: 41)] public bool _useFarPlayerOffset;
        [FieldAttr(nst: 50, ctr: 42)] public bool _wholeFade = true;
    }
}
