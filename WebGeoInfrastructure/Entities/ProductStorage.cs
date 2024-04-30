namespace WebGeoInfrastructure.Entities
{
    public class ProductStorage
    {
        private int id;

        private Storage storage;
        private Product product;

        private float stock;
        public int Id { get { return id; } private set => id = value; }
        public Product Product { get { return product; } private set => product = value; }
        public Storage Storage { get { return storage; } private set => storage = value; }
        public float Stock { get { return stock; } private set => stock = value; }
    }
}
