using ConsoleApp1.PracticalTask1.Common;

namespace ConsoleApp1.PracticalTask1
{
  /// <summary>
  /// Расширение конракта для карты с возможностью просчитывать маршрут.
  /// </summary>
  public interface IMap : IReadOnlyMap
  {
    /// <summary>
    /// Построить маршрут.
    /// </summary>
    /// <param name="current">Текущая позиция.</param>
    /// <param name="end">Конечная позиция.</param>
    /// <returns>Флаг был ли расчет успешный.</returns>
    bool BuildRoute(Coordinate current, Coordinate end);

    /// <summary>
    /// Построить маршрут.
    /// </summary>
    /// <param name="current">Текущая позиция.</param>
    /// <param name="end">Название места конечной позиции.</param>
    /// <returns>Флаг был ли расчет успешный.</returns>
    bool BuildRoute(Coordinate current, string endPlace);

    /// <summary>
    /// Обновить маршрут.
    /// </summary>
    /// <param name="current">Текущая позиция.</param>
    /// <returns>Флаг был ли расчет успешный.</returns>
    bool UpdateRoute(Coordinate current);
  }
}
