using System.Runtime.Loader;

namespace ConsoleApp1
{
  internal class PracticalTask2
  {
    #region  Константы

    private const string AssemblyPath = "C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\6.0.15\\mscorlib.dll";
    private const string TypeName = "System.Collections.Hashtable";
    private const string OutputFilePath = "test2.txt";

    #endregion

    #region Методы

    public void Process()
    {
      Type? type = LoadType();
      if (type == null)
        return;

      using var stream = new StreamWriter(OutputFilePath);
      PrintInterfaces(type, stream);
      PrintAttributes(type, stream);
    }

    private static void PrintAttributes(Type type, StreamWriter stream)
    {
      foreach (var attribute in type.CustomAttributes)
      {
        stream.WriteLine(attribute.AttributeType.Name);
      }
    }

    private static void PrintInterfaces(Type type, StreamWriter stream)
    {
      foreach (var interfaceType in type.GetInterfaces())
      {
        stream.WriteLine(interfaceType.Name);
      }
    }

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
