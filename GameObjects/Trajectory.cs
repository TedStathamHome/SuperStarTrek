using System.Diagnostics.CodeAnalysis;

namespace GameObjects
{
    public class Trajectory(double changeInXAxis, double changeInYAxis)
    {
        public double ChangeInXAxis { get; set; } = changeInXAxis;

        public double ChangeInYAxis { get; set; } = changeInYAxis;

        public bool Matches(Trajectory trajectoryToCompareTo)
        {
            if (trajectoryToCompareTo == null)
                return false;

            return (ChangeInXAxis == trajectoryToCompareTo.ChangeInXAxis
                && ChangeInYAxis == trajectoryToCompareTo.ChangeInYAxis);
        }
    }
}
