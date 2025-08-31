namespace Alchemy
{
    // VSC object extracted from: Characters_Egypt_Enemy_Vase_WhiteMonkey_Character.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class Characters_Egypt_Enemy_Vase_WhiteMonkey_CharacterData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity = new();
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(56)] public igHandleMetaField _Sound = new();
        [FieldAttr(64)] public string? _String = null;
        [FieldAttr(72)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
    }
}
