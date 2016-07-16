using System;

namespace CryptographicRandomGenerator.Factories
{
    public class ULongFactory : ValueFactory<ulong>
    {
        public override ulong Next()
        {
            CheckBuffer();
            var returnInt = BitConverter.ToUInt64(RdmBytes, Offset);
            IncrementOffset();
            return returnInt;
        }
    }
}