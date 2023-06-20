using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UAS_DRWA.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Nama")]
    [JsonPropertyName("Nama")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nama { get; set; } = null!;
    
    [Required]
    [StringLength(10, MinimumLength = 5)]
    public string Kelas { get; set; } = null!;

    [Required]
    [StringLength(10, MinimumLength = 6)]
    public string NIP { get; set; } = null!;
}