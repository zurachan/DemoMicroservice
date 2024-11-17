using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderAPI.Domains
{
    [Serializable, BsonIgnoreExtraElements]
    public class OrderDetail
    {
        [BsonRepresentation(BsonType.Int32)]
        public int ProductId { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Quantity { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal UnitPrice { get; set; }
    }
}
