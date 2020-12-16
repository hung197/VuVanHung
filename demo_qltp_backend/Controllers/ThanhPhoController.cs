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
    public class ThanhPhoController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public ThanhPhoController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/ThanhPho
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThanhPho>>> GetthanhPhos()
        {
            var thanhPho = await _context.thanhPhos.ToListAsync();
            //foreach (var itemTP in thanhPho)
            //{
            //    var quanHuyen = await _context.quanHuyens.Where(x => x.MaTp == itemTP.MaTp).ToListAsync();
            //    itemTP.tenQuanHuyen = quanHuyen.Select(x => x.TenQuanHuyen).ToList();
            //    itemTP.tenXaPhuong = new List<string>();
            //    foreach (var itemQH in quanHuyen)
            //    {
            //        var xaPhuong = await _context.xaPhuongs.Where(x => x.MaQuanHuyen == itemQH.MaQuanHuyen).ToListAsync();
            //        itemTP.tenXaPhuong.AddRange(xaPhuong.Select(x => x.TenXaPhuong).ToList());
            //    }
            //}
            return thanhPho;
        }

        // GET: api/ThanhPho/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThanhPho>> GetThanhPho(int id)
        {
            var thanhPho = await _context.thanhPhos.FindAsync(id);

            if (thanhPho == null)
            {
                return NotFound();
            }

            return thanhPho;
        }

        // PUT: api/ThanhPho/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThanhPho(int id, ThanhPho thanhPho)
        {
            if (id != thanhPho.MaTp)
            {
                return BadRequest();
            }

            _context.Entry(thanhPho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThanhPhoExists(id))
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

        // POST: api/ThanhPho
        [HttpPost]
        public async Task<ActionResult<ThanhPho>> PostThanhPho(ThanhPho thanhPho)
        {
            _context.thanhPhos.Add(thanhPho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThanhPho", new { id = thanhPho.MaTp }, thanhPho);
        }

        // DELETE: api/ThanhPho/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ThanhPho>> DeleteThanhPho(int id)
        {
            var thanhPho = await _context.thanhPhos.FindAsync(id);
            if (thanhPho == null)
            {
                return NotFound();
            }

            _context.thanhPhos.Remove(thanhPho);
            await _context.SaveChangesAsync();

            return thanhPho;
        }

        private bool ThanhPhoExists(int id)
        {
            return _context.thanhPhos.Any(e => e.MaTp == id);
        }
    }
}
