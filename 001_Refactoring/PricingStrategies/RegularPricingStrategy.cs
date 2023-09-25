namespace Refactoring.PricingStrategy;

public class RegularPricingStrategy : BasePricingStrategy, IPricingStrategy
{
    private const double BasePrice = 2.0;

    private const int BaseRentalDays = 2;

    public override double CalculatePrice(int daysRented)
    {
        return BasePrice + CalculateRentByDays(daysRented - BaseRentalDays);
    }

    public RegularPricingStrategy()
    {
        DayPrice = 1.5;
    }
}
