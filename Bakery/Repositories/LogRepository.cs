using MongoDB.Driver;
using Bakery.Models;

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


        var stuff = collection.Find(_ => true);
        var count = stuff.CountDocuments();
        Console.WriteLine("number of documents found: " + count);

        //return await stuff.ToListAsync();

        var builder = Builders<LogEntry>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrEmpty(userName))
        {
            filter &= builder.Eq(le => le.UserName, userName);

        }
        if (startTime.HasValue && endTime.HasValue)
        {
            //Find all timestamps inbetween the timeinterval of startTime and endTime
            filter &= builder.Gte(le => le.Timestamp, startTime.Value);
            filter &= builder.Lte(le => le.Timestamp, endTime.Value);
        }
        if (!string.IsNullOrEmpty(operationType))
        {
            filter &= builder.Eq(le => le.HttpMethod, operationType);
        }

        var logs = await collection.Find(filter).ToListAsync();
        return logs;
    }
}





