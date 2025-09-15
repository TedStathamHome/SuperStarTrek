namespace GameObjects
{
    /// <summary>
    /// A trajectory used for navigation, range finding, and the firing of weapons.
    /// </summary>
    /// <param name="changeInXAxis">The fractional change in the X-axis of the trajectory.</param>
    /// <param name="changeInYAxis">The fractional change in the Y-axis of the trajectory.</param>
    public class Trajectory(double changeInXAxis, double changeInYAxis)
    {
        /// <summary>
        /// The fractional change in the X-axis of the trajectory.
        /// </summary>
        public double ChangeInXAxis { get; set; } = changeInXAxis;

        /// <summary>
        /// The fractional change in the Y-axis of the trajectory.
        /// </summary>
        public double ChangeInYAxis { get; set; } = changeInYAxis;

        /// <summary>
        /// Compares the current Trajectory to the indicated Trajectory.
        /// </summary>
        /// <param name="trajectoryToCompareTo">The Trajectory to compare the current Trajectory to.</param>
        /// <returns>True if the changes in the X and Y axes match, false if not or if the indicated Trajectory is null.</returns>
        public bool Matches(Trajectory trajectoryToCompareTo)
        {
            if (trajectoryToCompareTo == null)
                return false;

            return (ChangeInXAxis == trajectoryToCompareTo.ChangeInXAxis
                && ChangeInYAxis == trajectoryToCompareTo.ChangeInYAxis);
        }
    }
}
