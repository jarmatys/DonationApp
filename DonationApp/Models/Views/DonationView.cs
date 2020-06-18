using DonationApp.Models.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Models.Views
{
    public class DonationView
    {
        // Etap 1
        public List<int> CategoriesSelected { get; set; }
        public List<CategoryView> CategoriesItems { get; set; }

        // Etap 2
        [Required(ErrorMessage ="Podaj ilość worków")]
        public int Bags { get; set; }

        // Etap 3
        [Required(ErrorMessage = "Zaznacz instytucje")]
        public int SelectedInstitutionId { get; set; }
        public List<InstitionView> InstitutionItems { get; set; }

        // Etap 4
        [Required(ErrorMessage = "Adres jest obowiązkowy")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Miasto jest obowiązkowe")]
        public string City { get; set; }
        // Zapytać string ??
        [Required(ErrorMessage = "Kod pocztowy jest obowiązkowy")]
        public string Postcode { get; set; }
        // Zapytać ?? czy phone i zipcode moze byc stringiem czy raczej jakieś int?
        [Required(ErrorMessage = "telefon jest obowiązkowy")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Data jest obowiązkowy")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "czas jest obowiązkowy")]
        public DateTime Time { get; set; }
        public string Moreinfo { get; set; }
    }

}
