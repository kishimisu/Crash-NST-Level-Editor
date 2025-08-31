namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CSoundUpdateMethod : igObject
    {
        [FieldAttr(16)] public float _updatePeriod = 0.3f;
        [FieldAttr(24)] public CScopedScheduledFunction? _scheduledFunction;
        [FieldAttr(32)] public CSoundUpdateTaskList? _soundTaskList;
        [FieldAttr(40)] public CSoundUpdateReferenceOverride? _referenceOverride;
    }
}
