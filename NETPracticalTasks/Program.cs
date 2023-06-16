// See https://aka.ms/new-console-template for more information

using MetadataExtraction;

var outputFilePath = Path.Combine(Environment.CurrentDirectory, "output.txt");
HashtableTypeMetadataExtractor.Process(outputFilePath);
