namespace WebGeoInfrastructure.Entities
{
    public class Product
    {
        private int id;

        private string name;

        private string description;

        private float preco;

        private List<ProductOrder> productsOrder;

        private List<Order> orders;

        private List<Shop> shops;
        private List<Storage> storages;

        public int Id { get { return id; } private set => id = value; }
        public string Name { get { return name; } private set => name = value; }
        public string Description { get { return description; } private set => description = value; }
        public float Preco { get { return preco; } private set => preco = value; }
        public List<ProductOrder> ProductOrders { get { return productsOrder; } private set => productsOrder = value; }
        public List<Order> Orders { get { return orders; } private set => orders = value; }
        public List<Shop> Shops { get { return shops; } private set => shops = value; }
        public List<Storage> Storages { get { return storages; } private set => storages = value; }


    }
}
