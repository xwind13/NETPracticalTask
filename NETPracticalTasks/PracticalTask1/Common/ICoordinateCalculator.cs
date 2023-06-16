namespace Navigation.Common
{
  /// <summary>
  /// Контракт для расчета координат на основе данных спутников.
  /// </summary>
  public interface ICoordinateCalculator
  {
    /// <summary>
    /// Расчет координат на основе данных спутников.
    /// </summary>
    /// <param name="satellites">Список объектов спутников.</param>
    /// <returns></returns>
    Coordinate CalculateСurrentCoordinate(IEnumerable<ISatellite> satellites);
  }
}
