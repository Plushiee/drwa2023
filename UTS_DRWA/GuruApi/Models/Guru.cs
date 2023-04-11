using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GuruApi.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? NIP { get; set; }

    [BsonElement("nama")]

    public string nama { get; set; } = null!;

    public string asal { get; set; } = null!;
}