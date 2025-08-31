namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igTextureBindAttr2 : igVisualAttribute
    {
        [FieldAttr(24)] public igTextureAttr2? _texture;
        [FieldAttr(32)] public int _unitID = -1;
    }
}
