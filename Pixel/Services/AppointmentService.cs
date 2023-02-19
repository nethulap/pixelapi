using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pixel.Models;

namespace Pixel.Services
{
  public class AppointmentService
  {
    private readonly IMongoCollection<Appointment> _appointmentCollection;

    public AppointmentService(
        IOptions<DatabaseSettings> dabaseSettings)
    {
      var mongoClient = new MongoClient(dabaseSettings.Value.ConnectionString);

      var mongoDatabase = mongoClient.GetDatabase(dabaseSettings.Value.DatabaseName);

      _appointmentCollection = mongoDatabase.GetCollection<Appointment>("Appointment");
    }

    public async Task<List<Appointment>> GetAsync() =>
        await _appointmentCollection.Find(_ => true).ToListAsync();

    public async Task<Appointment?> GetAsync(string id) =>
        await _appointmentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Appointment newAppointment) =>
        await _appointmentCollection.InsertOneAsync(newAppointment);

    public async Task UpdateAsync(string id, Appointment updatedAppointment) =>
        await _appointmentCollection.ReplaceOneAsync(x => x.Id == id, updatedAppointment);

    public async Task RemoveAsync(string id) => await _appointmentCollection.DeleteOneAsync(x => x.Id == id);
  }
}
