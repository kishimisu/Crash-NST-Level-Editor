namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 32, align: 8)]
    public class CButtonListenerInstance : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public CTimer? _cooldownTimer;
        [FieldAttr(nst: 24, ctr: 24)] public bool _currentlyAttacking;
    }
}
