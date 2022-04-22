using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBook.Models
{
    public class Notebook
    {
        [Key]
        public int NotebookId { get; set; }
        public string Name { get; set; }
        public ICollection<Journal> Journals { get; set; }

    }
}
