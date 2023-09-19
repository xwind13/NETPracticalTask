using System.Text;

namespace NETPracticalTasks.Models;

public class CompositeDocument : Document, ICompositeDocument
{

    private readonly List<IDocument> documents;
    public IReadOnlyList<IDocument> Documents =>  this.documents;

    private readonly List<IDocument> fileDocuments;

    public event Action<IDocument> FileDocumentAdded;

    public IReadOnlyList<IDocument> FileDocuments => this.fileDocuments;

    public override string GetDescription(int indent = 0)
    {
        var sb = new StringBuilder();
        sb.Append(base.GetDescription(indent));
        foreach(var document in this.documents)
            sb.Append(document.GetDescription(indent + 1));

        return sb.ToString();
    }

    public void AddDocument(IDocument document)
    {
       this.documents.Add(document);
        if (document is ICompositeDocument compositeDocument)
        {
            compositeDocument.FileDocumentAdded += FileDocumentAddedEventHandler;
            this.fileDocuments.AddRange(compositeDocument.FileDocuments);
        }
        else
        {
            this.fileDocuments.Add(document);
            this.FileDocumentAdded?.Invoke(document);
        }
    }

    private void FileDocumentAddedEventHandler(IDocument document)
    {
        this.fileDocuments.Add(document);
        this.FileDocumentAdded?.Invoke(document);
    }

    public CompositeDocument(int id, string name) : base(id, name)
    {
        this.documents = new List<IDocument>();
        this.fileDocuments = new List<IDocument>();
    }
}
