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
    public class SquaresController : Controller
    {
        GameContext db;
        public SquaresController(GameContext context)
        {
            this.db = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Square> Get()
        {
            return db.Squares.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Square square = db.Squares.FirstOrDefault(x => x.Id == id);
            if (square == null)
                return NotFound();
            return new ObjectResult(square);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Square square)
        {
            if (square == null)
            {
                return BadRequest();
            }

            db.Squares.Add(square);
            db.SaveChanges();
            return Ok(square);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]Square square)
        {
            if (square == null)
            {
                return BadRequest();
            }
            if (!db.Squares.Any(x => x.Id == square.Id))
            {
                return NotFound();
            }

            db.Update(square);
            db.SaveChanges();
            return Ok(square);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Square square = db.Squares.FirstOrDefault(x => x.Id == id);
            if (square == null)
            {
                return NotFound();
            }
            db.Squares.Remove(square);
            db.SaveChanges();
            return Ok(square);
        }
    }
}
