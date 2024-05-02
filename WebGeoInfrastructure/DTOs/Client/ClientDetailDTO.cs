using WebGeoInfrastructure.DTOs.Order;

namespace WebGeoInfrastructure.DTOs.Client
{
    public class ClientDetailDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<OrderListDTO> Orders { get; set; }
    }
}
