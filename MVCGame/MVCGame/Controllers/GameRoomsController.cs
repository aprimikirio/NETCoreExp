using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCGame.Models;
using Microsoft.AspNetCore.Authorization;

namespace MVCGame.Controllers
{
    public class GameRoomsController : Controller
    {
        GameContext db;
        public GameRoomsController(GameContext context)
        {
            db = context;
        }
        [Authorize]
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
            var thisGame = db.Games.Where(c => c.Id == RoomID).ToList<Game>();
            ViewData["GameName"] = thisGame.First().Name;
            return View(allSquares);
        }

        [HttpGet]
        public IActionResult Watch(int RoomID)
        {
            //var allbooks = db.Books.ToList<Book>();var allSquares = db.Squares.Where(c => c.GameId == RoomID);
            ViewData["RoomID"] = RoomID;
            var allSquares = db.Squares.Where(c => c.GameId == RoomID).ToList<Square>();
            var thisGame = db.Games.Where(c => c.Id == RoomID).ToList<Game>();
            ViewData["GameName"] = thisGame.First().Name;
            return View(allSquares);
        }
        [HttpGet]
        public IActionResult Edit(int RoomID)
        {
            //var allbooks = db.Books.ToList<Book>();var allSquares = db.Squares.Where(c => c.GameId == RoomID);
            ViewData["RoomID"] = RoomID;
            var allSquares = db.Squares.Where(c => c.GameId == RoomID).ToList<Square>();
            return View(allSquares);
        }
        [HttpPost]
        public void Edit(List<Square> squares)
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
