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
        public IActionResult Game()
        {
            return View(db.Games.ToList());
        }
        [HttpGet]
        public IActionResult Play(int RoomID)
        {
            //var allbooks = db.Books.ToList<Book>();var allSquares = db.Squares.Where(c => c.GameId == RoomID);
            ViewData["RoomID"] = RoomID;
            var allSquares = db.Squares.Where(c => c.GameId == RoomID).ToList<Square>();
            return View(allSquares);
        }
        [HttpGet]
        public void Save(List<Square> squares)
        {
            foreach(Square sq in squares)
                db.Squares.Add(sq);
            // сохраняем в бд все изменения
            db.SaveChanges();
        }
    }
}
