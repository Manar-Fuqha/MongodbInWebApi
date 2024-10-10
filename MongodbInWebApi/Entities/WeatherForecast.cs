
using MongoDB.Bson.Serialization.Attributes;
namespace MongodbInWebApi.Entities
{
    public class WeatherForecast
    {
        public Guid Id { get; set; }

        [BsonElement("Data")]
        public DateOnly Date { get; set; }

        [BsonElement("Temperature_C")]
        public int TemperatureC { get; set; }
        [BsonElement("Temperature_F")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        [BsonElement("Summary")]
        public string? Summary { get; set; }
    }
}
