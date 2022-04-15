using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBook.Models
{
    public class Weather
    {
        
        public int WeatherId { get; set; }
        [Key]
        public string WeatherPic { get; set; }

        public ICollection<Journal> Journals { get; set; }
    }
}
