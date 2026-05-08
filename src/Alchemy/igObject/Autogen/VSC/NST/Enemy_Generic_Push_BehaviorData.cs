namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Generic_Push_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _PushOnCollide;
        [FieldAttr(nst: 41, ctr: 33)] public bool _PushOnSpin;
        [FieldAttr(nst: 44, ctr: 36)] public float _PushOffset;
        [FieldAttr(nst: 48, ctr: 40)] public float _LaunchHeight;
        [FieldAttr(nst: 52, ctr: 44)] public float _LaunchSpeed;
        [FieldAttr(nst: 56, ctr: 48)] public string? _SpinDeath = null;
    }
}
