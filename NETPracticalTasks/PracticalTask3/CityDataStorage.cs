namespace CityDataProcessing
{
  /// <summary>
  /// Класс для хранилища данных о городах
  /// </summary>
  internal class CityDataStorage
  {
    /// <summary>
    /// Минимальная числиность населения.
    /// </summary>
    private const int MinCityPopulation = 100000;

    private readonly List<(string city, int population)> data = new();

    /// <summary>
    /// Импорт сырых данных.
    /// </summary>
    /// <param name="data"></param>
    internal void ImportRawData(IEnumerable<string[]> data)
    {
      foreach (var fields in data.Where(fields => fields.Length >= 2))
      {
        var city = fields[0].Trim('"');
        if (int.TryParse(fields[1], out int population))
        {
          this.data.Add((city, population));
        }
      }
    }

    /// <summary>
    /// Вернуть города с высокой численностью населения.
    /// </summary>
    /// <returns>Список названий городов.</returns>
    internal IEnumerable<string> GetHighPopulationCities()
    {
      return this.data.Where(record => record.population > MinCityPopulation)
        .Select(record => record.city).ToList();
    }
  }
}
