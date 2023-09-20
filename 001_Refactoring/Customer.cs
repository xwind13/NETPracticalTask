using System;
using System.Collections.Generic;

namespace Refactoring
{
  /// <summary>
  /// Класс, представляющий клиента магазина.
  /// </summary>
  public class Customer
  {
    private string name = null;

    private List<Rental> rentals = new List<Rental>();

    public Customer(string name)
    {
      this.name = name;
    }

    public string Statement()
    {
      double totalAmount = 0;
      int frequentRenterPoints = 0;
      string result = string.Format("Учет аренды для {0}: ", name);

      // Для каждого клиента рассчитываем задолженность...
      foreach (Rental rental in rentals)
      {
        double thisAmount = 0;

        // Определить сумму для каждой строки.
        switch (rental.Movie.PriceCode)
        {
          case Movie.REGULAR:
            thisAmount += 2;
            if (rental.DaysRented > 2)
              thisAmount += (rental.DaysRented - 2) * 1.5;
            break;
          case Movie.NEW_RELEASE:
            thisAmount += rental.DaysRented * 3;
            break;
          case Movie.CHILDRENS:
            thisAmount += 1.5;
            if (rental.DaysRented > 3)
              thisAmount += (rental.DaysRented - 3) * 1.5;
            break;
        }

        // Добавить очки для активного арендатора.
        frequentRenterPoints++;

        // Бонус за аренду новинки на один день или обычного фильма на неделею.
        if (((rental.Movie.PriceCode == Movie.NEW_RELEASE) && rental.DaysRented <= 1) ||
          (rental.Movie.PriceCode == Movie.REGULAR) && rental.DaysRented > 7)
          frequentRenterPoints++;

        // Показать результаты для этой аренды
        result += "\t" + rental.Movie.Title + "\t" + thisAmount + "\n";
        totalAmount += thisAmount;
      }

      // Добавить нижний колонтитул 
      result += "Сумма задолженности составляет " + totalAmount + "\n";
      result += "Вы заработали " + frequentRenterPoints + " очков за активность";

      return result;
    }

    public Rental Rentals
    {
      set { this.rentals.Add(value); }
    }

    public string Name
    {
      get { return this.name; }
    }
  }
}
