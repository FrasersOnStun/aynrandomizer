using System;

namespace CryptographicRandomGenerator.Factories
{
    public class IntFactory :ValueFactory<int>
    {
        public override int Next()
        {
            var returnInt = BitConverter.ToInt32(RdmBytes, Offset);
            IncrementOffset();
            return returnInt;
        }
    }
}
}