namespace Alchemy
{
    [ObjectAttr(96, 8, metaType: typeof(CTakeHitImmunityHandler))]
    public class CTakeHitImmunityHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public float _immunityDuration;
        [FieldAttr(84)] public bool _fullyInvulnerable = true;
        [FieldAttr(85)] public bool _pushBackImmunity;
        [FieldAttr(88)] public CChangeRequestList? _changeRequests;
    }
}
