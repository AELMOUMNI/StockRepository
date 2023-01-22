using Stocking.Domain.AggregatesModel;
using System.ComponentModel.DataAnnotations;

namespace StockingAPI.Presentation.Models.Articles.Requests
{
    public record CreateArticlesDTO
    {
        public string Reference { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Category Type { get; set; }
        public bool IsTakeAway { get; set; }    
    }
}
