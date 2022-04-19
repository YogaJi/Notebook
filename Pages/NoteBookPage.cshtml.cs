using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteBook.Data;
using NoteBook.Models;

namespace NoteBook.Pages
{
    public class NoteBookPageModel : PageModel
    {
        private readonly NoteBookContext db;

        public NoteBookPageModel(NoteBookContext dbContext)
        {
            db = dbContext;
        }

        [FromQuery]
        public Notebook Notebook { get; set; }
   
        public void OnGet(int id)
        {
            Notebook = db.Notebook.Include(notebook => notebook.Journals).FirstOrDefault(notebook => notebook.NotebookId == id);
            /*Journal = db.Journal.FirstOrDefault(n => n.JournalId == id);*/
        }
    }
}
