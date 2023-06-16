namespace Navigation.Common
{
  /// <summary>
  /// Класс для опций настроек Gps-модуля.
  /// </summary>
  internal class GpsModuleOptions
  {
    /// <summary>
    /// Интервал времени обновления в милисекундах.
    /// </summary>
    public int TimerUpdateInterval { get; set; } = 500;
  }
}
