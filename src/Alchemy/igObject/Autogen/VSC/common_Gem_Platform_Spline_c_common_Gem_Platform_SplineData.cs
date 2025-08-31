namespace Alchemy
{
    // VSC object extracted from: common_Gem_Platform_Spline_c.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class common_Gem_Platform_Spline_c_common_Gem_Platform_SplineData : CVscComponentData
    {
        [FieldAttr(40)] public bool _LockPlayer;
        [FieldAttr(48)] public igHandleMetaField _LockedPlayerCamera = new();
        [FieldAttr(56)] public igHandleMetaField _ExitingCamera = new();
        [FieldAttr(64)] public igHandleMetaField _Spline = new();
        [FieldAttr(72)] public float _WaitToReverse;
        [FieldAttr(76)] public float _WaitToMove;
        [FieldAttr(80)] public igHandleMetaField _CrashRidingPlatform = new();
        [FieldAttr(88)] public igHandleMetaField _minigame = new();
        [FieldAttr(96)] public igHandleMetaField _SplineMoverSettings = new();
        [FieldAttr(104)] public igHandleMetaField _Spline_Rotation_Mover = new();
        [FieldAttr(112)] public bool _Bool_0x70;
        [FieldAttr(116)] public float _Float_0x74;
        [FieldAttr(120)] public float _Float_0x78;
        [FieldAttr(124)] public bool _Bool_0x7c;
    }
}
