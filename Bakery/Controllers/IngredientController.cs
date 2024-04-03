using Bakery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Bakery.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly BakeryContext _context;
        public IngredientController(BakeryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetIngredients(string select)
        {
            try
            {
                IEnumerable<Ingredient> ingredients = _context.Ingredients;

                if (string.IsNullOrEmpty(select))
                {
                    return Ok(ingredients);
                }

                var selectedIngredients = new List<object>();
                foreach (var ingredient in ingredients)
                {
                    var selectedProperties = new Dictionary<string, object>();
                    var properties = select.Split(',');
                    foreach (var property in properties)
                    {
                        switch (property.Trim().ToLower())
                        {
                            case "name":
                                selectedProperties["Name"] = ingredient.Name;
                                break;
                            case "quantity":
                                selectedProperties["Quantity"] = ingredient.Stock;
                                break;
                        }
                    }
                    selectedIngredients.Add(selectedProperties);
                }

                return Ok(selectedIngredients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
