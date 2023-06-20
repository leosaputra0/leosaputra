using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models;

public class PresensiMengajar
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]

    [Required]
    public string PresensiMengajarNIP { get; set; } = null!;

    [Required]
    public string PresensiMengajarTgl { get; set; } = null!;

    [Required]
    public string PresensiMengajarKehadiran { get; set; } = null!;

    // [JsonPropertyName("Name")]
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string PresensiMengajarKelas { get; set; } = null!;
}