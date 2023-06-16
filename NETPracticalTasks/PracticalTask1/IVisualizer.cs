using Navigation.Common;

namespace Navigation
{
  /// <summary>
  /// Контракт визуализатора для отображения маршрута на карте.
  /// </summary>
  public interface IVisualizer
  {
    /// <summary>
    /// Флаг что режим отображения был выставлен.
    /// </summary>
    bool VisualizationModeSet { get; }

    /// <summary>
    /// Установить режим отображения.
    /// </summary>
    /// <param name="mode">Режим отображения.</param>
    void SetMode(VisualizationMode mode);

    /// <summary>
    /// Отобразить маршрут.
    /// </summary>
    /// <param name="route">Список координат маршрута.</param>
    void VisualizeRoute(IReadOnlyList<Coordinate> route);
  }
}
