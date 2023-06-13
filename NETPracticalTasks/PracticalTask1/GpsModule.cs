using ConsoleApp1.PracticalTask1.Common;
using Microsoft.Extensions.Options;

namespace ConsoleApp1.PracticalTask1
{
  /// <summary>
  /// GPS-модуль.
  /// </summary>
  internal class GpsModule : IGpsModule
  {
    #region Константы

    private const int MinSatelliteCount = 5;

    #endregion

    #region Свойства и поля

    private readonly ISatelliteScanner satelliteScanner;
    private readonly ICoordinateCalculator coordinateCalculator;

    private Timer timer;
    private List<ISatellite> satellites;
    private Coordinate currentCoordinate;

    public Coordinate CurrentCoordinate
    {
      get { return this.currentCoordinate; }
      private set
      {
        if (this.currentCoordinate == value)
          return;

        this.currentCoordinate = value;
        CoordinateUpdated?.Invoke(new CoordinateUpdatedArgs(this.currentCoordinate));
      }
    }
    public bool IsRouteCalculable { get; protected set; }

    #endregion

    #region Методы

    /// <summary>
    /// Обновление состояния GPS-модуля.
    /// </summary>
    /// <param name="state">Состояние передаваемое таймером.</param>
    private void RefreshGpsModuleState(object? state)
    {
      this.satellites = this.satelliteScanner.ObtainVisibleSatellites();
      this.IsRouteCalculable = this.satellites.Count >= MinSatelliteCount;

      if (!this.IsRouteCalculable)
        return;

      this.CurrentCoordinate = this.coordinateCalculator.Calculate(this.satellites);
    }

    #endregion

    #region События

    public event Action<CoordinateUpdatedArgs>? CoordinateUpdated;

    #endregion

    #region Конструкторы

    public GpsModule(ISatelliteScanner scanner, ICoordinateCalculator calculator, IOptions<GpsModuleOptions> options)
    {
      this.satellites = new List<ISatellite>();
      this.currentCoordinate = new(0, 0);

      this.satelliteScanner = scanner;
      this.coordinateCalculator = calculator;

      var updateInterval = options.Value.TimerUpdateInterval;
      this.timer = new Timer(callback: this.RefreshGpsModuleState, state: null, dueTime: updateInterval, period: updateInterval);
    }

    #endregion
  }
}
