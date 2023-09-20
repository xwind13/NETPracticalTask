using Refactoring;

Customer customer = new Customer("Alex");
Movie movie1 = new Movie("Matrix", 1);
Movie movie2 = new Movie("Star track", 0);
Rental rental1 = new Rental(movie1, 2);
Rental rental2 = new Rental(movie2, 3);

customer.Rentals = rental1;
customer.Rentals = rental2;
Console.WriteLine(customer.Statement());

Console.ReadKey();
