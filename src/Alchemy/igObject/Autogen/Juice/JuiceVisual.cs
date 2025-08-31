namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class JuiceVisual : igCinematicObject
    {
        [FieldAttr(16)] public igDataBindingList? _bindingList;
        [FieldAttr(24)] public string? _name = null;
        [FieldAttr(32)] public JuiceVisualList? _children;
    }
}
