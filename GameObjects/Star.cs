namespace GameObjects
{
    /// <summary>
    /// A star within a galactic Quadrant and Sector.
    /// </summary>
    /// <param name="startingQuadrant">The galactic Quadrant to place the star in.</param>
    /// <param name="startingSector">The Sector within the galactic Quadrant to place the star in.</param>
    public class Star(Coordinate startingQuadrant, Coordinate startingSector)
    {
        /// <summary>
        /// The galactic Quadrant the star is located in.
        /// </summary>
        public Coordinate QuadrantCoordinate { get; set; } = startingQuadrant;

        /// <summary>
        /// The Sector of the galactic Quadrant the star is located in.
        /// </summary>
        public Coordinate SectorCoordinate { get; set; } = startingSector;
    }
}
