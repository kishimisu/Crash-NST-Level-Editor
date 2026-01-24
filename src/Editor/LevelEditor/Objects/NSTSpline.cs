using Alchemy;
using ImGuiNET;

namespace NST
{
    public class NSTSpline : NSTObject<igSpline2>
    {
        public NSTEntity Parent { get; }
        public THREE.Color Color;

        public THREE.Object3D? Rotations3D;
        public THREE.Object3D? Markers3D;

        public List<NSTSplineControlPoint> _controlPoints = [];
        public List<NSTSplineRotationKeyFrame> _rotationKeyFrames = [];
        public List<NSTSplineVelocityKeyFrame> _velocityKeyFrames = [];
        public List<NSTSplineMarker> _markers = [];
        private NSTSplineControlPoint? _selectedControlPoint;
        private NSTSplineRotationKeyFrame? _selectedRotationKeyFrame;

        private igSplineRotationKeyframeTrack? _rotationTrack;
        private igSplineFloatKeyframeTrack? _velocityTrack;

        public bool OpenControlPointList { get; set; } = false;
        public bool OpenRotationList { get; set; } = false;
        public bool OpenVelocityList { get; set; } = false;
        public bool OpenMarkerList { get; set; } = false;
        private bool _isRotationListOpen = false;
        private bool _isVelocityListOpen = false;
        private bool _isMarkerListOpen = false;

        public NSTSpline(NSTEntity parent, igSpline2 spline)
        {
            Parent = parent;
            Object = spline;
            ArchiveFile = parent.ArchiveFile;

            uint hash = NamespaceUtils.ComputeHash(spline.ObjectName ?? spline.GetType().Name);
            Color = new THREE.Color((int)hash);
            Color.R = Color.R * 0.5f + 0.5f;
            Color.G = Color.G * 0.5f + 0.5f;
            Color.B = Color.B * 0.5f + 0.5f;

            bool hasData = SetupControlPoints();

            if (hasData)
            {
                SetupRotationKeyFrames();
                SetupVelocityKeyFrames();
                SetupMarkers();
                ComputeDistances();
            }
        }

        private bool SetupControlPoints()
        {
            if (Object._data == null || Object._data._data.Count == 0) return false;

            foreach (igSplineControlPoint2 point in Object._data._data)
            {
                var controlPoint = new NSTSplineControlPoint(this, point);
                _controlPoints.Add(controlPoint);
            }

            return true;
        }

        private void SetupRotationKeyFrames()
        {
            if (Object._rotationTracks == null || Object._rotationTracks.Dict.Count == 0) return;

            _rotationKeyFrames.Clear();

            foreach (igSplineRotationKeyframeTrack track in Object._rotationTracks.Dict.Values)
            {
                if (track._data?._data == null || track._data._data.Count == 0) continue;
                if (track._data._data[0].GetType() != typeof(CSplineRotationKeyframe)) continue;

                foreach (CSplineRotationKeyframe rotation in track._data._data)
                {
                    _rotationKeyFrames.Add(new NSTSplineRotationKeyFrame(this, rotation));
                }

                _rotationTrack = track;

                break;
            }

            _rotationKeyFrames.Sort((a, b) => (int)(a.Object._distance - b.Object._distance));
        }

        private void SetupVelocityKeyFrames()
        {
            if (Object._floatTracks == null || Object._floatTracks.Dict.Count == 0) return;

            _velocityKeyFrames.Clear();

            foreach (igSplineFloatKeyframeTrack track in Object._floatTracks.Dict.Values)
            {
                if (track._data?._data == null || track._data._data.Count == 0) continue;
                if (track._data._data[0].GetType() != typeof(CSplineVelocityKeyframe)) continue;

                foreach (CSplineVelocityKeyframe rotation in track._data._data)
                {
                    _velocityKeyFrames.Add(new NSTSplineVelocityKeyFrame(this, rotation));
                }

                _velocityTrack = track;

                break;
            }

            _velocityKeyFrames.Sort((a, b) => (int)(a.Object._distance - b.Object._distance));
        }

        private void SetupMarkers()
        {
            if (Object._events?._data == null || Object._events._data._data.Count == 0) return;

            _markers.Clear();

            foreach (igSplineEvent marker in Object._events._data._data)
            {
                _markers.Add(new NSTSplineMarker(this, marker));
            }

            _markers.Sort((a, b) => (int)(a.Object._distance - b.Object._distance));
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            List<THREE.Vector3> controlPoints = _controlPoints.Select(p => p.Object._position.ToVector3()).ToList();

            if (Object._looping)
            {
                controlPoints.Add(controlPoints[0]);
            }

            var lineMesh = CreateLineMesh(controlPoints);
            var pointMesh = CreateControlPointsMesh(controlPoints);

            Rotations3D = CreateRotationKeyFramesMesh();
            Markers3D = CreateMarkersMesh();

            lineMesh.Add(pointMesh);

            if (selected)
            {
                if (Rotations3D != null && _isRotationListOpen)
                {
                    lineMesh.Add(Rotations3D);
                }
                if (Markers3D != null && _isMarkerListOpen)
                {
                    lineMesh.Add(Markers3D);
                }
            }

            lineMesh.ApplyMatrix4(Parent.ObjectToWorld());

            if (!selected && !_controlPoints.Any(e => e.Object3D != null))
            {
                lineMesh.Traverse(e => e.Layers.Set((int)LevelExplorer.CameraLayer.Splines));
            }

            pointMesh.Traverse(e => e.UserData["spline"] = this);

            Object3D = lineMesh;

            // OpenControlPointList = _controlPoints.Any(e => e.IsSelected);

            return lineMesh;
        }

        private THREE.Object3D CreateLineMesh(List<THREE.Vector3> points)
        {
            var lineGeometry = new THREE.BufferGeometry();
            var lineMaterial = new THREE.LineBasicMaterial() { Color = Color, LineWidth = 2 };

            float[] positions = points.SelectMany(p => new float[] { p.X, p.Y, p.Z }).ToArray();

            lineGeometry.SetAttribute("position", new THREE.BufferAttribute<float>(positions, 3));
            lineGeometry.ComputeBoundingSphere();

            return new THREE.Line(lineGeometry, lineMaterial);
        }

        private THREE.InstancedMesh CreateControlPointsMesh(List<THREE.Vector3> points)
        {
            var sphereGeo = new THREE.SphereGeometry(8, 10, 10);
            var controlPointsMat = new THREE.MeshBasicMaterial() { Color = Color };

            var instancedMesh = new THREE.InstancedMesh(sphereGeo, controlPointsMat, points.Count) { FrustumCulled = false };

            for (int i = 0; i < points.Count; i++)
            {
                instancedMesh.SetMatrixAt(i, new THREE.Matrix4().SetPosition(points[i]));
            }

            return instancedMesh;
        }

        private THREE.Group? CreateRotationKeyFramesMesh()
        {
            if (_rotationKeyFrames.Count == 0) return null;

            THREE.Group group = new THREE.Group();

            foreach (NSTSplineRotationKeyFrame keyframe in _rotationKeyFrames)
            {
                if (keyframe.IsSelected) continue;
                group.Add(keyframe.CreateObject3D());
            }

            group.Traverse(e => e.UserData["excludeFromOutline"] = true);

            return group;
        }

        private THREE.Group? CreateMarkersMesh()
        {
            if (_markers.Count == 0) return null;

            THREE.Group group = new THREE.Group();

            foreach (NSTSplineMarker marker in _markers)
            {
                if (marker.IsSelected) continue;
                group.Add(marker.CreateObject3D());
            }

            return group;
        }

        // todo: optimize
        public void ComputeDistances(LevelExplorer? explorer = null, bool updateObject = false)
        {
            foreach (NSTSplineRotationKeyFrame keyFrame in _rotationKeyFrames)
            {
                float totalDistance = 0;
                
                for (int i = 0; i < _controlPoints.Count - 1; i++)
                {
                    float dist = _controlPoints[i].Object._position.ToVector3().DistanceTo(_controlPoints[i + 1].Object._position.ToVector3());

                    if (totalDistance + dist >= keyFrame.Object._distance || i == _controlPoints.Count - 2)
                    {
                        float k = (keyFrame.Object._distance - totalDistance) / dist;
                        THREE.Vector3 midPoint =_controlPoints[i].Object._position.ToVector3().Lerp(_controlPoints[i + 1].Object._position.ToVector3(), k);

                        keyFrame.Position = midPoint;
                        keyFrame.Prev = _controlPoints[i];
                        keyFrame.Next = _controlPoints[i + 1];
                        keyFrame.LocalDistance = k;
                        break;
                    }
                    totalDistance += dist;
                }
            }
            
            foreach (NSTSplineVelocityKeyFrame vel in _velocityKeyFrames)
            {
                float totalDistance = 0;

                for (int i = 0; i < _controlPoints.Count - 1; i++)
                {
                    float dist = _controlPoints[i].Object._position.ToVector3().DistanceTo(_controlPoints[i + 1].Object._position.ToVector3());

                    if (totalDistance + dist >= vel.Object._distance || i == _controlPoints.Count - 2)
                    {
                        float k = (vel.Object._distance - totalDistance) / dist;
                        THREE.Vector3 midPoint =_controlPoints[i].Object._position.ToVector3().Lerp(_controlPoints[i + 1].Object._position.ToVector3(), k);
                        vel.Position = midPoint;
                        break;
                    }
                    totalDistance += dist;
                }
            }

            foreach (NSTSplineMarker marker in _markers)
            {
                float totalDistance = 0;
                
                for (int i = 0; i < _controlPoints.Count - 1; i++)
                {
                    float dist = _controlPoints[i].Object._position.ToVector3().DistanceTo(_controlPoints[i + 1].Object._position.ToVector3());

                    if (totalDistance + dist >= marker.Object._distance || i == _controlPoints.Count - 2)
                    {
                        float k = (marker.Object._distance - totalDistance) / dist;
                        THREE.Vector3 midPoint =_controlPoints[i].Object._position.ToVector3().Lerp(_controlPoints[i + 1].Object._position.ToVector3(), k);
                        marker.Position = midPoint;
                        break;
                    }
                    totalDistance += dist;
                }
            }

            if (updateObject && explorer != null)
            {
                float totalDistance = 0;
            
                for (int i = 0; i < _controlPoints.Count - 1; i++)
                {
                    float dist = _controlPoints[i].Object._position.ToVector3().DistanceTo(_controlPoints[i + 1].Object._position.ToVector3());
                    totalDistance += dist;
                }

                // Console.WriteLine($"Updated distance from {Object._length} to {totalDistance}");

                Object._length = totalDistance;
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object);
            }
        }

        public void RefreshDistances(LevelExplorer explorer)
        {
            Dictionary<NSTSplineControlPoint, float> distances = [];

            float distance = 0;
            distances.Add(_controlPoints[0], distance);
            for (int i = 0; i < _controlPoints.Count - 1; i++)
            {
                NSTSplineControlPoint point = _controlPoints[i];
                NSTSplineControlPoint next = _controlPoints[i + 1];

                distance += point.Object._position.ToVector3().DistanceTo(next.Object._position.ToVector3());
                distances.Add(next, distance);
            }

            foreach (NSTSplineRotationKeyFrame keyFrame in _rotationKeyFrames)
            {
                float prevDist = distances[keyFrame.Prev];
                float nextDist = distances[keyFrame.Next];
                keyFrame.Object._distance = prevDist + (nextDist - prevDist) * keyFrame.LocalDistance;
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, keyFrame.Object);
            }
        }

        private NSTSplineControlPoint CreateNewControlPoint(LevelExplorer explorer, int index, bool insertBefore = false)
        {
            IgzFile igz = explorer.FileManager.GetIgz(ArchiveFile)!;
            var newObject = igz.AddClone(_controlPoints[index].Object);
            var newControlPoint = new NSTSplineControlPoint(this, newObject);

            int insertionIndex = int.Clamp(insertBefore ? index : index + 1, 0, _controlPoints.Count);
            
            if (_controlPoints.Count > 1)
            {
                THREE.Vector3 newPosition;

                if (insertBefore)
                {
                    if (index <= 0) newPosition = _controlPoints[0].Object._position.ToVector3() * 2 - _controlPoints[1].Object._position.ToVector3();
                    else newPosition = (_controlPoints[index].Object._position.ToVector3() + _controlPoints[index - 1].Object._position.ToVector3()) * 0.5f;
                }
                else
                {
                    if (index >= _controlPoints.Count - 1) newPosition = _controlPoints[_controlPoints.Count - 1].Object._position.ToVector3() * 2 - _controlPoints[_controlPoints.Count - 2].Object._position.ToVector3();
                    else newPosition = (_controlPoints[index].Object._position.ToVector3() + _controlPoints[index + 1].Object._position.ToVector3()) * 0.5f;
                }

                newObject._position = newPosition.ToVec3MetaField();
            }

            Object._data!._data.Insert(insertionIndex, newObject);
            _controlPoints.Insert(insertionIndex, newControlPoint);
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object._data, true);
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, newObject);

            if (index == 0 && insertBefore)
            {
                RefreshDistances(explorer);
            }

            ComputeDistances(explorer, true);

            if (!Parent.IsSelected)
            {
                RefreshSpline();
            }

            return newControlPoint;
        }

        private NSTSplineRotationKeyFrame CreateNewRotationKeyFrame(LevelExplorer explorer, int index, bool insertBefore = false)
        {
            IgzFile igz = explorer.FileManager.GetIgz(ArchiveFile)!;
            var newObject = igz.AddClone(_rotationKeyFrames[index].Object);
            var newRotationKeyframe = new NSTSplineRotationKeyFrame(this, newObject);

            int insertionIndex = int.Clamp(insertBefore ? index : index + 1, 0, _rotationKeyFrames.Count);

            if (_rotationKeyFrames.Count > 1)
            {
                if (insertBefore)
                {
                    if (index <= 0) newObject._distance = _rotationKeyFrames[0].Object._distance * 0.5f;
                    else newObject._distance = (_rotationKeyFrames[index].Object._distance + _rotationKeyFrames[index - 1].Object._distance) * 0.5f;
                }
                else
                {
                    if (index >= _rotationKeyFrames.Count - 1) newObject._distance = _rotationKeyFrames[_rotationKeyFrames.Count - 1].Object._distance + 200;
                    else newObject._distance = (_rotationKeyFrames[index].Object._distance + _rotationKeyFrames[index + 1].Object._distance) * 0.5f;
                }
            }

            _rotationTrack!._data!._data.Insert(insertionIndex, newObject);
            _rotationKeyFrames.Insert(insertionIndex, newRotationKeyframe);
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, _rotationTrack._data, true);
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, newObject);

            ComputeDistances(explorer, true);

            if (!Parent.IsSelected)
            {
                RefreshSpline();
            }

            return newRotationKeyframe;
        }

        private NSTSplineVelocityKeyFrame CreateNewVelocityKeyFrame(LevelExplorer explorer, int index, bool insertBefore = false)
        {
            IgzFile igz = explorer.FileManager.GetIgz(ArchiveFile)!;
            var newObject = igz.AddClone(_velocityKeyFrames[index].Object);
            var newVelocity = new NSTSplineVelocityKeyFrame(this, newObject);

            int insertionIndex = int.Clamp(insertBefore ? index : index + 1, 0, _velocityKeyFrames.Count);

            if (_velocityKeyFrames.Count > 1)
            {
                if (insertBefore)
                {
                    if (index <= 0) newObject._distance = _velocityKeyFrames[0].Object._distance * 0.5f;
                    else newObject._distance = (_velocityKeyFrames[index].Object._distance + _velocityKeyFrames[index - 1].Object._distance) * 0.5f;
                }
                else
                {
                    if (index >= _velocityKeyFrames.Count - 1) newObject._distance = _velocityKeyFrames[_velocityKeyFrames.Count - 1].Object._distance + 200;
                    else newObject._distance = (_velocityKeyFrames[index].Object._distance + _velocityKeyFrames[index + 1].Object._distance) * 0.5f;
                }
            }

            _velocityTrack!._data!._data.Insert(insertionIndex, newObject);
            _velocityKeyFrames.Insert(insertionIndex, newVelocity);
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, _velocityTrack._data, true);
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, newObject);

            ComputeDistances(explorer, true);

            if (!Parent.IsSelected)
            {
                RefreshSpline();
            }

            return newVelocity;
        }

        private NSTSplineMarker CreateNewMarker(LevelExplorer explorer, int index, bool insertBefore = false)
        {
            IgzFile igz = explorer.FileManager.GetIgz(ArchiveFile)!;
            var newObject = igz.AddClone(_markers[index].Object);
            var newMarker = new NSTSplineMarker(this, newObject);

            int insertionIndex = int.Clamp(insertBefore ? index : index + 1, 0, _markers.Count);

            if (_markers.Count > 1)
            {
                if (insertBefore)
                {
                    if (index <= 0) newObject._distance = _markers[0].Object._distance * 0.5f;
                    else newObject._distance = (_markers[index].Object._distance + _markers[index - 1].Object._distance) * 0.5f;
                }
                else
                {
                    if (index >= _markers.Count - 1) newObject._distance = _markers[_markers.Count - 1].Object._distance + 200;
                    else newObject._distance = (_markers[index].Object._distance + _markers[index + 1].Object._distance) * 0.5f;
                }
            }

            Object._events!._data!._data.Insert(insertionIndex, newObject);
            _markers.Insert(insertionIndex, newMarker);
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object._events._data, true);
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, newObject);

            ComputeDistances(explorer, true);

            if (!Parent.IsSelected)
            {
                RefreshSpline();
            }

            return newMarker;
        }

        private void RefreshControlPoint(NSTSplineControlPoint point, THREE.Vector3 previousPosition, LevelExplorer explorer)
        {
            RefreshDistances(explorer);
            ComputeDistances(explorer, true);

            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, point.Object);

            RefreshSpline();
            explorer.RenderNextFrame = true;

            if (explorer.SelectionManager._selection.Count == 0) return;
            
            // Multi-select translation
            if (point.IsSelected)
            {
                THREE.Vector3 offset = point.Object._position.ToVector3() - previousPosition;

                foreach (NSTObject obj in explorer.SelectionManager._selection)
                {
                    if (obj is not NSTSplineControlPoint cp || cp.Parent != this || cp == point) continue;

                    cp.Object._position._x += offset.X;
                    cp.Object._position._y += offset.Y;
                    cp.Object._position._z += offset.Z;
                }
            }

            // Refresh 3D selection
            if (explorer.SelectionManager._selection[0] is NSTSplineControlPoint root && root.Parent == this)
            {
                explorer.SelectionManager._selectionContainer.Position.Copy(root.Object._position.ToVector3().ApplyMatrix4(Parent.ObjectToWorld()));
            }
        }

        private void RefreshRotationKeyFrame(NSTSplineRotationKeyFrame keyframe, THREE.Vector3 previousRotation, LevelExplorer explorer)
        {
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, keyframe.Object);

            RefreshSpline();
            explorer.RenderNextFrame = true;

            if (explorer.SelectionManager._selection.Count == 0 || !keyframe.IsSelected) return;

            THREE.Vector3 offset = keyframe.Object._value.ToVector3() - previousRotation;

            // Multi-select rotation
            foreach (NSTObject obj in explorer.SelectionManager._selection)
            {
                if (obj is not NSTSplineRotationKeyFrame kf || kf.Parent != this || kf == keyframe) continue;

                kf.Object._value._x += offset.X;
                kf.Object._value._y += offset.Y;
                kf.Object._value._z += offset.Z;
            }

            explorer.SelectionManager.UpdateSelection(explorer.SelectionManager._selection.Where(e => e is NSTSplineRotationKeyFrame kf && kf.Parent == this).ToList());
        }

        private void RefreshVelocity(NSTSplineVelocityKeyFrame vel, LevelExplorer explorer)
        {
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, vel.Object);

            ComputeDistances(explorer, true);
            RefreshSpline();
            explorer.RenderNextFrame = true;

            if (explorer.SelectionManager._selection.Count == 0 || !vel.IsSelected) return;
            if (explorer.SelectionManager._selection[0] is NSTSplineVelocityKeyFrame root && root.Parent == this)
            {
                explorer.SelectionManager.UpdateSelection([root]);
            }
        }

        private void RefreshMarker(NSTSplineMarker marker, LevelExplorer explorer)
        {
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, marker.Object);

            ComputeDistances(explorer, true);
            RefreshSpline();
            explorer.RenderNextFrame = true;

            if (explorer.SelectionManager._selection.Count == 0 || !marker.IsSelected) return;
            if (explorer.SelectionManager._selection[0] is NSTSplineMarker root && root.Parent == this)
            {
                explorer.SelectionManager.UpdateSelection([root]);
            }
        }

        public void RefreshSpline()
        {
            if (Object3D == null) return;
            var p = Object3D.Parent;
            p.Remove(Object3D);
            p.Attach(CreateObject3D(Parent.IsSelected));
        }

        public void DeleteObjects(LevelExplorer explorer, List<NSTObject> objects)
        {
            List<NSTSplineControlPoint> controlPoints = [];
            List<NSTSplineRotationKeyFrame> rotationKeyFrames = [];
            List<NSTSplineVelocityKeyFrame> velocityKeyFrames = [];
            List<NSTSplineMarker> markers = [];

            foreach (NSTObject obj in objects)
            {
                if (obj is NSTSplineControlPoint controlPoint) controlPoints.Add(controlPoint);
                if (obj is NSTSplineRotationKeyFrame rotationKeyFrame) rotationKeyFrames.Add(rotationKeyFrame);
                if (obj is NSTSplineVelocityKeyFrame velocityKeyFrame) velocityKeyFrames.Add(velocityKeyFrame);
                if (obj is NSTSplineMarker marker) markers.Add(marker);
            }

            IgzFile igz = explorer.FileManager.GetIgz(ArchiveFile)!;

            foreach (NSTSplineControlPoint controlPoint in controlPoints)
            {
                _controlPoints.Remove(controlPoint);
                igz.Remove(controlPoint.Object);
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object._data, true);
            }

            foreach (NSTSplineRotationKeyFrame rotationKeyFrame in rotationKeyFrames)
            {
                _rotationKeyFrames.Remove(rotationKeyFrame);
                igz.Remove(rotationKeyFrame.Object);
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, _rotationTrack!._data, true);
            }

            foreach (NSTSplineVelocityKeyFrame velocityKeyFrame in velocityKeyFrames)
            {
                _velocityKeyFrames.Remove(velocityKeyFrame);
                igz.Remove(velocityKeyFrame.Object);
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, _velocityTrack!._data, true);
            }

            foreach (NSTSplineMarker marker in markers)
            {
                _markers.Remove(marker);
                igz.Remove(marker.Object);
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object._events?._data, true);
            }

            ComputeDistances(explorer, true);

            foreach (NSTSplineRotationKeyFrame keyFrame in _rotationKeyFrames.ToList())
            {
                if (keyFrame.LocalDistance < 0.0f || keyFrame.LocalDistance > 1.0f)
                {
                    _rotationKeyFrames.Remove(keyFrame);
                    igz.Remove(keyFrame.Object);
                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, _rotationTrack!._data, true);
                }
            }

            RefreshSpline();
        }

        public override void Render(LevelExplorer explorer)
        {
            if (Object._data == null || Object._data._data.Count == 0)
            {
                ImGui.Text("Spline is empty");
                return;
            }

            ImGui.TextDisabled("Right click to add new elements (?)");
            if (ImGui.IsItemHovered() && ImGui.BeginTooltip())
            {
                ImGui.Text("GUI controls:");
                ImGui.BulletText("Click any item to select it.");
                ImGui.BulletText("Shift+click: select range (position & rotation only)");
                ImGui.BulletText("Ctrl+click: add/remove from selection");
                ImGui.BulletText("Suppr/Del: delete selection");
                ImGui.Separator();
                ImGui.BulletText("Right click: add new items");
                ImGui.BulletText("Double click: focus in the scene");
                ImGui.BulletText("Click and drag to edit number fields");
                ImGui.EndTooltip();
            }

            // float distance = 0.0f;
            // for (int i = 0; i < Object._data._data.Count - 1; i++)
            // {
            //     igSplineControlPoint2 point = Object._data._data[i];
            //     igSplineControlPoint2 nextPoint = Object._data._data[i + 1];
            //     distance += (point._position.ToVector3() - nextPoint._position.ToVector3()).Length();
            // }
            // ImGui.Text($"Distance: {distance}");

            // Render positions

            if (OpenControlPointList)
            {
                ImGui.SetNextItemOpen(true);
                OpenControlPointList = false;
            }

            float indexWidth = ImGui.CalcTextSize("999.").X;
            var tableFlags = ImGuiTableFlags.BordersOuterH | ImGuiTableFlags.BordersInnerV | ImGuiTableFlags.NoBordersInBody;
            var selectableFlags = ImGuiSelectableFlags.AllowDoubleClick | ImGuiSelectableFlags.AllowOverlap | ImGuiSelectableFlags.SpanAllColumns;

            if (ImGui.TreeNodeEx($"Positions ({_controlPoints.Count})###Positions", ImGuiTreeNodeFlags.NoTreePushOnOpen) && ImGui.BeginTable("PositionTable", 4, tableFlags))
            {
                ImGui.TableSetupColumn("id", ImGuiTableColumnFlags.WidthFixed, indexWidth);
                ImGui.TableSetupColumn("x", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("y", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("z", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableHeadersRow();

                ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(0, 0));

                for (int i = 0; i < _controlPoints.Count; i++)
                {
                    NSTSplineControlPoint controlPoint = _controlPoints[i];
                    THREE.Vector3 previousPosition = controlPoint.Object._position.ToVector3();

                    ImGui.TableNextColumn();
                    if (ImGui.Selectable($"{i+1}##pid", controlPoint.IsSelected, selectableFlags))
                    {
                        // Double click: focus object
                        if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                        {
                            explorer.LookAtObject(controlPoint);
                        }
                        // Shift: select range
                        else if (ImGui.IsKeyDown(ImGuiKey.LeftShift) && _selectedControlPoint != null)
                        {
                            int lastIndex = _controlPoints.IndexOf(_selectedControlPoint);
                            int startIndex = int.Min(i, lastIndex + 1);
                            int count = int.Abs(i - lastIndex);
                            var added = _controlPoints.GetRange(startIndex, count).Where(e => !e.IsSelected).Cast<NSTObject>().ToList();

                            explorer.SelectionManager.UpdateSelection(added, false);
                            explorer.RenderNextFrame = true;
                        }
                        // Single selection
                        else
                        {
                            bool ctrlPressed = ImGui.IsKeyDown(ImGuiKey.LeftCtrl);
                            explorer.SelectionManager.UpdateSelection([controlPoint.IsSelected && !ctrlPressed ? Parent : controlPoint], !ctrlPressed);
                            explorer.RenderNextFrame = true;
                            _selectedControlPoint = controlPoint;
                            OpenControlPointList = true;
                        }
                    }

                    if (ImGui.BeginPopupContextItem($"PositionActions{i}"))
                    {
                        if (ImGui.Selectable("Create new (before)"))
                        {
                            OpenControlPointList = true;
                            explorer.SelectionManager.UpdateSelection([CreateNewControlPoint(explorer, i, true)]);
                        }
                        if (ImGui.Selectable("Create new (after)"))
                        {
                            OpenControlPointList = true;
                            explorer.SelectionManager.UpdateSelection([CreateNewControlPoint(explorer, i, false)]);
                        }
                        ImGui.EndPopup();
                    }

                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat($"##px{i}", ref controlPoint.Object._position._x)) RefreshControlPoint(controlPoint, previousPosition, explorer);
                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat($"##py{i}", ref controlPoint.Object._position._y)) RefreshControlPoint(controlPoint, previousPosition, explorer);
                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat($"##pz{i}", ref controlPoint.Object._position._z)) RefreshControlPoint(controlPoint, previousPosition, explorer);
                }
                ImGui.PopStyleVar();
                ImGui.EndTable();
                ImGui.Spacing();
            }

            // Render rotations

            if (OpenRotationList)
            {
                ImGui.SetNextItemOpen(true);
                OpenRotationList = false;
            }

            bool prevOpen = _isRotationListOpen;
            _isRotationListOpen = _rotationKeyFrames.Count > 0 && ImGui.TreeNodeEx($"Rotations ({_rotationKeyFrames.Count})###Rotations", ImGuiTreeNodeFlags.NoTreePushOnOpen);

            if (prevOpen != _isRotationListOpen && Object3D != null && Rotations3D != null)
            {
                if (_isRotationListOpen) Object3D.Add(Rotations3D);
                else Object3D.Remove(Rotations3D);
                explorer.RenderNextFrame = true;
            }

            if (_isRotationListOpen && ImGui.BeginTable("RotationTable", 5, tableFlags))
            {
                ImGui.TableSetupColumn("id", ImGuiTableColumnFlags.WidthFixed, indexWidth);
                ImGui.TableSetupColumn("distance", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("x", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("y", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("z", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableHeadersRow();

                ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(2.0f, 0.0f));

                for (int i = 0; i < _rotationKeyFrames.Count; i++)
                {
                    NSTSplineRotationKeyFrame keyframe = _rotationKeyFrames[i];
                    THREE.Vector3 previousRotation = keyframe.Object._value.ToVector3();

                    ImGui.TableNextColumn();
                    if (ImGui.Selectable($"{i+1}##rid", keyframe.IsSelected, selectableFlags))
                    {
                        if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                        {
                            explorer.LookAtObject(keyframe);
                        }
                        else if (ImGui.IsKeyDown(ImGuiKey.LeftShift) && _selectedRotationKeyFrame != null)
                        {
                            int lastIndex = _rotationKeyFrames.IndexOf(_selectedRotationKeyFrame);
                            int startIndex = int.Min(i, lastIndex + 1);
                            int count = int.Abs(i - lastIndex);
                            var added = _rotationKeyFrames.GetRange(startIndex, count).Where(e => !e.IsSelected).Cast<NSTObject>().ToList();

                            explorer.SelectionManager.UpdateSelection(added, false);
                            explorer.RenderNextFrame = true;
                        }
                        else
                        {
                            bool ctrlPressed = ImGui.IsKeyDown(ImGuiKey.LeftCtrl);
                            explorer.SelectionManager.UpdateSelection([keyframe.IsSelected && !ctrlPressed ? Parent : keyframe], !ctrlPressed);
                            explorer.RenderNextFrame = true;
                            _selectedRotationKeyFrame = keyframe;
                            OpenRotationList = true;
                        }
                    }

                    if (ImGui.BeginPopupContextItem($"RotationActions{i}"))
                    {
                        if (ImGui.Selectable("Create new (before)"))
                        {
                            OpenRotationList = true;
                            explorer.SelectionManager.UpdateSelection([CreateNewRotationKeyFrame(explorer, i, true)]);
                        }
                        if (ImGui.Selectable("Create new (after)"))
                        {
                            OpenRotationList = true;
                            explorer.SelectionManager.UpdateSelection([CreateNewRotationKeyFrame(explorer, i, false)]);
                        }
                        ImGui.EndPopup();
                    }

                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat($"##rd{i}", ref keyframe.Object._distance, 1.0f, 0.0f, float.MaxValue))
                    {
                        ComputeDistances();
                        RefreshRotationKeyFrame(keyframe, previousRotation, explorer);
                    }
                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat($"##rx{i}", ref keyframe.Object._value._x)) RefreshRotationKeyFrame(keyframe, previousRotation, explorer);
                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat($"##ry{i}", ref keyframe.Object._value._y)) RefreshRotationKeyFrame(keyframe, previousRotation, explorer);
                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat($"##rz{i}", ref keyframe.Object._value._z)) RefreshRotationKeyFrame(keyframe, previousRotation, explorer);
                }
                ImGui.PopStyleVar();
                ImGui.EndTable();
                ImGui.Spacing();
            }

            // Render velocity keyframes

            if (OpenVelocityList)
            {
                ImGui.SetNextItemOpen(true);
                OpenVelocityList = false;
            }

            _isVelocityListOpen = _velocityKeyFrames.Count > 0 && ImGui.TreeNodeEx($"Velocity ({_velocityKeyFrames.Count})", ImGuiTreeNodeFlags.NoTreePushOnOpen);

            if (_isVelocityListOpen && ImGui.BeginTable("VelocityTable", 4, tableFlags))
            {
                ImGui.TableSetupColumn("id", ImGuiTableColumnFlags.WidthFixed, indexWidth);
                ImGui.TableSetupColumn("distance", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("velocity", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("tension", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableHeadersRow();

                ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(2.0f, 0.0f));

                for (int i = 0; i < _velocityKeyFrames.Count; i++)
                {
                    NSTSplineVelocityKeyFrame velocity = _velocityKeyFrames[i];

                    ImGui.TableNextColumn();
                    if (ImGui.Selectable($"{i+1}##vid", velocity.IsSelected, selectableFlags))
                    {
                        if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                        {
                            explorer.LookAtObject(_velocityKeyFrames[i]);
                        }
                        else
                        {
                            OpenVelocityList = true;
                            explorer.SelectionManager.UpdateSelection([ velocity.IsSelected ? Parent : velocity ]);
                            explorer.RenderNextFrame = true;
                        }
                    }

                    if (ImGui.BeginPopupContextItem($"VelocityActions{i}"))
                    {
                        if (ImGui.Selectable("Create new (before)"))
                        {
                            OpenVelocityList = true;
                            explorer.SelectionManager.UpdateSelection([CreateNewVelocityKeyFrame(explorer, i, true)]);
                        }
                        if (ImGui.Selectable("Create new (after)"))
                        {
                            OpenVelocityList = true;
                            explorer.SelectionManager.UpdateSelection([CreateNewVelocityKeyFrame(explorer, i, false)]);
                        }
                        ImGui.EndPopup();
                    }

                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat($"##vd{i}", ref velocity.Object._distance, 1.0f, 0.0f, float.MaxValue)) RefreshVelocity(velocity, explorer);
                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat($"##vv{i}", ref velocity.Object._value, 0.01f)) explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, velocity.Object);
                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat($"##vt{i}", ref velocity.Object._tension, 0.01f)) explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, velocity.Object);
                }
                ImGui.PopStyleVar();
                ImGui.EndTable();
                ImGui.Spacing();
            }

            // Render markers

            if (OpenMarkerList)
            {
                ImGui.SetNextItemOpen(true);
                OpenMarkerList = false;
            }

            prevOpen = _isMarkerListOpen;
            _isMarkerListOpen = _markers.Count > 0 && ImGui.TreeNodeEx($"Markers ({_markers.Count})", ImGuiTreeNodeFlags.NoTreePushOnOpen);

            if (prevOpen != _isMarkerListOpen && Object3D != null && Markers3D != null)
            {
                if (_isMarkerListOpen) Object3D.Add(Markers3D);
                else Object3D.Remove(Markers3D);
                explorer.RenderNextFrame = true;
            }

            if (_isMarkerListOpen && ImGui.BeginTable("MarkerTable", 2, tableFlags))
            {
                ImGui.TableSetupColumn("id", ImGuiTableColumnFlags.WidthFixed, indexWidth);
                ImGui.TableSetupColumn("distance", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableHeadersRow();

                ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(2.0f, 0.0f));

                for (int i = 0; i < _markers.Count; i++)
                {
                    NSTSplineMarker marker = _markers[i];

                    ImGui.TableNextColumn();
                    if (ImGui.Selectable($"{i+1}##mid", marker.IsSelected, selectableFlags))
                    {
                        if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                        {
                            explorer.LookAtObject(marker);
                        }
                        else
                        {
                            OpenMarkerList = true;
                            explorer.SelectionManager.UpdateSelection([ marker.IsSelected ? Parent : marker ]);
                            explorer.RenderNextFrame = true;
                        }
                    }

                    if (ImGui.BeginPopupContextItem($"MarkerActions{i}"))
                    {
                        if (ImGui.Selectable("Create new (before)"))
                        {
                            OpenMarkerList = true;
                            explorer.SelectionManager.UpdateSelection([CreateNewMarker(explorer, i, true)]);
                        }
                        if (ImGui.Selectable("Create new (after)"))
                        {
                            OpenMarkerList = true;
                            explorer.SelectionManager.UpdateSelection([CreateNewMarker(explorer, i, false)]);
                        }
                        ImGui.EndPopup();
                    }

                    ImGui.TableNextColumn(); ImGui.SetNextItemWidth(-1);
                    if (ImGui.DragFloat("##marker_dist" + i, ref marker.Object._distance))
                    {
                        RefreshMarker(marker, explorer);
                    }
                }
                ImGui.PopStyleVar();
                ImGui.EndTable();
            }
        }
    }

    public class NSTSplineControlPoint : NSTObject<igSplineControlPoint2>
    {
        public NSTSpline Parent { get; }

        public override void Render(LevelExplorer explorer) => Parent.Parent.Render(explorer);

        public NSTSplineControlPoint(NSTSpline parent, igSplineControlPoint2 point)
        {
            Parent = parent;
            Object = point;
            ArchiveFile = parent.ArchiveFile;
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            var sphereGeo = new THREE.SphereGeometry(8, 10, 10);
            var sphereMat = new THREE.MeshBasicMaterial() { Color = Parent.Color };
            var sphereMesh = new THREE.Mesh(sphereGeo, sphereMat);

            sphereMesh.Position.Set(Object._position._x, Object._position._y, Object._position._z);
            sphereMesh.ApplyMatrix4(Parent.Parent.ObjectToWorld());

            Object3D = sphereMesh;

            return sphereMesh;
        }
    }

    public class NSTSplineRotationKeyFrame : NSTObject<CSplineRotationKeyframe>
    {
        public NSTSpline Parent { get; }
        public NSTSplineControlPoint Prev { get; set; }
        public NSTSplineControlPoint Next { get; set; }
        public float LocalDistance { get; set; } = 0;

        public THREE.Vector3 Position { get; set; }

        public override void Render(LevelExplorer explorer) => Parent.Parent.Render(explorer);

        public NSTSplineRotationKeyFrame(NSTSpline parent, CSplineRotationKeyframe rotation)
        {
            Parent = parent;
            Object = rotation;
            ArchiveFile = parent.ArchiveFile;
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            var group = new THREE.Group();
            var mesh = new THREE.Mesh(new THREE.ConeGeometry(50, 150, 4, thetaStart: (float)Math.PI/4), new THREE.MeshBasicMaterial() { Color = new THREE.Color(1,0,0), Wireframe = true });

            mesh.RotateZ((float)Math.PI / 2);
            mesh.Scale.X *= 1.6f;

            THREE.Vector3 rotation = Object._value.ToVector3() * THREE.MathUtils.DEG2RAD;
            group.Rotation.SetFromVector3(rotation, THREE.RotationOrder.ZYX);
            group.Position.Copy(Position);

            if (selected) group.ApplyMatrix4(Parent.Parent.ObjectToWorld());

            group.Add(mesh);

            group.Traverse(e => e.UserData["splineRotation"] = this);

            if (Object3D != null) Object3D.Parent.Remove(Object3D);

            Object3D = group;

            return group;
        }
    }

    public class NSTSplineVelocityKeyFrame : NSTObject<CSplineVelocityKeyframe>
    {
        public NSTSpline Parent { get; }
        public THREE.Vector3 Position { get; set; }

        public override void Render(LevelExplorer explorer) => Parent.Parent.Render(explorer);

        public NSTSplineVelocityKeyFrame(NSTSpline parent, CSplineVelocityKeyframe velocity)
        {
            Parent = parent;
            Object = velocity;
            ArchiveFile = parent.ArchiveFile;
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            const float height = 150;
            var geo = new THREE.CylinderGeometry(4, 4, height);
            var mat = new THREE.MeshBasicMaterial() { Color = new THREE.Color(.1f,1,.2f) };
            var mesh = new THREE.Mesh(geo, mat);

            mesh.Position.Copy(Position);
            mesh.RotateX((float)Math.PI / 2);
            if (selected) mesh.ApplyMatrix4(Parent.Parent.ObjectToWorld());

            mesh.UserData["splineVelocity"] = this;

            Object3D = mesh;

            return mesh;
        }
    }

    public class NSTSplineMarker : NSTObject<igSplineEvent>
    {
        public NSTSpline Parent { get; }
        public THREE.Vector3 Position { get; set; }

        public override void Render(LevelExplorer explorer) => Parent.Parent.Render(explorer);

        public NSTSplineMarker(NSTSpline parent, igSplineEvent marker)
        {
            Parent = parent;
            Object = marker;
            ArchiveFile = parent.ArchiveFile;
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            if (Position == null) return new THREE.Object3D();

            const float height = 150;
            var geo = new THREE.CylinderGeometry(4, 4, height);
            var mat = new THREE.MeshBasicMaterial() { Color = new THREE.Color(1,0,0) };
            var mesh = new THREE.Mesh(geo, mat);

            mesh.Position.Copy(Position);
            mesh.RotateX((float)Math.PI / 2);
            mesh.TranslateY(-height / 2);
            if (selected) mesh.ApplyMatrix4(Parent.Parent.ObjectToWorld());

            mesh.UserData["splineMarker"] = this;

            Object3D = mesh;

            return mesh;
        }
    }

    public class NSTWaypoint : NSTObject<CWaypoint>
    {
        public NSTEntity Parent { get; }

        public override void Render(LevelExplorer explorer) => Parent.Render(explorer);

        public NSTWaypoint(NSTEntity parent, CWaypoint waypoint)
        {
            Parent = parent;
            Object = waypoint;
            ArchiveFile = parent.ArchiveFile;
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            var sphereGeo = new THREE.SphereGeometry(8, 10, 10);
            var sphereMat = new THREE.MeshBasicMaterial() { Color = new THREE.Color(0xff0000) };
            var sphereMesh = new THREE.Mesh(sphereGeo, sphereMat);

            sphereMesh.Position.Set(Object._position._x, Object._position._y, Object._position._z);

            if (!selected)
            {
                sphereMesh.ApplyMatrix4(Parent.ObjectToWorld().Inverted());
            }

            sphereMesh.UserData["waypoint"] = this;

            Object3D = sphereMesh;

            return sphereMesh;
        }
    }
}