using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.PhotoDiaries
{
    public class DeleteModel : PageModel
    {
        private readonly NoteBook.Data.NoteBookContext _context;

        public DeleteModel(NoteBook.Data.NoteBookContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhotoDiary = await _context.PhotoDiary.FindAsync(id);

            if (PhotoDiary != null)
            {
                _context.PhotoDiary.Remove(PhotoDiary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
