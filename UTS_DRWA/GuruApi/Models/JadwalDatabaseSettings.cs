namespace GuruApi.Models;

public class JadwalDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string JadwalCollectionName { get; set; } = null!;
}