using Refactoring.Models;
using Refactoring.PricingStrategy;
using Xunit;

namespace Refactoring
{
    public class CustomerTests
    {
        [Fact]
        public void Statement_ReturnsCorrectStatement_WhenRentalsExist()
        {
            var movie1 = new Movie("Movie1", PriceCode.Regular);
            var movie2 = new Movie("Movie2", PriceCode.NewRelease);

            var rental1 = new Rental(movie1, 3);
            var rental2 = new Rental(movie2, 2);

            var customer = new Customer("TestCustomer");
            customer.AddRental(rental1);
            customer.AddRental(rental2);

            var statementGenerator = new CustomerStatementGenerator(new PricingStrategyFactory(), new BonusEligibilityChecker());
            string statement = statementGenerator.Generate(customer);

            string expectedStatement = "Учет аренды для TestCustomer: " +
                $"\tMovie1\t3.5\n" +
                "\tMovie2\t6\n" +
                "Сумма задолженности составляет 9.5\n" +
                "Вы заработали 2 очков за активность";

            Assert.Equal(expectedStatement, statement);
        }

        [Fact]
        public void Statement_ReturnsZeroAmount_WhenNoRentalsExist()
        {
            var customer = new Customer("TestCustomer");
            var statementGenerator = new CustomerStatementGenerator(new PricingStrategyFactory(), new BonusEligibilityChecker());
            string statement = statementGenerator.Generate(customer);

            string expectedStatement = "Учет аренды для TestCustomer: " +
                "Сумма задолженности составляет 0\n" +
                "Вы заработали 0 очков за активность";

            Assert.Equal(expectedStatement, statement);
        }

        [Fact]
        public void Statement_UpdatesPriceCodeCorrectly()
        {
            var movie1 = new Movie("Movie1", PriceCode.Regular);
            var movie2 = new Movie("Movie2", PriceCode.NewRelease);

            var rental1 = new Rental(movie1, 3);
            var rental2 = new Rental(movie2, 2);

            var customer = new Customer("TestCustomer");
            customer.AddRental(rental1);
            customer.AddRental(rental2);

            rental1.Movie.PriceCode = PriceCode.Children;
            rental2.Movie.PriceCode = PriceCode.Regular;

            var statementGenerator = new CustomerStatementGenerator(new PricingStrategyFactory(), new BonusEligibilityChecker());
            string statement = statementGenerator.Generate(customer);

            // Assert
            string expectedStatement = "Учет аренды для TestCustomer: " +
                "\tMovie1\t1.5\n" +
                "\tMovie2\t2\n" +
                "Сумма задолженности составляет 3.5\n" +
                "Вы заработали 2 очков за активность";

            Assert.Equal(expectedStatement, statement);
        }
    }
}