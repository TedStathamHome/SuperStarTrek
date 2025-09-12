using GameObjects;

namespace GameTests;

[TestClass]
public sealed class ShipboardSystemBehavior
{
    #region IsDamagedBehavior
    [TestMethod]
    [TestCategory("IsDamaged")]
    public void IsDamaged_ShouldReturnFalse_WhenSystemIsNotDamaged()
    {
        // Arrange
        var testShipboardSystem = new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control");

        // Act
        var testResult = testShipboardSystem.IsDamaged;

        // Assert
        Assert.IsFalse(testResult);
    }

    [TestMethod]
    [TestCategory("IsDamaged")]
    public void IsDamaged_ShouldReturnTrue_WhenSystemIsDamaged()
    {
        // Arrange
        var testShipboardSystem = new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control");
        testShipboardSystem.DamageLevel += 5;

        // Act
        var testResult = testShipboardSystem.IsDamaged;

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region TakeDamageByStatedAmountBehavior
    [TestMethod]
    [TestCategory("TakeDamageByStatedAmount")]
    public void TakeDamageByStatedAmount_ShouldIncreaseDamageLevelByAmountStated_WhenPositiveAmount()
    {
        // Arrange
        var testShipboardSystem = new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control");
        var testInitialDamageLevel = testShipboardSystem.DamageLevel;

        // Act
        testShipboardSystem.TakeDamageByStatedAmount(1);
        var testResult = testShipboardSystem.DamageLevel > testInitialDamageLevel;

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("TakeDamageByStatedAmount")]
    public void TakeDamageByStatedAmount_ShouldNotIncreaseDamageLevelByAmountStated_WhenNegativeAmount()
    {
        // Arrange
        var testShipboardSystem = new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control");
        var testInitialDamageLevel = testShipboardSystem.DamageLevel;

        // Act
        testShipboardSystem.TakeDamageByStatedAmount(-1);
        var testResult = testShipboardSystem.DamageLevel == testInitialDamageLevel;

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region RepairDamageByStatedAmountBehavior
    [TestMethod]
    [TestCategory("RepairDamageByStatedAmount")]
    public void RepairDamageByStatedAmount_ShouldDecreaseDamageLevelByAmountStated_WhenPositiveAmount()
    {
        // Arrange
        var testShipboardSystem = new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control");
        testShipboardSystem.TakeDamageByStatedAmount(1.5);
        var testCurrentDamageLevel = testShipboardSystem.DamageLevel;

        // Act
        testShipboardSystem.RepairDamageByStatedAmount(1);
        var testResult = testShipboardSystem.DamageLevel < testCurrentDamageLevel;

        // Assert
        Assert.IsTrue(testResult);
    }

    [TestMethod]
    [TestCategory("RepairDamageByStatedAmount")]
    public void RepairDamageByStatedAmount_ShouldNotDecreaseDamageLevelByAmountStated_WhenNegativeAmount()
    {
        // Arrange
        var testShipboardSystem = new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control");
        testShipboardSystem.TakeDamageByStatedAmount(1.5);
        var testCurrentDamageLevel = testShipboardSystem.DamageLevel;

        // Act
        testShipboardSystem.RepairDamageByStatedAmount(-1);
        var testResult = testShipboardSystem.DamageLevel == testCurrentDamageLevel;

        // Assert
        Assert.IsTrue(testResult);
    }
    #endregion

    #region MakeRandomRepairsBehavior
    [TestMethod]
    [TestCategory("MakeRandomRepairs")]
    public void MakeRandomRepairs_ShouldDecreaseDamageLevelByAtLeast1AndLessThan4Points()
    {
        // Arrange
        var testShipboardSystem = new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control");
        testShipboardSystem.TakeDamageByStatedAmount(5);
        var testInitialDamageLevel = testShipboardSystem.DamageLevel;
        var testRepairsInRange = true;

        const double baseRepairsToMake = 1;
        const double extraRepairsToMake = 3;

        // Act

        // since the amount of damage repaired is random, 
        // but must fall within a set range, run the test
        // 100 times, which should cause a failure if the
        // range test is incorrect
        for (int i = 0; i < 100; i++)
        {
            testShipboardSystem.DamageLevel = testInitialDamageLevel;
            testShipboardSystem.MakeRandomRepairs();
            var testDamageRepaired = testInitialDamageLevel - testShipboardSystem.DamageLevel;
            testRepairsInRange = testRepairsInRange &&
                (testDamageRepaired >= baseRepairsToMake
                && testDamageRepaired < (baseRepairsToMake + extraRepairsToMake));

            if (!testRepairsInRange)
                break;
        }

        // Assert
        Assert.IsTrue(testRepairsInRange);
    }
    #endregion

    #region TakeRandomDamageBehavior
    [TestMethod]
    [TestCategory("TakeRandomDamage")]
    public void TakeRandomDamage_ShouldIncreaseDamageLevelByAtLeast1AndLessThan6Points()
    {
        // Arrange
        var testShipboardSystem = new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control");
        var testInitialDamageLevel = testShipboardSystem.DamageLevel;
        var testDamageInRange = true;

        const double baseDamageToTake = 1;
        const double extraDamageToTake = 5;

        // Act

        // since the amount of damage caused is random, 
        // but must fall within a set range, run the test
        // 100 times, which should cause a failure if the
        // range test is incorrect
        for (int i = 0; i < 100; i++)
        {
            testShipboardSystem.DamageLevel = testInitialDamageLevel;
            testShipboardSystem.TakeRandomDamage();
            var testDamageTaken = testShipboardSystem.DamageLevel - testInitialDamageLevel;
            testDamageInRange = testDamageInRange &&
                (testDamageTaken >= baseDamageToTake
                && testDamageTaken < (baseDamageToTake + extraDamageToTake));

            if (!testDamageInRange)
                break;
        }

        // Assert
        Assert.IsTrue(testDamageInRange);
    }
    #endregion

    #region AffectDamageLevelRandomlyBehavior
    [TestMethod]
    [TestCategory("AffectDamageLevelRandomly")]
    public void AffectDamageLevelRandomly_ShouldCauseChangeInDamageLevelOver100Iterations()
    {
        // Arrange
        var testShipboardSystem = new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control");
        var testWasDamageTaken = false;
        var testWereRepairsMade = false;

        const double testBaseDamageLevel = 4;

        // Act

        // since the chance of repairs or damage happening
        // is only 20%, and within that, damage happens
        // 60% of the time and repairs the other 40%, the
        // test is run 100 times to ensure both damage and
        // repairs happen at least once each
        for (int i = 0; i < 100; i++)
        {
            testShipboardSystem.DamageLevel = testBaseDamageLevel;
            testShipboardSystem.AffectDamageLevelRandomly();

            if (testShipboardSystem.DamageLevel != testBaseDamageLevel)
            {
                testWasDamageTaken = testWasDamageTaken || (testShipboardSystem.DamageLevel > testBaseDamageLevel);
                testWereRepairsMade = testWereRepairsMade || (testShipboardSystem.DamageLevel < testBaseDamageLevel);
            }
        }

        // Assert
        Assert.IsTrue(testWasDamageTaken && testWereRepairsMade);
    }

    [TestMethod]
    [TestCategory("AffectDamageLevelRandomly")]
    public void AffectDamageLevelRandomly_ShouldCauseNoDamageOrRepairsAtLeastOnceOver100Iterations()
    {
        // Arrange
        var testShipboardSystem = new ShipboardSystem(ShipboardSystemType.DamageControl, "Damage Control");
        var testCountOfNoChangeInDamageLevel = 0;

        const double testBaseDamageLevel = 4;

        // Act

        // since the chance of repairs or damage happening
        // is only 20%, count the number of times no damage
        // is assigned or repairs made over 100 iterations
        for (int i = 0; i < 100; i++)
        {
            testShipboardSystem.DamageLevel = testBaseDamageLevel;
            testShipboardSystem.AffectDamageLevelRandomly();

            if (testShipboardSystem.DamageLevel == testBaseDamageLevel)
            {
                testCountOfNoChangeInDamageLevel++;
            }
        }

        // Assert
        Assert.IsTrue(testCountOfNoChangeInDamageLevel > 0);
    }
    #endregion
}
