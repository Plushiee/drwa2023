using GuruApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GuruApi.Services;

public class JadwalService
{
    private readonly IMongoCollection<Jadwal> _jadwalCollection;

    public JadwalService(
        IOptions<JadwalDatabaseSettings> jadwalDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            jadwalDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            jadwalDatabaseSettings.Value.DatabaseName);

        _jadwalCollection = mongoDatabase.GetCollection<Jadwal>(
            jadwalDatabaseSettings.Value.JadwalCollectionName);
    }

    public async Task<List<Jadwal>> GetAsync() =>
        await _jadwalCollection.Find(_ => true).ToListAsync();

    public async Task<Jadwal?> GetAsync(string id) =>
        await _jadwalCollection.Find(x => x.idJadwal == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Jadwal newJadwal) =>
        await _jadwalCollection.InsertOneAsync(newJadwal);

    public async Task UpdateAsync(string id, Jadwal updatedJadwal) =>
        await _jadwalCollection.ReplaceOneAsync(x => x.idJadwal == id, updatedJadwal);

    public async Task RemoveAsync(string id) =>
        await _jadwalCollection.DeleteOneAsync(x => x.idJadwal == id);
}