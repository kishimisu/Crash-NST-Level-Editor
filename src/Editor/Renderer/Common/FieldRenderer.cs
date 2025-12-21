using Alchemy;
using Havok;
using ImGuiNET;
using System.Numerics;
using System.Runtime.InteropServices;

namespace NST
{
    /// <summary>
    /// Handles rendering of object fields
    /// </summary>
    public static class FieldRenderer
    {
        // Used for copy/paste
        private static object? _copyObject = null;
        private static FileRenderer? _copyRenderer = null;

        /// <summary>
        /// Render all fields of the given igObjectBase or hkObject instance
        /// </summary>
        public static void RenderFields(FileRenderer renderer, object obj, IReadOnlyList<CachedFieldAttr> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (obj is igObject && i < 2) continue; // Hide "type ID" and "reference count" fields for igObjects

                CachedFieldAttr field = fields[i];
                Type fieldType = field.GetFieldType();
                string name = field.GetName();

                object? value = field.GetValue(obj);

                Action<object?> onChange = (newVal) => 
                {
                    if (fieldType.IsAssignableTo(typeof(igObject)))
                    {
                        // igObject field update
                        IgzTreeNode? newNode = (IgzTreeNode?)newVal;
                        field.SetValue(obj, newNode?.Object);
                        renderer.OnObjectRefChanged();
                    }
                    else if (fieldType.IsAssignableTo(typeof(hkObject)))
                    {
                        // hkObject field update
                        HavokTreeNode? newNode = (HavokTreeNode?)newVal;
                        field.SetValue(obj, newNode?.Object);
                        renderer.OnObjectRefChanged();
                    }
                    else
                    {
                        // Regular field update
                        field.SetValue(obj, newVal);
                        renderer.SetUpdated();
                    }
                };

                RenderField(renderer, value, fieldType, name, onChange);
            }
        }

        /// <summary>
        /// Render a single field (name, type, editable value)
        /// </summary>
        private static void RenderField(FileRenderer renderer, object? value, Type type, string name, Action<object?> onChange)
        {
            if (renderer is IgzRenderer igzRenderer)
            {
                RenderIgzField(igzRenderer, value, type, name, onChange);
            }
            else if (renderer is HavokRenderer havokRenderer)
            {
                RenderHavokField(havokRenderer, value, type, name, onChange);
            }
        }

        private static void RenderIgzField(IgzRenderer renderer, object? value, Type type, string name, Action<object?> onChange)
        {
            if (value is igMetaField metaField)
            {
                // MetaField
                MetaFieldRenderer.Render(renderer, metaField, type, name);
            }
            else if (value is Array arr)
            {
                // MetaFieldArray
                RenderArray(renderer, arr, name, type);
            }
            else
            {
                // Regular field
                RenderNameAndType(renderer, value, type, name, onChange);
                CreateInput(renderer, value, type, name, onChange);
            }

            HandleCopyPaste(renderer, name + "##data", value, type, onChange);
        }

        private static void RenderHavokField(HavokRenderer renderer, object? value, Type type, string name, Action<object?> onChange)
        {
            if (value is hkMemoryBase)
            {
                // Memory field
                RenderHkMemory((dynamic)value, renderer, name);
            }
            else
            {
                // Regular field
                RenderNameAndType(renderer, value, type, name, onChange);
                CreateInput(renderer, value, type, name, onChange);
            }

            HandleCopyPaste(renderer, name + "##data", value, type, onChange);
        }
        
        /// <summary>
        /// Render a field's name and type
        /// </summary>
        public static void RenderNameAndType(FileRenderer renderer, object? value, Type type, string name, Action<object?>? onChange = null)
        {
            TableNextRow(renderer);
            ImGui.Text(name);

            HandleCopyPaste(renderer, name + "##name", value, type, onChange);

            ImGui.TableNextColumn();
            RenderType(type);

            HandleCopyPaste(renderer, name + "##type", value, type, onChange);

            ImGui.TableNextColumn();
        }

        /// <summary>
        /// Render a field's type
        /// </summary>
        public static void RenderType(Type type)
        {
            uint typeColor = type.GetRenderColor();
            string displayName = type.GetDisplayName();

            ImGui.PushStyleColor(ImGuiCol.Text, typeColor);
            ImGui.AlignTextToFramePadding();
            ImGui.Text(displayName);
            ImGui.PopStyleColor();
        }

        /// <summary>
        /// Start a new row for a field
        /// </summary>
        public static void TableNextRow(FileRenderer renderer, bool pushStyles = false)
        {
            ImGui.TableNextRow(ImGuiTableRowFlags.None);//, pushStyles ? 25 : 20);

            renderer.PopStyles();

            if (pushStyles)
            {
                ImGui.PushStyleColor(ImGuiCol.TableRowBg, 0xff1e0014);
                ImGui.PushStyleColor(ImGuiCol.TableRowBgAlt, 0xff26010b);
            }

            ImGui.TableNextColumn();
            ImGui.AlignTextToFramePadding();
        }

        /// <summary>
        /// Render a field's editable value
        /// </summary>
        public static void CreateInput(FileRenderer renderer, object? value, Type type, string name, Action<object?> onChange)
        {
            string label = "##" + name;

            // Nullable types

            if (type.IsAssignableTo(typeof(igObject)))
            {
                CreateObjectRefInputIgz(renderer, (igObject?)value, type, name, onChange);
            }
            else if (type.IsAssignableTo(typeof(hkObject)))
            {
                CreateObjectRefInput(renderer, value, type, name, onChange);
            }
            else if (type == typeof(string))
            {
                CreateStringInput((string?)value, name, onChange);
            }

            else if (value == null)
            {
                ImGui.Text("null");
                Console.Error.WriteLine("Warning: Trying to render a null value (this should only happen for object references or strings)");
            }

            // Non-nullable types
            
            else if (type.IsEnum)
            {
                CreateEnumInput(value, type, name, onChange);
            }
            else if (type == typeof(bool))
            {
                CreateBoolInput((bool)value, name, onChange);
            }
            else if (type == typeof(Vector4))
            {
                CreateVector4Input((Vector4)value, name, onChange);
            }
            else if (type == typeof(Quaternion))
            {
                CreateQuaternionInput((Quaternion)value, name, onChange);
            }
            else if (type == typeof(Matrix4x4))
            {
                CreateMatrix4x4Input((Matrix4x4)value, name, onChange);
            }
            else if (type == typeof(Matrix3x4))
            {
                CreateMatrix3x4Input((Matrix3x4)value, name, onChange);
            }
            else
            {
                // Scalar types
                GCHandle handle = default;

                if      (type == typeof(i8))    handle = CreateScalarInput((i8)value,  ImGuiDataType.S8,  label, onChange);
                else if (type == typeof(u8))    handle = CreateScalarInput((u8)value,  ImGuiDataType.U8,  label, onChange);
                else if (type == typeof(i16))   handle = CreateScalarInput((i16)value, ImGuiDataType.S16, label, onChange);
                else if (type == typeof(u16))   handle = CreateScalarInput((u16)value, ImGuiDataType.U16, label, onChange);
                else if (type == typeof(i32))   handle = CreateScalarInput((i32)value, ImGuiDataType.S32, label, onChange);
                else if (type == typeof(u32))   handle = CreateScalarInput((u32)value, ImGuiDataType.U32, label, onChange);
                else if (type == typeof(i64))   handle = CreateScalarInput((i64)value, ImGuiDataType.S64, label, onChange);
                else if (type == typeof(u64))   handle = CreateScalarInput((u64)value, ImGuiDataType.U64, label, onChange);
                else if (type == typeof(float)) handle = CreateScalarInput((float)value, ImGuiDataType.Float, label, onChange);
                else if (type == typeof(Half))  handle = CreateScalarInput((float)(Half)value, ImGuiDataType.Float, label, val => onChange.Invoke((Half)(float)val));
                else
                {
                    ImGui.Text(value.ToString());
                    Console.Error.WriteLine($"Warning: Rendering of type {type.Name} is not supported.");
                }

                if (handle.IsAllocated)
                    handle.Free();
            }
        }

        public static void CreateStringInput(string? value, string name, Action<object?> onChange, bool createClearButton = true)
        {
            ImGui.PushID(name);
            
            // Null string
            if (value == null)
            {
                float buttonWidth = ImGui.CalcTextSize("\uEA0A").X + ImGui.GetStyle().FramePadding.X * 2 + 2;

                ImGui.Text("null");
                ImGui.SameLine();
                ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - buttonWidth);

                if (ImGui.Button("\uEA0A")) onChange.Invoke(""); // Add button
            }
            // Non-nullable string
            else if (!createClearButton)
            {
                if (ImGui.InputText("##" + name, ref value, 256))
                {
                    onChange.Invoke(value);
                }
            }
            // Nullable string
            else
            {
                float buttonWidth = createClearButton ? ImGui.CalcTextSize("x").X + ImGui.GetStyle().FramePadding.X * 2 + 2 : 0;
                float inputWidth = ImGui.GetContentRegionAvail().X - buttonWidth - ImGui.GetStyle().FramePadding.X * 2 + 2;

                ImGui.SetNextItemWidth(inputWidth);

                if (ImGui.InputText("##" + name, ref value, 256))
                {
                    onChange.Invoke(value);
                }

                ImGui.SameLine();
                ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - buttonWidth);
                
                if (ImGui.Button("x")) onChange.Invoke(null); // Clear button
            }

            ImGui.PopID();
        }

        private static void CreateBoolInput(bool value, string name, Action<object> onChange)
        {
            if (ImGui.Checkbox("##" + name, ref value))
            {
                onChange.Invoke(value);
            }
        }

        private static void CreateVector4Input(Vector4 value, string name, Action<object> onChange)
        {
            if (ImGui.InputFloat4("##" + name, ref value))
            {
                onChange.Invoke(value);
            }
        }

        private static void CreateQuaternionInput(Quaternion value, string name, Action<object> onChange)
        {
            Vector4 temp = value.AsVector4();

            if (ImGui.InputFloat4("##" + name, ref temp))
            {
                onChange.Invoke(temp.AsQuaternion());
            }
        }

        private static void CreateMatrix3x4Input(Matrix3x4 m, string name, Action<object> onChange)
        {
            Vector4 row0 = new Vector4(m.M11, m.M12, m.M13, m.M14);
            Vector4 row1 = new Vector4(m.M21, m.M22, m.M23, m.M24);
            Vector4 row2 = new Vector4(m.M31, m.M32, m.M33, m.M34);

            if (ImGui.InputFloat4("##" + name + "Row0", ref row0) ||
                ImGui.InputFloat4("##" + name + "Row1", ref row1) ||
                ImGui.InputFloat4("##" + name + "Row2", ref row2))
            {
                m.M11 = row0.X; m.M12 = row0.Y; m.M13 = row0.Z; m.M14 = row0.W;
                m.M21 = row1.X; m.M22 = row1.Y; m.M23 = row1.Z; m.M24 = row1.W;
                m.M31 = row2.X; m.M32 = row2.Y; m.M33 = row2.Z; m.M34 = row2.W;
                onChange.Invoke(m);
            }
        }

        private static void CreateMatrix4x4Input(Matrix4x4 m, string name, Action<object> onChange)
        {
            Vector4 row0 = new Vector4(m.M11, m.M12, m.M13, m.M14);
            Vector4 row1 = new Vector4(m.M21, m.M22, m.M23, m.M24);
            Vector4 row2 = new Vector4(m.M31, m.M32, m.M33, m.M34);
            Vector4 row3 = new Vector4(m.M41, m.M42, m.M43, m.M44);

            if (ImGui.InputFloat4("##" + name + "Row0", ref row0) ||
                ImGui.InputFloat4("##" + name + "Row1", ref row1) ||
                ImGui.InputFloat4("##" + name + "Row2", ref row2) ||
                ImGui.InputFloat4("##" + name + "Row3", ref row3))
            {
                m.M11 = row0.X; m.M12 = row0.Y; m.M13 = row0.Z; m.M14 = row0.W;
                m.M21 = row1.X; m.M22 = row1.Y; m.M23 = row1.Z; m.M24 = row1.W;
                m.M31 = row2.X; m.M32 = row2.Y; m.M33 = row2.Z; m.M34 = row2.W;
                m.M41 = row3.X; m.M42 = row3.Y; m.M43 = row3.Z; m.M44 = row3.W;
                onChange.Invoke(m);
            }
        }

        /// <summary>
        /// Renders an input for a scalar value
        /// </summary>
        private static GCHandle CreateScalarInput<T>(T value, ImGuiDataType type, string label, Action<object> onChange)
        {
            GCHandle handle = GCHandle.Alloc(value, GCHandleType.Pinned);

            if (ImGui.InputScalar(label, type, handle.AddrOfPinnedObject()))
            {
                onChange.Invoke(handle.Target!);
            }

            return handle;
        }

        /// <summary>
        /// Renders a dropdown input for an enum field
        /// </summary>
        public static bool CreateEnumInput(object value, Type type, string name, Action<object> onChange)
        {
            List<string> options = Enum.GetNames(type).ToList();
            string? optionName = Enum.GetName(type, value);
            int selectedIndex = optionName == null ? 0 : options.IndexOf(optionName);
            bool changed = false;

            if (optionName == null) {
                Console.WriteLine($"Warning: No enum associated with the value {value} for type {type} on field {name}");
            }

            if (ImGui.BeginCombo("##selectInput" + name, options[selectedIndex]))
            {
                for (int i = 0; i < options.Count; i++)
                {
                    bool isSelected = (selectedIndex == i);

                    if (ImGui.Selectable(options[i], isSelected))
                    {
                        onChange.Invoke(Enum.Parse(type, options[i]));
                        changed = true;
                    }

                    if (isSelected)
                    {
                        ImGui.SetItemDefaultFocus();
                    }
                }
                ImGui.EndCombo();
            }

            return changed;
        }

        /// <summary>
        /// Renders a dropdown input for an igObjectRefMetaField
        /// </summary>
        private static void CreateObjectRefInputIgz(FileRenderer renderer, igObject? obj, Type type, string label, Action<object?> onChange)
        {
            // External reference (REXT, RNEX)
            if (obj?.Reference != null)
            {
                string displayName = $"{obj.Reference.namespaceName}::{obj.Reference.objectName}";

                CreateStringInput(displayName, label, (newVal) => 
                {
                    renderer.SetUpdated();

                    if (newVal == null)
                    {
                        obj.Reference = null;
                        onChange.Invoke(null);
                    }
                    else
                    {
                        obj.Reference.SetNames((string)newVal);
                    }
                });
            }
            // Regular object pointer (ROFS)
            else
            {
                CreateObjectRefInput(renderer, obj, type, label, onChange);
            }
        }

        /// <summary>
        /// Renders a dropdown input for an object reference.
        /// It contains the name of all objects that inherit from the given type in the file.
        /// </summary>
        private static void CreateObjectRefInput(FileRenderer renderer, object? value, Type type, string name, Action<object?> onChange)
        {
            List<TreeNode> derivedNodes = renderer.FindDerivedObjectNodes(type, value, out int selectedIndex);
            List<string> options = derivedNodes.Select(node => node.GetDisplayName()).ToList();
            if (value != null) selectedIndex += 1;
            options.Insert(0, "null");
            options.Add($"(+) New {type.Name}...");

            ImGui.AlignTextToFramePadding();

            float availableWidth = ImGui.GetContentRegionAvail().X;
            float spacing = ImGui.GetStyle().ItemSpacing.X;
            float arrowWidth = 20;
            float maxTextWidth = availableWidth - arrowWidth - spacing;

            // Display object name
            if (value != null)
            {
                TreeNode? node = renderer.FindNode(value);

                if (node != null)
                {
                    ImGui.Text(ImGuiUtils.TruncateTextToFit(node.GetDisplayName(), maxTextWidth));
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
                        if (ImGui.IsItemClicked(ImGuiMouseButton.Left))
                        {
                            // Focus referenced object
                            renderer.TreeView.SelectChildNode(node);
                        }
                    }
                }
                else ImGui.Text("<Not found>");
            }
            else ImGui.Text("null");

            ImGui.SameLine();
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - arrowWidth);

            // Display dropdown input
            if (ImGui.BeginCombo(name, options[selectedIndex], ImGuiComboFlags.NoPreview))
            {
                for (int i = 0; i < options.Count; i++)
                {
                    bool isSelected = (selectedIndex == i);

                    if (ImGui.Selectable(options[i], isSelected))
                    {
                        selectedIndex = i;

                        // Set object ref to null
                        if (i == 0)
                        {
                            onChange.Invoke(null);
                        }
                        // Update object ref
                        else if (i < options.Count - 1)
                        {
                            onChange.Invoke(derivedNodes[i - 1]);
                        }
                        // Create new object
                        else
                        {
                            object obj = Activator.CreateInstance(type)!;

                            if (renderer is IgzRenderer igzRenderer && obj is igObject igObj)
                            {
                                IgzTreeNode node = new IgzTreeNode(igObj);

                                onChange.Invoke(node);

                                igzRenderer.TreeView.Add(node);
                                igzRenderer.TreeView.SelectChildNode(node);

                                igObj.MemoryPool = igzRenderer.TreeView.ObjectNodes[0].Object!.MemoryPool;
                            }
                        }
                    }

                    if (isSelected)
                    {
                        ImGui.SetItemDefaultFocus();
                    }
                }
                ImGui.EndCombo();
            }
        }

        private static void RenderHkMemory<T>(hkMemoryBase<T?> memory, FileRenderer renderer, string name)
        {
            RenderMemory(memory.GetElements(), renderer, memory.GetType(), name);
        }

        /// <summary>
        /// Renders a collapsible field that displays the contents of a list
        /// </summary>
        public static void RenderMemory<T>(IList<T?> mem, FileRenderer renderer, Type type, string name)
        {
            bool isExpanded = false;
            bool isEmpty = mem.Count == 0;

            ImGui.PushID(name);

            // Display name

            TableNextRow(renderer, !isEmpty);

            if (mem.Count == 0)
            {
                ImGui.Text(name);
            }
            else
            {
                ImGui.SetNextItemAllowOverlap();
                isExpanded = ImGui.TreeNodeEx(name, ImGuiTreeNodeFlags.SpanAllColumns);
            }

            // Display type

            ImGui.TableNextColumn();
            RenderType(type);

            // Display value

            ImGui.TableNextColumn();
            
            if (isExpanded)
            {
                ImGui.Text($"(-) Collapse array");
                ImGui.Indent(1);

                // Display elements

                float deleteButtonWidth = ImGui.CalcTextSize("x").X + ImGui.GetStyle().FramePadding.X * 2;

                for (int i = 0; i < mem.Count; i++)
                {
                    RenderField(renderer, mem[i], typeof(T), $"{name}[{i}]", (value) => 
                    {
                        // On field update
                        if (typeof(T).IsAssignableTo(typeof(igObject)))
                        {
                            IgzTreeNode? newNode = (IgzTreeNode?)value;

                            mem[i] = (T?)(object?)newNode?.Object;

                            renderer.OnObjectRefChanged();
                        }
                        else if (typeof(T).IsAssignableTo(typeof(hkObject)))
                        {
                            HavokTreeNode? newNode = (HavokTreeNode?)value;

                            mem[i] = (T?)(object?)newNode?.Object;

                            renderer.OnObjectRefChanged();
                        }
                        else
                        {
                            mem[i] = (T?)value;
                            renderer.SetUpdated();
                        }
                    });

                    // Display delete button
                    ImGui.TableSetColumnIndex(0);
                    ImGui.SameLine();
                    ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - deleteButtonWidth);
                    if (ImGui.Button("x##" + i))
                    {
                        mem.RemoveAt(i);
                    }
                }
                
                // Display add button
                ImGui.TableNextRow();
                ImGui.TableSetColumnIndex(2);

                renderer.PopStyles(2);
                isEmpty = true;

                if (ImGui.Button("Add element", new Vector2(-1, 0)))
                {
                    if (type.IsAssignableTo(typeof(igMetaField)))
                    {
                        mem.Add((T?)Activator.CreateInstance(typeof(T)));
                    }
                    else
                    {
                        mem.Add(default);
                    }
                }

                ImGui.Unindent(1);
                ImGui.TreePop();
            }
            else
            {
                if (mem.Count > 0)
                {
                    ImGui.Text($"(+) {mem.Count} elements");

                    // Display export button
                    if (typeof(T) == typeof(u8))
                    {
                        ImGui.SameLine();
                        if (ImGui.SmallButton("Export raw"))
                        {
                            string? path = FileExplorer.SaveFile("", FileExplorer.EXT_ALL, name + ".bin");
                            if (path != null)
                            {
                                File.WriteAllBytes(path, mem.Cast<u8>().ToArray());
                            }
                        }
                    }
                }
                else
                {
                    float buttonWidth = ImGui.CalcTextSize("\uEA0A").X + ImGui.GetStyle().FramePadding.X * 2 + 2;
                    
                    ImGui.Text($"Inactive");
                    ImGui.SameLine();
                    ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - buttonWidth);

                    // Display "+" button
                    if (ImGui.Button("\uEA0A"))
                    {
                        if (type.IsAssignableTo(typeof(igMetaField)))
                        {
                            mem.Add((T?)Activator.CreateInstance(typeof(T)));
                        }
                        else
                        {
                            mem.Add(default);
                        }
                    }
                }

                if (!isEmpty)
                    renderer.PopStylesOnNextRow(2);
            }

            ImGui.PopID();
        }

        /// <summary>
        /// Renders a collapsible field that displays the contents of a fixed-length array
        /// </summary>
        private static void RenderArray(IgzRenderer renderer, Array array, string name, Type type)
        {
            Type elementType = type.GetElementType()!;

            TableNextRow(renderer, true);

            bool isExpanded = ImGui.TreeNodeEx($"{name} ({array.Length})", ImGuiTreeNodeFlags.SpanAllColumns);

            if (isExpanded)
            {
                ImGui.TableNextColumn();

                ImGui.Text($"(-) Collapse array");
                ImGui.Indent(1);

                for (int i = 0; i < array.Length; i++)
                {
                    RenderField(renderer, array.GetValue(i), elementType, $"{name}[{i}]", (value) => 
                    { 
                        array.SetValue(value, i);
                        renderer.SetUpdated();
                    });
                }

                ImGui.Unindent(1);
                ImGui.TreePop();
            }
            else
            {
                ImGui.TableNextColumn();
                RenderType(type);

                ImGui.TableNextColumn();
                ImGui.Text($"(+) {array.Length} elements");
            }

            renderer.PopStylesOnNextRow(2);
        }

        /// <summary>
        /// Renders a list of key and value pairs from an igHashTable
        /// </summary>
        public static void RenderHashTable<K, V>(IgzRenderer renderer, igHashTable<K, V> table) where K : notnull
        {
            ImGui.Spacing();
            ImGui.Text($"HashTable preview ({table.Dict.Count}):");
            ImGui.Spacing();

            if (!ImGui.BeginTable("HashTable" + table, 2, ImGuiTableFlags.Resizable | ImGuiTableFlags.RowBg | ImGuiTableFlags.SizingStretchProp | ImGuiTableFlags.NoSavedSettings))
            {
                return;
            }

            float columnWidth = ImGui.GetContentRegionAvail().X / 2;
            ImGui.TableSetupColumn("Keys", ImGuiTableColumnFlags.WidthFixed, columnWidth);
            ImGui.TableSetupColumn("Values", ImGuiTableColumnFlags.WidthFixed, columnWidth);

            ImGui.TableNextRow(ImGuiTableRowFlags.Headers);

            ImGui.TableNextColumn();
            ImGui.Text("Keys ("); ImGui.SameLine();
            RenderType(typeof(K));
            ImGui.SameLine(); ImGui.Text(")");

            ImGui.TableNextColumn();
            ImGui.Text("Values ("); ImGui.SameLine();
            ImGui.SameLine();
            RenderType(typeof(V));
            ImGui.SameLine(); ImGui.Text(")");

            bool igObjectKey = typeof(K).IsAssignableTo(typeof(igObject));
            bool igObjectValue = typeof(V).IsAssignableTo(typeof(igObject));

            table.BuildDict(skipDuplicateKeys: true);

            for (int i = 0; i < table.Dict.Count; i++)
            {
                K key = table.Keys.ElementAt(i);
                V value = table.Values.ElementAt(i);

                int hashtableIndex = table._keys.IndexOf(key);

                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGui.SetNextItemWidth(-1);

                if (igObjectKey)
                {
                    CreateObjectRefInputIgz(renderer, (igObject)(object)key, typeof(K), "keys" + i, (newVal) => 
                    {
                        // igObjectRef key update
                        IgzTreeNode? node = (IgzTreeNode?)newVal;

                        table._keys[hashtableIndex] = (K?)(object?)node?.Object;
                        table.RebuildDict = true;
                        
                        renderer.OnObjectRefChanged();
                    });
                }
                else if (key is igMetaField metaFieldKey)
                {
                    MetaFieldRenderer.Render(renderer, metaFieldKey, typeof(K), "keys" + i, false);
                }
                else
                {
                    CreateInput(renderer, table.Keys.ElementAt(i), typeof(K), "keys" + i, (newKey) =>
                    {
                        // Key update
                        table._keys[hashtableIndex] = (K?)newKey;
                        table.RebuildDict = true;
                        renderer.SetUpdated();
                    });
                }

                ImGui.TableNextColumn();
                ImGui.SetNextItemWidth(-1);

                if (igObjectValue)
                {
                    CreateObjectRefInputIgz(renderer, (igObject?)(object?)value, typeof(V), "values" + i, (newVal) => 
                    {
                        // igObjectRef value update
                        IgzTreeNode? node = (IgzTreeNode?)newVal;

                        table._values[hashtableIndex] = (V?)(object?)node?.Object;
                        table.RebuildDict = true;

                        renderer.OnObjectRefChanged();
                    });
                }
                else if (value is igMetaField metaFieldValue)
                {
                    MetaFieldRenderer.Render(renderer, metaFieldValue, typeof(V), "values" + i, false);
                }
                else
                {
                    CreateInput(renderer, table.Values.ElementAt(i), typeof(V), "values" + i, (newValue) =>
                    {
                        // Value update
                        table._values[hashtableIndex] = (V?)newValue;
                        table.RebuildDict = true;
                        renderer.SetUpdated();
                    });
                }
            }

            ImGui.EndTable();

            if (table.Dict.Count == 0)
            {
                ImGui.Text("(Hash table is empty)");
            }
        }

        public static void HandleCopyPaste(FileRenderer renderer, string name, object? value, Type type, Action<object?>? onChange = null)
        {
            // Check if this field can be copied

            if (type.IsValueType || type == typeof(string)) return;

            bool isIgObject = type.IsAssignableTo(typeof(igObject));
            bool isHkObject = type.IsAssignableTo(typeof(hkObject));
            bool isMetaField = type.IsAssignableTo(typeof(igMetaField));

            if (!isIgObject && !isHkObject && !isMetaField) return;

            // Render the context menu

            if (!ImGui.BeginPopupContextItem("FieldActions" + name))
            {
                return;
            }

            name = name.Substring(0, name.Length - 6);

            RenderType(type); 
            ImGui.SameLine(); 
            ImGui.Text(": " + name);

            ImGui.Separator();

            // Copy object

            if (value != null && ImGui.Selectable($"Copy value"))
            {
                if (isMetaField && value is igMetaField metaField)
                {
                    _copyObject = metaField.Clone();
                }
                else if (isIgObject && renderer is IgzRenderer igzRenderer)
                {
                    _copyObject = igzRenderer.FindNode(value);
                }
                else if (isHkObject && renderer is HavokRenderer havokRenderer)
                {
                    _copyObject = havokRenderer.FindNode(value);
                }

                _copyRenderer = renderer;
            }

            // Check if the copied object can be pasted into this field

            bool canPaste = false;

            if (_copyObject != null)
            {
                if (isMetaField)
                {
                    canPaste  = _copyObject is igMetaField mf && mf.GetType().IsAssignableTo(type);
                    canPaste &= _copyObject is not igBitFieldMetaField || _copyObject.GetType() == value?.GetType();
                }
                else if (_copyRenderer == renderer)
                {
                    if (isIgObject)
                    {
                        canPaste = _copyObject is IgzTreeNode node && node.Object?.GetType().IsAssignableTo(type) == true;
                    }
                    else if (isHkObject)
                    {
                        canPaste = _copyObject is HavokTreeNode node && node.Object?.GetType().IsAssignableTo(type) == true;
                    }
                }
            }

            // Paste object
            
            if (canPaste && ImGui.Selectable($"Paste value"))
            {
                if (isMetaField && _copyObject is igMetaField source && value is igMetaField target)
                {
                    source.CopyTo(target);
                    renderer.SetUpdated();
                }
                else if (isIgObject || isHkObject)
                {
                    onChange?.Invoke(_copyObject);
                }
            }

            if (value is igHandleMetaField handle && handle.Reference != null)
            {
                if (ImGui.Selectable(handle.Reference.isEXID ? "Clear EXID" : "Convert to EXID"))
                {
                    handle.Reference.isEXID = !handle.Reference.isEXID;
                }
            }
            else if (value is IMemoryRef mem)
            {
                if (ImGui.Selectable($"Clear value"))
                {
                    mem.Clear();
                    renderer.SetUpdated();
                }
            }
            else if (value == null && !canPaste)
            {
                ImGui.Text("No available action");
            }

            ImGui.EndPopup();
        }
    }
}