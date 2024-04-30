using Bakery.Dtos;
using Bakery.Models;
using Bakery.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{

    [Route("v1/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientRepository IngredientRepository;

        private readonly ILogger<IngredientsController> Logger;
        public IngredientsController(IngredientRepository ingredientRepository, ILogger<IngredientsController> logger)
        {
            IngredientRepository = ingredientRepository;
            Logger = logger;
        }

        [Authorize(Policy = "Baker")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetIngredients([FromQuery] string select)
        {
            var ingredients = await IngredientRepository.ListIngredients();

            IList<IngredientDto> ingredientDtos = new List<IngredientDto>();
            foreach (var ingredient in ingredients)
            {
                var dto = new IngredientDto();
                if (select == "Name,Stock")
                {
                    dto.Name = ingredient.Name;
                    dto.Stock = ingredient.Stock;
                }
                else
                {
                    dto = IngredientDto.FromEntity(ingredient);
                }

                ingredientDtos.Add(dto);
            }
            return Ok(ingredientDtos);
        }
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientDto ingredientDto)
        {
            var loginfo = new { UserName = User.Identity?.Name, HttpMethod = HttpContext.Request.Method, Endpoint = HttpContext.Request.Path, Timestamp = DateTime.UtcNow };
            Logger.LogInformation("User {UserName} made a {HttpMethod} request to {Endpoint} at {Timestamp}", loginfo.UserName, loginfo.HttpMethod, loginfo.Endpoint, loginfo.Timestamp);

            if (ingredientDto == null)
            {
                return BadRequest("Ingredient data is missing from request body");
            }
            if (ingredientDto.Quantity < 0)
            {
                return BadRequest("Quantity cannot be negative");
            }

            // Create new ingredient from dto data and save it to the database
            Ingredient ingredient = new Ingredient
            {
                Name = ingredientDto.Name,
                Stock = ingredientDto.Quantity,
            };
            await IngredientRepository.CreateIngredient(ingredient);
            return Ok(IngredientDto.FromEntity(ingredient));
        }
        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, [FromBody] UpdateIngredientDto ingredientDto)
        {
            var loginfo = new { UserName = User.Identity?.Name, HttpMethod = HttpContext.Request.Method, Endpoint = HttpContext.Request.Path, Timestamp = DateTime.UtcNow };
            Logger.LogInformation("User {UserName} made a {HttpMethod} request to {Endpoint} at {Timestamp}", loginfo.UserName, loginfo.HttpMethod, loginfo.Endpoint, loginfo.Timestamp);

            if (ingredientDto == null) return BadRequest("Ingredient data missing from request body");
            if (ingredientDto.Quantity < 0) return BadRequest("Quantity cannot be negative");

            // Make sure ingredient exists
            Ingredient? ingredient = await IngredientRepository.GetIngredientById(id);
            if (ingredient == null) return NotFound("Ingredient not found");

            // Update ingredient with new data
            if (ingredientDto.Name != null) ingredient.Name = ingredientDto.Name;
            if (ingredientDto.Quantity != null) ingredient.Stock = ingredientDto.Quantity.Value;

            // Save changes to the database
            await IngredientRepository.UpdateIngredient(ingredient);

            return Ok(IngredientDto.FromEntity(ingredient));
        }
        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var loginfo = new { UserName = User.Identity?.Name, HttpMethod = HttpContext.Request.Method, Endpoint = HttpContext.Request.Path, Timestamp = DateTime.UtcNow };
            Logger.LogInformation("User {UserName} made a {HttpMethod} request to {Endpoint} at {Timestamp}", loginfo.UserName, loginfo.HttpMethod, loginfo.Endpoint, loginfo.Timestamp);
            // Make sure ingredient exists
            Ingredient? ingredient = await IngredientRepository.GetIngredientById(id);
            if (ingredient == null) return NotFound("Ingredient not found");

            // Delete ingredient from the database
            await IngredientRepository.DeleteIngredient(ingredient);

            return Ok(IngredientDto.FromEntity(ingredient));
        }
    }
}
