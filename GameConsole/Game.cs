using GameObjects;
using System.Runtime.CompilerServices;

namespace GameConsole
{
    internal class Game
    {
        /// <summary>
        /// The galaxy is considered to be a square of quadrants of this width and height.
        /// </summary>
        private const int GalaxyWidthHeight = 8;

        /// <summary>
        /// The Galaxy that the game is played within.
        /// </summary>
        private static Galaxy Galaxy = new();

        /// <summary>
        /// The stardate the mission begins on.
        /// </summary>
        private static int StartingStardate;

        /// <summary>
        /// How many stardates the player has to complete the mission.
        /// </summary>
        private static int StardatesToCompleteMissionIn;

        /// <summary>
        /// What the current stardate is within the mission.
        /// </summary>
        private static double CurrentStardate;

        public static void Main()
        {
            Start();
        }

        public static void Start()
        {
            Galaxy = new Galaxy();
            PopulateGalaxy();
            InitializeMissionParameters();
            PlayTheGame();
        }

        /// <summary>
        /// Sets up the initial state of the galaxy, placing the USS Enterprise,
        /// along with random amounts of stars, Klingon battle cruisers, and
        /// Federation starbases.
        /// </summary>
        private static void PopulateGalaxy()
        {
            PlaceTheUssEnterprise();

            for (int i = 0; i < GalaxyWidthHeight; i++)
            {
                for (int j = 0; j < GalaxyWidthHeight; j++)
                {
                    // There's a 4% chance of a Federation starbase being present in the quadrant
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

        /// <summary>
        /// Sets out the mission parameters for the game.
        /// </summary>
        private static void InitializeMissionParameters()
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

        private static void PlayTheGame()
        {
            Galaxy.ActivityLog.Add(
                "                                    ,------*------,\r\n" +
                "                    ,-------------   '---  ------'\r\n" +
                "                     '-------- --'      / /\r\n" +
                "                         ,---' '-------/ /--,\r\n" +
                "                          '----------------'\r\n" +
                "\r\n" +
                "                    The USS Enterprise --- NCC-1701\r\n" +
                "\r\n");

            Galaxy.ActivityLog.Add(
                $"Your orders from Federation Command are as follows:\r\n" +
                $"     Destroy the {Galaxy.KlingonBattleCruisers.Count:N0} Klingon warships which have invaded\r\n" +
                $"   the galaxy before they can attack Federation Headquarters\r\n" +
                $"   on Stardate {StartingStardate + StardatesToCompleteMissionIn:0000}. " +
                $"This gives you {StardatesToCompleteMissionIn:N0} days. There {(Galaxy.FederationStarbases.Count > 1 ? "are" : "is")}\r\n" +
                $"   {Galaxy.FederationStarbases.Count:N0} starbase{(Galaxy.FederationStarbases.Count > 1 ? "s" : "")} "+
                $"in the galaxy for resupplying your ship.\r\n");

            Galaxy.ActivityLog.Display();

            // Prompt and wait for input to start game

            Galaxy.ActivityLog.Add("Your mission begins with your starship located\r\n" +
                $"in the galactic quadrant of {Quadrant.QuadrantName(Galaxy.UssEnterprise.QuadrantCoordinate, addQuadrantNumber: true)}.\r\n");

            Galaxy.ActivityLog.Display();
        }

        /// <summary>
        /// Calculates a random coordinate for placing objects in the galaxy's Quadrants and Sectors.
        /// </summary>
        /// <returns>A Coordinate with random X and Y values.</returns>
        private static Coordinate RandomCoordinate()
        {
            return new(Randomizer.RandomNumberBetween0and7, Randomizer.RandomNumberBetween0and7);
        }

        /// <summary>
        /// Places the USS Enterprise at a random Quadrant and Sector.
        /// </summary>
        private static void PlaceTheUssEnterprise()
        {
            Galaxy.UssEnterprise = new(RandomCoordinate(), RandomCoordinate());

            PlaceSectorObjectInGalaxy(SectorObject.FederationStarship, Galaxy.UssEnterprise.QuadrantCoordinate, Galaxy.UssEnterprise.SectorCoordinate);
        }

        /// <summary>
        /// Places an object within the specified galactic Quadrant and Sector.
        /// </summary>
        /// <param name="sectorObject">What kind of object to place.</param>
        /// <param name="quadrantCoordinate">The galactic Quadrant to place the object in.</param>
        /// <param name="sectorCoordinate">The Sector within the galactic Quadrant to place the object in.</param>
        private static void PlaceSectorObjectInGalaxy(SectorObject sectorObject, Coordinate quadrantCoordinate, Coordinate sectorCoordinate)
        {
            Galaxy
                .Quadrants[quadrantCoordinate.x, quadrantCoordinate.y]
                .Sectors[sectorCoordinate.x, sectorCoordinate.y]
                .ObjectInSector = sectorObject;
        }

        /// <summary>
        /// Calculates the number of Klingon battle cruisers to place in a
        /// galactic Quadrant.
        /// </summary>
        /// <returns>The number of Klingon battle cruisers to place.</returns>
        private static int KlingonBattleCruisersToPlaceInQuadrant()
        {
            // A quadrant will contain 1, 2 or 3 Klingon battle cruisers based on the following percentages:
            // -  2% chance of 3 battle cruisers
            // -  5% chance of 2 battle cruisers
            // - 20% chance of 1 battle cruiser
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

        /// <summary>
        /// Determines an empty Sector within a galactic Quadrant by randomly
        /// picking one until it finds an empty one.
        /// </summary>
        /// <param name="quadrantCoordinate">The galactic Quadrant to find an empty Sector within.</param>
        /// <returns>The coordinate of an empty Sector within the identified galactic Quadrant.</returns>
        private static Coordinate FindAnEmptySectorInQuadrant(Coordinate quadrantCoordinate)
        {
            var sectorToCheck = RandomCoordinate();

            while (true)
            {
                if (Galaxy
                    .Quadrants[quadrantCoordinate.x, quadrantCoordinate.y]
                    .Sectors[sectorToCheck.x, sectorToCheck.y]
                    .IsOccupied)
                {
                    sectorToCheck = RandomCoordinate();
                }
                else
                    break;
            }

            return sectorToCheck;
        }

        /// <summary>
        /// Places the specified number of Klingon battle cruisers in the
        /// identified galactic Quadrant, at randomly selected Sectors.
        /// </summary>
        /// <param name="quadrantCoordinate">The galactic Quadrant to place the Klingon battle cruisers in.</param>
        /// <param name="klingonBattleCruisersToPlace">The number of Klingon battle cruisers to place in the galactic Quadrant.</param>
        private static void PlaceKlingonBattleCruisersInQuadrant(Coordinate quadrantCoordinate, int klingonBattleCruisersToPlace)
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

        /// <summary>
        /// Places the specified number of Federation starbases in the
        /// identified galactic Quadrant, at randomly selected Sectors.
        /// </summary>
        /// <param name="quadrantCoordinate">The galactic Quadrant to place the Federation starbases in.</param>
        /// <param name="federationStarbasesToPlace">The number of Federation starbases to place in the galactic Quadrant.</param>
        private static void PlaceFederationStarbasesInQuadrant(Coordinate quadrantCoordinate, int federationStarbasesToPlace)
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

        /// <summary>
        /// Checks to see if there are no Federation starbases in the Galaxy,
        /// and if it finds there are none, it places between 1 and 3 Federation
        /// starbases in the galactic Quadrant the USS Enterprise is located
        /// in. If there are less than 2 Klingon battle cruisers in this same
        /// galactic Quadrant, it adds another one to the galactic Quadrant.
        /// If it had to add more Federation starbases, it moves the USS
        /// Enterprise to a random galactic Quadrant and Sector.
        /// </summary>
        private static void AddFederationStarbasesIfNoneInGalaxy()
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
                Galaxy.UssEnterprise.QuadrantCoordinate = RandomCoordinate();
                Galaxy.UssEnterprise.SectorCoordinate = FindAnEmptySectorInQuadrant(Galaxy.UssEnterprise.QuadrantCoordinate);
                PlaceSectorObjectInGalaxy(SectorObject.FederationStarship, Galaxy.UssEnterprise.QuadrantCoordinate, Galaxy.UssEnterprise.SectorCoordinate);
            }
        }

        /// <summary>
        /// Places the specified number of Stars in the identified galactic
        /// Quadrant, at randomly selected Sectors.
        /// </summary>
        /// <param name="quadrantCoordinate">The galactic Quadrant to place the Stars in.</param>
        /// <param name="starsToPlace">The number of Stars to place in the galactic Quadrant.</param>
        private static void PlaceStarsInQuadrant(Coordinate quadrantCoordinate, int starsToPlace)
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

        /// <summary>
        /// Checks to see if the USS Enterprise is docked to a Federation
        /// starbase (in a Sector adjacent to an active Federation starbase),
        /// and if so, drops the shields and replenishes the Enterprise's
        /// energy reserves and complement of photon torpedoes.
        /// </summary>
        private static void DockTheEnterpriseIfNextToStarbase()
        {
            if (Galaxy.UssEnterprise.IsDocked(Galaxy))
            {
                Galaxy.UssEnterprise.DropShields();
                Galaxy.UssEnterprise.ReplenishEnergyReserves();
                Galaxy.UssEnterprise.ReplenishPhotonTorpedoes();
            }
        }

        /// <summary>
        /// Advances the current stardate by the specified number of stardates.
        /// </summary>
        /// <param name="stardatesToAdvance">The number of stardates to advance the current stardate by. Negative amounts are ignored (no time travel allowed!).</param>
        public static void AdvanceTime(double stardatesToAdvance)
        {
            CurrentStardate += stardatesToAdvance < 0 ? stardatesToAdvance : 0;
        }
    }
}
