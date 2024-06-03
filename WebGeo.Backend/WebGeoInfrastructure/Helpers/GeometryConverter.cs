using GeoAPI.CoordinateSystems.Transformations;
using NetTopologySuite.Geometries;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using WebGeoInfrastructure.DTOs.Order;

namespace WebGeoInfrastructure.Helpers
{
    public class GeometryConverter
    {
        public static NetTopologySuite.Geometries.Geometry convertToGeometry(double x, double y)
        {
            // Cria um GeometryFactory, que é usado para criar diferentes tipos de geometrias
            GeometryFactory geometryFactory = new GeometryFactory();

            // Cria um objeto Coordinate com as coordenadas do DTO
            NetTopologySuite.Geometries.Coordinate coordinate = new NetTopologySuite.Geometries.Coordinate(x, y);

            // Cria um ponto usando o GeometryFactory e a Coordinate
            Point point = geometryFactory.CreatePoint(coordinate);

            // Retorna o ponto criado
            return point;
        }

        private static RoutesCordDTO convertToCord(Point point)
        {
            // Cria um GeometryFactory, que é usado para criar diferentes tipos de geometrias
            return new RoutesCordDTO(point.X, point.Y);
        }

        public static RoutesCordDTO GetCoordinates(Geometry geometry)
        {
            if (geometry is Point point)
            {
                return convertToCord(point);
            }

            return new RoutesCordDTO();
        }

        public static Point CreatePoint(double x, double y, int srid)
        {
            var geometryFactory = NetTopologySuite.Geometries.GeometryFactory.Default;
            var point = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(x, y));
            point.SRID = srid;
            return point;
        }

        public static Point TransformToSrid(Point point, int targetSrid)
        {
            var csFactory = new CoordinateSystemFactory();
            var ctFactory = new CoordinateTransformationFactory();

            var sourceCS = GeographicCoordinateSystem.WGS84;
            var targetCS = csFactory.CreateFromWkt(
                "PROJCS[\"ETRS89 / Portugal TM06\", " +
                "GEOGCS[\"ETRS89\", " +
                "DATUM[\"European_Terrestrial_Reference_System_1989\", " +
                "SPHEROID[\"GRS 1980\",6378137,298.257222101, " +
                "AUTHORITY[\"EPSG\",\"7019\"]], " +
                "AUTHORITY[\"EPSG\",\"6258\"]], " +
                "PRIMEM[\"Greenwich\",0, " +
                "AUTHORITY[\"EPSG\",\"8901\"]], " +
                "UNIT[\"degree\",0.0174532925199433, " +
                "AUTHORITY[\"EPSG\",\"9122\"]], " +
                "AUTHORITY[\"EPSG\",\"4258\"]], " +
                "UNIT[\"metre\",1, " +
                "AUTHORITY[\"EPSG\",\"9001\"]], " +
                "PROJECTION[\"Transverse_Mercator\"], " +
                "PARAMETER[\"latitude_of_origin\",39.66825833333333], " +
                "PARAMETER[\"central_meridian\",-8.133108333333333], " +
                "PARAMETER[\"scale_factor\",1], " +
                "PARAMETER[\"false_easting\",0], " +
                "PARAMETER[\"false_northing\",0], " +
                "AUTHORITY[\"EPSG\",\"3763\"], " +
                "AXIS[\"X\",EAST], " +
                "AXIS[\"Y\",NORTH]]");

            ICoordinateTransformation transform = null;
            if (targetSrid == 3763)
            {
                transform = ctFactory.CreateFromCoordinateSystems(sourceCS, targetCS);
            }
            else if (targetSrid == 4326)
            {
                transform = ctFactory.CreateFromCoordinateSystems(targetCS, sourceCS);
            }

            var transformedCoordinates = transform?.MathTransform.Transform(new[] { point.X, point.Y });

            var geometryFactory = NetTopologySuite.Geometries.GeometryFactory.Default;
            var transformedPoint = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(transformedCoordinates[0], transformedCoordinates[1]));
            transformedPoint.SRID = targetSrid;

            return transformedPoint;
        }
    }
}
