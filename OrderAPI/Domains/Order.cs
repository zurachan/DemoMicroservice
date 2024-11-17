using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderAPI.Domains
{
    [Serializable, BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public long OrderId { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int CustomerId { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
