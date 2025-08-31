namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igPrefabComponentData : igComponentData
    {
        [FieldAttr(24)] public igEntityList? _prefabEntities;
    }
}
