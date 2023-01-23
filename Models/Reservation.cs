using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Security.Policy;

namespace proiect_hotel2.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        //[StringLength(100)] 
       // public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        [Required]
        [Range(1, 150)]
        public int RoomNumber { get; set; }
        [Required]
        [Range(1, 10)]
        public int NumberOfPeople { get; set; }
        [NotMapped]
        public string ArrivalDate => ArrivalDateTime.ToString("MM/dd/yyyy");
        [NotMapped]
        public string ArrivalTime => ArrivalDateTime.ToString("hh:mm tt");
        [NotMapped]
        public string DepartureDate => DepartureDateTime.ToString("MM/dd/yyyy");
        [NotMapped]
        public string DepartureTime => DepartureDateTime.ToString("hh:mm tt");
        public int? GuestID { get; set; }
        public Guest? Guest { get; set; }
        public ICollection<RoomCategory>? RoomCategories { get; set; }

        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
