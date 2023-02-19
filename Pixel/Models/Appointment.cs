using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pixel.Models
{
  public class Appointment
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public DateTimeOffset Date { get; set; }

    public DateTimeOffset Time { get; set; }
    //public Provider Provider { get; set; }

  }
}
