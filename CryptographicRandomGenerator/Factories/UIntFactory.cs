using System;

namespace CryptographicRandomGenerator.Factories
{
    public class UIntFactory : ValueFactory<uint>
    {
        public override uint Next()
        {
            CheckBuffer();
            var returnInt = BitConverter.ToUInt32(RdmBytes, Offset);
            IncrementOffset();
            return returnInt;
        }
    }
}