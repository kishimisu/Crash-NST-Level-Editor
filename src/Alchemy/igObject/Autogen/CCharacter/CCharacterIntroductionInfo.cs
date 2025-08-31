namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CCharacterIntroductionInfo : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _skewMaterial = new();
        [FieldAttr(24)] public igHandleMetaField _introductionVO = new();
    }
}
