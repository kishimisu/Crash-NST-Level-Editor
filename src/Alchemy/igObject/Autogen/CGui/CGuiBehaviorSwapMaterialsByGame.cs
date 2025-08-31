namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CGuiBehaviorSwapMaterialsByGame : igGuiBehavior
    {
        [FieldAttr(16)] public igHandleMetaField _crash1Material = new();
        [FieldAttr(24)] public igHandleMetaField _crash2Material = new();
        [FieldAttr(32)] public igHandleMetaField _crash3Material = new();
    }
}
