namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class common_Crash_HUD_ZoneCollectibles : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _spawnedEffect = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x34;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Zone_Info = new();
    }
}
