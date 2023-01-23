using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_hotel2.Data;
using proiect_hotel2.Models;

namespace proiect_hotel2.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly proiect_hotel2.Data.proiect_hotel2Context _context;

        public string GuestNameSort { get; set; }
        public string EmailSort { get; set; }
        public string ArrivalDateSort { get; set; }
        public string DepartureDateSort { get; set; }
        public string RoomNumberSort { get; set; }
        public string CategoryTypeSort { get; set; }
        public string NumberOfPeopleSort { get; set; }

        public string CurrentFilter { get; set; }


        public IndexModel(proiect_hotel2.Data.proiect_hotel2Context context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            if (_context.Reservation != null)
            {
                GuestNameSort = sortOrder == "guestname_asc_sort" ? "guestname_desc_sort" : "guestname_asc_sort";
                EmailSort = sortOrder == "email_asc_sort" ? "email_desc_sort" : "email_asc_sort";
                ArrivalDateSort = sortOrder == "arrivaldatetime_asc_sort" ? "arrivaldatetime_desc_sort" : "arrivaldatetime_asc_sort";
                DepartureDateSort = sortOrder == "departuredatetime_asc_sort" ? "departuredatetime_desc_sort" : "departuredatetime_asc_sort";
                RoomNumberSort = sortOrder == "roomnumber_asc_sort" ? "roomnumber_desc_sort" : "roomnumber_asc_sort";
                CategoryTypeSort = sortOrder == "categorytype_asc_sort" ? "categorytype_desc_sort" : "categorytype_asc_sort";
                NumberOfPeopleSort = sortOrder == "numberofpeople_asc_sort" ? "numberofpeople_desc_sort" : "numberofpeople_asc_sort";

                if (!String.IsNullOrEmpty(searchString))
                {
                    Reservation = await _context.Reservation.Include(b => b.Guest)
          .Include(b => b.Category).Where(s => s.Guest.GuestName.Contains(searchString)
                        || s.Email.Contains(searchString) || s.Category.CategoryName.Contains(searchString)).ToListAsync();

                }
                else
                {
                    Reservation = await _context.Reservation
          .Include(b => b.Guest)
          .Include(b => b.Category)

          .ToListAsync();
                }

               
                switch (sortOrder)
                {
                    case "guestname_asc_sort":
                        Reservation = Reservation.OrderBy(s => s.Guest.GuestName).ToList();
                        break;

                    case "guestname_desc_sort":
                        Reservation = Reservation.OrderByDescending(s => s.Guest.GuestName).ToList();
                        break;

                    case "email_asc_sort":
                        Reservation = Reservation.OrderBy(s => s.Email).ToList();
                        break;

                    case "email_desc_sort":
                        Reservation = Reservation.OrderByDescending(s => s.Email).ToList();
                        break;
                    default:
                        Reservation = Reservation.OrderBy(s => s.RoomNumber).ToList();
                        break;


                }
            }
           
        }

    }
}
