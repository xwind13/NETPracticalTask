using NETPracticalTasks.ExternalLibraries;
using NETPracticalTasks.Models;

namespace NETPracticalTasks.DocumentExport
{
    public class ArchivingDecorator : IDocumentExporter
    {
        private readonly IDocumentExporter exporter;
        private readonly Archivator archivator;
        public void Export(IEnumerable<IDocument> documents, string exportPath)
        {
            this.exporter.Export(documents, exportPath);
            Console.WriteLine();
            Console.WriteLine($"------------------------------");

            foreach (var document in documents)
            {
                var fileNames = new List<string>();
                if (document is CompositeDocument composite)
                    fileNames.AddRange(composite.FileDocuments.Select(f => f.Name));
                else
                    fileNames.Add(document.Name);

                this.archivator.Zip(exportPath, document.Name, fileNames);
                Console.WriteLine($"Файлы в папке {exportPath} упакованы в архив с именем \"{document.Name}\" .");
            }
            
        }

        public ArchivingDecorator(IDocumentExporter exporter)
        {
            this.exporter = exporter;
            this.archivator = new Archivator();
        }
    }
}
