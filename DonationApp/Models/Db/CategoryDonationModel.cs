using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Models.Db
{
    public class CategoryDonationModel
    {
        [Key]
        public int Id { get; set; }

        public int DonationId { get; set; }
        public DonationModel Donation { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
