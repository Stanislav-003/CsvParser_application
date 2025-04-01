using CsvHelper.Configuration;
using CsvHelper;
using CsvParser_App.Entity;
using System.Globalization;

namespace CsvParser_App;

public static class CsvWriterHelper
{
    private static readonly string DUPLICATES_FILE_PATH = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "duplicates.csv");

    public static async Task WriteDuplicatesAsync(List<CsvDataFile> duplicates)
    {
        if (!File.Exists(DUPLICATES_FILE_PATH))
            throw new FileNotFoundException($"Файл {DUPLICATES_FILE_PATH} не знайдений");

        await using var writer = new StreamWriter(DUPLICATES_FILE_PATH);
        await using var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ","
        });

        await csvWriter.WriteRecordsAsync(duplicates);
        Console.WriteLine($"Записано {duplicates.Count} дублікатів в {DUPLICATES_FILE_PATH}");
    }
}
