using Bakery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly BakeryContext _context;
        public BatchController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/ingredients")]
        public IActionResult GetIngredientsOfBatch(int id)
        {
            return Ok();
        }

        [HttpGet("average_delay")]
        public IActionResult GetAverageDelay()
        {
            return Ok();
        }
    }
}
