namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_WanderAIComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_WanderAIComponent_
    {
        public enum EWanderAIActorSpeed : uint
        {
            Walk = 0,
            Run = 1,
        }

        [FieldAttr(40)] public EWanderAIActorSpeed _actorSpeed = Scripts_WanderAIComponentData.EWanderAIActorSpeed.Run;
        [FieldAttr(44)] public float _wanderRange = 500.0f;
        [FieldAttr(48)] public float _idleDurationMin = 2.0f;
        [FieldAttr(52)] public float _idleDurationMax = 4.0f;
        [FieldAttr(56)] public bool _startStationary;
        [FieldAttr(60)] public float BlockedMovementTolerance = 50.0f;
        [FieldAttr(64)] public float BlockedMovementCooldown = 2.0f;
    }
}
