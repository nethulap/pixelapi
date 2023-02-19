using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pixel.Models
{
  public class Patient
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
  }
}
