using System.Text;
using Refactoring.Models;
using Refactoring.PricingStrategy;

namespace Refactoring;

public class CustomerStatementGenerator
{
    private readonly PricingStrategyFactory pricingStrategyFactory;
    private readonly IBonusEligibilityChecker bonusEligibilityChecker;

    public CustomerStatementGenerator(PricingStrategyFactory pricingStrategyFactory, IBonusEligibilityChecker bonusEligibilityChecker)
    {
        this.pricingStrategyFactory = pricingStrategyFactory;
        this.bonusEligibilityChecker = bonusEligibilityChecker;
    }

    public string Generate(Customer customer)
    {
        double totalAmount = 0;
        int frequentRenterPoints = 0;

        var sb = new StringBuilder();
        AppendHeader(sb, customer.Name);

        foreach (var rental in customer.Rentals)
        {
            double rentalPrice = pricingStrategyFactory
                .GetPricingStrategy(rental.Movie.PriceCode).CalculatePrice(rental.DaysRented);
            totalAmount += rentalPrice;
            AppendRentalLine(sb, rental.Movie.Title, rentalPrice);

            frequentRenterPoints += bonusEligibilityChecker.IsEligibleForBonus(rental) ? 2 : 1;
        }

        AppendFooter(sb, totalAmount, frequentRenterPoints);

        return sb.ToString();
    }

    private void AppendHeader(StringBuilder sb, string customerName)
    {
        sb.Append($"Учет аренды для {customerName}: ");
    }

    private void AppendRentalLine(StringBuilder sb, string movieTitle, double thisAmount)
    {
        sb.Append($"\t{movieTitle}\t{thisAmount}\n");
    }

    private void AppendFooter(StringBuilder sb, double totalAmount, int frequentRenterPoints)
    {
        sb.Append($"Сумма задолженности составляет {totalAmount}\n" +
                  $"Вы заработали {frequentRenterPoints} очков за активность");
    }
}
