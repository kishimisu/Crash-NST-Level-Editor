namespace Alchemy
{
    [ObjectAttr(256, 8)]
    public class CGuiBehaviorCrashContinueGameButton : CGuiBehaviorContinueGameButton
    {
        [FieldAttr(248)] public ECrashGame _crashGame;
    }
}
