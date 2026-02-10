using Alchemy;
using ImGuiNET;

namespace NST
{
    public static class ComponentRenderer
    {
        private static NamedReference? _copyReference = null;
        private static LevelExplorer? _copyReferenceExplorer = null;

        private static readonly Dictionary<Type, Action<igComponentData, NSTComponent>> _renderMethods = new ()
        {
            { typeof(CModelComponentData), (c, m) =>                           RenderComponent((CModelComponentData)c, m) },
            { typeof(CStaticComponentData), (c, m) =>                          RenderComponent((CStaticComponentData)c, m) },
            { typeof(CStaticCollisionComponentData), (c, m) =>                 RenderComponent((CStaticCollisionComponentData)c, m) },
            { typeof(igPrefabComponentData), (c, m) =>                         RenderComponent((igPrefabComponentData)c, m) },
            { typeof(Multiple_Spawner_Template_c), (c, m) =>                   RenderComponent((Multiple_Spawner_Template_c)c, m) },
            { typeof(common_Spawner_TemplateData), (c, m) =>                   RenderComponent((common_Spawner_TemplateData)c, m) },
            { typeof(common_Crate_SlotMachine_SpawnedData), (c, m) =>          RenderComponent((common_Crate_SlotMachine_SpawnedData)c, m) },
            { typeof(common_Crate_SpawnIronWhenUsedData), (c, m) =>            RenderComponent((common_Crate_SpawnIronWhenUsedData)c, m) },
            { typeof(common_Crate_Switch_IronData), (c, m) =>                  RenderComponent((common_Crate_Switch_IronData)c, m) },
            { typeof(common_Crate_Switch_ReusableData), (c, m) =>              RenderComponent((common_Crate_Switch_ReusableData)c, m) },
            { typeof(common_Crate_Switch_Iron_Reusable_SpawnedData), (c, m) => RenderComponent((common_Crate_Switch_Iron_Reusable_SpawnedData)c, m) },
            { typeof(common_Crate_Switch_Nitro_SpawnedData), (c, m) =>         RenderComponent((common_Crate_Switch_Nitro_SpawnedData)c, m) },
            { typeof(common_Crate_OutlineData), (c, m) =>                      RenderComponent((common_Crate_OutlineData)c, m) },
            { typeof(common_Crate_LevelCountData), (c, m) =>                   RenderComponent((common_Crate_LevelCountData)c, m) },
            { typeof(common_Crate_TimeTrialData), (c, m) =>                    RenderComponent((common_Crate_TimeTrialData)c, m) },
            { typeof(common_Crate_TimeTrial_SpawnedData), (c, m) =>            RenderComponent((common_Crate_TimeTrial_SpawnedData)c, m) },
            { typeof(common_Crate_StackCheckerData), (c, m) =>                 RenderComponent((common_Crate_StackCheckerData)c, m) },
            { typeof(common_Crate_TNT_MessengerData), (c, m) =>                RenderComponent((common_Crate_TNT_MessengerData)c, m) },
            { typeof(common_Crate_TNTData), (c, m) =>                          RenderComponent((common_Crate_TNTData)c, m) },
            { typeof(common_Crate_IronBound_Spawned_OnHitSFXData), (c, m) =>   RenderComponent((common_Crate_IronBound_Spawned_OnHitSFXData)c, m) },
            { typeof(common_Crate_FloatingData), (c, m) =>                     RenderComponent((common_Crate_FloatingData)c, m) },
            { typeof(common_Crate_Flood_BehaviorData), (c, m) =>               RenderComponent((common_Crate_Flood_BehaviorData)c, m) },
            { typeof(Egypt_Hazard_FloodWater_BehaviorData), (c, m) =>          RenderComponent((Egypt_Hazard_FloodWater_BehaviorData)c, m) },
            { typeof(Egypt_Platform_FloodWater_BehaviorData), (c, m) =>        RenderComponent((Egypt_Platform_FloodWater_BehaviorData)c, m) },
            { typeof(common_Level_ManagerData), (c, m) =>                      RenderComponent((common_Level_ManagerData)c, m) },
            { typeof(DDA_CheckpointData), (c, m) =>                            RenderComponent((DDA_CheckpointData)c, m) },
            { typeof(CVisualDataBoxComponentData), (c, m) =>                   RenderComponent((CVisualDataBoxComponentData)c, m) },
            { typeof(Scripts_SpawnCollectiblesComponentData), (c, m) =>        RenderComponent((Scripts_SpawnCollectiblesComponentData)c, m) },
            { typeof(CVfxTextComponentData), (c, m) =>                         RenderComponent((CVfxTextComponentData)c, m) },
            { typeof(common_CameraDistanceFadeEntityData), (c, m) =>           RenderComponent((common_CameraDistanceFadeEntityData)c, m) },
            { typeof(CDynamicCheckpointComponentData), (c, m) =>               RenderComponent((CDynamicCheckpointComponentData)c, m) },
            { typeof(CPlayerTriggerRadiusComponentData), (c, m) =>             RenderComponent((CPlayerTriggerRadiusComponentData)c, m) },
            { typeof(CMovementControllerComponentData), (c, m) =>              RenderComponent((CMovementControllerComponentData)c, m) },
            { typeof(CSplineLaneMoverComponentData), (c, m) =>                 RenderComponent((CSplineLaneMoverComponentData)c, m) },
            { typeof(CTriggerVolumeBoxComponentData), (c, m) =>                RenderComponent((CTriggerVolumeBoxComponentData)c, m) },
            { typeof(common_ChangeCrashGameMode_TriggerData), (c, m) =>        RenderComponent((common_ChangeCrashGameMode_TriggerData)c, m) },
            { typeof(common_C3_IntroSequenceData), (c, m) =>                   RenderComponent((common_C3_IntroSequenceData)c, m) },
            { typeof(common_Collectible_TimeTrial_StartData), (c, m) =>        RenderComponent((common_Collectible_TimeTrial_StartData)c, m) },
            { typeof(common_BonusRoundTeleporterData), (c, m) =>               RenderComponent((common_BonusRoundTeleporterData)c, m) },
            { typeof(common_Generic_Path_Platform_SwapGameModeData), (c, m) => RenderComponent((common_Generic_Path_Platform_SwapGameModeData)c, m) },
            { typeof(common_Path_Platform_Mover), (c, m) =>                    RenderComponent((common_Path_Platform_Mover)c, m) },
            { typeof(common_Generic_Path_Teleporter_StartData), (c, m) =>      RenderComponent((common_Generic_Path_Teleporter_StartData)c, m) },
            { typeof(common_OnStartMusicData), (c, m) =>                       RenderComponent((common_OnStartMusicData)c, m) },
            { typeof(L201_TurtleWoods_MousePit_CameraTriggerData), (c, m) =>   RenderComponent((L201_TurtleWoods_MousePit_CameraTriggerData)c, m) },
            { typeof(CTintSphereComponentData), (c, m) =>                      RenderComponent((CTintSphereComponentData)c, m) },
            { typeof(CPointLightComponentData), (c, m) =>                      RenderComponent((CPointLightComponentData)c, m) },
            { typeof(CBoxLightComponentData), (c, m) =>                        RenderComponent((CBoxLightComponentData)c, m) },
        };

        private static readonly HashSet<Type> _emptyComponents = new ()
        {
            typeof(common_Crate_CheckpointData),
            typeof(common_Crate_Checkpoint_SpawnedData),
            typeof(common_Crate_Swap_To_Iron_On_DamageData),
            typeof(common_Crate_AkuAku_Illuminated_CheckData),
            typeof(global_VFX_OnStartData),
        };
        
        public static void RenderComponent(NSTComponent c)
        {
            // Spline
            if (c.Object is CSplineComponentData)
            {
                c.Entity.Spline?.Render(c.Explorer);
            }
            // Custom render method
            else if (_renderMethods.TryGetValue(c.Object.GetType(), out Action<igComponentData, NSTComponent>? renderMethod))
            {
                renderMethod(c.Object, c);
            }
            // Empty component
            else if (_emptyComponents.Contains(c.Object.GetType()))
            {
                ImGui.TextDisabled("(No properties)");
            }
            // Default render method
            else
            {
                var fields = c.Object.GetFields().ToList();

                int metaIndex = fields.FindIndex(f => f.GetName() == "_meta");
                if (metaIndex != -1)
                {
                    fields = fields.Take(2).Union(fields.Skip(metaIndex + 1)).ToList();
                }
                else
                {
                    int bitfieldIndex = fields.FindIndex(f => f.GetName() == "_bitfield");
                    if (bitfieldIndex != -1)
                    {
                        fields = fields.Take(2).Union(fields.Skip(bitfieldIndex + 1)).ToList();
                    }
                }

                if (fields.Count <= 2)
                {
                    ImGui.TextDisabled("(No properties)");
                    return;
                }

                foreach (CachedFieldAttr field in fields)
                {
                    Type fieldType = field.GetFieldType();

                    if (fieldType == typeof(igHandleMetaField))
                    {
                        igHandleMetaField? handle = (igHandleMetaField?)field.GetValue(c.Object);
                        if (handle?.Reference == null) continue;

                        NSTObject? objectRef = RenderObjectReference(field.GetName(), handle.Reference, typeof(igObject), c.Explorer, (value) =>
                        {
                            field.SetValue(c.Object, value);
                            c.SetUpdated(true);
                        },
                        skipIfNotFound: true);
                        if (objectRef != null) continue;

                        igObject? obj = c.Explorer.FileManager.FindObjectInOpenFiles(handle.Reference, out _);
                        if (obj == null) continue;

                        if (obj is igHandleList handleList)
                        {
                            if (handleList is CWaypointHandleList waypointList)
                            {
                                RenderCWaypointHandleList(field.GetName(), waypointList, c.Object, c);
                            }
                            else
                            {
                                RenderNullableCEntityHandleList(field.GetName(), handle, c.Object, c);
                            }
                        }
                        else if (obj is CWaypoint waypoint)
                        {
                            RenderWaypoint(waypoint.ObjectName, waypoint, c);
                        }
                    }
                }

                c.RenderAdvancedProperties(c.Object, fields);
            }
        }

#region Static objects

        private static void RenderComponent(CModelComponentData component, NSTComponent manager)
        {
            ImGui.Text("Model:");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-1);

            string displayName = string.IsNullOrEmpty(component._fileName) ? "(null)" : Path.GetFileNameWithoutExtension(component._fileName);

            ImGuiUtils.RenderComboWithSearch("##model" + manager.Entity.Object.ObjectName, displayName, LevelExplorer.CachedModelNames, true, firstOption: "(null)", callback: (index, name) =>
            {
                if (index < 0)
                {
                    component._fileName = "";
                    manager.SetUpdated();
                    manager.Entity.RefreshModel(manager.Explorer, null, false);
                    return;
                }

                NSTModel model = LevelExplorer.CachedModels[name.ToLowerInvariant()];

                component._fileName = model.OriginalPath;
                
                manager.SetUpdated();
                manager.Entity.RefreshModel(manager.Explorer, model);
            });
        }

        private static void RenderComponent(CStaticCollisionComponentData component, NSTComponent manager)
        {
            bool hasCollision = manager.Entity.CollisionShapeIndex != -1;
            bool enabled = hasCollision && !component._flagsBitfield._disableCollision;

            if (hasCollision && manager.Entity.IsPrefabChild)
            {
                ImGui.PushStyleColor(ImGuiCol.Text, 0xff00bbff);
                ImGui.TextWrapped("This entity is part of a prefab, copy the parent prefab to keep collisions.");
                ImGui.PopStyleColor();
                ImGui.Spacing();
            }

            if (!hasCollision) ImGui.BeginDisabled();

            if (RenderCheckbox("Collisions:", ref enabled))
            {
                component._flagsBitfield._disableCollision = !enabled;
                manager.SetUpdated();
            }

            if (!hasCollision) ImGui.EndDisabled();
        }

        private static void RenderComponent(CStaticComponentData component, NSTComponent manager)
        {
            RenderCheckbox("Hidden:", ref component._flagsBitfield._disableVisual, component, manager);
        }

        private static void RenderComponent(igPrefabComponentData component, NSTComponent manager)
        {
            if (component._prefabEntities == null || component._prefabEntities._data.Count == 0)
            {
                ImGui.Text("Empty prefab");
                return;
            }

            // if (manager.Entity.Children.Any(c => c is NSTEntity e && e.CollisionShapeIndex != -1))
            // {
            //     ImGui.PushStyleColor(ImGuiCol.Text, 0xff00bbff);
            //     ImGui.TextWrapped("(!) This prefab contains children with collisions, which isn't fully supported yet.");
            //     ImGui.TextWrapped("- You can move this prefab around and keep collisions.");
            //     ImGui.TextWrapped("- You can copy this prefab to a different level *once* and keep collisions.");
            //     ImGui.TextWrapped("- You *cannot* keep collisions if you copy this prefab to the same level.");
            //     ImGui.PopStyleColor();
            //     ImGui.Separator();
            //     ImGui.Spacing();
            // }

            ImGui.Text("Prefab children:");

            ImGui.TextDisabled("(?) Infos");
            if (ImGui.BeginItemTooltip())
            {
                ImGui.Text("Editing prefabs using the GUI is currently not supported.\n");
                ImGui.Text("You can use the 3D level editor to:");
                ImGui.BulletText("Remove a child from all prefab instances (select prefab => select child => press DEL)");
                ImGui.BulletText("Duplicate a child in all prefab instances (select prefab => select child => Ctrl+C / Ctrl+V)");
                ImGui.BulletText("Delete or duplicate a single prefab instance (select prefab => Ctrl+C / Ctrl+V / DEL)");
                ImGui.EndTooltip();
            }

            for (int i = 0; i < component._prefabEntities._data.Count; i++)
            {
                RenderObject($"{i}.", component._prefabEntities._data[i], manager.Entity.FileNamespace, typeof(igEntity), manager.Explorer, (value) => 
                {
                    if (value == null) component._prefabEntities._data.RemoveAt(i);
                    else component._prefabEntities._data[i] = (igEntity)value;
                    manager.SetUpdated(component._prefabEntities, true);
                }, readOnly: true);

                if (i >= component._prefabEntities._data.Count) break;

                // if (component._prefabEntities._data[i] == null)
                // {
                //     ImGui.SameLine();
                //     if (ImGui.Button("x"))
                //     {
                //         component._prefabEntities._data.RemoveAt(i);
                //         manager.SetUpdated(component._prefabEntities, true);
                //     }
                // }
            }

            // ImGui.Spacing();
            // if (ImGui.Button("Add new...", new System.Numerics.Vector2(-1, 0)))
            // {
            //     component._prefabEntities._data.Add(null!);
            //     manager.SetUpdated(component._prefabEntities);
            // }
        }

#endregion
#region Crates

        private static void RenderComponent(common_Crate_SpawnIronWhenUsedData component, NSTComponent manager)
        {
            RenderObjectReference("Entity:", component._Entity.Reference, typeof(CEntity), manager.Explorer, (value) => 
            {
                component._Entity.Reference = value;
                manager.SetUpdated(true);
            });
        }

        private static void RenderComponent(common_Crate_Switch_IronData component, NSTComponent manager)
        {
            RenderFloat("Initial delay:", ref component._Float, component, manager);
            RenderFloat("Change delay:", ref component._ChangeDelay, component, manager);
            RenderNullableCEntityHandleList("Outlined crates", component._OulinedCrates, component, manager);
        }

        private static void RenderComponent(common_Crate_Switch_ReusableData component, NSTComponent manager)
        {
            RenderFloat("Change delay:", ref component._ChangeDelay, component, manager);
            RenderHandle("Sound:", "common_bank", component._Sound, component, manager);
            RenderNullableCEntityHandleList("Entities", component._igEntity_List, component, manager);
            RenderNullableCEntityHandleList("Outlined crates", component._OulinedCrates, component, manager);
        }

        private static void RenderComponent(common_Crate_Switch_Iron_Reusable_SpawnedData component, NSTComponent manager)
        {
            RenderFloat("Delay:", ref component._Float, component, manager);
        }

        private static void RenderComponent(common_Crate_Switch_Nitro_SpawnedData component, NSTComponent manager)
        {
            RenderFloat("Delay:", ref component._ChangeDelay, component, manager);
            RenderHandle("Target tag:", "EntityTags", component._Entity_Tag, component, manager);
            RenderHandle("Sound:", "common_bank", component._Sound, component, manager);
        }

        private static void RenderComponent(common_Crate_LevelCountData component, NSTComponent manager)
        {
            RenderCheckbox("Add to crate total:", ref component._addToCrateTotal, component, manager);
            RenderCheckbox("Is bonus crate:", ref component._Bool, component, manager);
        }

        private static void RenderComponent(common_Crate_TimeTrialData component, NSTComponent manager)
        {
            RenderEnum("Time trial type:", ref component._NewEnum3_id_d9xdeh9x, component, manager);
        }

        private static void RenderComponent(common_Crate_TimeTrial_SpawnedData component, NSTComponent manager)
        {
            RenderFloat("Time reduction:", ref component._Float, component, manager);
        }

        private static void RenderComponent(common_Crate_StackCheckerData component, NSTComponent manager)
        {
            RenderCheckbox("Affected by gravity:", ref component._Bool_0x48, component, manager);
            RenderCheckbox("Spawn floating collision:", ref component._SpawnFloatingCollision, component, manager);
            RenderCheckbox("Water / SlotMachine:", ref component._Bool_0x68, component, manager);
        }

        private static void RenderComponent(common_Crate_TNT_MessengerData component, NSTComponent manager)
        {
            RenderFloat("Messenger delay:", ref component._Float, component, manager);
        }

        private static void RenderComponent(common_Crate_TNTData component, NSTComponent manager)
        {
            RenderFloat("Time before explosion:", ref component._Float, component, manager);
        }

        private static void RenderComponent(common_Crate_SlotMachine_SpawnedData component, NSTComponent manager)
        {
            var RenderSlot = (string name, igHandleMetaField handle, ref bool active) => 
            {
                if (ImGui.Checkbox("##" + name, ref active))
                {
                    manager.SetUpdated();
                }
                ImGui.SameLine();
                RenderObjectReference(name, handle.Reference, typeof(CEntity), manager.Explorer, (value) => 
                {
                    handle.Reference = value;
                    manager.SetUpdated(true);
                });
            };

            RenderFloat("Start speed:", ref component._Float_0x38, component, manager);

            RenderSlot("Slot 1", component._Entity_0x40, ref component._Bool_0x30);
            RenderSlot("Slot 2", component._Entity_0x48, ref component._Bool_0x31);
            RenderSlot("Slot 3", component._Entity_0x50, ref component._Bool_0x32);
            RenderSlot("Slot 4", component._Entity_0x58, ref component._Bool_0x33);
            RenderSlot("Slot 5", component._Entity_0x60, ref component._Bool_0x34);
            ImGui.Spacing();

            RenderObjectReference("Final slot:", component._Entity_0x68.Reference, typeof(CEntity), manager.Explorer, (value) => 
            {
                component._Entity_0x68.Reference = value;
                manager.SetUpdated(true);
            });
        }

        private static void RenderComponent(common_Crate_OutlineData component, NSTComponent manager)
        {
            RenderObjectReference("Replace with:", component._ReplacementEntity.Reference, typeof(CEntity), manager.Explorer, (value) =>
            {
                component._ReplacementEntity.Reference = value;
                manager.SetUpdated(true);
            });

            RenderObjectReference("2nd replacement:", component._UsedEntityToSpawn.Reference, typeof(CEntity), manager.Explorer, (value) => 
            {
                component._UsedEntityToSpawn.Reference = value;
                manager.SetUpdated(true);
            });
        }

        private static void RenderComponent(common_Crate_IronBound_Spawned_OnHitSFXData component, NSTComponent manager)
        {
            RenderHandle("Metal sound:", "common_bank", component._Sound_0x28, component, manager);
            RenderHandle("Bounce sound:", "common_bank", component._Sound_0x30, component, manager);
            RenderHandle("Impact sound:", "common_bank", component._Sound_0x38, component, manager);
        }

        private static void RenderComponent(common_Crate_FloatingData component, NSTComponent manager)
        {
            RenderCheckbox("Is TNT:", ref component._Bool_0x28, component, manager);
            RenderCheckbox("Is Nitro:", ref component._Bool_0x29, component, manager);
        }

        private static void RenderComponent(common_Crate_Flood_BehaviorData component, NSTComponent manager)
        {
            RenderFloat("Flood height:", ref component._Float, component, manager, 10.0f, 100.0f);
        }

        private static void RenderComponent(Egypt_Hazard_FloodWater_BehaviorData component, NSTComponent manager)
        {
            RenderFloat("Flood height:", ref component._Float, component, manager, 10.0f, 100.0f);
            RenderString("Crash death:", ref component._CrashDeath, component, manager);
            RenderHandle("Lower sound:", "hazard_floodwater_bank", component._Sound_0x40, component, manager);
            RenderHandle("Rise sound: ", "hazard_floodwater_bank", component._Sound_0x38, component, manager);
            RenderObjectReference("Water sound object 1:", component._Entity_0x48, typeof(CGameEntity), manager);
            RenderObjectReference("Water sound object 2:", component._Entity_0x50, typeof(CGameEntity), manager);
            RenderObjectReference("Water sound object 3:", component._Entity_0x58, typeof(CGameEntity), manager);
            RenderCheckbox("Bool:", ref component._Bool, component, manager);
        }

        private static void RenderComponent(Egypt_Platform_FloodWater_BehaviorData component, NSTComponent manager)
        {
            RenderFloat("Flood height:", ref component._Float, component, manager, 10.0f, 100.0f);
        }

        private static void RenderComponent(Scripts_SpawnCollectiblesComponentData component, NSTComponent manager)
        {
            var method = (Scripts_SpawnCollectiblesComponentData_RandomRangedSelectionMethod?)component.SeletionMethod;

            if (ImGui.TreeNodeEx("Properties..."))
            {
                RenderFloat("Chance to spawn:", ref component.ChanceToSpawn, component, manager);
                RenderFloat("Delay:", ref component.Delay, component, manager);
                RenderFloat("Horizontal angular spread:", ref component.HorizontalAngularSpread, component, manager);
                RenderFloat("Horizontal angle:", ref component.HorizontalAngle, component, manager);
                RenderCheckbox("Face player:", ref component.RotateTowardsPlayer, component, manager);
                RenderCheckbox("Face camera:", ref component.FaceCamera, component, manager);
                
                if (method?.NumCollectiblesToSpawn != null)
                    RenderFloat("Num collectibles:", ref method.NumCollectiblesToSpawn._storage._max, method.NumCollectiblesToSpawn, manager, 1, 10);

                if (component.MaxCollectiblesToSpawn != null)
                    RenderFloat("Max collectibles:", ref component.MaxCollectiblesToSpawn._storage._max, component.MaxCollectiblesToSpawn, manager, 1, 10);

                RenderInt("Num collectibles in wave:", ref component.NumCollectiblesInWave, component, manager);

                if (component.SpawnOffset != null)
                    RenderFloat3("Spawn offset:", ref component.SpawnOffset._storage, component.SpawnOffset, manager);

                if (component.HorizontalVelocity != null)
                    RenderFloat("Horizontal velocity:", ref component.HorizontalVelocity._storage._max, component.HorizontalVelocity, manager);

                if (component.VerticalVelocity != null)
                    RenderFloat("Vertical velocity:", ref component.VerticalVelocity._storage._max, component.VerticalVelocity, manager);

                if (component.WorldDirectionalVelocity != null)
                    RenderFloat3("World directional velocity:", ref component.WorldDirectionalVelocity._storage, component.WorldDirectionalVelocity, manager);

                RenderCheckbox("Force collect:", ref component.ForceCollect, component, manager);

                if (component.ForceCollectDelay != null)
                    RenderFloat("Force collect delay:", ref component.ForceCollectDelay._storage._max, component.ForceCollectDelay, manager);

                RenderCheckbox("Spawn on message:", ref component.SpawnOnMessage, component, manager);
                RenderCheckbox("Spawn on start only once:", ref component.SpawnOnStartOnlyOnce, component, manager);
                RenderCheckbox("Remove entity when finished:", ref component.RemoveEntityWhenFinished, component, manager);

                ImGui.TreePop();
            }

            ImGui.Spacing();

            if (ImGui.TreeNodeEx("Collectibles...", ImGuiTreeNodeFlags.DefaultOpen))
            {
                if (method?.Collectibles == null)
                {
                    ImGui.TextDisabled("(Empty)");
                    return;
                }

                for (int i = 0; i < method.Collectibles._data.Count; i++)
                {
                    igEntity entity = method.Collectibles._data[i];
                    RenderObject($"{i}.", entity, manager.Entity.FileNamespace, typeof(CEntity), manager.Explorer, (value) =>
                    {
                        if (value == null)
                        {
                            method.Collectibles._data.RemoveAt(i);
                        }
                        else
                        {
                            method.Collectibles._data[i] = (igEntity)value;
                        }

                        manager.SetUpdated(method.Collectibles, true);
                    });

                    if (entity == null)
                    {
                        ImGui.SameLine();
                        if (ImGui.Button($"x##{i}"))
                        {
                            method.Collectibles._data.RemoveAt(i);
                            manager.SetUpdated(method.Collectibles);
                            break;
                        }
                    }
                }

                ImGui.Spacing();
                if (ImGui.Button("Add new...", new System.Numerics.Vector2(-1, 0)))
                {
                    method.Collectibles._data.Add(null!);
                    manager.SetUpdated(method.Collectibles);
                }

                ImGui.TreePop();
            }
        }

        private static void RenderComponent(CVfxTextComponentData component, NSTComponent manager)
        {
            RenderString("Display Text:", ref component._displayText, component, manager);
            RenderCheckbox("Enabled At Start:", ref component._enabledAtStart, component, manager);
            RenderCheckbox("Face Camera:", ref component._faceCamera, component, manager);
            RenderEnum("Text Alignment:", ref component._textAlignment, component, manager);
            RenderFloat("Seconds per character:", ref component._secondsPerCharacter, component, manager);
            RenderFloat("Max Width:", ref component._maxWidth, component, manager, 1, 10);
            RenderFloat("Curve Radius:", ref component._curveRadius, component, manager, 1, 10);

            if (component._endBolt.Reference != null)
            {
                IgzFile? igz = manager.Explorer.FileManager.GetIgz(manager.Entity.ArchiveFile);
                if (igz?.FindObject(component._endBolt.Reference) is CBoltPoint boltPoint)
                {
                    RenderFloat3("Text Offset:", ref boltPoint._offset, component, manager);
                }
            }
        }

#endregion
#region Levels

        private static void RenderComponent(L201_TurtleWoods_MousePit_CameraTriggerData component, NSTComponent manager)
        {
            RenderObjectReference("Enable camera:", component._Camera_Base_0x28, typeof(CCameraBase), manager);
            RenderObjectReference("Disable camera:", component._Camera_Base_0x38, typeof(CCameraBase), manager);
            RenderFloat("Transition speed in:", ref component._Float_0x30, component, manager);
            RenderFloat("Transition speed out:", ref component._Float_0x40, component, manager);
        }

#endregion
#region Other

        private static HashSet<igHandleMetaField> _nullOverrides = [];
        
        private static void RenderComponent(common_Spawner_TemplateData component, NSTComponent manager)
        {
            if (component._TriggerVolume.Reference != null || _nullOverrides.Contains(component._TriggerVolume))
            {
                _nullOverrides.Add(component._TriggerVolume);
                RenderObjectReference("Trigger Volume:", component._TriggerVolume, typeof(CEntity), manager);
            }

            if (component._SpawnAtEntity.Reference != null || _nullOverrides.Contains(component._SpawnAtEntity))
            {
                _nullOverrides.Add(component._SpawnAtEntity);
                RenderObjectReference("Spawn At Entity:", component._SpawnAtEntity, typeof(CEntity), manager);
            }

            RenderObjectReference("Template:", component._EntityToSpawn, typeof(CGameEntity), manager, defaultOpen: true);
        }

        private static void RenderComponent(Multiple_Spawner_Template_c component, NSTComponent manager)
        {
            RenderFloat("Delay between entities:", ref component._DelayBetweenEntities, component, manager);
            RenderFloat("Delay between sets:", ref component._DelayBetweenSets, component, manager);

            RenderCheckbox("Spawn multiple waves:", ref component._SpawnMultipleWaves, component, manager);
            RenderCheckbox("Spawn at spawner:", ref component._SpawnAtSpawner, component, manager);
            RenderCheckbox("Use trigger volume:", ref component._UseTriggerVolume, component, manager);

            RenderNullableCEntityHandleList("Spawned entities", component._Spawn_Entity_List, component, manager);

            manager.RenderAdvancedProperties(component, component.GetFields());
        }

        private static void RenderComponent(common_Level_ManagerData component, NSTComponent manager)
        {
            RenderObjectReference("Spawn Entity:", component._spawnEntity?.Reference, typeof(CEntity), manager.Explorer, (value) =>
            {
                if (component._spawnEntity == null) component._spawnEntity = new();
                component._spawnEntity.Reference = value;
                manager.SetUpdated(true);
            });

            ImGui.SeparatorText("Dark level");
            RenderCheckbox("Is Aku Aku Illuminated:", ref component._IsAkuAkuIlluminated, component, manager);
            RenderObjectReference("Visual Entity:", component._Entity_0x48?.Reference, typeof(CEntity), manager.Explorer, (value) =>
            {
                if (component._Entity_0x48 == null) component._Entity_0x48 = new();
                component._Entity_0x48.Reference = value;
                manager.SetUpdated(true);
            });

            ImGui.SeparatorText("Level properties");
            RenderEnum("C1 gem type: ", ref component._E_Zone_Collectible_Type, component, manager);
            RenderEnum("Shadow type: ", ref component._NewEnum9_id_5y039ngg, component, manager);
            RenderEnum("Raycast type:", ref component._NewEnum9_id_i7ih7bke, component, manager);

            ImGui.SeparatorText("Unknown");
            RenderCheckbox("Bool_0x40:", ref component._Bool_0x40, component, manager);
            ImGui.SetItemTooltip("False in:\n- L112_RoadToNowhere\n- L120_TheHighRoad");
            RenderCheckbox("Bool_0x50:", ref component._Bool_0x50, component, manager);
            ImGui.SetItemTooltip("True in:\n- L127_TheGreatHall\n- L200_Intro");
            RenderCheckbox("Disable Aku Aku:", ref component._Bool_0x60, component, manager);
            RenderCheckbox("Bool_0xa8:", ref component._Bool_0xa8, component, manager);
            ImGui.SetItemTooltip("False in:\n- L222_RockIt\n- L224_PackAttack");
        }

        private static void RenderComponent(DDA_CheckpointData component, NSTComponent manager)
        {
            RenderEnum("Type:", ref component._NewEnum12_id_kxje8bmu, component, manager);

            RenderObjectReference("DDA Entity:", component._Entity_0x50?.Reference, typeof(CEntity), manager.Explorer, (value) =>
            {
                if (component._Entity_0x50 == null) component._Entity_0x50 = new();
                component._Entity_0x50.Reference = value;
                manager.SetUpdated(true);
            });

            RenderObjectReference("Checkpoint template:", component._Entity_0x40?.Reference, typeof(CEntity), manager.Explorer, (value) =>
            {
                if (component._Entity_0x40 == null) component._Entity_0x40 = new();
                component._Entity_0x40.Reference = value;
                manager.SetUpdated(true);
            });

            RenderObjectReference("AkuAku template:", component._Entity_0x48?.Reference, typeof(CEntity), manager.Explorer, (value) =>
            {
                if (component._Entity_0x48 == null) component._Entity_0x48 = new();
                component._Entity_0x48.Reference = value;
                manager.SetUpdated(true);
            });
        }

        private static void RenderComponent(CVisualDataBoxComponentData component, NSTComponent manager)
        {
            IgzRenderer renderer = manager.Explorer.FileManager.GetOrCreateRenderer(manager.Entity.ArchiveFile, manager.Explorer.ArchiveRenderer);

            RenderFloat3("Dimensions:", ref component._dimensions, component, manager);
            
            ImGui.Spacing();
            if (ImGui.TreeNodeEx("Box Settings...", ImGuiTreeNodeFlags.NoTreePushOnOpen))
            {
                renderer.RenderObject(component, component.GetFields().Skip(2).ToList());
            }

            ImGui.Spacing();
            if (component._data != null && ImGui.TreeNodeEx("Visual properties...", ImGuiTreeNodeFlags.NoTreePushOnOpen))
            {
                renderer.RenderObject(component._data, component._data.GetFields());
            }
        }

        private static void RenderComponent(common_CameraDistanceFadeEntityData component, NSTComponent manager)
        {
            RenderEnum("Fade preset:", ref component._NewEnum9_id_i9rbjcfh, component, manager);
        }

        private static void RenderComponent(CPlayerTriggerRadiusComponentData component, NSTComponent manager)
        {
            RenderFloat("Radius:", ref component._radius, component, manager);
        }

        private static void RenderComponent(CDynamicCheckpointComponentData component, NSTComponent manager)
        {
            RenderCheckbox("Start enabled:", ref component._startEnabled, component, manager);

            RenderObjectReference("Camera:", component._camera?.Reference, typeof(CCameraBase), manager.Explorer, (value) =>
            {
                if (component._camera == null) component._camera = new CCameraBase();
                component._camera.Reference = value;
                manager.SetUpdated(true);
            });

            RenderFloat3("Offset:", ref component._dynamicCheckpointOffset, component, manager);
        }

        private static void RenderComponent(CMovementControllerComponentData component, NSTComponent manager)
        {
            RenderFloat("Max velocity:", ref component._maxVelocity, component, manager);

            if (component._controllerList?._data.Count > 0)
            {
                foreach (CBaseMovementController controller in component._controllerList._data)
                {
                    manager.RenderAdvancedProperties(controller, controller.GetFields(), controller.GetType().Name + "...");
                }
            }
            else
            {
                ImGui.TextDisabled("(No controllers)");
            }
        }

        private static void RenderComponent(CSplineLaneMoverComponentData component, NSTComponent manager)
        {
            NSTObject? splineObject = RenderObjectReference("Spline entity:", component._splineEntity.Reference, typeof(CEntity), manager.Explorer, (value) =>
            {
                if (component._splineEntity == null) component._splineEntity = new();
                component._splineEntity.Reference = value;
                manager.SetUpdated(true);
            });

            if (splineObject is NSTEntity splineEntity && splineEntity.Spline != null
                && splineEntity.Object.TryGetComponent(out CSplineComponentData? splineComponent))
            {
                var names = splineEntity.Spline._markers.Select(m => m.Object.ObjectName).ToArray();
                var displayNames = splineEntity.Spline._markers.Select((m, i) => "Spline marker " + (i+1)).ToArray(); 

                if (component._splineStart.Reference != null)
                {
                    int index = splineEntity.Spline._markers.FindIndex(m => m.Object.ObjectName == component._splineStart.Reference.objectName);

                    ImGui.Text("Spline start:");
                    ImGui.SameLine();
                    ImGui.SetNextItemWidth(-1);
                    if (ImGui.Combo("##SplineStart", ref index, displayNames, displayNames.Length))
                    {
                        component._splineStart.Reference.objectName = names[index]!;
                        manager.SetUpdated(true);
                    }
                }
                if (component._splineEnd.Reference != null)
                {
                    int index = splineEntity.Spline._markers.FindIndex(m => m.Object.ObjectName == component._splineEnd.Reference.objectName);

                    ImGui.Text("Spline end:");
                    ImGui.SameLine();
                    ImGui.SetNextItemWidth(-1);
                    if (ImGui.Combo("##SplineEnd", ref index, displayNames, displayNames.Length))
                    {
                        component._splineEnd.Reference.objectName = names[index]!;
                        manager.SetUpdated(true);
                    }
                }
            }

            var fields = component.GetFields().ToList();
            fields.RemoveRange(2, 4);

            manager.RenderAdvancedProperties(component, fields);
        }

        private static void RenderComponent(CTriggerVolumeBoxComponentData component, NSTComponent manager)
        {
            bool updated = RenderFloat3("Offset:    ", ref component._offset, component, manager, true);
            updated |=     RenderFloat3("Rotation:  ", ref component._rotation, component, manager, true, 0.1f);
            updated |=     RenderFloat3("Dimensions:", ref component._dimensions, component, manager, true);

            manager.RenderAdvancedProperties(component, component.GetFields().Skip(3).Take(8).ToList());

            if (manager.Entity.TriggerVolumeBox == null) return;

            var triggerExists = manager.Entity.Object3D?.Children.Contains(manager.Entity.TriggerVolumeBox);

            if (triggerExists == false && manager.Entity.Object3D != null)
            {
                manager.Entity.TriggerVolumeBox.Traverse(e => e.Layers.Set((int)LevelExplorer.CameraLayer.TriggersOn));
                manager.Entity.Object3D.Add(manager.Entity.TriggerVolumeBox);
                manager.Explorer.RenderNextFrame = true;
            }
            
            if (updated)
            {
                THREE.Vector3 position = component._offset.ToVector3();
                THREE.Euler rotation = component._rotation.Mul(THREE.MathUtils.DEG2RAD).ToEuler();
                THREE.Vector3 scale = component._dimensions.ToVector3();

                THREE.Vector3 parentScale = new THREE.Vector3();
                manager.Entity.ObjectToWorld().Decompose(new THREE.Vector3(), new THREE.Quaternion(), parentScale);

                manager.Entity.TriggerVolumeBox.Position.Copy(position / parentScale);
                manager.Entity.TriggerVolumeBox.Rotation.Copy(rotation);
                manager.Entity.TriggerVolumeBox.Scale.Copy(scale / parentScale);
                manager.Explorer.RenderNextFrame = true;
            }
        }

        private static void RenderComponent(common_ChangeCrashGameMode_TriggerData component, NSTComponent manager)
        {
            RenderEnum("Switch From:", ref component._E_World_Gameplay_Mode_0x2c, component, manager);
            RenderEnum("Switch To:  ", ref component._E_World_Gameplay_Mode_0x30, component, manager);
            RenderCheckbox("Bool:", ref component._Bool, component, manager);
        }

        private static void RenderComponent(common_C3_IntroSequenceData component, NSTComponent manager)
        {
            RenderFloat("Animation delay:", ref component._Float_0x30, component, manager);
            RenderFloat("Animation duration:", ref component._Float_0x40, component, manager);
            RenderFloat("Animation offset", ref component._Float_0x48, component, manager);
            RenderFloat("Animation size", ref component._Float_0x78, component, manager);
            ImGui.Separator();
            RenderFloat("Crash spawn delay:", ref component._Float_0x34, component, manager);
            RenderFloat("Spawn offset", ref component._Float_0x4c, component, manager);
            manager.RenderAdvancedProperties(component, component.GetFields());
        }

        private static void RenderComponent(common_Collectible_TimeTrial_StartData component, NSTComponent manager)
        {
            RenderCheckbox("Always spawn:", ref component._Bool, component, manager);
        }

        private static void RenderComponent(common_BonusRoundTeleporterData component, NSTComponent manager)
        {
            if (RenderEnum("Type:", ref component._NewEnum2_id_9tewcwq5, component, manager))
            {
                string type;
                switch (component._NewEnum2_id_9tewcwq5)
                {
                    case common_BonusRoundTeleporterData.ENewEnum2_id_9tewcwq5.Tawna:
                        type = "Tawna";
                        break;
                    case common_BonusRoundTeleporterData.ENewEnum2_id_9tewcwq5.Brio:
                        type = "Brio";
                        break;
                    case common_BonusRoundTeleporterData.ENewEnum2_id_9tewcwq5.Cortex:
                        type = "Cortex";
                        break;
                    default:
                        return;
                }

                string vfx = "CR1_BonusRound_Counter_" + type;
                component._Vfx_Effect_0x48.Reference ??= new NamedReference();
                component._Vfx_Effect_0x48.Reference.objectName = vfx;
                component._Vfx_Effect_0x48.Reference.namespaceName = vfx;
                
                if (manager.Entity.Object._entityData is CGameEntityData entityData && entityData._tags != null)
                {
                    entityData._tags.Clear();
                    entityData._tags.Add(new igObject() { Reference = new NamedReference("EntityTags", "Teleporter_" + type)}, true);
                    manager.SetUpdated(entityData._tags);
                }
            }

            RenderObjectReference("Checkpoint:", component._Entity.Reference, typeof(CEntity), manager.Explorer, (value) =>
            {
                component._Entity.Reference = value;
                manager.SetUpdated(true);
            });
        }

        private static void RenderComponent(common_Generic_Path_Platform_SwapGameModeData component, NSTComponent manager)
        {
            RenderEnum("Action:", ref component._NewEnum16_id_9et3dr1r, component, manager);
            RenderEnum("Game Mode:", ref component._E_World_Gameplay_Mode, component, manager);
        }

        private static void RenderComponent(common_Path_Platform_Mover component, NSTComponent manager)
        {
            RenderObjectReference("Spline Camera 1:", component._common_Gem_Platform_SplineDatas002, typeof(CSplineCamera), manager);
            RenderObjectReference("Spline Camera 2:", component._common_Gem_Platform_SplineDatas001, typeof(CSplineCamera), manager);
            RenderFloat("Initial Delay: ", ref component._common_Gem_Platform_SplineDatas007, component, manager);

            if (component._common_Gem_Platform_SplineDatas006.Reference != null)
            {
                IgzFile? igz = manager.Explorer.FileManager.GetIgz(manager.Entity.ArchiveFile);
                if (igz != null)
                {
                    if (igz.FindObject(component._common_Gem_Platform_SplineDatas006.Reference) is CSplineVelocityMover mover)
                    {
                        if (mover is CSplineConstantVelocityMover constantMover)
                        {
                            RenderFloat("Velocity:", ref constantMover._velocity, constantMover, manager);
                        }
                        else if (mover is CSplineTimeBasedMover timeMover)
                        {
                            RenderFloat("Time:", ref timeMover._time, timeMover, manager);
                            RenderFloat("Ease-in time:", ref timeMover._easeInTime, timeMover, manager);
                            RenderFloat("Ease-in velocity:", ref timeMover._easeInVelocityScale, timeMover, manager);
                            RenderFloat("Ease-out time:", ref timeMover._easeOutTime, timeMover, manager);
                            RenderFloat("Ease-out velocity:", ref timeMover._easeOutVelocityScale, timeMover, manager);
                        }
                    }
                    else ImGui.TextDisabled("Could not find the referenced object.");
                }
                else ImGui.TextDisabled("An error occured.");
            }

            RenderCheckbox("Lock Player:", ref component._Bool_0x58, component, manager);
            RenderCheckbox("Is Entrance:", ref component._Bool_0x5a, component, manager);
            RenderCheckbox("Is Arrival:", ref component._Bool_0x59, component, manager);
            
            RenderObjectReference("Proxy Camera:", component._CameraProxy, typeof(CEntity), manager);
            RenderObjectReference("Proxy Spline:", component._Spline, typeof(CEntity), manager);
            RenderEnum("Type:", ref component._NewEnum4_id_6yu8wy7t, component, manager);

            RenderCheckbox("Bool_0x74", ref component._Bool_0x74, component, manager);
            RenderFloat("Float_0x78", ref component._Float_0x78, component, manager);
            RenderFloat("Float_0x7c", ref component._Float_0x7c, component, manager);

            RenderCheckbox("Bool_0x98", ref component._Bool_0x98, component, manager);

            RenderCheckbox("Bool_0xb8", ref component._Bool_0xb8, component, manager);
            RenderCheckbox("Bool_0xb9", ref component._Bool_0xb9, component, manager);

            RenderCheckbox("Bool_0xd0", ref component._Bool_0xd0, component, manager);
            RenderCheckbox("Bool_0xd1", ref component._Bool_0xd1, component, manager);
            RenderCheckbox("Bool_0xd2", ref component._Bool_0xd2, component, manager);

            RenderObjectReference("Entity:", component._Entity, typeof(CEntity), manager);
            // RenderObjectReference("Component Data:", component._Component_Data, typeof(igEntity), manager);

            RenderCheckbox("Bool_0xf0", ref component._Bool_0xf0, component, manager);
            RenderFloat("Float_0xf4", ref component._Float_0xf4, component, manager);
        }

        private static void RenderComponent(common_Generic_Path_Teleporter_StartData component, NSTComponent manager)
        {
            if (component._Waypoint.Reference != null && manager.Explorer.FileManager.FindObjectInOpenFiles(component._Waypoint.Reference, out _) is CWaypoint wp)
            {
                RenderWaypoint("Teleport to waypoint", wp, manager);
            }
            RenderObjectReference("Teleport to:", component._Entity, typeof(CEntity), manager);
            RenderObjectReference("Target camera:", component._common_Gem_Platform_SplineDatas001, typeof(CCamera), manager);
            RenderObjectReference("Target spline:", component._Spline, typeof(CEntity), manager);
            RenderObjectReference("Camera proxy:", component._CameraProxy, typeof(CEntity), manager);
            RenderEnum("Gameplay switch:", ref component._NewEnum16_id_noksmwgb, component, manager);
            RenderEnum("Gameplay mode:", ref component._E_World_Gameplay_Mode, component, manager);
            RenderCheckbox("Warp animation:", ref component._Bool, component, manager);
        }

        private static int _audioPlayerStatus = 0;
        private static igComponentData? _musicComponent;
        private static IgArchiveFile? _soundBankFile;
        private static IgArchiveFile? _soundFile;
        private static IgzFile? _soundBankIgz;
        private static CSubSound? _subSound;
        private static void InitAudioPlayer(LevelExplorer explorer)
        {
            string soundFileName = Path.GetFileNameWithoutExtension(_subSound!._fileName!);

            _soundFile = explorer.Archive.FindFile(soundFileName, FileSearchType.NameStartsWith);

            if (_soundFile != null)
            {
                AudioPlayerInstance.InitAudioPlayer(_soundFile.Uncompress());
                _audioPlayerStatus = 1;
            }
            else
            {
                _audioPlayerStatus = -1;
            }
        }
        private static void RenderComponent(common_OnStartMusicData component, NSTComponent manager)
        {
            if (_musicComponent == null || _musicComponent != component)
            {
                _subSound = null;
                _audioPlayerStatus = 0;
                _musicComponent = component;

                Task.Run(() => 
                {
                    IgzFile igz = manager.Explorer.FileManager.GetIgz(manager.Entity.ArchiveFile)!;

                    var musicSettings = (CGameSoundMusicSettings)igz.FindObject(component._OnStartMusic.Reference!)!;

                    _soundBankFile = manager.Explorer.Archive.FindFile(musicSettings._nextStream.Reference!.namespaceName, FileSearchType.Name)!;
                    _soundBankIgz = manager.Explorer.FileManager.GetIgz(_soundBankFile) ?? _soundBankFile.ToIgzFile();

                    var sound = (CSound)_soundBankIgz.FindObject(musicSettings._nextStream.Reference)!;

                    _subSound = sound._subSoundList!._data[0];

                    InitAudioPlayer(manager.Explorer);
                })
                .ContinueWith(_ => _audioPlayerStatus = -1, TaskContinuationOptions.OnlyOnFaulted);
            }

            if (_subSound != null && _soundBankFile != null && _soundBankIgz != null)
            {
                if (RenderString("Sound file:", ref _subSound._fileName!))
                {
                    manager.Explorer.FileManager.Add(_soundBankFile, _soundBankIgz);
                    manager.Explorer.ArchiveRenderer.SetObjectUpdated(_soundBankFile, _subSound);
                }
                if (ImGui.Button("Locate"))
                {
                    string soundFileName = Path.GetFileNameWithoutExtension(_subSound._fileName!);
                    IgArchiveFile? soundFile = manager.Explorer.Archive.FindFile(soundFileName, FileSearchType.NameStartsWith);
                    if (soundFile != null)
                    {
                        App.OpenArchiveRenderer(manager.Explorer.ArchiveRenderer);
                        manager.Explorer.ArchiveRenderer.FocusFile(soundFile);
                    }
                }
                ImGui.SameLine();
                if (ImGui.Button("Reload"))
                {
                    _audioPlayerStatus = 0;

                    Task.Run(() => InitAudioPlayer(manager.Explorer))
                        .ContinueWith(_ => _audioPlayerStatus = -1, TaskContinuationOptions.OnlyOnFaulted);
                }
            }

            ImGui.Spacing();

            if (_audioPlayerStatus == 0)
            {
                ImGui.Spacing();
                ImGui.Text("Loading audio player...");
            }
            else if (_audioPlayerStatus == 1 && _soundFile != null)
            {
                AudioPlayerInstance.Render(newAudioData =>
                {
                    _soundFile.SetData(newAudioData);
                    manager.Explorer.ArchiveRenderer.SetFileUpdated(_soundFile);
                    AudioPlayerInstance.InitAudioPlayer(_soundFile.Uncompress());
                });
            }
            else
            {
                ImGui.Spacing();
                ImGui.Text("Could not load audio file.");
            }
        }

#endregion
#region Lighintg / VFX / SFX

        private static void RenderComponent(CTintSphereComponentData component, NSTComponent manager)
        {
            RenderColor("Color:       ", ref component._color, component, manager);
            RenderFloat("Radius:      ", ref component._radius, component, manager);
            RenderFloat("Intensity:   ", ref component._intensity, component, manager);
            RenderFloat("Additiveness:", ref component._additiveness, component, manager);
            ImGui.Spacing(); ImGui.Separator(); ImGui.Spacing();
            RenderCheckbox("Ignore occlusion boxes: ", ref component._ignoreOcclusionBoxes, component, manager);
            RenderCheckbox("Depth blending enabled: ", ref component._depthBlendingEnabled, component, manager);
            RenderFloat("Depth blending softness:", ref component._depthBlendingSoftness, component, manager);
        }

        private static void RenderComponent(CPointLightComponentData component, NSTComponent manager)
        {
            RenderColor("Color:    ", ref component._color, component, manager);
            RenderFloat("Radius:   ", ref component._radius, component, manager);
            RenderFloat("Intensity:", ref component._intensity, component, manager);
            ImGui.Spacing(); ImGui.Separator(); ImGui.Spacing();
            RenderEnum("Light bake type:", ref component._lightBakeType, component, manager);
            RenderCheckbox("Distance cull:  ", ref component._distanceCull, component, manager);
        }

        private static void RenderComponent(CBoxLightComponentData component, NSTComponent manager)
        {
            RenderColor( "Color:     ", ref component._color, component, manager);
            RenderFloat( "Intensity: ", ref component._intensity, component, manager);
            RenderFloat3("Dimensions:", ref component._dimensions, component, manager);
            ImGui.Spacing(); ImGui.Separator(); ImGui.Spacing();
            RenderFloat("Near attenuation:", ref component._nearAttenuation, component, manager);
            RenderFloat("Attenuation:     ", ref component._attenuation, component, manager);
            RenderFloat("X Falloff:       ", ref component._xFalloff, component, manager);
            RenderFloat("Y Falloff:       ", ref component._yFalloff, component, manager);
            RenderFloat("Wrap:            ", ref component._wrap, component, manager);
            RenderString("Cookie Texture:  ", ref component._cookieTextureName, component, manager);
            RenderEnum("Light bake type: ", ref component._lightBakeType, component, manager);
            RenderCheckbox("Distance cull:   ", ref component._distanceCull, component, manager);
        }

#endregion
#region References

        public static void RenderNullableCEntityHandleList(string label, igHandleMetaField listHandle, igObject parent, NSTComponent manager)
        {
            if (listHandle.Reference == null)
            {
                if (RenderCEntityHandleList(label, new CEntityHandleList(), manager))
                {
                    IgzFile igz = manager.Explorer.FileManager.GetIgz(manager.Entity.ArchiveFile)!;

                    CEntityHandleList list = igz.AddClone(new CEntityHandleList() { ObjectName = "entityHandleList" });
                    list.MemoryPool = parent.MemoryPool;
                    list._data.MemoryPool = parent.MemoryPool;
                    list._data.Add(new igHandleMetaField());
                    list._data.SetMemoryAlignment(parent.MemoryPool.alignment);

                    listHandle.Reference = list.ToNamedReference(manager.Entity.FileNamespace);
                    manager.SetUpdated(parent, true);
                }
            }
            else
            {
                RenderCEntityHandleList(label, listHandle, manager);
            }
        }
        
        private static void RenderCEntityHandleList(string label, igHandleMetaField listHandle, NSTComponent manager)
        {
            if (listHandle.Reference == null)
            {
                ImGui.Text($"{label}: (null)");
                return;
            }

            if (manager.Explorer.FileManager.FindObjectInOpenFiles(listHandle.Reference, out IgArchiveFile? file) is not igHandleList handleList || file == null)
            {
                Console.WriteLine($"Warning: Could not find CEntityHandleList from reference {listHandle.Reference}");
                return;
            }

            RenderCEntityHandleList(label, handleList, manager, file);
        }

        private static bool RenderCEntityHandleList(string label, igHandleList handleList, NSTComponent manager, IgArchiveFile? file = null)
        {
            ImGui.Text(label + ":");

            if (handleList._data.Count > 0)
            {
                ImGui.Spacing();

                for (int i = 0; i < handleList._data.Count; i++)
                {
                    igHandleMetaField handle = handleList._data[i];

                    RenderObjectReference($"{i}.", handle.Reference, typeof(CEntity), manager.Explorer, (value) => 
                    {
                        handle.Reference = value;
                        manager.SetUpdated(handleList, true, file);
                    });

                    if (handle.Reference == null)
                    {
                        ImGui.SameLine();
                        if (ImGui.Button($"x##{i}"))
                        {
                            handleList._data.RemoveAt(i);
                            manager.SetUpdated(handleList, false, file);
                            return false;
                        }
                    }
                }
                
                ImGui.Spacing();
            }
            else
            {
                ImGui.SameLine();
            }

            if (ImGui.Button("Add new...##" + label, new System.Numerics.Vector2(-1, 0)))
            {
                handleList._data.Add(new igHandleMetaField());
                return true;
            }

            return false;
        }

        private static void RenderWaypoint(string? label, CWaypoint waypoint, NSTComponent manager, Action? renderRemove = null)
        {
            NSTWaypoint wp = manager.Entity.AddWaypoint(waypoint, manager.Explorer);

            label ??= "Waypoint";

            ImGui.PushID(label);

            var flags = ImGuiSelectableFlags.AllowDoubleClick;
            if (wp.IsSelected) flags |= ImGuiSelectableFlags.Highlight;

            ImGui.SetNextItemAllowOverlap();
            if (ImGui.Selectable(label + ":", wp.IsSelected, flags))
            {
                if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                {
                    manager.Explorer.Focus(wp, true);
                }
                else
                {
                    manager.Explorer.SelectObject(wp.IsSelected ? manager.Entity : wp);
                }
            }
        
            renderRemove?.Invoke();

            ImGui.Indent();
            bool updated = RenderFloat3("Position:", ref waypoint._position, waypoint, manager, true);
            updated |= RenderFloat3("Rotation:", ref waypoint._rotation, waypoint, manager, true);
            RenderCheckbox("Occupied:", ref waypoint._occupied);
            ImGui.Unindent();

            ImGui.Separator();

            ImGui.PopID();

            if (updated && wp.Object3D != null)
            {
                if (wp.IsSelected)
                {
                    manager.Explorer.SelectObject(wp);
                }
                else
                {
                    var parent = wp.Object3D.Parent;
                    parent.Remove(wp.Object3D);
                    parent.Add(wp.CreateObject3D());
                    manager.Explorer.RenderNextFrame = true;
                }
            }
        }

        public static bool RenderCWaypointHandleList(string label, CWaypointHandleList handleList, igComponentData component, NSTComponent manager)
        {
            ImGui.Text(label + ":");

            IgzFile igz = manager.Explorer.FileManager.GetIgz(manager.Entity.ArchiveFile)!;

            if (handleList._data.Count > 0)
            {
                ImGui.Spacing();

                for (int i = 0; i < handleList._data.Count; i++)
                {
                    igHandleMetaField handle = handleList._data[i];

                    var RenderRemove = () =>
                    {
                        ImGui.SameLine();
                        ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - 16);
                        if (ImGui.SmallButton($"x##{i}"))
                        {
                            handleList._data.RemoveAt(i);
                            manager.SetUpdated(handleList, false);
                        }
                    };

                    if (handle.Reference == null)
                    {
                        ImGui.Text("(null)");
                        RenderRemove();
                        continue;
                    }

                    CWaypoint? waypoint = (CWaypoint?)igz.FindObject(handle.Reference);

                    if (waypoint == null)
                    {
                        ImGui.Text($"(Not Found) {handle.Reference}");
                        RenderRemove();
                        continue;
                    }

                    RenderWaypoint(waypoint.ObjectName, waypoint, manager, RenderRemove);
                }
                
                ImGui.Spacing();
            }
            else
            {
                ImGui.SameLine();
            }

            if (ImGui.Button("Add new...##" + label, new System.Numerics.Vector2(-1, 0)))
            {
                CWaypoint newWaypoint = new CWaypoint() { ObjectName = igz.FindSuitableName("Waypoint") };
                igHandleMetaField newHandle = new igHandleMetaField() { Reference = newWaypoint.ToNamedReference(manager.Entity.FileNamespace) };

                igz.Objects.Add(newWaypoint);
                handleList._data.Add(newHandle);
                
                return true;
            }

            return false;
        }

        public static void RenderObject(string name, igObject? obj, string fileNamespace, Type type, LevelExplorer explorer, Action<igObject?> callback, bool readOnly = false)
        {
            RenderObjectReference(name, obj?.ToNamedReference(fileNamespace), type, explorer, (value) =>
            {
                if (value == null)
                {
                    callback(null);
                }
                else
                {
                    NSTObject? entity = explorer.FindObject(value);
                    if (entity != null) callback(entity.GetObject());
                    else Console.WriteLine($"Warning: Could not find object reference {value}");
                }
            },
            // todo: allow to select objects from other files
            fileNamespace: fileNamespace,
            readOnly: readOnly);
        }

        public static NSTObject? RenderObjectReference(
            string label,
            igHandleMetaField metaField, 
            Type type,
            NSTComponent manager,
            string? fileNamespace = null,
            bool skipIfNotFound = false,
            bool defaultOpen = false,
            bool readOnly = false
        )
        {
            return RenderObjectReference(label, metaField.Reference, type, manager.Explorer, value =>
            {
                metaField.Reference = value;
                manager.SetUpdated(true);
                
            }, fileNamespace, skipIfNotFound, defaultOpen, readOnly);
        }

        public static NSTObject? RenderObjectReference(
            string label,
            NamedReference? reference, 
            Type type,
            LevelExplorer explorer,
            Action<NamedReference?> callback,
            string? fileNamespace = null,
            bool skipIfNotFound = false,
            bool defaultOpen = false,
            bool readOnly = false
        )
        {
            if (reference == null)
            {
                if (skipIfNotFound) return null;

                if (label != null)
                {
                    ImGui.Text(label);
                    ImGui.SameLine();
                }
                
                // Dropdown
                var objects = explorer.InstanceManager.AllObjects.Where(e => (fileNamespace == null || e.FileNamespace == fileNamespace) && e.GetObject().GetType().IsAssignableTo(type));
                ImGuiUtils.RenderComboWithSearch("##" + label, "null", objects.ToList(), (obj) =>
                {
                    callback(obj.ToReference());
                });

                // Paste
                if (_copyReference != null && _copyReferenceExplorer == explorer)
                {
                    ImGui.SameLine();
                    if (ImGui.Button("\uE901"))
                    {
                        callback(_copyReference);
                    }
                }

                return null;
            }
                        
            // Find object in explorer
            NSTObject? obj = explorer.FindObject(reference);

            if (obj == null)
            {
                if (skipIfNotFound) return null;

                ImGui.Text($"{label} (Not Found) {reference}");

                if (ImGuiUtils.SmallButtonAlignRight("\uE902"))
                {
                    ImGui.OpenPopup("ObjectReferencePopup");
                }
                if (ImGui.BeginPopup("ObjectReferencePopup"))
                {
                    if (ImGui.Selectable("Clear"))
                    {
                        callback(null);
                    }
                    ImGui.EndPopup();
                }
                return null;
            }

            ImGui.PushID(obj.GetObject().ObjectName + label);

            // Render object name
            if (label != null)
            {
                ImGui.Text(ImGuiUtils.TruncateTextToFit(label, ImGui.GetContentRegionAvail().X * 0.4f));
                ImGui.SameLine();
            }

            ImGui.SetNextItemAllowOverlap();
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(0, 0));

            ImGuiTreeNodeFlags flags = defaultOpen ? ImGuiTreeNodeFlags.DefaultOpen : ImGuiTreeNodeFlags.None;
            bool open = ImGui.CollapsingHeader("##" + label, flags);

            if (ImGui.IsItemHovered() && ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
            {
                explorer.Focus(obj);
            }

            ImGui.SameLine();
            float maxW = ImGui.GetContentRegionAvail().X - ImGui.CalcTextSize("\uE902").X - ImGui.GetStyle().FramePadding.X * 2 - 2;

            obj.RenderName(maxW);

            ImGui.PopStyleVar();

            // Render actions button & popup
            if (ImGuiUtils.SmallButtonAlignRight("\uE902"))
            {
                ImGui.OpenPopup("ObjectReferencePopup");
            }
            if (ImGui.BeginPopup("ObjectReferencePopup"))
            {
                // obj.RenderName();
                ImGui.PushStyleColor(ImGuiCol.Text, obj.GetObject().GetType().GetUniqueColor());
                ImGui.Text(obj.GetObject().GetType().Name);
                ImGui.PopStyleColor();

                // if (ImGui.Selectable("Replace"))
                // {
                //     var objects = explorer.InstanceManager.AllObjects.Where(e => e.GetObject().GetType().IsAssignableTo(type)).ToList();
                //     ImGuiUtils.RenderComboWithSearch("##" + label, "null", objects.Select(e => e.GetObject().ObjectName!).ToList(), (index) =>
                //     {
                //         NSTObject obj = objects[index];
                //         callback(obj.ToReference());
                //     });
                // }
                if (ImGui.Selectable("Copy"))
                {
                    _copyReference = reference.Clone();
                    _copyReferenceExplorer = explorer;
                }
                if (_copyReference != null && explorer == _copyReferenceExplorer && ImGui.Selectable("Paste"))
                {
                    callback(_copyReference); // todo: allow to paste into different explorer
                }
                if (!readOnly && ImGui.Selectable("Clear"))
                {
                    callback(null);
                }
                // ImGui.Separator();
                // if (ImGui.Selectable("Focus in editor"))
                // {
                //     NSTEntity? refEntity = explorer.FindEntity(reference);
                //     if (refEntity != null) explorer.FocusObject(refEntity.Object);
                //     else Console.WriteLine($"Warning: Could not find entity reference {reference}");
                // }
                // if (ImGui.Selectable("Focus in archive"))
                // {
                //     explorer.ArchiveRenderer.FocusObject(reference);
                // }
                ImGui.EndPopup();
            }

            ImGui.PopID();

            if (open)
            {
                ImGui.PushStyleColor(ImGuiCol.ChildBg, new System.Numerics.Vector4(0.1f, 0.12f, 0.2f, 1.0f));
                if (ImGui.BeginChild("ObjectChild##" + obj.GetObject().ObjectName + label, System.Numerics.Vector2.Zero, ImGuiChildFlags.Border | ImGuiChildFlags.AutoResizeY))
                {
                    if (ImGui.Selectable("")) explorer.Focus(obj);

                    ImGui.SameLine();
                    obj.RenderName();

                    ImGui.Separator();
                    obj.RenderEntityData(explorer);
                }
                ImGui.EndChild();
                ImGui.PopStyleColor();
                ImGui.Spacing();
            }

            return obj;
        }

#endregion
#region ImGui

        public static bool RenderCheckbox(string name, ref bool value, NSTObject obj, LevelExplorer explorer, int align = 0)
        {
            if (RenderCheckbox(name, ref value, align))
            {
                explorer.ArchiveRenderer.SetObjectUpdated(obj.ArchiveFile, obj.GetObject());
                return true;
            }
            return false;
        }
        private static bool RenderCheckbox(string name, ref bool value, igObject obj, NSTComponent c)
        {
            if (RenderCheckbox(name, ref value))
            {
                c.SetUpdated(obj);
                return true;
            }
            return false;
        }
        private static bool RenderCheckbox(string name, ref bool value, int align = 0)
        {
            ImGui.BeginGroup();
            ImGui.Text(name);
            if (align == 0) ImGui.SameLine();
            else ImGui.SameLine(align);
            bool changed = ImGui.Checkbox("##" + name, ref value);
            ImGui.EndGroup();
            return changed;
        }

        private static bool RenderInt(string name, ref int value, igObject obj, NSTComponent manager, int step = 1, int step_fast = 10)
        {
            ImGui.Text(name);
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-1);
            if (ImGui.InputInt("##" + name, ref value, step, step_fast))
            {
                manager.SetUpdated(obj);
                return true;
            }
            return false;
        }

        public static bool RenderFloat(string name, ref float value, NSTObject obj, LevelExplorer explorer, float step = 0.1f, float step_fast = 1.0f)
        {
            if (RenderFloat(name, ref value, step, step_fast))
            {
                explorer.ArchiveRenderer.SetObjectUpdated(obj.ArchiveFile, obj.GetObject());
                return true;
            }
            return false;
        }
        private static bool RenderFloat(string name, ref float value, igObject obj, NSTComponent c, float step = 0.1f, float step_fast = 1.0f)
        {
            if (RenderFloat(name, ref value))
            {
                c.SetUpdated(obj);
                return true;
            }
            return false;
        }
        private static bool RenderFloat(string name, ref float value, float step = 0.1f, float step_fast = 1.0f)
        {
            ImGui.Text(name);
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-1);
            return ImGui.InputFloat("##" + name, ref value, step, step_fast);
        }

        public static bool RenderFloat2(string name, ref igVec2fMetaField value, NSTObject obj, LevelExplorer explorer)
        {
            if (RenderFloat2(name, ref value))
            {
                explorer.ArchiveRenderer.SetObjectUpdated(obj.ArchiveFile, obj.GetObject());
                return true;
            }
            return false;
        }
        private static bool RenderFloat2(string name, ref igVec2fMetaField value)
        {
            var tmp = new System.Numerics.Vector2(value._x, value._y);

            ImGui.Text(name);
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-1);
            if (ImGui.InputFloat2("##" + name, ref tmp))
            {
                value._x = tmp.X;
                value._y = tmp.Y;
                return true;
            }
            return false;
        }

        private static bool RenderFloat3(string name, ref igVec3fMetaField value, igObject obj, NSTComponent manager, bool dragInput = false, float speed = 1)
        {
            var tmp = value.ToNumericsVector3();

            ImGui.Text(name);
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-1);
            if (!dragInput && ImGui.InputFloat3("##" + name, ref tmp) ||
                 dragInput && ImGui.DragFloat3("##" + name, ref tmp, speed))
            {
                value._x = tmp.X;
                value._y = tmp.Y;
                value._z = tmp.Z;
                manager.SetUpdated(obj);
                return true;
            }
            return false;
        }

        public static bool RenderFloat4(string name, ref igVec4fMetaField value, NSTObject obj, LevelExplorer explorer)
        {
            if (RenderFloat4(name, ref value))
            {
                explorer.ArchiveRenderer.SetObjectUpdated(obj.ArchiveFile, obj.GetObject());
                return true;
            }
            return false;
        }
        private static bool RenderFloat4(string name, ref igVec4fMetaField value)
        {
            var tmp = value.ToNumericsVector4();

            ImGui.Text(name);
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-1);
            if (ImGui.InputFloat4("##" + name, ref tmp))
            {
                value._x = tmp.X;
                value._y = tmp.Y;
                value._z = tmp.Z;
                value._w = tmp.W;
                return true;
            }
            return false;
        }

        private static bool RenderColor(string name, ref igVec3fMetaField value, igObject obj, NSTComponent manager)
        {
            if (RenderColor(name, ref value))
            {
                manager.SetUpdated(obj);
                return true;
            }
            return false;
        }
        private static bool RenderColor(string name, ref igVec3fMetaField value)
        {
            var tmp = value.ToNumericsVector3();

            ImGui.Text(name);
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-1);
            if (ImGui.ColorEdit3("##" + name, ref tmp))
            {
                value._x = tmp.X;
                value._y = tmp.Y;
                value._z = tmp.Z;
                return true;
            }
            return false;
        }

        private static bool RenderColor(string name, ref igVec4fMetaField value, igObject obj, NSTComponent manager)
        {
            if (RenderColor(name, ref value))
            {
                manager.SetUpdated(obj);
                return true;
            }
            return false;
        }
        private static bool RenderColor(string name, ref igVec4fMetaField value)
        {
            var tmp = value.ToNumericsVector4();

            ImGui.Text(name);
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-1);
            if (ImGui.ColorEdit4("##" + name, ref tmp))
            {
                value._x = tmp.X;
                value._y = tmp.Y;
                value._z = tmp.Z;
                value._w = tmp.W;
                return true;
            }
            return false;
        }

        private static bool RenderEnum<T>(string name, ref T value, igObject obj, NSTComponent manager) where T : Enum
        {
            ImGui.Text(name);
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-1);

            T localValue = value;
            bool changed = FieldRenderer.CreateEnumInput(value, value.GetType(), name, (newValue) => localValue = (T)newValue);

            if (changed)
            {
                value = localValue;
                manager.SetUpdated(obj);
            }

            return changed;
        }

        private static bool RenderString(string name, ref string? text, igComponentData component, NSTComponent manager)
        {
            string str = text ?? "";
            if (RenderString(name, ref str))
            {
                text = str;
                manager.SetUpdated();
                return true;
            }
            return false;
        }
        private static bool RenderString(string name, ref string value)
        {
            ImGui.Text(name);
            ImGui.SameLine();
            ImGui.SetNextItemWidth(-1);
            return ImGui.InputText("##" + name, ref value, 256);
        }

        private static bool RenderHandle(string name, string namespaceName, igHandleMetaField handle, igComponentData component, NSTComponent manager)
        {
            string objectName = handle.Reference?.objectName ?? "";

            if (RenderString(name, ref objectName))
            {
                if (handle.Reference == null) handle.Reference = new(namespaceName, objectName);
                else handle.Reference.objectName = objectName;
                manager.SetUpdated(component);
                return true;
            }
            return false;
        }

#endregion

    }
}