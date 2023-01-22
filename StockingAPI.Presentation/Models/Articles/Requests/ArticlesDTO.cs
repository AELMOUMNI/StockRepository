using Stocking.Domain.AggregatesModel;
using System.ComponentModel.DataAnnotations;

namespace StockingAPI.Presentation.Models.Articles.Requests
{
    public record ArticlesDTO
    {
        [Required]
        public string Reference { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TVA { get; set; }
        public Category Type { get; private set; }
        

    }
}
