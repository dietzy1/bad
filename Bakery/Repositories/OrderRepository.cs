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

    public async Task<IDictionary<string, int>> ListBakingGoodsForOrderWithQuantities(int orderId)
    {
        return await Context.OrderBakingGoods
            .Where(obg => obg.OrderId == orderId)
            .ToDictionaryAsync(obg => obg.BakingGood.BakingGoodName, obg => obg.Quantity);
    }

    public async Task<Packet[]> ListPacketForOrder(int orderId)
    {
        return await Context.Packets
            .Where(i => i.OrderId == orderId)
            .ToArrayAsync();
    }
}
