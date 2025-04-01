using CsvHelper.Configuration.Attributes;

namespace CsvParser_App.Entity;

public class CsvDataFile
{
    [Ignore]
    public int Id { get; set; }
    
    [Name("tpep_pickup_datetime")]
    public DateTimeOffset TpepPickupDateTime { get; set; }
    
    [Name("tpep_dropoff_datetime")]
    public DateTimeOffset TpepDropoffDateTime { get; set; }
    
    [Name("passenger_count")]
    [Default(0)]
    public int PassengerCount { get; set; } 
    
    [Name("trip_distance")]
    public double TripDistance { get; set; }

    [Name("store_and_fwd_flag")]
    public string StoreAndFwdFlag { get; set; } = string.Empty;

    [Name("PULocationID")]
    public int PULocationID { get; set; }

    [Name("DOLocationID")]
    public int DOLocationID { get; set; }

    [Name("fare_amount")]
    public decimal FareAmount { get; set; }

    [Name("tip_amount")]
    public decimal TipAmount { get; set; }
}
