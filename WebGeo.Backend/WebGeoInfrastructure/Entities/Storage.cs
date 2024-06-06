namespace WebGeoInfrastructure.Entities
{
    public class Storage
    {
        private int id;

        private int localityId;
        private Locality locality;

        private List<ProductStorage> productStorages;
        private List<Product> products;
        private List<Order> orderRestocked;

        public int Id { get { return id; } private set => id = value; }

        public int LocalityId { get { return localityId; } private set => localityId = value; }
        public Locality Locality { get { return locality; } private set => locality = value; }
        public List<ProductStorage> ProductStorages { get { return productStorages; } private set => productStorages = value; }
        public List<Product> Products { get { return products; } private set => products = value; }

        public List<Order> OrderRestocked { get { return orderRestocked; } private set => orderRestocked = value; }
    }
}
