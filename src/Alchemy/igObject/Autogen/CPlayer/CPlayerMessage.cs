namespace Alchemy
{
    [ObjectAttr(64, 8, metaObject: true)]
    public class CPlayerMessage : CEntityMessage
    {
        [FieldAttr(56)] public EPlayerId _player = EPlayerId.EPLAYERID_NONE;
    }
}
