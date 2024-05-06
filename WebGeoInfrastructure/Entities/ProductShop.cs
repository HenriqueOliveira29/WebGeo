namespace WebGeoInfrastructure.Entities
{
    public class ProductShop
    {
        private int id;

        private Shop shop;
        private Product product;

        private float stock;
        public int Id { get { return id; } private set => id = value; }
        public Product Product { get { return product; } private set => product = value; }
        public Shop Shop { get { return shop; } private set => shop = value; }
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

        public ProductShop()
        {

        }

        public ProductShop(Shop shop, Product product, float quantity)
        {
            this.Shop = shop;
            this.Product = product;
            this.Stock = quantity;
        }

        public void AddStock(float quantity)
        {
            this.Stock += quantity;
        }
    }
}
