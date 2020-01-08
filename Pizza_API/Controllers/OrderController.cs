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
    public class OrderController : ControllerBase
    {
        private s15885Context _context;
        public OrderController(s15885Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getOrders()
        {
            return Ok(_context.Order.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult getOrder(int id)
        {
            var order = _context.Order.FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create(Order newOrder)
        {
            _context.Order.Add(newOrder);
            _context.SaveChanges();

            return StatusCode(201, newOrder);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Order updatedOrder)
        {
            //var p = _context.Order.Count(p => p.Id == updatedOrder.Id);

            if (_context.Order.Count(p => p.Id == id) == 0)
            {
                return NotFound();
            }

            _context.Order.Attach(updatedOrder);
            _context.Entry(updatedOrder).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedOrder);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Order.FirstOrDefault(p => p.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }
    }
}