using Alchemy;
using System.Diagnostics.CodeAnalysis;

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
        public static bool TryGetComponent<T>(this igEntity entity, [NotNullWhen(true)] out T? component) where T : igComponentData
        {
            component = (T?)entity._entityData?._componentData?._values.Find(e => e is T);
            return component != null;
        }

        /// <summary>
        /// Get all igComponentData children
        /// </summary>
        public static List<igComponentData> GetComponents(this igEntity entity)
        {
            return entity._entityData?._componentData?._values.GetElements().OfType<igComponentData>().ToList() ?? [];
        }

        /// <summary>
        /// Get all igComponentData children with their keys
        /// </summary>
        public static Dictionary<string, igComponentData> GetComponentsDictionary(this igEntity entity)
        {
            return entity._entityData?._componentData?.Dict.ToDictionary(x => x.Key, x => (igComponentData)x.Value) ?? [];
        }

        /// <summary>
        /// Add a new component to this entity
        /// </summary>
        public static void AddComponent(this igEntity entity, string key, igComponentData component)
        {
            if (entity._entityData?._componentData == null)
            {
                Console.WriteLine("Warning: igEntity._entityData._componentData is null");
                return;
            }

            if (entity._entityData._componentData.Dict.ContainsKey(key))
            {
                Console.WriteLine("Warning: igEntity._entityData._componentData already contains key " + key);
                return;
            }

            entity._entityData._componentData.Add(key, component);
            entity._entityData._componentData.RebuildDict = true;
        }

        /// <summary>
        /// Remove a component from this entity
        /// </summary>
        public static void RemoveComponent(this igEntity entity, string componentKey)
        {
            entity._entityData?._componentData?.Remove(componentKey);
        }

        /// <summary>
        /// Compute this entity's object-to-world matrix
        /// </summary>
        public static THREE.Matrix4 GetTransformMatrix(this igEntity entity, THREE.Vector3? overrideScale = null)
        {
            THREE.Vector3 position = entity._parentSpacePosition.ToVector3();

            if (entity._transform == null)
            {
                if (overrideScale != null)
                {
                    return new THREE.Matrix4().Compose(position, new THREE.Quaternion(), overrideScale);    
                }

                return new THREE.Matrix4().MakeTranslation(position.X, position.Y, position.Z);
            }

            THREE.Quaternion rotation = entity._transform._parentSpaceRotation.ToQuaternion();
            THREE.Vector3 scale = overrideScale ?? entity._transform._nonUniformPersistentParentSpaceScale.ToVector3();

            return new THREE.Matrix4().Compose(position, rotation, scale);
        }

        /// <summary>
        /// Find the model name associated to this entity
        /// </summary>
        public static string? GetModelName(this igEntity entity, IgzFile igz, LevelExplorer explorer)
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
                        igObject entityToSpawn = AlchemyUtils.FindObjectInArchives(entityToSpawnRef, explorer.Archive, explorer, igz);

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
                                    modelName = GetCollectibleModelName(entityToSpawnEntity, explorer);
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
                        igObject handleListObject = AlchemyUtils.FindObjectInArchives(handleListRef, explorer.Archive, explorer, igz);

                        if (handleListObject is CEntityHandleList handleList && handleList._count > 0)
                        {
                            NamedReference? entityToSpawnRef = handleList._data[0].Reference;

                            if (entityToSpawnRef != null)
                            {
                                igObject entityToSpawnObject = AlchemyUtils.FindObjectInArchives(entityToSpawnRef, explorer.Archive, explorer);

                                if (entityToSpawnObject is igEntity entityToSpawn)
                                {
                                    modelName = entityToSpawn.GetModelName(igz, explorer);
                                }
                            }
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(modelName))
            {
                modelName = GetCollectibleModelName(entity, explorer);
            }

            return modelName;
        }

        private static string? GetCollectibleModelName(igEntity entity, LevelExplorer explorer)
        {
            CCollectibleComponentData? cccd = entity.GetComponent<CCollectibleComponentData>();

            if (cccd != null)
            {
                NamedReference? idleVfxRef = cccd._idleVfx.Reference;

                if (idleVfxRef != null)
                {
                    IgArchiveFile? vfxFile = AlchemyUtils.FindFileInArchives(idleVfxRef.namespaceName, out _, explorer.Archive);
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
    }
}