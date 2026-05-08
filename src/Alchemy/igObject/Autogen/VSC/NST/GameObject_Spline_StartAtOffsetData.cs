namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 4, metaType: typeof(CVscComponentData))]
    public class GameObject_Spline_StartAtOffsetData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _PlayForward;
        [FieldAttr(nst: 44, ctr: 36)] public float _StartingRatio;
    }
}
