using Refactoring.Models;

namespace Refactoring;

public interface IBonusEligibilityChecker
{
    bool IsEligibleForBonus(Rental rental);
}

public class BonusEligibilityChecker : IBonusEligibilityChecker
{
    public bool IsEligibleForBonus(Rental rental)
    {
        var newReleaseRentedForOneDay = rental.Movie.PriceCode == PriceCode.NewRelease && rental.DaysRented <= 1;
        var regularRentedForMoreThanWeek = rental.Movie.PriceCode == PriceCode.Regular && rental.DaysRented > 7;

        return (newReleaseRentedForOneDay || regularRentedForMoreThanWeek);
    }
}
