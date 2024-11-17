using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderAPI.Domains;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _orderCollection;
        public OrderController()
        {
            var dbhost = "localhost";
            var dbname = "dms_order";
            var connectionStr = $"mongodb://{dbhost}:27017/{dbname}";
            var mongoUrl = MongoUrl.Create(connectionStr);
            var mongoClient = new MongoClient(mongoUrl);
            var db = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            _orderCollection = db.GetCollection<Order>("order");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return await _orderCollection.Find(Builders<Order>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId, id);
            return await _orderCollection.Find(filter).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Order order)
        {
            await _orderCollection.InsertOneAsync(order);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Order order)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId, order.OrderId);
            await _orderCollection.ReplaceOneAsync(filter, order);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId, id);
            await _orderCollection.DeleteOneAsync(filter);
            return Ok();
        }
    }
}
