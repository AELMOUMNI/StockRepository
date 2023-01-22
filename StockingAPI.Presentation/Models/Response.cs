namespace StockingAPI.Presentation.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public int Status { get; set; }
    }
}
