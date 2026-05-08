namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 8)]
    public class igGuiVec3LinearKeyframe : igGuiFieldKeyframe
    {
        [FieldAttr(nst: 32, ctr: 24)] public igVec3fMetaField _data = new();
    }
}
