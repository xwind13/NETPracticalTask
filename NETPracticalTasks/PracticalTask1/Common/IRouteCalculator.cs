namespace Navigation.Common
{
  /// <summary>
  /// Контракт для расчета маршрута.
  /// </summary>
  public interface IRouteCalculator
  {
    /// <summary>
    /// Расчитать новый маршрут от начальной до конечной точки.
    /// </summary>
    /// <param name="begin">Начальная координата.</param>
    /// <param name="end">Конечная координата.</param>
    /// <returns></returns>
    IReadOnlyList<Coordinate> Calculate(Coordinate begin, Coordinate end);

    /// <summary>
    /// Подкорректировать существующий маршрут, в зависимости от текущего положения.
    /// </summary>
    /// <param name="route">Список координат соотвествующих текущему маршруту.</param>
    /// <param name="current">Текущая координата.</param>
    /// <returns></returns>
    IReadOnlyList<Coordinate> Update(IReadOnlyList<Coordinate> route, Coordinate current);
  }
}
