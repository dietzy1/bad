
using MongoDB.Driver;
using System.Threading.Tasks;
using Bakery.Models;

namespace Bakery.Repositories;

public class LogRepository(string connectionString)
{
    private readonly MongoClient Client = new MongoClient(connectionString);

    //Filter for specific user, timeInterval, and type of operation, post, put, delete
    public async Task<LogEntry[]> Tester()
    {
        var collection = Client.GetDatabase("bakery").GetCollection<LogEntry>("logs");
        var filter = Builders<LogEntry>.Filter.Empty;
        return await collection
    }
}
