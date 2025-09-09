using Alchemy;
using Havok;
using ImGuiNET;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NST
{
    /// <summary>
    /// Handles rendering of object fields
    /// </summary>
    public static class FieldRenderer
    {
        /// <summary>
        /// Parent of the current fields being rendered, used to register object updates
        /// </summary>
        public static object ParentObject { get; set; }

        /// <summary>
        /// Render all fields of the given igObjectBase or hkObject instance
        /// </summary>
        public static void RenderFields(FileRenderer renderer, object obj)
        {
            List<CachedFieldAttr> fields = AttributeUtils.GetAttributes(obj.GetType()).GetFields();

            if (obj is igObject) fields = fields[2..]; // Hide "type ID" and "reference count" fields for igObjects

            foreach (CachedFieldAttr field in fields)
            {
                string name = field.GetName();
                Type fieldType = field.GetFieldType();

                object? value = field.GetValue(obj);

                Action<object> onChange = (newVal) => 
                {
                    field.SetValue(obj, newVal);
                    renderer.SetUpdated();
                };

                RenderField(renderer, value, fieldType, name, onChange);
            }
        }

        /// <summary>
        /// Render a single field (name, type, editable value)
        /// </summary>
        public static void RenderField(FileRenderer renderer, object? value, Type type, string name, Action<object> onChange)
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

        private static void RenderIgzField(IgzRenderer renderer, object? value, Type type, string name, Action<object> onChange)
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
                RenderNameAndType(renderer, type, name);
                CreateInput(renderer, value, type, name, onChange);
            }
        }

        private static void RenderHavokField(HavokRenderer renderer, object? value, Type type, string name, Action<object> onChange)
        {
            if (value is hkMemoryBase)
            {
                // Memory field
                RenderHkMemory((dynamic)value, renderer, name);
            }
            else
            {
                // Regular field
                RenderNameAndType(renderer, type, name);
                CreateInput(renderer, value, type, name, onChange);
            }
        }
        
        /// <summary>
        /// Render a field's name and type
        /// </summary>
        public static void RenderNameAndType(FileRenderer renderer, Type type, string name)
        {
            TableNextRow(renderer);
            ImGui.Text(name);

            ImGui.TableNextColumn();
            RenderType(type);

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
        public static void CreateInput(FileRenderer renderer, object? value, Type type, string name, Action<object> onChange)
        {
            string label = "##" + name;

            // Nullable types

            if (type.IsAssignableTo(typeof(igObject)))
            {
                CreateObjectRefInputIgz(renderer, (igObject?)value, type, name);
            }
            else if (type.IsAssignableTo(typeof(hkObject)))
            {
                CreateObjectRefInput(renderer, value, type, name);
            }
            else if (type == typeof(string))
            {
                CreateStringInput(renderer, (string?)value, name, onChange);
            }

            else if (value == null)
            {
                ImGui.Text("null");
                Console.Error.WriteLine("Warning: Trying to render a null value (this should only happen for object references or strings)");
            }

            // Non-nullable types
            
            else if (type.IsEnum)
            {
                CreateEnumInput(renderer, value, type, name, onChange);
            }
            else if (type == typeof(bool))
            {
                CreateBoolInput(renderer, (bool)value, name, onChange);
            }
            else if (type == typeof(Vector4))
            {
                CreateVector4Input(renderer, (Vector4)value, name, onChange);
            }
            else if (type == typeof(Quaternion))
            {
                CreateQuaternionInput(renderer, (Quaternion)value, name, onChange);
            }
            else if (type == typeof(Matrix4x4))
            {
                CreateMatrix4x4Input(renderer, (Matrix4x4)value, name, onChange);
            }
            else if (type == typeof(Matrix3x4))
            {
                CreateMatrix3x4Input(renderer, (Matrix3x4)value, name, onChange);
            }
            else
            {
                // Scalar types
                GCHandle handle = default;

                if      (type == typeof(i8))    handle = CreateScalarInput(renderer, (i8)value,  ImGuiDataType.S8,  label, onChange);
                else if (type == typeof(u8))    handle = CreateScalarInput(renderer, (u8)value,  ImGuiDataType.U8,  label, onChange);
                else if (type == typeof(i16))   handle = CreateScalarInput(renderer, (i16)value, ImGuiDataType.S16, label, onChange);
                else if (type == typeof(u16))   handle = CreateScalarInput(renderer, (u16)value, ImGuiDataType.U16, label, onChange);
                else if (type == typeof(i32))   handle = CreateScalarInput(renderer, (i32)value, ImGuiDataType.S32, label, onChange);
                else if (type == typeof(u32))   handle = CreateScalarInput(renderer, (u32)value, ImGuiDataType.U32, label, onChange);
                else if (type == typeof(i64))   handle = CreateScalarInput(renderer, (i64)value, ImGuiDataType.S64, label, onChange);
                else if (type == typeof(u64))   handle = CreateScalarInput(renderer, (u64)value, ImGuiDataType.U64, label, onChange);
                else if (type == typeof(float)) handle = CreateScalarInput(renderer, (float)value, ImGuiDataType.Float, label, onChange);
                else if (type == typeof(Half))  handle = CreateScalarInput(renderer, (float)(Half)value, ImGuiDataType.Float, label, val => onChange.Invoke((Half)(float)val));
                else
                {
                    ImGui.Text(value.ToString());
                    Console.Error.WriteLine($"Warning: Rendering of type {type.Name} is not supported.");
                }

                if (handle.IsAllocated)
                    handle.Free();
            }
        }

        private static void CreateStringInput(FileRenderer renderer, string? value, string name, Action<object> onChange)
        {
            if (value == null) value = "";

            if (ImGui.InputText("##" + name, ref value, 256, ImGuiInputTextFlags.AlwaysOverwrite))
            {
                onChange.Invoke(value);
            }
        }

        private static void CreateBoolInput(FileRenderer renderer, bool value, string name, Action<object> onChange)
        {
            if (ImGui.Checkbox("##" + name, ref value))
            {
                onChange.Invoke(value);
            }
        }

        private static void CreateVector4Input(FileRenderer renderer, Vector4 value, string name, Action<object> onChange)
        {
            if (ImGui.InputFloat4("##" + name, ref value))
            {
                onChange.Invoke(value);
            }
        }

        private static void CreateQuaternionInput(FileRenderer renderer, Quaternion value, string name, Action<object> onChange)
        {
            Vector4 temp = value.AsVector4();

            if (ImGui.InputFloat4("##" + name, ref temp))
            {
                onChange.Invoke(temp.AsQuaternion());
            }
        }

        private static void CreateMatrix3x4Input(FileRenderer renderer, Matrix3x4 m, string name, Action<object> onChange)
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

        private static void CreateMatrix4x4Input(FileRenderer renderer, Matrix4x4 m, string name, Action<object> onChange)
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
        private static GCHandle CreateScalarInput<T>(FileRenderer renderer, T value, ImGuiDataType type, string label, Action<object> onChange)
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
        private static void CreateEnumInput(FileRenderer renderer, object value, Type type, string name, Action<object> onChange)
        {
            List<string> options = Enum.GetNames(type).ToList();
            int selectedIndex = options.IndexOf(Enum.GetName(type, value)!);

            if (ImGui.BeginCombo("##selectInput" + name, options[selectedIndex]))
            {
                for (int i = 0; i < options.Count; i++)
                {
                    bool isSelected = (selectedIndex == i);

                    if (ImGui.Selectable(options[i], isSelected))
                    {
                        onChange.Invoke(Enum.Parse(type, options[i]));
                    }

                    if (isSelected)
                    {
                        ImGui.SetItemDefaultFocus();
                    }
                }
                ImGui.EndCombo();
            }
        }

        /// <summary>
        /// Renders a dropdown input for an igObjectRefMetaField
        /// </summary>
        private static void CreateObjectRefInputIgz(FileRenderer renderer, igObject? value, Type type, string label)
        {
            // External reference (REXT, RNEX)
            if (value?.GetReference() is NamedReference reference)
            {
                string displayName = $"{reference.namespaceName}::{reference.objectName}";

                CreateInput(renderer, displayName, typeof(string), label + "file", (newVal) => 
                {
                    reference.SetNames((string)newVal);
                    renderer.SetUpdated();
                });
            }
            // Regular object pointer (ROFS)
            else
            {
                CreateObjectRefInput(renderer, value, type, label);
            }
        }

        /// <summary>
        /// Renders a dropdown input for an object reference.
        /// It contains the name of all objects that inherit from the given type in the file.
        /// </summary>
        private static void CreateObjectRefInput(FileRenderer renderer, object? value, Type type, string name)
        {
            List<string> options = renderer.FindDerivedObjectNames(type, value, out int selectedIndex);
            if (value != null) selectedIndex += 1;
            options.Insert(0, "null");
            options.Add($"(+) New {type.Name}...");

            ImGui.AlignTextToFramePadding();

            float availableWidth = ImGui.GetContentRegionAvail().X;
            float spacing = ImGui.GetStyle().ItemSpacing.X;
            float arrowWidth = 20;
            float maxTextWidth = availableWidth - arrowWidth - spacing;

            if (value != null)
            {
                string text = renderer.FindNode(value).GetDisplayName();
                ImGui.Text(ImGuiUtils.TruncateTextToFit(text, maxTextWidth));
                if (ImGui.IsItemHovered())
                {
                    ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
                    if (ImGui.IsItemClicked(ImGuiMouseButton.Left))
                    {
                        renderer.TreeView.SetSelectedNode(renderer.FindNode(value), true);
                    }
                }
            }
            else
            {
                ImGui.Text("null");
            }

            ImGui.SameLine();
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - arrowWidth);

            if (ImGui.BeginCombo(name, options[selectedIndex], ImGuiComboFlags.NoPreview))
            {
                for (int i = 0; i < options.Count; i++)
                {
                    bool isSelected = (selectedIndex == i);

                    if (ImGui.Selectable(options[i], isSelected))
                    {
                        selectedIndex = i;
                        renderer.SetUpdated();
                    }

                    if (isSelected)
                    {
                        ImGui.SetItemDefaultFocus();
                    }
                }
                ImGui.EndCombo();
            }
        }

        private static void RenderHkMemory<T>(hkMemory<T> memory, FileRenderer renderer, string name)
        {
            RenderMemory(memory.GetElements(), renderer, memory.GetType(), name);
        }

        /// <summary>
        /// Renders a collapsible field that displays the contents of a list
        /// </summary>
        public static void RenderMemory<T>(List<T> mem, FileRenderer renderer, Type type, string name)
        {
            bool isExpanded = false;
            bool isEmpty = mem.Count == 0;

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

                for (int i = 0; i < mem.Count; i++)
                {
                    RenderField(renderer, mem[i], typeof(T), $"{name}[{i}]", (value) => mem[i] = (T)value);
                }

                ImGui.Unindent(1);
                ImGui.TreePop();
            }
            else
            {
                // if (mem.IsActive())
                if (mem.Count > 0)
                {
                    ImGui.Text($"(+) {mem.Count} elements");

                    if (typeof(T) == typeof(u8))
                    {
                        ImGui.SameLine();
                        if (ImGui.SmallButton("Export raw"))
                        {
                            string? path = FileExplorer.SaveFile("", FileExplorer.EXT_ALL, name + ".bin");
                            if (path == null) return;

                            File.WriteAllBytes(path, mem.Cast<u8>().ToArray());
                        }
                    }
                }
                else
                {
                    ImGui.Text($"Inactive");
                }
            }

            if (!isEmpty)
                renderer.PopStylesOnNextRow(2);
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
                    RenderField(renderer, array.GetValue(i), elementType, $"{name}[{i}]", (value) => { array.SetValue(value, i); });
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
        public static void RenderHashTable<K, V>(IgzRenderer renderer, igHashTable<K, V> table, string name) where K : notnull
        {
            if (!ImGui.BeginTable("HashTable" + name, 2, ImGuiTableFlags.Resizable | ImGuiTableFlags.RowBg | ImGuiTableFlags.SizingStretchProp | ImGuiTableFlags.NoSavedSettings))
            {
                ImGui.Text("Failed to render HashTable");
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

            for (int i = 0; i < table.Dict.Count; i++)
            {
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGui.SetNextItemWidth(-1);

                K key = table.Keys.ElementAt(i);
                MethodInfo? renderValueMethod = key.GetType().GetMethod("RenderValue");

                if (key is igObject objectRefKey)
                {
                    CreateObjectRefInput(renderer, objectRefKey, typeof(K), "keys" + i);
                }
                else
                {
                    if (renderValueMethod != null)
                    {
                        renderValueMethod.Invoke(key, new object[] { renderer, "keys" + i });
                    }
                    else
                    {
                        CreateInput(renderer, table.Keys.ElementAt(i), typeof(K), "keys" + i, (newKey) =>
                        {
                            table.Dict.Remove(table.Keys.ElementAt(i));
                            table[(K)newKey] = table.Values.ElementAt(i);
                        });
                    }
                }

                ImGui.TableNextColumn();
                ImGui.SetNextItemWidth(-1);

                V value = table.Values.ElementAt(i);

                if (value is igObject objectRef)
                {
                    CreateObjectRefInput(renderer, objectRef, typeof(V), "values" + i);
                }
                else
                {
                    renderValueMethod = value?.GetType().GetMethod("RenderValue");
                    if (renderValueMethod != null)
                    {
                        renderValueMethod.Invoke(value, new object[] { renderer, "values" + i });
                    }
                    else
                    {
                        CreateInput(renderer, table.Values.ElementAt(i), typeof(V), "values" + i, (newValue) =>
                        {
                            table[table.Keys.ElementAt(i)] = (V)newValue;
                        });
                    }
                }
            }

            ImGui.EndTable();
        }
    }
}