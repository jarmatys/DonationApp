using DonationApp.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Models.Views
{
    public class DonationView
    {
        public List<CategoryView> CategoriesItems { get; set; }
        public List<InstitionView> InstitutionItems { get; set; }
    }

}
