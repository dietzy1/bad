//using BakeryAPI.Data;
//using BakeryAPI.Models;
using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace RestExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        [HttpPost]
        public void SeedData()
        {



        }
    }
}