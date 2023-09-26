using Domain;
using Microsoft.AspNetCore.Mvc;
// status code
using System.Net;

namespace Server;

[ApiController]
[Route("api/pacientes")]
public class PatientController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public PatientController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Patient>> GetPatients() {
        return _appDbContext.Patients;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatientByIdAsync(long id) {
        var patient = await _appDbContext.Patients.FindAsync(id);

        if (patient == null) {
            return NotFound();
        }

        return Ok(patient);
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> CreatePatientAsync(
        [FromBody] Patient patient) {
            if (patient == null) {
                return BadRequest("Invalid Patient data");
            }

            _appDbContext.Patients.Add(patient);
            await _appDbContext.SaveChangesAsync();

            return new ObjectResult(patient) { 
                StatusCode = (int) HttpStatusCode.Created
            };
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Patient>> UpdatePatientAsync(
        long id, [FromBody] Patient patient) {
            if (patient == null || patient.PatientID != id) {
                return BadRequest();
            }

            var patientToUpdate = await _appDbContext.Patients.FindAsync(id);

            if (patientToUpdate == null) {
                return NotFound();
            }

            patientToUpdate.FirstName = patient.FirstName;
            patientToUpdate.LastName = patient.LastName;
            patientToUpdate.IdentificationNumber = patient.IdentificationNumber;

            await _appDbContext.SaveChangesAsync();

            return Ok(patientToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Patient>> DeletePatientAsync(long id) {
        var patient = await _appDbContext.Patients.FindAsync(id);

        if (patient == null) {
            return NotFound();
        }

        _appDbContext.Patients.Remove(patient);
        await _appDbContext.SaveChangesAsync();

        return Ok(patient);
    }
}