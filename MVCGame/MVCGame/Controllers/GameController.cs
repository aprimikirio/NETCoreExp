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
        [HttpPost]
        public void Play(List<Square> squares)
        {
            for (int i = 0; i < squares.Count; i++)
            {
                db.Squares.Update(
                    new Square
                    {
                        Id = squares[i].Id,
                        GameId = squares[i].GameId,
                        Edge = squares[i].Edge,
                        X = squares[i].X,
                        Y = squares[i].Y
                    }
                );
            }
            db.SaveChanges();
        }
    }
}
