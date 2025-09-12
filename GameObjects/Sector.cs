namespace GameObjects
{
    public enum SectorObject : byte
    {
        Nothing,
        Star,
        FederationStarbase,
        FederationStarship,
        KlingonBattleCruiser
    };

    public class Sector
    {
        public Sector()
        {
        }

        public SectorObject ObjectInSector { get; set; } = SectorObject.Nothing;

        public bool IsEmpty
            => ObjectInSector.Equals(SectorObject.Nothing);

        public bool IsOccupied
            => !IsEmpty;
    }
}
