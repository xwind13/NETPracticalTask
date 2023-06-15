namespace CityDataProcessing
{
  /// <summary>
  /// Класс для генерации отчетов.
  /// </summary>
  internal class ReportGenerator
  {
    private readonly string outputFileName;

    /// <summary>
    /// Генерирует отчет на основе списка городов.
    /// </summary>
    /// <param name="cities">Список городов для отчета.</param>
    internal void GenerateReport(IEnumerable<string> cities)
    {
      using var stream = new StreamWriter(this.outputFileName);
      foreach (var city in cities.OrderBy(c => c))
      {
        stream.WriteLine(city);
      }
    }

    public ReportGenerator(string outputFileName)
    {
      this.outputFileName = outputFileName;
    }
  }
}
