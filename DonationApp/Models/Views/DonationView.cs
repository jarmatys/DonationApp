using DonationApp.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Models.Views
{
    public class DonationView
    {
        // Etap 1
        public List<CategoryView> CategoriesItems { get; set; }

        // Etap 2
        public int Bags { get; set; }

        // Etap 3
        public int SelectedInstitutionId { get; set; }
        public List<InstitionView> InstitutionItems { get; set; }

        // Etap 4
        public string Address { get; set; }
        public string City { get; set; }
        // Zapytać string ??
        public string Postcode { get; set; }
        // Zapytać string ??
        public string Phone { get; set; }

        public DateTime Data { get; set; }
        public DateTime Time { get; set; }
        public string Moreinfo { get; set; }
    }

}
