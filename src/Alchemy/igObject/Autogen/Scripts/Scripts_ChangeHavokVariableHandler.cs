namespace Alchemy
{
    [ObjectAttr(120, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_ChangeHavokVariableHandler : CBehaviorLogic
    {
        public enum ESetHavokBehaviorVariableEnum : uint
        {
            Int = 0,
            Float = 1,
            Bool = 2,
        }

        [FieldAttr(80)] public ESetHavokBehaviorVariableEnum HavokVariableEnum;
        [FieldAttr(88)] public string? HavokBehaviorVariableID = null;
        [FieldAttr(96)] public int ActivateValue = -1;
        [FieldAttr(100)] public int DeactivateValue = -1;
        [FieldAttr(104)] public float ActivateFloatValue = -1.0f;
        [FieldAttr(108)] public float DeactivateFloatValue = -1.0f;
        [FieldAttr(112)] public bool ActivateBoolValue = true;
        [FieldAttr(113)] public bool DeactivateBoolValue;
        [FieldAttr(114)] public bool ExitReset;
    }
}
