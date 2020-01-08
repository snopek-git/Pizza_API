//s15885

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_API.Models;

namespace Pizza_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private s15885Context _context;
        public PizzaController(s15885Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult getPizza(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(p => p.Id == id);

            if(pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        [HttpPost]
        public IActionResult Create(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Pizza updatedPizza)
        {
            //var p = _context.Pizza.Count(p => p.Id == updatedPizza.Id);

            if(_context.Pizza.Count(p => p.Id == id) == 0)
            {
                return NotFound();
            }

            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(p => p.Id == id);

            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }

    }
}