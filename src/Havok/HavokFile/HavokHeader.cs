using Alchemy;

namespace Havok
{
    class HavokHeader
    {
        public u64 signature = 0x10C0C01057E0E057;
        public u32 userTag = 0;
        public u32 version = 11;

        public u8 ptrSize = 8;
        public u8 littleEndian = 1;
        public u8 reusePaddingOptimization = 0;
        public u8 emptyBaseClassOptimization = 1;

        public i32 sectionCount = 3;
        public i32 contentSectionIndex = 2;
        public i32 contentSectionOffset = 0;
        public i32 contentsClassNameSectionIndex = 0;
        public i32 contentsClassNameSectionOffset = 75;

        public string versionString = "hk_2014.1.0-r1";

        public u32 flags = 0;
        public i16 maxPredicate = 21;
        public i16 predicateArraySizePlusPadding = 16;

        public byte[] predicateArray = new byte[16];

        public HavokHeader(BinaryReader reader) 
        {
            signature = reader.ReadUInt64();
            userTag = reader.ReadUInt32();
            version = reader.ReadUInt32();

            ptrSize = reader.ReadByte();
            littleEndian = reader.ReadByte();
            reusePaddingOptimization = reader.ReadByte();
            emptyBaseClassOptimization = reader.ReadByte();

            sectionCount = reader.ReadInt32();
            contentSectionIndex = reader.ReadInt32();
            contentSectionOffset = reader.ReadInt32();
            contentsClassNameSectionIndex = reader.ReadInt32();
            contentsClassNameSectionOffset = reader.ReadInt32();

            versionString = reader.ReadNullTerminatedString();

            reader.Seek(56, SeekOrigin.Begin);
            flags = reader.ReadUInt32();
            maxPredicate = reader.ReadInt16();
            predicateArraySizePlusPadding = reader.ReadInt16();

            if (predicateArraySizePlusPadding > 0)
            {
                reader.Read(predicateArray, 0, (int)predicateArraySizePlusPadding);
            }        
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(signature);
            writer.Write(userTag);
            writer.Write(version);

            writer.Write(ptrSize);
            writer.Write(littleEndian);
            writer.Write(reusePaddingOptimization);
            writer.Write(emptyBaseClassOptimization);

            writer.Write(sectionCount);
            writer.Write(contentSectionIndex);
            writer.Write(contentSectionOffset);
            writer.Write(contentsClassNameSectionIndex);
            writer.Write(contentsClassNameSectionOffset);

            writer.WriteNullTerminatedString(versionString);

            writer.Seek(55, SeekOrigin.Begin);
            writer.Write((byte)0xFF);

            writer.Write(flags);
            writer.Write(maxPredicate);
            writer.Write(predicateArraySizePlusPadding);

            if (predicateArraySizePlusPadding > 0)
            {
                writer.Write(predicateArray, 0, (int)predicateArraySizePlusPadding);
            }
        }
    }
}