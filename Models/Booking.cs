namespace SparklingMVC.Models
{
    public class Booking
    {

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int NoAttending { get; set; }
        public string Timespan { get; set; } = "";
        public string GSM { get; set; } = "";
        public string Gmail { get; set; } = "";
        public string Address { get; set; } = "";

    }
}
