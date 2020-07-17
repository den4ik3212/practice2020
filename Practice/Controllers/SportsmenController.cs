using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Practice.Models;

namespace Practice.Controllers
{
    [Route("api/Sportsmen")]
    [ApiController]
    public class SportsmenController : ControllerBase
    {
        private readonly SportsmenContext _context;
        public SportsmenController(SportsmenContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSportsmen()
        {
            var sportsmen = _context.Sportsmen.ToList();
            return Ok(sportsmen);
        }

        [HttpGet("{id}")]
        public IActionResult GetSportsmenbyId(int id)
        {
            var sportsmen = _context.Sportsmen.Find(id);
            if (sportsmen == null)
            {
                return NotFound();
            }
            return Ok(sportsmen);
        }

        [HttpPost("{id}/{name}")]
        public IActionResult PostSportsmen( int id, string name)
        {
            var sportsmen = new Sportsmen()
            {
                cl_Id = id,
                sp_Name = name
            };
            _context.Add(sportsmen);
            _context.SaveChanges();
            return Ok("Created");
        }

        [HttpPut("{id}/{id2}/{rename}")]
        public IActionResult PutSportsmen(int id, int id2, string rename)
        {
            var sportsmen = _context.Sportsmen.Find(id);
            if (sportsmen == null)
            {
                return NotFound();
            }
            sportsmen.sp_Name = rename;
            sportsmen.cl_Id = id2;
            _context.Sportsmen.Update(sportsmen);
            _context.SaveChanges();
            return Ok("Update");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSportsmen(int id)
        {
            var sportsmen = _context.Sportsmen.Find(id);
            if (sportsmen == null)
            {
                return NotFound();
            }
            _context.Sportsmen.Remove(sportsmen);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}

