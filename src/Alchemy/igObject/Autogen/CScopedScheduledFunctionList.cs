namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CScopedScheduledFunctionList : igObjectList<CScopedScheduledFunction>
    {
        [FieldAttr(40)] public int _lastIndex;
    }
}
