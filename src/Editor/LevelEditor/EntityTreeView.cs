using Alchemy;
using ImGuiNET;
using System.Text.RegularExpressions;

namespace NST
{
    public partial class EntityTreeView : TreeView<EntityTreeNode>
    {
        public LevelExplorer Explorer { get; }

        // Entity type hierarchy:
        // ----------------------
        // igEntity
        // └─ CEntity
        //    ├─ CPlayerStartEntity
        //    ├─ CWorldEntity
        //    └─ CGameEntity
        //       ├─ CDynamicClipEntity
        //       ├─ CScriptTriggerEntity
        //       └─ CPhysicalEntity
        //          └─ CActor

        private static readonly Dictionary<string, List<string>> _objectGroupNames = new()
        {
            { "3D Game Objects",  new List<string>() { "igEntity", "Prefabs", "CEntity", "CGameEntity", "CPhysicalEntity", "CActor", "Crates", "Collectibles" } },
            { "Game Objects", new List<string>() { "CPlayerStartEntity", "CScriptTriggerEntity", "CDynamicClipEntity", "Cameras", "CCameraBox" } },
            { "Other",         new List<string>() { "Lighting", "VFX", "SFX", "Other" } },
            { "Hidden",        new List<string>() { "Templates", "Hidden" } }
        };
        private static readonly List<string> _typeOrder = 
        [
            "igEntity", "Prefabs", "CEntity", "CGameEntity", "CPhysicalEntity", "CActor", "Crates", "Collectibles",
            "CPlayerStartEntity", "CScriptTriggerEntity", "CDynamicClipEntity", "Cameras", "CCameraBox", 
            "Lighting", "VFX", "SFX", "Other", "Templates", "Hidden"
        ];
        private static readonly Dictionary<string, string> _objectGroupMap = new() 
        {
            {"igEntity", "Static objects"},
            {"CPlayerStartEntity", "Player start"},
            {"CScriptTriggerEntity", "Triggers"},
            {"CDynamicClipEntity", "Clips"},
        };
        private static readonly HashSet<Type> _alwaysDisplayComponents = 
        [
            typeof(common_Path_Platform_Mover),
            typeof(Hazard_Crushing_Block_ManagerData),
            typeof(Egypt_Crushing_Block_Manager_BehaviorData),
            typeof(common_BabyT_SpawnManagerData),
        ];
        private static readonly HashSet<Type> _componentsWithoutModel = 
        [
            typeof(common_Spawner_TemplateData),
            typeof(Spawner_Trigger_LogicData),
            typeof(CTriggerVolumeComponentData),
            typeof(Hazard_AlwaysOnData),
            typeof(L319_FutureFrenzy_Elevator_logicData),
            typeof(L333_FutureTense_Elevator_LogicData),
            typeof(L333_FutureTense_Tech_Platform_FlipOff_Synchronized_ControllerData),
        ];

        private Dictionary<string, List<EntityTreeNode>> _objectGroups = [];

        public EntityTreeView(LevelExplorer explorer, List<NSTObject> entities)
        {
            Explorer = explorer;
            RebuildTree(entities);
        }

        public override void Render()
        {
            PreviousNode = null;
            SelectNextNode = false;

            foreach ((string group, List<EntityTreeNode> nodes) in _objectGroups)
            {
                if (nodes.Count == 0) continue;
                
                ImGui.SeparatorText(group);

                foreach (EntityTreeNode node in nodes.ToList())
                {
                    node.Render(this);
                }
                
                ImGui.Spacing();
            }
        }

        public void RebuildTree(List<NSTObject> objects)
        {
            Dictionary<string, List<NSTObject>> types = [];
            Dictionary<string, uint> colors = [];

            List<NSTObject> entities = [];
            List<NSTObject> crates = [];
            List<NSTObject> collectibles = [];
            List<NSTObject> prefabs = [];
            List<NSTObject> cameras = [];
            List<NSTObject> light = [];
            List<NSTObject> vfx = [];
            List<NSTObject> sfx = [];
            List<NSTObject> other = [];
            List<NSTObject> templates = [];
            List<NSTObject> hidden = [];

            foreach (NSTObject obj in objects)
            {
                bool added = false;

                if (obj is NSTEntity entity)
                {
                    added = true;

                    if (entity.IsPrefabTemplate) continue;
                    else if (entity.IsPrefabInstance) prefabs.Add(obj);
                    else if (entity.IsTemplate)
                    {
                        if (entity.IsPrefabChild && templates.Any(t => t.GetObject() == entity.Object)) continue;
                        if (entity.Parents.Any(p => p is NSTEntity e && e.IsTemplate)) continue;
                        templates.Add(obj);
                    }
                    else if (entity.IsHidden) hidden.Add(obj);
                    else if (entity.IsPrefabChild) continue;
                    else if (entity.Object.GetType() == typeof(CEntity) && entity.Object.GetComponent<common_Crate_StackCheckerData>() != null) crates.Add(obj);
                    else if (entity.Object.GetType() == typeof(CEntity) && entity.Children.Any(c => c is NSTEntity e && e.Object.GetComponent<common_Collectible_Template_SpawnedData>() != null)) collectibles.Add(obj);
                    else if (entity.Object is CScriptTriggerEntity && entity.Parents.Any(p => p.GetObject() is not CScriptTriggerEntity)) continue;
                    else if (entity.Object is CPlayerStartEntity || entity.Object.GetComponents().Any(c => _alwaysDisplayComponents.Any(t => c.GetType().IsAssignableTo(t)))) added = false;
                    else if (entity.Parents.Count(p => p is NSTEntity e && e.IsSpawned && e.Object is not CScriptTriggerEntity && e.Object.GetComponent<common_Spawner_TemplateData>() == null) == 1) continue;
                    else if (entity.Model == null && entity.Object is not CScriptTriggerEntity && entity.Object is not CDynamicClipEntity && entity.Object is not CPlayerStartEntity)
                    {
                        if (entity.Parents.Any(p => p is not NSTEntity e || !e.IsTemplate) && entity.Object.GetComponent<common_Spawner_TemplateData>() == null) continue;
                        else if (entity.Object.GetType() == typeof(igEntity) && entity.Object.ObjectName == "Main_OutdoorLightEntity") light.Add(obj);
                        else if (entity.Object.GetComponents().Any(c => _componentsWithoutModel.Any(t => c.GetType().IsAssignableTo(t)))) added = false;
                        else if (entity.Object.GetComponent<CTintSphereComponentData>() != null)    light.Add(obj);
                        else if (entity.Object.GetComponent<CPointLightComponentData>() != null)    light.Add(obj);
                        else if (entity.Object.GetComponent<CBoxLightComponentData>() != null)      light.Add(obj);
                        else if (entity.Object.GetComponent<CVisualDataBoxComponentData>() != null) light.Add(obj);
                        else if (entity.Object.GetComponent<CStaticVfxComponentData>() != null)     vfx.Add(obj);
                        else if (entity.Object.GetComponent<CLoopingVfxComponentData>() != null)    vfx.Add(obj);
                        else if (entity.Object.GetComponent<CAmbientAudioComponentData>() != null)  sfx.Add(obj);
                        else if (entity.Object.GetComponent<common_OnStartMusicData>() != null)     sfx.Add(obj);
                        else other.Add(obj);
                    }
                    else added = false;
                }
                else if (obj.GetObject() is CCamera)
                {
                    cameras.Add(obj);
                    added = true;
                }
                
                if (!added)
                {
                    Type type = obj.GetObject().GetType();

                    if (!types.TryGetValue(type.Name, out List<NSTObject>? value))
                    {
                        value = [];
                        types.Add(type.Name, value);
                        colors.Add(type.Name, type.GetUniqueColor());
                    }

                    value.Add(obj);
                }
            }

            types["Prefabs"] = prefabs;
            types["Crates"] = crates;
            types["Collectibles"] = collectibles;
            types["Cameras"] = cameras;
            types["Lighting"] = light;
            types["VFX"] = vfx;
            types["SFX"] = sfx;
            types["Other"] = other;
            types["Templates"] = templates;
            types["Hidden"] = hidden;

            types = _typeOrder.Where(t => types.ContainsKey(t) && types[t].Count > 0).ToDictionary(t => t, t => types[t]);

            _objectGroups = _objectGroupNames.ToDictionary(e => e.Key, e => new List<EntityTreeNode>());

            AllNodes.Clear();

            _rootNodes = types.Select(t => 
            {
                Dictionary<string, List<EntityTreeNode>> names = [];

                foreach (NSTObject entity in t.Value)
                {
                    string name = entity.GetObject().ObjectName ?? "<No name>";
                    Match match = ObjectNameRegex().Match(name);

                    if (!match.Success) {
                        Console.WriteLine($"Warning: Could not parse {name} into name and number");
                        continue;
                    }

                    string prefix = match.Groups[1].Value;

                    if (!names.ContainsKey(prefix)) names.Add(prefix, []);
                    EntityTreeNode entityNode = new EntityTreeNode(name, entity);
                    names[prefix].Add(entityNode);
                    AllNodes.Add(entityNode);
                }

                List<EntityTreeNode> subFolders = names.Select(n => {
                    if (n.Value.Count == 1) {
                        AllNodes.Add(n.Value[0]);
                        return n.Value[0];
                    }
                    string name = $"{n.Key} ({n.Value.Count})";
                    EntityTreeNode folderNode = new EntityTreeNode(name, n.Value);
                    AllNodes.Add(folderNode);
                    return folderNode;
                })
                .OrderBy(n => n.Children.Count == 0)
                .ThenBy(n => n.Object != null)
                .ThenBy(n => n.Object != null ? n.Object.GetObject().GetType().Name : "")
                .ThenBy(n => n.Name)
                .ToList();

                int totalCount = subFolders.Sum(n => n.IsFolder ? Math.Max(1, n.Children.Count) : 1);

                if (!_objectGroupMap.TryGetValue(t.Key, out string? rootName))
                {
                    rootName = t.Key;
                }
                rootName += $" ({totalCount})";

                if (subFolders.Count == 1 && subFolders.First().IsFolder)
                {
                    subFolders = subFolders.First().Children.Cast<EntityTreeNode>().ToList();
                }

                EntityTreeNode rootNode = new EntityTreeNode(rootName, subFolders, GetUniqueColor(t.Key));
                AllNodes.Add(rootNode);

                string? groupName = _objectGroupNames.FirstOrDefault(e => e.Value.Contains(t.Key)).Key ?? "3D Game Objects";
                _objectGroups[groupName].Add(rootNode);

                return rootNode;
            })
            .ToList();
        }

        public void SelectObject(NSTObject obj)
        {
            var queue = new Queue<EntityTreeNode>(AllNodes);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Object == obj)
                {
                    SetSelectedNode(node, keyboardFocus: false, expandParents: true);
                    return;
                }

                foreach (EntityTreeNode child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        private static uint GetUniqueColor(string name)
        {
            Random rng = new Random((int)NamespaceUtils.ComputeHash(name)+1);
            int r = rng.Next(130, 255);
            int g = rng.Next(130, 255);
            int b = rng.Next(130, 255);
            return 0xff000000 | (uint)((b << 16) | (g << 8) | r);
        }

        [GeneratedRegex(@"^(.*?)(?:_)?(\d+)?$")]
        private static partial Regex ObjectNameRegex();
    }

    public class EntityTreeNode : TreeNode
    {
        public NSTObject Object { get; }
        public uint? Color { get; set; }

        public EntityTreeNode(string name, List<EntityTreeNode> childNodes, uint? color = null)
        {
            Name = name;
            IsFolder = true;
            Color = color;
            
            foreach (EntityTreeNode child in childNodes)
            {
                Children.Add(child);
            }
        }

        public EntityTreeNode(string name, NSTObject obj, HashSet<NSTObject>? added = null)
        {
            Name = name;
            Object = obj;

            added ??= new HashSet<NSTObject>();
            added.Add(obj);

            HashSet<NSTObject> prev = added.ToHashSet();

            bool isSpawned = obj is NSTEntity entity && entity.IsSpawned;

            foreach (NSTObject child in obj.Children)
            {
                if (child is NSTSpline) continue;
                if (isSpawned && child is NSTEntity e && e.IsTemplate) continue;
                if (added.Contains(child)) continue;
                Children.Add(new EntityTreeNode(child.GetObject().ObjectName ?? "<No name>", child, prev));
            }

            if (obj is NSTEntity)
            {
                Children.Sort((a, b) => a.Name.CompareTo(b.Name));
            }
        }

        public void Render(EntityTreeView tree)
        {
            ImGuiTreeNodeFlags? flags = SetupNode(tree, onFocus: () => 
            { 
                if (Object != null && NextFocus == NextFocusState.FocusAndKeyboard)
                {
                    tree.Explorer.SelectObject(Object, fromTree: true);
                }
            });

            if (flags == null) return;

            RenderNode(tree, flags.Value);

            tree.PreviousNode = this;

            if (IsOpen)
            {
                foreach (EntityTreeNode child in Children)
                {
                    child.Render(tree);
                }
                ImGui.TreePop();
            }
        }

        private void RenderName(string displayName)
        {
            ImGui.SameLine(0, 0);

            if (Object != null)
            {
                ImGui.PushStyleColor(ImGuiCol.Text, Object.GetObject().GetType().GetUniqueColor());
                ImGui.Text("\uEA1E");
                ImGui.PopStyleColor();
                ImGui.SameLine(0, 5);
            }

            if (Color != null) ImGui.PushStyleColor(ImGuiCol.Text, Color.Value);

            ImGui.Text(displayName);

            if (Color != null) ImGui.PopStyleColor();
        }

        private void RenderNode(EntityTreeView tree, ImGuiTreeNodeFlags flags)
        {
            if (Object == null)
            {
                RenderFolderNode(tree, flags);
                return;
            }

            if (Object.IsSelected) flags |= ImGuiTreeNodeFlags.Selected;
            else flags &= ~ImGuiTreeNodeFlags.Selected;

            string displayName = Object is NSTEntity entity && entity.IsPrefabInstance ? $"[Prefab] {Name}" : Name;

            IsOpen = ImGui.TreeNodeEx("###" + Name + Object.FileNamespace, flags);

            if (ImGui.IsItemClicked())
            {
                if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                {
                    tree.Explorer.LookAtObject(Object);
                }
            }

            HandleNavigation(tree);
            RenderName(displayName);
        }

        private void RenderFolderNode(EntityTreeView tree, ImGuiTreeNodeFlags flags)
        {
            IsOpen = ImGui.TreeNodeEx("###" + Name, flags);

            HandleNavigation(tree);
            RenderName(Name);
        }
    }
}