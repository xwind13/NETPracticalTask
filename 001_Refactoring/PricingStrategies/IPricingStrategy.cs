namespace Refactoring.PricingStrategy;

public interface IPricingStrategy
{
    double CalculatePrice(int daysRented);
}