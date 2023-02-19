using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Pixel.Enums;

namespace Pixel.Models
{
  public class Provider
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public Modality Modality { get; set; }
    public string ProviderNumber { get; set; } = null!;
  }
}
