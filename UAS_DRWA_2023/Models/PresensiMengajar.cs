using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UAS_DRWA.Models;

public class PresensiMengajar
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("NIP")]
    [JsonPropertyName("NIP")]
    [Required]
    [StringLength(10, MinimumLength = 3)]
    public string NIP { get; set; } = null!;
    
    [Required]
    [StringLength(15, MinimumLength = 2)]
    public string Tgl { get; set; } = null!;
    
    [Required]
    [StringLength(10, MinimumLength = 4)]
    public string Kehadiran { get; set; } = null!;

    [Required]
    [StringLength(10, MinimumLength = 2)]
    public string Kelas { get; set; } = null!;
}