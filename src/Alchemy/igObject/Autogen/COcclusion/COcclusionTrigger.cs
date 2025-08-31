namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class COcclusionTrigger : igObject
    {
        [FieldAttr(16)] public OcclusionBoxList? _boxes;
        [FieldAttr(24)] public uint _entered;
        [FieldAttr(28)] public igVec3fMetaField _position = new();
        [FieldAttr(40)] public igVec3fMetaField _rotation = new();
        [FieldAttr(52)] public igVec3fMetaField _scale = new();
        [FieldAttr(64)] public igVec3fMetaField _min = new();
        [FieldAttr(76)] public igVec3fMetaField _max = new();
        [FieldAttr(88)] public bool _ignoreDuringEngineCutscene;
        [FieldAttr(89)] public bool _ignoreDuringMovieCutscene = true;
        [FieldAttr(90)] public bool _useCameraPosition;
        [FieldAttr(91)] public bool _state = true;
    }
}
