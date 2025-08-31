using Alchemy;

namespace Havok
{
    [ObjectAttr(48)]
    public class hknpShapeMassProperties : hkReferencedObject
    {
        public override uint Hash => 0xe9191728;

        [FieldAttr(16)] public i16 _centerOfMass_0; // TYPE_INT16, arrsize: 4, (Inlined from type: hkCompressedMassProperties)
        [FieldAttr(18)] public i16 _centerOfMass_1;
        [FieldAttr(20)] public i16 _centerOfMass_2;
        [FieldAttr(22)] public i16 _centerOfMass_3;
        [FieldAttr(24)] public i16 _inertia_0; // TYPE_INT16, arrsize: 4, (Inlined from type: hkCompressedMassProperties)
        [FieldAttr(26)] public i16 _inertia_1;
        [FieldAttr(28)] public i16 _inertia_2;
        [FieldAttr(30)] public i16 _inertia_3;
        [FieldAttr(32)] public i16 _majorAxisSpace_0; // TYPE_INT16, arrsize: 4, (Inlined from type: hkCompressedMassProperties)
        [FieldAttr(34)] public i16 _majorAxisSpace_1;
        [FieldAttr(36)] public i16 _majorAxisSpace_2;
        [FieldAttr(38)] public i16 _majorAxisSpace_3;
        [FieldAttr(40)] public float _mass; // TYPE_REAL, (Inlined from type: hkCompressedMassProperties)
        [FieldAttr(44)] public float _volume; // TYPE_REAL, (Inlined from type: hkCompressedMassProperties)
    }
}