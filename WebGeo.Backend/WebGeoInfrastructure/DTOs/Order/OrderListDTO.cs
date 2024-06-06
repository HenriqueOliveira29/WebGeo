namespace WebGeoInfrastructure.DTOs.Order
{
    public class OrderListDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string DateString { get; set; }
        public string LocalityName { get; set; }
        public int NumberOfProducts { get; set; }
        public int ShopId { get; set; }

        public OrderListDTO()
        {

        }

        public OrderListDTO(Entities.Order order)
        {
            this.Id = order.Id;
            this.ShopId = order.ShopId;
            this.LocalityName = order.Shop.Locality.Name;
            this.NumberOfProducts = order.ProductOrders.Count;
            this.Date = order.DateDeliver != null ? order.DateDeliver.Value : order.Date;
            this.DateString = order.DateDeliver != null ? order.DateDeliver.Value.ToShortDateString() + " " + order.DateDeliver.Value.ToShortTimeString() : order.Date.ToShortDateString() + " " + order.Date.ToShortTimeString();
        }
    }
}
