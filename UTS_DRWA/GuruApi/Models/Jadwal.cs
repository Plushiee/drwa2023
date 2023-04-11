using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GuruApi.Models;

public class Jadwal
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? idJadwal { get; set; }
    public string? NIP { get; set; }

    [BsonElement("kelas")]
    
    public string kelas { get; set; } = null!;

    public string jadwalMapel { get; set; } = null!;
}