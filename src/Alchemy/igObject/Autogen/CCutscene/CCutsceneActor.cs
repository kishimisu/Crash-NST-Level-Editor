namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class CCutsceneActor : JuiceVisual
    {
        [FieldAttr(40)] public igHandleMetaField _proxiedEntity = new();
        [FieldAttr(48)] public igVec3fMetaField _position = new();
        [FieldAttr(60)] public igVec3fMetaField _rotation = new();
        [FieldAttr(72)] public igVec3fMetaField _scale = new();
        [FieldAttr(88)] public CSkinnedModelInstance? _model;
        [FieldAttr(96)] public CCutsceneActorData? _entityData;
        [FieldAttr(104)] public string? _cutsceneOwnerName = "DO NOT CHANGE";
        [FieldAttr(112)] public string? _animationDatabasePath = "DO NOT CHANGE";
    }
}
