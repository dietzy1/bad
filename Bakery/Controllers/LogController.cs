using Bakery.Dtos;
using Bakery.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Exception = System.Exception;

namespace Bakery.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("v1/[controller]")]
    [ApiController]
    public class LogController(LogRepository logRepository) : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> GetLogs(string userId = null, DateTime? startTime = null, DateTime? endTime = null, string operationType = null)
       {
           try
           {
               var logs = await logRepository.GetLogs(userId, startTime, endTime, operationType);
               return Ok(logs);
           }
           catch (Exception ex)
           {
               return StatusCode(500, ex.Message);
           }
       }
    }
}



//We need to add this somewhere idk DTO? Models to filter out shit
public class LogEntry
{
    public string UserId { get; set; }
    public DateTime TimeStamp { get; set; }
    public string OperationType { get; set; }
}