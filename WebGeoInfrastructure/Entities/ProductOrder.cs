namespace WebGeoInfrastructure.Entities
{
    public class ProductOrder
    {
        private int id;

        private int orderId;
        private Order order;


        private int productId;
        private Product product;
        private float quantity;

        public int Id { get { return id; } private set => id = value; }
        public int OrderId { get { return orderId; } private set => orderId = value; }
        public Order Order { get { return order; } private set => order = value; }
        public int ProductId { get { return productId; } private set => productId = value; }
        public Product Product { get { return product; } private set => product = value; }
        public float Quantity
        {
            get { return quantity; }
            private set
            {
                if (quantity < 0)
                {
                    throw new ArgumentException("Quantity can't be lower than 0");
                }
                quantity = value;
            }
        }

        public ProductOrder()
        {

        }
        public ProductOrder(Product product, Order order, float quantity)
        {
            this.Product = product;
            this.Order = order;
            this.Quantity = quantity;
        }
    }
}
