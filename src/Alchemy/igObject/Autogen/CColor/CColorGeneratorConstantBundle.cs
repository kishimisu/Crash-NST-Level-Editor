namespace Alchemy
{
    [ObjectAttr(992, 16)]
    public class CColorGeneratorConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField[] _boxInfluence = new igVec4fMetaField[3];
        [FieldAttr(80)] public igVec4fMetaField _externalInfluence = new();
        [FieldAttr(96)] public igVec4fMetaField[] _scale = new igVec4fMetaField[8];
        [FieldAttr(224)] public igVec4fMetaField[] _bias = new igVec4fMetaField[8];
        [FieldAttr(352)] public igVec4fMetaField[] _keys = new igVec4fMetaField[40];
    }
}
