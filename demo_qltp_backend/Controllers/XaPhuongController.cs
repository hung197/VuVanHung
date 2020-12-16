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
    public class XaPhuongController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public XaPhuongController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/XaPhuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<XaPhuong>>> GetxaPhuongs()
        {
            return await _context.xaPhuongs.ToListAsync();
        }

        // GET: api/XaPhuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<XaPhuong>> GetXaPhuong(int id)
        {
            var xaPhuong = await _context.xaPhuongs.FindAsync(id);

            if (xaPhuong == null)
            {
                return NotFound();
            }

            return xaPhuong;
        }
        [HttpGet("XaPhuongByIdQuanHuyen/{id}")]

        public async Task<ActionResult<List<XaPhuong>>> GetXaPhuongByIdQuanHuyen(int id)
        {
            List<XaPhuong> xaPhuongs = await _context.xaPhuongs.Where(x => x.MaXaPhuong == id).ToListAsync();

            return xaPhuongs;
        }

        [HttpGet("getXaPhuongListByIdTp/{id}")]

        public async Task<ActionResult<List<XaPhuong>>> getXaPhuongListByIdTp(int id)
        {
            List<XaPhuong> xaPhuongs = await _context.xaPhuongs.Where(x => x.MaTp == id).ToListAsync();

            return xaPhuongs;
        }

        // PUT: api/XaPhuong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXaPhuong(int id, XaPhuong xaPhuong)
        {
            if (id != xaPhuong.MaXaPhuong)
            {
                return BadRequest();
            }

            _context.Entry(xaPhuong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XaPhuongExists(id))
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

        // POST: api/XaPhuong
        [HttpPost]
        public async Task<ActionResult<XaPhuong>> PostXaPhuong(XaPhuong xaPhuong)
        {
            _context.xaPhuongs.Add(xaPhuong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXaPhuong", new { id = xaPhuong.MaXaPhuong }, xaPhuong);
        }

        // DELETE: api/XaPhuong/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<XaPhuong>> DeleteXaPhuong(int id)
        {
            var xaPhuong = await _context.xaPhuongs.FindAsync(id);
            if (xaPhuong == null)
            {
                return NotFound();
            }

            _context.xaPhuongs.Remove(xaPhuong);
            await _context.SaveChangesAsync();

            return xaPhuong;
        }

        private bool XaPhuongExists(int id)
        {
            return _context.xaPhuongs.Any(e => e.MaXaPhuong == id);
        }
    }
}
