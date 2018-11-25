using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCGame.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCGame.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        GameContext db;
        public GameController(GameContext context)
        {
            this.db = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return db.Games.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Game game = db.Games.FirstOrDefault(x => x.Id == id);
            if (game == null)
                return NotFound();
            return new ObjectResult(game);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Game game)
        {
            if (game == null)
            {
                return BadRequest();
            }

            db.Games.Add(game);
            db.SaveChanges();
            return Ok(game);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]Game game)
        {
            if (game == null)
            {
                return BadRequest();
            }
            if (!db.Games.Any(x => x.Id == game.Id))
            {
                return NotFound();
            }

            db.Update(game);
            db.SaveChanges();
            return Ok(game);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Game game = db.Games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            db.Games.Remove(game);
            db.SaveChanges();
            return Ok(game);
        }
    }
}
