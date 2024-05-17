

namespace WebGeoInfrastructure.DTOs.Client
{
    public class ClientListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ClientListDTO(WebGeoInfrastructure.Entities.Client client)
        {
            this.Id = client.Id;
            this.Name = client.Name;
        }
    }
}
