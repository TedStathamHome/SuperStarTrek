namespace GameObjects
{
    /// <summary>
    /// General coordinate structure used for quadrants and sectors.
    /// </summary>
    /// <param name="xAxis">Position on the X-axis (horizontal)</param>
    /// <param name="yAxis">Position on the Y-axis (vertical)</param>
    public struct Coordinate(int xAxis, int yAxis)
    {
        public int x = xAxis;
        public int y = yAxis;

        /// <summary>
        /// Evaluates if two coordinates have the same x/y values.
        /// </summary>
        /// <param name="coordinateToCompareTo">The Coordinate to compare this one to.</param>
        /// <returns>True if their x/y values match, false if they don't.</returns>
        public readonly bool Matches(Coordinate coordinateToCompareTo)
        {
            return (x == coordinateToCompareTo.x
                && y == coordinateToCompareTo.y);
        }
    }
}
