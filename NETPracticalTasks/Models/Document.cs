using System.Text;

namespace NETPracticalTasks.Models;

public abstract class Document : IDocument
{
    public int Id { get; private set; }

    public string Name { get; set; }

    public virtual string GetDescription(int indent = 0) {
        var sb = new StringBuilder();
        sb.Append(' ', indent * 2);
        sb.AppendLine(this.Name);
        return sb.ToString();
    }

    public Document(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
