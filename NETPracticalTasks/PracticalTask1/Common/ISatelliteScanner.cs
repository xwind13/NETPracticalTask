namespace ConsoleApp1.PracticalTask1.Common
{
  /// <summary>
  /// Контракт сканнера для получения актульного состава видимых спутников.
  /// </summary>
  public interface ISatelliteScanner
  {
    List<ISatellite> ObtainVisibleSatellites();
  }
}
