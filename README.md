# CsvParser_application
Щоб запустити програму локально потрібно:
1) Клонуйте або завантажте репозиторій на свій комп'ютер.
2) Додайте файл sample-cab-data.csv до вашого проекту в Solution Explorer. Цей файл містить дані для парсингу.
3) Перевірте строку підключення: Відкрийте клас ApplicationDbContext і перевірте, чи співпадає строка підключення до бази даних з вашою конфігурацією. Строка підключення має вигляд: public const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=CsvParserDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"; змініть її відповідно до вашого середовища або залиште як є.
4) Виконайте оновлення бази даних через Package Manager Console: update-database, або за допомогою .NET CLI: dotnet ef database update. Це створить базу даних CsvParserDb у вашому SQL Server (MSSQL) та необхідну таблицю CsvDataFiles чи через .net cli "dotnet ef database update". ця міграція створить базу даних CsvParserDb в MSSQL з необхідною таблицею
5) Запустіть додаток комбінацією клавіш Ctrl+F5 (або натиснувши кнопку "Run" у вашому IDE).
