namespace WebGeoInfrastructure.DTOs.Storage
{
    public class StorageListDTO
    {
        public int Id { get; set; }

        public string Localization { get; set; }

        public StorageListDTO()
        {

        }

        public StorageListDTO(int id, string localization)
        {
            this.Id = id;
            this.Localization = localization;
        }
    }
}
