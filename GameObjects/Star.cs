namespace GameObjects
{
    public class Star(Coordinate startingQuadrant, Coordinate startingSector)
    {
        public Coordinate QuadrantCoordinate { get; set; } = startingQuadrant;

        public Coordinate SectorCoordinate { get; set; } = startingSector;
    }
}
