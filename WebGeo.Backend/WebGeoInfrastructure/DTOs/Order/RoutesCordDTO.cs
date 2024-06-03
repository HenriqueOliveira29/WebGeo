namespace WebGeoInfrastructure.DTOs.Order
{
    public class RoutesCordDTO
    {
        public double CordX { get; set; }

        public double CordY { get; set; }

        public RoutesCordDTO(double x, double y)
        {
            CordX = x;
            CordY = y;
        }
        public RoutesCordDTO()
        {

        }
    }
}
