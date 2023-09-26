using Domain;
using Microsoft.AspNetCore.Mvc;
// status code
using System.Net;

namespace Server;

[ApiController]
[Route("api/consultas")]
public class ConsultationController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public ConsultationController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Consultation>> GetConsultations() {
        return _appDbContext.Consultations;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Consultation>> GetConsultationByIdAsync(long id) {
        var consultation = await _appDbContext.Consultations.FindAsync(id);

        if (consultation == null) {
            return NotFound();
        }

        return Ok(consultation);
    }

    [HttpPost]
    public async Task<ActionResult<Consultation>> CreateConsultationAsync(
        [FromBody] Consultation consultation) {
            if (consultation == null) {
                return BadRequest("Invalid Consultation data");
            }

            _appDbContext.Consultations.Add(consultation);
            await _appDbContext.SaveChangesAsync();

            return new ObjectResult(consultation) { 
                StatusCode = (int) HttpStatusCode.Created
            };
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Consultation>> UpdateConsultationAsync(
        long id, [FromBody] Consultation consultation) {
            if (consultation == null || consultation.ConsultationID != id) {
                return BadRequest();
            }

            var consultationToUpdate = await _appDbContext.Consultations.FindAsync(id);

            if (consultationToUpdate == null) {
                return NotFound();
            }

            consultationToUpdate.Doctor = consultation.Doctor;
            consultationToUpdate.Patient = consultation.Patient;
            consultationToUpdate.Receptionist = consultation.Receptionist;
            consultationToUpdate.dateTime = consultation.dateTime;
            consultationToUpdate.Observations = consultation.Observations;
            consultationToUpdate.ConsultationType = consultation.ConsultationType;

            await _appDbContext.SaveChangesAsync();

            return Ok(consultationToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Consultation>> DeleteConsultationAsync(long id) {
        var consultation = await _appDbContext.Consultations.FindAsync(id);

        if (consultation == null) {
            return NotFound();
        }

        _appDbContext.Consultations.Remove(consultation);
        await _appDbContext.SaveChangesAsync();

        return Ok(consultation);
    }
}