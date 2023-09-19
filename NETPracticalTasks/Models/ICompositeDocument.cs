namespace NETPracticalTasks.Models;

public interface ICompositeDocument : IDocument
{
    IReadOnlyList<IDocument> Documents { get; }

    IReadOnlyList<IDocument> FileDocuments { get; }

    event Action<IDocument> FileDocumentAdded;

    void AddDocument(IDocument document);
}
