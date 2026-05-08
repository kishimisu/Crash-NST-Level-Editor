namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 32, align: 8)]
    public class igGuiVec2LinearKeyframe : igGuiFieldKeyframe
    {
        [FieldAttr(nst: 32, ctr: 24)] public igVec2fMetaField _data = new();
    }
}
