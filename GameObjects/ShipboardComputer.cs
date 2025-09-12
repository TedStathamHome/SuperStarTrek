namespace GameObjects
{
    public class ShipboardComputer
    {
        public ShipboardComputer()
        {
            
        }

        // The course trajectory grid looks like the following:
        // ┌───┬───┬───┐
        // │ 4 │ 3 │ 2 │
        // ├───┼───┼───┤
        // │ 5 │ * │ 1 │
        // ├───┼───┼───┤
        // │ 6 │ 7 │ 8 │
        // └───┴───┴───┘
        // The * represents the starting coordinate.
        // The array below represents the change in the 
        // x (horizontal) and y (vertical) axis in
        // relation to the starting coordinate.
        static internal double[,] courseTrajectoryGrid =
        {
            { 0, 0 },           // ignoring the zero element
            { 1, 0 },           // course 1 →
            { 1, 1 },           // course 2 
            { 0, 1 },           // course 3 ↑
            { -1, 1 },          // course 4
            { -1, 0 },          // course 5 ←
            { -1, -1 },         // course 6
            { 0, -1 },          // course 7 ↓
            { 1, -1 },          // course 8
            { 1, 0 }            // course 9, same as course 1
        };

        public static double DistanceBetweenCoordinates(Coordinate startingCoordinate, Coordinate endingCoordinate)
            // Uses the Pythagorean formula (c² = a² + b²) to determine the distance between two
            // coordinates, taking the square reoot of c² in the formula below.
            => Math.Sqrt(
                Math.Pow(startingCoordinate.x - endingCoordinate.x, 2) +
                Math.Pow(startingCoordinate.y - endingCoordinate.y, 2)
                );

        private static double CourseAdjustmentVertical(int relativeXAxisDistance, int relativeYAxisDistance)
        {
            double courseAdjustment;

            // If the change in the x-axis is greater than the change in the y-axis,
            // adjust the course by a fraction of a course point.
            if (Math.Abs(relativeXAxisDistance) > Math.Abs(relativeYAxisDistance))
            {
                courseAdjustment = Math.Abs(relativeYAxisDistance) / Math.Abs(relativeXAxisDistance);
            }
            else
            {
                // Otherwise, adjust it by an amount larger than 1 course point.
                courseAdjustment = (2 * Math.Abs(relativeYAxisDistance) - Math.Abs(relativeXAxisDistance)) / Math.Abs(relativeYAxisDistance);
            }

            return courseAdjustment;
        }

        private static double CourseAdjustmentHorizontal(int relativeXAxisDistance, int relativeYAxisDistance)
        {
            // This is just the inverse of the vertical calculation,
            // so just swap the x and y-axis values and pass it through.
            return CourseAdjustmentVertical(relativeYAxisDistance, relativeXAxisDistance);
        }

        public static double CourseBetweenCoordinates(Coordinate startingCoordinate, Coordinate endingCoordinate)
        {
            const double courseHeadingNoMovement = 0d;
            const double courseHeadingRight = 1d;
            const double courseHeadingLeft = 5d;
            const double courseHeadingUp = 3d;
            const double courseHeadingDown = 7d;

            double courseToEndingCoordinate;

            var relativeXAxisDistance = endingCoordinate.x - startingCoordinate.x;
            var relativeYAxisDistance = endingCoordinate.y - startingCoordinate.y;

            if (relativeXAxisDistance == 0 && relativeYAxisDistance == 0)
            {
                // The two coordinates are at the same place, so there is no movement
                return courseHeadingNoMovement;
            }
            else if (relativeYAxisDistance == 0)
            {
                // No y-axis movement, so they're moving directly right or left
                return (relativeXAxisDistance > 0) ? courseHeadingRight : courseHeadingLeft;
            }
            else if (relativeXAxisDistance == 0)
            {
                // No x-axis movement, so they're moving directly up or down
                return (relativeYAxisDistance > 0) ? courseHeadingUp : courseHeadingDown;
            }

            if (relativeXAxisDistance > 0)
            {
                // Moving to the right, either up (counter-clockwise from heading right)
                // or down (counter-clockwise from heading down).
                courseToEndingCoordinate = (relativeYAxisDistance > 0) ?
                    (courseHeadingRight + CourseAdjustmentVertical(relativeXAxisDistance, relativeYAxisDistance)) :
                    (courseHeadingDown + CourseAdjustmentHorizontal(relativeXAxisDistance, relativeYAxisDistance));
            }
            else
            {
                // Moving to the left, either up (counter-clockwise from heading up)
                // or down (counter-clockwise from heading left).
                courseToEndingCoordinate = (relativeYAxisDistance > 0) ?
                    (courseHeadingUp + CourseAdjustmentHorizontal(relativeXAxisDistance, relativeYAxisDistance)) :
                    (courseHeadingLeft + CourseAdjustmentVertical(relativeXAxisDistance, relativeYAxisDistance));
            }

            return courseToEndingCoordinate;
        }

        public static Trajectory CalculateTrajectoryBasedOnCourse(double course)
        {
            const double lowestCourse = 1;
            const double highestCourse = 9;     // This is effectively course 1

            var trajectory = new Trajectory(0, 0);

            // If we have a good course
            if (course >= lowestCourse && course < highestCourse)
            {
                var integralPartOfCourse = (int)Math.Truncate(course);
                var decimalPartOfCourse = course - integralPartOfCourse;

                trajectory.ChangeInXAxis = courseTrajectoryGrid[integralPartOfCourse, 0] +
                    ((courseTrajectoryGrid[integralPartOfCourse + 1, 0] - courseTrajectoryGrid[integralPartOfCourse, 0])
                    * decimalPartOfCourse);

                trajectory.ChangeInYAxis = courseTrajectoryGrid[integralPartOfCourse, 1] +
                    ((courseTrajectoryGrid[integralPartOfCourse + 1, 1] - courseTrajectoryGrid[integralPartOfCourse, 1])
                    * decimalPartOfCourse);
            }

            return trajectory;
        }

        public static List<Coordinate> CalculateSectorPathBasedOnTrajectory(Coordinate startingCoordinate, Trajectory trajectory)
        {
            const int minimumSectorNumber = 0;
            const int maximumSectorNumber = 7;

            var sectorPath = new List<Coordinate>();
            var currentXPosition = (double)startingCoordinate.x;
            var currentYPosition = (double)startingCoordinate.y;

            // Loop until we exceed the bounds of the quadrant.
            while (true)
            {
                currentXPosition += trajectory.ChangeInXAxis;
                currentYPosition += trajectory.ChangeInYAxis;

                var coordinateXPosition = (int)Math.Truncate(Math.Round(currentXPosition + 0.01, 0));
                var coordinateYPosition = (int)Math.Truncate(Math.Round(currentYPosition + 0.01, 0));

                if ((coordinateXPosition >= minimumSectorNumber && coordinateXPosition <= maximumSectorNumber)
                    && (coordinateYPosition >= minimumSectorNumber && coordinateYPosition <= maximumSectorNumber))
                {
                    sectorPath.Add(new Coordinate(coordinateXPosition, coordinateYPosition));
                }
                else
                {
                    break;
                }
            }

            return sectorPath;
        }
    }
}
