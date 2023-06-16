namespace Navigation.Common
{
  /// <summary>
  /// Аргументы передаваемые событием при изменении координат.
  /// </summary>
  internal class CoordinateUpdatedArgs
  {
    /// <summary>
    /// Изменненая координата.
    /// </summary>
    public Coordinate Coordinate { get; protected set; }

    public CoordinateUpdatedArgs(Coordinate coordinate)
    {
      this.Coordinate = coordinate;
    }
  }
}
