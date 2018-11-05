using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCGame.Models;

namespace MVCGame.Controllers
{
    public class GameController : Controller
    {
        GameContext db;
        public GameController(GameContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Games.ToList());
        }
    }
}
