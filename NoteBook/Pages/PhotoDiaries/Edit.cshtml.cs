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

namespace NoteBook.Pages.PhotoDiaries
{
    public class EditModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public EditModel(NoteBook.Data.NoteBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PhotoDiary PhotoDiary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhotoDiary = await _context.PhotoDiary
                .Include(p => p.template).FirstOrDefaultAsync(m => m.PhotoDiaryId == id);

            if (PhotoDiary == null)
            {
                return NotFound();
            }
           ViewData["TemplateId"] = new SelectList(_context.Set<Template>(), "TemplateId", "TemplateId");
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

            _context.Attach(PhotoDiary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoDiaryExists(PhotoDiary.PhotoDiaryId))
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

        private bool PhotoDiaryExists(int id)
        {
            return _context.PhotoDiary.Any(e => e.PhotoDiaryId == id);
        }
    }
}
