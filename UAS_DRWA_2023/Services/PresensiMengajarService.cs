using UAS_DRWA.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UAS_DRWA.Services;

public class PresensiMengajarService
{
    private readonly IMongoCollection<PresensiMengajar> _presensiMengajarCollection;

    public PresensiMengajarService(
        IOptions<PresensiMengajarDatabaseSettings> presensiMengajarDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            presensiMengajarDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            presensiMengajarDatabaseSettings.Value.DatabaseName);

        _presensiMengajarCollection = mongoDatabase.GetCollection<PresensiMengajar>(
            presensiMengajarDatabaseSettings.Value.PresensiMengajarCollectionName);
    }

    public async Task<List<PresensiMengajar>> GetAsync() =>
        await _presensiMengajarCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiMengajar?> GetAsync(string id) =>
        await _presensiMengajarCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiMengajar newPresensiMengajar) =>
        await _presensiMengajarCollection.InsertOneAsync(newPresensiMengajar);

    public async Task UpdateAsync(string id, PresensiMengajar updatedPresensiMengajar) =>
        await _presensiMengajarCollection.ReplaceOneAsync(x => x.Id == id, updatedPresensiMengajar);

    public async Task RemoveAsync(string id) =>
        await _presensiMengajarCollection.DeleteOneAsync(x => x.Id == id);
}