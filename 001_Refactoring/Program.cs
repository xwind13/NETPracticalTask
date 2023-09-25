using Refactoring;
using Refactoring.Models;
using Refactoring.PricingStrategy;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Customer customer = new("Alex");
Movie movie1 = new("Matrix", PriceCode.NewRelease);
Movie movie2 = new("Star track", PriceCode.Regular);
Rental rental1 = new(movie1, 2);
Rental rental2 = new(movie2, 3);

customer.AddRental(rental1);
customer.AddRental(rental2);

var statementGenerator = new CustomerStatementGenerator(new PricingStrategyFactory(), new BonusEligibilityChecker());
Console.WriteLine(statementGenerator.Generate(customer));

Console.ReadKey();
