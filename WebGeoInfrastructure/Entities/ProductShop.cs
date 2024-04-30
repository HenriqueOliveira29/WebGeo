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
        public float Stock { get { return stock; } private set => stock = value; }
    }
}
