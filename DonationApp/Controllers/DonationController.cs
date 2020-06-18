using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonationApp.Models.Db;
using DonationApp.Models.Views;
using DonationApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonationApp.Controllers
{
    public class DonationController : Controller
    {
        private readonly IDonationService _donationService;
        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        [HttpGet]
        public async Task<IActionResult> Donate()
        {
            var viewModel = await _donationService.PrepareViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Donate(DonationView result)
        {
            // ZAPYTAĆ, czy mogę tak dodawać czy jest lepszy patern na to 
            if (result.CategoriesSelected == null)
            {
                ModelState.AddModelError("", "Zaznacz przynajmniej jedną kategorie");
            }

            if (result.SelectedInstitutionId == 0)
            {
                ModelState.AddModelError("", "Wybierz organizację");
            }

            if (!ModelState.IsValid)
            {
                var viewModel = await _donationService.PrepareViewModel(result);

                return View(viewModel);
            }

            return RedirectToAction("DonateConfirmation", "Donation");
        }

        [HttpGet]
        public IActionResult DonateConfirmation()
        {
            return View();
        }

    }
}