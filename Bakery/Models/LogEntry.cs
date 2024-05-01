
namespace Bakery.Models
{

    [BsonIgnoreExtraElements]
    public class LogEntry
    {
        [BsonElement("UserName")]
        public string UserName { get; set; }

        [BsonElement("HttpMethod")]
        public string HttpMethod { get; set; }

        [BsonElement("Endpoint")]
        public string Endpoint { get; set; }

        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}