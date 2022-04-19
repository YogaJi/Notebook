using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages.Templates
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
            return Page();
        }

        [BindProperty]
        public Template Template { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Template.Add(Template);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
