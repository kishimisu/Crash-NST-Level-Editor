namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 72, align: 8)]
    public class CGroundClampFailMessage : CEntityMessage
    {
        public enum EGroundClampFailReason
        {
            eGCFR_FirstFail = 0,
            eGCFR_Fail = 1,
            eGCFR_FailEnded = 2,
        }

        [FieldAttr(nst: 56, ctr: 56)] public EGroundClampFailReason _reason = CGroundClampFailMessage.EGroundClampFailReason.eGCFR_Fail;
        [FieldAttr(nst: 60, ctr: 60)] public igVec3fMetaField _mostRecentSuccessPosition = new();
    }
}
