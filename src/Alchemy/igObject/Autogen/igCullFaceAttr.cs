namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igCullFaceAttr : igVisualAttribute
    {
        [FieldAttr(24)] public bool _enabled = true;
        [FieldAttr(28)] public EIG_GFX_CULL_FACE_MODE _mode;
    }
}
