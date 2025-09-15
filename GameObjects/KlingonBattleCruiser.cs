namespace GameObjects
{
    /// <summary>
    /// Constructs an instance of a Klingon battle cruiser.
    /// </summary>
    /// <param name="startingQuadrant">The Quadrant the battle cruiser is located in.</param>
    /// <param name="startingSector">The Sector within the Quadrant the battle cruiser is located in.</param>
    /// <param name="startingEnergyLevel">The amount of energy the battle cruiser starts with for performing its operations.</param>
    public class KlingonBattleCruiser(Coordinate startingQuadrant, Coordinate startingSector, int startingEnergyLevel)
    {
        /// <summary>
        /// The galactic Quadrant the battle cruiser is located in.
        /// </summary>
        public Coordinate QuadrantCoordinate { get; set; } = startingQuadrant;

        /// <summary>
        /// The Sector within the Quadrant the battle cruiser is located in.
        /// </summary>
        public Coordinate SectorCoordinate { get; set; } = startingSector;

        /// <summary>
        /// The starting amount of energy the battle cruiser has for performing its operations.
        /// </summary>
        public int StartingEnergyLevel { get; } = startingEnergyLevel;

        /// <summary>
        /// The current amount of energy the battle cruiser has for performing its operations.
        /// </summary>
        public int EnergyLevel { get; set; } = startingEnergyLevel;

        /// <summary>
        /// Indicates if a battle cruiser is still active. Will become inactive once destroyed by a photon torpedo.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
