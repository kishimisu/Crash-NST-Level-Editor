using Alchemy;

// Working:
// - selecting objects                       (gizmo/gui) [including multi-select & box selection]
// - translate/rotate/scale entities         (gizmo/gui) [including crate snapping + templates & splines]
// - translate/rotate cameras                (gizmo/gui)
// - translate/rotate* spline points         (gizmo/gui) *issue with redo
// - rotate* spline rotations                (gizmo/gui) *missing 'distance' & 'set from camera'
// - translate/rotate/resize dynamic clips   (gizmo/gui)
// - translate/rotate/resize script triggers (gizmo/gui)
// - translate/rotate/resize camera boxes    (gizmo/gui)
// - move selection (ctrl+shift+x)

// Missing (gui):
// - trigger volumes, audio boxes, visual boxes, box lights, point lights, tint lights

// Not planned:
// - copy/pasting objects
// - creating new objects
// - deleting objects
// - editing components
// - editing any property other than the position, rotation, scale or bounds (min/max)

namespace NST
{
    public class UndoManager
    {
        public enum UndoActionType { Select, Transform }

        public class UndoAction
        {
            public string Mode;
            public UndoActionType Type;
            public List<NSTObject> Objects;

            public THREE.Vector3 Position = new();
            public THREE.Quaternion Quaternion = new();
            public THREE.Vector3 Scale = new();
            public THREE.Box3? BoundsBefore = null;
            public THREE.Box3? BoundsAfter = null;

            public void Undo(SelectionManager manager, THREE.Vector3 scale, string mode)
            {
                manager.UpdateSelection(Objects);
                manager.UpdateScaleTransform(scale, false);

                manager.SelectionContainer.Position.Copy(Position);
                manager.SelectionContainer.Quaternion.Copy(Quaternion);
                manager.SelectionContainer.Scale.Set(1, 1, 1);

                manager.ApplyChanges(mode, false, scale);
            }

            public void UndoBounds(SelectionManager manager, bool redo = false)
            {
                var bounds = redo ? BoundsAfter : BoundsBefore;

                if (bounds == null || Objects.Count == 0) return;

                igObject obj = Objects[0].GetObject();

                if (obj is CScriptTriggerEntity trigger)
                {
                    trigger._min = bounds.Min.ToVec3MetaField();
                    trigger._max = bounds.Max.ToVec3MetaField();
                }
                else if (obj is CDynamicClipEntity clip)
                {
                    clip._min = bounds.Min.ToVec3MetaField();
                    clip._max = bounds.Max.ToVec3MetaField();
                }
                else if (obj is CCameraBox cameraBox)
                {
                    cameraBox._min = bounds.Min.ToVec3MetaField();
                    cameraBox._max = bounds.Max.ToVec3MetaField();
                }

                manager.UpdateSelection(Objects);
            }

            public string Print(bool undo = true)
            {
                string prefix = undo ? "Undo" : "Redo";
                string objects = Objects.Count == 1 ? "object" : $"{Objects.Count} objects";

                if (Type == UndoActionType.Select)
                {
                    if (Objects.Count == 0)
                        return $"{prefix} select object";

                    return $"{prefix} select {objects}";
                }

                return $"{prefix} {Mode} {objects}";
            }
        }
        
        const int MAX_HISTORY = 50;

        private List<UndoAction> _history = 
        [ 
            new UndoAction() { Type = UndoActionType.Select, Objects = [] } 
        ];

        private int _index = 1;
        private readonly LevelExplorer _explorer;

        public UndoManager(LevelExplorer explorer) => _explorer = explorer;

        public void AddAction(UndoActionType type, string mode = "", THREE.Box3? bounds = null)
        {
            SelectionManager manager = _explorer.SelectionManager;
            List<NSTObject> objects = manager.Selection.ToList();

            var action = new UndoAction()
            {
                Type = type,
                Objects = objects,
                Mode = mode,
                BoundsBefore = bounds
            };

            action.Position.Copy(manager.SelectionContainer.Position);
            action.Quaternion.Copy(manager.SelectionContainer.Quaternion);
            action.Scale.Copy(manager.SelectionContainer.Scale);

            // Prevent adding duplicate actions
            if (type == UndoActionType.Select && _index > 0 && objects.Count == _history[_index-1].Objects.Count)
            {
                bool valid = false;

                for (int i = 0; i < objects.Count; i++)
                {
                    if (objects[i] != _history[_index-1].Objects[i])
                    {
                        valid = true;
                        break;
                    }
                }
                
                if (!valid) return;
            }

            _history = _history.Slice(0, _index);
            _history.Add(action);

            if (_history.Count <= MAX_HISTORY)
            {
                _index++;
            }
            else
            {
                _history = _history.Skip(1).ToList();
            }
        }

        public void FinalizeBoundsAction(THREE.Box3 boundsAfter)
        {
            _history[_history.Count - 1].BoundsAfter = boundsAfter;
        }

        public void Undo()
        {
            _index--;

            if (_index <= 0 || _index-1 >= _history.Count)
            {
                _index = 1;
                _explorer.Notify("Nothing to undo!");
                return;
            }

            var undoAction = _history[_index - 1];
            var lastAction = _history[_index];

            if (lastAction.BoundsBefore == null)
            {
                undoAction.Undo(_explorer.SelectionManager, THREE.Vector3.One() / lastAction.Scale, lastAction.Mode);
            }
            else
            {
                lastAction.UndoBounds(_explorer.SelectionManager);
            }

            _explorer.Notify(lastAction.Print(true));
        }

        public void Redo()
        {
            _index++;

            if (_index-1 >= _history.Count)
            {
                _index = _history.Count;
                _explorer.Notify("Nothing to redo!");
                return;
            }

            var action = _history[_index - 1];

            if (action.BoundsBefore == null)
            {
                action.Undo(_explorer.SelectionManager, action.Scale, action.Mode);
            }
            else
            {
                action.UndoBounds(_explorer.SelectionManager, true);
            }

            _explorer.Notify(action.Print(false));
        }
    }
}