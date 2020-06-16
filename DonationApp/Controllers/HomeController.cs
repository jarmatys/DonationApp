using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DonationApp.Models;
using DonationApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInstitutionService _institutionService;
        private readonly IDonationService _donationService;
        public HomeController(IInstitutionService institutionService, IDonationService donationService)
        {
            _institutionService = institutionService;
            _donationService = donationService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["institutions"] = await _institutionService.GetAll();
            ViewData["sumOfBag"] = await _donationService.DonationCount();
            ViewData["sumOfInstitions"] = await _donationService.DonatedInstitionsCount();
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}