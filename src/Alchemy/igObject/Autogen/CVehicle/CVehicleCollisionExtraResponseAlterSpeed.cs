namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CVehicleCollisionExtraResponseAlterSpeed : CVehicleCollisionExtraResponseReorientBase
    {
        [FieldAttr(64)] public igVec3fMetaField _alterSpeedFactor = new();
    }
}
