using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GuruApi.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? nip { get; set; }
    public string? idMapel { get; set; }

    [BsonElement("Name")]
    public string Nama { get; set; } = null!;

    public string Mapel { get; set; } = null!;

    public string JadwalGuru { get; set; } = null!;
}