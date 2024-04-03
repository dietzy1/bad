

using Microsoft.EntityFrameworkCore;

namespace Bakery.Models;

public class OrderBakingGood
{
    public int OrderId { get; set; }
    public int BakingGoodId { get; set; }
    public int Quantity { get; set; }
    public Order Order { get; set; } = null!;
    public BakingGood BakingGood { get; set; } = null!;
}