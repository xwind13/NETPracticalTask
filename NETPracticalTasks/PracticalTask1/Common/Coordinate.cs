namespace ConsoleApp1.PracticalTask1.Common
{
  /// <summary>
  /// Запись для координаты.
  /// Выбор использования этой записи вместо System.Windows.Point обуславлевается тем,
  /// что библиотека WindowsBase недоступна для .NET 6, а также выбранная мной модель более соответствует предметной области.
  /// </summary>
  /// <param name="Latitude">Широта</param>
  /// <param name="Longitude">Долгота</param>
  public record Coordinate(double Latitude, double Longitude);
}
