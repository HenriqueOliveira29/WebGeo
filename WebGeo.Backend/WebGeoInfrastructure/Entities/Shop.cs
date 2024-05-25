namespace WebGeoInfrastructure.Entities
{
    public class Shop
    {
        private int id;

        private int localityId;

        private Locality locality;

        private List<ProductShop> productShop;

        private List<Product> products;
        private List<Order> orders;

        public int Id { get { return id; } private set => id = value; }
        public int LocalityId { get { return localityId; } private set => localityId = value; }
        public Locality Locality { get { return locality; } private set => locality = value; }
        public List<ProductShop> ProductShop { get { return productShop; } private set => productShop = value; }
        public List<Product> Products { get { return products; } private set => products = value; }
        public List<Order> Orders { get { return orders; } private set => orders = value; }

    }
}
