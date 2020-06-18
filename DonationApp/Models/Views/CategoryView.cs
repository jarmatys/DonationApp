using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Models.Views
{
    public class CategoryView
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
}
