// See https://aka.ms/new-console-template for more information
using NETPracticalTasks.DocumentExport;
using NETPracticalTasks.Storages;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var documents = FileStorage.GetDocuments();

IDocumentExporter exporter = new DocumentExporter();

// Get user input for encryption and archiving options
Console.Write("Хотите ли зашифровать экспортированные документы? (y/n): ");
var encryptOption = Console.ReadLine().Trim().ToLower() == "y";

Console.Write("Хотите ли заархивировать экспортированные документы? (y/n): ");
var archiveOption = Console.ReadLine().Trim().ToLower() == "y";

if (encryptOption)
{
    exporter = new EncryptionDecorator(exporter);
}

if (archiveOption)
{
    exporter = new ArchivingDecorator(exporter);
}

Console.Write("Введите имя папки для экспорта: ");
var exportFolder = Console.ReadLine();
exporter.Export(documents, exportFolder);