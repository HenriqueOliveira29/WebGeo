namespace WebGeoInfrastructure.DTOs.Client
{
    public class ClientInsertDTO
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public Entities.Client toEntity()
        {
            Entities.Client client = new Entities.Client();
            client.SetValues(this.Name, this.Address);
            return client;
        }
    }
}
