namespace CryptographicRandomGenerator.Factories
{
    public class ByteFactory : ValueFactory <byte>
    {
        public override byte Next()
        {
            CheckBuffer();
            var returnByte = RdmBytes[Offset];
            IncrementOffset();
            return returnByte;
        }
    }
}
