using ConsoleApp1.PracticalTask1.Common;

namespace ConsoleApp1.PracticalTask1
{
  /// <summary>
  /// Контракт визуализатора для отображения маршрута на карте.
  /// </summary>
  public interface IVisualizer
  {
    void SetMode(VisualizationMode mode);
    void VisualizeRoute(IReadOnlyList<Coordinate> route);
  }
}
