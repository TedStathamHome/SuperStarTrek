namespace GameObjects
{
    public class Randomizer
    {
        private static readonly Random RandomNumberGenerator = new();

        public static byte RandomNumberBetween0and7
            => (byte)RandomNumberGenerator.Next(0, 8);

        public static double RandomDoubleBetween0and1
            => RandomNumberGenerator.NextDouble();
    }
}
