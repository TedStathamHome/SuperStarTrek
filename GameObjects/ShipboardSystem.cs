namespace GameObjects
{
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

    public class ShipboardSystem(ShipboardSystemType shipboardSystemType, string name)
    {
        public ShipboardSystemType ShipboardSystemType { get; set; } = shipboardSystemType;

        public string Name { get; set; } = name;

        public double DamageLevel { get; set; } = 0;

        public bool IsDamaged
            => DamageLevel > 0;

        public void TakeDamageByStatedAmount(double amountOfDamage)
            => DamageLevel += amountOfDamage >= 0 ? amountOfDamage : 0;

        public void TakeRandomDamage()
        {
            const double baseDamageToTake = 1;
            const double extraDamageToTake = 5;

            TakeDamageByStatedAmount(baseDamageToTake + Randomizer.RandomDoubleBetween0and1 * extraDamageToTake);
        }

        public void RepairDamageByStatedAmount(double amountToRepair)
        {
            DamageLevel -= amountToRepair >= 0 ? amountToRepair : 0;

            // Don't allow the damage level to go below zero,
            // as that allows a "super repaired" level for the
            // shipboard system.
            if (DamageLevel < 0)
                DamageLevel = 0;
        }

        public void MakeRandomRepairs()
        {
            const double baseRepairsToMake = 1;
            const double extraRepairsToMake = 3;

            RepairDamageByStatedAmount(baseRepairsToMake + Randomizer.RandomDoubleBetween0and1 * extraRepairsToMake);
        }

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
