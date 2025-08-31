namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CDestructibleStage : igObject
    {
        [FieldAttr(16)] public float _percentHealth = 1.0f;
        [FieldAttr(20)] public EVulnerability _vulnerability;
        [FieldAttr(24)] public string? _model = null;
        [FieldAttr(32)] public bool _skylandersCanDamage = true;
        [FieldAttr(33)] public bool _vehiclesCanDamage = true;
        [FieldAttr(40)] public igHandleMetaField _onDamageVfx = new();
        [FieldAttr(48)] public igHandleMetaField _onDamageSfx = new();
        [FieldAttr(56)] public igHandleMetaField _onStageEndVfx = new();
        [FieldAttr(64)] public igHandleMetaField _onStageEndSfx = new();
    }
}
