namespace Alchemy
{
    [ObjectAttr(104, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_InvisibilityHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public bool RemainVisible;
        [FieldAttr(81)] public bool RemainTargetable;
        [FieldAttr(82)] public bool InvisibleOnStart = true;
        [FieldAttr(88)] public Scripts_StringMessage? ReturnVisibleMessage;
        [FieldAttr(96)] public Scripts_StringMessage? BecomeInvisibleMessage;
    }
}
