namespace Refactoring;

/// <summary>
/// Класс, представляющий данные о прокате фильма.
/// </summary>
public class Rental
{
    public Movie Movie { get; }

    public int DaysRented { get; }

    public double GetTotalPrice()
    {
        return RentalPricingCalculator.Calculate(this.Movie.PriceCode, this.DaysRented);
    }

    public bool IsEligibleForBonus()
    {
        var newReleaseRentedForOneDay = this.Movie.PriceCode == PriceCode.NewRelease && this.DaysRented <= 1;
        var regularRentedForMoreThanWeek = this.Movie.PriceCode == PriceCode.Regular && this.DaysRented > 7;

        return (newReleaseRentedForOneDay || regularRentedForMoreThanWeek);
    }

    public Rental(Movie movie, int daysRented)
    {
        this.Movie = movie;
        this.DaysRented = daysRented;
    }
}
