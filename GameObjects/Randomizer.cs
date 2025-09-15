namespace GameObjects
{
    /// <summary>
    /// General functionality for randomizing certain calculations used
    /// throughout the system.
    /// </summary>
    public class Randomizer
    {
        /// <summary>
        /// The random number generator.
        /// </summary>
        private static readonly Random RandomNumberGenerator = new();

        /// <summary>
        /// Calculate a random integer between 0 and 7.
        /// </summary>
        public static byte RandomNumberBetween0and7
            => (byte)RandomNumberGenerator.Next(0, 8);

        /// <summary>
        /// Calculate a random percentage using a double value between 0 and 1.
        /// </summary>
        public static double RandomDoubleBetween0and1
            => RandomNumberGenerator.NextDouble();
    }
}
