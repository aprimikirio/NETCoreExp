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
    public class PublicationsController : Controller
    {
        PublicationContext db;

        public PublicationsController(PublicationContext context)
        {
            this.db = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Publication> Get()
        {
            return db.Publications.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Publication pub = db.Publications.FirstOrDefault(x => x.Id == id);
            if (pub == null)
                return NotFound();
            return new ObjectResult(pub);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Publication pub)
        {
            if (pub == null)
            {
                return BadRequest();
            }

            db.Publications.Add(pub);
            db.SaveChanges();
            return Ok(pub);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]Publication pub)
        {
            if (pub == null)
            {
                return BadRequest();
            }
            if (!db.Publications.Any(x => x.Id == pub.Id))
            {
                return NotFound();
            }

            db.Update(pub);
            db.SaveChanges();
            return Ok(pub);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Publication pub = db.Publications.FirstOrDefault(x => x.Id == id);
            if (pub == null)
            {
                return NotFound();
            }
            db.Publications.Remove(pub);
            db.SaveChanges();
            return Ok(pub);
        }
    }
}
