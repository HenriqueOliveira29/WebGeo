using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.DTOs.Product
{
    public class ProductListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Quantity { get; set; }

        public ProductListDTO(ProductOrder productOrder)
        {
            this.Id = productOrder.ProductId;
            this.Name = productOrder.Product.Name;
            this.Description = productOrder.Product.Description;
            this.Quantity = productOrder.Quantity;
        }
    }
}
