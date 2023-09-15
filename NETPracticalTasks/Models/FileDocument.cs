namespace NETPracticalTasks.Models;

public class FileDocument : Document, IDocument
{
    public FileDocument(int id, string name) : base(id, name)
    {
    }
}
