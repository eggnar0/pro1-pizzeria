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
    public class ZamowieniaController : ControllerBase
    {
        private s15410Context _context;
        public ZamowieniaController(s15410Context context)
        {
            _context = context;
        }
        //api/zamowienia
        [HttpGet]
        public IActionResult GetZamowienia()
        {
            return Ok(_context.Zamowienie.ToList());
        }
        //api/zamowienia/4
        [HttpGet("{id:int}")]
        public IActionResult GetZamowienie(int id)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(k => k.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return Ok(zamowienie);
        }
    }
}