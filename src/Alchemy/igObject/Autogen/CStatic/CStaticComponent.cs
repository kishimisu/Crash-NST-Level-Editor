namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 72, align: 8)]
    public class CStaticComponent : igComponent
    {
        public enum ECastsShadows
        {
            ECS_Archetype = 0,
            ECS_CastsShadows = 1,
            ECS_DoesNotCastShadows = 2,
        }

        public enum EMobileShadowStateOverride
        {
            eMSSO_Archetype = 0,
            eMSSO_CastsShadows = 1,
            eMSSO_ReceivesShadows = 2,
            eMSSO_DoesNotCastOrReceiveShadows = 3,
        }

        [FieldAttr(ctr: 40)] public CModelInstance? _model;
        [FieldAttr(nst: 40, ctr: 48)] public ECastsShadows _castsShadows;
        [FieldAttr(nst: 44, ctr: 52)] public EMobileShadowStateOverride _mobileShadowState;
        [FieldAttr(nst: 48, ctr: 56)] public CCloudBundle? _cloudBundle;
        [FieldAttr(nst: 56, ctr: 64)] public bool _pendingUpdateMessage;
    }
}
