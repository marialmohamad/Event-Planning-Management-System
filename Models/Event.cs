using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SparklingMVC.Models
{
    public class Event
    {
        public int Id { get; set; } 

        
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string EventType { get; set; } = "";
        [MaxLength(100)]
        public string Location { get; set; } = "";
        [Precision(16, 2)]
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        [MaxLength(100)]
        public string ImageFileName { get; set; } = "";
        public DateTime ReservationNo { get; set; }
    }
}
