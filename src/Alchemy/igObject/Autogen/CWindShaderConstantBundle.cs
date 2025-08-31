namespace Alchemy
{
    [ObjectAttr(336, 16)]
    public class CWindShaderConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _windVector = new();
        [FieldAttr(48)] public igVec4fMetaField _windGlobal = new();
        [FieldAttr(64)] public igVec4fMetaField _windBranch = new();
        [FieldAttr(80)] public igVec4fMetaField _windBranchTwitch = new();
        [FieldAttr(96)] public igVec4fMetaField _windBranchWhip = new();
        [FieldAttr(112)] public igVec4fMetaField _windBranchAnchor = new();
        [FieldAttr(128)] public igVec4fMetaField _windBranchAdherences = new();
        [FieldAttr(144)] public igVec4fMetaField _windTurbulences = new();
        [FieldAttr(160)] public igVec4fMetaField _windRollingBranches = new();
        [FieldAttr(176)] public igVec4fMetaField _windLeaf1Ripple = new();
        [FieldAttr(192)] public igVec4fMetaField _windLeaf1Tumble = new();
        [FieldAttr(208)] public igVec4fMetaField _windLeaf1Twitch = new();
        [FieldAttr(224)] public igVec4fMetaField _windLeaf1Roll = new();
        [FieldAttr(240)] public igVec4fMetaField _windLeaf2Ripple = new();
        [FieldAttr(256)] public igVec4fMetaField _windLeaf2Tumble = new();
        [FieldAttr(272)] public igVec4fMetaField _windLeaf2Twitch = new();
        [FieldAttr(288)] public igVec4fMetaField _windLeaf2Roll = new();
        [FieldAttr(304)] public igVec4fMetaField _windFrondRipple = new();
        [FieldAttr(320)] public igVec4fMetaField _windAnimation = new();
    }
}
