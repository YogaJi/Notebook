using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBook.Models
{
    public class Weather
    {

        [Key]
        public int WeatherId { get; set; }
        public string WeatherName { get; set; }
        public string WeatherPic { get; set; }

        public ICollection<Journal> Journals { get; set; }
    }
}
