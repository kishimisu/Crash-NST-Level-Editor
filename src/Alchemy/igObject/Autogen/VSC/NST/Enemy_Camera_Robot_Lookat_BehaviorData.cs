namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Camera_Robot_Lookat_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _UsePitch;
        [FieldAttr(nst: 41, ctr: 33)] public bool _UseYaw;
        [FieldAttr(nst: 42, ctr: 34)] public bool _Bool;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float;
    }
}
