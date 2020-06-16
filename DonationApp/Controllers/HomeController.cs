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
        public HomeController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["institutions"] = await _institutionService.GetAll();
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}