using Bakery.Dtos;
using Bakery.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Exception = System.Exception;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bakery.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("v1/[controller]")]
    [ApiController]
    public class LogController(LogRepository logRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogEntry>>> GetLogs(string userId = null, DateTime? startTime = null, DateTime? endTime = null, string operationType = null)
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

[BsonIgnoreExtraElements]
public class LogEntry
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; }
    [BsonElement("Timestamp")]
    public DateTime Timestamp { get; set; }
    [BsonElement("Operation Type")]
    public string OperationType { get; set; }
    [BsonElement("Endpoint")]
    public string Endpoint { get; set; }
}