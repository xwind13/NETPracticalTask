using ConsoleApp1.PracticalTask1.Common;

namespace ConsoleApp1.PracticalTask1
{
  internal class Navigator : INavigator
  {
    #region Поля и свойства

    private readonly IMap map;
    private readonly IVisualizer visualizer;
    private readonly IGpsModule module;

    #endregion

    #region Методы

    public void StartRoute(Coordinate coordinate)
    {
      if (!this.module.IsRouteCalculable)
        return;

      if (this.map.BuildRoute(this.module.CurrentCoordinate, coordinate))
        this.visualizer.VisualizeRoute(this.map.Route);
    }

    public void StartRoute(string endPoint)
    {
      if (!this.module.IsRouteCalculable)
        return;

      if (this.map.BuildRoute(this.module.CurrentCoordinate, endPoint))
        this.visualizer.VisualizeRoute(this.map.Route);
    }

    public void SetVisualizationMode(VisualizationMode mode)
    {
      this.visualizer.SetMode(mode);
      this.visualizer.VisualizeRoute(this.map.Route);
    }

    private void CoordinateUpdatedHandler(CoordinateUpdatedArgs args)
    {
      var coordinate = args.Coordinate;
      if (this.module.IsRouteCalculable)
        this.map.UpdateRoute(coordinate);
    }

    #endregion

    #region Конструкторы

    public Navigator(IGpsModule gpsModule, IMap map, IVisualizer visualizer)
    {
      this.module = gpsModule;
      this.module.CoordinateUpdated += this.CoordinateUpdatedHandler;
      this.visualizer = visualizer;

      this.map = map;
    }

    #endregion
  }
}
