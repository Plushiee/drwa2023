using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GuruApi.Models;

public class Mapel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id { get; set; }

    [BsonElement("Name")]
    public string mapel { get; set; } = null!;

    public string ruang { get; set; } = null!;

}