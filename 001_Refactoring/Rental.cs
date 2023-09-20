using System;

namespace Refactoring
{
  /// <summary>
  /// Класс, представляющий данные о прокате фильма.
  /// </summary>
  public class Rental
  {
    private Movie movie = null;

    private int daysRented = 0;

    public Rental(Movie movie, int daysRented)
    {
      this.movie = movie;
      this.daysRented = daysRented;
    }

    public Movie Movie
    {
      get { return this.movie; }
    }

    public int DaysRented
    {
      get { return this.daysRented; }
    }
  }
}
