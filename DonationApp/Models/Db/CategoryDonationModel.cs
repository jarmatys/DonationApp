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

        public int InstitutionId { get; set; }
        public InstitutionModel Institution { get; set; }
    }
}
