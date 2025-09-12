using Alchemy;
using ImGuiNET;

namespace NST
{
    /// <summary>
    /// Utilities for rendering igMetaFields
    /// </summary>
    public static class MetaFieldRenderer
    {
        /// <summary>
        /// Renders an igMetaField
        /// </summary>
        public static void Render(IgzRenderer renderer, igMetaField metaField, Type type, string name, bool renderNameAndType = true)
        {
            // igMemoryRef, igVector
            if (type.IsGenericType)
            {
                RenderMemory((dynamic)metaField, renderer, name);
            }
            // igBitField
            else if (metaField is igBitFieldMetaField bitfield)
            {
                int fieldCount = AttributeUtils.GetAttributes(type).GetFields().Count;
                RenderMetaField(bitfield, renderer, typeof(igBitFieldMetaField), name, "(-) Collapse fields", $"(+) {fieldCount} hidden fields");
            }
            // Custom render methods
            else if (RenderMethods.TryGetValue(type, out var renderMethod))
            {
                if (renderNameAndType) 
                    FieldRenderer.RenderNameAndType(renderer, metaField.GetType(), name);

                renderMethod(metaField, renderer, name);
            }
            // Generic render method
            else
            {
                RenderMetaField(metaField, renderer, type, name, "(-) Collapse Metafield", "(+) Expand Metafield");
            }
        }

        /// <summary>
        /// Generic render method for igMetaFields (displays all fields in a collapsible tree)
        /// </summary>
        private static void RenderMetaField(igMetaField metaField, FileRenderer renderer, Type type, string name, string collapseLabel, string expandLabel)
        {
            FieldRenderer.TableNextRow(renderer, true);

            bool isExpanded = ImGui.TreeNodeEx(name, ImGuiTreeNodeFlags.SpanAllColumns);

            ImGui.TableNextColumn();
            FieldRenderer.RenderType(type);

            ImGui.TableNextColumn();

            if (isExpanded)
            {
                ImGui.Text(collapseLabel);
                ImGui.Indent(1);
                FieldRenderer.RenderFields(renderer, metaField);
                ImGui.Unindent(1);
                ImGui.TreePop();
            }
            else
            {
                ImGui.Text(expandLabel);
            }

            renderer.PopStylesOnNextRow(2);
        }

        /// <summary>
        /// Custom render methods for igMetaFields
        /// </summary>
        private static readonly Dictionary<Type, Action<igMetaField, IgzRenderer, string>> RenderMethods = new ()
        {
            { typeof(igHandleMetaField),      (obj, renderer, name) => Render((igHandleMetaField)obj, renderer, name) },
            { typeof(igRawRefMetaField),      (obj, renderer, name) => Render((igRawRefMetaField)obj, renderer, name) },
            { typeof(igKerningPairMetaField), (obj, renderer, name) => Render((igKerningPairMetaField)obj, renderer, name) },
            { typeof(igVec2fMetaField),       (obj, renderer, name) => Render((igVec2fMetaField)obj, renderer, name) },
            { typeof(igVec3fMetaField),       (obj, renderer, name) => Render((igVec3fMetaField)obj, renderer, name) },
            { typeof(igVec4fMetaField),       (obj, renderer, name) => Render((igVec4fMetaField)obj, renderer, name) },
            { typeof(igQuaternionfMetaField), (obj, renderer, name) => Render((igQuaternionfMetaField)obj, renderer, name) },
            { typeof(igMatrix44fMetaField),   (obj, renderer, name) => Render((igMatrix44fMetaField)obj, renderer, name) },
            { typeof(igNameMetaField),        (obj, renderer, name) => Render((igNameMetaField)obj, renderer, name) },
            { typeof(igRandomMetaField),      (obj, renderer, name) => Render((igRandomMetaField)obj, renderer, name) },
            { typeof(igRangedFloatMetaField), (obj, renderer, name) => Render((igRangedFloatMetaField)obj, renderer, name) },
            { typeof(igSizeTypeMetaField),    (obj, renderer, name) => Render((igSizeTypeMetaField)obj, renderer, name) },
            { typeof(igTimeMetaField),        (obj, renderer, name) => Render((igTimeMetaField)obj, renderer, name) },
            { typeof(igEnumMetaField),        (obj, renderer, name) => Render((igEnumMetaField)obj, renderer, name) },
            { typeof(CConstraintMetaField),   (obj, renderer, name) => Render((CConstraintMetaField)obj, renderer, name) },
            { typeof(CEntityIDMetaField),     (obj, renderer, name) => Render((CEntityIDMetaField)obj, renderer, name) },
            { typeof(ChunkFileInfoMetaField), (obj, renderer, name) => Render((ChunkFileInfoMetaField)obj, renderer, name) },
        };

        private static void RenderMemory<T>(igMemoryRef<T?> obj, FileRenderer renderer, string name)
        {
            FieldRenderer.RenderMemory(obj.GetElements(), renderer, obj.GetType(), name);
        }
        
        private static void RenderMemory<T>(igVectorMetaField<T?> obj, FileRenderer renderer, string name)
        {
            FieldRenderer.RenderMemory(obj._data.GetElements(), renderer, obj.GetType(), name);
        }

        private static void Render(igHandleMetaField obj, IgzRenderer renderer, string name)
        {
            NamedReference? reference = obj.GetReference();

            ImGui.PushID(name);

            // Null reference
            if (reference == null)
            {
                ImGui.Text("null");
                ImGui.SameLine();

                float addButtonWidth = ImGui.CalcTextSize("\uEA0A").X + ImGui.GetStyle().FramePadding.X * 2 + 2;
                ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - addButtonWidth);
                
                if (ImGui.Button("\uEA0A"))
                {
                    obj.SetReference(new NamedReference());
                }

                ImGui.PopID();

                return;
            }

            // Namespace field
            FieldRenderer.CreateStringInput(renderer, reference.namespaceName, name + "file", (newVal) => 
            {
                if (newVal == null) {
                    obj.SetReference(null);
                }
                else {
                    reference.SetNamespace((string)newVal);
                }
                renderer.OnObjectRefChanged();
            });

            float buttonWidth = ImGui.CalcTextSize(" Open ").X;
            ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - buttonWidth - ImGui.GetStyle().ItemSpacing.X * 2);

            // Object field
            FieldRenderer.CreateStringInput(renderer, reference.objectName, name + "object", (newVal) => 
            {
                if (newVal == null) return;
                reference.SetObject((string)newVal);
                renderer.OnObjectRefChanged();
            }, false);
            
            // Open button
            ImGui.SameLine();
            if (ImGui.Button(" Open ##" + obj.GetHashCode()))
            {
                App.FocusObject(reference, renderer);
            }

            ImGui.PopID();
        }

        private static void Render(igRawRefMetaField obj, FileRenderer renderer, string name)
        {
            ImGui.Text(obj._address == 0 ? "Inactive" : "Active");
        }

        private static void Render(CConstraintMetaField obj, FileRenderer renderer, string name)
        {
            CreateFloat2Input(renderer, name, ref obj._min, ref obj._max);
        }

        private static void Render(CEntityIDMetaField obj, FileRenderer renderer, string name)
        {
            FieldRenderer.CreateInput(renderer, obj._entityID, typeof(int), "_entityID", (newVal) => { obj._entityID = (int)newVal!; renderer.SetUpdated(); });
        }

        private static void Render(ChunkFileInfoMetaField obj, FileRenderer renderer, string name)
        {
            float availableWidth = ImGui.GetContentRegionAvail().X - 10.0f;

            ImGui.PushItemWidth(availableWidth * 0.25f);
            FieldRenderer.CreateStringInput(renderer, obj._type, name + "type", (newVal) => { obj._type = (string?)newVal; renderer.SetUpdated(); });
            ImGui.PopItemWidth();

            ImGui.SameLine();

            ImGui.PushItemWidth(availableWidth * 0.75f);
            FieldRenderer.CreateStringInput(renderer, obj._name, name + "name", (newVal) => { obj._name = (string?)newVal; renderer.SetUpdated(); });
            ImGui.PopItemWidth();
        }

        private static void Render(igKerningPairMetaField obj, FileRenderer renderer, string name)
        {
            CreateInt2Input(renderer, name, ref obj._first, ref obj._second);
        }

        private static void Render(igVec2fMetaField obj, FileRenderer renderer, string name)
        {
            CreateFloat2Input(renderer, name, ref obj._x, ref obj._y);
        }

        private static void Render(igVec3fMetaField obj, FileRenderer renderer, string name)
        {
            CreateFloat3Input(renderer, name, ref obj._x, ref obj._y, ref obj._z);
        }

        private static void Render(igVec4fMetaField obj, FileRenderer renderer, string name)
        {
            CreateFloat4Input(renderer, name, ref obj._x, ref obj._y, ref obj._z, ref obj._w);
        }

        private static void Render(igMatrix44fMetaField obj, FileRenderer renderer, string name)
        {
            string label = "##" + name;
            CreateFloat4Input(renderer, label + "_row0", ref obj._row0._x, ref obj._row0._y, ref obj._row0._z, ref obj._row0._w);
            CreateFloat4Input(renderer, label + "_row1", ref obj._row1._x, ref obj._row1._y, ref obj._row1._z, ref obj._row1._w);
            CreateFloat4Input(renderer, label + "_row2", ref obj._row2._x, ref obj._row2._y, ref obj._row2._z, ref obj._row2._w);
            CreateFloat4Input(renderer, label + "_row3", ref obj._row3._x, ref obj._row3._y, ref obj._row3._z, ref obj._row3._w);
        }

        private static void Render(igNameMetaField obj, FileRenderer renderer, string name)
        {
            FieldRenderer.CreateStringInput(renderer, obj._name, name, (newVal) => { obj._name = (string?)newVal; renderer.SetUpdated(); });
        }

        private static void Render(igRandomMetaField obj, FileRenderer renderer, string name)
        {
            CreateFloat2Input(renderer, name, ref obj._min, ref obj._max);
        }

        private static void Render(igRangedFloatMetaField obj, FileRenderer renderer, string name)
        {
            CreateFloat2Input(renderer, name, ref obj._min, ref obj._max);
        }

        private static void Render(igSizeTypeMetaField obj, FileRenderer renderer, string name)
        {
            FieldRenderer.CreateInput(renderer, obj._size, typeof(u64), name, (newVal) => { obj._size = (u64)newVal!; renderer.SetUpdated(); });
        }

        private static void Render(igTimeMetaField obj, FileRenderer renderer, string name)
        {
            FieldRenderer.CreateInput(renderer, obj._time, typeof(u32), name, (newVal) => { obj._time = (u32)newVal!; renderer.SetUpdated(); });
        }

        private static void Render(igEnumMetaField obj, FileRenderer renderer, string name)
        {
            FieldRenderer.CreateInput(renderer, obj._value, typeof(int), name, (newVal) => { obj._value = (int)newVal!; renderer.SetUpdated(); });
        }

        private static void CreateInt2Input(FileRenderer renderer, string name, ref uint x, ref uint y)
        {
            int[] temp = new int[2] { (int)x, (int)y };

            if (ImGui.InputInt2("##" + name, ref temp[0]))
            {
                x = (uint)temp[0];
                y = (uint)temp[1];
                renderer.SetUpdated();
            }
        }

        private static void CreateFloat2Input(FileRenderer renderer, string name, ref float x, ref float y)
        {
            System.Numerics.Vector2 temp = new System.Numerics.Vector2(x, y);
            
            if (ImGui.InputFloat2("##" + name, ref temp))
            {
                x = temp.X;
                y = temp.Y;
                renderer.SetUpdated();
            }
        }

        private static void CreateFloat3Input(FileRenderer renderer, string name, ref float x, ref float y, ref float z)
        {
            System.Numerics.Vector3 temp = new System.Numerics.Vector3(x, y, z);
            
            if (ImGui.InputFloat3("##" + name, ref temp))
            {
                x = temp.X;
                y = temp.Y;
                z = temp.Z;
                renderer.SetUpdated();
            }
        }

        private static void CreateFloat4Input(FileRenderer renderer, string name, ref float x, ref float y, ref float z, ref float w)
        {
            System.Numerics.Vector4 temp = new System.Numerics.Vector4(x, y, z, w);
            
            if (ImGui.InputFloat4("##" + name, ref temp))
            {
                x = temp.X;
                y = temp.Y;
                z = temp.Z;
                w = temp.W;
                renderer.SetUpdated();
            }
        }
    }
}