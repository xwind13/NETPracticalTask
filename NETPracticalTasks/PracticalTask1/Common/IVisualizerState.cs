namespace ConsoleApp1.PracticalTask1.Common
{
  /// <summary>
  /// Контракт состояния для визуализатора, в зависимости от которого происходит отображение.
  /// </summary>
  public interface IVisualizerState
  {
    void VisualizeRoute(IReadOnlyList<Coordinate> route);
  }
}
