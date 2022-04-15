using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.Weathers
{
    public class DeleteModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public DeleteModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Weather Weather { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Weather = await _context.Weather.FirstOrDefaultAsync(m => m.WeatherPic == id);

            if (Weather == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Weather = await _context.Weather.FindAsync(id);

            if (Weather != null)
            {
                _context.Weather.Remove(Weather);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
