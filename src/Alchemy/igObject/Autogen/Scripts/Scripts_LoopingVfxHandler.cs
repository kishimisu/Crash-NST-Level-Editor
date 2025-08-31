namespace Alchemy
{
    [ObjectAttr(112, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_LoopingVfxHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public CVfxEffectDotNetHandle? LoopingVfxData;
        [FieldAttr(88)] public CBoltPoint? LoopingVfxBoltPoint01;
        [FieldAttr(96)] public CBoltPoint? LoopingVfxBoltPoint02;
        [FieldAttr(104)] public bool HardKill;
    }
}
