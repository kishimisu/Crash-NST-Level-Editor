namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 56, align: 8)]
    public class CSkyboxModels : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public CRigidModelInstance? _nearSkyModel;
        [FieldAttr(nst: 24, ctr: 24)] public CRigidModelInstance? _farSkyModel1;
        [FieldAttr(nst: 32, ctr: 32)] public CRigidModelInstance? _farSkyModel2;
        [FieldAttr(nst: 40, ctr: 40)] public CRigidModelInstance? _farSkyModel3;
        [FieldAttr(nst: 48, ctr: 48)] public CRigidModelInstance? _farSkyModel4;
    }
}
