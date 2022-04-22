using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBook.Models
{
    public class Greeting
    {
        [Key]
        public int ContentId { get; set; }
        public string Content { get; set; }
    }
}
