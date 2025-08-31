namespace Alchemy
{
    [ObjectAttr(288, 16)]
    public class CEnvironmentLightingBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _iridescentFixedOffsetDirection = new();
        [FieldAttr(48)] public igVec4fMetaField _averageEnvironmentColor = new();
        [FieldAttr(64)] public igVec4fMetaField _averageEnvironmentColorLinear = new();
        [FieldAttr(80)] public igVec4fMetaField _sunColor = new();
        [FieldAttr(96)] public igVec4fMetaField _combinedEnvironmentColor = new();
        [FieldAttr(112)] public igVec4fMetaField _grassInteractionOne = new();
        [FieldAttr(128)] public igVec4fMetaField _grassInteractionTwo = new();
        [FieldAttr(144)] public igVec4fMetaField _playerFadeOne = new();
        [FieldAttr(160)] public igVec4fMetaField _playerFadeOneScaled = new();
        [FieldAttr(176)] public igVec4fMetaField _playerFadeTwo = new();
        [FieldAttr(192)] public igVec4fMetaField _playerFadeTwoScaled = new();
        [FieldAttr(208)] public igVec4fMetaField _playerFadeOneFar = new();
        [FieldAttr(224)] public igVec4fMetaField _playerFadeOneScaledFar = new();
        [FieldAttr(240)] public igVec4fMetaField _playerFadeTwoFar = new();
        [FieldAttr(256)] public igVec4fMetaField _playerFadeTwoScaledFar = new();
        [FieldAttr(272)] public igVec4fMetaField _waterEnvironmentLighting = new();
    }
}
