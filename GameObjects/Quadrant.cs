namespace GameObjects
{
    public class Quadrant
    {
        public Quadrant()
        {
            InitializeSectors();
        }

        private const int QuadrantWidthHeight = 8;

        public bool IsScanned { get; set; } = false;

        public Sector[,] Sectors { get; set; } = new Sector[QuadrantWidthHeight, QuadrantWidthHeight];

        private int CountOfKlingonBattleCruisers()
            => (from Sector sector in Sectors
                where sector.IsOccupied
                    && sector.ObjectInSector == SectorObject.KlingonBattleCruiser
                select sector
                ).Count();

        private int CountOfFederationStarbases()
            => (from Sector sector in Sectors
                where sector.IsOccupied
                    && sector.ObjectInSector == SectorObject.FederationStarbase
                select sector
                ).Count();

        private int CountOfStars()
            => (from Sector sector in Sectors
                where sector.IsOccupied
                    && sector.ObjectInSector == SectorObject.Star
                select sector
                ).Count();

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
