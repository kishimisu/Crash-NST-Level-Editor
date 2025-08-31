namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CTargetableFlagEnableStack))]
    public class CTargetableFlagEnableStack : CEnableStack
    {
        [FieldAttr(64)] public igHandleMetaField _entity = new();
    }
}
