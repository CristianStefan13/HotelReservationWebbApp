using System.ComponentModel.DataAnnotations;

namespace proiect_hotel2.Models
{
    public class Guest
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage ="Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]

        [StringLength(30, MinimumLength = 3)]
        public string GuestName { get; set; }

        [StringLength(70)]

        public string Address { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]
        public string? Phone { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
