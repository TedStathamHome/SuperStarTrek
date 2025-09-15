namespace GameObjects
{
    /// <summary>
    /// Enumeration of the possible contents of a galactic Quadrant Sector.
    /// </summary>
    public enum SectorObject : byte
    {
        Nothing,
        Star,
        FederationStarbase,
        FederationStarship,
        KlingonBattleCruiser
    };

    /// <summary>
    /// A single sector of a galactic Quadrant.
    /// </summary>
    public class Sector
    {
        /// <summary>
        /// Constructs an empty sector.
        /// </summary>
        public Sector()
        {
        }

        /// <summary>
        /// The object currently in the sector, which defaults to nothing (empty space).
        /// </summary>
        public SectorObject ObjectInSector { get; set; } = SectorObject.Nothing;

        /// <summary>
        /// Indicates if the sector is empty.
        /// </summary>
        public bool IsEmpty
            => ObjectInSector.Equals(SectorObject.Nothing);

        /// <summary>
        /// Indicates if the sector is occupied by anything, such as a star, Federation starbase or starship, or Klingon battle cruiser.
        /// </summary>
        public bool IsOccupied
            => !IsEmpty;
    }
}
