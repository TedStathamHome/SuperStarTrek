namespace GameObjects
{
    /// <summary>
    /// Defines a Federation Starship, such as the USS Enterprise, and all of its
    /// properties and systems.
    /// </summary>
    public class FederationStarship
    {
        private const int MaximumEnergyReserves = 3000;
        private const byte MaximumPhotonTorpedoes = 10;
        private const int LowShieldEnergyLevel = 200;

        /// <summary>
        /// Coordinate defining which galactic quadrant the starship is located in.
        /// </summary>
        public Coordinate QuadrantCoordinate { get; set; }

        /// <summary>
        /// Coordinate defining which sector of the defined galactic quadrant the
        /// starship is located in.
        /// </summary>
        public Coordinate SectorCoordinate { get; set; }

        /// <summary>
        /// How much energy the starship has remaining for performing its various
        /// functions, such as raising shields, navigating, and firing weapons.
        /// Docking with a Federation Starbase will replenish the energy reserves
        /// to its maximum level.
        /// </summary>
        public int EnergyReserves { get; set; } = MaximumEnergyReserves;

        /// <summary>
        /// How much energy the starship has assigned to its defensive shields.
        /// This amount is taken from the EnergyReserves, and can be drawn upon
        /// if other shipboard systems need to. Docking with a Federation
        /// Starbase will drop the shields automatically.
        /// </summary>
        public int ShieldEnergy { get; set; } = 0;

        /// <summary>
        /// How many photon torpedoes remain for the starship to fire. Docking
        /// with a Federation Starbase will replenish the complement of photon
        /// torpedoes to the maximum level.
        /// </summary>
        public byte PhotonTorpedoesRemaining { get; set; } = MaximumPhotonTorpedoes;

        /// <summary>
        /// The list of shipboard systems available to the starship. Each of these
        /// can be damaged and repaired.
        /// </summary>
        public List<ShipboardSystem> ShipboardSystems { get; set; } = [];

        /// <summary>
        /// Constructs a new Federation Starship, placing it at the indicated
        /// galactic coordinates, and then initializes its shipboard systems.
        /// </summary>
        /// <param name="startingQuadrant">Coordinate defining which galactic quadrant the starship is located in.</param>
        /// <param name="startingSector">Coordinate defining which sector of the defined galactic quadrant the starship is located in.</param>
        public FederationStarship(Coordinate startingQuadrant, Coordinate startingSector)
        {
            QuadrantCoordinate = startingQuadrant;
            SectorCoordinate = startingSector;
            InitializeShipboardSystems();
        }

        /// <summary>
        /// Adds all the relevant shipboard systems to the starship.
        /// </summary>
        private void InitializeShipboardSystems()
        {
            ShipboardSystems.Add(new ShipboardSystem(ShipboardSystemType.WarpEngines, "Warp Engines"));
            ShipboardSystems.Add(new ShipboardSystem(ShipboardSystemType.ShortRangeSensors, "Short Range Sensors"));
            ShipboardSystems.Add(new ShipboardSystem(ShipboardSystemType.LongRangeSensors, "Long Range Sensors"));
            ShipboardSystems.Add(new ShipboardSystem(ShipboardSystemType.PhaserControl, "Phaser Control"));
            ShipboardSystems.Add(new ShipboardSystem(ShipboardSystemType.PhotonTorpedoTubes, "Photon Torpedo Tubes"));
            ShipboardSystems.Add(new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control"));
            ShipboardSystems.Add(new ShipboardSystem(ShipboardSystemType.ShieldControl, "Shield Contrl"));
            ShipboardSystems.Add(new ShipboardSystem(ShipboardSystemType.ShipboardComputer, "Shipboard Computer"));
        }

        /// <summary>
        /// Determines if the Federation Starship is docked with a nearby
        /// Federation Starbase.
        /// </summary>
        /// <param name="galaxy">The galaxy containing both the starship and the various starbases.</param>
        /// <returns>True if the starship is next to an active starbase, false if not.</returns>
        public bool IsDocked(Galaxy galaxy)
        {
            bool isDocked = false;
            const int minimumSectorNumber = 0;
            const int maximumSectorNumber = 7;

            var xAxisStart = SectorCoordinate.x - (SectorCoordinate.x > minimumSectorNumber ? 1 : 0);
            var xAxisEnd = SectorCoordinate.x + (SectorCoordinate.x < maximumSectorNumber ? 1 : 0);
            var yAxisStart = SectorCoordinate.y - (SectorCoordinate.y > minimumSectorNumber ? 1 : 0);
            var yAxisEnd = SectorCoordinate.y + (SectorCoordinate.y < maximumSectorNumber ? 1 : 0);

            for (var x = xAxisStart; x <= xAxisEnd && !isDocked; x++)
            {
                for (var y = yAxisStart; y <= yAxisEnd && !isDocked; y++)
                {
                    isDocked = galaxy
                        .Quadrants[QuadrantCoordinate.x, QuadrantCoordinate.y]
                        .Sectors[x, y]
                        .ObjectInSector.Equals(SectorObject.FederationStarbase);

                    // TODO: should check the starbase's IsActive flag
                    // TODO: add test case for being near an inactive starbase
                    // TODO: add test case for being near two starbases, both active
                    // TODO: add test case for being near two starbases, both inactive
                    // TODO: add test case for being near two starbases, one active, one inactive
                }
            }

            return isDocked;
        }

        /// <summary>
        /// Checks if the starship has enough energy to satisfy the request for
        /// energy. It uses the sum of the energy reserves and the energy assigned to
        /// the shields when making the comparison.
        /// </summary>
        /// <param name="energyToConsume">The amount of energy requested to be consumed.</param>
        /// <returns>True if there is enough energy, false if not.</returns>
        public bool HasSufficientEnergyReservesToConsumeEnergy(int energyToConsume)
            => energyToConsume <= (EnergyReserves + ShieldEnergy);

        /// <summary>
        /// Checks if the starship has enough energy to adjust the shields.
        /// </summary>
        /// <param name="energyToShields">The amount of energy to set the shields to.</param>
        /// <returns>True if there is enough energy, false if not.</returns>
        public bool HasSufficientEnergyToAdjustShields(int energyToShields)
            => HasSufficientEnergyReservesToConsumeEnergy(energyToShields);

        /// <summary>
        /// Returns the damage status of the identified shipboard system.
        /// </summary>
        /// <param name="shipboardSystemType">The shipboard system to check the damage status of.</param>
        /// <returns>True if the shipboard system is damaged, false if not.</returns>
        public bool ShipboardSystemIsDamaged(ShipboardSystemType shipboardSystemType)
            => ShipboardSystems.First(s => s.ShipboardSystemType.Equals(shipboardSystemType)).IsDamaged;

        /// <summary>
        /// Attempts to adjust the shield energy by the amount specified. No
        /// change will be made if the shield control system is damanged, the
        /// amount of energy requested is negative, the amount of energy
        /// requested is the same as the current shield level, or the energy
        /// requested is greater than the total energy available to the ship.
        /// </summary>
        /// <param name="energyToShields">The amount of energy to assign to the shields.</param>
        public void AdjustShieldEnergy(int energyToShields)
        {
            if (ShipboardSystemIsDamaged(ShipboardSystemType.ShieldControl) && energyToShields > 0)
            {
                // If not adjusting to zero energy (can always drop shields),
                // so report that shields are damaged and abort the adjustment.
                return;
            }

            if (energyToShields < 0 || ShieldEnergy == energyToShields)
            {
                // Supplied with a negative value or same energy level as already assigned,
                // so report that shield energy level didn't change.
                return;
            }

            if (energyToShields > (EnergyReserves + ShieldEnergy))
            {
                // Insufficient energy to adjust shield energy,
                // so report it and abort adjustment.
                return;
            }

            EnergyReserves += (ShieldEnergy - energyToShields);
            ShieldEnergy = energyToShields;
        }

        /// <summary>
        /// Drops the shields by adjusting the shield energy level to zero.
        /// </summary>
        public void DropShields()
        {
            AdjustShieldEnergy(0);
            // Report that shields were dropped.
        }

        /// <summary>
        /// Applies the specified amount of damage to the identified shipboard system.
        /// </summary>
        /// <param name="shipboardSystemType">The shipboard system to damage.</param>
        /// <param name="amountOfDamage">The amount of damage to apply to the shipboard system. Negative amounts will be converted to positives.</param>
        public void DamageShipboardSystemByStatedAmount(ShipboardSystemType shipboardSystemType, double amountOfDamage)
        {
            ShipboardSystems.First(s => s.ShipboardSystemType.Equals(shipboardSystemType)).TakeDamageByStatedAmount(Math.Abs(amountOfDamage));
        }

        /// <summary>
        /// Picks a random shipboard system.
        /// </summary>
        /// <returns>The randomly selected shipboard system.</returns>
        public static ShipboardSystemType PickRandomShipboardSystem()
            => (ShipboardSystemType)Enum.ToObject(typeof(ShipboardSystemType), Randomizer.RandomNumberBetween0and7);

        /// <summary>
        /// Attempts to consume energy from the reserves. Consumption of energy
        /// will fail if the amount requested is negative or exceeds the total
        /// energy available between the reserves and the shields. If there's
        /// enough energy available, but some of it is currently assigned to the
        /// shields, it will borrow any extra from the shields.
        /// </summary>
        /// <param name="energyToConsume">The amount of energy to attempt to consume.</param>
        public void ConsumeEnergyReserves(int energyToConsume)
        {
            if (energyToConsume < 0)
            {
                // Report that we cannot consume a negative amount of energy.
                return;
            }

            if (energyToConsume > (EnergyReserves + ShieldEnergy))
            {
                // Report that we cannot consume more energy than available in reserves and shields.
                return;
            }

            // TODO: May simply need to do this check, but abort consumption and let user choose to shift energy.

            // If we need to, borrow energy from the shields.
            if (energyToConsume > EnergyReserves)
            {
                if (ShipboardSystemIsDamaged(ShipboardSystemType.ShieldControl))
                {
                    // Report that to satisfy the request, we need to borrow energy from the shields,
                    // but they are damaged, which prevents us from borrowing the energy. This lets
                    // the player determine if they want to drop shields first, which they can always
                    // do, regardless of their damage level.
                    return;
                }

                var levelToSetShieldEnergyTo = EnergyReserves + ShieldEnergy - energyToConsume;
                AdjustShieldEnergy(levelToSetShieldEnergyTo);
            }

            EnergyReserves -= energyToConsume;
        }

        public void ReplenishEnergyReserves()
            => EnergyReserves = MaximumEnergyReserves;

        public void ReplenishPhotonTorpedoes()
            => PhotonTorpedoesRemaining = MaximumPhotonTorpedoes;

        public bool IsShieldEnergyDangerouslyLow()
            => ShieldEnergy <= LowShieldEnergyLevel;

        public bool ActiveKlingonBattleCruisersAreInQuadrant(List<KlingonBattleCruiser> klingonBattleCruisers)
            => klingonBattleCruisers.Any(k => k.QuadrantCoordinate.Equals(QuadrantCoordinate) && k.IsActive);

        private bool PhotonTorpedoWasAbsorbedByStar(List<Star> stars, Coordinate sector)
        {
            return stars.Any(s => s.QuadrantCoordinate.Equals(QuadrantCoordinate) && s.SectorCoordinate.Equals(sector));
        }

        private bool PhotonTorpedoDestroyedFederationStarbase(List<FederationStarbase> federationStarbases, Coordinate sector)
        {
            return federationStarbases.Any(s => s.QuadrantCoordinate.Equals(QuadrantCoordinate) && s.SectorCoordinate.Equals(sector));
        }

        private bool PhotonTorpedoDestroyedKlingonBattleCruiser(List<KlingonBattleCruiser> klingonBattleCruisers, Coordinate sector)
        {
            return klingonBattleCruisers.Any(k => k.QuadrantCoordinate.Equals(QuadrantCoordinate) && k.SectorCoordinate.Equals(sector));
        }

        public PhotonTorpedoFiringResult OutcomeOfFiringPhotonTorpedo(double firingCourse, List<KlingonBattleCruiser> klingonBattleCruisers, List<FederationStarbase> federationStarbases, List<Star> stars)
        {
            const int energyReservesRequiredToFirePhotonTorpedo = 2;
            ConsumeEnergyReserves(energyReservesRequiredToFirePhotonTorpedo);
            PhotonTorpedoesRemaining--;

            var firingResult = new PhotonTorpedoFiringResult
            {
                Outcome = PhotonTorpedoFiringOutcome.HitNothing,
                Course = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(SectorCoordinate, ShipboardComputer.CalculateTrajectoryBasedOnCourse(firingCourse))
            };

            // If there's nothing in the quadrant to hit, return.
            // The photon torpedo was wasted.
            if (klingonBattleCruisers.Count == 0 &&
                federationStarbases.Count == 0 &&
                stars.Count == 0)
            {
                return firingResult;
            }

            foreach (var sector in firingResult.Course)
            {
                if (PhotonTorpedoWasAbsorbedByStar(stars, sector))
                {
                    firingResult.Outcome = PhotonTorpedoFiringOutcome.AbsorbedByStar;
                    firingResult.ImpactCoordinate = sector;
                    break;
                }

                if (PhotonTorpedoDestroyedFederationStarbase(federationStarbases, sector))
                {
                    // Deactivate federation starbase
                    // Remove from sector
                    firingResult.Outcome = PhotonTorpedoFiringOutcome.DestroyedFederationStarbase;
                    firingResult.ImpactCoordinate = sector;
                    break;
                }

                if (PhotonTorpedoDestroyedKlingonBattleCruiser(klingonBattleCruisers, sector))
                {
                    // Deactivate Klingon battle cruiser
                    // Remove from sector
                    firingResult.Outcome = PhotonTorpedoFiringOutcome.DestroyedKlingonBattleCruiser;
                    firingResult.ImpactCoordinate = sector;
                    break;
                }
            }

            return firingResult;
        }

        public PhotonTorpedoFiringResult FirePhotonTorpedo(double firingCourse, List<KlingonBattleCruiser> klingonBattleCruisers, List<FederationStarbase> federationStarbases, List<Star> stars)
        {
            const int energyReservesRequiredToFirePhotonTorpedo = 2;
            var firingResult = new PhotonTorpedoFiringResult();

            if (PhotonTorpedoesRemaining == 0)
            {
                firingResult.Outcome = PhotonTorpedoFiringOutcome.NoPhotonTorpedoes;
                return firingResult;
            }

            if (ShipboardSystemIsDamaged(ShipboardSystemType.PhotonTorpedoTubes))
            {
                firingResult.Outcome = PhotonTorpedoFiringOutcome.PhotonTorpedoTubesAreDamaged;
                return firingResult;
            }

            if (!HasSufficientEnergyReservesToConsumeEnergy(energyReservesRequiredToFirePhotonTorpedo))
            {
                firingResult.Outcome = PhotonTorpedoFiringOutcome.InsufficientEnergyReserves;
                return firingResult;
            }

            return OutcomeOfFiringPhotonTorpedo(firingCourse, klingonBattleCruisers, federationStarbases, stars);
        }
    }
}
