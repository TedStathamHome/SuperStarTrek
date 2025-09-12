using GameObjects;

namespace GameTests;

[TestClass]
public sealed class ShipboardComputerBehavior
{
    #region DistanceBetweenCoordinatesBehavior
    [TestMethod]
    [TestCategory("DistanceBetweenCoordinates")]
    public void DistanceBetweenCoordinates_ShouldReturnSqrtOf2_WhenObjects1SectorApartDiagonally()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(1, 1);
        var testEndingCoordinate = new Coordinate(2, 2);

        // Act
        var testResult = ShipboardComputer.DistanceBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(Math.Sqrt(2d), testResult);
    }
    #endregion

    #region CourseBetweenCoordinatesBehavior
    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn0_WhenEndingCoordinateSameAsStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(4, 4);

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(0, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn1_WhenEndingCoordinateToRightOfStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(5, 4);

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(1, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn3_WhenEndingCoordinateAboveStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(4, 5);

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(3, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn5_WhenEndingCoordinateToLeftOfStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(3, 4);

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(5, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn7_WhenEndingCoordinateBelowStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(4, 3);

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(7, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn1p333_WhenEndingCoordinate3ToRightAnd1AboveStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(7, 5);
        double testExpectedResult = 1 + 1 / 3;

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(testExpectedResult, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn2p666_WhenEndingCoordinate1ToRightAnd3AboveStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(5, 7);
        double testExpectedResult = 1 + ((2 * 3 - 1) / 3);

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(testExpectedResult, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn3p333_WhenEndingCoordinate1ToLeftAnd3AboveStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(3, 7);
        double testExpectedResult = 3 + 1 / 3;

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(testExpectedResult, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn4p666_WhenEndingCoordinate3ToLeftAnd1AboveStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(1, 5);
        double testExpectedResult = 3 + ((2 * 3 - 1) / 3);

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(testExpectedResult, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn5p333_WhenEndingCoordinate3ToLeftAnd1BelowStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(1, 3);
        double testExpectedResult = 5 + 1 / 3;

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(testExpectedResult, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn6p666_WhenEndingCoordinate1ToLeftAnd3BelowStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(3, 1);
        double testExpectedResult = 5 + ((2 * 3 - 1) / 3);

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(testExpectedResult, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn7p333_WhenEndingCoordinate1ToRightAnd3BelowStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(5, 1);
        double testExpectedResult = 7 + 1 / 3;

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(testExpectedResult, testResult);
    }

    [TestMethod]
    [TestCategory("CourseBetweenCoordinates")]
    public void CourseBetweenCoordinates_ShouldReturn8p666_WhenEndingCoordinate3ToRightAnd1BelowStartingCoordinate()
    {
        // Arrange
        var testStartingCoordinate = new Coordinate(4, 4);
        var testEndingCoordinate = new Coordinate(7, 3);
        double testExpectedResult = 7 + ((2 * 3 - 1) / 3);

        // Act
        var testResult = ShipboardComputer.CourseBetweenCoordinates(testStartingCoordinate, testEndingCoordinate);

        // Assert
        Assert.AreEqual(testExpectedResult, testResult);
    }
    #endregion

    #region CalculateTrajectoryBasedOnCourseBehavior
    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnPlus1And0_WhenCourseIs1()
    {
        // Arrange
        var testCourse = 1.0d;
        var testExpectedTrajectory = new Trajectory(1, 0);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnPlus1AndPlus1_WhenCourseIs2()
    {
        // Arrange
        var testCourse = 2.0d;
        var testExpectedTrajectory = new Trajectory( 1, 1);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturn0AndPlus1_WhenCourseIs3()
    {
        // Arrange
        var testCourse = 3.0d;
        var testExpectedTrajectory = new Trajectory(0, 1);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnMinus1AndPlus1_WhenCourseIs4()
    {
        // Arrange
        var testCourse = 4.0d;
        var testExpectedTrajectory = new Trajectory(-1, 1);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnMinus1And0_WhenCourseIs5()
    {
        // Arrange
        var testCourse = 5.0d;
        var testExpectedTrajectory = new Trajectory(-1, 0);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnMinus1AndMinus1_WhenCourseIs6()
    {
        // Arrange
        var testCourse = 6.0d;
        var testExpectedTrajectory = new Trajectory(-1, -1);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturn0AndMinus1_WhenCourseIs7()
    {
        // Arrange
        var testCourse = 7.0d;
        var testExpectedTrajectory = new Trajectory(0, -1);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturn1AndMinus1_WhenCourseIs8()
    {
        // Arrange
        var testCourse = 8.0d;
        var testExpectedTrajectory = new Trajectory(1, -1);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturn0And0_WhenCourseIsLessThan1()
    {
        // Arrange
        var testCourse = 0.9d;
        var testExpectedTrajectory = new Trajectory(0, 0);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturn0And0_WhenCourseIs9()
    {
        // Arrange
        var testCourse = 9d;
        var testExpectedTrajectory = new Trajectory(0, 0);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturn0And0_WhenCourseIsGreaterThan9()
    {
        // Arrange
        var testCourse = 9.000001d;
        var testExpectedTrajectory = new Trajectory(0, 0);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnPlus1AndPlus0p5_WhenCourseIs1p5()
    {
        // Arrange
        var testCourse = 1.5d;
        var testExpectedTrajectory = new Trajectory(1, 0.5);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnPlus0p5AndPlus1_WhenCourseIs2p5()
    {
        // Arrange
        var testCourse = 2.5d;
        var testExpectedTrajectory = new Trajectory(0.5, 1);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnMinus0p5AndPlus1_WhenCourseIs3p5()
    {
        // Arrange
        var testCourse = 3.5d;
        var testExpectedTrajectory = new Trajectory(-0.5, 1);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnMinus1AndPlus0p5_WhenCourseIs4p5()
    {
        // Arrange
        var testCourse = 4.5d;
        var testExpectedTrajectory = new Trajectory(-1, 0.5);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnMinus1AndMinus0p5_WhenCourseIs5p5()
    {
        // Arrange
        var testCourse = 5.5d;
        var testExpectedTrajectory = new Trajectory(-1, -0.5);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnMinus0p5AndMinus1_WhenCourseIs6p5()
    {
        // Arrange
        var testCourse = 6.5d;
        var testExpectedTrajectory = new Trajectory(-0.5, -1);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnPlus0p5AndMinus1_WhenCourseIs7p5()
    {
        // Arrange
        var testCourse = 7.5d;
        var testExpectedTrajectory = new Trajectory(0.5, -1);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }

    [TestMethod]
    [TestCategory("CalculateTrajectoryBasedOnCourse")]
    public void CalculateTrajectoryBasedOnCourse_ShouldReturnPlus1AndMinus0p5_WhenCourseIs8p5()
    {
        // Arrange
        var testCourse = 8.5d;
        var testExpectedTrajectory = new Trajectory(1, -0.5);

        // Act
        var testResult = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);

        // Assert
        Assert.IsTrue(testResult.Matches(testExpectedTrajectory));
    }
    #endregion

    #region CalculateSectorPathBasedOnTrajectoryBehavior
    public static bool CoordinateListsAreEqual(List<Coordinate> expectedList, List<Coordinate> actualList)
    {
        var areListsSameLength = (expectedList.Count == actualList.Count);
        var areCoordinatesEqual = false;

        if (areListsSameLength)
        {
            areCoordinatesEqual = true;
            for (int i = 0; i < expectedList.Count; i++)
            {
                areCoordinatesEqual = areCoordinatesEqual && expectedList[i].Equals(actualList[i]);
            }
        }

        return (areListsSameLength && areCoordinatesEqual);
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse1()
    {
        // Arrange
        var testCourse = 1d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 4),
            new(6, 4),
            new(7, 4)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse2()
    {
        // Arrange
        var testCourse = 2d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 5),
            new(6, 6),
            new(7, 7)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse3()
    {
        // Arrange
        var testCourse = 3d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(4, 5),
            new(4, 6),
            new(4, 7)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse4()
    {
        // Arrange
        var testCourse = 4d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 5),
            new(2, 6),
            new(1, 7)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse5()
    {
        // Arrange
        var testCourse = 5d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 4),
            new(2, 4),
            new(1, 4),
            new(0, 4)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse6()
    {
        // Arrange
        var testCourse = 6d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 3),
            new(2, 2),
            new(1, 1),
            new(0, 0)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse7()
    {
        // Arrange
        var testCourse = 7d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(4, 3),
            new(4, 2),
            new(4, 1),
            new(4, 0)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse8()
    {
        // Arrange
        var testCourse = 8d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 3),
            new(6, 2),
            new(7, 1)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse1p5()
    {
        // Arrange
        var testCourse = 1.5d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 5),
            new(6, 5),
            new(7, 6)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse2p5()
    {
        // Arrange
        var testCourse = 2.5d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 5),
            new(5, 6),
            new(6, 7)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse3p5()
    {
        // Arrange
        var testCourse = 3.5d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(4, 5),
            new(3, 6),
            new(3, 7)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse4p5()
    {
        // Arrange
        var testCourse = 4.5d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 5),
            new(2, 5),
            new(1, 6),
            new(0, 6)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse5p5()
    {
        // Arrange
        var testCourse = 5.5d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 4),
            new(2, 3),
            new(1, 3),
            new(0, 2)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse6p5()
    {
        // Arrange
        var testCourse = 6.5d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(4, 3),
            new(3, 2),
            new(3, 1),
            new(2, 0)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse7p5()
    {
        // Arrange
        var testCourse = 7.5d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 3),
            new(5, 2),
            new(6, 1),
            new(6, 0)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse8p5()
    {
        // Arrange
        var testCourse = 8.5d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 4),
            new(6, 3),
            new(7, 3)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse1p25()
    {
        // Arrange
        var testCourse = 1.25d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 4),
            new(6, 5),
            new(7, 5)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse1p75()
    {
        // Arrange
        var testCourse = 1.75d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 5),
            new(6, 6),
            new(7, 6)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse2p25()
    {
        // Arrange
        var testCourse = 2.25d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 5),
            new(6, 6),
            new(6, 7)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse2p75()
    {
        // Arrange
        var testCourse = 2.75d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(4, 5),
            new(5, 6),
            new(5, 7)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse3p25()
    {
        // Arrange
        var testCourse = 3.25d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(4, 5),
            new(4, 6),
            new(3, 7)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse3p75()
    {
        // Arrange
        var testCourse = 3.75d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 5),
            new(3, 6),
            new(2, 7)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse4p25()
    {
        // Arrange
        var testCourse = 4.25d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 5),
            new(2, 6),
            new(1, 6),
            new(0, 7)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse4p75()
    {
        // Arrange
        var testCourse = 4.75d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 4),
            new(2, 5),
            new(1, 5),
            new(0, 5)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse5p25()
    {
        // Arrange
        var testCourse = 5.25d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 4),
            new(2, 4),
            new(1, 3),
            new(0, 3)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse5p75()
    {
        // Arrange
        var testCourse = 5.75d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 3),
            new(2, 3),
            new(1, 2),
            new(0, 1)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse6p25()
    {
        // Arrange
        var testCourse = 6.25d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(3, 3),
            new(3, 2),
            new(2, 1),
            new(1, 0)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse6p75()
    {
        // Arrange
        var testCourse = 6.75d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(4, 3),
            new(4, 2),
            new(3, 1),
            new(3, 0)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse7p25()
    {
        // Arrange
        var testCourse = 7.25d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(4, 3),
            new(5, 2),
            new(5, 1),
            new(5, 0)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn4Sectors_WhenAtSector4_4WithCourse7p75()
    {
        // Arrange
        var testCourse = 7.75d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 3),
            new(6, 2),
            new(6, 1),
            new(7, 0)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse8p25()
    {
        // Arrange
        var testCourse = 8.25d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 3),
            new(6, 3),
            new(7, 2)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }

    [TestMethod]
    [TestCategory("CalculateSectorPathBasedOnTrajectory")]
    public void CalculateSectorPathBasedOnTrajectory_ShouldReturn3Sectors_WhenAtSector4_4WithCourse8p75()
    {
        // Arrange
        var testCourse = 8.75d;
        var testTrajectory = ShipboardComputer.CalculateTrajectoryBasedOnCourse(testCourse);
        var testStartingCoordinate = new Coordinate(4, 4);

        var testExpectedResult = new List<Coordinate>
        {
            new(5, 4),
            new(6, 4),
            new(7, 3)
        };

        // Act
        var testResult = ShipboardComputer.CalculateSectorPathBasedOnTrajectory(testStartingCoordinate, testTrajectory);

        // Assert
        Assert.IsTrue(CoordinateListsAreEqual(testExpectedResult, testResult));
    }
    #endregion
}
