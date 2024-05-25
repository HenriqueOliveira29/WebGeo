namespace WebGeoInfrastructure.DTOs.Shop
{
    public class CreateShopDTO
    {
        public double x { get; set; }
        public double y { get; set; }

        public Entities.Shop toEntity()
        {
            var shop = new Entities.Shop();
            return shop;
        }
    }


}
