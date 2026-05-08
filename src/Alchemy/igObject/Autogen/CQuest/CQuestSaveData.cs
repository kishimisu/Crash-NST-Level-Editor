namespace Alchemy
{
    [ObjectAttr(nst: 24, ctr: 16, align: 4)]
    public class CQuestSaveData : igObject
    {
        [ObjectAttr(size: 4)]
        public class SaveBitfield : igBitFieldMetaField
        {
            [FieldAttr(offset: 0, size: 4)] public uint _stepIndex;
            [FieldAttr(offset: 4, size: 18)] public uint _objectiveProgress;
        }

        [FieldAttr(nst: 16, ctr: 12)] public SaveBitfield _saveBitfield = new();
    }
}
