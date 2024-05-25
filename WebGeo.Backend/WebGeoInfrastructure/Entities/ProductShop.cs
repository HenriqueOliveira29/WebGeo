namespace WebGeoInfrastructure.Entities
{
    public class ProductShop
    {
        private int id;


        private int shopId;
        private Shop shop;

        private int productId;
        private Product product;

        private float stock;
        public int Id { get { return id; } private set => id = value; }

        public int ProductId { get { return productId; } private set => productId = value; }
        public Product Product { get { return product; } private set => product = value; }

        public int ShopId { get { return shopId; } private set => shopId = value; }
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

        public void RetireStock(float quantity)
        {
            this.Stock -= quantity;
        }
    }
}
