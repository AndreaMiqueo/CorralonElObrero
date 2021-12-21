using CoralónElObrero.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoralónElObrero.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailServices;
        
        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailServices = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QueOfrecemos()
        {
            return View();
        }

        public IActionResult CorralónDeMateriales()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Contacto(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Mensaje"] = "Lo sentimos el mensaje no pudo ser enviado.";
                return View();
            }

            await _emailServices
                      .EnviarEmailAsync(model).ConfigureAwait(false);
            TempData["Mensaje"] = "Mensaje enviado correctamente.";
            return RedirectToAction(nameof(Contacto));

        }

        public IActionResult Legales()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MapaWeb()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
