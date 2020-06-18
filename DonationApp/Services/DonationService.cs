using DonationApp.Context;
using DonationApp.Models.Db;
using DonationApp.Models.Views;
using DonationApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DonationApp.Models.Views.DonationView;

namespace DonationApp.Services
{
    public class DonationService : IDonationService
    {
        private readonly DonationContext _context;

        public DonationService(DonationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(DonationView result)
        {
            var donation = new DonationModel
            {
                Quantity = result.Bags,
                // Categories = 
                Institution = await _context.Instituties.FindAsync(result.SelectedInstitutionId),
                Street = result.Address,
                City = result.City,
                ZipCode = result.Postcode,
                PickUpDate = result.Data,
                PickUpTime = result.Time,
                PickUpComment = result.Moreinfo
            };

            _context.Donations.Add(donation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<DonationModel> Get(int id)
        {
            return await _context.Donations.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IList<DonationModel>> GetAll()
        {
            return await _context.Donations.ToListAsync();
        }

        public async Task<bool> Update(DonationModel donation)
        {
            _context.Donations.Update(donation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var donation = await _context.Donations.SingleOrDefaultAsync(b => b.Id == id);
            if (donation == null)
                return false;

            _context.Donations.Remove(donation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> DonationCount()
        {
            var donationList = await _context.Donations.ToListAsync();
            return donationList.Count();
        }

        public async Task<int> DonatedInstitionsCount()
        {
            var donatedInstitionsList = await _context.Donations.Include(x => x.Institution).Select(x => x.Institution.Id).Distinct().ToListAsync();
            return donatedInstitionsList.Count();
        }

        public async Task<DonationView> PrepareViewModel(DonationView result = null)
        {
            var viewModel = new DonationView();

            // 1. kategorie do widoku
            List<CategoryView> categoryItems = new List<CategoryView>() { };

            var categories = await _context.Categories.ToListAsync();
            foreach (var category in categories)
            {
                CategoryView tempCat;
                if (result != null && result.CategoriesSelected != null && result.CategoriesSelected.Contains(category.Id))
                {
                    tempCat = new CategoryView { Id = category.Id, Value = category.Name, Text = category.Name, IsChecked = true };
                }
                else
                {
                    tempCat = new CategoryView { Id = category.Id, Value = category.Name, Text = category.Name, IsChecked = false };
                }               

                categoryItems.Add(tempCat);
            }

            viewModel.CategoriesItems = categoryItems;

            // 2. instytucje do widoku
            List<InstitionView> institionItems = new List<InstitionView>() { };

            var institutions = await _context.Instituties.ToListAsync();
            foreach (var institution in institutions)
            {
                InstitionView tempInst;
                if (result != null && result.SelectedInstitutionId != 0 && result.SelectedInstitutionId == institution.Id)
                {
                    tempInst = new InstitionView { Id = institution.Id, Name = institution.Name, Description = institution.Description, IsChecked = true };
                }
                else
                {
                    tempInst = new InstitionView { Id = institution.Id, Name = institution.Name, Description = institution.Description, IsChecked = false };
                }
                institionItems.Add(tempInst);
            }

            viewModel.InstitutionItems = institionItems;

            return viewModel;
        }
    }
}
