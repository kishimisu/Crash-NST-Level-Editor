namespace Alchemy
{
    [ObjectAttr(1696, 16)]
    public class CLightRigConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField[] _pointLightPositions = new igVec4fMetaField[16];
        [FieldAttr(288)] public igVec4fMetaField[] _pointLightColors = new igVec4fMetaField[16];
        [FieldAttr(544)] public igMatrix44fMetaField[] _boxLightMatrices = new igMatrix44fMetaField[8];
        [FieldAttr(1056)] public igVec4fMetaField[] _boxLightDirections = new igVec4fMetaField[8];
        [FieldAttr(1184)] public igVec4fMetaField[] _boxLightColors = new igVec4fMetaField[8];
        [FieldAttr(1312)] public igVec4fMetaField[] _boxLightParameters = new igVec4fMetaField[24];
    }
}
