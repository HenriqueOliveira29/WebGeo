using WebGeoInfrastructure.DTOs.Order;

namespace WebGeoInfrastructure.DTOs.Client
{
    public class ClientDetailDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<OrderListDTO> Orders { get; set; }

        public ClientDetailDTO()
        {

        }

        public ClientDetailDTO(Entities.Client client)
        {
            this.Id = client.Id;
            this.Name = client.Name;
            this.Address = client.Address;
            if (client.Orders != null)
            {
                this.Orders = client.Orders.Select(t => new OrderListDTO(t)).ToList();
            }
            else
            {
                this.Orders = new List<OrderListDTO>();
            }
        }
    }
}
