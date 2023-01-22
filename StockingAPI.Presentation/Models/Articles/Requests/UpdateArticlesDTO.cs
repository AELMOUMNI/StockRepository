using Stocking.Domain.AggregatesModel;
using System.ComponentModel.DataAnnotations;

namespace StockingAPI.Presentation.Models.Articles.Requests
{
    public record UpdateArticlesDTO
    {
        
        public string Name { get; set; }
        [Required]
        [Range(1, 100)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TVA { get; set; }
        public Category Type { get; set; }
        public decimal HT { get; set; }
    }
}
