using WebGeoInfrastructure.DTOs.Product;

namespace WebGeoInfrastructure.DTOs.Order
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }

        public List<ProductListDTO> products { get; set; }

        public DateTime Date { get; set; }

        public string DateString { get; set; }

        public List<RoutesCordDTO> Routes { get; set; }

        public int ShopId { get; set; }

        public string ShopName { get; set; }

        public int StorageId { get; set; }

        public string StorageName { get; set; }

        public int Time { get; set; }

        public OrderDetailDTO(WebGeoInfrastructure.Entities.Order order, List<RoutesCordDTO> routes)
        {
            Id = order.Id;
            products = order.ProductOrders.Where(t => t.InShop == false).Select(t => new ProductListDTO(t)).ToList();
            Date = order.DateDeliver != null ? order.DateDeliver.Value : order.Date;
            DateString = order.DateDeliver != null ? order.DateDeliver.Value.ToShortDateString() + " " + order.DateDeliver.Value.ToShortTimeString() : order.Date.ToShortDateString() + " " + order.Date.ToShortTimeString();
            Routes = routes;
            ShopId = order.ShopId;
            ShopName = order.Shop.Locality.Name;
            StorageId = order.Id;
            StorageName = order.StorageRestock?.Locality.Name;
        }
    }
}
