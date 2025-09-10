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

            Dictionary<HashedReference, int> collisionData = GetCollisionData(table);
            bool rebuildHashMap = false;

            foreach (CollisionUpdateInfos updateInfos in updatedCollisionData)
            {
                if (updateInfos.shapeInstance != null)
                {
                    // Add new shape
                    int newShapeIndex = AddHavokShape(updateInfos.entity, compoundShape, updateInfos.shapeInstance);
                    u64 key = ((u64)updateInfos.reference.fileHash << 32) | (u64)updateInfos.reference.objectHash;

                    table.Dict.Add(key, (i16)newShapeIndex);
                    rebuildHashMap = true;

                    Console.WriteLine("Added new shape for " + updateInfos.entity.GetObjectName() + " at index " + newShapeIndex);
                }
                else if (!collisionData.ContainsKey(updateInfos.reference))
                {
                    // Add new instance of existing shape
                    int newShapeIndex = AddHavokShape(updateInfos.entity, compoundShape, updateInfos.shapeIndex);
                    u64 key = ((u64)updateInfos.reference.fileHash << 32) | (u64)updateInfos.reference.objectHash;

                    table.Dict.Add(key, (i16)newShapeIndex);
                    rebuildHashMap = true;

                    Console.WriteLine("Added collision for " + updateInfos.entity.GetObjectName() + " at index " + newShapeIndex + " (" + updateInfos.shapeIndex + ")");
                }
                else
                {
                    // Update existing shape
                    UpdateHavokShape(updateInfos.entity, compoundShape, updateInfos.shapeIndex);

                    Console.WriteLine("Updated collision for " + updateInfos.entity.GetObjectName() + " at index " + updateInfos.shapeIndex);
                }
                // TODO: handle removed shapes
            }

            // Rebuild BVH tree
            BVHNode root = BVHBuilder.Build(compoundShape._elements.GetElements());
            List<hkcdStaticTreeCodec3Axis6> axis6Tree = root.BuildAxis6Tree();
            compoundShape._boundingVolumeData._nodes.Clear();
            compoundShape._boundingVolumeData._nodes.AddRange(axis6Tree);

            collisionHkxFile.SetData(collisionHkx.Save());

            // Rebuild hash map
            if (rebuildHashMap)
            {
                table.RebuildDict = true;
                collisionIgzFile.SetData(collisionIgz.Save());
            }
        }

        /// <summary>
        /// Add a new instance of an existing shape to a static compound shape
        /// </summary>
        /// <param name="entity">Associated entity</param>
        /// <param name="compoundShape">Static compound shape</param>
        /// <param name="shapeIndex">hknpShapeInstance index</param>
        /// <returns></returns>
        static int AddHavokShape(igEntity entity, hknpStaticCompoundShape compoundShape, int shapeIndex)
        {
            hknpShapeInstance shapeInstance = compoundShape._elements[shapeIndex];

            return AddHavokShape(entity, compoundShape, shapeInstance);
        }

        /// <summary>
        /// Add a new hknpShapeInstance to a static compound shape
        /// </summary>
        /// <param name="entity">Associated entity</param>
        /// <param name="compoundShape">Static compound shape</param>
        /// <param name="shapeInstance">New shape instance</param>
        /// <returns></returns>
        static int AddHavokShape(igEntity entity, hknpStaticCompoundShape compoundShape, hknpShapeInstance shapeInstance)
        {
            hknpShapeInstance cloneInstance = (hknpShapeInstance)shapeInstance.Clone();
            int cloneIndex = compoundShape._elements.Count;

            compoundShape._elements.Add(cloneInstance);

            UpdateHavokShape(entity, compoundShape, cloneIndex);

            return cloneIndex;
        }

        /// <summary>
        /// Update a hknpShapeInstance's transform
        /// </summary>
        /// <param name="entity">Associated entity</param>
        /// <param name="compoundShape">Static compound shape</param>
        /// <param name="shapeIndex">hknpShapeInstance index</param>
        static void UpdateHavokShape(igEntity entity, hknpStaticCompoundShape compoundShape, int shapeIndex)
        {
            hknpShapeInstance shapeInstance = compoundShape._elements[shapeIndex];

            THREE.Vector3 position = entity._parentSpacePosition.ToVector3();
            THREE.Vector3 scale = THREE.Vector3.One();
            THREE.Quaternion rotation = THREE.Quaternion.Identity();

            if (entity._transform is igEntityTransform transform)
            {
                rotation = transform._parentSpaceRotation.ToQuaternion();
                scale = transform._nonUniformPersistentParentSpaceScale.ToVector3();
            }

            THREE.Matrix4 matrix = new THREE.Matrix4().Compose(position * 0.0254f, rotation, THREE.Vector3.One());
            
            System.Numerics.Matrix4x4 originalTransform = shapeInstance._transform;

            shapeInstance._transform = matrix.ToMatrix4();
            shapeInstance._scale = new System.Numerics.Vector4(scale.X, scale.Y, scale.Z, 1);

            shapeInstance._transform.M14 = originalTransform.M14;
            shapeInstance._transform.M24 = originalTransform.M24;
            shapeInstance._transform.M34 = originalTransform.M34;
            shapeInstance._transform.M44 = originalTransform.M44;
        }
    }
}