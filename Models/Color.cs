using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBook.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }
        public string ColorString { get; set; }

        public ICollection<Journal> Journals { get; set; }
    }
}
