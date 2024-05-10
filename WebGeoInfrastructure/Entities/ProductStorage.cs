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
        public float Stock
        {
            get { return stock; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Stock can't be lower than 0");
                }
                stock = value;
            }
        }

        public ProductStorage()
        {

        }

        public ProductStorage(Storage storage, Product product, float quantity)
        {
            this.storage = storage;
            this.Product = product;
            this.Stock = quantity;
        }

        public void AddStock(float quantity)
        {
            this.Stock += quantity;
        }
    }
}
