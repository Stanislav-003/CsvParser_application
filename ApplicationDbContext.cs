using CsvParser_App.Entity;
using Microsoft.EntityFrameworkCore;

namespace CsvParser_App;

public class ApplicationDbContext : DbContext
{
    public const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=CsvParserDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public DbSet<CsvDataFile> CsvDataFiles { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CsvDataFile>().HasKey(cdf => cdf.Id);
        modelBuilder.Entity<CsvDataFile>().Property(cdf => cdf.Id).ValueGeneratedOnAdd();
    }
}
