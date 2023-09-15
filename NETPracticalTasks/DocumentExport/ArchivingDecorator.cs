using NETPracticalTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NETPracticalTasks.DocumentExport
{
    public class ArchivingDecorator : IDocumentExporter
    {
        private readonly IDocumentExporter exporter;
        public void Export(IEnumerable<IDocument> documents, string exportPath)
        {
            this.exporter.Export(documents, exportPath);
            Console.WriteLine();
            Console.WriteLine($"------------------------------");
            foreach (var document in documents)
            {
                Console.WriteLine($"Файлы в папке {exportPath} упакованы в архив с именем \"{document.Name}\" .");
            }
            
        }

        public ArchivingDecorator(IDocumentExporter exporter)
        {
            this.exporter = exporter;
        }
    }
}
