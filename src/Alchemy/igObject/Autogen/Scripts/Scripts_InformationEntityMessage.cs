namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CEntityMessage))]
    public class Scripts_InformationEntityMessage : CEntityMessage
    {
        public enum EInformationMessage : uint
        {
            Bolted = 0,
            Toggle = 1,
            Jumppad = 2,
            Bounce = 3,
            Charge = 4,
            Release = 5,
            Turbo = 6,
            Start = 7,
            Stop = 8,
        }

        [FieldAttr(56)] public string? Tag = null;
        [FieldAttr(64)] public EInformationMessage InformationMessage;
    }
}
