namespace Alchemy
{
    // VSC object extracted from: Ride_Bike_Rough_Road.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class Ride_Bike_Rough_RoadData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Collision_Material = new();
        [FieldAttr(48)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(56)] public igHandleMetaField _Vfx_Effect = new();
    }
}
