namespace GameObjects
{
    /// <summary>
    /// Defines a Federation Starbase with a galactic position and its active status.
    /// </summary>
    /// <param name="startingQuadrant">Coordinate defining which galactic quadrant the starbase is located in.</param>
    /// <param name="startingSector">Coordinate defining which sector of the defined galactic quadrant the starbase is located in.</param>
    public class FederationStarbase(Coordinate startingQuadrant, Coordinate startingSector)
    {
        /// <summary>
        /// Coordinate defining which galactic quadrant the starbase is located in.
        /// </summary>
        public Coordinate QuadrantCoordinate { get; set; } = startingQuadrant;

        /// <summary>
        /// Coordinate defining which sector of the defined galactic quadrant the starbase is located in.
        /// </summary>
        public Coordinate SectorCoordinate { get; set; } = startingSector;

        /// <summary>
        /// The active status of the starbase. Starbases can be rendered inactive if destroyed by a photon torpedo.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
