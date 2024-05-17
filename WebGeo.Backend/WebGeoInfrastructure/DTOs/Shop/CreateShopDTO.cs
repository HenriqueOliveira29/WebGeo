using WebGeoInfrastructure.Helpers;

namespace WebGeoInfrastructure.DTOs.Shop
{
    public class CreateShopDTO
    {
        public double x { get; set; }
        public double y { get; set; }

        public Entities.Shop toEntity()
        {
            var shop = new Entities.Shop();
            shop.setLocation(GeometryConverter.convertToGeometry(x, y));
            return shop;
        }
    }


}
