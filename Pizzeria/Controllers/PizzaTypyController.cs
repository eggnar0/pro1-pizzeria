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
    public class PizzaTypyController : ControllerBase
    {
        private s15410Context _context;
        public PizzaTypyController(s15410Context context)
        {
            _context = context;
        }
        //api/pizzatypy
        [HttpGet]
        public IActionResult GetPizzaTypy()
        {
            return Ok(_context.Klient.ToList());
        }
        //api/pizzatypy/4
        [HttpGet("{id:int}")]
        public IActionResult GetPizzaTyp(int id)
        {
            var pizzaTyp = _context.PizzaTyp.FirstOrDefault(p => p.Id == id);
            if (pizzaTyp == null)
            {
                return NotFound();
            }

            return Ok(pizzaTyp);
        }
    }
}