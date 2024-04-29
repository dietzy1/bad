using Bakery.Models;
using MongoDB.Driver;

namespace Bakery.Repositories;

public abstract class Repository
{
    protected readonly BakeryContext Context;

    public Repository(BakeryContext context)
    {
        Context = context;
    }
}
