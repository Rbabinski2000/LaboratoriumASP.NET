using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3_App.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać imię!")]
        [StringLength(maximumLength:100, ErrorMessage = "Zbyt długie imie")]
        public string Name { get; set; }

        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Required(ErrorMessage = "Proszę podać poprawny eamil!")]
        public string Email { get; set; }

        [Phone(ErrorMessage ="Niepoprawny numer telefonu!!")]
        public string Phone { get; set; }

        public DateTime Birth { get; set; }

        

    }
}
