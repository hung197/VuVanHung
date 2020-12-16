using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demo_qltp_backend.Model;

namespace demo_qltp_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanHuyenController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public QuanHuyenController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/QuanHuyen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuanHuyen>>> GetquanHuyens()
        {
            return await _context.quanHuyens.ToListAsync();
        }

        // GET: api/QuanHuyen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuanHuyen>> GetQuanHuyen(int id)
        {
            var quanHuyen = await _context.quanHuyens.FindAsync(id);

            if (quanHuyen == null)
            {
                return NotFound();
            }

            return quanHuyen;
        }
        [HttpGet("QuanHuyenByIdThanhPho/{id}")]

        public async Task<ActionResult<List<QuanHuyen>>> GetQuanHuyenByIdThanhPho(int id)
        {
            List<QuanHuyen> quanhuyens = await _context.quanHuyens.Where(x => x.MaTp == id).ToListAsync();

            return quanhuyens;
        }

        // PUT: api/QuanHuyen/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuanHuyen(int id, QuanHuyen quanHuyen)
        {
            if (id != quanHuyen.MaQuanHuyen)
            {
                return BadRequest();
            }

            _context.Entry(quanHuyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuanHuyenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QuanHuyen
        [HttpPost]
        public async Task<ActionResult<QuanHuyen>> PostQuanHuyen(QuanHuyen quanHuyen)
        {
            _context.quanHuyens.Add(quanHuyen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuanHuyen", new { id = quanHuyen.MaQuanHuyen }, quanHuyen);
        }

        // DELETE: api/QuanHuyen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuanHuyen>> DeleteQuanHuyen(int id)
        {
            var quanHuyen = await _context.quanHuyens.FindAsync(id);
            if (quanHuyen == null)
            {
                return NotFound();
            }

            _context.quanHuyens.Remove(quanHuyen);
            await _context.SaveChangesAsync();

            return quanHuyen;
        }

        private bool QuanHuyenExists(int id)
        {
            return _context.quanHuyens.Any(e => e.MaQuanHuyen == id);
        }
    }
   
   
}
