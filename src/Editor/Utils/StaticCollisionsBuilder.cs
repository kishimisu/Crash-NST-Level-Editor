using Alchemy;
using Havok;

namespace NST
{
    /// <summary>
    /// Handles extracting and rebuilding static collisions in .pak archives
    /// </summary>
    public static class StaticCollisionsUtils
    {
        /// <summary>
        /// Get static collision data from an IgArchive
        /// </summary>
        /// <returns>A pair of (object reference, hashtable index)</returns>
        public static Dictionary<HashedReference, int> GetCollisionData(IgArchive archive)
        {
            IgArchiveFile? collisionFile = archive.FindCollisionFile();

            if (collisionFile == null) {
                return [];
            }

            IgzFile collisionIgz = collisionFile.ToIgzFile();

            var table = collisionIgz.FindObject<CStaticCollisionHashInstanceIdHashTable>()!;

            return GetCollisionData(table);
        }

        /// <summary>
        /// Get static collision data from an archive's CStaticCollision hash table
        /// </summary>
        /// <returns>A pair of (object reference, hashtable index)</returns>
        private static Dictionary<HashedReference, int> GetCollisionData(CStaticCollisionHashInstanceIdHashTable table)
        {
            Dictionary<HashedReference, int> collisionData = [];

            foreach ((u64 key, i16 id) in table.Dict)
            {
                u32 namespaceHash  = (u32)(key >> 32);
                u32 objectNameHash = (u32)(key & 0xFFFFFFFF);

                var reference = new HashedReference(namespaceHash, objectNameHash);

                collisionData.Add(reference, id);
            }

            return collisionData;
        }

        /// <summary>
        /// Rebuild static collisions for an archive, more specifically
        /// the StaticCollision.igz and StaticCollision.hkx files.
        /// </summary>
        /// <param name="archive">The archive to rebuild</param>
        /// <param name="updatedCollisionData">The list of updated collisions</param>
        public static void RebuildCollisions(IgArchive archive, List<CollisionUpdateInfos> updatedCollisionData)
        {
            IgArchiveFile? collisionIgzFile = archive.FindCollisionFile(".igz");
            IgArchiveFile? collisionHkxFile = archive.FindCollisionFile(".hkx");

            if (collisionIgzFile == null) {
                Console.WriteLine("Could not rebuild collisions: Collision file not found.");
                return;
            }
            if (collisionHkxFile == null) {
                Console.WriteLine("Could not rebuild collisions: Havok file not found.");
                return;
            }

            IgzFile collisionIgz = collisionIgzFile.ToIgzFile();
            var table = collisionIgz.FindObject<CStaticCollisionHashInstanceIdHashTable>()!;

            HavokFile collisionHkx = collisionHkxFile.ToHavokFile();
            var compoundShape = (hknpStaticCompoundShape)collisionHkx.GetRootObjects().First(x => x is hknpStaticCompoundShape);

            Dictionary<hknpShapeInstance, u64> shapes = [];
            Dictionary<int, hknpShapeInstance> shapesById = [];
            HashSet<HashedReference> existing = [];
            bool rebuildHashMap = false;

            foreach ((u64 key, i16 id) in table.Dict)
            {
                hknpShapeInstance shape = compoundShape._elements[id];
                shapes.Add(shape, key);
                shapesById.Add(id, shape);
                existing.Add(new HashedReference((u32)(key >> 32), (u32)(key & 0xFFFFFFFF)));
            }

            foreach (CollisionUpdateInfos updateInfos in updatedCollisionData)
            {
                HashedReference reference = updateInfos.GetReference();

                if (updateInfos.removed)
                {
                    if (updateInfos.entity.CollisionShapeIndex == -1 || !existing.Contains(reference))
                    {
                        continue;
                    }

                    // Remove existing shape

                    hknpShapeInstance shape = shapesById[updateInfos.entity.CollisionShapeIndex];

                    compoundShape._elements.Remove(shape);

                    existing.Remove(reference);
                    shapes.Remove(shape);
                    rebuildHashMap = true;

                    Console.WriteLine("Removed collision for " + updateInfos.entity.Object.ObjectName);
                }
                else if (updateInfos.shapeInstance != null)
                {
                    // Add new shape

                    hknpShapeInstance shape = AddHavokShape(updateInfos, compoundShape, updateInfos.shapeInstance);

                    u64 key = ((u64)reference.fileHash << 32) | reference.objectHash;

                    shapes.Add(shape, key);
                    rebuildHashMap = true;

                    Console.WriteLine($"Added new collision shape for {updateInfos.entity.Object.ObjectName}{(updateInfos.entity.ParentPrefabInstance != null ? $", prefab hash: {updateInfos.entity.CollisionPrefabHash}" : "")}, key: {key}");
                }
                else if (!existing.Contains(reference))
                {
                    // Add new instance of existing shape

                    hknpShapeInstance original = shapesById[updateInfos.entity.CollisionShapeIndex];
                    hknpShapeInstance shape = AddHavokShape(updateInfos, compoundShape, original);

                    u64 key = ((u64)reference.fileHash << 32) | reference.objectHash;

                    shapes.Add(shape, key);
                    rebuildHashMap = true;

                    Console.WriteLine("Added collision shape instance for " + updateInfos.entity.Object.ObjectName);
                }
                else
                {
                    // Update existing shape

                    hknpShapeInstance toUpdate = shapesById[updateInfos.entity.CollisionShapeIndex];
                    
                    UpdateHavokShape(updateInfos.entity, toUpdate);

                    Console.WriteLine("Updated collision for " + updateInfos.entity.Object.ObjectName);
                }
            }

            // Rebuild BVH tree
            BVHNode root = BVHBuilder.Build(compoundShape._elements.GetElements());
            List<hkcdStaticTreeCodec3Axis6> axis6Tree = root.BuildAxis6Tree(compoundShape._elements.GetElements());

            compoundShape._boundingVolumeData._nodes.Clear();
            compoundShape._boundingVolumeData._nodes.AddRange(axis6Tree);

            // Update bounds
            compoundShape._min = new System.Numerics.Vector4(root.boundsMin.X, root.boundsMin.Y, root.boundsMin.Z, compoundShape._min.W);
            compoundShape._max = new System.Numerics.Vector4(root.boundsMax.X, root.boundsMax.Y, root.boundsMax.Z, compoundShape._max.W);
            compoundShape._boundingVolumeData._min = new System.Numerics.Vector4(root.boundsMin.X, root.boundsMin.Y, root.boundsMin.Z, compoundShape._boundingVolumeData._min.W);
            compoundShape._boundingVolumeData._max = new System.Numerics.Vector4(root.boundsMax.X, root.boundsMax.Y, root.boundsMax.Z, compoundShape._boundingVolumeData._max.W);

            collisionHkxFile.SetData(collisionHkx.Save());

            // Rebuild collision dictionary
            if (rebuildHashMap)
            {
                table.Dict.Clear();
                table.RebuildDict = true;

                foreach ((hknpShapeInstance shape, u64 key) in shapes)
                {
                    int index = compoundShape._elements.IndexOf(shape);
                    table.Dict.Add(key, (i16)index);
                }
                
                collisionIgzFile.SetData(collisionIgz.Save());
            }
        }

        /// <summary>
        /// Add a clone of a hknpShapeInstance to a static compound shape
        /// </summary>
        static hknpShapeInstance AddHavokShape(CollisionUpdateInfos infos, hknpStaticCompoundShape compoundShape, hknpShapeInstance shapeInstance)
        {
            hknpShapeInstance cloneInstance = (hknpShapeInstance)shapeInstance.Clone();
            
            compoundShape._elements.Add(cloneInstance);

            UpdateHavokShape(infos.entity, cloneInstance);

            return cloneInstance;
        }

        /// <summary>
        /// Update a hknpShapeInstance's transform
        /// </summary>
        static void UpdateHavokShape(NSTEntity entity, hknpShapeInstance shapeInstance)
        {
            THREE.Matrix4 transform = entity.ObjectToWorld();

            THREE.Vector3 position = new THREE.Vector3();
            THREE.Vector3 scale = new THREE.Vector3();
            THREE.Quaternion rotation = new THREE.Quaternion();
            
            transform.Decompose(position, rotation, scale);

            transform.Compose(position * 0.0254f, rotation, THREE.Vector3.One());
            
            System.Numerics.Matrix4x4 originalTransform = shapeInstance._transform;

            shapeInstance._transform = transform.ToMatrix4();
            shapeInstance._scale = new System.Numerics.Vector4(scale.X, scale.Y, scale.Z, 1);

            shapeInstance._transform.M14 = originalTransform.M14;
            shapeInstance._transform.M24 = originalTransform.M24;
            shapeInstance._transform.M34 = originalTransform.M34;
            shapeInstance._transform.M44 = originalTransform.M44;
        }
    }
}