using Refactoring;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Customer customer = new("Alex");
Movie movie1 = new("Matrix", PriceCode.NewRelease);
Movie movie2 = new("Star track", PriceCode.Regular);
Rental rental1 = new(movie1, 2);
Rental rental2 = new(movie2, 3);

customer.AddRental(rental1);
customer.AddRental(rental2);
Console.WriteLine(ReportManager.GenerateCustomerStatement(customer));

Console.ReadKey();
