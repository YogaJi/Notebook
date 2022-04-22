using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.Journals
{
    public class EditModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public EditModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Journal Journal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Journal = await _context.Journal
                .Include(j => j.color)
                .Include(j => j.mood)
                .Include(j => j.notebook)
                .Include(j => j.weather).FirstOrDefaultAsync(m => m.JournalId == id);

            if (Journal == null)
            {
                return NotFound();
            }
           ViewData["ColorId"] = new SelectList(_context.Set<Color>(), "ColorId", "ColorString");
           ViewData["MoodId"] = new SelectList(_context.Set<Mood>(), "MoodId", "MoodPic");
           ViewData["NotebookId"] = new SelectList(_context.Set<Notebook>(), "NotebookId", "Name");
           ViewData["WeatherId"] = new SelectList(_context.Set<Weather>(), "WeatherId", "WeatherPic");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Journal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalExists(Journal.JournalId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JournalExists(int id)
        {
            return _context.Journal.Any(e => e.JournalId == id);
        }
    }
}
