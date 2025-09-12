using GameObjects;

namespace GameTests;

[TestClass]
public sealed class QuadrantBehavior
{
    #region ScannerReadingBehavior
    [TestMethod]
    [TestCategory("ScannerReading")]
    public void ScannerReading_ShouldReturnEmptyQuadrant_WhenNotPreviouslyScanned()
    {
        // Arrange
        var testQuadrant = new Quadrant();

        // Act
        var testResult = testQuadrant.ScannerReading;

        // Assert
        Assert.AreEqual("•••", testResult);
    }

    [TestMethod]
    [TestCategory("ScannerReading")]
    public void ScannerReading_ShouldReturn000_WhenEmptyAndPreviouslyScanned()
    {
        // Arrange
        var testQuadrant = new Quadrant
        {
            IsScanned = true
        };

        // Act
        var testResult = testQuadrant.ScannerReading;

        // Assert
        Assert.AreEqual("000", testResult);
    }

    [TestMethod]
    [TestCategory("ScannerReading")]
    public void ScannerReading_ShouldReturn111_WhenContainsOneOfEachObjectAndPreviouslyScanned()
    {
        // Arrange
        var testQuadrant = new Quadrant
        {
            IsScanned = true
        };

        testQuadrant.Sectors[0, 0].ObjectInSector = SectorObject.KlingonBattleCruiser;
        testQuadrant.Sectors[0, 1].ObjectInSector = SectorObject.FederationStarbase;
        testQuadrant.Sectors[0, 2].ObjectInSector = SectorObject.Star;
        testQuadrant.Sectors[0, 3].ObjectInSector = SectorObject.FederationStarship;

        // Act
        var testResult = testQuadrant.ScannerReading;

        // Assert
        Assert.AreEqual("111", testResult);
    }

    [TestMethod]
    [TestCategory("ScannerReading")]
    public void ScannerReading_ShouldReturn863_WhenContains8Klingons6Starbases3StarsAndPreviouslyScanned()
    {
        // Arrange
        var testQuadrant = new Quadrant
        {
            IsScanned = true
        };

        for (int i = 0; i < 8; i++)
        {
            testQuadrant.Sectors[0, i].ObjectInSector = SectorObject.KlingonBattleCruiser;
        }

        for (int i = 0; i < 6; i++)
        {
            testQuadrant.Sectors[1, i].ObjectInSector = SectorObject.FederationStarbase;
        }

        for (int i = 0; i < 3; i++)
        {
            testQuadrant.Sectors[2, i].ObjectInSector = SectorObject.Star;
        }

        testQuadrant.Sectors[3, 0].ObjectInSector = SectorObject.FederationStarship;

        // Act
        var testResult = testQuadrant.ScannerReading;

        // Assert
        Assert.AreEqual("863", testResult);
    }
    #endregion
}
