using WebGeoInfrastructure.Helpers;

namespace WebGeoInfrastructure.DTOs.Shop
{
    public class CreateShopDTO
    {
        public double x { get; set; }
        public double y { get; set; }

        public Entities.Shop toEntity()
        {

            return new Entities.Shop() { Location = GeometryConverter.convertToGeometry(x, y) };
        }
    }


}
