using WebGeoInfrastructure.DTOs.Product;

namespace WebGeoInfrastructure.DTOs.Order
{
    public class CreateOrderDTO
    {
        public int CliendId { get; set; }

        public int ShopId { get; set; }

        public DateTime DateDeliver { get; set; }

        public List<ProductListDTO> Products { get; set; }
    }
}
