namespace Refactoring;

public static class RentalPricingCalculator
{
    private const double RegularBasePrice = 2.0;
    private const int RegularBaseRentalDays = 2;

    private const double ChildrenBasePrice = 1.5;
    private const int ChildrenBaseRentalDays = 3;

    private const double DayPrice = 1.5;
    private const double NewReleaseDayPrice = 3;

    public static double Calculate(PriceCode priceCode, int daysRented)
    {
        return priceCode switch
        {
            PriceCode.Regular => RegularBasePrice +
                CalculateRentByDays(daysRented - RegularBaseRentalDays, DayPrice),
            PriceCode.NewRelease => CalculateRentByDays(daysRented, NewReleaseDayPrice),
            PriceCode.Children => ChildrenBasePrice +
                CalculateRentByDays(daysRented - ChildrenBaseRentalDays, DayPrice),
            _ => throw new InvalidOperationException("Unknown PriceCode")
        };
    }

    private static double CalculateRentByDays(int days, double price)
    {
        if (days <= 0)
            return 0;

        return days * price;
    }
}
