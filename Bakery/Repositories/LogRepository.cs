using MongoDB.Driver;
using Bakery.Models;
using MongoDB.Bson;
using NuGet.Protocol;

namespace Bakery.Repositories;

public class LogRepository
{
    private MongoClient _client;

    public LogRepository(string connectionString)
    {
        Console.WriteLine(connectionString);
        var mongoUrl = new MongoUrl(connectionString);
        _client = new MongoClient(mongoUrl);
    }

    //Filter for specific user, timeInterval, and type of operation, post, put, delete
    public async Task<IEnumerable<LogEntry>> GetLogs(string userName = "", DateTime? startTime = null, DateTime? endTime = null, string operationType = "")
    {
        var db = _client.GetDatabase("bakery");
        var collection = db.GetCollection<LogEntry>("logs_202405");

        //Get all logs using find
        var Results = collection.FindAsync(new BsonDocument()).Result.ToList();
        //decode the results
        foreach (var result in Results)
        {
            Console.WriteLine(result.ToJson());
        }



        var builder = Builders<LogEntry>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrEmpty(userName))
        {
            filter &= builder.Eq(le => le.Properties.UserName, userName);

        }
        if (startTime.HasValue && endTime.HasValue)
        {
            //Find all timestamps inbetween the timeinterval of startTime and endTime
            filter &= builder.Gte(le => le.Properties.Timestamp, startTime.Value);
            filter &= builder.Lte(le => le.Properties.Timestamp, endTime.Value);
        }
        if (!string.IsNullOrEmpty(operationType))
        {
            filter &= builder.Eq(le => le.Properties.HttpMethod, operationType);
        }

        Console.WriteLine($"Generated Filter: {filter.ToJson()}");


        return await collection.Find(filter).ToListAsync();
    }
}





