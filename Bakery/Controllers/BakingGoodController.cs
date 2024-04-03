using Bakery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BakingGoodController : ControllerBase
    {
        private readonly BakeryContext _context;
        public BakingGoodController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBakingGoods(string select)
        {
            try
            {
                IEnumerable<BakingGood> bakingGoods = _context.BakingGoods;

                if (string.IsNullOrEmpty(select))
                {
                    return Ok(bakingGoods);
                }

                var selectedBakingGoods = new List<object>();
                foreach (var bakingGood in bakingGoods)
                {
                    var selectedProperties = new Dictionary<string, object>();
                    var properties = select.Split(',');
                    foreach (var property in properties)
                    {
                        switch (property.Trim().ToLower())
                        {
                            case "name":
                                selectedProperties["Name"] = bakingGood.BakingGoodName;
                                break;
                            case "totalquantityordered":
                                selectedProperties["Total Quantity Ordered"] = bakingGood.TotalQuantityOrdered;
                                break;
                        }
                    }

                    selectedBakingGoods.Add(selectedProperties);
                }

                return Ok(selectedBakingGoods);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
