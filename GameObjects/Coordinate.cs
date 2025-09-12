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
    }
}
