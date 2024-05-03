namespace WebGeoInfrastructure.DTOs.Order
{
    public class OrderListDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
        public int ShopId { get; set; }

        public OrderListDTO()
        {

        }

        public OrderListDTO(Entities.Order order)
        {
            this.Id = order.Id;
            this.Date = order.Date;
            this.State = order.State;
            this.ShopId = order.ShopId;
        }
    }
}
