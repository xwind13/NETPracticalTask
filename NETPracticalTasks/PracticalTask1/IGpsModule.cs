using Navigation.Common;

namespace Navigation
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

    /// <summary>
    /// Текущая координата.
    /// </summary>
    Coordinate CurrentCoordinate { get; }

    /// <summary>
    /// Событие обновление текущей координаты.
    /// </summary>
    event Action<CoordinateUpdatedArgs> CoordinateUpdated;
  }
}
