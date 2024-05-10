namespace WebGeoInfrastructure.DTOs.Storage
{
    public class AddProductToStorageDTO
    {
        public int StorageId { get; set; }
        public int ProductId { get; set; }
        public float quantity { get; set; }
    }
}
