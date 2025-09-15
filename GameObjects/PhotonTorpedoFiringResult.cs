namespace GameObjects
{
    /// <summary>
    /// Enumeration of the possible outcomes when firing a photon torpedo.
    /// </summary>
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

    /// <summary>
    /// The result of firing a photon torpedo.
    /// </summary>
    public class PhotonTorpedoFiringResult
    {
        /// <summary>
        /// The outcome of firing the photon torpedo. Defaults to it having hit nothing.
        /// </summary>
        public PhotonTorpedoFiringOutcome Outcome { get; set; } = PhotonTorpedoFiringOutcome.HitNothing;

        /// <summary>
        /// The list of sectors the photon torpedo passed through along its firing course.
        /// This will be empty if the photon torpedo could not be fired due to the starship
        /// having insufficient energy, having damaged photon torpedo tubes, or no available
        /// photon torpedos to fire.
        /// </summary>
        public List<Coordinate> Course { get; set; } = [];

        /// <summary>
        /// The sector the photon torpedo impacted something, like a star, a Federation
        /// starbase, or a Klingon battle cruiser. This will be empty if the photon
        /// torpedo could not be fired or nothing was encountered in its firing course.
        /// </summary>
        public Coordinate? ImpactCoordinate { get; set; } = null;

        /// <summary>
        /// Constructs the photon torpedo firing result.
        /// </summary>
        public PhotonTorpedoFiringResult()
        {
        }
    }
}
