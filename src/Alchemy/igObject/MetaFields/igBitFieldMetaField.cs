using System.Collections.Specialized;

namespace Alchemy
{
    public class igBitFieldMetaField : igMetaField
    {
        /// <summary>
        /// Parse all child fields from a bitfield stored as an int
        /// </summary>
        public override void Parse(IgzReader reader)
        {
            int bitfieldSize = AttributeUtils.GetObjectSize(GetType());

            int bitfieldValue = bitfieldSize switch
            {
                1 => reader.ReadByte(),
                2 => reader.ReadInt16(),
                4 => reader.ReadInt32(),
                _ => throw new InvalidOperationException($"Unsupported bitfield size {bitfieldSize}")
            };

            BitVector32.Section? section = null;

            foreach (CachedFieldAttr field in GetFields())
            {
                Type type = field.GetFieldType();
                int size = field.GetBitFieldSize();
                int maxValue = (1 << size) - 1;

                if (maxValue > short.MaxValue)
                    throw new Exception("Bitfield size is too large.");

                if (section == null)
                    section = BitVector32.CreateSection((short)maxValue);
                else
                    section = BitVector32.CreateSection((short)maxValue, section.Value);

                int fieldValue = (bitfieldValue >> section.Value.Offset) & section.Value.Mask;

                if (type.IsEnum)
                    field.SetValue(this, Enum.ToObject(type, fieldValue));
                else
                    field.SetValue(this, Convert.ChangeType(fieldValue, type));
            }
        }

        public override void Write(IgzWriter writer)
        {
            int bitfieldSize = AttributeUtils.GetObjectSize(GetType());
            int bitfieldValue = GetValueAsInteger();
            int position = writer.GetPosition();

            switch (bitfieldSize)
            {
                case 1:
                    writer.Write((byte)bitfieldValue, position);
                    break;
                case 2:
                    writer.Write((short)bitfieldValue, position);
                    break;
                case 4:
                    writer.Write(bitfieldValue, position);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported bitfield size {bitfieldSize}");
            }
        }

        /// <summary>
        /// Get the value of this bitfield as an integer
        /// </summary>
        public int GetValueAsInteger()
        {
            BitVector32.Section? section = null;
            int bitfieldValue = 0;

            foreach (CachedFieldAttr field in GetFields())
            {
                object value = field.GetValue(this)!;
                int size = field.GetBitFieldSize();
                int maxValue = (1 << size) - 1;

                if (section == null)
                    section = BitVector32.CreateSection((short)maxValue);
                else
                    section = BitVector32.CreateSection((short)maxValue, section.Value);

                // Convert to int if necessary
                int intValue = value switch
                {
                    bool boolVal => boolVal ? 1 : 0,
                    Enum enumVal => Convert.ToInt32(enumVal),
                    _ => Convert.ToInt32(value)
                };

                bitfieldValue |= intValue << section.Value.Offset;
            }

            return bitfieldValue;
        }
    }
}