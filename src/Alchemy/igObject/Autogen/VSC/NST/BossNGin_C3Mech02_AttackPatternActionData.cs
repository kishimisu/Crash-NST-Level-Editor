namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 4, metaType: typeof(CVscComponentData))]
    public class BossNGin_C3Mech02_AttackPatternActionData : CVscComponentData
    {
        public enum ENewEnum18_id_ejsfjzh4
        {
            None = 0,
            ChinGunShoot = 1,
            SideGunLeftShoot = 2,
            SideGunRightShoot = 3,
            MissileShoot = 4,
        }

        [FieldAttr(nst: 40, ctr: 32)] public ENewEnum18_id_ejsfjzh4 _NewEnum18_id_ejsfjzh4;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float;
    }
}
