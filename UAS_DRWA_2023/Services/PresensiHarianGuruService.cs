using UAS_DRWA.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UAS_DRWA.Services;

public class PresensiHarianGuruService
{
    private readonly IMongoCollection<PresensiHarianGuru> _presensiHarianGuruCollection;

    public PresensiHarianGuruService(
        IOptions<PresensiHarianGuruDatabaseSettings> presensiHarianGuruDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            presensiHarianGuruDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            presensiHarianGuruDatabaseSettings.Value.DatabaseName);

        _presensiHarianGuruCollection = mongoDatabase.GetCollection<PresensiHarianGuru>(
            presensiHarianGuruDatabaseSettings.Value.PresensiHarianGuruCollectionName);
    }

    public async Task<List<PresensiHarianGuru>> GetAsync() =>
        await _presensiHarianGuruCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiHarianGuru?> GetAsync(string id) =>
        await _presensiHarianGuruCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiHarianGuru newPresensiHarianGuru) =>
        await _presensiHarianGuruCollection.InsertOneAsync(newPresensiHarianGuru);

    public async Task UpdateAsync(string id, PresensiHarianGuru updatedPresensiharianGuru) =>
        await _presensiHarianGuruCollection.ReplaceOneAsync(x => x.Id == id, updatedPresensiharianGuru);

    public async Task RemoveAsync(string id) =>
        await _presensiHarianGuruCollection.DeleteOneAsync(x => x.Id == id);
}