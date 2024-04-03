namespace Bakery.Repositories;

using Microsoft.EntityFrameworkCore;
using Bakery.Models;

public class OrderRepository : Repository
{
    public OrderRepository(BakeryContext context) : base(context) { }

    public async Task<Order?> GetOrderById(int id)
    {
        return await Context.Orders.FindAsync(id);
    }

    public async Task<BakingGood[]> ListBakingGoodsForOrder(int orderId)
    {
        return await Context.BakingGoods
            .Where(i => i.OrderBakingGoods.Any(obg => obg.OrderId == orderId))
            .ToArrayAsync();
    }

    public async Task<Packet[]> ListPacketForOrder(int orderId)
    {
        return await Context.Packets
            .Where(i => i.OrderId == orderId)
            .ToArrayAsync();
    }
}
