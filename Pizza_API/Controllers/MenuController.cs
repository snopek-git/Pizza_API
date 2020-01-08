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
    public class MenuController : ControllerBase
    {
        private s15885Context _context;
        public MenuController(s15885Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getMenus()
        {
            return Ok(_context.Menu.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult getMenu(int id)
        {
            var menu = _context.Menu.FirstOrDefault(m => m.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        [HttpPost]
        public IActionResult Create(Menu newMenu)
        {
            _context.Menu.Add(newMenu);
            _context.SaveChanges();

            return StatusCode(201, newMenu);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Menu updatedMenu)
        {
            //var p = _context.Menu.Count(p => p.Id == updatedMenu.Id);

            if (_context.Menu.Count(p => p.Id == id) == 0)
            {
                return NotFound();
            }

            _context.Menu.Attach(updatedMenu);
            _context.Entry(updatedMenu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedMenu);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var menu = _context.Menu.FirstOrDefault(p => p.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            _context.Menu.Remove(menu);
            _context.SaveChanges();

            return Ok(menu);
        }
    }
}