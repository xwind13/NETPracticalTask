namespace NETPracticalTasks.Models;

public interface IDocument
{
    int Id { get; }
    string Name { get; set; }
    string GetDescription(int indent = 0);
}
