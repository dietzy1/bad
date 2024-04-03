using Bakery.Models;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Repositories;

public class BatchRepository : Repository {
    public BatchRepository(BakeryContext dbContext) : base(dbContext) { }

    public async Task<Batch?> GetBatchById(int id) {
        return await Context.Batches.FindAsync(id);
    }

    public async Task<double?> GetAverageDelay() {
        var batches = await Context.Batches.ToListAsync();
        return batches.Average(b => b.Delay);
    }
}
