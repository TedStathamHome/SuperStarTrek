using GameObjects;

namespace GameTests;

[TestClass]
public sealed class SectorBehavior
{
    #region IsOccupiedBehavior
    [TestMethod]
    [TestCategory("IsOccupied")]
    public void IsOccupied_ShouldReturnTrue_WhenNotEmpty()
    {
        // Arrange
        var testSector = new Sector()
        {
            ObjectInSector = SectorObject.Star
        };

        // Act
        var testResult = testSector.IsOccupied;

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("IsOccupied")]
    public void IsOccupied_ShouldReturnFalse_WhenEmpty()
    {
        // Arrange
        var testSector = new Sector();

        // Act
        var testResult = testSector.IsOccupied;

        // Assert
        Assert.IsFalse(testResult);
    }
    #endregion

    #region IsEmptyBehavior
    [TestMethod]
    [TestCategory("IsEmpty")]
    public void IsEmpty_ShouldReturnTrue_WhenEmpty()
    {
        // Arrange
        var testSector = new Sector();

        // Act
        var testResult = testSector.IsEmpty;

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("IsEmpty")]
    public void IsEmpty_ShouldReturnFalse_WhenNotEmpty()
    {
        // Arrange
        var testSector = new Sector()
        {
            ObjectInSector = SectorObject.Star
        };

        // Act
        var testResult = testSector.IsEmpty;

        // Assert
        Assert.IsFalse(testResult);
    }
    #endregion
}
