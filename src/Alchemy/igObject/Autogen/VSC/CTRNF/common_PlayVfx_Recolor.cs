namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class common_PlayVfx_Recolor : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _SteamBlower_BehaviorDatas = new();
        [FieldAttr(nst: 48, ctr: 40)] public igVec4ucMetaField _Color = new();
        [FieldAttr(nst: 52, ctr: 44)] public bool _Bool;
    }
}
