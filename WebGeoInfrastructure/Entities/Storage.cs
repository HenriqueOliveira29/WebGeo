using NetTopologySuite.Geometries;

namespace WebGeoInfrastructure.Entities
{
    public class Storage
    {
        private int id;

        private Geometry location;

        private List<ProductStorage> productStorages;
        private List<Product> products;

        public int Id { get { return id; } private set => id = value; }
        public Geometry Location { get { return location; } private set => location = value; }
        public List<ProductStorage> ProductStorages { get { return productStorages; } private set => productStorages = value; }
        public List<Product> Products { get { return products; } private set => products = value; }


        public void setLocation(Point location)
        {
            this.Location = location;
        }
    }
}
