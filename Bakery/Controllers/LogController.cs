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

        //Rune Add some of the authorization shit here
        /*    [HttpGet]
           public async Task<ActionResult> GetLogs()
           {
               LogRepository.Tester();
               return null;
           } */
    }
}



//We need to add this somewhere idk DTO? Models to filter out shit
public class LogEntry
{

}