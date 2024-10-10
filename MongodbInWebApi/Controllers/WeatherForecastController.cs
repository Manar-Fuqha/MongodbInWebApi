using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongodbInWebApi.Data;
using MongodbInWebApi.Entities;

namespace MongodbInWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(AppDbContext dbContext) : ControllerBase
    {
        [HttpGet]        
        public async Task<IActionResult> GetList()
        {
            return Ok(await dbContext.WeatherForecast.Find(Builders<WeatherForecast>.Filter.Empty).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            var allData = await dbContext.WeatherForecast.Find(Builders<WeatherForecast>.Filter.Empty).ToListAsync();
            return Ok(allData.FirstOrDefault(w=>w.Id==id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] WeatherForecast weatherForecast)
        {
            weatherForecast.Id = Guid.NewGuid();
            await dbContext.WeatherForecast.InsertOneAsync(weatherForecast);
            return Ok(weatherForecast);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WeatherForecast weatherForecast)
        {
            await dbContext.WeatherForecast.ReplaceOneAsync(w => w.Id == weatherForecast.Id, weatherForecast);
            return Ok(weatherForecast);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await dbContext.WeatherForecast.DeleteOneAsync(w => w.Id == id);
            return NoContent(); 
        }
    }
}
