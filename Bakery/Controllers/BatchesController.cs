using Bakery.Dtos;
using Bakery.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly BatchRepository BatchRepository;
        private readonly IngredientRepository IngredientRepository;

        public BatchesController(BatchRepository batchRepository, IngredientRepository ingredientRepository)
        {
            BatchRepository = batchRepository;
            IngredientRepository = ingredientRepository;
        }

        [HttpGet("{id}/Ingredients")]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetIngredientsOfBatch(int id)
        {
            // Make sure batch exists
            if (await BatchRepository.GetBatchById(id) == null) return NotFound("Batch not found");

            // Get ingredients of batch and transform it into a DTO
            var ingredients = await IngredientRepository.ListIngredientsInBatch(id);

            IList<IngredientDto> ingredientDtos = new List<IngredientDto>();
            foreach (var ingredient in ingredients)
            {
                var dto = IngredientDto.FromEntity(ingredient);
                dto.Select(new string[] { "Name", "Stock", "Allergens" });

                ingredientDtos.Add(dto);
            }

            return Ok(ingredientDtos);
        }

        [HttpGet("AverageDelay")]
        public async Task<IActionResult> GetAverageDelay()
        {
            double? averageDelay = await BatchRepository.GetAverageDelay();
            if (averageDelay == null) return NotFound("No batches found");

            return Ok(AverageDelayDto.FromDelay(averageDelay.Value));
        }
    }
}
