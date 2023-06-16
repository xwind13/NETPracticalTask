using Navigation.Common;

namespace Navigation
{
  /// <summary>
  /// Контракт для навигатора.
  /// </summary>
  public interface INavigator
  {
    /// <summary>
    /// Установить режим отображения.
    /// </summary>
    /// <param name="mode">Режим отображения.</param>
    void SetVisualizationMode(VisualizationMode mode);

    /// <summary>
    /// Начать марштрут к указаной точки.
    /// </summary>
    /// <param name="coordinate">Пункт назначения.</param>
    bool StartRoute(Coordinate coordinate);

    /// <summary>
    /// Начать марштрут к указаной точки.
    /// </summary>
    /// <param name="endPoint">Название пункта назначения.</param>
    bool StartRoute(string endPoint);
  }
}
