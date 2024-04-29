using Bakery.Dtos;
using Bakery.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {

        private readonly LogRepository LogRepository;
        public LogController(LogRepository logRepository)
        {
            LogRepository = logRepository;
        }

        //Rune Add some of the authorization shit here
        [HttpGet]
        public async Task<ActionResult> GetLogs()
        {
            LogRepository.Tester();
            return null;
        }
    }
}
