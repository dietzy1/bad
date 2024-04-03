namespace Bakery.Repositories;

using Microsoft.EntityFrameworkCore;
using Bakery.Models;

public class BakingGoodRepository : Repository
{
    public BakingGoodRepository(BakeryContext context) : base(context) { }

    public async Task<BakingGood[]> ListBakingGoodsAscending()
    {
        return await Context.BakingGoods.OrderBy(bg => bg.BakingGoodName).ToArrayAsync();
    }

    public async Task<BakingGood[]> ListBakingGoodsForOrder(int orderId)
    {
        return await Context.BakingGoods
            .Where(i => i.OrderBakingGoods.Any(obg => obg.OrderId == orderId))
            .ToArrayAsync();
    }
}
