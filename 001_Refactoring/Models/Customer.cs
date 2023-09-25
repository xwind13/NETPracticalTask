namespace Refactoring.Models;

/// <summary>
/// Класс, представляющий клиента магазина.
/// </summary>
public class Customer
{
    private readonly List<Rental> rentals = new List<Rental>();

    public string Name { get; }

    public IReadOnlyList<Rental> Rentals => rentals;

    public void AddRental(Rental rental)
    {
        rentals.Add(rental);
    }

    public Customer(string name)
    {
        Name = name;
    }
}
