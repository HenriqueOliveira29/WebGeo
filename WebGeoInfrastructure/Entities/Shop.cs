using NetTopologySuite.Geometries;

namespace WebGeoInfrastructure.Entities
{
    public class Shop
    {
        private int id;

        private Geometry location;

        private List<ProductShop> productShop;

        private List<Product> products;
        private List<Order> orders;

        public int Id { get { return id; } private set => id = value; }
        public Geometry Location { get { return location; } private set { location = value; } }
        public List<ProductShop> ProductShop { get { return productShop; } private set => productShop = value; }
        public List<Product> Products { get { return products; } private set => products = value; }
        public List<Order> Orders { get { return orders; } private set => orders = value; }

        public void setLocation(Geometry location)
        {
            this.Location = location;
        }


    }
}
