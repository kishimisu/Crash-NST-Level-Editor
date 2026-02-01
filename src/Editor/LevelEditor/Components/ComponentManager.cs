using Alchemy;
using ImGuiNET;

namespace NST
{
    public class ComponentManager
    {
        private uint _uuid;

        public NSTEntity Entity { get; private set; }
        public LevelExplorer Explorer { get; private set; }

        public NSTComponent PopupComponent { get; set; }

        private List<NSTComponent> _components;
        private List<NSTComponent> _selection = [];

        private bool _isCrate = false;

        private static NSTEntity? _copyEntity = null;
        private static List<NSTComponent> _copyComponents = [];
        private static LevelExplorer? _copyEntityExplorer = null;

        private static readonly HashSet<Type> _autoFocusComponents = 
        [
            typeof(common_Spawner_TemplateData), 
            typeof(Multiple_Spawner_Template_c), 
            typeof(Animated_Multiple_Spawner_Template_Behavior),
            typeof(igPrefabComponentData), 
            typeof(common_Level_ManagerData),
            typeof(common_BonusRoundTeleporterData)
        ];

        public int Count => _components.Count;
        public string GetID() => _uuid.ToString();
        public NSTComponent? GetComponent<T>() where T : igComponentData => _components.Find(c => c.Object is T);

        public ComponentManager(NSTEntity entity)
        {
            Entity = entity;
            _uuid = ImGuiUtils.Uuid();
        }

        public List<NSTComponent> SetupComponents(LevelExplorer explorer)
        {
            Explorer = explorer;

            List<NSTComponent> components = [];
            Dictionary<string, igComponentData> dict = Entity.Object.GetComponentsDictionary();

            _isCrate = dict.Values.Any(e => e is common_Crate_StackCheckerData);

            foreach ((string key, igComponentData component) in dict)
            {
                if (!Explorer.CachedComponents.TryGetValue(component, out List<NSTEntity>? references))
                {
                    references = Explorer.InstanceManager.AllEntities.Where(e => !e.IsPrefabChild && e.Object.GetComponents().Contains(component)).ToList();
                    Explorer.CachedComponents[component] = references;
                }

                bool isUnique = references.Count <= 1 || component is igPrefabComponentData;

                NSTComponent c = new NSTComponent(key, component, this, isUnique);
                components.Add(c);

                if (_isCrate || _selection.Count > 0) continue;

                if (dict.Count == 1 || _autoFocusComponents.Contains(component.GetType()))
                {
                    _selection.Add(c);
                }
            }

            components.Sort((a, b) => a.DisplayName.CompareTo(b.DisplayName));

            _components = components;

            return components;
        }

        public void RefreshComponents(LevelExplorer explorer)
        {
            foreach (igComponentData component in Entity.Object.GetComponents())
            {
                if (explorer.CachedComponents.TryGetValue(component, out List<NSTEntity>? references))
                {
                    references.ForEach(e => e.Components?.Refresh());
                    explorer.CachedComponents.Remove(component);
                }
            }
        }

        public void Refresh()
        {
            _components = null!;
            _selection.Clear();
        }

        public void SelectComponent<T>() where T : igComponentData
        {
            NSTComponent? component = _components.Find(c => c.Object is T);
            
            if (component != null)
            {
                _selection.Clear();
                _selection.Add(component);
            }
        }

        public void RenderComponents(LevelExplorer explorer)
        {
            _components ??= SetupComponents(explorer);

            if (_components.Count == 0) return;

            ImGui.PushID((int)_uuid);

            ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
            ImGui.SeparatorText($"Components ({_components.Count})");
            ImGui.PopStyleColor();

            if (ImGui.BeginChild("##components", System.Numerics.Vector2.Zero, ImGuiChildFlags.AutoResizeY))
            {
                ImGuiMultiSelectIOPtr io = ImGui.BeginMultiSelect(ImGuiMultiSelectFlags.ClearOnEscape | ImGuiMultiSelectFlags.ClearOnClickVoid | ImGuiMultiSelectFlags.BoxSelect1d);
                ApplyMultiSelectRequests(io);

                for (int i = 0; i < _components.Count; i++)
                {
                    igComponentData component = _components[i].Object;

                    ImGui.PushStyleColor(ImGuiCol.Text, component.GetType().GetUniqueColor());
                    ImGui.Bullet();

                    ImGui.SetNextItemSelectionUserData(i);
                    ImGui.SetNextItemAllowOverlap();

                    bool selected = _selection.Contains(_components[i]);

                    if (ImGui.Selectable(_components[i].DisplayName, selected, ImGuiSelectableFlags.AllowDoubleClick) && ImGui.IsMouseDoubleClicked(0))
                    {
                        explorer.FocusObjectInArchive(component.ToNamedReference(Entity.FileNamespace));
                    }
                    if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
                    {
                        ImGui.OpenPopup("ComponentActionsPopup");
                    }

                    ImGui.PopStyleColor();
                    ImGui.SameLine();

                    ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(0, 0));
                    ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X- ImGui.GetFrameHeight());
                    if (ImGui.Checkbox("##selected" + i, ref component._bitfield._isEnabled))
                    {
                        _components[i].SetUpdated();
                    }
                    ImGui.PopStyleVar();
                }

                io = ImGui.EndMultiSelect();
                ApplyMultiSelectRequests(io);

                RenderComponentPopup(explorer);
            }

            ImGuiUtils.VerticalSpacing(8.0f);

            // if (ImGui.IsWindowHovered())
            // {
            //     if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.C)) CopyComponents(_selection.ToList(), explorer);
            //     if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.V)) PasteComponents(explorer);
            //     if (ImGui.IsKeyPressed(ImGuiKey.Delete) || ImGui.IsKeyPressed(ImGuiKey.Backspace)) DeleteComponents(_selection, explorer);
            // }

            ImGui.EndChild();
            ImGui.PopID();
        }

        public void RenderSelectedComponent(LevelExplorer explorer)
        {
            if (_components.Count == 0) return;

            if (_selection.Count == 1)
            {
                _selection[0].Render();
            }
            // Special display for crates
            else if (_isCrate)
            {
                Dictionary<Type, NSTComponent> components = _components.ToDictionary(c => c.Object.GetType(), c => c);

                if (components.TryGetValue(typeof(common_Spawner_TemplateData), out NSTComponent? cst))           cst.Render();
                if (components.TryGetValue(typeof(common_Crate_Switch_IronData), out NSTComponent? ccsi))         ccsi.Render();
                if (components.TryGetValue(typeof(common_Crate_Switch_ReusableData), out NSTComponent? ccsr))     ccsr.Render();
                if (components.TryGetValue(typeof(common_Crate_OutlineData), out NSTComponent? cco))              cco.Render();
                if (components.TryGetValue(typeof(common_Crate_SlotMachine_SpawnedData), out NSTComponent? ccss)) ccss.Render();
                if (components.TryGetValue(typeof(common_Crate_LevelCountData), out NSTComponent? ccl))           ccl.Render();
                if (components.TryGetValue(typeof(common_Crate_TimeTrialData), out NSTComponent? cct))            cct.Render();
                if (components.TryGetValue(typeof(common_Crate_WaterData), out NSTComponent? ccw))                ccw.Render();
                // if (components.TryGetValue(typeof(common_Crate_StackCheckerData), out NSTComponent? ccs)) ccs.Render();
                // if (components.TryGetValue(typeof(common_Crate_ExplodeData), out NSTComponent? cce)) cce.Render();
                // if (components.TryGetValue(typeof(common_Crate_Nitro_SpawnedData), out NSTComponent? ccns)) ccns.Render();
                // if (components.TryGetValue(typeof(common_Crate_Switch_Iron_Reusable_SpawnedData), out NSTComponent? ccsir)) ccsir.Render();
                // if (components.TryGetValue(typeof(common_Crate_Flood_BehaviorData), out NSTComponent? ccfb)) ccfb.Render();
            }
            // Special display for static objects
            else if (_components.Count <= 3)
            {
                NSTComponent? cmc = _components.FirstOrDefault(c => c.Object is CModelComponentData);
                NSTComponent? csc = _components.FirstOrDefault(c => c.Object is CStaticComponentData);

                if (cmc != null && csc != null)
                {
                    NSTComponent? cscc = _components.FirstOrDefault(c => c.Object is CStaticCollisionComponentData);

                    cmc.Render();
                    csc.Render();
                    cscc?.Render();
                }
            }

            RenderComponentPopup(explorer, false);
        }

        public NSTComponent MakeUnique(NSTComponent c)
        {
            if (Entity.Object._entityData?._componentData == null) return c;

            // Find index in component list
            int idx = Entity.Object._entityData._componentData._values.IndexOf(c.OriginalObject);

            Entity.MakeUnique(Explorer);

            // Clone component
            IgzFile igz = Explorer.FileManager.GetIgz(Entity.ArchiveFile)!;
            igComponentData clone = igz.AddClone(c.Object, mode: CloneMode.Deep | CloneMode.SkipEntities);
            NSTComponent newComponent = new NSTComponent(c.Key, clone, this, true);

            // Replace component
            Entity.Object._entityData._componentData._values[idx] = clone;
            Entity.Object._entityData._componentData.BuildDict();

            Explorer.ArchiveRenderer.SetObjectUpdated(Entity.ArchiveFile, clone, true);
            Explorer.ArchiveRenderer.SetObjectUpdated(Entity.ArchiveFile, Entity.Object._entityData._componentData, true);

            // Update cache
            int componentIndex = _components.IndexOf(c);

            _components[componentIndex] = newComponent;

            int selectionIndex = _selection.IndexOf(c);
            if (selectionIndex != -1)
            {
                _selection[selectionIndex] = newComponent;
            }

            Explorer.CachedComponents[c.OriginalObject].Remove(Entity);
            Explorer.CachedComponents[clone] = [ Entity ];

            return newComponent;
        }

        private void CopyComponents(List<NSTComponent> components, LevelExplorer explorer)
        {
            _copyComponents = components;
            _copyEntityExplorer = explorer;
            _copyEntity = Entity;
        }

        private void PasteComponents(LevelExplorer explorer)
        {
            if (explorer != _copyEntityExplorer || _copyEntity == null) return;

            Entity.MakeUnique(explorer);

            Dictionary<igObject, igObject> clones = [];

            foreach (NSTComponent c in _copyComponents)
            {
                string baseName = c.GetBaseKeyName();
                string key = baseName;
                int id = 2;

                Console.WriteLine("Base name: " + baseName);

                // Find suitable key in hashtable
                while (Entity.Object._entityData?._componentData?.Dict.Keys.Contains(key) == true)
                {
                    key = baseName + (id++);
                    Console.WriteLine("Trying name: " + key);
                }

                // External archive
                // if (_copyExplorer != explorer)
                // {
                //     IgArchive source = _copyExplorer.Archive;
                //     IgzFile sourceIgz = _copyExplorer.FileManager.GetIgz(_copyEntity.ArchiveFile)!;
                //     IgzFile destIgz = explorer.FileManager.GetIgz(Entity.ArchiveFile)!;

                //     igComponentData clone = explorer.ArchiveRenderer.Clone(c.component, source, sourceIgz, destIgz, clones);
                //     Component newComponent = new Component(key, clone, explorer);

                //     CachedComponents[clone] = newComponent;
                //     _components.Add(newComponent);
                //     Entity.Object._entityData?._componentData?.Add(key, clone);
                // }
                // else
                {
                    IgzFile sourceIgz = explorer.FileManager.GetIgz(_copyEntity.ArchiveFile)!;
                    IgzFile destIgz = explorer.FileManager.GetIgz(Entity.ArchiveFile)!;

                    // Add clone
                    igComponentData clone = destIgz.AddClone(c.OriginalObject, sourceIgz, clones, CloneMode.Deep | CloneMode.SkipEntities);
                    Entity.Object._entityData?._componentData?.Add(key, clone);

                    // Update cache
                    _components.Add(new NSTComponent(key, clone, this, true));
                    explorer.CachedComponents[clone] = [ Entity ];
                }
            }

            if (Entity.Spline == null)
            {
                Entity.InitSpline();
            }

            foreach (igObject clone in clones.Values)
            {
                explorer.ArchiveRenderer.SetObjectUpdated(Entity.ArchiveFile, clone);
            }
            
            explorer.ArchiveRenderer.SetObjectUpdated(Entity.ArchiveFile, Entity.Object._entityData?._componentData, true);

            explorer.InstanceManager.RefreshModel(Entity);
        }

        private void DeleteComponents(List<NSTComponent> components, LevelExplorer explorer)
        {
            Entity.MakeUnique(explorer);

            foreach (NSTComponent c in components)
            {
                // Update cache
                _components.Remove(c);
                explorer.CachedComponents[c.OriginalObject].Remove(Entity);

                // Update object
                Entity.Object._entityData?._componentData?.Remove(c.Key);
            }

            // Clear selection
            if (components.Count > 1 || _selection.Contains(components[0]))
            {
                _selection.Clear();
            }
            
            explorer.ArchiveRenderer.SetObjectUpdated(Entity.ArchiveFile, Entity.Object._entityData?._componentData, true);

            explorer.InstanceManager.RefreshModel(Entity);
        }

        private void RenderComponentPopup(LevelExplorer explorer, bool useSelection = true)
        {
            if (!ImGui.BeginPopup("ComponentActionsPopup")) return;

            List<NSTComponent> components = useSelection ? _selection.ToList() : [ PopupComponent ];
            string trailing = "component";

            if (components.Count == 1)
            {
                components[0].RenderName();
            }
            else
            {
                trailing = $"{components.Count} components";
            }
            
            // Copy components
            if (ImGui.Selectable("Copy " + trailing))
            {
                CopyComponents(components, explorer);
            }

            // Delete components
            if (Entity.Object._entityData?._componentData != null && ImGui.Selectable("Delete " + trailing))
            {
                DeleteComponents(components, explorer);
            }

            // Paste components
            if (Entity.Object._entityData?._componentData != null && _copyComponents.Count > 0 && explorer == _copyEntityExplorer)
            {
                if (useSelection)
                {
                    ImGui.Separator();
                    if (ImGui.Selectable($"Paste {_copyComponents.Count} component{(_copyComponents.Count == 1 ? "" : "s")}"))
                    {
                        PasteComponents(explorer);
                    }
                }

                if (_copyComponents[0].Object.GetType() == components[0].Object.GetType())
                {
                    ImGui.Separator();
                    if (ImGui.Selectable($"Paste component values"))
                    {
                        IgzFile sourceIgz = _copyEntityExplorer.FileManager.GetIgz(_copyComponents[0].Entity.ArchiveFile)!;
                        IgzFile destinationIgz = explorer.FileManager.GetIgz(components[0].Entity.ArchiveFile)!;

                        _copyComponents[0].Object.CopyTo(components[0].Object);

                        var clones = new Dictionary<igObject, igObject>();

                        foreach (CachedFieldAttr field in components[0].Object.GetFields())
                        {
                            object? value = field.GetValue(components[0].Object);

                            if (value is igObject obj && obj.ObjectName != null && obj.Reference == null)
                            {
                                object? clone = destinationIgz.AddClone(obj, sourceIgz, clones, CloneMode.Deep | CloneMode.SkipComponents | CloneMode.SkipEntities);
                                field.SetValue(components[0].Object, clone);
                            }
                        }

                        foreach (var clone in clones.Values)
                        {
                            explorer.ArchiveRenderer.SetObjectUpdated(Entity.ArchiveFile, clone);
                        }
                        
                        explorer.ArchiveRenderer.SetObjectUpdated(Entity.ArchiveFile, components[0].Object, true);

                        if (_components[0].Object is CModelComponentData modelComponent)
                        {
                            NSTModel? model = LevelExplorer.CachedModels.Values.FirstOrDefault(m => m.OriginalPath == modelComponent._fileName);
                            if (model != null)
                            {
                                Entity.RefreshModel(explorer, model);
                            }
                        }
                    }
                }
            }

            ImGui.EndPopup();
        }
        
        private void ApplyMultiSelectRequests(ImGuiMultiSelectIOPtr multiselectIO)
        {
            int lastSelected = _selection.Count != 1 ? -1 : _components.IndexOf(_selection[0]);

            for (int reqIdx = 0; reqIdx < multiselectIO.Requests.Size; reqIdx++)
            {
                ImGuiSelectionRequestPtr req = multiselectIO.Requests[reqIdx];

                if (req.Type == ImGuiSelectionRequestType.SetAll)
                {
                    if (!req.Selected)
                    {
                        if (Entity.Object3D != null && Entity.TriggerVolumeBox != null 
                            && Entity.Object3D.Children.Contains(Entity.TriggerVolumeBox))
                        {
                            Entity.Object3D.Remove(Entity.TriggerVolumeBox);
                            Explorer.RenderNextFrame = true;
                        }

                        _selection.Clear();
                        continue;
                    }

                    req.RangeFirstItem = 0;
                    req.RangeLastItem = _selection.Count - 1;
                    req.RangeDirection = 1;
                }

                long startIndex = Math.Min(req.RangeFirstItem, req.RangeLastItem);
                long endIndex = Math.Max(req.RangeFirstItem, req.RangeLastItem);
                for (long i = startIndex; i <= endIndex; i++)
                {
                    if (req.Selected && i != lastSelected)
                    {
                        _selection.Add(_components[(int)i]);
                    }
                    else
                    {
                        _selection.Remove(_components[(int)i]);
                    }
                }
            }
        }
    }
}