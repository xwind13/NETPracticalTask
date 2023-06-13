namespace ConsoleApp1.PracticalTask1.Common
{
  /// <summary>
  /// Контракт для класса содержащий словарь с ключом соотвествующий режиму отображения и состоянием визуализатора.
  /// </summary>
  public interface IVisualizerStates
  {
    Dictionary<VisualizationMode, IVisualizerState> States { get; }
  }
}
