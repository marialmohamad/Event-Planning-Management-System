using System.ComponentModel.DataAnnotations;

namespace SparklingMVC.Models
{
    public class EventDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string EventType { get; set; } = "";
        [Required, MaxLength(100)]
        public string Location { get; set; } = "";


        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; } = "";
        
        
        public IFormFile? ImageFile { get; set; } 
    }
}
