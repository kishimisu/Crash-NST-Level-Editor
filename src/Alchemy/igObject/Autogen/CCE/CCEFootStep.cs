namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CCEFootStep : CCombatNodeEvent
    {
        [FieldAttr(80)] public EFoot _foot;
        [FieldAttr(84)] public bool _walking;
        [FieldAttr(85)] public bool _ignoreCommonSound;
        [FieldAttr(86)] public bool _ignoreMaterialSound;
    }
}
