using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GuruApi.Models;

public class Mapel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? idMapel { get; set; }

    [BsonElement("namaMapel")]
    public string namaMapel { get; set; } = null!;

    public string semester { get; set; } = null!;

}