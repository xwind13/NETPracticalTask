namespace Navigation.Common
{
  /// <summary>
  /// Контракт для получения данных для карты.
  /// </summary>
  public interface IMapDataService
  {
    /// <summary>
    /// Получение координат всех именованных мест.
    /// </summary>
    /// <returns>Словарь с ключом имени места и с зачением координаты этого места.</returns>
    Dictionary<string, Coordinate> GetNamedPlaces();
  }
}
