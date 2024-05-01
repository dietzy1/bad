using Bakery.Dtos;
using Bakery.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("v1/[controller]")]
    [ApiController]
    public class LogController(LogRepository logRepository) : ControllerBase
    {

        private readonly LogRepository LogRepository = logRepository;



        //Add query parameters to filter logs, like timestamp range, user, and HTTP method
        [HttpGet]
        public async Task<ActionResult> GetLogs(DateTime? startTimestamp, DateTime? endTimestamp, string user, string httpMethod)
        {
            var logs = await LogRepository.GetLogs(startTimestamp, endTimestamp, user, httpMethod);
            return Ok(logs);


        }
    }
}
