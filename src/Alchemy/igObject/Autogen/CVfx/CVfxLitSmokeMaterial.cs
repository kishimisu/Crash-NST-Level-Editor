namespace Alchemy
{
    [ObjectAttr(304, 16)]
    public class CVfxLitSmokeMaterial : CVfxMaterial
    {
        [FieldAttr(272)] public float _lightWrap = 0.75f;
        [FieldAttr(288)] public igVec4fMetaField _lightWrapParameters = new();
    }
}
