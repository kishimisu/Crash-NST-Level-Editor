namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CutsceneActionKillVFX : CutsceneVFXAction
    {
        [FieldAttr(40)] public igVfxManager.EffectKillType _killType;
    }
}
