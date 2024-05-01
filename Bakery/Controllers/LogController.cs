using Bakery.Dtos;
using Bakery.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Exception = System.Exception;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Bakery.Models;

namespace Bakery.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("v1/[controller]")]
    [ApiController]
    public class LogController(LogRepository logRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogEntry>>> GetLogs(string username = "", DateTime? startTime = null, DateTime? endTime = null, string operationType = "")
        {
            Console.WriteLine($"UserName: {username}, StartTime: {startTime}, EndTime: {endTime}, OperationType: {operationType}");

            try
            {
                var logs = await logRepository.GetLogs(username, startTime, endTime, operationType);



                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}