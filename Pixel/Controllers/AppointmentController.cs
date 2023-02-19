using Microsoft.AspNetCore.Mvc;
using Pixel.Models;
using Pixel.Services;

namespace Pixel.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AppointmentController : ControllerBase
  {
    private readonly AppointmentService _appointmentService;

    private readonly ILogger<AppointmentController> _logger;

    public AppointmentController(ILogger<AppointmentController> logger, AppointmentService appointmentService)
    {
      _logger = logger;
      _appointmentService = appointmentService;
    }

    [HttpGet]
    public async Task<List<Appointment>> Get() => await _appointmentService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Appointment>> Get(string id)
    {
      var appointment = await _appointmentService.GetAsync(id);
      if (appointment == null)
      {
        return NotFound();
      }

      return appointment;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Appointment newAppointment)
    {
      await _appointmentService.CreateAsync(newAppointment);

      return NoContent();
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Appointment updatedAppointment)
    {
      var appointment = await _appointmentService.GetAsync(id);

      if (appointment is null)
      {
        return NotFound();
      }

      updatedAppointment.Id = appointment.Id;

      await _appointmentService.UpdateAsync(id, updatedAppointment);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
      var appointment = await _appointmentService.GetAsync(id);

      if (appointment is null)
      {
        return NotFound();
      }

      await _appointmentService.RemoveAsync(id);

      return NoContent();
    }
  }
}
