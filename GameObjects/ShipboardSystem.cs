namespace GameObjects
{
    /// <summary>
    /// Enumeration of the various shipboard systems of a Federation starship.
    /// </summary>
    public enum ShipboardSystemType : byte
    {
        WarpEngines = 0,
        ShortRangeSensors = 1,
        LongRangeSensors = 2,
        PhaserControl = 3,
        PhotonTorpedoTubes = 4,
        DamageControl = 5,
        ShieldControl = 6,
        ShipboardComputer = 7
    };

    /// <summary>
    /// A single shipboard system of a Federation starship.
    /// </summary>
    /// <param name="shipboardSystemType">The type of the shipboard system.</param>
    /// <param name="name">The friendly, human-readable name of the shipboard system.</param>
    public class ShipboardSystem(ShipboardSystemType shipboardSystemType, string name)
    {
        /// <summary>
        /// The shipboard system's type.
        /// </summary>
        public ShipboardSystemType ShipboardSystemType { get; set; } = shipboardSystemType;

        /// <summary>
        /// The friendly, human-readable name of the shipboard system.
        /// </summary>
        public string Name { get; set; } = name;

        /// <summary>
        /// The current level of damage sustained by the shipboard system. A value
        /// of zero indicates the system is fully operational.
        /// </summary>
        public double DamageLevel { get; set; } = 0;

        /// <summary>
        /// Indicates if the shipboard system is currently damaged.
        /// </summary>
        public bool IsDamaged
            => DamageLevel > 0;

        /// <summary>
        /// Damage the shipboard system by the indicated amount.
        /// </summary>
        /// <param name="amountOfDamage">The amount of damage to be inflicted on the shipboard system. Negative values are ignored.</param>
        public void TakeDamageByStatedAmount(double amountOfDamage)
            => DamageLevel += amountOfDamage >= 0 ? amountOfDamage : 0;

        /// <summary>
        /// Applies a random amount of damage to the shipboard system, between 1 and 6 points.
        /// </summary>
        public void TakeRandomDamage()
        {
            const double baseDamageToTake = 1;
            const double extraDamageToTake = 5;

            TakeDamageByStatedAmount(baseDamageToTake + Randomizer.RandomDoubleBetween0and1 * extraDamageToTake);
        }

        /// <summary>
        /// Apply repairs to the shipboard system by the indicated amount. The
        /// DamageLevel will not go below zero even if the amount to repair is
        /// greater than the current damage level.
        /// </summary>
        /// <param name="amountToRepair">The amount of damage to repair for the shipboard system. Negative values are ignored.</param>
        public void RepairDamageByStatedAmount(double amountToRepair)
        {
            DamageLevel -= amountToRepair >= 0 ? amountToRepair : 0;

            // Don't allow the damage level to go below zero,
            // as that allows a "super repaired" level for the
            // shipboard system.
            if (DamageLevel < 0)
                DamageLevel = 0;
        }

        /// <summary>
        /// Repair the shipboard system by a random amount between 1 and 4 points.
        /// </summary>
        public void MakeRandomRepairs()
        {
            const double baseRepairsToMake = 1;
            const double extraRepairsToMake = 3;

            RepairDamageByStatedAmount(baseRepairsToMake + Randomizer.RandomDoubleBetween0and1 * extraRepairsToMake);
        }

        /// <summary>
        /// Randomly repair or damage the shipboard system. The change will
        /// happen 20% of the time, effecting a repair in 40% of those cases
        /// and damage in the other 60% of cases.
        /// </summary>
        public void AffectDamageLevelRandomly()
        {
            const double chanceOfRandomChangeToDamageLevel = 0.8;
            const double chanceOfEffectingRandomRepairs = 0.6;

            if (Randomizer.RandomDoubleBetween0and1 >= chanceOfRandomChangeToDamageLevel)
            {
                if (Randomizer.RandomDoubleBetween0and1 >= chanceOfEffectingRandomRepairs)
                {
                    MakeRandomRepairs();
                }
                else
                {
                    TakeRandomDamage();
                }
            }
        }
    }
}
