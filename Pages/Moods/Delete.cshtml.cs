using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.Moods
{
    public class DeleteModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public DeleteModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mood Mood { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mood = await _context.Mood.FirstOrDefaultAsync(m => m.MoodPic == id);

            if (Mood == null)
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

            Mood = await _context.Mood.FindAsync(id);

            if (Mood != null)
            {
                _context.Mood.Remove(Mood);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
