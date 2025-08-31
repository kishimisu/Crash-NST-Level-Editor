namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CVfxDrawPointLightOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public bool _distanceCull = true;
        [FieldAttr(36)] public u32 /* igStructMetaField */ _instance;
    }
}
