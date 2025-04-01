using CsvHelper.Configuration;
using CsvHelper;
using CsvParser_App.Entity;
using System.Globalization;

namespace CsvParser_App;

public static class CsvDataProcessor
{
    public static async Task<List<CsvDataFile>> ProcessCsvAsync()
    {
        var allRecords = await CsvParser.ParseCsvAsync();
        var seenKeys = new HashSet<(DateTimeOffset, DateTimeOffset, int)>();
        var uniqueRecords = new List<CsvDataFile>();
        var duplicateRecords = new List<CsvDataFile>();

        foreach (var record in allRecords)
        {
            record.StoreAndFwdFlag = record.StoreAndFwdFlag.Trim();
            record.StoreAndFwdFlag = record.StoreAndFwdFlag.Trim().ToUpper() == "N" ? "No" : "Yes";
            var estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            record.TpepPickupDateTime = TimeZoneInfo.ConvertTimeToUtc(record.TpepPickupDateTime.DateTime, estZone);
            record.TpepDropoffDateTime = TimeZoneInfo.ConvertTimeToUtc(record.TpepDropoffDateTime.DateTime, estZone);

            var key = (record.TpepPickupDateTime, record.TpepDropoffDateTime, record.PassengerCount);
            
            if (!seenKeys.Add(key)) // повертає false, якщо клює уже є
            {
                duplicateRecords.Add(record);
                continue;
            }

            uniqueRecords.Add(record);
        }

        Console.WriteLine(
                    $"Знайдено {uniqueRecords.Count} унікальних записів. \n" +
                    $"Знайдено {duplicateRecords.Count} записів дублікатві.");

        // запис дублікатів
        if (duplicateRecords.Any())
        {
            await CsvWriterHelper.WriteDuplicatesAsync(duplicateRecords);
        }

        return uniqueRecords;
    }
}