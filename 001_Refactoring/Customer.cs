namespace Refactoring;

/// <summary>
/// Класс, представляющий клиента магазина.
/// </summary>
public class Customer
{
    private readonly List<Rental> rentals = new List<Rental>();

    public string Name { get; }

    public IReadOnlyList<Rental> Rentals => this.rentals;

    public void AddRental(Rental rental)
    {
        this.rentals.Add(rental);
    }

    public Customer(string name)
    {
        this.Name = name;
    }
}
