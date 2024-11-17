using OrderAPI.Domains;

namespace OrderAPI.Dto
{
    public class OrderDto
    {
        public long OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
