namespace WebGeoInfrastructure.DTOs.Storage
{
    public class CreateStorageDTO
    {
        public double x { get; set; }
        public double y { get; set; }

        public Entities.Storage toEntity()
        {
            var storage = new Entities.Storage();
            return storage;
        }
    }
}
