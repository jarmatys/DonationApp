using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Models.Db
{
    public class DonationModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public List<CategoryDonationModel> Categories { get; set; }
        public InstitutionModel Institution { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime PickUpTime { get; set; }
        public string PickUpComment { get; set; }
    }
}
