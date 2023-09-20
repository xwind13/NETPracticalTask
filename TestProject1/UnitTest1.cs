namespace Refactoring
{
    public class CustomerTests
    {
        [Fact]
        public void Statement_ReturnsCorrectStatement_WhenRentalsExist()
        {
            var movie1 = new Movie("Movie1", Movie.REGULAR);
            var movie2 = new Movie("Movie2", Movie.NEW_RELEASE);

            var rental1 = new Rental(movie1, 3);
            var rental2 = new Rental(movie2, 2);

            var customer = new Customer("TestCustomer");
            customer.Rentals = rental1;
            customer.Rentals = rental2;

            string statement = customer.Statement();

            string expectedStatement = "���� ������ ��� TestCustomer: " +
                "\tMovie1\t3.5\n" +
                "\tMovie2\t6\n" +
                "����� ������������� ���������� 9.5\n" +
                "�� ���������� 2 ����� �� ����������";

            Assert.Equal(expectedStatement, statement);
        }

        [Fact]
        public void Statement_ReturnsZeroAmount_WhenNoRentalsExist()
        {
            var customer = new Customer("TestCustomer");
            string statement = customer.Statement();

            string expectedStatement = "���� ������ ��� TestCustomer: " +
                "����� ������������� ���������� 0\n" +
                "�� ���������� 0 ����� �� ����������";

            Assert.Equal(expectedStatement, statement);
        }

        [Fact]
        public void Statement_UpdatesPriceCodeCorrectly()
        {
            var movie1 = new Movie("Movie1", Movie.REGULAR);
            var movie2 = new Movie("Movie2", Movie.NEW_RELEASE);

            var rental1 = new Rental(movie1, 3);
            var rental2 = new Rental(movie2, 2);

            var customer = new Customer("TestCustomer");
            customer.Rentals = rental1;
            customer.Rentals = rental2;

            rental1.Movie.PriceCode = Movie.CHILDRENS;
            rental2.Movie.PriceCode = Movie.REGULAR;

            string statement = customer.Statement();

            string expectedStatement = "���� ������ ��� TestCustomer: " +
                "\tMovie1\t1.5\n" +
                "\tMovie2\t2\n" +
                "����� ������������� ���������� 3.5\n" +
                "�� ���������� 2 ����� �� ����������";

            Assert.Equal(expectedStatement, statement);
        }
    }
}