using NETPracticalTasks.ExternalLibraries;
using NETPracticalTasks.Models;

namespace NETPracticalTasks.DocumentExport;

public class EncryptionDecorator : IDocumentExporter
{
    private readonly IDocumentExporter exporter;
    private readonly Encoder encoder;

    public void Export(IEnumerable<IDocument> documents, string exportPath)
    {
        this.exporter.Export(documents, exportPath);

        foreach (var document in documents)
        {
            var fileNames = new List<string>();
            if (document is CompositeDocument composite)
                fileNames.AddRange(composite.FileDocuments.Select(f => f.Name));
            else
                fileNames.Add(document.Name);

            this.encoder.Encode(exportPath, fileNames);
        }

        Console.WriteLine();
        Console.WriteLine($"------------------------------");
        Console.WriteLine($"Файлы в папке {exportPath} зашифрованы.");
    }

    public EncryptionDecorator(IDocumentExporter exporter)
    {
        this.exporter = exporter;
        this.encoder = new Encoder();
    }
}
