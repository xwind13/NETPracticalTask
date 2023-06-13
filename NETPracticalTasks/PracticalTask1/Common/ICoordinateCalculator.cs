namespace ConsoleApp1.PracticalTask1.Common
{
  /// <summary>
  /// Контракт для расчета коодинат, которые получены с данных спутников.
  /// </summary>
  public interface ICoordinateCalculator
  {
    Coordinate Calculate(IEnumerable<ISatellite> satellites);
  }
}
