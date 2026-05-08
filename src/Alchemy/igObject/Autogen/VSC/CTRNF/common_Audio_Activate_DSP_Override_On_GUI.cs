namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class common_Audio_Activate_DSP_Override_On_GUI : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igObject? _InternalStore_prioritySetHandler = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Priority_Dsp_Override_Set = new();
    }
}
