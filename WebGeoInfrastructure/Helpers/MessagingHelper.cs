namespace WebGeoInfrastructure.Helpers
{
    public class MessagingHelper<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; } = "";

        public T Obj { get; set; }
    }

    public class MessagingHelper
    {
        public bool Success { get; set; }

        public string Message { get; set; } = "";
    }
}
