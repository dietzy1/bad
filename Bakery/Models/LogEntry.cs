using MongoDB.Bson.Serialization.Attributes;


namespace Bakery.Models
{

    [BsonIgnoreExtraElements]
    public class LogEntry
    {


        [BsonElement("Level")]
        public string? Level { get; set; }


        [BsonElement("Properties")]

        public LogProperties? Properties { get; set; }

    }
}

