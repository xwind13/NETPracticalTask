using System.Text;

namespace Refactoring;

public static class ReportManager
{
    public static string GenerateCustomerStatement(Customer customer)
    {
        double totalAmount = 0;
        int frequentRenterPoints = 0;

        var sb = new StringBuilder();
        AppendHeader(sb, customer.Name);

        foreach (var rental in customer.Rentals)
        {
            double rentalPrice = rental.GetTotalPrice();
            totalAmount += rentalPrice;
            AppendRentalLine(sb, rental.Movie.Title, rentalPrice);
            
            frequentRenterPoints += rental.IsEligibleForBonus() ? 2 : 1;
        }

        AppendFooter(sb, totalAmount, frequentRenterPoints);

        return sb.ToString();
    }

    private static void AppendHeader(StringBuilder sb, string customerName)
    {
        sb.Append($"Учет аренды для {customerName}: ");
    }

    private static void AppendRentalLine(StringBuilder sb, string movieTitle, double thisAmount)
    {
        sb.Append($"\t{movieTitle}\t{thisAmount}\n");
    }

    private static void AppendFooter(StringBuilder sb, double totalAmount, int frequentRenterPoints)
    {
        sb.Append($"Сумма задолженности составляет {totalAmount}\n" +
               $"Вы заработали {frequentRenterPoints} очков за активность");
    }
}
