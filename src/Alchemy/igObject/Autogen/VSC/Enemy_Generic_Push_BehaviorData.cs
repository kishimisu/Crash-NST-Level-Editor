namespace Alchemy
{
    // VSC object extracted from: Enemy_Generic_Push_Behavior_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class Enemy_Generic_Push_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _PushOnCollide;
        [FieldAttr(41)] public bool _PushOnSpin;
        [FieldAttr(44)] public float _PushOffset;
        [FieldAttr(48)] public float _LaunchHeight;
        [FieldAttr(52)] public float _LaunchSpeed;
        [FieldAttr(56)] public string? _SpinDeath = null;
    }
}
