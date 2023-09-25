namespace Refactoring.PricingStrategy;

public class ChildrenPricingStrategy : BasePricingStrategy, IPricingStrategy
{
    private const double BasePrice = 1.5;
    private const int BaseRentalDays = 3;

    public override double CalculatePrice(int daysRented)
    {
        return BasePrice + CalculateRentByDays(daysRented - BaseRentalDays);
    }

    public ChildrenPricingStrategy()
    {
        this.DayPrice = 1.5;
    }
}