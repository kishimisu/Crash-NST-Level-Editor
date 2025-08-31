namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igGuiComposition : igGuiAsset
    {
        [FieldAttr(32)] public igGuiPlaceable? _placeable;
        [FieldAttr(40)] public igGuiInstanceMap? _instanceMap;
    }
}
