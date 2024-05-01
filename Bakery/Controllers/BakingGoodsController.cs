using Bakery.Dtos;
using Bakery.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BakingGoodsController : ControllerBase
    {
        private readonly BakingGoodRepository BakingGoodRepository;

        public BakingGoodsController(BakingGoodRepository bakingGoodRepository)
        {
            BakingGoodRepository = bakingGoodRepository;

        }

        [Authorize(Policy = "Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BakingGoodDto>>> GetBakingGoods(string? select)
        {
            var bakingGoods = await BakingGoodRepository.ListBakingGoodsAscending();
            IList<BakingGoodDto> bakingGoodDtos = new List<BakingGoodDto>();
            foreach (var bakingGood in bakingGoods)
            {
                var dto = BakingGoodDto.FromEntity(bakingGood);
                if (select != null) dto.Select(select.Split(','));

                bakingGoodDtos.Add(dto);
            }

            return Ok(bakingGoodDtos);
        }
    }
}
