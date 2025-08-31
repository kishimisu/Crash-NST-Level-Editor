namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igBlendStateAttr : igVisualAttribute
    {
        [FieldAttr(24)] public bool _enabled;
        [FieldAttr(25)] public bool _alphaToCoverageEnabled;
    }
}
