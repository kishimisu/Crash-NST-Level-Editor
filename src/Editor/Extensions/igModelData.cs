using Alchemy;

namespace NST
{
    /// <summary>
    /// Simple container for draw call data
    /// </summary>
    public class DrawCallData
    {
        public int index; // Draw call index
        public NamedReference? materialHandle; // Material reference

        public List<uint> indices = [];
        public List<System.Numerics.Vector3> positions = [];
        public List<System.Numerics.Vector3> normals = [];
        public List<System.Numerics.Vector2> uvs = [];
    }

    /// <summary>
    /// Extension methods for igModelData objects
    /// </summary>
    public static class igModelDataExtensions
    {
        private static readonly uint[] _paddedElementSizes = [44, 52, 64, 76, 84, 140];

        /// <summary>
        /// Extracts draw calls from a model
        /// </summary>
        public static List<DrawCallData> ExtractDrawCalls(this igModelData model)
        {
            List<DrawCallData> drawCalls = [];

            for (int i = 0; i < model._drawCalls.Count; i++)
            {
                DrawCallData? drawCall = ProcessDrawcall(model, i);

                if (drawCall != null)
                {
                    drawCalls.Add(drawCall);
                }
                else
                {
                    Console.Error.WriteLine("Warning: There was an error processing a draw call.");
                }
            }

            return drawCalls;
        }

        /// <summary>
        /// Processes a draw call
        /// </summary>
        /// <param name="drawCallIndex">The index of the draw call in the model</param>
        /// <returns></returns>
        private static DrawCallData? ProcessDrawcall(this igModelData model, int drawCallIndex)
        {
            igModelDrawCallData drawcall = model._drawCalls[drawCallIndex];
            
            igVertexBuffer? vertexBuffer = drawcall._graphicsVertexBuffer?._vertexBuffer;
            igIndexBuffer? indexBuffer = drawcall._graphicsIndexBuffer?._indexBuffer;

            if (vertexBuffer == null || indexBuffer == null) return null;

            NamedReference? materialReference = drawcall._materialHandle.Reference;

            DrawCallData data = new DrawCallData() { 
                index = drawCallIndex, 
                materialHandle = materialReference
            };

            ExtractIndexBuffer(data, indexBuffer);
            ExtractVertexBuffer(model, data, vertexBuffer, drawCallIndex);

            return data;
        }

        /// <summary>
        /// Add indices to a draw call
        /// </summary>
        private static void ExtractIndexBuffer(DrawCallData data, igIndexBuffer buffer)
        {
            using MemoryStream indexStream = new MemoryStream(buffer._data.ToArray());
            using BinaryReader indexReader = new BinaryReader(indexStream);

            for (int i = 0; i < buffer._indexCount; i++)
            {
                data.indices.Add(indexReader.ReadUInt16());
            }
        }

        /// <summary>
        /// Add vertices, normals, and uvs to a draw call
        /// </summary>
        private static void ExtractVertexBuffer(igModelData model, DrawCallData data, igVertexBuffer buffer, int drawCallIndex)
        {
            igAnimatedTransform? transform = GetAnimatedTransform(model, drawCallIndex);
            igVertexFormat? format = buffer._format;

            if (format == null)
            {
                Console.Error.WriteLine("Warning: There was an error processing a vertex buffer.");
                return;
            }

            uint elementSize = format._vertexSize;
            bool hasPadding = _paddedElementSizes.Contains(elementSize);

            using MemoryStream stream = new MemoryStream(buffer._data.ToArray());
            using BinaryReader reader = new BinaryReader(stream);

            for (int i = 0; i < buffer._vertexCount; i++)
            {
                reader.Seek(i * elementSize);

                float px = reader.ReadSingle();
                float py = reader.ReadSingle();
                float pz = reader.ReadSingle();

                if (transform != null)
                {
                    px += transform._matrix._row3._x;
                    py += transform._matrix._row3._y;
                    pz += transform._matrix._row3._z;
                }

                float nx = 0;
                float ny = 0;
                float nz = 0;

                if (elementSize > 24)
                {
                    nx = reader.ReadSingle();
                    ny = reader.ReadSingle();
                    nz = reader.ReadSingle();

                    if (hasPadding) reader.ReadUInt32();
                }

                float u = (float)reader.ReadHalf();
                float v = (float)reader.ReadHalf();

                data.positions.Add(new System.Numerics.Vector3(px, py, pz));
                data.normals.Add(new System.Numerics.Vector3(nx, ny, nz));
                data.uvs.Add(new System.Numerics.Vector2(u, v));
            }
        }

        /// <summary>
        /// Get the animated transform corresponding to a draw call
        /// </summary>
        private static igAnimatedTransform? GetAnimatedTransform(this igModelData model, int drawCallIndex)
        {
            int transformIndex = model._drawCallTransformIndices[drawCallIndex] - 1;

            if (transformIndex < 0 || transformIndex >= model._transformHierarchy.Count)
            {
                return null;
            }

            if (model._transformHierarchy[transformIndex] > 0)
            {
                transformIndex = model._transformHierarchy[transformIndex] - 1;
            }

            if (transformIndex < 0 || transformIndex >= model._transforms.Count)
            {
                return null;
            }

            return model._transforms[transformIndex];
        }
    }
}
