using ConsoleApp1.PracticalTask1.Common;

namespace ConsoleApp1.PracticalTask1
{
  /// <summary>
  /// Контракт для навигатора.
  /// </summary>
  public interface INavigator
  {
    void SetVisualizationMode(VisualizationMode mode);

    /// <summary>
    /// Начать марштрут к указаной точки.
    /// </summary>
    /// <param name="coordinate">Пункт назначения.</param>
    void StartRoute(Coordinate coordinate);

    /// <summary>
    /// Начать марштрут к указаной точки.
    /// </summary>
    /// <param name="endPoint">Название пункта назначения.</param>
    void StartRoute(string endPoint);
  }
}
