using Alchemy;

namespace NST
{
    /// <summary>
    /// Extension methods for igEntity objects
    /// </summary>
    public static class igEntityExtensions
    {
        /// <summary>
        /// Find the first child igComponentData of type T
        /// </summary>
        public static T? GetComponent<T>(this igEntity entity) where T : igComponentData
        {
            return (T?)entity._entityData?._componentData?._values.Find(e => e is T);
        }

        /// <summary>
        /// Get all igComponentData children
        /// </summary>
        public static List<igComponentData> GetComponents(this igEntity entity)
        {
            return entity._entityData?._componentData?._values.GetElements().OfType<igComponentData>().ToList() ?? [];
        }

        /// <summary>
        /// Find the model name associated to this entity
        /// </summary>
        public static string? GetModelName(this igEntity entity, IgArchive archive)
        {
            // todo: cleanup this mess
            CModelComponentData? modelComponent = entity.GetComponent<CModelComponentData>();

            string? modelName = modelComponent?._fileName; // CModelComponentData._fileName
            
            if (string.IsNullOrEmpty(modelName) && entity._entityData is CGameEntityData gameEntityData)
            {
                modelName = gameEntityData._modelName;     // CGameEntityData._modelName

                if (string.IsNullOrEmpty(modelName)) {
                    modelName = gameEntityData._skinName;  // CGameEntityData._skinName
                }
            }

            if (string.IsNullOrEmpty(modelName) && entity._entityData is CActorData actorData)
            {
                modelName = actorData._skin;               // CActorData._skin
            }

            if (string.IsNullOrEmpty(modelName))           // common_Spawner_TemplateData
            {
                common_Spawner_TemplateData? spawnerTemplate = entity.GetComponent<common_Spawner_TemplateData>();
                
                if (spawnerTemplate != null)
                {
                    NamedReference? entityToSpawnRef = spawnerTemplate._EntityToSpawn.Reference;

                    if (entityToSpawnRef != null)
                    {
                        igObject entityToSpawn = AlchemyUtils.FindObjectInArchives(entityToSpawnRef, archive);

                        if (entityToSpawn is igEntity entityToSpawnEntity)
                        {
                            modelName = modelComponent?._fileName;

                            if (string.IsNullOrEmpty(modelName) && entityToSpawnEntity._entityData is CGameEntityData gea)
                            {
                                modelName = gea._modelName;

                                if (string.IsNullOrEmpty(modelName)) {
                                    modelName = gea._skinName;
                                }
                            }

                            if (string.IsNullOrEmpty(modelName) && entityToSpawnEntity._entityData is CActorData ada)
                            {
                                modelName = ada._skin;
                            }

                            if (string.IsNullOrEmpty(modelName))
                            {
                                common_Collectible_AkuAku_SpawnedData? ccsd = entityToSpawnEntity.GetComponent<common_Collectible_AkuAku_SpawnedData>();

                                if (ccsd != null)
                                {
                                    modelName = @"actors:\NPC\AkuAku.igb";
                                }

                                if (string.IsNullOrEmpty(modelName))
                                {
                                    modelName = GetCollectibleModelName(entityToSpawnEntity, archive);
                                }
                            }
                        }
                    }
                }
            }            

            if (string.IsNullOrEmpty(modelName)) // Multiple_Spawner_Template_c
            {
                var multipleSpawner = entity.GetComponent<Multiple_Spawner_Template_c>();

                if (multipleSpawner != null)
                {
                    NamedReference? handleListRef = multipleSpawner._Spawn_Entity_List.Reference;

                    if (handleListRef != null)
                    {
                        igObject handleListObject = AlchemyUtils.FindObjectInArchives(handleListRef, archive);

                        if (handleListObject is CEntityHandleList handleList && handleList._count > 0)
                        {
                            NamedReference? entityToSpawnRef = handleList._data[0].Reference;

                            if (entityToSpawnRef != null)
                            {
                                igObject entityToSpawnObject = AlchemyUtils.FindObjectInArchives(entityToSpawnRef, archive);

                                if (entityToSpawnObject is igEntity entityToSpawn)
                                {
                                    modelName = entityToSpawn.GetModelName(archive);
                                }
                            }
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(modelName))
            {
                modelName = GetCollectibleModelName(entity, archive);
            }

            modelName = Path.GetFileNameWithoutExtension(modelName);

            return modelName;
        }

        private static string? GetCollectibleModelName(igEntity entity, IgArchive archive)
        {
            CCollectibleComponentData? cccd = entity.GetComponent<CCollectibleComponentData>();

            if (cccd != null)
            {
                NamedReference? idleVfxRef = cccd._idleVfx.Reference;

                if (idleVfxRef != null)
                {
                    IgArchiveFile? vfxFile = AlchemyUtils.FindFileInArchives(idleVfxRef.namespaceName, archive);
                    if (vfxFile != null)
                    {
                        IgzFile igz = vfxFile.ToIgzFile();
                        igVfxDrawModelOperator? drawModel = igz.FindObject<igVfxDrawModelOperator>();

                        if (drawModel != null)
                        {
                            return drawModel._modelNameInternal;
                        }
                    }
                    Console.WriteLine("Failed to find model for " + entity.ObjectName);
                }
            }

            return null;
        }
    
        public static List<igObject>? GetSpawnedChildren(this igEntity entity, IgArchive archive)
        {
            common_Spawner_TemplateData? spawner = entity.GetComponent<common_Spawner_TemplateData>();

            if (spawner != null)
            {
                NamedReference? entityToSpawnRef = spawner._EntityToSpawn.Reference;
                if (entityToSpawnRef == null) return null;

                igEntity? entityToSpawn = (igEntity?)AlchemyUtils.FindObjectInArchives(entityToSpawnRef, archive);
                if (entityToSpawn == null) return null;

                return [entityToSpawn];
            }

            Multiple_Spawner_Template_c? multiSpawner = entity.GetComponent<Multiple_Spawner_Template_c>();
            if (multiSpawner == null) return null;

            NamedReference? entityListRef = multiSpawner._Spawn_Entity_List.Reference;
            if (entityListRef == null) return null;

            CEntityHandleList? entityList = (CEntityHandleList?)AlchemyUtils.FindObjectInArchives(entityListRef, archive);
            if (entityList == null) return null;

            List<igObject> prefabs = [];

            foreach (igHandleMetaField? handle in entityList._data)
            {
                NamedReference? handleRef = handle?.Reference;
                if (handleRef == null) continue;
                
                igEntity? spawnedEntity = (igEntity?)AlchemyUtils.FindObjectInArchives(handleRef, archive);
                if (spawnedEntity == null) continue;

                prefabs.Add(spawnedEntity);
            }

            return prefabs;
        }
    }
}