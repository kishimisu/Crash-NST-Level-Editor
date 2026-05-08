namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 64, align: 8)]
    public class CWorldCollectibleModifier : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public string? _modelName = null;
        [FieldAttr(nst: 24, ctr: 24)] public igStringRefList? _modelNames;
        [FieldAttr(nst: 32, ctr: 32)] public CWorldCollectibleModifierItemList? _items;
        [FieldAttr(nst: 40, ctr: 40)] public igEntity? _collectibleReplacementEntity;
        [FieldAttr(nst: 48, ctr: 48)] public float _awardValueOverride = -1.0f;
        [FieldAttr(nst: 52, ctr: 52)] public float _alternateAwardValueOverride = -1.0f;
        [FieldAttr(nst: 56, ctr: 56)] public float _attractRadiusOverride = -1.0f;
    }
}
