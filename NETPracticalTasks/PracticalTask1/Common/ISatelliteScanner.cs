namespace Navigation.Common
{
  /// <summary>
  /// Контракт сканнера для получения актульного состава видимых спутников.
  /// </summary>
  public interface ISatelliteScanner
  {
    /// <summary>
    /// Получение актульного состава видимых спутников.
    /// </summary>
    /// <returns>Список спутников.</returns>
    IReadOnlyList<ISatellite> ObtainVisibleSatellites();
  }
}
