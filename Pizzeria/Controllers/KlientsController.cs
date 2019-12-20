using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlientsController : ControllerBase
    {
        private s15410Context _context; 
        public KlientsController(s15410Context context)
        {
            _context = context;
        }
        //api/klients

        /// <summary>
        /// Pobiera listę klientów
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Zwraca posortowaną listę wszystkich klientów</returns>
        [HttpGet]
        public IActionResult GetKlients(string order = "Nazwisko")
        {
            if (order == "id")
            {
                return Ok(_context.Klient.OrderBy(k => k.Id).ToList());
            }
            return Ok(_context.Klient.OrderBy(k => k.Nazwisko).ToList());
        }
        //api/klients/4
        [HttpGet("{id:int}")]
        public IActionResult GetKlient(int id)
        {
            var klient = _context.Klient.FirstOrDefault(k => k.Id == id);
            if(klient == null)
            {
                return NotFound();
            }

            return Ok(klient);
        }
        [HttpPost]
        public IActionResult Create(Klient newKlient)
        {
            _context.Klient.Add(newKlient);
            _context.SaveChanges();

            return StatusCode(201, newKlient);
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Klient updatedKlient)
        {
          

            if (_context.Klient.Count(k => k.Id == id) == 0)
            {
                return NotFound();
            }

            _context.Klient.Attach(updatedKlient);
            _context.Entry(updatedKlient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedKlient);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var klient = _context.Klient.FirstOrDefault(k => k.Id == id);
            if (klient == null)
            {
                return NotFound();
            }

            _context.Klient.Remove(klient);
            _context.SaveChanges();

            return Ok(klient);
        }
    }
}