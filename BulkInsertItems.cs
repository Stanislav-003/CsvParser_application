using CsvHelper.Configuration.Attributes;
using CsvParser_App.Entity;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace CsvParser_App;

public static class BulkInsertItems
{
    public static async Task SqlBulkAsync(List<CsvDataFile> processedData)
    {
        using var bulk = new SqlBulkCopy(ApplicationDbContext.ConnectionString);

        bulk.DestinationTableName = "dbo.CsvDataFiles";

        bulk.ColumnMappings.Add(nameof(CsvDataFile.TpepPickupDateTime), "TpepPickupDateTime");
        bulk.ColumnMappings.Add(nameof(CsvDataFile.TpepDropoffDateTime), "TpepDropoffDateTime");
        bulk.ColumnMappings.Add(nameof(CsvDataFile.PassengerCount), "PassengerCount");
        bulk.ColumnMappings.Add(nameof(CsvDataFile.TripDistance), "TripDistance");
        bulk.ColumnMappings.Add(nameof(CsvDataFile.StoreAndFwdFlag), "StoreAndFwdFlag");
        bulk.ColumnMappings.Add(nameof(CsvDataFile.PULocationID), "PULocationID");
        bulk.ColumnMappings.Add(nameof(CsvDataFile.DOLocationID), "DOLocationID");
        bulk.ColumnMappings.Add(nameof(CsvDataFile.FareAmount), "FareAmount");
        bulk.ColumnMappings.Add(nameof(CsvDataFile.TipAmount), "TipAmount");

        try
        {
            var dataTable = GetCsvDataTable(processedData);
            Console.WriteLine($"Записуємо дані в базу, {dataTable.Rows.Count} записів");
            
            await bulk.WriteToServerAsync(dataTable);
            Console.WriteLine("Дані завантажені в БД.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка в SqlBulk: {ex.Message}");
        }
    }

    private static DataTable GetCsvDataTable(List<CsvDataFile> processedData)
    {
        var dataTable = new DataTable();

        dataTable.Columns.Add(nameof(CsvDataFile.TpepPickupDateTime), typeof(DateTimeOffset));
        dataTable.Columns.Add(nameof(CsvDataFile.TpepDropoffDateTime), typeof(DateTimeOffset));
        dataTable.Columns.Add(nameof(CsvDataFile.PassengerCount), typeof(int));
        dataTable.Columns.Add(nameof(CsvDataFile.TripDistance), typeof(double));
        dataTable.Columns.Add(nameof(CsvDataFile.StoreAndFwdFlag), typeof(string));
        dataTable.Columns.Add(nameof(CsvDataFile.PULocationID), typeof(int));
        dataTable.Columns.Add(nameof(CsvDataFile.DOLocationID), typeof(int));
        dataTable.Columns.Add(nameof(CsvDataFile.FareAmount), typeof(decimal));
        dataTable.Columns.Add(nameof(CsvDataFile.TipAmount), typeof(decimal));

        foreach (var csvItem in processedData)
        {
            dataTable.Rows.Add(
                csvItem.TpepPickupDateTime,
                csvItem.TpepDropoffDateTime,
                csvItem.PassengerCount,
                csvItem.TripDistance,
                csvItem.StoreAndFwdFlag,
                csvItem.PULocationID,
                csvItem.DOLocationID,
                csvItem.FareAmount,
                csvItem.TipAmount);
        }

        return dataTable;
    }
}