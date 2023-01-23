using System.ComponentModel.DataAnnotations;

namespace proiect_hotel2.Models
{
    public class Category
    {
        
            public int ID { get; set; }
            [Display(Name ="Room Type")]
            public string CategoryName { get; set; }
            public ICollection<Reservation>? Reservations { get; set; }
        

    }
}
