
using MongoDB.Driver;


namespace Bakery.Repositories;

public class LogRepository(string connectionString)
{
    private readonly MongoClient Client = new MongoClient(connectionString);

    //Filter for specific user, timeInterval, and type of operation, post, put, delete
    public async void Tester()
    {
        System.Console.WriteLine("Hello");
        return;
    }
}
