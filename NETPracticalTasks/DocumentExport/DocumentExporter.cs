using NETPracticalTasks.Models;

namespace NETPracticalTasks.DocumentExport;

public class DocumentExporter : IDocumentExporter
{
    public void Export(IEnumerable<IDocument> documents, string exportPath)
    {
        this.ExportDocuments(documents, exportPath);

        Console.WriteLine();
        Console.WriteLine($"------------------------------");

        foreach(var document in documents)
        {
            Console.WriteLine("Описание экспортированного документа");
            Console.Write(document.GetDescription(1));
        }
    }

    private void ExportDocuments(IEnumerable<IDocument> documents, string exportPath)
    {
        foreach (var document in documents)
        {
            if (document is ICompositeDocument composite)
            {
                this.ExportDocuments(composite.FileDocuments, exportPath);
            }
            else
            {
                this.ExportDocument(document, exportPath);
            }
        }
    }

    private void ExportDocument(IDocument document, string exportPath)
    {
        Console.WriteLine($"Документ {document.Name} экспортирован в папку {exportPath}");
    }
}
