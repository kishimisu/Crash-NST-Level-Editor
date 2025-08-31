namespace Alchemy
{
    [ObjectAttr(80, 16)]
    public class CVfxRaycastOperator : igVfxFrameOperator
    {
        public enum EFailAction : uint
        {
            UseCurrent = 0,
            UseStart = 1,
            UseEnd = 2,
            UseHide = 3,
            UseKill = 4,
        }

        public enum EHitFacing : uint
        {
            FaceRay = 0,
            FaceSurfaceNormal = 1,
            FaceReflection = 2,
        }

        [ObjectAttr(4)]
        public class RaycastFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public CVfxRaycastOperator.EFailAction _failAction;
            [FieldAttr(3, size: 2)] public CVfxRaycastOperator.EHitFacing _hitFacing = CVfxRaycastOperator.EHitFacing.FaceRay;
            [FieldAttr(5, size: 1)] public bool _hitFacingFlip;
        }

        [FieldAttr(32)] public RaycastFlags _raycastFlags = new();
        [FieldAttr(48)] public igVec3fAlignedMetaField _testRay = new();
        [FieldAttr(64)] public float _balance;
        [FieldAttr(68)] public uint _collisionFlags = 320;
        [FieldAttr(72)] public u32 /* igStructMetaField */ _instance;
    }
}
