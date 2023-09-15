namespace NETPracticalTasks.Models;

public interface ICompositeDocument : IDocument
{
    IReadOnlyList<IDocument> Documents { get; }


    void AddDocument(IDocument document);
}
