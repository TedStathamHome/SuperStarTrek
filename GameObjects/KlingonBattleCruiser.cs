namespace GameObjects
{
    public class KlingonBattleCruiser(Coordinate startingQuadrant, Coordinate startingSector, int startingEnergyLevel)
    {
        public Coordinate QuadrantCoordinate { get; set; } = startingQuadrant;

        public Coordinate SectorCoordinate { get; set; } = startingSector;

        public int StartingEnergyLevel { get; } = startingEnergyLevel;

        public int EnergyLevel { get; set; } = startingEnergyLevel;

        public bool IsActive { get; set; } = true;
    }
}
