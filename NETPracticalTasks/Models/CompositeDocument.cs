using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETPracticalTasks.Models;

public class CompositeDocument : Document, ICompositeDocument
{

    private readonly List<IDocument> documents;
    public IReadOnlyList<IDocument> Documents =>  this.documents;

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
    }

    public CompositeDocument(int id, string name) : base(id, name)
    {
        this.documents = new List<IDocument>();
    }
}
