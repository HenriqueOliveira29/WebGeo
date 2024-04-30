namespace WebGeoInfrastructure.Entities
{
    public class Client
    {
        private int id;

        private string name;

        private string address;
        private List<Order> orders;

        public int Id { get { return id; } private set => id = value; }
        public string Name { get { return name; } private set => name = value; }
        public string Address { get { return address; } private set => address = value; }
        public List<Order> Orders { get { return orders; } private set => orders = value; }
    }
}
