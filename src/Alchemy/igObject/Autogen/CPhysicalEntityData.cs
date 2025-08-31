namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class CPhysicalEntityData : CGameEntityData
    {
        [FieldAttr(128)] public uint _physicalEntityFlags = 128;
        [FieldAttr(132)] public int _health = 100;
        [FieldAttr(136)] public int _healthMax = 100;
        [FieldAttr(140)] public EVulnerability _vulnerability = EVulnerability.eV_Invulnerable;
    }
}
