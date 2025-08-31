namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class CWorldVisualData : igObject
    {
        [FieldAttr(16)] public igVec3fMetaField _windDirection = new();
        [FieldAttr(32)] public string? _cloudCoverTextureName = "loosetextures";
        [FieldAttr(40)] public string? _specularEnvironmentMap = "loosetextures";
        [FieldAttr(48)] public string? _environmentMap = null;
        [FieldAttr(56)] public CDistantGeometryModelNameList? _farSkyModelList;
        [FieldAttr(64)] public CDistantGeometryModelNameList? _nearSkyModelList;
        [FieldAttr(72)] public CWorldVisualDataGroup? _defaultGroup;
        [FieldAttr(80)] public string? _nearSkyModelName = null;
        [FieldAttr(88)] public string? _farSkyModelName1 = null;
        [FieldAttr(96)] public string? _farSkyModelName2 = null;
        [FieldAttr(104)] public string? _farSkyModelName3 = null;
        [FieldAttr(112)] public string? _farSkyModelName4 = null;
        [FieldAttr(120)] public CSkyboxModelsHashTable? _skyboxModelsHashTable;
        [FieldAttr(128)] public igObjectDirectory? _cloudCoverTextureDirectory;
        [FieldAttr(136)] public igObjectDirectory? _specularEnvironmentMapDirectory;
        [FieldAttr(144)] public igObjectDirectory? _environmentMapDirectory;
    }
}
