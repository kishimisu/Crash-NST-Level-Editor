namespace Alchemy
{
    [ObjectAttr(40, 8, metaType: typeof(CDotNetCombatNodeEvent))]
    public class Scripts_StartBounceJumpEvent : CDotNetCombatNodeEvent
    {
        [FieldAttr(32)] public bool AllowAirControl;
        [FieldAttr(33)] public bool FollowJumpHeightWithCamera;
        [FieldAttr(36)] public float ZJumpVelocity = 700.0f;
    }
}
