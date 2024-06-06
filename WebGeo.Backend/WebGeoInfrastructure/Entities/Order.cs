namespace WebGeoInfrastructure.Entities
{
    public class Order
    {
        private int id;

        private DateTime date;

        private string state;

        private DateTime? dateDeliver;

        public DateTime? dateDeliverToClient;

        private int clientId;

        private Client client;

        private List<ProductOrder> productsOrder;

        private List<Product> products;

        private int shopId;
        private Shop shop;

        private int? storageRestockId;

        private Storage? storageRestock;

        public int Id { get { return id; } private set => id = value; }
        public DateTime Date { get { return date; } private set => date = value; }
        public string State { get { return state; } private set => state = value; }
        public DateTime? DateDeliver { get { return dateDeliver; } private set => dateDeliver = value; }

        public DateTime? DateDeliverToClient { get { return dateDeliverToClient; } private set => dateDeliverToClient = value; }

        public int ClientId { get { return clientId; } private set => clientId = value; }
        public Client Client { get { return client; } private set => client = value; }
        public List<ProductOrder> ProductOrders { get { return productsOrder; } private set => productsOrder = value; }
        public List<Product> Products { get { return products; } private set => products = value; }
        public int ShopId { get { return shopId; } private set => shopId = value; }
        public Shop Shop { get { return shop; } private set => shop = value; }

        public int? StorageRestockId { get { return storageRestockId; } private set => storageRestockId = value; }
        public Storage? StorageRestock { get { return storageRestock; } private set => storageRestock = value; }

        public Order()
        {

        }

        public Order(Shop shop, Client client)
        {
            this.Shop = shop;
            this.Client = client;
            this.Date = DateTime.Now.ToUniversalTime();
            this.state = OrderState.Active.ToString();
            this.DateDeliver = null;
        }

        public void SetDateDeliver(DateTime date)
        {
            this.dateDeliver = date.ToUniversalTime();
        }

        public void AddProducts(Product product)
        {
            if (this.Products == null)
            {
                this.products = new List<Product>();
            }
            this.products.Add(product);
        }

        public void SetOrderOnWaitingStock()
        {
            this.State = OrderState.WaitingForStock.ToString();
        }

        public void Cancel()
        {
            this.State = OrderState.Canceled.ToString();
        }

        public void DeliverToClient()
        {
            this.DateDeliverToClient = DateTime.Now.ToUniversalTime();
            this.State = OrderState.Concluded.ToString();
        }

        public void DeliverToShop()
        {
            this.State = OrderState.WaitForClient.ToString();
        }

        public void SetStorageReStock(Storage storage)
        {
            this.StorageRestockId = storage.Id;
            this.StorageRestock = storage;
        }

    }

    public enum OrderState
    {
        Active,
        WaitingForStock,
        Validated,
        WaitForClient,
        Canceled,
        Concluded,
    }
}
