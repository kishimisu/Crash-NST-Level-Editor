namespace Alchemy
{
    [ObjectAttr(272, 16)]
    public class igGuiPlaceableBolt : igVfxBolt
    {
        [FieldAttr(240)] public igHandleMetaField _place = new();
        [FieldAttr(248)] public float _distanceFromCamera = 50.0f;
        [FieldAttr(256)] public igHandleMetaField _spawnedEffect = new();
        [FieldAttr(264)] public bool _setBoltParametersFromTexCoords;
    }
}
