namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Racer_HUD_Nitro_Fueled_Boost_Bar : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public EOctaneBoostBarType _E_Octane_Boost_Bar_Type;
        [FieldAttr(nst: 56, ctr: 48)] public igObject? _InternalStore__timer = new();
    }
}
