namespace GameObjects
{
    /// <summary>
    /// A single quadrant of the galaxy, with what objects are within it.
    /// </summary>
    public class Quadrant
    {
        /// <summary>
        /// Constructs the quadrant, initializing its sectors.
        /// </summary>
        public Quadrant()
        {
            InitializeSectors();
        }

        /// <summary>
        /// Defines the square grid's width and height of the sectors within a quadrant.
        /// </summary>
        private const int QuadrantWidthHeight = 8;

        /// <summary>
        /// Reflects whether the Quadrant has been scanned by long- or short-range sensors.
        /// </summary>
        public bool IsScanned { get; set; } = false;

        /// <summary>
        /// The square grid of Sectors in the Quadrant.
        /// </summary>
        public Sector[,] Sectors { get; set; } = new Sector[QuadrantWidthHeight, QuadrantWidthHeight];

        /// <summary>
        /// Calculates the number of Klingon battle cruisers in the galactic Quadrant.
        /// </summary>
        /// <returns>The number of Klingon battle cruisers in the galactic Quadrant.</returns>
        private int CountOfKlingonBattleCruisers()
            => (from Sector sector in Sectors
                where sector.IsOccupied
                    && sector.ObjectInSector == SectorObject.KlingonBattleCruiser
                select sector
                ).Count();

        /// <summary>
        /// Calculates the number of Federation starbases in the galactic Quadrant.
        /// </summary>
        /// <returns>The number of Federation starbases in the galactic Quadrant.</returns>
        private int CountOfFederationStarbases()
            => (from Sector sector in Sectors
                where sector.IsOccupied
                    && sector.ObjectInSector == SectorObject.FederationStarbase
                select sector
                ).Count();

        /// <summary>
        /// Calculates the number of stars in the galactic Quadrant.
        /// </summary>
        /// <returns>The number of stars in the galactic Quadrant.</returns>
        private int CountOfStars()
            => (from Sector sector in Sectors
                where sector.IsOccupied
                    && sector.ObjectInSector == SectorObject.Star
                select sector
                ).Count();

        /// <summary>
        /// The scanner reading of objects in the galactic Quadrant. It is presented in
        /// a format of KBS, where K indicates the number of Klingon battle cruisers, B
        /// indicates the number of Federation starbases, and S indicates the number of
        /// stars located in the quadrant. If the quadrant has not be scanned before,
        /// it will instead provide "•••".
        /// </summary>
        public string ScannerReading
        {
            get
            {
                if (IsScanned)
                {
                    return $"{(CountOfKlingonBattleCruisers() * 100 + CountOfFederationStarbases() * 10 + CountOfStars()):000}";
                }
                else
                {
                    return "•••";
                }
            }
        }

        /// <summary>
        /// Initializes the Sectors of the galactic Quadrant to their default state.
        /// </summary>
        internal void InitializeSectors()
        {
            for (int i = 0; i < QuadrantWidthHeight; i++)
            {
                for(int j = 0; j < QuadrantWidthHeight; j++)
                {
                    Sectors[i, j] = new Sector();
                }
            }
        }
    }
}
