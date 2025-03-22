using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;


class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\n📖 Your journal is empty!\n");
            return;
        }

        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToCsv(string filename)
    {
        
        try
        {
            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true // Write headers
            }))
            {
                csv.WriteRecords(_entries);
            }
            Console.WriteLine("\n✅ Journal successfully saved to CSV!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error saving file: {ex.Message}");
        }
    }

    public void LoadFromCsv(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("\n❌ File not found. Please check the filename and try again.\n");
            return;
        }

        try
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                _entries = new List<Entry>(csv.GetRecords<Entry>());
            }
            Console.WriteLine("\n✅ Journal successfully loaded from CSV!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error loading file: {ex.Message}");
        }
    }
}
