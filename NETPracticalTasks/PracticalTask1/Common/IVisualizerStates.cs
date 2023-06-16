namespace Navigation.Common
{
  /// <summary>
  /// Контракт для класса содержащий словарь с ключом соотвествующий режиму отображения и состоянием визуализатора.
  /// </summary>
  public interface IVisualizerStates
  {
    /// <summary>
    /// Cловарь с ключом соотвествующий режиму отображения и состоянием визуализатора.
    /// </summary>
    Dictionary<VisualizationMode, IVisualizerState> States { get; }
  }
}
