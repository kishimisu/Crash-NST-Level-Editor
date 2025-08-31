namespace Alchemy
{
    [ObjectAttr(224, 8, metaObject: true)]
    public class CInteractionData : Object
    {
        public enum EInteractPromptAreaType : uint
        {
            eIPAT_Radius = 0,
            eIPAT_TriggerVolumeComponent = 1,
        }

        [FieldAttr(32)] public CInteractionRestriction? _restriction;
        [FieldAttr(40)] public bool _waitForButtonRelease;
        [FieldAttr(44)] public int _interactionPriority;
        [FieldAttr(48)] public bool _boltAlertPrompt = true;
        [FieldAttr(56)] public CBoltPoint? _boltPoint;
        [FieldAttr(64)] public igVec3fMetaField _boltPointOffset = new();
        [FieldAttr(80)] public igHandleMetaField _alertPromptUI = new();
        [FieldAttr(88)] public float _alertPromptDistance = 2000.0f;
        [FieldAttr(92)] public bool _displayInteractPrompt = true;
        [FieldAttr(93)] public bool _boltInteractPrompt = true;
        [FieldAttr(96)] public CBoltPoint? _interactVfxBoltPoint;
        [FieldAttr(104)] public igVec3fMetaField _interactVfxBoltPointOffset = new();
        [FieldAttr(116)] public EInteractPromptAreaType _interactPromptAreaType;
        [FieldAttr(120)] public float _interactPromptDistance = 300.0f;
        [FieldAttr(124)] public bool _supportCannotInteract = true;
        [FieldAttr(128)] public igHandleMetaField _cannotInteractPromptUI = new();
        [FieldAttr(136)] public igHandleMetaField _entityToBoltTo = new();
        [FieldAttr(144)] public bool _whenOutOfRangeKillVfxImmediately;
        [FieldAttr(145)] public bool _softKillForPendingVfx;
        [FieldAttr(152)] public igVfxEffectHandleList? _additionalInteractVfx;
        [FieldAttr(160)] public EXBUTTON _interactKey = EXBUTTON.R1;
        [FieldAttr(164)] public bool _sendMessageToEntity = true;
        [FieldAttr(168)] public igHandleMetaField _onInteractSfx = new();
        [FieldAttr(176)] public CEntityMessage? _interactionMessage;
        [FieldAttr(184)] public CEntityMessage? _heldButtonInteractionStart;
        [FieldAttr(192)] public CEntityHandleList? _messageRecipients;
        [FieldAttr(200)] public bool _broadcastMessage;
        [FieldAttr(208)] public CEntitySphere? _broadcastSphere;
        [FieldAttr(216)] public float _stateCooldownInSeconds;
    }
}
