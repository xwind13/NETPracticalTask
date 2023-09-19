using NETPracticalTasks.Models;

namespace NETPracticalTasks.DocumentExport;

public interface IDocumentExporter
{
    void Export(IEnumerable<IDocument> documents, string exportPath);
}
