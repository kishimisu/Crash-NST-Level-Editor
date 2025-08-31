namespace Alchemy
{
    [ObjectAttr(112, 16)]
    public class igTextureMatrixAttr : igVisualAttribute
    {
        [FieldAttr(32)] public igMatrix44fMetaField _m = new();
        [FieldAttr(96)] public int _unitID = -1;
        [FieldAttr(100)] public i16 _outputElementCount = -1;
        [FieldAttr(102)] public bool _isProjective;
    }
}
