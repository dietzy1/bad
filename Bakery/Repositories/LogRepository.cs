
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Serilog;


namespace Bakery.Repositories;

public class LogRepository
{
    private readonly IMongoCollection<LogEntry> _logCollection;

    public LogRepository(string connectionString)
    {
        var mongoUrl = new MongoUrl(connectionString);
        var databaseName = mongoUrl.DatabaseName;
        
        var client = new MongoClient(mongoUrl);
        var database = client.GetDatabase(databaseName);
        _logCollection = database.GetCollection<LogEntry>("logs");

    }

    //Filter for specific user, timeInterval, and type of operation, post, put, delete
    public async Task<IEnumerable<LogEntry>> GetLogs(string userId = null!, DateTime? startTime = null, DateTime? endTime = null, string operationType = null)
    {
        var builder = Builders<LogEntry>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrEmpty(userId))
        {
            filter &= builder.Eq(le => le.UserId, userId);
        }

        if (startTime.HasValue && endTime.HasValue)
        {
            filter &= builder.Gte(le => le.TimeStamp, startTime.Value);
            filter &= builder.Lte(le => le.TimeStamp, endTime.Value);
        }

        if (!string.IsNullOrEmpty(operationType))
        {
            filter &= builder.Eq(le => le.OperationType, operationType);
        }

        return await _logCollection.Find(filter).ToListAsync();
    }
}
