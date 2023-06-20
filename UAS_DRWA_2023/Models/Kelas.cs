using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UAS_DRWA.Models;

public class Kelas
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Nama")]
    [JsonPropertyName("Nama")]
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Nama { get; set; } = null!;
}