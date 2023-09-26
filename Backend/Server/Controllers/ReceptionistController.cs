using Domain;
using Microsoft.AspNetCore.Mvc;
// status code
using System.Net;

namespace Server;

[ApiController]
[Route("api/recepcionistas")]
public class ReceptionistController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public ReceptionistController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Receptionist>> GetReceptionists() {
        return _appDbContext.Receptionists;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Receptionist>> GetReceptionistByIdAsync(long id) {
        var receptionist = await _appDbContext.Receptionists.FindAsync(id);

        if (receptionist == null) {
            return NotFound();
        }

        return Ok(receptionist);
    }

    [HttpPost]
    public async Task<ActionResult<Receptionist>> CreateReceptionistAsync(
        [FromBody] Receptionist receptionist) {
            if (receptionist == null) {
                return BadRequest("Invalid Receptionist data");
            }

            _appDbContext.Receptionists.Add(receptionist);
            await _appDbContext.SaveChangesAsync();

            return new ObjectResult(receptionist) { 
                StatusCode = (int) HttpStatusCode.Created
            };
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Receptionist>> UpdateReceptionistAsync(
        long id, [FromBody] Receptionist receptionist) {
            if (receptionist == null || receptionist.ReceptionistID != id) {
                return BadRequest();
            }

            var receptionistToUpdate = await _appDbContext.Receptionists.FindAsync(id);

            if (receptionistToUpdate == null) {
                return NotFound();
            }

            receptionistToUpdate.FirstName = receptionist.FirstName;
            receptionistToUpdate.LastName = receptionist.LastName;
            receptionistToUpdate.IdentificationNumber = receptionist.IdentificationNumber;
            receptionistToUpdate.TelephoneNumber = receptionist.TelephoneNumber;

            await _appDbContext.SaveChangesAsync();

            return Ok(receptionistToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Receptionist>> DeleteReceptionistAsync(long id) {
        var receptionist = await _appDbContext.Receptionists.FindAsync(id);

        if (receptionist == null) {
            return NotFound();
        }

        _appDbContext.Receptionists.Remove(receptionist);
        await _appDbContext.SaveChangesAsync();

        return Ok(receptionist);
    }
}