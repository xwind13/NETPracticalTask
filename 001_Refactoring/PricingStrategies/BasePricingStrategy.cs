namespace Refactoring.PricingStrategy;

public abstract class BasePricingStrategy : IPricingStrategy
{
    protected double DayPrice { get; set; }
    public abstract double CalculatePrice(int daysRented);

    protected double CalculateRentByDays(int days)
    {
        if (days <= 0)
            return 0;

        return days * DayPrice;
    }
}
