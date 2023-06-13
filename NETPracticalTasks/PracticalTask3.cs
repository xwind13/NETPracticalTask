using Microsoft.VisualBasic.FileIO;

namespace ConsoleApp1
{
  public class PracticalTask3
  {
    #region Константы

    private const int MinCount = 100000;
    private const string OutputFilePath = "test3.txt";

    #endregion

    #region Свойства и поля

    private readonly string fileName;
    private readonly List<string> cities;

    #endregion

    #region Методы

    public void Process()
    {
      this.ExtractRequiredCities();
      this.PrintResult();
    }

    private void ExtractRequiredCities()
    {
      using var parser = new TextFieldParser(this.fileName);
      parser.SetDelimiters(",");
      while (!parser.EndOfData)
      {
        var fields = parser.ReadFields();
        if (fields == null || fields.Length < 2)
          continue;

        var city = fields[0].Trim('"');
        if (int.TryParse(fields[1], out int count) && count > MinCount)
        {
          this.cities.Add(city);
        }
      }
    }

    private void PrintResult()
    {
      using var stream = new StreamWriter(OutputFilePath);
      foreach (var city in this.cities.OrderBy(c=> c))
      {
        stream.WriteLine(city);
      }
    }

    #endregion

    #region Конструктор

    public PracticalTask3(string fileName)
    {
      this.fileName = fileName;
      this.cities = new List<string>();
    }

    #endregion
  }
}
