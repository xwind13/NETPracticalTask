using System.Runtime.Loader;

namespace MetadataExtraction
{
  /// <summary>
  /// Извлечение метаданных объекта типа "System.Collections.Hashtable" (список интрфейсов и аттрибутов)
  /// </summary>
  internal class HashtableTypeMetadataExtractor
  {
    #region  Константы

    /// <summary>
    /// Путь к файлу сборки.
    /// </summary>
    private const string AssemblyPath = "C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\6.0.15\\mscorlib.dll";

    /// <summary>
    /// Название объекта типа.
    /// </summary>
    private const string TypeName = "System.Collections.Hashtable";

    #endregion

    #region Методы

    /// <summary>
    /// Извлечение имен интерфейсов и аттрибутов из класса System.Collections.Hashtable в файл.
    /// </summary>
    /// <param name="outputFilePath"></param>
    internal static void Process(string outputFilePath)
    {
      var type = LoadType();
      if (type == null)
        return;

      using var stream = new StreamWriter(outputFilePath);
      PrintInterfaces(type, stream);
      PrintAttributes(type, stream);
    }

    /// <summary>
    /// Записать имена аттрибутов объекта типа в поток записи.
    /// </summary>
    /// <param name="type">Объект типа.</param>
    /// <param name="stream">Поток записи.</param>
    private static void PrintAttributes(Type type, StreamWriter stream)
    {
      foreach (var attribute in type.CustomAttributes)
      {
        stream.WriteLine(attribute.AttributeType.Name);
      }
    }

    /// <summary>
    /// Записать имена интерфейсов объекта типа в поток записи.
    /// </summary>
    /// <param name="type">Объект типа.</param>
    /// <param name="stream">Поток записи.</param>
    private static void PrintInterfaces(Type type, StreamWriter stream)
    {
      foreach (var interfaceType in type.GetInterfaces())
      {
        stream.WriteLine(interfaceType.Name);
      }
    }

    /// <summary>
    /// Загрузить объект типа из файла сборки.
    /// </summary>
    /// <returns>Объект типа.</returns>
    private static Type? LoadType()
    {
      var context = new AssemblyLoadContext(name: "Test", isCollectible: true);
      var assembly = context.LoadFromAssemblyPath(AssemblyPath);
      var type = assembly.GetType(TypeName);
      return type;
    }

    #endregion
  }
}
