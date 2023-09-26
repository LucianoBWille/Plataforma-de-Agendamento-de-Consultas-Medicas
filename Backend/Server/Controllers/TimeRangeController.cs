using Domain;
using Microsoft.AspNetCore.Mvc;
// status code
using System.Net;

namespace Server;

[ApiController]
[Route("api/horarios")]
public class TimeRangeController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public TimeRangeController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TimeRange>> GetTimeRanges() {
        return _appDbContext.TimeRanges;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TimeRange>> GetTimeRangeByIdAsync(long id) {
        var timeRange = await _appDbContext.TimeRanges.FindAsync(id);

        if (timeRange == null) {
            return NotFound();
        }

        return Ok(timeRange);
    }

    [HttpPost]
    public async Task<ActionResult<TimeRange>> CreateTimeRangeAsync(
        [FromBody] TimeRange timeRange) {
            if (timeRange == null) {
                return BadRequest("Invalid TimeRange data");
            }

            _appDbContext.TimeRanges.Add(timeRange);
            await _appDbContext.SaveChangesAsync();

            return new ObjectResult(timeRange) { 
                StatusCode = (int) HttpStatusCode.Created
            };
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TimeRange>> UpdateTimeRangeAsync(
        long id, [FromBody] TimeRange timeRange) {
            if (timeRange == null || timeRange.TimeRangeID != id) {
                return BadRequest();
            }

            var timeRangeToUpdate = await _appDbContext.TimeRanges.FindAsync(id);

            if (timeRangeToUpdate == null) {
                return NotFound();
            }

            timeRangeToUpdate.StartTime = timeRange.StartTime;
            timeRangeToUpdate.EndTime = timeRange.EndTime;

            await _appDbContext.SaveChangesAsync();

            return Ok(timeRangeToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TimeRange>> DeleteTimeRangeAsync(long id) {
        var timeRange = await _appDbContext.TimeRanges.FindAsync(id);

        if (timeRange == null) {
            return NotFound();
        }

        _appDbContext.TimeRanges.Remove(timeRange);
        await _appDbContext.SaveChangesAsync();

        return Ok(timeRange);
    }
}