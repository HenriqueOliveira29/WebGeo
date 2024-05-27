using NetTopologySuite.Geometries;

namespace WebGeoInfrastructure.Entities
{
    public class Routes
    {
        private int id;

        private int weight;

        private int originId;

        private Locality origin;

        private int destinyId;

        private Locality destiny;
        private int time;

        private Geometry geom;

        public int Id { get { return id; } private set => id = value; }
        public int Weight { get { return weight; } private set => weight = value; }
        public int Time { get { return time; } private set => time = value; }

        public int OriginId { get { return originId; } private set => originId = value; }
        public Locality Origin { get { return origin; } private set => origin = value; }

        public int DestinyId { get { return destinyId; } private set => destinyId = value; }
        public Locality Destiny { get { return destiny; } private set => destiny = value; }

        public Geometry Geom { get { return geom; } private set { geom = value; } }
    }
}
