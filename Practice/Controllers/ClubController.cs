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
    [Route("api/Club")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly ClubContext _context;
        public ClubController(ClubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClub()
        {
            var club = _context.Club.ToList();
            return Ok(club);
        }

        [HttpGet("{id}")]
        public IActionResult GetClubbyId(int id)
        {
            var club = _context.Club.Find(id);
            if (club == null)
            {
                return NotFound();
            }
            return Ok(club);
        }

        [HttpPost("{name}")]
        public IActionResult PostClub(string name)
        {
            var club = new Club()
            {
                cl_Name = name
            };
            _context.Add(club);
            _context.SaveChanges();
            return Ok("Created");
        }

        [HttpPut("{id}/{rename}")]
        public IActionResult PutClub(int id, string rename)
        {
            var club = _context.Club.Find(id);
            if (club == null)
            {
                return NotFound();
            }
            club.cl_Name = rename;
            _context.Club.Update(club);
            _context.SaveChanges();
            return Ok("Update");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClub(int id)
        {
            var club = _context.Club.Find(id);
            if (club == null)
            {
                return NotFound();
            }
            _context.Club.Remove(club);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}

