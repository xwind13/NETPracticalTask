using NETPracticalTasks.Models;

namespace NETPracticalTasks.Storages;

public class FileStorage
{
    public static IEnumerable<IDocument> GetDocuments()
    {
        var composite1 = new CompositeDocument(1, "Комплект 1");
        composite1.AddDocument(new FileDocument(2, "Документ 1"));
        composite1.AddDocument(new FileDocument(3, "Документ 2"));

        var composite2 = new CompositeDocument(4, "Комплект 2");
        composite2.AddDocument(composite1);
        composite2.AddDocument(new FileDocument(5, "Документ 3"));

        return new List<IDocument> { composite2 };
    }
}
