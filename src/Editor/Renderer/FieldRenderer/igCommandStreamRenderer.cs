using Alchemy;
using ImGuiNET;
using System.Numerics;
using System.Runtime.InteropServices;

namespace NST
{
    public static class igCommandStreamRenderer
    {
		private enum igCommandId
		{
			kNoop = 0,
			kSetPrimitiveType = 1,
			kSetVertexBuffer = 2,
			kSetIndexBuffer = 3,
			kSetVertexShader = 4,
			kSetVertexShaderVariant = 5,
			kSetVertexShaderTexture = 6,
			kSetVertexShaderSampler = 7,
			kSetViewport = 8,
			kSetScissor = 9,
			kSetScissorEnabled = 10,
			kSetRasterizeStateBundle = 11,
			kSetPixelShader = 12,
			kSetPixelShaderVariant = 13,
			kSetPixelShaderTexture = 14,
			kSetPixelShaderSampler = 15,
			kSetGeometryShader = 16,
			kSetGeometryShaderVariant = 17,
			kSetGeometryShaderTexture = 18,
			kSetGeometryShaderSampler = 19,
			kSetAlphaTestStateBundle = 20,
			kSetBlendStateBundle = 21,
			kSetDepthStateBundle = 22,
			kSetStencilStateBundle = 23,
			kSetStencilRef = 24,
			kSetRenderTargets = 25,
			kSetRenderTargetMask = 26,
			kSetConstantBool = 27,
			kSetConstantInt = 28,
			kSetConstantFloat = 29,
			kSetConstantVec4f = 30,
			kSetConstantMatrix44f = 31,
			kSetConstantArrayInt = 32,
			kSetConstantArrayFloat = 33,
			kSetConstantArrayVec4f = 34,
			kSetConstantArrayMatrix44f = 35,
			kApplyConstantBundle = 36,
			kApplyConstantValueList = 37,
			kSetPixelShaderTextureEnabledConstant = 38,
			kSetVertexShaderTextureEnabledConstant = 39,
			kSetPixelShaderTextureSizeConstant = 40,
			kSetVertexShaderTextureSizeConstant = 41,
			kClearRenderTarget = 42,
			kDraw = 43,
			kDrawPrimitives = 44,
			kFlush = 45,
			kResetState = 46,
			kDecodeMemoryCommandStream = 47,
			kCopyTexture = 48,
			kUpdateTexture = 49,
			kExecuteCallback = 50,
			kSetCameraMatrices = 51,
			kComputeAndSetInstanceMatrices = 52,
			kComputeAndSetInstanceConstants = 53,
			kSetCommonRenderState = 54,
			kSetDitherState = 55,
			kBeginNamedEvent = 56,
			kEndNamedEvent = 57,
			kIssueBufferedGpuTimestamp = 58,
			kNumAlchemyCommands = 59,
			kLastAlchemyCommand = 8191,
			kLastCommand = 65535,
		}

		private class igCommand
		{
			public igCommandId id;
			public igGraphicsObject? resource;
			public object? value;
			public int valueOffset = -1;

			public bool Render(IgzRenderer renderer, byte[] memoryStream)
			{
				RenderCommandName();

				ImGui.TableNextColumn();
				RenderResource(renderer);
				
				ImGui.TableNextColumn();
				bool updated = RenderValue(memoryStream);

				ImGui.TableNextColumn();
				RenderName();

				return updated;
			}

			private void RenderCommandName()
			{
				ImGui.PushStyleColor(ImGuiCol.Text, value?.GetType().GetRenderColor() ?? TypeExtensions.GetUniqueColor(id.ToString()));
				ImGui.Text(id.ToString());
				ImGui.PopStyleColor();
			}

			private void RenderResource(IgzRenderer renderer)
			{
				if (resource != null && renderer != null)
				{
					var node = renderer.FindNode(resource);

					if (node != null)
					{
						node.RenderObjectName();

						if (ImGui.IsItemHovered())
						{
							ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);

							if (ImGui.IsItemClicked())
							{
								renderer.TreeView.SetSelectedNode(node);
							}
						}
					}
					else
					{
						ImGui.TextDisabled("Not found");
					}
				}
				else ImGui.TextDisabled("-");
			}

			private bool RenderValue(byte[] memoryStream)
			{
				if (value is Vector4 vec4)
				{
					ImGui.SetNextItemWidth(-1);
					if (ImGui.ColorEdit4("##color", ref vec4, ImGuiColorEditFlags.NoInputs))
					{
						byte[] c = MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(ref vec4, 1)).ToArray();
						Buffer.BlockCopy(c, 0, memoryStream, valueOffset, c.Length);
						return true;
					}
				}
				else if (value is Matrix4x4 mat4)
				{
					ImGui.Text($"({mat4.M11}, {mat4.M12}, {mat4.M13}, {mat4.M14})\n({mat4.M21}, {mat4.M22}, {mat4.M23}, {mat4.M24})\n({mat4.M31}, {mat4.M32}, {mat4.M33}, {mat4.M34})\n({mat4.M41}, {mat4.M42}, {mat4.M43}, {mat4.M44})");
				}
				else if (value != null)
				{
					ImGui.Text($"{value}");
				}
				else ImGui.TextDisabled("-");

				return false;
			}

			private void RenderName()
			{
				string? name = null;

				if (resource is igGraphicsShaderConstant constant)
				{
					name = constant._name;
				}
				else if (resource is igGraphicsTexture texture)
				{
					name = texture._imageHandle.Reference?.namespaceName;
				}

				if (!string.IsNullOrEmpty(name))
				{
					ImGui.Text(name);
					ImGui.SetItemTooltip(name);
				}
				else ImGui.TextDisabled("-");
			}
		}

        public static bool Render(IgzRenderer renderer, igMemoryCommandStream commandStream, igGraphicsObjectSet? graphicsObjects, string label = "")
		{
			if (!ImGui.BeginTable("CommandStream##" + label, 4,                  
				  ImGuiTableFlags.Resizable 
                | ImGuiTableFlags.Reorderable 
                | ImGuiTableFlags.RowBg
                | ImGuiTableFlags.BordersInner
                | ImGuiTableFlags.Hideable
                | ImGuiTableFlags.SizingFixedFit
                | ImGuiTableFlags.NoSavedSettings))
			{
				return false;
			}

			ImGui.TableSetupColumn("Command");
			ImGui.TableSetupColumn("Resource");
			ImGui.TableSetupColumn("Value");
			ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthStretch);
			ImGui.TableHeadersRow();

			var memory = commandStream._memory.ToList();
			while (memory.Count % 4 != 0) memory.Add(0);

			byte[] bytes = memory.ToArray();
			byte[] copy = memory.ToArray();

			int offset = 0;
			int idx = 0;
			bool updated = false;

			while (offset <= bytes.Length - 4)
			{
				try
				{
					ImGui.TableNextRow();
					ImGui.TableNextColumn();
					
					ImGui.Text($"{++idx}.");
					ImGui.SameLine(0, 2);

					var command = CreateCommand(ref offset, bytes, graphicsObjects);

					updated |= command.Render(renderer, copy);
				}
				catch (Exception e)
				{
					ImGui.TextColored(new Vector4(1,0,0,1), $"{e.Message}");
					Console.WriteLine(e);
					break;
				}
			}

			ImGui.EndTable();

			if (updated)
			{
				commandStream._memory.Set(copy);
			}

			return updated;
		}

		private static igCommand CreateCommand(ref int refOffset, byte[] bytes, igGraphicsObjectSet? graphicsObjects)
		{
			int offset = refOffset;

			var commandId = (igCommandId)BitConverter.ToInt32(bytes, offset);
			var command = new igCommand() { id = commandId };
			
			offset += 8;

			igGraphicsObject? GetGraphicsObject()
			{
				int index = BitConverter.ToInt32(bytes, offset);

				offset += 4;
				offset += offset % 8;

				if (graphicsObjects == null || index >= graphicsObjects._objects.Count)
					return null;

				return graphicsObjects._objects[index];
			}

			switch (commandId)
			{
				case igCommandId.kApplyConstantValueList:
				case igCommandId.kSetBlendStateBundle:
				case igCommandId.kSetRasterizeStateBundle:
				case igCommandId.kSetRenderTargetMask:
				case igCommandId.kSetDepthStateBundle:
				case igCommandId.kSetPixelShader:
				case igCommandId.kSetVertexShader:
				case igCommandId.kSetGeometryShader:
				case igCommandId.kSetPixelShaderVariant:
				case igCommandId.kSetVertexShaderVariant:
				case igCommandId.kSetStencilStateBundle:
				case igCommandId.kApplyConstantBundle:
					command.resource = GetGraphicsObject();
					break;

				case igCommandId.kSetCommonRenderState:
					command.value = BitConverter.ToInt32(bytes, offset - 4);
					break;

				case igCommandId.kSetStencilRef:
					command.value = BitConverter.ToInt32(bytes, offset - 4);
					offset += 4;
					break;

				case igCommandId.kSetPixelShaderTexture:
				case igCommandId.kSetPixelShaderSampler:
				case igCommandId.kSetPixelShaderTextureSizeConstant:
					command.resource = GetGraphicsObject();
					command.value = BitConverter.ToInt32(bytes, offset);
					offset += 4;
					offset += offset % 8;
					break;

				case igCommandId.kSetConstantBool:
					command.resource = GetGraphicsObject();
					command.value = BitConverter.ToInt32(bytes, offset) != 0;
					offset += 8;
					break;
				
				case igCommandId.kSetConstantVec4f:
					offset += offset % 16;
					command.resource = GetGraphicsObject();

					offset += offset % 16;
					command.valueOffset = offset;
					command.value = new Vector4(
						BitConverter.ToSingle(bytes, offset + 0),
                        BitConverter.ToSingle(bytes, offset + 4),
                        BitConverter.ToSingle(bytes, offset + 8),
                        BitConverter.ToSingle(bytes, offset + 12)
					);
					offset += 16;
					break;
				
				case igCommandId.kSetConstantMatrix44f:
					offset += offset % 16;
					command.resource = GetGraphicsObject();

					offset += offset % 16;
					float[] m = new float[16];
					for (int i = 0; i < 16; i++)
						m[i] = BitConverter.ToSingle(bytes, offset + i * 4);
					
					command.value = new Matrix4x4(
						m[0], m[1], m[2], m[3],
						m[4], m[5], m[6], m[7],
						m[8], m[9], m[10], m[11],
						m[12], m[13], m[14], m[15]
					);
					offset += 64;
					break;

				default:
					throw new NotImplementedException($"Error: {commandId}");
			};

			refOffset = offset;

			return command;
		}
    }
}