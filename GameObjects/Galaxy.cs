namespace GameObjects
{
    /// <summary>
    /// Defines the galaxy that the game occurs within.
    /// </summary>
    public class Galaxy
    {
        /// <summary>
        /// Constructs the galaxy for the game.
        /// </summary>
        public Galaxy()
        {
            InitializeQuadrants();
        }

        /// <summary>
        /// The galaxy is considered to be a square of quadrants of this width and height.
        /// </summary>
        private const int GalaxyWidthHeight = 8;

        /// <summary>
        /// The square grid of Quadrants in the galaxy.
        /// </summary>
        public Quadrant[,] Quadrants { get; set; } = new Quadrant[GalaxyWidthHeight, GalaxyWidthHeight];

        /// <summary>
        /// The list of stars populating the galaxy.
        /// </summary>
        public List<Star> Stars { get; set; } = [];

        /// <summary>
        /// The list of Federation starbases in the galaxy.
        /// </summary>
        public List<FederationStarbase> FederationStarbases { get; set; } = [];

        /// <summary>
        /// The list of Klingon battle cruisers in the galaxy.
        /// </summary>
        public List<KlingonBattleCruiser> KlingonBattleCruisers { get; set; } = [];

        /// <summary>
        /// The Federation starship USS Enterprise within the galaxy.
        /// </summary>
        public FederationStarship UssEnterprise { get; set; } = new(new Coordinate(0, 0), new Coordinate(0, 0));

        public ActivityLog ActivityLog { get; set; } = new();

        /// <summary>
        /// Initializes the Quadrants of the galaxy.
        /// </summary>
        internal void InitializeQuadrants()
        {
            for (int i = 0; i < GalaxyWidthHeight; i++)
            {
                for (int j = 0; j < GalaxyWidthHeight; j++)
                {
                    Quadrants[i, j] = new Quadrant();
                }
            }
        }
    }
}
