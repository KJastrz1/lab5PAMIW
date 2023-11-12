﻿using Microsoft.AspNetCore.Mvc;
using P09ShopWebAPPMVC.Client.Models;
using System.Diagnostics;
using System.Reflection;

namespace P09ShopWebAPPMVC.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var version = Assembly.GetEntryAssembly()
                     .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                     .InformationalVersion;

            ViewData["Version"] = version;

            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy Policy";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}