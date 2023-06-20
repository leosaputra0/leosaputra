using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models;

public class PresensiHarianGuru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]

    [Required]
    public string PresensiHarianGuruNIP { get; set; } = null!;

    [Required]
    public string PresensiHarianGuruTgl { get; set; } = null!;

    [Required]
    public string PresensiHarianGuruKehadiran { get; set; } = null!;
}