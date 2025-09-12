using GameObjects;

namespace GameTests;

[TestClass]
public sealed class FederationStarshipBehavior
{
    #region IsDockedBehavior
    [TestMethod]
    [TestCategory("IsDocked")]
    public void IsDocked_ShouldReturnFalse_WhenNoStarbaseInQuadrant()
    {
        // Arrange
        var testGalaxy = new Galaxy();
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));

        testGalaxy.Quadrants[0, 0].Sectors[0, 0].ObjectInSector = SectorObject.FederationStarship;

        // Act
        var testResult = testFederationStarship.IsDocked(testGalaxy);

        // Assert
        Assert.IsFalse(testResult);
    }

    [TestMethod]
    [TestCategory("IsDocked")]
    public void IsDocked_ShouldReturnFalse_WhenStarbaseInQuadrantButNotNextToEnterprise()
    {
        // Arrange
        var testGalaxy = new Galaxy();
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));

        testGalaxy.Quadrants[0, 0].Sectors[0, 0].ObjectInSector = SectorObject.FederationStarship;
        testGalaxy.Quadrants[0, 0].Sectors[7, 7].ObjectInSector = SectorObject.FederationStarbase;

        // Act
        var testResult = testFederationStarship.IsDocked(testGalaxy);

        // Assert
        Assert.IsFalse(testResult);
    }

    [TestMethod]
    [TestCategory("IsDocked")]
    public void IsDocked_ShouldReturnTrue_WhenEnterpriseAtx0y0AndStarbaseAtx1y1()
    {
        // Arrange
        var testGalaxy = new Galaxy();
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));

        testGalaxy.Quadrants[0, 0].Sectors[0, 0].ObjectInSector = SectorObject.FederationStarship;
        testGalaxy.Quadrants[0, 0].Sectors[1, 1].ObjectInSector = SectorObject.FederationStarbase;

        // Act
        var testResult = testFederationStarship.IsDocked(testGalaxy);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("IsDocked")]
    public void IsDocked_ShouldReturnTrue_WhenEnterpriseAtx7y0AndStarbaseAtx6y1()
    {
        // Arrange
        var testGalaxy = new Galaxy();
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(7, 0));

        testGalaxy.Quadrants[0, 0].Sectors[7, 0].ObjectInSector = SectorObject.FederationStarship;
        testGalaxy.Quadrants[0, 0].Sectors[6, 1].ObjectInSector = SectorObject.FederationStarbase;

        // Act
        var testResult = testFederationStarship.IsDocked(testGalaxy);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("IsDocked")]
    public void IsDocked_ShouldReturnTrue_WhenEnterpriseAtx7y7AndStarbaseAtx6y6()
    {
        // Arrange
        var testGalaxy = new Galaxy();
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(7, 7));

        testGalaxy.Quadrants[0, 0].Sectors[7, 7].ObjectInSector = SectorObject.FederationStarship;
        testGalaxy.Quadrants[0, 0].Sectors[6, 6].ObjectInSector = SectorObject.FederationStarbase;

        // Act
        var testResult = testFederationStarship.IsDocked(testGalaxy);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("IsDocked")]
    public void IsDocked_ShouldReturnTrue_WhenEnterpriseAtx0y7AndStarbaseAtx1y6()
    {
        // Arrange
        var testGalaxy = new Galaxy();
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 7));

        testGalaxy.Quadrants[0, 0].Sectors[0, 7].ObjectInSector = SectorObject.FederationStarship;
        testGalaxy.Quadrants[0, 0].Sectors[1, 6].ObjectInSector = SectorObject.FederationStarbase;

        // Act
        var testResult = testFederationStarship.IsDocked(testGalaxy);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("IsDocked")]
    public void IsDocked_ShouldReturnTrue_WhenEnterpriseAtx1y1AndStarbaseAtx0y0()
    {
        // Arrange
        var testGalaxy = new Galaxy();
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(1, 1));

        testGalaxy.Quadrants[0, 0].Sectors[1, 1].ObjectInSector = SectorObject.FederationStarship;
        testGalaxy.Quadrants[0, 0].Sectors[0, 0].ObjectInSector = SectorObject.FederationStarbase;

        // Act
        var testResult = testFederationStarship.IsDocked(testGalaxy);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("IsDocked")]
    public void IsDocked_ShouldReturnTrue_WhenEnterpriseAtx6y1AndStarbaseAtx7y0()
    {
        // Arrange
        var testGalaxy = new Galaxy();
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(6, 1));

        testGalaxy.Quadrants[0, 0].Sectors[6, 1].ObjectInSector = SectorObject.FederationStarship;
        testGalaxy.Quadrants[0, 0].Sectors[7, 0].ObjectInSector = SectorObject.FederationStarbase;

        // Act
        var testResult = testFederationStarship.IsDocked(testGalaxy);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("IsDocked")]
    public void IsDocked_ShouldReturnTrue_WhenEnterpriseAtx6y6AndStarbaseAtx7y7()
    {
        // Arrange
        var testGalaxy = new Galaxy();
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(6, 6));

        testGalaxy.Quadrants[0, 0].Sectors[6, 6].ObjectInSector = SectorObject.FederationStarship;
        testGalaxy.Quadrants[0, 0].Sectors[7, 7].ObjectInSector = SectorObject.FederationStarbase;

        // Act
        var testResult = testFederationStarship.IsDocked(testGalaxy);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("IsDocked")]
    public void IsDocked_ShouldReturnTrue_WhenEnterpriseAtx1y6AndStarbaseAtx0y7()
    {
        // Arrange
        var testGalaxy = new Galaxy();
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(1, 6));

        testGalaxy.Quadrants[0, 0].Sectors[1, 6].ObjectInSector = SectorObject.FederationStarship;
        testGalaxy.Quadrants[0, 0].Sectors[0, 7].ObjectInSector = SectorObject.FederationStarbase;

        // Act
        var testResult = testFederationStarship.IsDocked(testGalaxy);

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region HasSufficientEnergyToAdjustShieldsBehavior
    [TestMethod]
    [TestCategory("HasSufficientEnergyToAdjustShields")]
    public void HasSufficientEnergyToAdjustShields_ShouldReturnTrue_WhenShieldsAreNotRaisedAndAllEnergyIsToBeUsed()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));

        // Act
        var testResult = testFederationStarship.HasSufficientEnergyToAdjustShields(testFederationStarship.EnergyReserves);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("HasSufficientEnergyToAdjustShields")]
    public void HasSufficientEnergyToAdjustShields_ShouldReturnTrue_WhenShieldsAreRaisedAndAllEnergyIsToBeUsed()
    {
        // Arrange
        const int testInitialShieldEnergyToSet = 300;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testInitialEnergyReserves = testFederationStarship.EnergyReserves;
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);

        // Act
        var testResult = testFederationStarship.HasSufficientEnergyToAdjustShields(testInitialEnergyReserves);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("HasSufficientEnergyToAdjustShields")]
    public void HasSufficientEnergyToAdjustShields_ShouldReturnFalse_WhenMoreEnergyThanInReservesIsToBeUsed()
    {
        // Arrange
        const int testInitialEnergyReservesToSet = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0))
        {
            EnergyReserves = testInitialEnergyReservesToSet
        };

        // Act
        var testResult = testFederationStarship.HasSufficientEnergyToAdjustShields(testInitialEnergyReservesToSet + 1);

        // Assert
        Assert.IsFalse(testResult);
    }

    [TestMethod]
    [TestCategory("HasSufficientEnergyToAdjustShields")]
    public void HasSufficientEnergyToAdjustShields_ShouldReturnTrue_WhenShieldsAlreadyRaisedAndReservesAreSufficient()
    {
        // Arrange
        const int testInitialShieldEnergyToSet = 300;
        const int testInitialEnergyReservesToSet = 100;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);
        testFederationStarship.EnergyReserves = testInitialEnergyReservesToSet;

        // Act
        var testResult = testFederationStarship.HasSufficientEnergyToAdjustShields(testInitialEnergyReservesToSet + testInitialShieldEnergyToSet);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("HasSufficientEnergyToAdjustShields")]
    public void HasSufficientEnergyToAdjustShields_ShouldReturnFalse_WhenShieldsAlreadyRaisedAndReservesAreInsufficient()
    {
        // Arrange
        const int testInitialShieldEnergyToSet = 300;
        const int testInitialEnergyReservesToSet = 100;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);
        testFederationStarship.EnergyReserves = testInitialEnergyReservesToSet;

        // Act
        var testResult = testFederationStarship.HasSufficientEnergyToAdjustShields(testInitialEnergyReservesToSet + testInitialShieldEnergyToSet + 1);

        // Assert
        Assert.IsFalse(testResult);
    }
    #endregion

    #region AdjustShieldEnergyBehavior
    [TestMethod]
    [TestCategory("AdjustShieldEnergy")]
    public void AdjustShieldEnergy_ShouldCauseNoChangeInShieldEnergyLevel_WhenPassedANegative()
    {
        // Arrange
        const int testInitialShieldEnergyToSet = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);

        // Act
        testFederationStarship.AdjustShieldEnergy(-1);
        var testResult = testFederationStarship.ShieldEnergy == testInitialShieldEnergyToSet;

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("AdjustShieldEnergy")]
    public void AdjustShieldEnergy_ShouldCauseNoChangeInShieldEnergyLevel_WhenPassedCurrentShieldEnergy()
    {
        // Arrange
        const int testInitialShieldEnergyToSet = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);

        // Act
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);
        var testResult = testFederationStarship.ShieldEnergy == testInitialShieldEnergyToSet;

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("AdjustShieldEnergy")]
    public void AdjustShieldEnergy_ShouldCauseNoChangeInShieldEnergyLevel_WhenShieldControlDamagedAndPassedNonZeroEnergyLevel()
    {
        // Arrange
        const int testInitialShieldEnergyToSet = 200;
        const int testFinalShieldEnergyToSet = 100;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);
        testFederationStarship.DamageShipboardSystemByStatedAmount(ShipboardSystemType.ShieldControl, 1);

        // Act
        testFederationStarship.AdjustShieldEnergy(testFinalShieldEnergyToSet);
        var testResult = testFederationStarship.ShieldEnergy == testInitialShieldEnergyToSet;

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("AdjustShieldEnergy")]
    public void AdjustShieldEnergy_ShouldCauseNoChangeInShieldEnergyLevel_WhenRequestedLevelExceedsReservesPlusCurrentShields()
    {
        // Arrange
        const int testInitialShieldEnergyToSet = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testMaximumEnergyLevel = testFederationStarship.EnergyReserves;
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);

        // Act
        testFederationStarship.AdjustShieldEnergy(testMaximumEnergyLevel + 1);
        var testResult = testFederationStarship.ShieldEnergy == testInitialShieldEnergyToSet;

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region DropShieldsBehavior
    [TestMethod]
    [TestCategory("DropShields")]
    public void DropShields_ShouldCauseShieldEnergyLevelToDropToZero()
    {
        // Arrange
        const int testInitialShieldEnergyToSet = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);
        var testEnergyReservesRemaining = testFederationStarship.EnergyReserves;

        // Act
        testFederationStarship.DropShields();
        var testResult = (testFederationStarship.ShieldEnergy == 0)
            && (testFederationStarship.EnergyReserves == testEnergyReservesRemaining + testInitialShieldEnergyToSet);

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region ConsumeEnergyReservesBehavior
    [TestMethod]
    [TestCategory("ConsumeEnergyReserves")]
    public void ConsumeEnergyReserves_ShouldCauseNoChangeInEnergyReserves_WhenGivenNegativeAmount()
    {
        // Arrange
        const int testEnergyReservesToConsume = -3;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testInitialEnergyReserves = testFederationStarship.EnergyReserves;

        // Act
        testFederationStarship.ConsumeEnergyReserves(testEnergyReservesToConsume);
        var testResult = testFederationStarship.EnergyReserves == testInitialEnergyReserves;

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("ConsumeEnergyReserves")]
    public void ConsumeEnergyReserves_ShouldCauseNoChangeInEnergyReserves_WhenLimitExceeded()
    {
        // Arrange
        const int testShieldEnergyToSet = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testInitialEnergyReserves = testFederationStarship.EnergyReserves;
        testFederationStarship.AdjustShieldEnergy(testShieldEnergyToSet);
        var testRemainingEnergyReserves = testFederationStarship.EnergyReserves;

        // Act
        testFederationStarship.ConsumeEnergyReserves(testInitialEnergyReserves + 1);
        var testResult = testFederationStarship.EnergyReserves == testRemainingEnergyReserves;

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("ConsumeEnergyReserves")]
    public void ConsumeEnergyReserves_ShouldBorrowShieldEnergy_WhenInsufficientReserves()
    {
        // Arrange
        const int testShieldEnergyToSet = 200;
        const int testShieldEnergyToBorrow = 100;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        testFederationStarship.AdjustShieldEnergy(testShieldEnergyToSet);
        var testRemainingEnergyReserves = testFederationStarship.EnergyReserves;

        // Act
        testFederationStarship.ConsumeEnergyReserves(testRemainingEnergyReserves + testShieldEnergyToBorrow);
        var testResult = (testFederationStarship.EnergyReserves == 0)
            && (testFederationStarship.ShieldEnergy == testShieldEnergyToSet - testShieldEnergyToBorrow);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("ConsumeEnergyReserves")]
    public void ConsumeEnergyReserves_ShouldNotBorrowShieldEnergy_WhenSufficientReserves()
    {
        // Arrange
        const int testShieldEnergyToSet = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        testFederationStarship.AdjustShieldEnergy(testShieldEnergyToSet);
        var testRemainingEnergyReserves = testFederationStarship.EnergyReserves;

        // Act
        testFederationStarship.ConsumeEnergyReserves(testRemainingEnergyReserves);
        var testResult = (testFederationStarship.EnergyReserves == 0)
            && (testFederationStarship.ShieldEnergy == testShieldEnergyToSet);

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region ReplenishEnergyReservesBehavior
    [TestMethod]
    [TestCategory("ReplenishEnergyReserves")]
    public void ReplenishEnergyReserves_ShouldSetEnergyReservesToMaximum()
    {
        // Arrange
        const int testEnergyReservesToConsume = 300;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testInitialEnergyReserves = testFederationStarship.EnergyReserves;
        testFederationStarship.ConsumeEnergyReserves(testEnergyReservesToConsume);

        // Act
        testFederationStarship.ReplenishEnergyReserves();
        var testResult = testFederationStarship.EnergyReserves == testInitialEnergyReserves;

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region ReplenishPhotonTorpedoesBehavior
    [TestMethod]
    [TestCategory("ReplenishPhotonTorpedoes")]
    public void ReplenishPhotonTorpedoes_ShouldSetPhotonTorpedoesRemainingToMaximum()
    {
        // Arrange
        const int testPhotonTorpedoesToRemove = 3;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testInitialPhotonTorpedoesRemaining = testFederationStarship.PhotonTorpedoesRemaining;
        testFederationStarship.PhotonTorpedoesRemaining -= testPhotonTorpedoesToRemove;

        // Act
        testFederationStarship.ReplenishPhotonTorpedoes();
        var testResult = testFederationStarship.PhotonTorpedoesRemaining == testInitialPhotonTorpedoesRemaining;

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region PickRandomShipboardSystemBehavior
    [TestMethod]
    [TestCategory("PickRandomShipboardSystem")]
    public void PickRandomShipboardSystem_ShouldReturnAShipboardSystemType()
    {
        // Arrange
        var testRandomShipboardSystemType = FederationStarship.PickRandomShipboardSystem();

        // Act
        var testResult = testRandomShipboardSystemType.ToString().Length > 0;

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region DamageShipboardSystemByStatedAmountBehavior
    [TestMethod]
    [TestCategory("DamageShipboardSystemByStatedAmount")]
    public void DamageShipboardSystemByStatedAmount_ShouldIncreaseDamageByStatedPositiveAmountToStatedShipboardSystem()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testShipboardSystem = testFederationStarship.ShipboardSystems.First(x => x.ShipboardSystemType.Equals(ShipboardSystemType.DamageControl));
        var testOriginalDamageLevel = testShipboardSystem.DamageLevel;

        // Act
        testFederationStarship.DamageShipboardSystemByStatedAmount(ShipboardSystemType.DamageControl, 3);
        var testResult = testShipboardSystem.DamageLevel > testOriginalDamageLevel;

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("DamageShipboardSystemByStatedAmount")]
    public void DamageShipboardSystemByStatedAmount_ShouldCauseNoChangeByStatedNegativeAmountToStatedShipboardSystem()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testShipboardSystem = testFederationStarship.ShipboardSystems.First(x => x.ShipboardSystemType.Equals(ShipboardSystemType.DamageControl));
        var testOriginalDamageLevel = testShipboardSystem.DamageLevel;

        // Act
        testFederationStarship.DamageShipboardSystemByStatedAmount(ShipboardSystemType.DamageControl, -3);
        var testResult = testShipboardSystem.DamageLevel == testOriginalDamageLevel;

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region IsShieldEnergyDangerouslyLowBehavior
    [TestMethod]
    [TestCategory("IsShieldEnergyDangerouslyLow")]
    public void IsShieldEnergyDangerouslyLow_ShouldReturnTrue_WhenShieldEnergyLessThanOrEqualTo200()
    {
        // Arrange
        const int testInitialShieldEnergyToSet = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);

        // Act
        var testResult = testFederationStarship.IsShieldEnergyDangerouslyLow();

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("IsShieldEnergyDangerouslyLow")]
    public void IsShieldEnergyDangerouslyLow_ShouldReturnFalse_WhenShieldEnergyGreaterThan200()
    {
        // Arrange
        const int testInitialShieldEnergyToSet = 201;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        testFederationStarship.AdjustShieldEnergy(testInitialShieldEnergyToSet);

        // Act
        var testResult = testFederationStarship.IsShieldEnergyDangerouslyLow();

        // Assert
        Assert.IsFalse(testResult);
    }
    #endregion

    #region AreActiveKlingonBattleCruisersInQuadrantBehavior
    [TestMethod]
    [TestCategory("AreActiveKlingonBattleCruisersInQuadrant")]
    public void AreActiveKlingonBattleCruisersInQuadrant_ShouldReturnFalse_WhenNoKlingonBattleCruisersInQuadrant()
    {
        // Arrange
        const int testStartingEnergyLevel = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>
        {
            new(new Coordinate(0, 1), new Coordinate(0, 0), testStartingEnergyLevel)
        };

        // Act
        var testResult = testFederationStarship.ActiveKlingonBattleCruisersAreInQuadrant(testKlingonBattleCruisers);

        // Assert
        Assert.IsFalse(testResult);
    }

    [TestMethod]
    [TestCategory("AreActiveKlingonBattleCruisersInQuadrant")]
    public void AreActiveKlingonBattleCruisersInQuadrant_ShouldReturnFalse_WhenNoActiveKlingonBattleCruisersInQuadrant()
    {
        // Arrange
        const int testStartingEnergyLevel = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>
        {
            new(new Coordinate(0, 0), new Coordinate(0, 1), testStartingEnergyLevel) { IsActive = false },
            new(new Coordinate(0, 1), new Coordinate(0, 0), testStartingEnergyLevel)
        };

        // Act
        var testResult = testFederationStarship.ActiveKlingonBattleCruisersAreInQuadrant(testKlingonBattleCruisers);

        // Assert
        Assert.IsFalse(testResult);
    }

    [TestMethod]
    [TestCategory("AreActiveKlingonBattleCruisersInQuadrant")]
    public void AreActiveKlingonBattleCruisersInQuadrant_ShouldReturnTrue_When1ActiveKlingonBattleCruiserInQuadrant()
    {
        // Arrange
        const int testStartingEnergyLevel = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>
        {
            new(new Coordinate(0, 0), new Coordinate(0, 1), testStartingEnergyLevel),
            new(new Coordinate(0, 1), new Coordinate(0, 0), testStartingEnergyLevel)
        };

        // Act
        var testResult = testFederationStarship.ActiveKlingonBattleCruisersAreInQuadrant(testKlingonBattleCruisers);

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("AreActiveKlingonBattleCruisersInQuadrant")]
    public void AreActiveKlingonBattleCruisersInQuadrant_ShouldReturnTrue_WhenAtLeast1ActiveKlingonBattleCruiserInQuadrant()
    {
        // Arrange
        const int testStartingEnergyLevel = 200;

        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(0, 0));
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>
        {
            new(new Coordinate(0, 0), new Coordinate(0, 1), testStartingEnergyLevel) { IsActive = false },
            new(new Coordinate(0, 0), new Coordinate(0, 2), testStartingEnergyLevel),
            new(new Coordinate(0, 1), new Coordinate(0, 0), testStartingEnergyLevel)
        };

        // Act
        var testResult = testFederationStarship.ActiveKlingonBattleCruisersAreInQuadrant(testKlingonBattleCruisers);

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region FirePhotonTorpedoBehavior
    [TestMethod]
    [TestCategory("FirePhotonTorpedo")]
    public void FirePhotonTorpedo_ShouldReturnPhotonTorpedoFiringOutcome_NoPhotonTorpedoes_WhenNoTorpedoesAvailable()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(4, 4));
        var testCourse = 1d;
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>();
        var testFederationStarbases = new List<FederationStarbase>();
        var testStars = new List<Star>();
        testFederationStarship.PhotonTorpedoesRemaining = 0;

        // Act
        var testResult = testFederationStarship.FirePhotonTorpedo(testCourse, testKlingonBattleCruisers, testFederationStarbases, testStars);

        // Assert
        Assert.AreEqual(PhotonTorpedoFiringOutcome.NoPhotonTorpedoes, testResult.Outcome);
        Assert.IsTrue(testResult.Course.Count == 0);
        Assert.IsNull(testResult.ImpactCoordinate);
    }

    [TestMethod]
    [TestCategory("FirePhotonTorpedo")]
    public void FirePhotonTorpedo_ShouldReturnPhotonTorpedoFiringOutcome_PhotonTorpedoTubesAreDamaged_WhenPhotonTorpedoTubesAreDamaged()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(4, 4));
        var testCourse = 1d;
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>();
        var testFederationStarbases = new List<FederationStarbase>();
        var testStars = new List<Star>();
        testFederationStarship.DamageShipboardSystemByStatedAmount(ShipboardSystemType.PhotonTorpedoTubes, 1);

        // Act
        var testResult = testFederationStarship.FirePhotonTorpedo(testCourse, testKlingonBattleCruisers, testFederationStarbases, testStars);

        // Assert
        Assert.AreEqual(PhotonTorpedoFiringOutcome.PhotonTorpedoTubesAreDamaged, testResult.Outcome);
        Assert.IsTrue(testResult.Course.Count == 0);
        Assert.IsNull(testResult.ImpactCoordinate);
    }

    [TestMethod]
    [TestCategory("FirePhotonTorpedo")]
    public void FirePhotonTorpedo_ShouldReturnPhotonTorpedoFiringOutcome_InsufficientEnergyReserves_When1EnergyUnitLeft()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(4, 4));
        var testCourse = 1d;
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>();
        var testFederationStarbases = new List<FederationStarbase>();
        var testStars = new List<Star>();
        testFederationStarship.ConsumeEnergyReserves(testFederationStarship.EnergyReserves - 1);

        // Act
        var testResult = testFederationStarship.FirePhotonTorpedo(testCourse, testKlingonBattleCruisers, testFederationStarbases, testStars);

        // Assert
        Assert.AreEqual(PhotonTorpedoFiringOutcome.InsufficientEnergyReserves, testResult.Outcome);
        Assert.IsTrue(testResult.Course.Count == 0);
        Assert.IsNull(testResult.ImpactCoordinate);
    }

    [TestMethod]
    [TestCategory("FirePhotonTorpedo")]
    public void FirePhotonTorpedo_ShouldReturnPhotonTorpedoFiringOutcome_HitNothing_WhenQuadrantIsEmpty()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(4, 4));
        var testCourse = 1d;
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>();
        var testFederationStarbases = new List<FederationStarbase>();
        var testStars = new List<Star>();

        // Act
        var testResult = testFederationStarship.FirePhotonTorpedo(testCourse, testKlingonBattleCruisers, testFederationStarbases, testStars);

        // Assert
        Assert.AreEqual(PhotonTorpedoFiringOutcome.HitNothing, testResult.Outcome);
        Assert.IsTrue(testResult.Course.Count > 0);
        Assert.IsNull(testResult.ImpactCoordinate);
    }

    [TestMethod]
    [TestCategory("FirePhotonTorpedo")]
    public void FirePhotonTorpedo_ShouldReturnPhotonTorpedoFiringOutcome_HitNothing_WhenQuadrantIsNotEmptyAndNothingOnCourse()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(4, 4));
        var testCourse = 1d;
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>();
        var testFederationStarbases = new List<FederationStarbase>();
        var testStars = new List<Star>
        {
            new(testFederationStarship.QuadrantCoordinate, new Coordinate(5, 3))
        };
        testFederationStarbases.Add(new FederationStarbase(testFederationStarship.QuadrantCoordinate, new Coordinate(5, 2)));
        testKlingonBattleCruisers.Add(new KlingonBattleCruiser(testFederationStarship.QuadrantCoordinate, new Coordinate(5, 1), 200));

        // Act
        var testResult = testFederationStarship.FirePhotonTorpedo(testCourse, testKlingonBattleCruisers, testFederationStarbases, testStars);

        // Assert
        Assert.AreEqual(PhotonTorpedoFiringOutcome.HitNothing, testResult.Outcome);
        Assert.IsTrue(testResult.Course.Count > 0);
        Assert.IsNull(testResult.ImpactCoordinate);
    }

    [TestMethod]
    [TestCategory("FirePhotonTorpedo")]
    public void FirePhotonTorpedo_ShouldReturnPhotonTorpedoFiringOutcome_HitNothing_WhenEnterpriseIsAtEdgeOfQuadrantAndFiringTowardsSameEdge()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(7, 4));
        var testCourse = 1d;
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>();
        var testFederationStarbases = new List<FederationStarbase>();
        var testStars = new List<Star>();

        // Act
        var testResult = testFederationStarship.FirePhotonTorpedo(testCourse, testKlingonBattleCruisers, testFederationStarbases, testStars);

        // Assert
        Assert.AreEqual(PhotonTorpedoFiringOutcome.HitNothing, testResult.Outcome);
        Assert.IsTrue(testResult.Course.Count == 0);
        Assert.IsNull(testResult.ImpactCoordinate);
    }

    [TestMethod]
    [TestCategory("FirePhotonTorpedo")]
    public void FirePhotonTorpedo_ShouldReturnPhotonTorpedoFiringOutcome_AbsorbedByStar_WhenStarIsOnCourse()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(4, 4));
        var testCourse = 1d;
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>();
        var testFederationStarbases = new List<FederationStarbase>();
        var testStars = new List<Star>
        {
            new(testFederationStarship.QuadrantCoordinate, new Coordinate(5, 4))
        };

        // Act
        var testResult = testFederationStarship.FirePhotonTorpedo(testCourse, testKlingonBattleCruisers, testFederationStarbases, testStars);

        // Assert
        Assert.AreEqual(PhotonTorpedoFiringOutcome.AbsorbedByStar, testResult.Outcome);
        Assert.IsTrue(testResult.Course.Count > 0);
        Assert.IsNotNull(testResult.ImpactCoordinate);
    }

    [TestMethod]
    [TestCategory("FirePhotonTorpedo")]
    public void FirePhotonTorpedo_ShouldReturnPhotonTorpedoFiringOutcome_DestroyedFederationStarbase_WhenFederationStarbaseIsOnCourse()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(4, 4));
        var testCourse = 1d;
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>();
        var testFederationStarbases = new List<FederationStarbase>();
        var testStars = new List<Star>();
        testFederationStarbases.Add(new FederationStarbase(testFederationStarship.QuadrantCoordinate, new Coordinate(5, 4)));

        // Act
        var testResult = testFederationStarship.FirePhotonTorpedo(testCourse, testKlingonBattleCruisers, testFederationStarbases, testStars);

        // Assert
        Assert.AreEqual(PhotonTorpedoFiringOutcome.DestroyedFederationStarbase, testResult.Outcome);
        Assert.IsTrue(testResult.Course.Count > 0);
        Assert.IsNotNull(testResult.ImpactCoordinate);
    }

    [TestMethod]
    [TestCategory("FirePhotonTorpedo")]
    public void FirePhotonTorpedo_ShouldReturnPhotonTorpedoFiringOutcome_DestroyedKlingonBattleCruiser_WhenKlingonBattleCruiserIsOnCourse()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(4, 4));
        var testCourse = 1d;
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>();
        var testFederationStarbases = new List<FederationStarbase>();
        var testStars = new List<Star>();
        testKlingonBattleCruisers.Add(new KlingonBattleCruiser(testFederationStarship.QuadrantCoordinate, new Coordinate(5, 4), 200));

        // Act
        var testResult = testFederationStarship.FirePhotonTorpedo(testCourse, testKlingonBattleCruisers, testFederationStarbases, testStars);

        // Assert
        Assert.AreEqual(PhotonTorpedoFiringOutcome.DestroyedKlingonBattleCruiser, testResult.Outcome);
        Assert.IsTrue(testResult.Course.Count > 0);
        Assert.IsNotNull(testResult.ImpactCoordinate);
    }

    [TestMethod]
    [TestCategory("FirePhotonTorpedo")]
    public void FirePhotonTorpedo_ShouldReturnPhotonTorpedoFiringOutcome_DestroyedKlingonBattleCruiser_WhenKlingonBattleCruiserAndStarbaseAreOnCourse()
    {
        // Arrange
        var testFederationStarship = new FederationStarship(new Coordinate(0, 0), new Coordinate(4, 4));
        var testCourse = 1d;
        var testKlingonBattleCruisers = new List<KlingonBattleCruiser>();
        var testFederationStarbases = new List<FederationStarbase>();
        var testStars = new List<Star>();
        testKlingonBattleCruisers.Add(new KlingonBattleCruiser(testFederationStarship.QuadrantCoordinate, new Coordinate(5, 4), 200));
        testFederationStarbases.Add(new FederationStarbase(testFederationStarship.QuadrantCoordinate, new Coordinate(6, 4)));

        // Act
        var testResult = testFederationStarship.FirePhotonTorpedo(testCourse, testKlingonBattleCruisers, testFederationStarbases, testStars);

        // Assert
        Assert.AreEqual(PhotonTorpedoFiringOutcome.DestroyedKlingonBattleCruiser, testResult.Outcome);
        Assert.IsTrue(testResult.Course.Count > 0);
        Assert.IsNotNull(testResult.ImpactCoordinate);
    }
    #endregion
}
