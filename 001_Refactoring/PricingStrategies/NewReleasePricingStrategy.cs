namespace Refactoring.PricingStrategy;

public class NewReleasePricingStrategy : BasePricingStrategy, IPricingStrategy
{
    public override double CalculatePrice(int daysRented)
    {
        return daysRented * DayPrice;
    }

    public NewReleasePricingStrategy()
    {
        DayPrice = 3.0;
    }
}
