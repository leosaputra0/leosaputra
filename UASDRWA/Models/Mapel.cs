using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models;

public class Mapel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    // [JsonPropertyName("Name")]
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string MapelName { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string MapelKelas { get; set; } = null!;

}