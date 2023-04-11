using GuruApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GuruApi.Services;

public class JadwalService
{
    private readonly IMongoCollection<Guru> _guruCollection;

    public JadwalService(
        IOptions<GuruDatabaseSettings> guruDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            guruDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            guruDatabaseSettings.Value.DatabaseName);

        _guruCollection = mongoDatabase.GetCollection<Guru>(
            guruDatabaseSettings.Value.GuruCollectionName);
    }

    public async Task<List<Guru>> GetAsync() =>
        await _guruCollection.Find(_ => true).ToListAsync();

    public async Task<Guru?> GetAsync(string id) =>
        await _guruCollection.Find(x => x.nip == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Guru newGuru) =>
        await _guruCollection.InsertOneAsync(newGuru);

    public async Task UpdateAsync(string id, Guru updatedGuru) =>
        await _guruCollection.ReplaceOneAsync(x => x.nip == id, updatedGuru);

    public async Task RemoveAsync(string id) =>
        await _guruCollection.DeleteOneAsync(x => x.nip == id);
}