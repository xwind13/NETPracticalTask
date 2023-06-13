namespace ConsoleApp1.PracticalTask1.Common
{
  /// <summary>
  /// Аргументы передаваемые событием при изменении координат.
  /// </summary>
  internal class CoordinateUpdatedArgs
  {
    public Coordinate Coordinate { get; protected set; }

    public CoordinateUpdatedArgs(Coordinate coordinate)
    {
      this.Coordinate = coordinate;
    }
  }
}
