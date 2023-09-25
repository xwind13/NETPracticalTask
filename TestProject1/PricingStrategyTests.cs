using Refactoring.PricingStrategy;
using Xunit;

namespace Refactoring.Tests;

public class PricingStrategyTests
{
    [Fact]
    public void RegularPricingStrategy_CalculatePrice_ReturnsCorrectPrice()
    {
        var strategy = new RegularPricingStrategy();
        var price = strategy.CalculatePrice(5);
        Assert.Equal(6.5, price);
    }

    [Fact]
    public void NewReleasePricingStrategy_CalculatePrice_ReturnsCorrectPrice()
    {
        var strategy = new NewReleasePricingStrategy();
        var price = strategy.CalculatePrice(3);
        Assert.Equal(9, price);
    }

    [Fact]
    public void ChildrenPricingStrategy_CalculatePrice_ReturnsCorrectPrice()
    {
        var strategy = new ChildrenPricingStrategy();
        var price = strategy.CalculatePrice(4);
        Assert.Equal(3, price);
    }
}
