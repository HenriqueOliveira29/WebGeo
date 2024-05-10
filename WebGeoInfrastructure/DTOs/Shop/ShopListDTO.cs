namespace WebGeoInfrastructure.DTOs.Shop
{
    public class ShopListDTO
    {
        public int Id { get; set; }

        public string Localization { get; set; }

        public ShopListDTO()
        {

        }

        public ShopListDTO(int id, string localization)
        {
            this.Id = id;
            this.Localization = localization;
        }
    }
}
