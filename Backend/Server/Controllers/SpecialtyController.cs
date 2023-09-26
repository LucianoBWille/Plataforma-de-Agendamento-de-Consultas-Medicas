using Domain;
using Microsoft.AspNetCore.Mvc;
// status code
using System.Net;

namespace Server;

[ApiController]
[Route("api/especialidades")]
public class SpecialtyController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public SpecialtyController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Specialty>> GetSpecialties() {
        return _appDbContext.Specialties;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Specialty>> GetSpecialtyByIdAsync(long id) {
        var specialty = await _appDbContext.Specialties.FindAsync(id);

        if (specialty == null) {
            return NotFound();
        }

        return Ok(specialty);
    }

    [HttpPost]
    public async Task<ActionResult<Specialty>> CreateSpecialtyAsync(
        [FromBody] Specialty specialty) {
            if (specialty == null) {
                return BadRequest("Invali Specialty data");
            }

            _appDbContext.Specialties.Add(specialty);
            await _appDbContext.SaveChangesAsync();

            return new ObjectResult(specialty) { 
                StatusCode = (int) HttpStatusCode.Created
            };
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Specialty>> UpdateSpecialtyAsync(
        long id, [FromBody] Specialty specialty) {
            if (specialty == null || specialty.SpecialtyID != id) {
                return BadRequest();
            }

            var specialtyToUpdate = await _appDbContext.Specialties.FindAsync(id);

            if (specialtyToUpdate == null) {
                return NotFound();
            }

            specialtyToUpdate.SpecialtyName = specialty.SpecialtyName;
            specialtyToUpdate.Description = specialty.Description;

            await _appDbContext.SaveChangesAsync();

            return Ok(specialtyToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Specialty>> DeleteSpecialtyAsync(long id) {
        var specialtyToDelete = await _appDbContext.Specialties.FindAsync(id);

        if (specialtyToDelete == null) {
            return NotFound();
        }

        _appDbContext.Specialties.Remove(specialtyToDelete);
        await _appDbContext.SaveChangesAsync();

        return Ok(specialtyToDelete);
    }
}