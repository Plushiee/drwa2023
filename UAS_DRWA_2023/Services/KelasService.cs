using UAS_DRWA.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UAS_DRWA.Services;

public class KelasService
{
    private readonly IMongoCollection<Kelas> _kelasCollection;

    public KelasService(
        IOptions<KelasDatabaseSettings> kelasDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            kelasDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            kelasDatabaseSettings.Value.DatabaseName);

        _kelasCollection = mongoDatabase.GetCollection<Kelas>(
            kelasDatabaseSettings.Value.KelasCollectionName);
    }

    public async Task<List<Kelas>> GetAsync() =>
        await _kelasCollection.Find(_ => true).ToListAsync();

    public async Task<Kelas?> GetAsync(string id) =>
        await _kelasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Kelas newKelas) =>
        await _kelasCollection.InsertOneAsync(newKelas);

    public async Task UpdateAsync(string id, Kelas updatedKelas) =>
        await _kelasCollection.ReplaceOneAsync(x => x.Id == id, updatedKelas);

    public async Task RemoveAsync(string id) =>
        await _kelasCollection.DeleteOneAsync(x => x.Id == id);
}