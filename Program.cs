using CsvParser_App;

var processedData = await CsvDataProcessor.ProcessCsvAsync();

await BulkInsertItems.SqlBulkAsync(processedData);