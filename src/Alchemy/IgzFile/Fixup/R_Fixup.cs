namespace Alchemy
{
    public class R_Fixup : Fixup<int>
    {
        public R_Fixup(string name) : base(name) {}
        public R_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}

        protected override void Parse(BinaryReader reader)
        {
            List<int> items = Decode(reader, _itemCount);
            AddRange(items);
        }

        protected override void WriteItems(BinaryWriter writer)
        {
            byte[] encoded = Encode(this);
            writer.Write(encoded);
        }

        public static List<int> Decode(BinaryReader reader, int count)
        {
            var list = new List<int>(count);
            int currentInt = 0;
            int currentShift = 0;

            // Read half-bytes
            int[] bytes = new int[2];
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                byte b = reader.ReadByte();
                bytes[0] = b & 0xF;
                bytes[1] = (b >> 4) & 0xF;

                for (int i = 0; i < 2; i++)
                {
                    int halfByte = bytes[i];
                    bool stopReading = (halfByte & 0b1000) == 0;

                    currentInt |= (halfByte & 0b0111) << currentShift;
                    currentShift += 3;

                    if (stopReading)
                    {
                        int lastInt = list.Count > 0 ? list[^1] : 0;
                        list.Add(lastInt + currentInt * 4);

                        if (list.Count == count) return list;

                        currentInt = 0;
                        currentShift = 0;
                    }
                }
            }

            return list;
        }

        public static byte[] Encode(List<int> data)
        {
            var bytes = new List<int>();

            data.Sort();

            for (int i = 0; i < data.Count; i++)
            {
                int lastInt = i > 0 ? data[i - 1] : 0;
                int currentInt = (data[i] - lastInt) / 4;

                do
                {
                    int bytePart = currentInt & 0b0111;
                    currentInt >>= 3;

                    if (currentInt != 0)
                        bytePart |= 0b1000; // Continue reading
                    bytes.Add(bytePart);
                } while (currentInt > 0);
            }

            // Ensure the byte list length is a multiple of 8
            while (bytes.Count % 8 != 0) 
                bytes.Add(0);

            // Pack bytes into final format
            var final = new List<byte>();
            for (int i = 0; i < bytes.Count; i += 2)
            {
                final.Add((byte)(bytes[i] | (bytes[i + 1] << 4)));
            }

            return final.ToArray();
        }
    }

    public class RVTB_Fixup : R_Fixup
    {
        public RVTB_Fixup() : base("RVTB") {}
        public RVTB_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }

    public class RSTT_Fixup : R_Fixup
    {
        public RSTT_Fixup() : base("RSTT") {}
        public RSTT_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }

    public class ROFS_Fixup : R_Fixup
    {
        public ROFS_Fixup() : base("ROFS") {}
        public ROFS_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }

    public class RPID_Fixup : R_Fixup
    {
        public RPID_Fixup() : base("RPID") {}
        public RPID_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }

    public class RHND_Fixup : R_Fixup
    {
        public RHND_Fixup() : base("RHND") {}
        public RHND_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }

    public class RNEX_Fixup : R_Fixup
    {
        public RNEX_Fixup() : base("RNEX") {}
        public RNEX_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }

    public class REXT_Fixup : R_Fixup
    {
        public REXT_Fixup() : base("REXT") {}
        public REXT_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }

    public class ROOT_Fixup : R_Fixup
    {
        public ROOT_Fixup() : base("ROOT") {}
        public ROOT_Fixup(BinaryReader reader, string name, int offset) : base(reader, name, offset) {}
    }
}