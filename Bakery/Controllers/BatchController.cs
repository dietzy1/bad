using Bakery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly BakeryContext _context;
        public BatchController(BakeryContext context)
        {
            _context = context;
        }
    }
}
