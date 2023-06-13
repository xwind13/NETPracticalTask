using ConsoleApp1.PracticalTask1.Common;

namespace ConsoleApp1.PracticalTask1
{
  /// <summary>
  /// Визуализатор для отображения маршрута на карте.
  /// </summary>
  internal class Visualizer : IVisualizer
  {
    private readonly Dictionary<VisualizationMode, IVisualizerState> states;
    private IVisualizerState? currentState;

    public void SetMode(VisualizationMode mode)
    {
      if (this.states.ContainsKey(mode))
      {
        this.currentState = this.states[mode];
      }
      else
      {
        throw new ArgumentException($"Invalid visualization mode: {mode}");
      }
    }

    public void VisualizeRoute(IReadOnlyList<Coordinate> route)
    {
      this.currentState?.VisualizeRoute(route);
    }

    public Visualizer(IVisualizerStates states)
    {
      this.states = states.States;
      this.SetMode(VisualizationMode.Mode2D);
    }
  }
}
