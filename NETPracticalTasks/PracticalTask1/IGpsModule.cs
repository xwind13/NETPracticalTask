using ConsoleApp1.PracticalTask1.Common;

namespace ConsoleApp1.PracticalTask1
{
  /// <summary>
  /// Контракт для GPS-модуля
  /// </summary>
  internal interface IGpsModule
  {
    /// <summary>
    /// Флаг если возможно получить актуальную текущую кординату, необходимую для расчета пути
    /// </summary>
    bool IsRouteCalculable { get; }
    Coordinate CurrentCoordinate { get; }
    event Action<CoordinateUpdatedArgs> CoordinateUpdated;
  }
}
