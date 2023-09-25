using _001_Refactoring.Models;

namespace Refactoring.PricingStrategy;

public class PricingStrategyFactory
{
    public IPricingStrategy GetPricingStrategy(PriceCode priceCode)
    {
        return priceCode switch
        {
            PriceCode.Regular => new RegularPricingStrategy(),
            PriceCode.Children => new ChildrenPricingStrategy(),
            PriceCode.NewRelease => new NewReleasePricingStrategy(),
            _ => throw new InvalidOperationException("Unknown PriceCode")
        };
    }
}
