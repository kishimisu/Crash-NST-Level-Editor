namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CAttachmentSpline : igSpline
    {
        [FieldAttr(64)] public CAttachmentSplineAttachmentList? _spawnedAttachments;
        [FieldAttr(72)] public CAttachmentSplineAttachmentList? _attachmentsQueue;
        [FieldAttr(80)] public bool _allCoinsCollected = true;
    }
}
