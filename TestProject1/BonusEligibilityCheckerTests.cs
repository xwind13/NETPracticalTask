using Refactoring.Models;
using Xunit;

namespace Refactoring.Tests;

public class BonusEligibilityCheckerTests
{
    [Fact]
    public void IsEligibleForBonus_NewReleaseForOneDay_ReturnsTrue()
    {
        var rental = new Rental(new Movie("MovieTitle", PriceCode.NewRelease), 1);
        var checker = new BonusEligibilityChecker();
        var result = checker.IsEligibleForBonus(rental);
        Assert.True(result);
    }

    [Fact]
    public void IsEligibleForBonus_RegularForMoreThanAWeek_ReturnsTrue()
    {
        var rental = new Rental(new Movie("MovieTitle", PriceCode.Regular), 8);
        var checker = new BonusEligibilityChecker();
        var result = checker.IsEligibleForBonus(rental);
        Assert.True(result);
    }

    [Fact]
    public void IsEligibleForBonus_RegularForLessThanAWeek_ReturnsFalse()
    {
        var rental = new Rental(new Movie("MovieTitle", PriceCode.Regular), 5);
        var checker = new BonusEligibilityChecker();
        var result = checker.IsEligibleForBonus(rental);
        Assert.False(result);
    }
}
