using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.Data;
using CRUDAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPI.Controllers
{
    [Route("api/[Controller]")]
    public class StudentController : Controller
    {
        private readonly Context _context;

        public StudentController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Student> Get()
        {
            return _context.Students.ToList();
        }

        [HttpGet("{id}")]
        public async Task<Student> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return student;
        }

        [HttpPost]
        public IActionResult PostStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null) return NotFound();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
