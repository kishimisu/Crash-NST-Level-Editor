namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Octane_MinimapData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float;
        [FieldAttr(nst: 44, ctr: 36)] public igVec2fMetaField _Vec_2F_0x24 = new();
        [FieldAttr(nst: 52, ctr: 44)] public igVec2fMetaField _Vec_2F_0x2c = new();
        [FieldAttr(nst: 60, ctr: 52)] public igVec2fMetaField _Vec_2F_0x34 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Fx_Material = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(nst: 88, ctr: 80)] public ERacingMinimapDirection _E_Racing_Minimap_Direction;
    }
}
