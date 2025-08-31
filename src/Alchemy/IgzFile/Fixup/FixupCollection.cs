using System.Reflection;
using System.Text;

namespace Alchemy
{
    /// <summary>
    /// Container for all fixups in an IGZ file
    /// </summary>
    public class FixupCollection
    {
        public TDEP_Fixup TDEP = []; // External dependencies
        public TSTR_Fixup TSTR = []; // Strings
        public TMET_Fixup TMET = []; // Object types
        public MTSZ_Fixup MTSZ = []; // Object sizes
        public EXNM_Fixup EXNM = []; // Named object references
        public EXID_Fixup EXID = []; // Hashed object references
        public RVTB_Fixup RVTB = []; // Object offsets
        public RSTT_Fixup RSTT = []; // String offsets
        public ROFS_Fixup ROFS = []; // Object reference offsets
        public RPID_Fixup RPID = []; // Inactive memories offsets
        public RHND_Fixup RHND = []; // Handle offsets
        public RNEX_Fixup RNEX = []; // External reference offsets (1)
        public REXT_Fixup REXT = []; // External reference offsets (2)
        public ONAM_Fixup ONAM = []; // igNameList offset
        public ROOT_Fixup ROOT = []; // igObjectList offset
        public NSPC_Fixup NSPC = []; // Collision igNameList offset 

        // Named object references
        public List<NamedReference> handleReferences = [];
        public List<NamedReference> objectReferences = [];
        public List<NamedReference> exidReferences = [];
        
        public IFixup this[string name]
        {
            get
            {
                FieldInfo fixupField = GetFixupByName(name);
                return (IFixup)fixupField.GetValue(this)!;
            }
            set
            {
                FieldInfo fixupField = GetFixupByName(name);
                fixupField.SetValue(this, value);
            }
        }

        public List<IFixup> GetAll() => [ TDEP, TSTR, TMET, MTSZ, EXID, EXNM, RVTB, RSTT, ROFS, RPID, REXT, RHND, RNEX, ROOT, ONAM, NSPC ];
        public R_Fixup? GetR_Fixup(string name) => (R_Fixup?)this[name];
        public int GetActiveCount() => GetAll().Count(fixup => !fixup.IsEmpty());

        /// <summary>
        /// Parse all fixups from an IGZ file stream at its current position
        /// </summary>
        /// <param name="reader">The reader containing the IGZ data stream</param>
        /// <returns>The parsed fixup collection</returns>
        public static FixupCollection Parse(BinaryReader reader)
        {
            FixupCollection fixups = new FixupCollection();

            while (true)
            {
                int fixupStartOffset = (int)reader.BaseStream.Position;
                
                IFixup? fixup = ParseFixup(reader);
                if (fixup == null) break;

                string fixupName = fixup.GetName();
                fixups[fixupName] = fixup;

                reader.Seek(fixupStartOffset + fixup.GetSize());
            }

            fixups.SetupNamedReferences();

            return fixups;
        }
        
        /// <summary>
        /// Instantiates and parses a fixup according to its name.
        /// </summary>
        /// <returns>The parsed fixup, or null if the end of the fixups is reached</returns>
        private static IFixup? ParseFixup(BinaryReader reader) 
        {
            int offset = (int)reader.BaseStream.Position;
            byte[] nameBytes = reader.ReadBytes(4);

            if (nameBytes[0] * nameBytes[1] * nameBytes[2] * nameBytes[3] == 0)
            {
                return null; // End of fixups
            }

            string name = Encoding.UTF8.GetString(nameBytes);

            return name switch
            {
                "TDEP" => new TDEP_Fixup(reader, name, offset),
                "TSTR" => new TSTR_Fixup(reader, name, offset),
                "TMET" => new TMET_Fixup(reader, name, offset),
                "MTSZ" => new MTSZ_Fixup(reader, name, offset),
                "EXID" => new EXID_Fixup(reader, name, offset),
                "EXNM" => new EXNM_Fixup(reader, name, offset),
                "RVTB" => new RVTB_Fixup(reader, name, offset),
                "RSTT" => new RSTT_Fixup(reader, name, offset),
                "ROFS" => new ROFS_Fixup(reader, name, offset),
                "RPID" => new RPID_Fixup(reader, name, offset),
                "RHND" => new RHND_Fixup(reader, name, offset),
                "RNEX" => new RNEX_Fixup(reader, name, offset),
                "REXT" => new REXT_Fixup(reader, name, offset),
                "ROOT" => new ROOT_Fixup(reader, name, offset),
                "ONAM" => new ONAM_Fixup(reader, name, offset),
                "NSPC" => new NSPC_Fixup(reader, name, offset),
                _ => throw new Exception($"Unknown fixup name: {name}"),
            };
        }

        /// <summary>
        /// Convert EXNM and EXID entries to NamedReferences
        /// </summary>
        private void SetupNamedReferences()
        {
            foreach (HashedReference item in EXNM)
            {
                bool isHandle = (item.fileHash & 0x80000000) != 0;
                string namespaceName = TSTR[(int)(item.fileHash & 0x7FFFFFFF)];
                string objectName = TSTR[(int)item.objectHash];

                NamedReference reference = new NamedReference(namespaceName, objectName, false);

                if (isHandle)
                    handleReferences.Add(reference);
                else
                    objectReferences.Add(reference);
            }

            foreach (HashedReference item in EXID)
            {
                // string namespaceName = NamespaceUtils.FindNameForHash(item.fileHash);
                // string objectName = NamespaceUtils.FindNameForHash(item.objectHash);
                string namespaceName = item.fileHash.ToString();
                string objectName = item.objectHash.ToString();
                
                NamedReference reference = new NamedReference(namespaceName, objectName, true);
                exidReferences.Add(reference);
            }
        }

        /// <summary>
        /// Get the FieldInfo corresponding to a fixup name.
        /// </summary>
        private FieldInfo GetFixupByName(string name)
        {
            return GetType().GetField(name, BindingFlags.Public | BindingFlags.Instance)
                   ?? throw new ArgumentException($"Unknown fixup name: {name}");
        }
    }
}