using Navigation.Common;

namespace Navigation
{
  /// <summary>
  /// Карта.
  /// </summary>
  public class Map : IMap
  {
    #region Поля и свойства

    private readonly IRouteCalculator routeCalculator;
    private readonly IMapDataService dataService;
    private readonly Dictionary<string, Coordinate> namedPlaces;

    /// <summary>
    /// Расчитанный маршрут.
    /// </summary>
    public IReadOnlyList<Coordinate> Route { get; private set; }

    /// <summary>
    /// Словарь названий мест с сохраненными для них координатами.
    /// </summary>
    public IReadOnlyDictionary<string, Coordinate> NamedPlaces
    {
      get
      {
        if (this.namedPlaces != null)
          return this.namedPlaces;

        return new Dictionary<string, Coordinate>();
      }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Построить маршрут.
    /// </summary>
    /// <param name="current">Текущая позиция.</param>
    /// <param name="end">Конечная позиция.</param>
    /// <returns>Флаг был ли расчет успешный.</returns>
    public bool BuildRoute(Coordinate current, Coordinate end)
    {
      this.Route = this.routeCalculator.Calculate(current, end);
      //  если вернулся пустой маршрут, то расчет провальный.
      var isSuccess = this.Route.Any();
      return isSuccess;
    }

    /// <summary>
    /// Построить маршрут.
    /// </summary>
    /// <param name="current">Текущая позиция.</param>
    /// <param name="end">Название места конечной позиции.</param>
    /// <returns>Флаг был ли расчет успешный.</returns>
    public bool BuildRoute(Coordinate current, string endPlace)
    {
      if (!this.namedPlaces.ContainsKey(endPlace))
        return false;

      return this.BuildRoute(current, this.namedPlaces[endPlace]);
    }

    /// <summary>
    /// Обновить маршрут.
    /// </summary>
    /// <param name="current">Текущая позиция.</param>
    /// <returns>Флаг был ли расчет успешный.</returns>
    public bool UpdateRoute(Coordinate current)
    {
      if (this.Route.Any())
        return false;

      this.Route = this.routeCalculator.Update(this.Route, current);
      //  если вернулся пустой маршрут, то расчет провальный.
      var isSuccess = this.Route.Any();
      return isSuccess;
    }

    #endregion

    #region Конструкторы

    public Map(IMapDataService dataService, IRouteCalculator routeCalculator)
    {
      this.routeCalculator = routeCalculator;
      this.dataService = dataService;

      this.Route = new List<Coordinate>();
      this.namedPlaces = this.dataService.GetNamedPlaces();
    }

    #endregion
  }
}
