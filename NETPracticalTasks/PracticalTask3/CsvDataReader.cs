using Microsoft.VisualBasic.FileIO;

namespace CityDataProcessing
{
  /// <summary>
  /// Класс для чтения данных из CSV файла.
  /// </summary>
  internal class CsvDataReader
  {
    private readonly string fileName;

    /// <summary>
    /// Читает данные из CSV файла и возвращает их в виде списка массивов строк.
    /// </summary>
    /// <returns>Список массивов строк, представляющих данные из CSV файла.</returns>
    internal List<string[]> ReadData()
    {
      var data = new List<string[]>();
      using var parser = new TextFieldParser(this.fileName);
      parser.SetDelimiters(",");
      while (!parser.EndOfData)
      {
        var fields = parser.ReadFields();
        if (fields != null)
        {
          data.Add(fields);
        }
      }
      return data;
    }

    internal CsvDataReader(string fileName)
    {
      this.fileName = fileName;
    }
  }
}
