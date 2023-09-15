using NETPracticalTasks.Models;

namespace NETPracticalTasks.DocumentExport;

public class EncryptionDecorator : IDocumentExporter
{
    private readonly IDocumentExporter exporter;

    public void Export(IEnumerable<IDocument> document, string exportPath)
    {
        this.exporter.Export(document, exportPath);
        Console.WriteLine();
        Console.WriteLine($"------------------------------");
        Console.WriteLine($"Файлы в папке {exportPath} зашифрованы.");
    }

    public EncryptionDecorator(IDocumentExporter exporter)
    {
        this.exporter = exporter;
    }
}
