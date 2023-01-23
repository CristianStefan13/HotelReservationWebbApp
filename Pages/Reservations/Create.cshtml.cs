using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect_hotel2.Data;
using proiect_hotel2.Models;

namespace proiect_hotel2.Pages.Reservations
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly proiect_hotel2.Data.proiect_hotel2Context _context;

        public CreateModel(proiect_hotel2.Data.proiect_hotel2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["GuestID"] = new SelectList(_context.Set<Guest>(), "ID",
"GuestName");
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID",
"CategoryName");


            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
