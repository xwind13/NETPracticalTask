namespace Refactoring.Models;

/// <summary>
/// Класс, который предоставляет данные о фильме.
/// </summary>
public class Movie
{
    public PriceCode PriceCode { get; set; }

    public string Title { get; }

    public Movie(string title, PriceCode priceCode)
    {
        Title = title;
        PriceCode = priceCode;
    }
}

public enum PriceCode
{
    Regular = 0, NewRelease, Children
}
