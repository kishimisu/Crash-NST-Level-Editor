namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igColorMaskAttr : igVisualAttribute
    {
        [FieldAttr(24)] public bool _red = true;
        [FieldAttr(25)] public bool _green = true;
        [FieldAttr(26)] public bool _blue = true;
        [FieldAttr(27)] public bool _alpha = true;
        [FieldAttr(28)] public uint _unused;
    }
}
