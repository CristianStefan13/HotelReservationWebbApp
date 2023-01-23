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
    public class DeleteModel : PageModel
    {
        private readonly proiect_hotel2.Data.proiect_hotel2Context _context;

        public DeleteModel(proiect_hotel2.Data.proiect_hotel2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Type == null)
            {
                return NotFound();
            }

            var category = await _context.Type.FirstOrDefaultAsync(m => m.ID == id);

            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Type == null)
            {
                return NotFound();
            }
            var category = await _context.Type.FindAsync(id);

            if (category != null)
            {
                Category = category;
                _context.Type.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
