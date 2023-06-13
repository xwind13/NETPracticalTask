using ConsoleApp1.PracticalTask1.Common;

namespace ConsoleApp1.PracticalTask1
{
  /// <summary>
  /// контракт для карты со свойствами доступных только по чтению.
  /// </summary>
  public interface IReadOnlyMap
  {
    /// <summary>
    /// Список названий мест, для которых есть сохранненые координаты.
    /// </summary>
    IReadOnlyCollection<string> NamedPlaces { get; }

    /// <summary>
    /// Расчитанный маршрут.
    /// </summary>
    IReadOnlyList<Coordinate> Route { get; }
  }
}
