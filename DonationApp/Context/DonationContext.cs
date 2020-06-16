using DonationApp.Models.Db;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Context
{
    public class DonationContext : IdentityDbContext<UserApp>
    {
        public DonationContext(DbContextOptions<DonationContext> options) : base(options) { }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<InstitutionModel> Instituties { get; set; }
        public DbSet<DonationModel> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
