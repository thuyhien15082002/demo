using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<SinhVien> GetSV()
        {
            using (var context = new ApiContext())
            {
                //Get all 
                return context.SinhViens.ToList();


            }
        }
        [HttpGet("{SoCccd}")]
        public async Task<SinhVien> GetSVbySoCCCD(string SoCccd)
        {
            using (var context = new ApiContext())
            {
                // Get student by soCCCD
                var sv = await context.SinhViens.FindAsync(SoCccd);
                return sv;
               
            }
        }
        [HttpPost]
        public async Task<ActionResult<SinhVien>> PostUser(SinhVien sinhVien)
        {
            using (var context = new ApiContext())
            {
                context.SinhViens.Add(sinhVien);
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetSV), new { SoCccd = sinhVien.SoCccd }, sinhVien);
            }
        
        }

        [HttpPut("{SoCccd}")]
        public async Task<IActionResult> PutUser(string SoCccd, SinhVien sv)
        {
            if (SoCccd != sv.SoCccd)
            {
                return BadRequest();
            }
            using (var context = new ApiContext())
            {

                context.Entry(sv).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sinhVienExists(SoCccd))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return NoContent();
        }



        [HttpDelete("{SoCccd}")]
        public async Task<IActionResult> DeleteUser(string SoCccd)
        {
            using (var context = new ApiContext())
            {
                var user = await context.SinhViens.FindAsync(SoCccd);
                if (user == null)
                {
                    return NotFound();
                }

                context.SinhViens.Remove(user);
                await context.SaveChangesAsync();

                return NoContent();
            }
        }

        private bool sinhVienExists(string SoCccd)
        {
            using (var context = new ApiContext())
            {
                return context.SinhViens.Any(e => e.SoCccd == SoCccd);
            }
        }

    }
}
