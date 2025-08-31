namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CStackCameraControllerBase : igNamedObject
    {
        [FieldAttr(24)] public EControllerPriorityCategory _priorityCategory;
        [FieldAttr(28)] public int _priority;
        [FieldAttr(32)] public CStackCameraBehaviorStates? _behaviorStates;
        [FieldAttr(40)] public CStackBlender? _blender;
        [FieldAttr(48)] public bool _debugControllerEnabled = true;
        [FieldAttr(49)] public bool _debuggingEnabled;
    }
}
