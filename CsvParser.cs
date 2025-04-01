using CsvHelper.Configuration;
using CsvHelper;
using CsvParser_App.Entity;
using System.Globalization;

namespace CsvParser_App;

public static class CsvParser
{
    private static readonly string CSV_FILE_PATH = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "sample-cab-data.csv"); 

    public static async Task<List<CsvDataFile>> ParseCsvAsync()
    {
        if (!File.Exists(CSV_FILE_PATH))
            throw new FileNotFoundException($"Файл {CSV_FILE_PATH} не знайдений");

        Console.WriteLine($"Починається парсинг CSV-файлу: {CSV_FILE_PATH}");

        using var reader = new StreamReader(CSV_FILE_PATH);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ",",
            BadDataFound = null,
            MissingFieldFound = null

            // можна пропускати рекорди з пустими властивостями, але ставлю просто дефолтне значення для типу
            //ShouldSkipRecord = row => string.IsNullOrWhiteSpace(row.Row.GetField("passenger_count"))
        });

        var records = await Task.Run(() => csv.GetRecords<CsvDataFile>().ToList());

        Console.WriteLine(
                    $"Парсинг завершено! \n" +
                    $"Усіх записів {records.Count} з файлу {CSV_FILE_PATH}");

        return records;
    }
}
