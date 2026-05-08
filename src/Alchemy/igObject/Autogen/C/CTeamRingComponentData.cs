namespace Alchemy
{
    [ObjectAttr(nst: 32, align: 8)]
    public class CTeamRingComponentData : CEntityComponentData
    {
        [FieldAttr(nst: 24)] public igVfxEffectHandleList? _teamRingVfx;
    }
}
