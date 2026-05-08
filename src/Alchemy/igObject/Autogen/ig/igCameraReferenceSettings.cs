namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 80, align: 16)]
    public class igCameraReferenceSettings : igObject
    {
        public enum EZoomSelectionOptions
        {
            kZoomSelObjectCenter = 1,
            kZoomSelMouseLocation = 2,
            kZoomSelViewCenter = 3,
        }

        public enum EZoomNoSelectionOptions
        {
            kZoomNoSelMouseLocation = 2,
            kZoomNoSelViewCenter = 3,
        }

        public enum ERotateSelectionOptions
        {
            kRotateSelObjectCenter = 1,
            kRotateSelMouseLocation = 2,
            kRotateSelWorldOrigin = 4,
        }

        public enum ERotateNoSelectionOptions
        {
            kRotateNoSelMouseLocation = 2,
            kRotateNoSelWorldOrigin = 4,
        }

        public enum EPanSelectionOptions
        {
            kPanSelObjectCenter = 1,
            kPanSelMouseLocation = 2,
        }

        public enum EPanNoSelectionOptions
        {
            kPanNoSelMouseLocation = 2,
        }

        [FieldAttr(nst: 16, ctr: 12)] public EZoomSelectionOptions _zoomSelectionMode = igCameraReferenceSettings.EZoomSelectionOptions.kZoomSelMouseLocation;
        [FieldAttr(nst: 20, ctr: 16)] public EZoomNoSelectionOptions _zoomNoSelectionMode = igCameraReferenceSettings.EZoomNoSelectionOptions.kZoomNoSelMouseLocation;
        [FieldAttr(nst: 24, ctr: 20)] public ERotateSelectionOptions _rotateSelectionMode = igCameraReferenceSettings.ERotateSelectionOptions.kRotateSelObjectCenter;
        [FieldAttr(nst: 28, ctr: 24)] public ERotateNoSelectionOptions _rotateNoSelectionMode = igCameraReferenceSettings.ERotateNoSelectionOptions.kRotateNoSelMouseLocation;
        [FieldAttr(nst: 32, ctr: 28)] public EPanSelectionOptions _panSelectionMode = igCameraReferenceSettings.EPanSelectionOptions.kPanSelObjectCenter;
        [FieldAttr(nst: 36, ctr: 32)] public EPanNoSelectionOptions _panNoSelectionMode = igCameraReferenceSettings.EPanNoSelectionOptions.kPanNoSelMouseLocation;
        [FieldAttr(nst: 40, ctr: 36)] public bool _drawReferencePoint = true;
        [FieldAttr(nst: 48, ctr: 48)] public igVec4fMetaField _referencePointColor = new();
        [FieldAttr(nst: 64, ctr: 64)] public float _referencePointPixelSize = 20.0f;
    }
}
