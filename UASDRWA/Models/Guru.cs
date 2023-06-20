using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    // [JsonPropertyName("Name")]
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string GuruName { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string GuruKelas { get; set; } = null!;

    [Required]
    public string GuruNIP { get; set; } = null!;
}