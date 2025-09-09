namespace Alchemy
{
    /// <summary>
    /// Class containing encoded string pairs from EXNM and EXID fixups
    /// For EXNM fixups, these are indices in the TSTR fixup
    /// For EXID fixups, these are hashes of the original strings
    /// </summary>
    public struct HashedReference
    {
        public uint objectHash;
        public uint fileHash;
        public HashedReference(uint fileHash, uint objectHash) { this.fileHash = fileHash; this.objectHash = objectHash; }
        public override string ToString() => $"{fileHash}::{objectHash}";
    }

    /// <summary>
    /// Represents a reference to a named object, either external or in the same file
    /// Equivalent to EXNM/EXID fixup items but in human-readable form
    /// </summary>
    public class NamedReference
    {
        public string namespaceName = "";
        public string objectName = "";
        public bool isEXID = false; // EXNM/EXID

        public NamedReference() { }

        /// <summary>
        /// Creates an EXID NamedReference
        /// </summary>
        public static NamedReference EXID(string namespaceName, string objectName) => new NamedReference(namespaceName, objectName, true);

        /// <summary>
        /// Create a NamedReference from a namespace and object name
        /// </summary>
        /// <param name="isEXID">Whether the reference should be stored in EXID or EXNM (default)</param>
        public NamedReference(string namespaceName, string objectName, bool isEXID = false)
        {
            this.namespaceName = namespaceName;
            this.objectName = objectName;
            this.isEXID = isEXID;
        }

        public void SetNamespace(string name) => namespaceName = name;
        public void SetObject(string name) => objectName = name;
        public bool IsNullOrEmpty() => string.IsNullOrEmpty(namespaceName) || string.IsNullOrEmpty(objectName);

        /// <summary>
        /// Extracts the namespace and object name from a string in the format "namespace::object"
        /// </summary>
        public void SetNames(string name)
        {
            try {
                string[] parts = name.Split("::", 2);
                namespaceName = parts[0];
                objectName = parts[1];
            }
            catch
            {
                namespaceName = name;
                objectName = "";
            }
        }

        public HashedReference ToHandleEXNM(TSTR_Fixup TSTR) => ToEXNM(TSTR, true);
        public HashedReference ToObjectEXNM(TSTR_Fixup TSTR) => ToEXNM(TSTR, false);

        /// <summary>
        /// Converts a NamedReference back to an EXNM fixup item
        /// </summary>
        private HashedReference ToEXNM(TSTR_Fixup TSTR, bool handleRef = false)
        {
            uint fileHash = (uint)TSTR.AddUnique(namespaceName);
            uint objectHash = (uint)TSTR.AddUnique(objectName);

            if (handleRef) fileHash |= 0x80000000;

            return new HashedReference() { fileHash = fileHash, objectHash = objectHash };
        }

        /// <summary>
        /// Converts a NamedReference back to an EXID fixup item
        /// </summary>
        public HashedReference ToEXID()
        {
            uint fileHash = namespaceName.All(char.IsDigit) ? uint.Parse(namespaceName) : NamespaceUtils.ComputeHash(namespaceName);
            uint objectHash = objectName.All(char.IsDigit) ? uint.Parse(objectName) : NamespaceUtils.ComputeHash(objectName);

            return new HashedReference() { fileHash = fileHash, objectHash = objectHash };
        }

        public override bool Equals(object? obj) => obj is NamedReference other && namespaceName == other.namespaceName && objectName == other.objectName && isEXID == other.isEXID;
        public override int GetHashCode() => HashCode.Combine(namespaceName, objectName, isEXID);
        public override string ToString() => $"{(isEXID ? "[EXID] " : "")}{namespaceName}::{objectName}";
    }
}