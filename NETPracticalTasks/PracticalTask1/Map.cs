using ConsoleApp1.PracticalTask1.Common;

namespace ConsoleApp1.PracticalTask1
{
  /// <summary>
  /// Карта.
  /// </summary>
  public class Map : IMap
  {
    #region Поля и свойства

    private readonly IRouteCalculator routeCalculator;
    private readonly IMapDataService dataService;

    private Dictionary<string, Coordinate> namedPlaces;

    public IReadOnlyList<Coordinate> Route { get; private set; }
    public IReadOnlyCollection<string> NamedPlaces
    {
      get
      {
        if (this.namedPlaces != null)
          return this.namedPlaces.Keys;

        return new List<string>();
      }
    }

    #endregion

    #region Методы

    public bool BuildRoute(Coordinate current, Coordinate end)
    {
      this.Route = this.routeCalculator.Calculate(current, end);
      //  если вернулся пустой маршрут, то расчет провальный.
      var isSuccess = this.Route.Any();
      return isSuccess;
    }

    public bool BuildRoute(Coordinate current, string endPlace)
    {
      if (!this.namedPlaces.ContainsKey(endPlace))
        return false;

      return this.BuildRoute(current, this.namedPlaces[endPlace]);
    }

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
