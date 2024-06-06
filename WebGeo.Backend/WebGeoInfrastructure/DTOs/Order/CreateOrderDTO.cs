namespace WebGeoInfrastructure.DTOs.Order
{
    public class CreateOrderDTO
    {
        public int CliendId { get; set; }

        public int ShopId { get; set; }

        public DateTime DateDeliver { get; set; }

        public List<ProductCreateOrder> Products { get; set; }
    }

    public class ProductCreateOrder
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
