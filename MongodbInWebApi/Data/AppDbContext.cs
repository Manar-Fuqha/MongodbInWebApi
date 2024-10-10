using MongoDB.Driver;
using MongodbInWebApi.Entities;

namespace MongodbInWebApi.Data
{
    public class AppDbContext
    {
        private readonly IMongoDatabase mongoDatabase;
        public AppDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Mongodb");
            var databaseName = configuration.GetConnectionString("DatabaseName");

            var client = new MongoClient(connectionString);
            mongoDatabase = client.GetDatabase(databaseName);
        }

        public IMongoCollection<WeatherForecast> WeatherForecast =>
            mongoDatabase.GetCollection<WeatherForecast>("WeatherForecastList");
    }
}
