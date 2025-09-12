using GameObjects;

namespace GameConsole
{
    internal class Game
    {
        private const int GalaxyWidthHeight = 8;

        private Galaxy Galaxy = new();
        private static Coordinate RandomCoordinate
            => new(Randomizer.RandomNumberBetween0and7, Randomizer.RandomNumberBetween0and7);
        private int StartingStardate;
        private int StardatesToCompleteMissionIn;
        private double CurrentStardate;

        public static void Main()
        {

        }

        public void Start()
        {
            Galaxy = new Galaxy();
            PopulateGalaxy();
            InitializeMissionParameters();
        }

        private void PopulateGalaxy()
        {
            PlaceTheUssEnterprise();

            for (int i = 0; i < GalaxyWidthHeight; i++)
            {
                for (int j = 0; j < GalaxyWidthHeight; j++)
                {
                    const double chanceOfStarbaseInQuadrant = 0.96d;

                    var quadrantCoordinate = new Coordinate(i, j);
                    var klingonBattleCruisersToPlaceInQuadrant = KlingonBattleCruisersToPlaceInQuadrant();
                    var federationStarbasesToPlaceInQuadrant = (Randomizer.RandomDoubleBetween0and1 > chanceOfStarbaseInQuadrant) ? 1 : 0;
                    var starsToPlaceInQuadrant = Randomizer.RandomNumberBetween0and7;

                    PlaceKlingonBattleCruisersInQuadrant(quadrantCoordinate, klingonBattleCruisersToPlaceInQuadrant);
                    PlaceFederationStarbasesInQuadrant(quadrantCoordinate, federationStarbasesToPlaceInQuadrant);
                    PlaceStarsInQuadrant(quadrantCoordinate, starsToPlaceInQuadrant);
                }
            }

            AddFederationStarbasesIfNoneInGalaxy();

            DockTheEnterpriseIfNextToStarbase();
        }

        private void InitializeMissionParameters()
        {
            const double baseMillenium = 20d;
            const double milleniumAdjustment = 20d;
            const int milleniumFactor = 100;
            const int baseStardatesToCompleteMissionIn = 25;
            const double extraStardatesToCompleteMissionIn = 10d;

            StartingStardate = Convert.ToInt32(baseMillenium + milleniumAdjustment * Randomizer.RandomDoubleBetween0and1) * milleniumFactor;
            CurrentStardate = StartingStardate;
            StardatesToCompleteMissionIn = baseStardatesToCompleteMissionIn + Convert.ToInt32(extraStardatesToCompleteMissionIn * Randomizer.RandomDoubleBetween0and1);

            if (Galaxy.KlingonBattleCruisers.Count > StardatesToCompleteMissionIn)
            {
                StardatesToCompleteMissionIn = Galaxy.KlingonBattleCruisers.Count + 1;
            }
        }

        private void PlaceTheUssEnterprise()
        {
            Galaxy.UssEnterprise = new(RandomCoordinate, RandomCoordinate);

            PlaceSectorObjectInGalaxy(SectorObject.FederationStarship, Galaxy.UssEnterprise.QuadrantCoordinate, Galaxy.UssEnterprise.SectorCoordinate);
        }

        private void PlaceSectorObjectInGalaxy(SectorObject sectorObject, Coordinate quadrantCoordinate, Coordinate sectorCoordinate)
        {
            Galaxy
                .Quadrants[quadrantCoordinate.x, quadrantCoordinate.y]
                .Sectors[sectorCoordinate.x, sectorCoordinate.y]
                .ObjectInSector = sectorObject;
        }

        private static int KlingonBattleCruisersToPlaceInQuadrant()
        {
            const double rateFor3KlingonBattleCruisers = 0.98d;
            const double rateFor2KlingonBattleCruisers = 0.95d;
            const double rateFor1KlingonBattleCruiser = 0.8d;

            var chanceOfKlingonBattleCruisers = Randomizer.RandomDoubleBetween0and1;
            int klingonBattleCruisersToPlaceInQuadrant = 0;

            if (chanceOfKlingonBattleCruisers > rateFor3KlingonBattleCruisers)
            {
                klingonBattleCruisersToPlaceInQuadrant = 3;
            }
            else if (chanceOfKlingonBattleCruisers > rateFor2KlingonBattleCruisers)
            {
                klingonBattleCruisersToPlaceInQuadrant = 2;
            }
            else if (chanceOfKlingonBattleCruisers > rateFor1KlingonBattleCruiser)
            {
                klingonBattleCruisersToPlaceInQuadrant = 1;
            }

            return klingonBattleCruisersToPlaceInQuadrant;
        }

        private Coordinate FindAnEmptySectorInQuadrant(Coordinate quadrantCoordinate)
        {
            var sectorToCheck = RandomCoordinate;

            while (true)
            {
                if (Galaxy
                    .Quadrants[quadrantCoordinate.x, quadrantCoordinate.y]
                    .Sectors[sectorToCheck.x, sectorToCheck.y]
                    .IsOccupied)
                {
                    sectorToCheck = RandomCoordinate;
                }
                else
                    break;
            }

            return sectorToCheck;
        }

        private void PlaceKlingonBattleCruisersInQuadrant(Coordinate quadrantCoordinate, int klingonBattleCruisersToPlace)
        {
            if (klingonBattleCruisersToPlace > 0)
            {
                for (int k = 0; k < klingonBattleCruisersToPlace; k++)
                {
                    const double baseKlingonBattleCruiserEnergy = 200d;
                    const double extraEnergyPercentage = 0.5d;

                    var emptySector = FindAnEmptySectorInQuadrant(quadrantCoordinate);
                    int startingEnergyLevel = Convert.ToInt32(baseKlingonBattleCruiserEnergy * (extraEnergyPercentage + Randomizer.RandomDoubleBetween0and1));

                    Galaxy.KlingonBattleCruisers.Add(new(quadrantCoordinate, emptySector, startingEnergyLevel));
                    PlaceSectorObjectInGalaxy(SectorObject.KlingonBattleCruiser, quadrantCoordinate, emptySector);
                }
            }
        }

        private void PlaceFederationStarbasesInQuadrant(Coordinate quadrantCoordinate, int federationStarbasesToPlace)
        {
            if (federationStarbasesToPlace > 0)
            {
                for(int b = 0; b < federationStarbasesToPlace; b++)
                {
                    var emptySector = FindAnEmptySectorInQuadrant(quadrantCoordinate);

                    Galaxy.FederationStarbases.Add(new(quadrantCoordinate, emptySector));
                    PlaceSectorObjectInGalaxy(SectorObject.FederationStarbase, quadrantCoordinate, emptySector);
                }
            }
        }

        private void AddFederationStarbasesIfNoneInGalaxy()
        {
            if (Galaxy.FederationStarbases.Count == 0)
            {
                var klingonBattleCruisersNearUssEnterprise =
                    Galaxy.KlingonBattleCruisers.Count(k => k.QuadrantCoordinate.Equals(Galaxy.UssEnterprise.QuadrantCoordinate));

                if (klingonBattleCruisersNearUssEnterprise < 2)
                {
                    PlaceKlingonBattleCruisersInQuadrant(Galaxy.UssEnterprise.QuadrantCoordinate, 1);
                    PlaceFederationStarbasesInQuadrant(Galaxy.UssEnterprise.QuadrantCoordinate, 2);
                }

                PlaceFederationStarbasesInQuadrant(Galaxy.UssEnterprise.QuadrantCoordinate, 1);

                PlaceSectorObjectInGalaxy(SectorObject.Nothing, Galaxy.UssEnterprise.QuadrantCoordinate, Galaxy.UssEnterprise.SectorCoordinate);
                Galaxy.UssEnterprise.QuadrantCoordinate = RandomCoordinate;
                Galaxy.UssEnterprise.SectorCoordinate = FindAnEmptySectorInQuadrant(Galaxy.UssEnterprise.QuadrantCoordinate);
                PlaceSectorObjectInGalaxy(SectorObject.FederationStarship, Galaxy.UssEnterprise.QuadrantCoordinate, Galaxy.UssEnterprise.SectorCoordinate);
            }
        }

        private void PlaceStarsInQuadrant(Coordinate quadrantCoordinate, int starsToPlace)
        {
            if (starsToPlace > 0)
            {
                for (int s = 0; s < starsToPlace; s++)
                {
                    var emptySector = FindAnEmptySectorInQuadrant(quadrantCoordinate);

                    Galaxy.Stars.Add(new(quadrantCoordinate, emptySector));
                    PlaceSectorObjectInGalaxy(SectorObject.Star, quadrantCoordinate, emptySector);
                }
            }
        }

        private void DockTheEnterpriseIfNextToStarbase()
        {
            if (Galaxy.UssEnterprise.IsDocked(Galaxy))
            {
                Galaxy.UssEnterprise.DropShields();
                Galaxy.UssEnterprise.ReplenishEnergyReserves();
                Galaxy.UssEnterprise.ReplenishPhotonTorpedoes();
            }
        }

        public void AdvanceTime(double stardatesToAdvance)
        {
            CurrentStardate += stardatesToAdvance;
        }
    }
}
