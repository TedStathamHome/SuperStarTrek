namespace GameObjects
{
    public enum PhotonTorpedoFiringOutcome
    {
        NoPhotonTorpedoes,
        PhotonTorpedoTubesAreDamaged,
        InsufficientEnergyReserves,
        HitNothing,
        AbsorbedByStar,
        DestroyedFederationStarbase,
        DestroyedKlingonBattleCruiser
    }

    public class PhotonTorpedoFiringResult
    {
        public PhotonTorpedoFiringOutcome Outcome { get; set; } = PhotonTorpedoFiringOutcome.HitNothing;

        public List<Coordinate> Course { get; set; } = [];

        public Coordinate? ImpactCoordinate { get; set; } = null;

        public PhotonTorpedoFiringResult()
        {
            
        }
    }
}
