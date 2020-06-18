using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Models.Views
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Imie jest wymagane")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email jest wymagane")]
        [EmailAddress(ErrorMessage = "Wprowadzono błędny adres email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Haslo jest wymagane")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Haslo jest wymagane"), Compare("Password")]
        public string ReapeatPassword { get; set; }
    }
}
