namespace CityDataProcessing
{

  internal class CityDataProcessor
  {
    /// <summary>
    /// Создание отчета с городами максимальной численности на основе данных CSV файла
    /// </summary>
    /// <param name="csvFilePath">Путь к CSV файлу с данными о городах.</param>
    /// <param name="reportFilePath">Путь к файлу, в который будет сгенерирован отчет.</param>
    internal static void GenerateReportFromCsvFle(string csvFilePath, string reportFilePath)
    {
      var reader = new CsvDataReader(csvFilePath);
      var data = reader.ReadData();

      var storage = new CityDataStorage();
      storage.ImportRawData(data);

      var generator = new ReportGenerator(reportFilePath);
      generator.GenerateReport(storage.GetHighPopulationCities());
    }
  }
}
