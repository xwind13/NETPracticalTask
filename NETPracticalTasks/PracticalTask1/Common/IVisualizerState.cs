namespace Navigation.Common
{
  /// <summary>
  /// Контракт состояния для визуализатора, в зависимости от которого происходит отображение.
  /// </summary>
  public interface IVisualizerState
  {
    /// <summary>
    /// Передать данные маршрута
    /// </summary>
    /// <param name="route"></param>
    void SetRoute(IReadOnlyList<Coordinate> route);

    /// <summary>
    /// Обновить отображение.
    /// </summary>
    void Invalidate();
  }
}
