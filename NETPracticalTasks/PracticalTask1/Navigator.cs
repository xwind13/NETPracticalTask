using Navigation.Common;

namespace Navigation
{
  /// <summary>
  /// Навигатор.
  /// </summary>
  internal class Navigator : INavigator
  {
    #region Поля и свойства

    private readonly IMap map;
    private readonly IVisualizer visualizer;
    private readonly IGpsModule module;

    #endregion

    #region Методы

    /// <summary>
    /// Начать марштрут к указаной точки.
    /// </summary>
    /// <param name="coordinate">Пункт назначения.</param>
    public bool StartRoute(Coordinate coordinate)
    {
      if (!this.module.IsRouteCalculable)
        return false;

      if (this.map.BuildRoute(this.module.CurrentCoordinate, coordinate))
        this.visualizer.VisualizeRoute(this.map.Route);

      return true;
    }

    /// <summary>
    /// Начать марштрут к указаной точки.
    /// </summary>
    /// <param name="endPoint">Название пункта назначения.</param>
    public bool StartRoute(string endPoint)
    {
      if (!this.module.IsRouteCalculable)
        return false;

      if (this.map.BuildRoute(this.module.CurrentCoordinate, endPoint))
        this.VisualizeRoute();

      return true;
    }

    /// <summary>
    /// Установить режим отображения.
    /// </summary>
    /// <param name="mode">Режим отображения.</param>
    public void SetVisualizationMode(VisualizationMode mode)
    {
      this.visualizer.SetMode(mode);
      this.visualizer.VisualizeRoute(this.map.Route);
    }

    /// <summary>
    /// Хандлер для события обновления текущей координаты.
    /// </summary>
    /// <param name="args">Аргументы передаваемые событием.</param>
    private void CoordinateUpdatedHandler(CoordinateUpdatedArgs args)
    {
      var coordinate = args.Coordinate;
      if (this.module.IsRouteCalculable)
        this.map.UpdateRoute(coordinate);
    }

    /// <summary>
    /// Визуализировать маршрут.
    /// </summary>
    private void VisualizeRoute()
    {
      if (!this.visualizer.VisualizationModeSet)
        this.visualizer.SetMode(VisualizationMode.Mode2D);

      this.visualizer.VisualizeRoute(this.map.Route);
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
