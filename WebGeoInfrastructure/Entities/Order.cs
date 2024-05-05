namespace WebGeoInfrastructure.Entities
{
    public class Order
    {
        private int id;

        private DateTime date;

        private string state;

        private DateTime? dateDeliver;

        private int clientId;

        private Client client;

        private List<ProductOrder> productsOrder;

        private List<Product> products;

        private int shopId;
        private Shop shop;

        public int Id { get { return id; } private set => id = value; }
        public DateTime Date { get { return date; } private set => date = value; }
        public string State { get { return state; } private set => state = value; }
        public DateTime? DateDeliver { get { return dateDeliver; } private set => dateDeliver = value; }

        public int ClientId { get { return clientId; } private set => clientId = value; }
        public Client Client { get { return client; } private set => client = value; }
        public List<ProductOrder> ProductOrders { get { return productsOrder; } private set => productsOrder = value; }
        public List<Product> Products { get { return products; } private set => products = value; }
        public int ShopId { get { return shopId; } private set => shopId = value; }
        public Shop Shop { get { return shop; } private set => shop = value; }

        public Order()
        {

        }

        public Order(Shop shop, Client client)
        {
            this.Shop = shop;
            this.Client = client;
            this.Date = DateTime.Now;
            this.state = "Processing";
            this.DateDeliver = null;
        }

        public void AddProducts(Product product)
        {
            if (this.Products == null)
            {
                this.products = new List<Product>();
            }
            this.products.Add(product);
        }


    }
}
