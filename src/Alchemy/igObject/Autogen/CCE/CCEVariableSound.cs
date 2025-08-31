namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CCEVariableSound : CCombatNodeEvent
    {
        [FieldAttr(80)] public CWeightedSoundList? _weightedSoundList;
        [FieldAttr(88)] public bool _findSoundsOnThisVehicleDriver;
    }
}
