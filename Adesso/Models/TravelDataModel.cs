namespace Adesso.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public int Description { get; set; }
        public bool isPublished { get; set; }
        public int SeatCount { get; set; }
        public int AvailableSeats { get; set; }

    }
}
