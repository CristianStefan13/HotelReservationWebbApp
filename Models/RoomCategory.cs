namespace proiect_hotel2.Models
{
    public class RoomCategory
    {
        public int ID { get; set; }
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
