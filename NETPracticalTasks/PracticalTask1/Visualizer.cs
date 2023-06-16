using Navigation.Common;

namespace Navigation
{
  /// <summary>
  /// Визуализатор для отображения маршрута на карте.
  /// </summary>
  internal class Visualizer : IVisualizer
  {
    private readonly Dictionary<VisualizationMode, IVisualizerState> states;
    private IVisualizerState? currentState;

    /// <summary>
    /// Флаг что режим отображения был выставлен.
    /// </summary>
    public bool VisualizationModeSet { get; private set; }

    /// <summary>
    /// Установить режим отображения.
    /// </summary>
    /// <param name="mode">Режим отображения.</param>
    public void SetMode(VisualizationMode mode)
    {
      if (!this.states.TryGetValue(mode, out var state))
        throw new ArgumentException($"Invalid visualization mode: {mode}");

      this.currentState = state;
      this.VisualizationModeSet = true;
    }

    /// <summary>
    /// Отобразить маршрут.
    /// </summary>
    /// <param name="route">Список координат маршрута.</param>
    public void VisualizeRoute(IReadOnlyList<Coordinate> route)
    {
      this.currentState?.SetRoute(route);
      this.currentState?.Invalidate();
    }

    public Visualizer(IVisualizerStates states)
    {
      this.states = states.States;
      
    }
  }
}
