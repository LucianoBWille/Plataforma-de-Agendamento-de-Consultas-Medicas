using Domain;
using Microsoft.AspNetCore.Mvc;
// status code
using System.Net;

namespace Server;

[ApiController]
[Route("api/medicos")]
public class DoctorController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public DoctorController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Doctor>> GetDoctors() {
        return _appDbContext.Doctors;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Doctor>> GetDoctorByIdAsync(long id) {
        var doctor = await _appDbContext.Doctors.FindAsync(id);

        if (doctor == null) {
            return NotFound();
        }

        return Ok(doctor);
    }

    [HttpPost]
    public async Task<ActionResult<Doctor>> CreateDoctorAsync(
        [FromBody] Doctor doctor) {
            if (doctor == null) {
                return BadRequest("Invalid Doctor data");
            }

            // para cada AvaliableHour verificar se existe um horário com o mesmo id e se os dados são válidos (não nulos)
            foreach (var availableHour in doctor.AvailableHours) {
                if (availableHour == null) {
                    return BadRequest("Invalid AvailableHour data");
                }

                var availableHourToCheck = await _appDbContext.TimeRanges.FindAsync(availableHour.TimeRangeID);
                if (availableHourToCheck == null) {
                    // tentar criar o horário e relacionar com o médico, caso não retorne erro finalizar a criação do médico
                    if (availableHour.StartTime == null) {
                        return BadRequest("Invalid TimeRange data");
                    }
                    if (availableHour.EndTime == null) {
                        return BadRequest("Invalid TimeRange data");
                    }
                    var availableHourToCreate = new TimeRange {
                        // get max id from availableHours + 1 for new id
                        TimeRangeID = _appDbContext.TimeRanges.Max(a => a.TimeRangeID) + 1,
                        StartTime = availableHour.StartTime,
                        EndTime = availableHour.EndTime
                    };
                    // criar horário
                    _appDbContext.TimeRanges.Add(availableHourToCreate);
                    await _appDbContext.SaveChangesAsync();
                    // relacionar horário com o médico
                    availableHour.TimeRangeID = availableHourToCreate.TimeRangeID;
                }else{
                    // verificar se o horário do médico é o mesmo que o horário encontrado
                    if (availableHour.TimeRangeID != availableHourToCheck.TimeRangeID) {
                        return BadRequest("Invalid TimeRange data");
                    }
                    if(DateTime.Compare(availableHour.StartTime, availableHourToCheck.StartTime) != 0) {
                        return BadRequest("Invalid TimeRange data");
                    }
                    if(DateTime.Compare(availableHour.EndTime, availableHourToCheck.EndTime) != 0) {
                        return BadRequest("Invalid TimeRange data");
                    }
                }
            }

            // verificar se a especialidade existe
            if (doctor.Specialty == null) {
                return BadRequest("Invalid Specialty data");
            }

            // criar especialidade caso não exista e validar se os dados da especialidade são válidos
            var specialty = await _appDbContext.Specialties.FindAsync(doctor.Specialty.SpecialtyID);
            if (specialty == null) {
                // tentar criar a especialidade e relacionar com o médico, caso não retorne erro finalizar a criação do médico
                if (doctor.Specialty.SpecialtyName == null || doctor.Specialty.SpecialtyName == "") {
                    return BadRequest("Invalid Specialty data");
                }
                var specialtyToCreate = new Specialty {
                    // get max id from specialties + 1 for new id
                    SpecialtyID = _appDbContext.Specialties.Max(s => s.SpecialtyID) + 1,
                    SpecialtyName = doctor.Specialty.SpecialtyName,
                    Description = doctor.Specialty.Description
                };
                // criar especialidade
                _appDbContext.Specialties.Add(specialtyToCreate);
                await _appDbContext.SaveChangesAsync();
                // relacionar especialidade com o médico
                doctor.Specialty = specialtyToCreate;

            }else{
                // verificar se a especialidade do médico é a mesma que a especialidade encontrada
                if (doctor.Specialty.SpecialtyID != specialty.SpecialtyID) {
                    return BadRequest("Invalid Specialty data");
                }
                if (doctor.Specialty.SpecialtyName != specialty.SpecialtyName) {
                    return BadRequest("Invalid Specialty data");
                }
                if (doctor.Specialty.Description != specialty.Description) {
                    return BadRequest("Invalid Specialty data");
                }
            }

            _appDbContext.Doctors.Add(doctor);
            await _appDbContext.SaveChangesAsync();

            return new ObjectResult(doctor) { 
                StatusCode = (int) HttpStatusCode.Created
            };
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Doctor>> UpdateDoctorAsync(
        long id, [FromBody] Doctor doctor) {
            if (doctor == null || doctor.DoctorID != id) {
                return BadRequest();
            }

            var doctorToUpdate = await _appDbContext.Doctors.FindAsync(id);

            if (doctorToUpdate == null) {
                return NotFound();
            }

            doctorToUpdate.Name = doctor.Name;
            doctorToUpdate.ProfesssionalRegistrationNumber = doctor.ProfesssionalRegistrationNumber;
            doctorToUpdate.Specialty = doctor.Specialty;

            await _appDbContext.SaveChangesAsync();

            return Ok(doctorToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Doctor>> DeleteDoctorAsync(long id) {
        var doctor = await _appDbContext.Doctors.FindAsync(id);

        if (doctor == null) {
            return NotFound();
        }

        _appDbContext.Doctors.Remove(doctor);
        await _appDbContext.SaveChangesAsync();

        return Ok(doctor);
    }
}