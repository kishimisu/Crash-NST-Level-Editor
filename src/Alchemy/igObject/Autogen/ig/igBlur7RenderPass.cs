namespace Alchemy
{
    [ObjectAttr(nst: 608, ctr: 608, align: 16)]
    public class igBlur7RenderPass : igFullScreenRenderPass
    {
        [FieldAttr(ctr: 580)] public float _blurRadius;
        [FieldAttr(nst: 592, ctr: 584)] public igVec4fList? _texcoordOffsets;
        [FieldAttr(nst: 600, ctr: 592)] public igSizeTypeMetaField _texcoordOffsetResource = new();
    }
}
