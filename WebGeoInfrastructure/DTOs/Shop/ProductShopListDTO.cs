namespace WebGeoInfrastructure.DTOs.Shop
{
    public class ProductShopListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Stock { get; set; }

        public ProductShopListDTO(int id, string name, string desc, float stock)
        {
            this.Id = id;
            this.Name = name;
            this.Description = desc;
            this.Stock = stock;
        }
    }
}
