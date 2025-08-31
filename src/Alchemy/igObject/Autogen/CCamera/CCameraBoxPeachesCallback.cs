namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CCameraBoxPeachesCallback : igPeachesBaseCallback
    {
        [FieldAttr(16, false)] public CCameraBox? _object;
        [FieldAttr(24)] public u32 /* igStructMetaField */ _function;
    }
}
