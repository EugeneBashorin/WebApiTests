using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Indicate book's name")]
        public string Name { get; set; }

        public string Author { get; set; }

        [Range(1800,2000,ErrorMessage ="Year should be in range 1800..2000")]
        [Required(ErrorMessage ="Indicate the year of publication")]
        public int Year { get; set; }
    }
}