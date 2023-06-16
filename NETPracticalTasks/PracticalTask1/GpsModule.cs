using Navigation.Common;
using Microsoft.Extensions.Options;

namespace Navigation
{
  /// <summary>
  /// GPS-модуль.
  /// </summary>
  internal class GpsModule : IGpsModule, IDisposable
  {
    #region Константы

    /// <summary>
    /// Минимальное допустимое количество спутников для получения текущих координат.
    /// </summary>
    private const int MinSatelliteCount = 5;

    #endregion

    #region Свойства и поля

    private readonly ISatelliteScanner satelliteScanner;
    private readonly ICoordinateCalculator coordinateCalculator;
    private readonly Timer timer;

    private IReadOnlyList<ISatellite> satellites;
    private Coordinate currentCoordinate;

    /// <summary>
    /// Текущая координата.
    /// </summary>
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

    /// <summary>
    /// Флаг если возможно получить актуальную текущую кординату, необходимую для расчета пути
    /// </summary>
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

      this.CurrentCoordinate = this.coordinateCalculator.CalculateСurrentCoordinate(this.satellites);
    }

    /// <summary>
    /// Освобождение ресурсов таймера.
    /// </summary>
    public void Dispose()
    {
      this.timer.Change(Timeout.Infinite, Timeout.Infinite);
      this.timer.Dispose();
    }

    #endregion

    #region События

    /// <summary>
    /// Событие обновление текущей координаты.
    /// </summary>
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
