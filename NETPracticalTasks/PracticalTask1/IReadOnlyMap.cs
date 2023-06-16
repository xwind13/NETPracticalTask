using Navigation.Common;

namespace Navigation
{
  /// <summary>
  /// контракт для карты со свойствами доступных только по чтению.
  /// </summary>
  public interface IReadOnlyMap
  {
    /// <summary>
    /// Словарь названий мест с сохраненными для них координатами.
    /// </summary>
    IReadOnlyDictionary<string, Coordinate> NamedPlaces { get; }

    /// <summary>
    /// Расчитанный маршрут.
    /// </summary>
    IReadOnlyList<Coordinate> Route { get; }
  }
}
