namespace Alchemy
{
    [ObjectAttr(112, 16)]
    public class igViewPositionReconstructionBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _reconstructionConstants = new();
        [FieldAttr(48)] public igMatrix44fMetaField _inverseViewMatrix = new();
    }
}
