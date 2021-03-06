using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.Journals
{
    public class CreateModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public CreateModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Colors"] = new SelectList(_context.Set<Color>(), "ColorId", "ColorString");
            ViewData["Moods"] = new SelectList(_context.Set<Mood>(), "MoodId", "MoodPic");
            ViewData["Notebooks"] = new SelectList(_context.Set<Notebook>(), "NotebookId", "Name");
            ViewData["Weathers"] = new SelectList(_context.Set<Weather>(), "WeatherId", "WeatherName");
            return Page();
        }

        [BindProperty]
        public Journal Journal { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Journal.Add(Journal);
            await _context.SaveChangesAsync();
            ViewData["Colors"] = new SelectList(_context.Set<Color>(), "ColorId", "ColorString");
            ViewData["Moods"] = new SelectList(_context.Set<Mood>(), "MoodId", "MoodPic");
            ViewData["Notebooks"] = new SelectList(_context.Set<Notebook>(), "NotebookId", "Name");
            ViewData["Weathers"] = new SelectList(_context.Set<Weather>(), "WeatherId", "WeatherName");
            return RedirectToPage("./Index");
        }
    }
}
