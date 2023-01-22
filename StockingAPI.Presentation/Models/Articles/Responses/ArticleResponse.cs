using Stocking.Domain.AggregatesModel;
using System.ComponentModel.DataAnnotations;

namespace StockingAPI.Presentation.Models.Articles.Responses
{
    public record ArticleResponse
    {
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal TVA { get; set; }
        public decimal HT { get; set; }
        public decimal TTC { get; set; }
        public Category Category { get; set; }
        public bool IsTakeAway { get; set; }
    }
}
