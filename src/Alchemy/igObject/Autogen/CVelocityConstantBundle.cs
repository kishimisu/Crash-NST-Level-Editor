namespace Alchemy
{
    [ObjectAttr(176, 16)]
    public class CVelocityConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igMatrix44fMetaField _viewProjPrevious = new();
        [FieldAttr(96)] public float _exposureTime = 0.25f;
        [FieldAttr(112)] public igVec4fMetaField _exposureParams = new();
        [FieldAttr(128)] public igVec4fMetaField _tileParams = new();
        [FieldAttr(144)] public igVec4fMetaField _radiusParams = new();
        [FieldAttr(160)] public bool _motionBlurState = true;
    }
}
