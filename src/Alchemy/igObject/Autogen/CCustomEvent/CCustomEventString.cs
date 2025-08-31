namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CCustomEventString))]
    public class CCustomEventString : CCustomEvent
    {
        [FieldAttr(64)] public string? _string = null;
    }
}
