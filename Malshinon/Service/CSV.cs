using System.IO;
using System;
using Utils;
using Malshinon.Dal;
using Malshinon.Utiles;
using Malshinon.Moduls;


namespace Malshinon.Service
{
    public static class CsvImporter // Wrap in a static class
    {
        public static void ImportCsv() // Make it a public static method
        {
            Console.Write("Please enter CSV file path: ");
            var path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                Console.WriteLine("File not found.\n");
                return;
            }

            int count = 0;
            try
            {
                using var reader = new StreamReader(path);
                string? header = reader.ReadLine();
                if (header == null)
                {
                    Console.WriteLine("CSV is empty.\n");
                    return;
                }
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(',');
                    if (parts.Length < 4)
                    {
                        Console.WriteLine($"Warning: Skipping invalid row (less than 4 parts): {line}");
                        continue;
                    }

                    var reporter = parts[0].Trim();
                    var target = parts[1].Trim();
                    var text = parts[2].Trim();

                    // Removed the stray 'a' from here
                    if (!DateTime.TryParse(parts[3].Trim(), null, System.Globalization.DateTimeStyles.AssumeLocal, out var ts))
                    {
                        Console.WriteLine($"Warning: Skipping row with invalid date format: {line}");
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(reporter) || string.IsNullOrWhiteSpace(target) || string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine($"Warning: Skipping row with empty required fields: {line}");
                        continue;
                    }

                    int reporterId = PeopleDAL.GetOrCreatePerson(reporter);
                    int targetId = PeopleDAL.GetOrCreatePerson(target);
                    ReportsDAL.InsertReport(reporterId, targetId, text, ts);
                    count++;
                    AlertsDAL.CheckAndTriggerAlerts(targetId);
                }
                Logger.Log($"CSVImport: Imported {count} reports from {path}");
                Console.WriteLine($"Imported {count} reports.\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error while reading the file: {ex.Message}\n");
                Logger.Log($"CSVImport Error: IOException reading file {path} - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}\n");
                Logger.Log($"CSVImport Error: Unexpected error - {ex.Message}");
            }
        }
    }
}