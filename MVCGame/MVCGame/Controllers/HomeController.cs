using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCGame.Models;

namespace MVCGame.Controllers
{
    public class HomeController : Controller
    {
        PublicationContext db;
        public HomeController(PublicationContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allpublications = db.Publications.ToList();
            return View(allpublications);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
