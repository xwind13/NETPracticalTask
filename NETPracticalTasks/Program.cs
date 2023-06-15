// See https://aka.ms/new-console-template for more information
using CityDataProcessing;
using System.Reflection;

var csvFilePath = Path.Combine(Environment.CurrentDirectory, "Книга1.csv");
var reportPath = Path.Combine(Environment.CurrentDirectory, "report.txt");
CityDataProcessor.GenerateReportFromCsvFle(csvFilePath, reportPath);
