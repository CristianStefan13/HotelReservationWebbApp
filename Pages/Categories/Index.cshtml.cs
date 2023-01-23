using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_hotel2.Data;
using proiect_hotel2.Models;

namespace proiect_hotel2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly proiect_hotel2.Data.proiect_hotel2Context _context;

        public IndexModel(proiect_hotel2.Data.proiect_hotel2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Type != null)
            {
                Category = await _context.Type.ToListAsync();
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Reservations/Index", new { id = 3 });

        }
    }
}
