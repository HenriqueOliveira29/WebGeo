namespace WebGeoInfrastructure.DTOs.Product
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public Entities.Product toEntity()
        {
            var product = new Entities.Product();
            product.SetValues(this.Name, this.Description, this.Price);
            return product;
        }
    }
}
