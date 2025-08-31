namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CCloudBundle : igObject
    {
        public enum ECloudEntityType : uint
        {
            kNoEntity = 0,
            kGameEntity = 1,
            kIgEntity = 2,
        }

        [FieldAttr(40, false)] public igObject? _entity;
        [FieldAttr(48)] public ECloudEntityType _currentType;
        [FieldAttr(56, false)] public igModelInstance? _modelInstance;
    }
}
